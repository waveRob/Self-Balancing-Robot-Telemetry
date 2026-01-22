using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace interface_pid
{
    public partial class Form1 : Form
    {

        private const int ListenerPort = 5005;
        private const int ControllerPort = 5006;

        private UdpClient _udp;
        private UdpClient _cmdUdp;
        private IPEndPoint _remote = new IPEndPoint(IPAddress.Any, 0);
        private readonly IPEndPoint _cmdTarget = new IPEndPoint(IPAddress.Parse("192.168.137.146"), ControllerPort);

        private bool _pidUiInitialized = false;
        private bool _settingUiProgrammatically = false; // prevents ValueChanged loop

        public Form1()
        {
            InitializeComponent();
            _udp = new UdpClient(ListenerPort);
            _udp.Client.Blocking = false;  // important: don't freeze UI

            _cmdUdp = new UdpClient();
            _cmdUdp.Connect(_cmdTarget);

            plot_formatting(chart1, "Reference Angle", "Angle (deg)", "");
            plot_formatting(chart2, "Angle Control Signal", "Control Signal", "");
            plot_formatting(chart3, "Angle Control Signal", "Control Signal", "");

        }

        private void plot_formatting(Chart chart, string title, string ylabel, string xlabel)
        {
            chart.Titles.Add(title);
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;
            chart.ChartAreas[0].AxisY.Title = ylabel;
            chart.ChartAreas[0].AxisX.Title = xlabel;

            chart.ChartAreas[0].Position.Auto = false;
            chart.ChartAreas[0].Position.X = 5;
            chart.ChartAreas[0].Position.Y = 10;
            chart.ChartAreas[0].Position.Width = 70;
            chart.ChartAreas[0].Position.Height = 80;

            chart.ChartAreas[0].InnerPlotPosition.Auto = false;
            chart.ChartAreas[0].InnerPlotPosition.X = 10;
            chart.ChartAreas[0].InnerPlotPosition.Y = 15;
            chart.ChartAreas[0].InnerPlotPosition.Width = 85;
            chart.ChartAreas[0].InnerPlotPosition.Height = 75;

        }

        // rolling buffers (like deque(maxlen=N))
        private const int N = 500;
        private readonly Queue<double> _t = new();

        private readonly Queue<double> _filt_angl = new();
        private readonly Queue<double> _ref_angl = new();

        private readonly Queue<double> _angl_u = new();
        private readonly Queue<double> _angl_up = new();
        private readonly Queue<double> _angl_ud = new();
        private readonly Queue<double> _angl_ui = new();

        private readonly Queue<double> _stab_u = new();
        private readonly Queue<double> _stab_up = new();
        private readonly Queue<double> _stab_ud = new();
        private readonly Queue<double> _stab_ui = new();

        private double? _t0 = null;  // for time-zeroing like Python

        private void EnqueueWithMax(Queue<double> q, double v)
        {
            if (q.Count >= N) q.Dequeue();
            q.Enqueue(v);
        }

        private void DrainUdpPackets()
        {
            while (_udp.Available > 0)
            {
                byte[] data = _udp.Receive(ref _remote);

                using var doc = JsonDocument.Parse(data);
                var root = doc.RootElement;

                double t = root.GetProperty("t").GetDouble();
                if (_t0 == null) _t0 = t;

                double filt_angl = root.GetProperty("filt_angl").GetDouble();
                double ref_angl = root.GetProperty("ref_angl").GetDouble();

                double angl_u = root.GetProperty("angl_u").GetDouble();
                double angl_up = root.GetProperty("angl_up").GetDouble();
                double angl_ud = root.GetProperty("angl_ud").GetDouble();
                double angl_ui = root.GetProperty("angl_ui").GetDouble();

                double stab_u = root.GetProperty("stab_u").GetDouble();
                double stab_up = root.GetProperty("stab_up").GetDouble();
                double stab_ud = root.GetProperty("stab_ud").GetDouble();
                double stab_ui = root.GetProperty("stab_ui").GetDouble();

                double angl_kp = root.GetProperty("angl_kp").GetDouble();
                double angl_ki = root.GetProperty("angl_ki").GetDouble();
                double angl_kd = root.GetProperty("angl_kd").GetDouble();

                double stab_kp = root.GetProperty("stab_kp").GetDouble();
                double stab_ki = root.GetProperty("stab_ki").GetDouble();
                double stab_kd = root.GetProperty("stab_kd").GetDouble();

                EnqueueWithMax(_t, t - _t0.Value);
                EnqueueWithMax(_filt_angl, filt_angl);
                EnqueueWithMax(_ref_angl, ref_angl);

                EnqueueWithMax(_angl_u, angl_u);
                EnqueueWithMax(_angl_up, angl_up);
                EnqueueWithMax(_angl_ud, angl_ud);
                EnqueueWithMax(_angl_ui, angl_ui);

                EnqueueWithMax(_stab_u, stab_u);
                EnqueueWithMax(_stab_up, stab_up);
                EnqueueWithMax(_stab_ud, stab_ud);
                EnqueueWithMax(_stab_ui, stab_ui);

                if (!_pidUiInitialized)
                {
                    _settingUiProgrammatically = true;

                    numericUpDownAnglKp.Value = (decimal)angl_kp;
                    numericUpDownAnglKi.Value = (decimal)angl_ki;
                    numericUpDownAnglKd.Value = (decimal)angl_kd;
                    numericUpDownStabKp.Value = (decimal)stab_kp;
                    numericUpDownStabKi.Value = (decimal)stab_ki;
                    numericUpDownStabKd.Value = (decimal)stab_kd;
                    _pidUiInitialized = true;
                    _settingUiProgrammatically = false;
                }

                if (false)
                { 
                var dbg = $"angl kp={angl_kp:F5} ki={angl_ki:F5} kd={angl_kd:F5} | " +
                $"stab kp={stab_kp:F5} ki={stab_ki:F5} kd={stab_kd:F5}";
                Debug.WriteLine(dbg);    // shows immediately in Output window (Debug pane)
                this.Text = dbg;         // shows in the form title bar during run
                }
            }
        }

        private void SendUdpPackets()
        {
            double stab_kp = (double)numericUpDownStabKp.Value;
            double stab_ki = (double)numericUpDownStabKi.Value;
            double stab_kd = (double)numericUpDownStabKd.Value;
            double angl_kp = (double)numericUpDownAnglKp.Value;
            double angl_ki = (double)numericUpDownAnglKi.Value;
            double angl_kd = (double)numericUpDownAnglKd.Value;

            var msg = new Dictionary<string, double>
            {
                {"stab_kp", stab_kp},
                {"stab_ki", stab_ki},
                {"stab_kd", stab_kd},
                {"angl_kp", angl_kp},
                {"angl_ki", angl_ki},
                {"angl_kd", angl_kd},
            };

            string jsonString = JsonSerializer.Serialize(msg);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

            _cmdUdp.Send(bytes, bytes.Length);
        }

        private void RedrawChart1()
        {
            if (_t.Count == 0) return;

            var t = _t.ToArray();
            var m = _filt_angl.ToArray();
            var r = _ref_angl.ToArray();

            var sF = chart1.Series["filt_angl"];
            var sR = chart1.Series["ref_angl"];

            sF.Points.Clear();
            sR.Points.Clear();

            int n = t.Length;
            for (int i = 0; i < n; i++)
            {
                sF.Points.AddXY(t[i], m[i]);
                sR.Points.AddXY(t[i], r[i]);
            }
        }

        private void RedrawChart2()
        {
            if (_t.Count == 0) return;

            var t = _t.ToArray();
            var u = _angl_u.ToArray();
            var up = _angl_up.ToArray();
            var ud = _angl_ud.ToArray();
            var ui = _angl_ui.ToArray();

            var sU = chart2.Series["angl_u"];
            var sUP = chart2.Series["angl_up"];
            var sUD = chart2.Series["angl_ud"];
            var sUI = chart2.Series["angl_ui"];

            sU.Points.Clear();
            sUP.Points.Clear();
            sUD.Points.Clear();
            sUI.Points.Clear();

            int n = t.Length;
            for (int i = 0; i < n; i++)
            {
                sU.Points.AddXY(t[i], u[i]);
                sUP.Points.AddXY(t[i], up[i]);
                sUD.Points.AddXY(t[i], ud[i]);
                sUI.Points.AddXY(t[i], ui[i]);
            }
        }

        private void RedrawChart3()
        {
            if (_t.Count == 0) return;

            var t = _t.ToArray();
            var u = _stab_u.ToArray();
            var up = _stab_up.ToArray();
            var ud = _stab_ud.ToArray();
            var ui = _stab_ui.ToArray();

            var sU = chart3.Series["stab_u"];
            var sUP = chart3.Series["stab_up"];
            var sUD = chart3.Series["stab_ud"];
            var sUI = chart3.Series["stab_ui"];

            sU.Points.Clear();
            sUP.Points.Clear();
            sUD.Points.Clear();
            sUI.Points.Clear();

            int n = t.Length;
            for (int i = 0; i < n; i++)
            {
                sU.Points.AddXY(t[i], u[i]);
                sUP.Points.AddXY(t[i], up[i]);
                sUD.Points.AddXY(t[i], ud[i]);
                sUI.Points.AddXY(t[i], ui[i]);
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DrainUdpPackets();
            }
            catch
            {
                // keep it simple for now;
            }

            RedrawChart1();
            RedrawChart2();
            RedrawChart3();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownAnglKp_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
        private void numericUpDownAnglKi_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
        private void numericUpDownAnglKd_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
        private void numericUpDownStabKp_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
        private void numericUpDownStabKi_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
        private void numericUpDownStabKd_ValueChanged(object sender, EventArgs e)
        {
            SendUdpPackets();
        }
    }
}

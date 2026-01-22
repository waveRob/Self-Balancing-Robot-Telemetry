namespace interface_pid
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            timer1 = new System.Windows.Forms.Timer(components);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            numericUpDownAnglKp = new NumericUpDown();
            numericUpDownAnglKi = new NumericUpDown();
            numericUpDownAnglKd = new NumericUpDown();
            numericUpDownStabKp = new NumericUpDown();
            numericUpDownStabKi = new NumericUpDown();
            numericUpDownStabKd = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKd).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(12, 12);
            chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "filt_angl";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.Green;
            series2.Legend = "Legend1";
            series2.Name = "ref_angl";
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Size = new Size(1288, 239);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chart2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.Name = "ChartArea2";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend2";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(12, 257);
            chart2.Name = "chart2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea2";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = Color.Red;
            series3.Legend = "Legend2";
            series3.Name = "angl_u";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea2";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = Color.Green;
            series4.Legend = "Legend2";
            series4.Name = "angl_up";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea2";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = Color.Orange;
            series5.Legend = "Legend2";
            series5.Name = "angl_ui";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea2";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = Color.Blue;
            series6.Legend = "Legend2";
            series6.Name = "angl_ud";
            chart2.Series.Add(series3);
            chart2.Series.Add(series4);
            chart2.Series.Add(series5);
            chart2.Series.Add(series6);
            chart2.Size = new Size(1288, 239);
            chart2.TabIndex = 2;
            chart2.Text = "chart2";
            // 
            // chart3
            // 
            chart3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea3.Name = "ChartArea3";
            chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend3";
            chart3.Legends.Add(legend3);
            chart3.Location = new Point(12, 502);
            chart3.Name = "chart3";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea3";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = Color.Red;
            series7.Legend = "Legend3";
            series7.Name = "stab_u";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea3";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = Color.Green;
            series8.Legend = "Legend3";
            series8.Name = "stab_up";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea3";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = Color.Orange;
            series9.Legend = "Legend3";
            series9.Name = "stab_ui";
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea3";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = Color.Blue;
            series10.Legend = "Legend3";
            series10.Name = "stab_ud";
            chart3.Series.Add(series7);
            chart3.Series.Add(series8);
            chart3.Series.Add(series9);
            chart3.Series.Add(series10);
            chart3.Size = new Size(1288, 239);
            chart3.TabIndex = 2;
            chart3.Text = "chart3";
            // 
            // numericUpDownAnglKp
            // 
            numericUpDownAnglKp.DecimalPlaces = 5;
            numericUpDownAnglKp.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownAnglKp.Location = new Point(12, 820);
            numericUpDownAnglKp.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownAnglKp.Name = "numericUpDownAnglKp";
            numericUpDownAnglKp.Size = new Size(193, 39);
            numericUpDownAnglKp.TabIndex = 3;
            numericUpDownAnglKp.Tag = "";
            numericUpDownAnglKp.ValueChanged += numericUpDownAnglKp_ValueChanged;
            // 
            // numericUpDownAnglKi
            // 
            numericUpDownAnglKi.DecimalPlaces = 5;
            numericUpDownAnglKi.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownAnglKi.Location = new Point(211, 820);
            numericUpDownAnglKi.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownAnglKi.Name = "numericUpDownAnglKi";
            numericUpDownAnglKi.Size = new Size(193, 39);
            numericUpDownAnglKi.TabIndex = 7;
            numericUpDownAnglKi.Tag = "";
            numericUpDownAnglKi.ValueChanged += numericUpDownAnglKi_ValueChanged;
            // 
            // numericUpDownAnglKd
            // 
            numericUpDownAnglKd.DecimalPlaces = 5;
            numericUpDownAnglKd.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownAnglKd.Location = new Point(410, 820);
            numericUpDownAnglKd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownAnglKd.Name = "numericUpDownAnglKd";
            numericUpDownAnglKd.Size = new Size(193, 39);
            numericUpDownAnglKd.TabIndex = 8;
            numericUpDownAnglKd.Tag = "";
            numericUpDownAnglKd.ValueChanged += numericUpDownAnglKd_ValueChanged;
            // 
            // numericUpDownStabKp
            // 
            numericUpDownStabKp.DecimalPlaces = 5;
            numericUpDownStabKp.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownStabKp.Location = new Point(12, 918);
            numericUpDownStabKp.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownStabKp.Name = "numericUpDownStabKp";
            numericUpDownStabKp.Size = new Size(193, 39);
            numericUpDownStabKp.TabIndex = 9;
            numericUpDownStabKp.Tag = "";
            numericUpDownStabKp.ValueChanged += numericUpDownStabKp_ValueChanged;
            // 
            // numericUpDownStabKi
            // 
            numericUpDownStabKi.DecimalPlaces = 5;
            numericUpDownStabKi.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownStabKi.Location = new Point(211, 918);
            numericUpDownStabKi.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownStabKi.Name = "numericUpDownStabKi";
            numericUpDownStabKi.Size = new Size(193, 39);
            numericUpDownStabKi.TabIndex = 10;
            numericUpDownStabKi.Tag = "";
            numericUpDownStabKi.ValueChanged += numericUpDownStabKi_ValueChanged;
            // 
            // numericUpDownStabKd
            // 
            numericUpDownStabKd.DecimalPlaces = 5;
            numericUpDownStabKd.Increment = new decimal(new int[] { 1, 0, 0, 327680 });
            numericUpDownStabKd.Location = new Point(410, 918);
            numericUpDownStabKd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownStabKd.Name = "numericUpDownStabKd";
            numericUpDownStabKd.Size = new Size(193, 39);
            numericUpDownStabKd.TabIndex = 11;
            numericUpDownStabKd.Tag = "";
            numericUpDownStabKd.ValueChanged += numericUpDownStabKd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 785);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 6;
            label1.Text = "Angle Kp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 785);
            label2.Name = "label2";
            label2.Size = new Size(103, 32);
            label2.TabIndex = 12;
            label2.Text = "Angle Ki";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(410, 785);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 13;
            label3.Text = "Angle Kd";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 883);
            label4.Name = "label4";
            label4.Size = new Size(164, 32);
            label4.TabIndex = 14;
            label4.Text = "Stabalizing Kp";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(211, 883);
            label5.Name = "label5";
            label5.Size = new Size(156, 32);
            label5.TabIndex = 15;
            label5.Text = "Stabalizing Ki";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(410, 883);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 16;
            label6.Text = "Stabalizing Kd";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 995);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownStabKd);
            Controls.Add(numericUpDownStabKi);
            Controls.Add(numericUpDownStabKp);
            Controls.Add(numericUpDownAnglKd);
            Controls.Add(numericUpDownAnglKi);
            Controls.Add(numericUpDownAnglKp);
            Controls.Add(chart3);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Name = "Form1";
            Text = "Control Interface";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAnglKd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStabKd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private NumericUpDown numericUpDownAnglKp;
        private NumericUpDown numericUpDownAnglKi;
        private NumericUpDown numericUpDownAnglKd;
        private NumericUpDown numericUpDownStabKp;
        private NumericUpDown numericUpDownStabKi;
        private NumericUpDown numericUpDownStabKd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}

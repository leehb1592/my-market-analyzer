﻿namespace MyMarketAnalyzer
{
    partial class AlgorithmDesignForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.dataTableMain = new MyMarketAnalyzer.StatTable();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.chartMain = new MyMarketAnalyzer.CustomChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbPrototype = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbProtoAttributeY = new System.Windows.Forms.ComboBox();
            this.cbProtoFunction = new System.Windows.Forms.ComboBox();
            this.cbProtoAttributeX = new System.Windows.Forms.ComboBox();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.numParam1 = new System.Windows.Forms.NumericUpDown();
            this.numParam3 = new System.Windows.Forms.NumericUpDown();
            this.numParam2 = new System.Windows.Forms.NumericUpDown();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numGroupMax = new System.Windows.Forms.NumericUpDown();
            this.numGroupMin = new System.Windows.Forms.NumericUpDown();
            this.numTestPct = new System.Windows.Forms.NumericUpDown();
            this.algorithmSelectListBox = new System.Windows.Forms.ListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.trackBarTrainingPct = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numTrainingPct = new System.Windows.Forms.NumericUpDown();
            this.tabConsoleContainer = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPrototype.SuspendLayout();
            this.gbParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParam3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroupMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroupMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTestPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrainingPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingPct)).BeginInit();
            this.tabConsoleContainer.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabConsoleContainer, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 530);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageChart);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 148);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 379);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.dataTableMain);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(487, 353);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // dataTableMain
            // 
            this.dataTableMain.AutoScroll = true;
            this.dataTableMain.AutoSize = true;
            this.dataTableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableMain.Location = new System.Drawing.Point(3, 3);
            this.dataTableMain.Name = "dataTableMain";
            this.dataTableMain.Size = new System.Drawing.Size(481, 347);
            this.dataTableMain.TabIndex = 0;
            this.dataTableMain.TableType = MyMarketAnalyzer.StatTableType.HIST_STATS;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.chartMain);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(487, 353);
            this.tabPageChart.TabIndex = 1;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // chartMain
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            this.chartMain.CurrentSeriesIndex = 0;
            this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "chartLegend";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(3, 3);
            this.chartMain.Name = "chartMain";
            this.chartMain.Size = new System.Drawing.Size(481, 347);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "customChart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.numTestPct);
            this.panel1.Controls.Add(this.algorithmSelectListBox);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.trackBarTrainingPct);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numTrainingPct);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 114);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gbPrototype);
            this.groupBox1.Controls.Add(this.gbParameters);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numGroupMax);
            this.groupBox1.Controls.Add(this.numGroupMin);
            this.groupBox1.Location = new System.Drawing.Point(437, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // gbPrototype
            // 
            this.gbPrototype.Controls.Add(this.label7);
            this.gbPrototype.Controls.Add(this.label6);
            this.gbPrototype.Controls.Add(this.label5);
            this.gbPrototype.Controls.Add(this.cbProtoAttributeY);
            this.gbPrototype.Controls.Add(this.cbProtoFunction);
            this.gbPrototype.Controls.Add(this.cbProtoAttributeX);
            this.gbPrototype.Location = new System.Drawing.Point(139, 3);
            this.gbPrototype.Name = "gbPrototype";
            this.gbPrototype.Size = new System.Drawing.Size(200, 108);
            this.gbPrototype.TabIndex = 15;
            this.gbPrototype.TabStop = false;
            this.gbPrototype.Text = "Feature Selection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Fn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "X:";
            // 
            // cbProtoAttributeY
            // 
            this.cbProtoAttributeY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtoAttributeY.FormattingEnabled = true;
            this.cbProtoAttributeY.Location = new System.Drawing.Point(32, 42);
            this.cbProtoAttributeY.Name = "cbProtoAttributeY";
            this.cbProtoAttributeY.Size = new System.Drawing.Size(160, 21);
            this.cbProtoAttributeY.TabIndex = 2;
            this.cbProtoAttributeY.SelectedIndexChanged += new System.EventHandler(this.cbProtoAttribute_YIndexChanged);
            // 
            // cbProtoFunction
            // 
            this.cbProtoFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtoFunction.FormattingEnabled = true;
            this.cbProtoFunction.Location = new System.Drawing.Point(32, 72);
            this.cbProtoFunction.Name = "cbProtoFunction";
            this.cbProtoFunction.Size = new System.Drawing.Size(160, 21);
            this.cbProtoFunction.TabIndex = 1;
            // 
            // cbProtoAttributeX
            // 
            this.cbProtoAttributeX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtoAttributeX.FormattingEnabled = true;
            this.cbProtoAttributeX.Location = new System.Drawing.Point(32, 14);
            this.cbProtoAttributeX.Name = "cbProtoAttributeX";
            this.cbProtoAttributeX.Size = new System.Drawing.Size(160, 21);
            this.cbProtoAttributeX.TabIndex = 0;
            this.cbProtoAttributeX.SelectedIndexChanged += new System.EventHandler(this.cbProtoAttribute_XIndexChanged);
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.lblParam1);
            this.gbParameters.Controls.Add(this.lblParam3);
            this.gbParameters.Controls.Add(this.numParam1);
            this.gbParameters.Controls.Add(this.numParam3);
            this.gbParameters.Controls.Add(this.numParam2);
            this.gbParameters.Controls.Add(this.lblParam2);
            this.gbParameters.Location = new System.Drawing.Point(345, 3);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(166, 108);
            this.gbParameters.TabIndex = 14;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Paramters";
            this.gbParameters.Visible = false;
            // 
            // lblParam1
            // 
            this.lblParam1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParam1.AutoSize = true;
            this.lblParam1.Location = new System.Drawing.Point(72, 16);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(42, 13);
            this.lblParam1.TabIndex = 9;
            this.lblParam1.Text = "param1";
            this.lblParam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblParam3
            // 
            this.lblParam3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParam3.AutoSize = true;
            this.lblParam3.Location = new System.Drawing.Point(72, 75);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(42, 13);
            this.lblParam3.TabIndex = 13;
            this.lblParam3.Text = "param3";
            // 
            // numParam1
            // 
            this.numParam1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numParam1.Location = new System.Drawing.Point(120, 14);
            this.numParam1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numParam1.Name = "numParam1";
            this.numParam1.Size = new System.Drawing.Size(40, 20);
            this.numParam1.TabIndex = 8;
            this.numParam1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numParam3
            // 
            this.numParam3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numParam3.Location = new System.Drawing.Point(120, 73);
            this.numParam3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numParam3.Name = "numParam3";
            this.numParam3.Size = new System.Drawing.Size(40, 20);
            this.numParam3.TabIndex = 12;
            this.numParam3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numParam2
            // 
            this.numParam2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numParam2.Location = new System.Drawing.Point(120, 43);
            this.numParam2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numParam2.Name = "numParam2";
            this.numParam2.Size = new System.Drawing.Size(40, 20);
            this.numParam2.TabIndex = 10;
            this.numParam2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblParam2
            // 
            this.lblParam2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParam2.AutoSize = true;
            this.lblParam2.Location = new System.Drawing.Point(72, 45);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(42, 13);
            this.lblParam2.TabIndex = 11;
            this.lblParam2.Text = "param2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max. Class Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min. Class Size:";
            // 
            // numGroupMax
            // 
            this.numGroupMax.Location = new System.Drawing.Point(93, 37);
            this.numGroupMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGroupMax.Name = "numGroupMax";
            this.numGroupMax.Size = new System.Drawing.Size(40, 20);
            this.numGroupMax.TabIndex = 5;
            this.numGroupMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numGroupMin
            // 
            this.numGroupMin.Location = new System.Drawing.Point(93, 8);
            this.numGroupMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGroupMin.Name = "numGroupMin";
            this.numGroupMin.Size = new System.Drawing.Size(40, 20);
            this.numGroupMin.TabIndex = 4;
            this.numGroupMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTestPct
            // 
            this.numTestPct.Location = new System.Drawing.Point(343, 8);
            this.numTestPct.Name = "numTestPct";
            this.numTestPct.Size = new System.Drawing.Size(40, 20);
            this.numTestPct.TabIndex = 4;
            this.numTestPct.ValueChanged += new System.EventHandler(this.numTestPct_ValueChanged);
            // 
            // algorithmSelectListBox
            // 
            this.algorithmSelectListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmSelectListBox.FormattingEnabled = true;
            this.algorithmSelectListBox.ItemHeight = 15;
            this.algorithmSelectListBox.Location = new System.Drawing.Point(3, 3);
            this.algorithmSelectListBox.Name = "algorithmSelectListBox";
            this.algorithmSelectListBox.Size = new System.Drawing.Size(194, 109);
            this.algorithmSelectListBox.TabIndex = 0;
            this.algorithmSelectListBox.SelectedIndexChanged += new System.EventHandler(this.algorithm_SelectionChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(205, 90);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(226, 22);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run Classifier";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // trackBarTrainingPct
            // 
            this.trackBarTrainingPct.LargeChange = 10;
            this.trackBarTrainingPct.Location = new System.Drawing.Point(205, 39);
            this.trackBarTrainingPct.Maximum = 100;
            this.trackBarTrainingPct.Name = "trackBarTrainingPct";
            this.trackBarTrainingPct.Size = new System.Drawing.Size(226, 45);
            this.trackBarTrainingPct.SmallChange = 5;
            this.trackBarTrainingPct.TabIndex = 2;
            this.trackBarTrainingPct.TickFrequency = 5;
            this.trackBarTrainingPct.Value = 75;
            this.trackBarTrainingPct.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "% Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "% Training";
            // 
            // numTrainingPct
            // 
            this.numTrainingPct.Location = new System.Drawing.Point(267, 8);
            this.numTrainingPct.Name = "numTrainingPct";
            this.numTrainingPct.Size = new System.Drawing.Size(40, 20);
            this.numTrainingPct.TabIndex = 3;
            this.numTrainingPct.ValueChanged += new System.EventHandler(this.numTrainingPct_ValueChanged);
            // 
            // tabConsoleContainer
            // 
            this.tabConsoleContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConsoleContainer.Controls.Add(this.tabPageMain);
            this.tabConsoleContainer.Location = new System.Drawing.Point(504, 148);
            this.tabConsoleContainer.Name = "tabConsoleContainer";
            this.tabConsoleContainer.SelectedIndex = 0;
            this.tabConsoleContainer.Size = new System.Drawing.Size(495, 147);
            this.tabConsoleContainer.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.richTextBox1);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(487, 121);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Console";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(481, 115);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // AlgorithmDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlgorithmDesignForm";
            this.Text = "Pattern Discovery";
            this.Shown += new System.EventHandler(this.algDesignForm_FirstShown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.tabPageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPrototype.ResumeLayout(false);
            this.gbPrototype.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParam3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroupMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroupMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTestPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrainingPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingPct)).EndInit();
            this.tabConsoleContainer.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private StatTable dataTableMain;
        private System.Windows.Forms.TabPage tabPageChart;
        private CustomChart chartMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numTestPct;
        private System.Windows.Forms.ListBox algorithmSelectListBox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TrackBar trackBarTrainingPct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTrainingPct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numGroupMax;
        private System.Windows.Forms.NumericUpDown numGroupMin;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.NumericUpDown numParam3;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.NumericUpDown numParam2;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.NumericUpDown numParam1;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbPrototype;
        private System.Windows.Forms.ComboBox cbProtoFunction;
        private System.Windows.Forms.ComboBox cbProtoAttributeX;
        private System.Windows.Forms.ComboBox cbProtoAttributeY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabConsoleContainer;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}
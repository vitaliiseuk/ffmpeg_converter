namespace iNVMSMain
{
    partial class FrmSystemConfigurationUsageInfo
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
            this.components = new System.ComponentModel.Container();
            this.tabUsageInfo = new System.Windows.Forms.TabControl();
            this.pageCPU = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataChartCpu = new iNVMS.CustomControl.DataChart();
            this.lblCpuPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pageMemory = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vMemChart = new iNVMS.CustomControl.DataChart();
            this.lblvPercentM = new System.Windows.Forms.Label();
            this.lblvUsedM = new System.Windows.Forms.Label();
            this.lblvTotalM = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pMemChart = new iNVMS.CustomControl.DataChart();
            this.lblpPercentM = new System.Windows.Forms.Label();
            this.lblpUsedM = new System.Windows.Forms.Label();
            this.lblpTotalM = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageNetwork = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataChartNet = new iNVMS.CustomControl.DataChart();
            this.label22 = new System.Windows.Forms.Label();
            this.lblNetPercent = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNetUsedSpeed = new System.Windows.Forms.Label();
            this.lblNetStatus = new System.Windows.Forms.Label();
            this.lblNetOrigSpeed = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbNetwork = new System.Windows.Forms.ComboBox();
            this.pageCameraInfo = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewCameraInfoD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCameraInfoT = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBitRateRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageStoragePath = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.probarHardDiskCal = new System.Windows.Forms.ProgressBar();
            this.txtTotalRecordTime = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cpuChart = new iNVMS.CustomControl.DataChart();
            this.listStoragePath = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabUsageInfo.SuspendLayout();
            this.pageCPU.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageMemory.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pageNetwork.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pageCameraInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraInfoD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraInfoT)).BeginInit();
            this.pageStoragePath.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUsageInfo
            // 
            this.tabUsageInfo.Controls.Add(this.pageCPU);
            this.tabUsageInfo.Controls.Add(this.pageMemory);
            this.tabUsageInfo.Controls.Add(this.pageNetwork);
            this.tabUsageInfo.Controls.Add(this.pageCameraInfo);
            this.tabUsageInfo.Controls.Add(this.pageStoragePath);
            this.tabUsageInfo.Location = new System.Drawing.Point(12, 12);
            this.tabUsageInfo.Name = "tabUsageInfo";
            this.tabUsageInfo.SelectedIndex = 0;
            this.tabUsageInfo.Size = new System.Drawing.Size(560, 387);
            this.tabUsageInfo.TabIndex = 0;
            // 
            // pageCPU
            // 
            this.pageCPU.Controls.Add(this.panel1);
            this.pageCPU.Location = new System.Drawing.Point(4, 22);
            this.pageCPU.Name = "pageCPU";
            this.pageCPU.Padding = new System.Windows.Forms.Padding(3);
            this.pageCPU.Size = new System.Drawing.Size(552, 361);
            this.pageCPU.TabIndex = 0;
            this.pageCPU.Text = "CPU";
            this.pageCPU.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataChartCpu);
            this.panel1.Controls.Add(this.lblCpuPercent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 349);
            this.panel1.TabIndex = 0;
            // 
            // dataChartCpu
            // 
            this.dataChartCpu.BackColor = System.Drawing.Color.Black;
            this.dataChartCpu.ChartType = iNVMS.CustomControl.ChartType.Line;
            this.dataChartCpu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataChartCpu.GridPixels = 12;
            this.dataChartCpu.InitialHeight = 100;
            this.dataChartCpu.LineColor = System.Drawing.Color.Lime;
            this.dataChartCpu.Location = new System.Drawing.Point(13, 17);
            this.dataChartCpu.Name = "dataChartCpu";
            this.dataChartCpu.Size = new System.Drawing.Size(511, 276);
            this.dataChartCpu.TabIndex = 3;
            // 
            // lblCpuPercent
            // 
            this.lblCpuPercent.AutoSize = true;
            this.lblCpuPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpuPercent.Location = new System.Drawing.Point(402, 296);
            this.lblCpuPercent.Name = "lblCpuPercent";
            this.lblCpuPercent.Size = new System.Drawing.Size(23, 20);
            this.lblCpuPercent.TabIndex = 2;
            this.lblCpuPercent.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Utility :";
            // 
            // pageMemory
            // 
            this.pageMemory.Controls.Add(this.panel2);
            this.pageMemory.Location = new System.Drawing.Point(4, 22);
            this.pageMemory.Name = "pageMemory";
            this.pageMemory.Padding = new System.Windows.Forms.Padding(3);
            this.pageMemory.Size = new System.Drawing.Size(552, 361);
            this.pageMemory.TabIndex = 1;
            this.pageMemory.Text = "Memory";
            this.pageMemory.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 349);
            this.panel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vMemChart);
            this.groupBox2.Controls.Add(this.lblvPercentM);
            this.groupBox2.Controls.Add(this.lblvUsedM);
            this.groupBox2.Controls.Add(this.lblvTotalM);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(285, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Virtual Memory Size";
            // 
            // vMemChart
            // 
            this.vMemChart.BackColor = System.Drawing.Color.Black;
            this.vMemChart.ChartType = iNVMS.CustomControl.ChartType.Line;
            this.vMemChart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.vMemChart.GridPixels = 12;
            this.vMemChart.InitialHeight = 100;
            this.vMemChart.LineColor = System.Drawing.Color.Lime;
            this.vMemChart.Location = new System.Drawing.Point(7, 20);
            this.vMemChart.Name = "vMemChart";
            this.vMemChart.Size = new System.Drawing.Size(229, 183);
            this.vMemChart.TabIndex = 7;
            // 
            // lblvPercentM
            // 
            this.lblvPercentM.AutoSize = true;
            this.lblvPercentM.Location = new System.Drawing.Point(192, 268);
            this.lblvPercentM.Name = "lblvPercentM";
            this.lblvPercentM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblvPercentM.Size = new System.Drawing.Size(15, 13);
            this.lblvPercentM.TabIndex = 6;
            this.lblvPercentM.Text = "%";
            // 
            // lblvUsedM
            // 
            this.lblvUsedM.AutoSize = true;
            this.lblvUsedM.Location = new System.Drawing.Point(189, 240);
            this.lblvUsedM.Name = "lblvUsedM";
            this.lblvUsedM.Size = new System.Drawing.Size(23, 13);
            this.lblvUsedM.TabIndex = 5;
            this.lblvUsedM.Text = "MB";
            // 
            // lblvTotalM
            // 
            this.lblvTotalM.AutoSize = true;
            this.lblvTotalM.Location = new System.Drawing.Point(188, 215);
            this.lblvTotalM.Name = "lblvTotalM";
            this.lblvTotalM.Size = new System.Drawing.Size(23, 13);
            this.lblvTotalM.TabIndex = 4;
            this.lblvTotalM.Text = "MB";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Utility Rate:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Used Memory:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pMemChart);
            this.groupBox1.Controls.Add(this.lblpPercentM);
            this.groupBox1.Controls.Add(this.lblpUsedM);
            this.groupBox1.Controls.Add(this.lblpTotalM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Physical Memory Size";
            // 
            // pMemChart
            // 
            this.pMemChart.BackColor = System.Drawing.Color.Black;
            this.pMemChart.ChartType = iNVMS.CustomControl.ChartType.Line;
            this.pMemChart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pMemChart.GridPixels = 12;
            this.pMemChart.InitialHeight = 100;
            this.pMemChart.LineColor = System.Drawing.Color.Lime;
            this.pMemChart.Location = new System.Drawing.Point(7, 20);
            this.pMemChart.Name = "pMemChart";
            this.pMemChart.Size = new System.Drawing.Size(229, 183);
            this.pMemChart.TabIndex = 7;
            // 
            // lblpPercentM
            // 
            this.lblpPercentM.AutoSize = true;
            this.lblpPercentM.Location = new System.Drawing.Point(193, 268);
            this.lblpPercentM.Name = "lblpPercentM";
            this.lblpPercentM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblpPercentM.Size = new System.Drawing.Size(15, 13);
            this.lblpPercentM.TabIndex = 6;
            this.lblpPercentM.Text = "%";
            // 
            // lblpUsedM
            // 
            this.lblpUsedM.AutoSize = true;
            this.lblpUsedM.Location = new System.Drawing.Point(192, 240);
            this.lblpUsedM.Name = "lblpUsedM";
            this.lblpUsedM.Size = new System.Drawing.Size(23, 13);
            this.lblpUsedM.TabIndex = 5;
            this.lblpUsedM.Text = "MB";
            // 
            // lblpTotalM
            // 
            this.lblpTotalM.AutoSize = true;
            this.lblpTotalM.Location = new System.Drawing.Point(191, 215);
            this.lblpTotalM.Name = "lblpTotalM";
            this.lblpTotalM.Size = new System.Drawing.Size(23, 13);
            this.lblpTotalM.TabIndex = 4;
            this.lblpTotalM.Text = "MB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Utility Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Used Memory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total:";
            // 
            // pageNetwork
            // 
            this.pageNetwork.Controls.Add(this.panel3);
            this.pageNetwork.Location = new System.Drawing.Point(4, 22);
            this.pageNetwork.Name = "pageNetwork";
            this.pageNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.pageNetwork.Size = new System.Drawing.Size(552, 361);
            this.pageNetwork.TabIndex = 2;
            this.pageNetwork.Text = "Network";
            this.pageNetwork.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.dataChartNet);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.lblNetPercent);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.cmbNetwork);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(540, 349);
            this.panel3.TabIndex = 0;
            // 
            // dataChartNet
            // 
            this.dataChartNet.BackColor = System.Drawing.Color.Black;
            this.dataChartNet.ChartType = iNVMS.CustomControl.ChartType.Line;
            this.dataChartNet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataChartNet.GridPixels = 12;
            this.dataChartNet.InitialHeight = 1000;
            this.dataChartNet.LineColor = System.Drawing.Color.Lime;
            this.dataChartNet.Location = new System.Drawing.Point(4, 4);
            this.dataChartNet.Name = "dataChartNet";
            this.dataChartNet.Size = new System.Drawing.Size(533, 220);
            this.dataChartNet.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(312, 324);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "Utility Rate :";
            // 
            // lblNetPercent
            // 
            this.lblNetPercent.AutoSize = true;
            this.lblNetPercent.Location = new System.Drawing.Point(439, 324);
            this.lblNetPercent.Name = "lblNetPercent";
            this.lblNetPercent.Size = new System.Drawing.Size(15, 13);
            this.lblNetPercent.TabIndex = 4;
            this.lblNetPercent.Text = "%";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNetUsedSpeed);
            this.groupBox3.Controls.Add(this.lblNetStatus);
            this.groupBox3.Controls.Add(this.lblNetOrigSpeed);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(143, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bandwidth";
            // 
            // lblNetUsedSpeed
            // 
            this.lblNetUsedSpeed.AutoSize = true;
            this.lblNetUsedSpeed.Location = new System.Drawing.Point(289, 43);
            this.lblNetUsedSpeed.Name = "lblNetUsedSpeed";
            this.lblNetUsedSpeed.Size = new System.Drawing.Size(33, 13);
            this.lblNetUsedSpeed.TabIndex = 6;
            this.lblNetUsedSpeed.Text = "Mbps";
            // 
            // lblNetStatus
            // 
            this.lblNetStatus.AutoSize = true;
            this.lblNetStatus.Location = new System.Drawing.Point(289, 64);
            this.lblNetStatus.Name = "lblNetStatus";
            this.lblNetStatus.Size = new System.Drawing.Size(59, 13);
            this.lblNetStatus.TabIndex = 5;
            this.lblNetStatus.Text = "Connected";
            // 
            // lblNetOrigSpeed
            // 
            this.lblNetOrigSpeed.AutoSize = true;
            this.lblNetOrigSpeed.Location = new System.Drawing.Point(289, 20);
            this.lblNetOrigSpeed.Name = "lblNetOrigSpeed";
            this.lblNetOrigSpeed.Size = new System.Drawing.Size(33, 13);
            this.lblNetOrigSpeed.TabIndex = 3;
            this.lblNetOrigSpeed.Text = "Mbps";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Connected Status :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Used Speed :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Connected Speed :";
            // 
            // cmbNetwork
            // 
            this.cmbNetwork.FormattingEnabled = true;
            this.cmbNetwork.Location = new System.Drawing.Point(16, 236);
            this.cmbNetwork.Name = "cmbNetwork";
            this.cmbNetwork.Size = new System.Drawing.Size(121, 21);
            this.cmbNetwork.TabIndex = 1;
            this.cmbNetwork.SelectedIndexChanged += new System.EventHandler(this.cmbNetwork_SelectedIndexChanged);
            // 
            // pageCameraInfo
            // 
            this.pageCameraInfo.Controls.Add(this.panel4);
            this.pageCameraInfo.Location = new System.Drawing.Point(4, 22);
            this.pageCameraInfo.Name = "pageCameraInfo";
            this.pageCameraInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageCameraInfo.Size = new System.Drawing.Size(552, 361);
            this.pageCameraInfo.TabIndex = 3;
            this.pageCameraInfo.Text = "Camera Information";
            this.pageCameraInfo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.dataGridViewCameraInfoD);
            this.panel4.Controls.Add(this.dataGridViewCameraInfoT);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(540, 349);
            this.panel4.TabIndex = 0;
            // 
            // dataGridViewCameraInfoD
            // 
            this.dataGridViewCameraInfoD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCameraInfoD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewCameraInfoD.Location = new System.Drawing.Point(20, 126);
            this.dataGridViewCameraInfoD.Name = "dataGridViewCameraInfoD";
            this.dataGridViewCameraInfoD.RowHeadersVisible = false;
            this.dataGridViewCameraInfoD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCameraInfoD.Size = new System.Drawing.Size(501, 208);
            this.dataGridViewCameraInfoD.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.FillWeight = 10F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "fps(Live)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.HeaderText = "bit-rate(Live)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.HeaderText = "bit-rate(record)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewCameraInfoT
            // 
            this.dataGridViewCameraInfoT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCameraInfoT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.colName,
            this.colFps,
            this.colBitRate,
            this.colBitRateRec,
            this.colStatus});
            this.dataGridViewCameraInfoT.Location = new System.Drawing.Point(20, 15);
            this.dataGridViewCameraInfoT.Name = "dataGridViewCameraInfoT";
            this.dataGridViewCameraInfoT.RowHeadersVisible = false;
            this.dataGridViewCameraInfoT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCameraInfoT.Size = new System.Drawing.Size(501, 105);
            this.dataGridViewCameraInfoT.TabIndex = 2;
            // 
            // ColID
            // 
            this.ColID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColID.FillWeight = 10F;
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColID.Width = 43;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 60;
            // 
            // colFps
            // 
            this.colFps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colFps.HeaderText = "fps(Live)";
            this.colFps.Name = "colFps";
            this.colFps.Width = 72;
            // 
            // colBitRate
            // 
            this.colBitRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colBitRate.HeaderText = "bit-rate(Live)";
            this.colBitRate.Name = "colBitRate";
            this.colBitRate.Width = 90;
            // 
            // colBitRateRec
            // 
            this.colBitRateRec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colBitRateRec.HeaderText = "bit-rate(record)";
            this.colBitRateRec.Name = "colBitRateRec";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // pageStoragePath
            // 
            this.pageStoragePath.Controls.Add(this.panel5);
            this.pageStoragePath.Location = new System.Drawing.Point(4, 22);
            this.pageStoragePath.Name = "pageStoragePath";
            this.pageStoragePath.Padding = new System.Windows.Forms.Padding(3);
            this.pageStoragePath.Size = new System.Drawing.Size(552, 361);
            this.pageStoragePath.TabIndex = 4;
            this.pageStoragePath.Text = "Storage Path";
            this.pageStoragePath.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.groupBox5);
            this.panel5.Controls.Add(this.groupBox4);
            this.panel5.Location = new System.Drawing.Point(7, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(539, 348);
            this.panel5.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.btnCalculator);
            this.groupBox5.Controls.Add(this.probarHardDiskCal);
            this.groupBox5.Controls.Add(this.txtTotalRecordTime);
            this.groupBox5.Location = new System.Drawing.Point(18, 203);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(503, 127);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hard Disk Calculator";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(240, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(142, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "Total Recording Time (Days)";
            // 
            // btnCalculator
            // 
            this.btnCalculator.Location = new System.Drawing.Point(422, 98);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(75, 23);
            this.btnCalculator.TabIndex = 2;
            this.btnCalculator.Text = "Calculator";
            this.btnCalculator.UseVisualStyleBackColor = true;
            // 
            // probarHardDiskCal
            // 
            this.probarHardDiskCal.Location = new System.Drawing.Point(6, 66);
            this.probarHardDiskCal.Name = "probarHardDiskCal";
            this.probarHardDiskCal.Size = new System.Drawing.Size(491, 23);
            this.probarHardDiskCal.TabIndex = 1;
            // 
            // txtTotalRecordTime
            // 
            this.txtTotalRecordTime.Location = new System.Drawing.Point(397, 28);
            this.txtTotalRecordTime.Name = "txtTotalRecordTime";
            this.txtTotalRecordTime.Size = new System.Drawing.Size(100, 20);
            this.txtTotalRecordTime.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listStoragePath);
            this.groupBox4.Location = new System.Drawing.Point(18, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(503, 176);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Storage Path";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cpuChart
            // 
            this.cpuChart.BackColor = System.Drawing.Color.Silver;
            this.cpuChart.ChartType = iNVMS.CustomControl.ChartType.Stick;
            this.cpuChart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cpuChart.GridPixels = 12;
            this.cpuChart.InitialHeight = 100;
            this.cpuChart.LineColor = System.Drawing.Color.DarkBlue;
            this.cpuChart.Location = new System.Drawing.Point(13, 13);
            this.cpuChart.Name = "cpuChart";
            this.cpuChart.Size = new System.Drawing.Size(512, 252);
            this.cpuChart.TabIndex = 3;
            // 
            // listStoragePath
            // 
            this.listStoragePath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listStoragePath.FullRowSelect = true;
            this.listStoragePath.GridLines = true;
            this.listStoragePath.Location = new System.Drawing.Point(6, 19);
            this.listStoragePath.Name = "listStoragePath";
            this.listStoragePath.Size = new System.Drawing.Size(491, 151);
            this.listStoragePath.TabIndex = 0;
            this.listStoragePath.UseCompatibleStateImageBehavior = false;
            this.listStoragePath.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Free Space";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total";
            this.columnHeader3.Width = 80;
            // 
            // FrmSystemConfigurationUsageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.tabUsageInfo);
            this.MaximizeBox = false;
            this.Name = "FrmSystemConfigurationUsageInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSystemConfigurationUsageInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSystemConfigurationUsageInfo_FormClosing);
            this.Load += new System.EventHandler(this.FrmSystemConfigurationUsageInfo_Load);
            this.tabUsageInfo.ResumeLayout(false);
            this.pageCPU.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageMemory.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageNetwork.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pageCameraInfo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraInfoD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCameraInfoT)).EndInit();
            this.pageStoragePath.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUsageInfo;
        private System.Windows.Forms.TabPage pageCPU;
        private System.Windows.Forms.TabPage pageMemory;
        private System.Windows.Forms.TabPage pageNetwork;
        private System.Windows.Forms.TabPage pageCameraInfo;
        private System.Windows.Forms.TabPage pageStoragePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCpuPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblpPercentM;
        private System.Windows.Forms.Label lblpUsedM;
        private System.Windows.Forms.Label lblpTotalM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblvPercentM;
        private System.Windows.Forms.Label lblvUsedM;
        private System.Windows.Forms.Label lblvTotalM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbNetwork;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblNetUsedSpeed;
        private System.Windows.Forms.Label lblNetStatus;
        private System.Windows.Forms.Label lblNetOrigSpeed;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.ProgressBar probarHardDiskCal;
        private System.Windows.Forms.TextBox txtTotalRecordTime;
        private iNVMS.CustomControl.DataChart vMemChart;
        private iNVMS.CustomControl.DataChart pMemChart;
        private System.Windows.Forms.Timer timer1;
        private iNVMS.CustomControl.DataChart cpuChart;
        private iNVMS.CustomControl.DataChart dataChartCpu;
        private System.Windows.Forms.Timer timer2;
        private iNVMS.CustomControl.DataChart dataChartNet;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblNetPercent;
        private System.Windows.Forms.DataGridView dataGridViewCameraInfoT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBitRateRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridView dataGridViewCameraInfoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ListView listStoragePath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
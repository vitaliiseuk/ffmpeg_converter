namespace iNVMSMain
{
    partial class FrmBackup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtSelectedFiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbCDR = new System.Windows.Forms.RadioButton();
            this.rdbDVDR = new System.Windows.Forms.RadioButton();
            this.chkAutoPartition = new System.Windows.Forms.CheckBox();
            this.chkStartBackup = new System.Windows.Forms.CheckBox();
            this.chkIncludePlayer = new System.Windows.Forms.CheckBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.btnBackupNow = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnQuickBackup = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(27, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 184);
            this.panel1.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(72, 6);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtSelectedFiles);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(409, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "KB";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "0";
            // 
            // txtSelectedFiles
            // 
            this.txtSelectedFiles.Location = new System.Drawing.Point(9, 29);
            this.txtSelectedFiles.Name = "txtSelectedFiles";
            this.txtSelectedFiles.Size = new System.Drawing.Size(100, 20);
            this.txtSelectedFiles.TabIndex = 2;
            this.txtSelectedFiles.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Required Space";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Files";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbCDR);
            this.groupBox2.Controls.Add(this.rdbDVDR);
            this.groupBox2.Controls.Add(this.chkAutoPartition);
            this.groupBox2.Location = new System.Drawing.Point(409, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rdbCDR
            // 
            this.rdbCDR.AutoSize = true;
            this.rdbCDR.Enabled = false;
            this.rdbCDR.Location = new System.Drawing.Point(95, 44);
            this.rdbCDR.Name = "rdbCDR";
            this.rdbCDR.Size = new System.Drawing.Size(51, 17);
            this.rdbCDR.TabIndex = 2;
            this.rdbCDR.TabStop = true;
            this.rdbCDR.Text = "CD-R";
            this.rdbCDR.UseVisualStyleBackColor = true;
            // 
            // rdbDVDR
            // 
            this.rdbDVDR.AutoSize = true;
            this.rdbDVDR.Enabled = false;
            this.rdbDVDR.Location = new System.Drawing.Point(9, 44);
            this.rdbDVDR.Name = "rdbDVDR";
            this.rdbDVDR.Size = new System.Drawing.Size(59, 17);
            this.rdbDVDR.TabIndex = 1;
            this.rdbDVDR.TabStop = true;
            this.rdbDVDR.Text = "DVD-R";
            this.rdbDVDR.UseVisualStyleBackColor = true;
            // 
            // chkAutoPartition
            // 
            this.chkAutoPartition.AutoSize = true;
            this.chkAutoPartition.Location = new System.Drawing.Point(9, 19);
            this.chkAutoPartition.Name = "chkAutoPartition";
            this.chkAutoPartition.Size = new System.Drawing.Size(89, 17);
            this.chkAutoPartition.TabIndex = 0;
            this.chkAutoPartition.Text = "Auto Partition";
            this.chkAutoPartition.UseVisualStyleBackColor = true;
            this.chkAutoPartition.CheckedChanged += new System.EventHandler(this.chkAutoPartition_CheckedChanged);
            // 
            // chkStartBackup
            // 
            this.chkStartBackup.AutoSize = true;
            this.chkStartBackup.Location = new System.Drawing.Point(27, 202);
            this.chkStartBackup.Name = "chkStartBackup";
            this.chkStartBackup.Size = new System.Drawing.Size(327, 17);
            this.chkStartBackup.TabIndex = 3;
            this.chkStartBackup.Text = "Start backup when CD/DVD or USB storage device is detected";
            this.chkStartBackup.UseVisualStyleBackColor = true;
            // 
            // chkIncludePlayer
            // 
            this.chkIncludePlayer.AutoSize = true;
            this.chkIncludePlayer.Location = new System.Drawing.Point(27, 225);
            this.chkIncludePlayer.Name = "chkIncludePlayer";
            this.chkIncludePlayer.Size = new System.Drawing.Size(161, 17);
            this.chkIncludePlayer.TabIndex = 4;
            this.chkIncludePlayer.Text = "Include Player when backup";
            this.chkIncludePlayer.UseVisualStyleBackColor = true;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(27, 260);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(376, 20);
            this.txtBackupPath.TabIndex = 5;
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.Location = new System.Drawing.Point(409, 258);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(31, 23);
            this.btnBackupPath.TabIndex = 6;
            this.btnBackupPath.Text = "...";
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // btnBackupNow
            // 
            this.btnBackupNow.Location = new System.Drawing.Point(446, 257);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(119, 23);
            this.btnBackupNow.TabIndex = 7;
            this.btnBackupNow.Text = "Backup Now";
            this.btnBackupNow.UseVisualStyleBackColor = true;
            this.btnBackupNow.Click += new System.EventHandler(this.btnBackupNow_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(27, 600);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(490, 626);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnQuickBackup
            // 
            this.btnQuickBackup.Location = new System.Drawing.Point(388, 626);
            this.btnQuickBackup.Name = "btnQuickBackup";
            this.btnQuickBackup.Size = new System.Drawing.Size(97, 23);
            this.btnQuickBackup.TabIndex = 11;
            this.btnQuickBackup.Text = "Quick Backup";
            this.btnQuickBackup.UseVisualStyleBackColor = true;
            this.btnQuickBackup.Click += new System.EventHandler(this.btnQuickBackup_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24});
            this.dataGridView1.Location = new System.Drawing.Point(27, 286);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(538, 307);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "00";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "01";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "02";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "03";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "04";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 30;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "05";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "06";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 30;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "07";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "08";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column9.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "09";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column10.Width = 30;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column11.Width = 30;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column12.Width = 30;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column13.Width = 30;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "13";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column14.Width = 30;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "14";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column15.Width = 30;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "15";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column16.Width = 30;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "16";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column17.Width = 30;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "17";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column18.Width = 30;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "18";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column19.Width = 30;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "19";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column20.Width = 30;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "20";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column21.Width = 30;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "21";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column22.Width = 30;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "22";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column23.Width = 30;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "23";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column24.Width = 30;
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQuickBackup);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnBackupNow);
            this.Controls.Add(this.btnBackupPath);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.chkIncludePlayer);
            this.Controls.Add(this.chkStartBackup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup Setting";
            this.Load += new System.EventHandler(this.FrmBackup_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtSelectedFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbCDR;
        private System.Windows.Forms.RadioButton rdbDVDR;
        private System.Windows.Forms.CheckBox chkAutoPartition;
        private System.Windows.Forms.CheckBox chkStartBackup;
        private System.Windows.Forms.CheckBox chkIncludePlayer;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.Button btnBackupNow;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnQuickBackup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
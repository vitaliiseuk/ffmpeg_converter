namespace iNVMSMain
{
    partial class FrmSchedule
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
            this.calendarTo = new System.Windows.Forms.MonthCalendar();
            this.calendarFrom = new System.Windows.Forms.MonthCalendar();
            this.cmbSchedule = new System.Windows.Forms.ComboBox();
            this.pdbWeekly = new System.Windows.Forms.PictureBox();
            this.pdbOneTime = new System.Windows.Forms.PictureBox();
            this.rdbWeekly = new System.Windows.Forms.RadioButton();
            this.rdbOneTime = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.labBackupPath = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.chkDelOver = new System.Windows.Forms.CheckBox();
            this.rdbIncrementalBackup = new System.Windows.Forms.RadioButton();
            this.rdbMirrorBackup = new System.Windows.Forms.RadioButton();
            this.chkUserLogin = new System.Windows.Forms.CheckBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picSchedule = new GridCtrl.Grid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdbWeekly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdbOneTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.calendarTo);
            this.panel1.Controls.Add(this.calendarFrom);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 205);
            this.panel1.TabIndex = 0;
            // 
            // calendarTo
            // 
            this.calendarTo.Location = new System.Drawing.Point(256, 28);
            this.calendarTo.Name = "calendarTo";
            this.calendarTo.TabIndex = 1;
            this.calendarTo.TitleBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.calendarTo.TodayDate = new System.DateTime(2018, 5, 15, 0, 0, 0, 0);
            // 
            // calendarFrom
            // 
            this.calendarFrom.Location = new System.Drawing.Point(11, 28);
            this.calendarFrom.Name = "calendarFrom";
            this.calendarFrom.TabIndex = 0;
            this.calendarFrom.TodayDate = new System.DateTime(2017, 2, 8, 0, 0, 0, 0);
            // 
            // cmbSchedule
            // 
            this.cmbSchedule.FormattingEnabled = true;
            this.cmbSchedule.Items.AddRange(new object[] {
            "Record",
            "Backup",
            "Enable Network",
            "Reboot",
            "Disable Alarm",
            "Turn on Relay1",
            "Turn on Relay2",
            "Turn on Relay3",
            "Turn on Relay4",
            "Turn on Relay5"});
            this.cmbSchedule.Location = new System.Drawing.Point(533, 40);
            this.cmbSchedule.Name = "cmbSchedule";
            this.cmbSchedule.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedule.TabIndex = 1;
            this.cmbSchedule.SelectedIndexChanged += new System.EventHandler(this.cmbSchedule_SelectedIndexChanged);
            // 
            // pdbWeekly
            // 
            this.pdbWeekly.BackColor = System.Drawing.Color.Blue;
            this.pdbWeekly.Location = new System.Drawing.Point(533, 76);
            this.pdbWeekly.Name = "pdbWeekly";
            this.pdbWeekly.Size = new System.Drawing.Size(25, 25);
            this.pdbWeekly.TabIndex = 2;
            this.pdbWeekly.TabStop = false;
            // 
            // pdbOneTime
            // 
            this.pdbOneTime.BackColor = System.Drawing.Color.Red;
            this.pdbOneTime.Location = new System.Drawing.Point(533, 105);
            this.pdbOneTime.Name = "pdbOneTime";
            this.pdbOneTime.Size = new System.Drawing.Size(25, 25);
            this.pdbOneTime.TabIndex = 3;
            this.pdbOneTime.TabStop = false;
            // 
            // rdbWeekly
            // 
            this.rdbWeekly.AutoSize = true;
            this.rdbWeekly.Location = new System.Drawing.Point(569, 80);
            this.rdbWeekly.Name = "rdbWeekly";
            this.rdbWeekly.Size = new System.Drawing.Size(70, 17);
            this.rdbWeekly.TabIndex = 4;
            this.rdbWeekly.Text = "WEEKLY";
            this.rdbWeekly.UseVisualStyleBackColor = true;
            this.rdbWeekly.CheckedChanged += new System.EventHandler(this.rdbWeekly_CheckedChanged);
            // 
            // rdbOneTime
            // 
            this.rdbOneTime.AutoSize = true;
            this.rdbOneTime.Location = new System.Drawing.Point(569, 109);
            this.rdbOneTime.Name = "rdbOneTime";
            this.rdbOneTime.Size = new System.Drawing.Size(77, 17);
            this.rdbOneTime.TabIndex = 5;
            this.rdbOneTime.Text = "ONE TIME";
            this.rdbOneTime.UseVisualStyleBackColor = true;
            this.rdbOneTime.CheckedChanged += new System.EventHandler(this.rdbOneTime_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 612);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 612);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(175, 612);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(579, 612);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(498, 612);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // labBackupPath
            // 
            this.labBackupPath.AutoSize = true;
            this.labBackupPath.Location = new System.Drawing.Point(12, 226);
            this.labBackupPath.Name = "labBackupPath";
            this.labBackupPath.Size = new System.Drawing.Size(62, 13);
            this.labBackupPath.TabIndex = 12;
            this.labBackupPath.Text = "Backup to :";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(77, 223);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(402, 20);
            this.txtBackupPath.TabIndex = 13;
            this.txtBackupPath.WordWrap = false;
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.Location = new System.Drawing.Point(492, 221);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(33, 23);
            this.btnBackupPath.TabIndex = 14;
            this.btnBackupPath.Text = "...";
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // chkDelOver
            // 
            this.chkDelOver.AutoSize = true;
            this.chkDelOver.Location = new System.Drawing.Point(18, 591);
            this.chkDelOver.Name = "chkDelOver";
            this.chkDelOver.Size = new System.Drawing.Size(275, 17);
            this.chkDelOver.TabIndex = 17;
            this.chkDelOver.Text = "Delete or overwrite backup files when the HDD is full";
            this.chkDelOver.UseVisualStyleBackColor = true;
            this.chkDelOver.Visible = false;
            // 
            // rdbIncrementalBackup
            // 
            this.rdbIncrementalBackup.AutoSize = true;
            this.rdbIncrementalBackup.Checked = true;
            this.rdbIncrementalBackup.Location = new System.Drawing.Point(18, 568);
            this.rdbIncrementalBackup.Name = "rdbIncrementalBackup";
            this.rdbIncrementalBackup.Size = new System.Drawing.Size(120, 17);
            this.rdbIncrementalBackup.TabIndex = 18;
            this.rdbIncrementalBackup.TabStop = true;
            this.rdbIncrementalBackup.Text = "Incremental Backup";
            this.rdbIncrementalBackup.UseVisualStyleBackColor = true;
            this.rdbIncrementalBackup.Visible = false;
            // 
            // rdbMirrorBackup
            // 
            this.rdbMirrorBackup.AutoSize = true;
            this.rdbMirrorBackup.Location = new System.Drawing.Point(18, 545);
            this.rdbMirrorBackup.Name = "rdbMirrorBackup";
            this.rdbMirrorBackup.Size = new System.Drawing.Size(91, 17);
            this.rdbMirrorBackup.TabIndex = 18;
            this.rdbMirrorBackup.Text = "Mirror Backup";
            this.rdbMirrorBackup.UseVisualStyleBackColor = true;
            this.rdbMirrorBackup.Visible = false;
            // 
            // chkUserLogin
            // 
            this.chkUserLogin.AutoSize = true;
            this.chkUserLogin.Location = new System.Drawing.Point(197, 549);
            this.chkUserLogin.Name = "chkUserLogin";
            this.chkUserLogin.Size = new System.Drawing.Size(362, 17);
            this.chkUserLogin.TabIndex = 19;
            this.chkUserLogin.Text = "This windows operation ssytem needs user name and password to login";
            this.chkUserLogin.UseVisualStyleBackColor = true;
            this.chkUserLogin.Visible = false;
            this.chkUserLogin.CheckedChanged += new System.EventHandler(this.chkUserLogin_CheckedChanged);
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(9, 554);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(60, 13);
            this.labUserName.TabIndex = 20;
            this.labUserName.Text = "User Name";
            this.labUserName.Visible = false;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(10, 582);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(53, 13);
            this.labPassword.TabIndex = 20;
            this.labPassword.Text = "Password";
            this.labPassword.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(80, 547);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 21;
            this.txtUserName.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 579);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.Visible = false;
            // 
            // picSchedule
            // 
            this.picSchedule.AllowDrop = true;
            this.picSchedule.BackColor = System.Drawing.Color.White;
            this.picSchedule.CellColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red,
        System.Drawing.Color.White};
            this.picSchedule.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.picSchedule.GridOpacity = 100;
            this.picSchedule.Location = new System.Drawing.Point(12, 260);
            this.picSchedule.LockUpdates = false;
            this.picSchedule.Name = "picSchedule";
            this.picSchedule.SelectedValue = 0;
            this.picSchedule.Size = new System.Drawing.Size(659, 279);
            this.picSchedule.TabIndex = 22;
            this.picSchedule.OnCellSelect += new GridCtrl.Grid.CellSelectDelegate(this.picSchedule_OnCellSelect);
            this.picSchedule.Load += new System.EventHandler(this.OnScheduleControl_Load);
            // 
            // FrmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 645);
            this.Controls.Add(this.picSchedule);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labPassword);
            this.Controls.Add(this.labUserName);
            this.Controls.Add(this.chkUserLogin);
            this.Controls.Add(this.rdbMirrorBackup);
            this.Controls.Add(this.rdbIncrementalBackup);
            this.Controls.Add(this.chkDelOver);
            this.Controls.Add(this.btnBackupPath);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.labBackupPath);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rdbOneTime);
            this.Controls.Add(this.rdbWeekly);
            this.Controls.Add(this.pdbOneTime);
            this.Controls.Add(this.pdbWeekly);
            this.Controls.Add(this.cmbSchedule);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSchedule";
            this.Load += new System.EventHandler(this.FrmSchedule_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdbWeekly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdbOneTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar calendarTo;
        private System.Windows.Forms.MonthCalendar calendarFrom;
        private System.Windows.Forms.ComboBox cmbSchedule;
        private System.Windows.Forms.PictureBox pdbWeekly;
        private System.Windows.Forms.PictureBox pdbOneTime;
        private System.Windows.Forms.RadioButton rdbWeekly;
		private System.Windows.Forms.RadioButton rdbOneTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labBackupPath;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.CheckBox chkDelOver;
        private System.Windows.Forms.RadioButton rdbIncrementalBackup;
        private System.Windows.Forms.RadioButton rdbMirrorBackup;
        private System.Windows.Forms.CheckBox chkUserLogin;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
		private GridCtrl.Grid picSchedule;
    }
}
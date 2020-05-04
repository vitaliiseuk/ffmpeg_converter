namespace iNVMSMain
{
    partial class FrmSystemSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeleteEvent = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoveTo = new System.Windows.Forms.Button();
            this.txtMoveTo = new System.Windows.Forms.TextBox();
            this.chkMoveTo = new System.Windows.Forms.CheckBox();
            this.txtDeleteRecord = new System.Windows.Forms.TextBox();
            this.chkDeleteRecord = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listViewStoragePath = new System.Windows.Forms.ListView();
            this.colFolderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cmbDefaultUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkGuestMode = new System.Windows.Forms.CheckBox();
            this.chkSilentLaunch = new System.Windows.Forms.CheckBox();
            this.chkLoginCompact = new System.Windows.Forms.CheckBox();
            this.chkAutoStartNetwork = new System.Windows.Forms.CheckBox();
            this.chkAutoRecord = new System.Windows.Forms.CheckBox();
            this.chkAskPassword = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnConfigExport = new System.Windows.Forms.Button();
            this.btnConfigImport = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnMiscelSetting = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnDualMonSetting = new System.Windows.Forms.Button();
            this.chkEnableDualMonitor = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnUPSSetting = new System.Windows.Forms.Button();
            this.chkUPSEnable = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnSystenConfigSetting = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnSystemControllerSetting = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnPrevStream = new System.Windows.Forms.Button();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnGPUSetting = new System.Windows.Forms.Button();
            this.chkUseGPU = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimesPerDay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.chkAttentionEnable = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDeleteEvent);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnCalc);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMoveTo);
            this.groupBox1.Controls.Add(this.txtMoveTo);
            this.groupBox1.Controls.Add(this.chkMoveTo);
            this.groupBox1.Controls.Add(this.txtDeleteRecord);
            this.groupBox1.Controls.Add(this.chkDeleteRecord);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.listViewStoragePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Storage Path";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Days";
            // 
            // txtDeleteEvent
            // 
            this.txtDeleteEvent.Enabled = false;
            this.txtDeleteEvent.Location = new System.Drawing.Point(209, 178);
            this.txtDeleteEvent.Name = "txtDeleteEvent";
            this.txtDeleteEvent.Size = new System.Drawing.Size(41, 20);
            this.txtDeleteEvent.TabIndex = 15;
            this.txtDeleteEvent.Text = "7";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Delete event and alarm log after:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.BackgroundImage = global::iNVMSMain.Properties.Resources.Calculator_OLD;
            this.btnCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCalc.Location = new System.Drawing.Point(259, 117);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(24, 23);
            this.btnCalc.TabIndex = 13;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Days";
            // 
            // btnMoveTo
            // 
            this.btnMoveTo.Enabled = false;
            this.btnMoveTo.Location = new System.Drawing.Point(343, 211);
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(38, 23);
            this.btnMoveTo.TabIndex = 9;
            this.btnMoveTo.Text = "...";
            this.btnMoveTo.UseVisualStyleBackColor = true;
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_click);
            // 
            // txtMoveTo
            // 
            this.txtMoveTo.Enabled = false;
            this.txtMoveTo.Location = new System.Drawing.Point(112, 213);
            this.txtMoveTo.Name = "txtMoveTo";
            this.txtMoveTo.Size = new System.Drawing.Size(224, 20);
            this.txtMoveTo.TabIndex = 8;
            // 
            // chkMoveTo
            // 
            this.chkMoveTo.AutoSize = true;
            this.chkMoveTo.Location = new System.Drawing.Point(20, 215);
            this.chkMoveTo.Name = "chkMoveTo";
            this.chkMoveTo.Size = new System.Drawing.Size(65, 17);
            this.chkMoveTo.TabIndex = 7;
            this.chkMoveTo.Text = "Move to";
            this.chkMoveTo.UseVisualStyleBackColor = true;
            this.chkMoveTo.CheckedChanged += new System.EventHandler(this.chkMoveTo_CheckedChanged);
            // 
            // txtDeleteRecord
            // 
            this.txtDeleteRecord.Enabled = false;
            this.txtDeleteRecord.Location = new System.Drawing.Point(172, 150);
            this.txtDeleteRecord.Name = "txtDeleteRecord";
            this.txtDeleteRecord.Size = new System.Drawing.Size(41, 20);
            this.txtDeleteRecord.TabIndex = 5;
            this.txtDeleteRecord.Text = "7";
            // 
            // chkDeleteRecord
            // 
            this.chkDeleteRecord.AutoSize = true;
            this.chkDeleteRecord.Location = new System.Drawing.Point(20, 153);
            this.chkDeleteRecord.Name = "chkDeleteRecord";
            this.chkDeleteRecord.Size = new System.Drawing.Size(149, 17);
            this.chkDeleteRecord.TabIndex = 3;
            this.chkDeleteRecord.Text = "Delete Record Data After:";
            this.chkDeleteRecord.UseVisualStyleBackColor = true;
            this.chkDeleteRecord.CheckedChanged += new System.EventHandler(this.chkDeleteRecord_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(389, 117);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listViewStoragePath
            // 
            this.listViewStoragePath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFolderPath,
            this.colFreeSpace,
            this.colTotalSpace});
            this.listViewStoragePath.FullRowSelect = true;
            this.listViewStoragePath.GridLines = true;
            this.listViewStoragePath.Location = new System.Drawing.Point(6, 19);
            this.listViewStoragePath.Name = "listViewStoragePath";
            this.listViewStoragePath.Size = new System.Drawing.Size(458, 84);
            this.listViewStoragePath.TabIndex = 0;
            this.listViewStoragePath.UseCompatibleStateImageBehavior = false;
            this.listViewStoragePath.View = System.Windows.Forms.View.Details;
            // 
            // colFolderPath
            // 
            this.colFolderPath.Text = "Path";
            this.colFolderPath.Width = 150;
            // 
            // colFreeSpace
            // 
            this.colFreeSpace.Text = "Free Space";
            this.colFreeSpace.Width = 72;
            // 
            // colTotalSpace
            // 
            this.colTotalSpace.Text = "Total";
            this.colTotalSpace.Width = 80;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmbDefaultUser);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.chkGuestMode);
            this.groupBox7.Controls.Add(this.chkSilentLaunch);
            this.groupBox7.Controls.Add(this.chkLoginCompact);
            this.groupBox7.Controls.Add(this.chkAutoStartNetwork);
            this.groupBox7.Controls.Add(this.chkAutoRecord);
            this.groupBox7.Controls.Add(this.chkAskPassword);
            this.groupBox7.Controls.Add(this.chkAutoLogin);
            this.groupBox7.Location = new System.Drawing.Point(492, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(380, 197);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Login";
            // 
            // cmbDefaultUser
            // 
            this.cmbDefaultUser.FormattingEnabled = true;
            this.cmbDefaultUser.Location = new System.Drawing.Point(244, 166);
            this.cmbDefaultUser.Name = "cmbDefaultUser";
            this.cmbDefaultUser.Size = new System.Drawing.Size(121, 21);
            this.cmbDefaultUser.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Default User";
            // 
            // chkGuestMode
            // 
            this.chkGuestMode.AutoSize = true;
            this.chkGuestMode.Location = new System.Drawing.Point(19, 159);
            this.chkGuestMode.Name = "chkGuestMode";
            this.chkGuestMode.Size = new System.Drawing.Size(83, 17);
            this.chkGuestMode.TabIndex = 6;
            this.chkGuestMode.Text = "Guest mode";
            this.chkGuestMode.UseVisualStyleBackColor = true;
            // 
            // chkSilentLaunch
            // 
            this.chkSilentLaunch.AutoSize = true;
            this.chkSilentLaunch.Location = new System.Drawing.Point(19, 136);
            this.chkSilentLaunch.Name = "chkSilentLaunch";
            this.chkSilentLaunch.Size = new System.Drawing.Size(87, 17);
            this.chkSilentLaunch.TabIndex = 5;
            this.chkSilentLaunch.Text = "Silent launch";
            this.chkSilentLaunch.UseVisualStyleBackColor = true;
            // 
            // chkLoginCompact
            // 
            this.chkLoginCompact.AutoSize = true;
            this.chkLoginCompact.Location = new System.Drawing.Point(19, 112);
            this.chkLoginCompact.Name = "chkLoginCompact";
            this.chkLoginCompact.Size = new System.Drawing.Size(128, 17);
            this.chkLoginCompact.TabIndex = 4;
            this.chkLoginCompact.Text = "Log in compact mode";
            this.chkLoginCompact.UseVisualStyleBackColor = true;
            // 
            // chkAutoStartNetwork
            // 
            this.chkAutoStartNetwork.AutoSize = true;
            this.chkAutoStartNetwork.Location = new System.Drawing.Point(19, 88);
            this.chkAutoStartNetwork.Name = "chkAutoStartNetwork";
            this.chkAutoStartNetwork.Size = new System.Drawing.Size(166, 17);
            this.chkAutoStartNetwork.TabIndex = 3;
            this.chkAutoStartNetwork.Text = "Auto start network when login";
            this.chkAutoStartNetwork.UseVisualStyleBackColor = true;
            // 
            // chkAutoRecord
            // 
            this.chkAutoRecord.AutoSize = true;
            this.chkAutoRecord.Location = new System.Drawing.Point(19, 65);
            this.chkAutoRecord.Name = "chkAutoRecord";
            this.chkAutoRecord.Size = new System.Drawing.Size(135, 17);
            this.chkAutoRecord.TabIndex = 2;
            this.chkAutoRecord.Text = "Auto record when login";
            this.chkAutoRecord.UseVisualStyleBackColor = true;
            // 
            // chkAskPassword
            // 
            this.chkAskPassword.AutoSize = true;
            this.chkAskPassword.Location = new System.Drawing.Point(19, 42);
            this.chkAskPassword.Name = "chkAskPassword";
            this.chkAskPassword.Size = new System.Drawing.Size(161, 17);
            this.chkAskPassword.TabIndex = 1;
            this.chkAskPassword.Text = "Ask for password when login";
            this.chkAskPassword.UseVisualStyleBackColor = true;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Location = new System.Drawing.Point(19, 19);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(143, 17);
            this.chkAutoLogin.TabIndex = 0;
            this.chkAutoLogin.Text = "Auto login when OS start";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            this.chkAutoLogin.CheckedChanged += new System.EventHandler(this.chkAutoLogin_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(319, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(146, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "UI Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "System Language";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnConfigExport);
            this.groupBox6.Controls.Add(this.btnConfigImport);
            this.groupBox6.Location = new System.Drawing.Point(13, 497);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(470, 49);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configuration";
            // 
            // btnConfigExport
            // 
            this.btnConfigExport.Location = new System.Drawing.Point(252, 17);
            this.btnConfigExport.Name = "btnConfigExport";
            this.btnConfigExport.Size = new System.Drawing.Size(98, 23);
            this.btnConfigExport.TabIndex = 1;
            this.btnConfigExport.Text = "Export";
            this.btnConfigExport.UseVisualStyleBackColor = true;
            this.btnConfigExport.Click += new System.EventHandler(this.btnConfigExport_Click);
            // 
            // btnConfigImport
            // 
            this.btnConfigImport.Location = new System.Drawing.Point(88, 17);
            this.btnConfigImport.Name = "btnConfigImport";
            this.btnConfigImport.Size = new System.Drawing.Size(99, 23);
            this.btnConfigImport.TabIndex = 0;
            this.btnConfigImport.Text = "Import";
            this.btnConfigImport.UseVisualStyleBackColor = true;
            this.btnConfigImport.Click += new System.EventHandler(this.btnConfigImport_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnMiscelSetting);
            this.groupBox8.Location = new System.Drawing.Point(492, 224);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(380, 48);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Miscellaneous";
            // 
            // btnMiscelSetting
            // 
            this.btnMiscelSetting.Location = new System.Drawing.Point(202, 15);
            this.btnMiscelSetting.Name = "btnMiscelSetting";
            this.btnMiscelSetting.Size = new System.Drawing.Size(75, 23);
            this.btnMiscelSetting.TabIndex = 0;
            this.btnMiscelSetting.Text = "Setting";
            this.btnMiscelSetting.UseVisualStyleBackColor = true;
            this.btnMiscelSetting.Click += new System.EventHandler(this.btnMiscelSetting_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnDualMonSetting);
            this.groupBox9.Controls.Add(this.chkEnableDualMonitor);
            this.groupBox9.Location = new System.Drawing.Point(12, 564);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(470, 50);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Monitors";
            // 
            // btnDualMonSetting
            // 
            this.btnDualMonSetting.Enabled = false;
            this.btnDualMonSetting.Location = new System.Drawing.Point(202, 17);
            this.btnDualMonSetting.Name = "btnDualMonSetting";
            this.btnDualMonSetting.Size = new System.Drawing.Size(75, 23);
            this.btnDualMonSetting.TabIndex = 1;
            this.btnDualMonSetting.Text = "Setting";
            this.btnDualMonSetting.UseVisualStyleBackColor = true;
            this.btnDualMonSetting.Click += new System.EventHandler(this.btnDualMonSetting_Click);
            // 
            // chkEnableDualMonitor
            // 
            this.chkEnableDualMonitor.AutoSize = true;
            this.chkEnableDualMonitor.Location = new System.Drawing.Point(21, 22);
            this.chkEnableDualMonitor.Name = "chkEnableDualMonitor";
            this.chkEnableDualMonitor.Size = new System.Drawing.Size(139, 17);
            this.chkEnableDualMonitor.TabIndex = 0;
            this.chkEnableDualMonitor.Text = "Enable multiple monitors";
            this.chkEnableDualMonitor.UseVisualStyleBackColor = true;
            this.chkEnableDualMonitor.CheckedChanged += new System.EventHandler(this.chkEnableDualMonitor_CheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnUPSSetting);
            this.groupBox11.Controls.Add(this.chkUPSEnable);
            this.groupBox11.Location = new System.Drawing.Point(492, 354);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(380, 48);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "UPS";
            // 
            // btnUPSSetting
            // 
            this.btnUPSSetting.Enabled = false;
            this.btnUPSSetting.Location = new System.Drawing.Point(202, 17);
            this.btnUPSSetting.Name = "btnUPSSetting";
            this.btnUPSSetting.Size = new System.Drawing.Size(75, 23);
            this.btnUPSSetting.TabIndex = 1;
            this.btnUPSSetting.Text = "Setting";
            this.btnUPSSetting.UseVisualStyleBackColor = true;
            this.btnUPSSetting.Click += new System.EventHandler(this.btnUPSSetting_Click);
            // 
            // chkUPSEnable
            // 
            this.chkUPSEnable.AutoSize = true;
            this.chkUPSEnable.Location = new System.Drawing.Point(22, 21);
            this.chkUPSEnable.Name = "chkUPSEnable";
            this.chkUPSEnable.Size = new System.Drawing.Size(59, 17);
            this.chkUPSEnable.TabIndex = 0;
            this.chkUPSEnable.Text = "Enable";
            this.chkUPSEnable.UseVisualStyleBackColor = true;
            this.chkUPSEnable.CheckedChanged += new System.EventHandler(this.chkUPSEnable_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnSystenConfigSetting);
            this.groupBox12.Location = new System.Drawing.Point(492, 417);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(380, 50);
            this.groupBox12.TabIndex = 14;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "System Configuration";
            // 
            // btnSystenConfigSetting
            // 
            this.btnSystenConfigSetting.Location = new System.Drawing.Point(202, 17);
            this.btnSystenConfigSetting.Name = "btnSystenConfigSetting";
            this.btnSystenConfigSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSystenConfigSetting.TabIndex = 0;
            this.btnSystenConfigSetting.Text = "Setting";
            this.btnSystenConfigSetting.UseVisualStyleBackColor = true;
            this.btnSystenConfigSetting.Click += new System.EventHandler(this.btnSystenConfigSetting_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnSystemControllerSetting);
            this.groupBox13.Location = new System.Drawing.Point(492, 489);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(380, 50);
            this.groupBox13.TabIndex = 15;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "System Controller";
            // 
            // btnSystemControllerSetting
            // 
            this.btnSystemControllerSetting.Location = new System.Drawing.Point(202, 17);
            this.btnSystemControllerSetting.Name = "btnSystemControllerSetting";
            this.btnSystemControllerSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSystemControllerSetting.TabIndex = 0;
            this.btnSystemControllerSetting.Text = "Setting";
            this.btnSystemControllerSetting.UseVisualStyleBackColor = true;
            this.btnSystemControllerSetting.Click += new System.EventHandler(this.btnSystemControllerSetting_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(793, 588);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 16;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(712, 588);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(631, 588);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnPrevStream);
            this.groupBox14.Location = new System.Drawing.Point(492, 287);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(380, 51);
            this.groupBox14.TabIndex = 11;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Preview Stream Setting";
            // 
            // btnPrevStream
            // 
            this.btnPrevStream.Location = new System.Drawing.Point(202, 17);
            this.btnPrevStream.Name = "btnPrevStream";
            this.btnPrevStream.Size = new System.Drawing.Size(75, 23);
            this.btnPrevStream.TabIndex = 0;
            this.btnPrevStream.Text = "Setting";
            this.btnPrevStream.UseVisualStyleBackColor = true;
            this.btnPrevStream.Click += new System.EventHandler(this.btnPrevStream_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeyboard.Location = new System.Drawing.Point(594, 586);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(31, 26);
            this.btnKeyboard.TabIndex = 73;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnGPUSetting);
            this.groupBox10.Controls.Add(this.chkUseGPU);
            this.groupBox10.Location = new System.Drawing.Point(12, 435);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(469, 47);
            this.groupBox10.TabIndex = 74;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "GPU";
            // 
            // btnGPUSetting
            // 
            this.btnGPUSetting.Enabled = false;
            this.btnGPUSetting.Location = new System.Drawing.Point(202, 17);
            this.btnGPUSetting.Name = "btnGPUSetting";
            this.btnGPUSetting.Size = new System.Drawing.Size(75, 23);
            this.btnGPUSetting.TabIndex = 1;
            this.btnGPUSetting.Text = "Setting";
            this.btnGPUSetting.UseVisualStyleBackColor = true;
            this.btnGPUSetting.Click += new System.EventHandler(this.btnGPUSetting_Click);
            // 
            // chkUseGPU
            // 
            this.chkUseGPU.AutoSize = true;
            this.chkUseGPU.Location = new System.Drawing.Point(23, 21);
            this.chkUseGPU.Name = "chkUseGPU";
            this.chkUseGPU.Size = new System.Drawing.Size(59, 17);
            this.chkUseGPU.TabIndex = 0;
            this.chkUseGPU.Text = "Enable";
            this.chkUseGPU.UseVisualStyleBackColor = true;
            this.chkUseGPU.CheckedChanged += new System.EventHandler(this.chkUseGPU_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTimesPerDay);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnAnalysis);
            this.groupBox3.Controls.Add(this.chkAttentionEnable);
            this.groupBox3.Location = new System.Drawing.Point(12, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 78);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attention Please";
            // 
            // txtTimesPerDay
            // 
            this.txtTimesPerDay.Location = new System.Drawing.Point(128, 49);
            this.txtTimesPerDay.Name = "txtTimesPerDay";
            this.txtTimesPerDay.Size = new System.Drawing.Size(106, 20);
            this.txtTimesPerDay.TabIndex = 3;
            this.txtTimesPerDay.Leave += new System.EventHandler(this.txtTimesPerDay_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Times per day";
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(350, 46);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(106, 23);
            this.btnAnalysis.TabIndex = 1;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // chkAttentionEnable
            // 
            this.chkAttentionEnable.AutoSize = true;
            this.chkAttentionEnable.Location = new System.Drawing.Point(22, 24);
            this.chkAttentionEnable.Name = "chkAttentionEnable";
            this.chkAttentionEnable.Size = new System.Drawing.Size(104, 17);
            this.chkAttentionEnable.TabIndex = 0;
            this.chkAttentionEnable.Text = "Attention Enable";
            this.chkAttentionEnable.UseVisualStyleBackColor = true;
            this.chkAttentionEnable.Click += new System.EventHandler(this.chkAttentionEnable_Click);
            // 
            // FrmSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 624);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmSystemSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Settings";
            this.Load += new System.EventHandler(this.FrmSystemSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewStoragePath;
        private System.Windows.Forms.ColumnHeader colFolderPath;
        private System.Windows.Forms.ColumnHeader colFreeSpace;
		private System.Windows.Forms.ColumnHeader colTotalSpace;
        private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnMoveTo;
        private System.Windows.Forms.TextBox txtMoveTo;
		private System.Windows.Forms.CheckBox chkMoveTo;
		private System.Windows.Forms.TextBox txtDeleteRecord;
        private System.Windows.Forms.CheckBox chkDeleteRecord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfigExport;
        private System.Windows.Forms.Button btnConfigImport;
        private System.Windows.Forms.ComboBox cmbDefaultUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkGuestMode;
        private System.Windows.Forms.CheckBox chkSilentLaunch;
        private System.Windows.Forms.CheckBox chkLoginCompact;
        private System.Windows.Forms.CheckBox chkAutoStartNetwork;
        private System.Windows.Forms.CheckBox chkAutoRecord;
        private System.Windows.Forms.CheckBox chkAskPassword;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Button btnMiscelSetting;
        private System.Windows.Forms.Button btnDualMonSetting;
		private System.Windows.Forms.CheckBox chkEnableDualMonitor;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnUPSSetting;
        private System.Windows.Forms.CheckBox chkUPSEnable;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnSystenConfigSetting;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnSystemControllerSetting;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnPrevStream;
        private System.Windows.Forms.Button btnKeyboard;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Button btnGPUSetting;
		private System.Windows.Forms.CheckBox chkUseGPU;
        private System.Windows.Forms.FolderBrowserDialog openFileDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAttentionEnable;
        private System.Windows.Forms.TextBox txtTimesPerDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeleteEvent;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
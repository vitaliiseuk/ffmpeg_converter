namespace iNVMSMain
{
    partial class FrmUserSettingAdd
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
            this.rdbAdmin = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.grbControlRight = new System.Windows.Forms.GroupBox();
            this.chkPTZSetup = new System.Windows.Forms.CheckBox();
            this.chkGroupTreeMenu = new System.Windows.Forms.CheckBox();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.chkReboot = new System.Windows.Forms.CheckBox();
            this.chkMinimize = new System.Windows.Forms.CheckBox();
            this.chkPOS = new System.Windows.Forms.CheckBox();
            this.chkScheduler = new System.Windows.Forms.CheckBox();
            this.chkBackUp = new System.Windows.Forms.CheckBox();
            this.chkEMap = new System.Windows.Forms.CheckBox();
            this.chkPTZControl = new System.Windows.Forms.CheckBox();
            this.chkAdvancedMode = new System.Windows.Forms.CheckBox();
            this.chkPowerOff = new System.Windows.Forms.CheckBox();
            this.chkPlayback = new System.Windows.Forms.CheckBox();
            this.chkNetControl = new System.Windows.Forms.CheckBox();
            this.chkRecord = new System.Windows.Forms.CheckBox();
            this.chkSystemSetting = new System.Windows.Forms.CheckBox();
            this.grbVisibleCam = new System.Windows.Forms.GroupBox();
            this.btnVisiCamPrev = new System.Windows.Forms.Button();
            this.btnVisiCamNext = new System.Windows.Forms.Button();
            this.chkCam16 = new System.Windows.Forms.CheckBox();
            this.chkCam15 = new System.Windows.Forms.CheckBox();
            this.chkCam14 = new System.Windows.Forms.CheckBox();
            this.chkCam13 = new System.Windows.Forms.CheckBox();
            this.chkCam12 = new System.Windows.Forms.CheckBox();
            this.chkCam11 = new System.Windows.Forms.CheckBox();
            this.chkCam10 = new System.Windows.Forms.CheckBox();
            this.chkCam9 = new System.Windows.Forms.CheckBox();
            this.chkCam8 = new System.Windows.Forms.CheckBox();
            this.chkCam7 = new System.Windows.Forms.CheckBox();
            this.chkCam6 = new System.Windows.Forms.CheckBox();
            this.chkCam5 = new System.Windows.Forms.CheckBox();
            this.chkCam4 = new System.Windows.Forms.CheckBox();
            this.chkCam3 = new System.Windows.Forms.CheckBox();
            this.chkCam2 = new System.Windows.Forms.CheckBox();
            this.chkCam1 = new System.Windows.Forms.CheckBox();
            this.chkVisiCamAll = new System.Windows.Forms.CheckBox();
            this.grbTimeSpan = new System.Windows.Forms.GroupBox();
            this.timePickerExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.timePickerActiveDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTimeSpanEnable = new System.Windows.Forms.CheckBox();
            this.chkSkipPassword = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPWConfirm = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.chkPCViewNet = new System.Windows.Forms.CheckBox();
            this.chkPCRemoteConsole = new System.Windows.Forms.CheckBox();
            this.chkPCRemoteEmap = new System.Windows.Forms.CheckBox();
            this.chkPCRemoteRecord = new System.Windows.Forms.CheckBox();
            this.chkRemoteLogView = new System.Windows.Forms.CheckBox();
            this.chkIPCam = new System.Windows.Forms.CheckBox();
            this.chkRemoteSetup = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRATInfinite = new System.Windows.Forms.CheckBox();
            this.txtRATime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbPCViewer = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grbControlRight.SuspendLayout();
            this.grbVisibleCam.SuspendLayout();
            this.grbTimeSpan.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grbPCViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAdmin);
            this.groupBox1.Controls.Add(this.rdbUser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authorization Level";
            // 
            // rdbAdmin
            // 
            this.rdbAdmin.AutoSize = true;
            this.rdbAdmin.Location = new System.Drawing.Point(190, 20);
            this.rdbAdmin.Name = "rdbAdmin";
            this.rdbAdmin.Size = new System.Drawing.Size(85, 17);
            this.rdbAdmin.TabIndex = 1;
            this.rdbAdmin.TabStop = true;
            this.rdbAdmin.Text = "Administrator";
            this.rdbAdmin.UseVisualStyleBackColor = true;
            this.rdbAdmin.CheckedChanged += new System.EventHandler(this.rdbAdmin_CheckedChanged);
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Location = new System.Drawing.Point(30, 20);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(47, 17);
            this.rdbUser.TabIndex = 0;
            this.rdbUser.TabStop = true;
            this.rdbUser.Text = "User";
            this.rdbUser.UseVisualStyleBackColor = true;
            // 
            // grbControlRight
            // 
            this.grbControlRight.Controls.Add(this.chkPTZSetup);
            this.grbControlRight.Controls.Add(this.chkGroupTreeMenu);
            this.grbControlRight.Controls.Add(this.chkExport);
            this.grbControlRight.Controls.Add(this.chkReboot);
            this.grbControlRight.Controls.Add(this.chkMinimize);
            this.grbControlRight.Controls.Add(this.chkPOS);
            this.grbControlRight.Controls.Add(this.chkScheduler);
            this.grbControlRight.Controls.Add(this.chkBackUp);
            this.grbControlRight.Controls.Add(this.chkEMap);
            this.grbControlRight.Controls.Add(this.chkPTZControl);
            this.grbControlRight.Controls.Add(this.chkAdvancedMode);
            this.grbControlRight.Controls.Add(this.chkPowerOff);
            this.grbControlRight.Controls.Add(this.chkPlayback);
            this.grbControlRight.Controls.Add(this.chkNetControl);
            this.grbControlRight.Controls.Add(this.chkRecord);
            this.grbControlRight.Controls.Add(this.chkSystemSetting);
            this.grbControlRight.Location = new System.Drawing.Point(12, 67);
            this.grbControlRight.Name = "grbControlRight";
            this.grbControlRight.Size = new System.Drawing.Size(380, 162);
            this.grbControlRight.TabIndex = 1;
            this.grbControlRight.TabStop = false;
            this.grbControlRight.Text = "Control Right";
            // 
            // chkPTZSetup
            // 
            this.chkPTZSetup.AutoSize = true;
            this.chkPTZSetup.Location = new System.Drawing.Point(255, 88);
            this.chkPTZSetup.Name = "chkPTZSetup";
            this.chkPTZSetup.Size = new System.Drawing.Size(78, 17);
            this.chkPTZSetup.TabIndex = 15;
            this.chkPTZSetup.Text = "PTZ Setup";
            this.chkPTZSetup.UseVisualStyleBackColor = true;
            // 
            // chkGroupTreeMenu
            // 
            this.chkGroupTreeMenu.AutoSize = true;
            this.chkGroupTreeMenu.Location = new System.Drawing.Point(255, 65);
            this.chkGroupTreeMenu.Name = "chkGroupTreeMenu";
            this.chkGroupTreeMenu.Size = new System.Drawing.Size(110, 17);
            this.chkGroupTreeMenu.TabIndex = 14;
            this.chkGroupTreeMenu.Text = "Group Tree Menu";
            this.chkGroupTreeMenu.UseVisualStyleBackColor = true;
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Location = new System.Drawing.Point(255, 42);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(56, 17);
            this.chkExport.TabIndex = 13;
            this.chkExport.Text = "Export";
            this.chkExport.UseVisualStyleBackColor = true;
            // 
            // chkReboot
            // 
            this.chkReboot.AutoSize = true;
            this.chkReboot.Location = new System.Drawing.Point(255, 19);
            this.chkReboot.Name = "chkReboot";
            this.chkReboot.Size = new System.Drawing.Size(61, 17);
            this.chkReboot.TabIndex = 12;
            this.chkReboot.Text = "Reboot";
            this.chkReboot.UseVisualStyleBackColor = true;
            // 
            // chkMinimize
            // 
            this.chkMinimize.AutoSize = true;
            this.chkMinimize.Location = new System.Drawing.Point(142, 134);
            this.chkMinimize.Name = "chkMinimize";
            this.chkMinimize.Size = new System.Drawing.Size(66, 17);
            this.chkMinimize.TabIndex = 11;
            this.chkMinimize.Text = "Minimize";
            this.chkMinimize.UseVisualStyleBackColor = true;
            // 
            // chkPOS
            // 
            this.chkPOS.AutoSize = true;
            this.chkPOS.Location = new System.Drawing.Point(142, 111);
            this.chkPOS.Name = "chkPOS";
            this.chkPOS.Size = new System.Drawing.Size(48, 17);
            this.chkPOS.TabIndex = 10;
            this.chkPOS.Text = "POS";
            this.chkPOS.UseVisualStyleBackColor = true;
            // 
            // chkScheduler
            // 
            this.chkScheduler.AutoSize = true;
            this.chkScheduler.Location = new System.Drawing.Point(142, 88);
            this.chkScheduler.Name = "chkScheduler";
            this.chkScheduler.Size = new System.Drawing.Size(74, 17);
            this.chkScheduler.TabIndex = 9;
            this.chkScheduler.Text = "Scheduler";
            this.chkScheduler.UseVisualStyleBackColor = true;
            // 
            // chkBackUp
            // 
            this.chkBackUp.AutoSize = true;
            this.chkBackUp.Location = new System.Drawing.Point(142, 65);
            this.chkBackUp.Name = "chkBackUp";
            this.chkBackUp.Size = new System.Drawing.Size(63, 17);
            this.chkBackUp.TabIndex = 8;
            this.chkBackUp.Text = "Backup";
            this.chkBackUp.UseVisualStyleBackColor = true;
            // 
            // chkEMap
            // 
            this.chkEMap.AutoSize = true;
            this.chkEMap.Location = new System.Drawing.Point(142, 42);
            this.chkEMap.Name = "chkEMap";
            this.chkEMap.Size = new System.Drawing.Size(57, 17);
            this.chkEMap.TabIndex = 7;
            this.chkEMap.Text = "E-Map";
            this.chkEMap.UseVisualStyleBackColor = true;
            // 
            // chkPTZControl
            // 
            this.chkPTZControl.AutoSize = true;
            this.chkPTZControl.Location = new System.Drawing.Point(142, 19);
            this.chkPTZControl.Name = "chkPTZControl";
            this.chkPTZControl.Size = new System.Drawing.Size(83, 17);
            this.chkPTZControl.TabIndex = 6;
            this.chkPTZControl.Text = "PTZ Control";
            this.chkPTZControl.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedMode
            // 
            this.chkAdvancedMode.AutoSize = true;
            this.chkAdvancedMode.Location = new System.Drawing.Point(30, 134);
            this.chkAdvancedMode.Name = "chkAdvancedMode";
            this.chkAdvancedMode.Size = new System.Drawing.Size(105, 17);
            this.chkAdvancedMode.TabIndex = 5;
            this.chkAdvancedMode.Text = "Advanced Mode";
            this.chkAdvancedMode.UseVisualStyleBackColor = true;
            // 
            // chkPowerOff
            // 
            this.chkPowerOff.AutoSize = true;
            this.chkPowerOff.Location = new System.Drawing.Point(30, 111);
            this.chkPowerOff.Name = "chkPowerOff";
            this.chkPowerOff.Size = new System.Drawing.Size(73, 17);
            this.chkPowerOff.TabIndex = 4;
            this.chkPowerOff.Text = "Power Off";
            this.chkPowerOff.UseVisualStyleBackColor = true;
            // 
            // chkPlayback
            // 
            this.chkPlayback.AutoSize = true;
            this.chkPlayback.Location = new System.Drawing.Point(30, 88);
            this.chkPlayback.Name = "chkPlayback";
            this.chkPlayback.Size = new System.Drawing.Size(70, 17);
            this.chkPlayback.TabIndex = 3;
            this.chkPlayback.Text = "Playback";
            this.chkPlayback.UseVisualStyleBackColor = true;
            // 
            // chkNetControl
            // 
            this.chkNetControl.AutoSize = true;
            this.chkNetControl.Location = new System.Drawing.Point(30, 65);
            this.chkNetControl.Name = "chkNetControl";
            this.chkNetControl.Size = new System.Drawing.Size(102, 17);
            this.chkNetControl.TabIndex = 2;
            this.chkNetControl.Text = "Network Control";
            this.chkNetControl.UseVisualStyleBackColor = true;
            // 
            // chkRecord
            // 
            this.chkRecord.AutoSize = true;
            this.chkRecord.Location = new System.Drawing.Point(30, 42);
            this.chkRecord.Name = "chkRecord";
            this.chkRecord.Size = new System.Drawing.Size(61, 17);
            this.chkRecord.TabIndex = 1;
            this.chkRecord.Text = "Record";
            this.chkRecord.UseVisualStyleBackColor = true;
            // 
            // chkSystemSetting
            // 
            this.chkSystemSetting.AutoSize = true;
            this.chkSystemSetting.Location = new System.Drawing.Point(30, 19);
            this.chkSystemSetting.Name = "chkSystemSetting";
            this.chkSystemSetting.Size = new System.Drawing.Size(96, 17);
            this.chkSystemSetting.TabIndex = 0;
            this.chkSystemSetting.Text = "System Setting";
            this.chkSystemSetting.UseVisualStyleBackColor = true;
            // 
            // grbVisibleCam
            // 
            this.grbVisibleCam.Controls.Add(this.btnVisiCamPrev);
            this.grbVisibleCam.Controls.Add(this.btnVisiCamNext);
            this.grbVisibleCam.Controls.Add(this.chkCam16);
            this.grbVisibleCam.Controls.Add(this.chkCam15);
            this.grbVisibleCam.Controls.Add(this.chkCam14);
            this.grbVisibleCam.Controls.Add(this.chkCam13);
            this.grbVisibleCam.Controls.Add(this.chkCam12);
            this.grbVisibleCam.Controls.Add(this.chkCam11);
            this.grbVisibleCam.Controls.Add(this.chkCam10);
            this.grbVisibleCam.Controls.Add(this.chkCam9);
            this.grbVisibleCam.Controls.Add(this.chkCam8);
            this.grbVisibleCam.Controls.Add(this.chkCam7);
            this.grbVisibleCam.Controls.Add(this.chkCam6);
            this.grbVisibleCam.Controls.Add(this.chkCam5);
            this.grbVisibleCam.Controls.Add(this.chkCam4);
            this.grbVisibleCam.Controls.Add(this.chkCam3);
            this.grbVisibleCam.Controls.Add(this.chkCam2);
            this.grbVisibleCam.Controls.Add(this.chkCam1);
            this.grbVisibleCam.Controls.Add(this.chkVisiCamAll);
            this.grbVisibleCam.Location = new System.Drawing.Point(398, 12);
            this.grbVisibleCam.Name = "grbVisibleCam";
            this.grbVisibleCam.Size = new System.Drawing.Size(380, 99);
            this.grbVisibleCam.TabIndex = 3;
            this.grbVisibleCam.TabStop = false;
            this.grbVisibleCam.Text = "Visible Camera";
            // 
            // btnVisiCamPrev
            // 
            this.btnVisiCamPrev.Location = new System.Drawing.Point(326, 17);
            this.btnVisiCamPrev.Name = "btnVisiCamPrev";
            this.btnVisiCamPrev.Size = new System.Drawing.Size(22, 23);
            this.btnVisiCamPrev.TabIndex = 18;
            this.btnVisiCamPrev.Text = "<";
            this.btnVisiCamPrev.UseVisualStyleBackColor = true;
            this.btnVisiCamPrev.Click += new System.EventHandler(this.btnVisiCamPrev_Click);
            // 
            // btnVisiCamNext
            // 
            this.btnVisiCamNext.Location = new System.Drawing.Point(347, 17);
            this.btnVisiCamNext.Name = "btnVisiCamNext";
            this.btnVisiCamNext.Size = new System.Drawing.Size(22, 23);
            this.btnVisiCamNext.TabIndex = 17;
            this.btnVisiCamNext.Text = ">";
            this.btnVisiCamNext.UseVisualStyleBackColor = true;
            this.btnVisiCamNext.Click += new System.EventHandler(this.btnVisiCamNext_Click);
            // 
            // chkCam16
            // 
            this.chkCam16.AutoSize = true;
            this.chkCam16.Location = new System.Drawing.Point(337, 67);
            this.chkCam16.Name = "chkCam16";
            this.chkCam16.Size = new System.Drawing.Size(38, 17);
            this.chkCam16.TabIndex = 16;
            this.chkCam16.Text = "16";
            this.chkCam16.UseVisualStyleBackColor = true;
            // 
            // chkCam15
            // 
            this.chkCam15.AutoSize = true;
            this.chkCam15.Location = new System.Drawing.Point(298, 67);
            this.chkCam15.Name = "chkCam15";
            this.chkCam15.Size = new System.Drawing.Size(38, 17);
            this.chkCam15.TabIndex = 15;
            this.chkCam15.Text = "15";
            this.chkCam15.UseVisualStyleBackColor = true;
            // 
            // chkCam14
            // 
            this.chkCam14.AutoSize = true;
            this.chkCam14.Location = new System.Drawing.Point(255, 67);
            this.chkCam14.Name = "chkCam14";
            this.chkCam14.Size = new System.Drawing.Size(38, 17);
            this.chkCam14.TabIndex = 14;
            this.chkCam14.Text = "14";
            this.chkCam14.UseVisualStyleBackColor = true;
            // 
            // chkCam13
            // 
            this.chkCam13.AutoSize = true;
            this.chkCam13.Location = new System.Drawing.Point(212, 67);
            this.chkCam13.Name = "chkCam13";
            this.chkCam13.Size = new System.Drawing.Size(38, 17);
            this.chkCam13.TabIndex = 13;
            this.chkCam13.Text = "13";
            this.chkCam13.UseVisualStyleBackColor = true;
            // 
            // chkCam12
            // 
            this.chkCam12.AutoSize = true;
            this.chkCam12.Location = new System.Drawing.Point(169, 67);
            this.chkCam12.Name = "chkCam12";
            this.chkCam12.Size = new System.Drawing.Size(38, 17);
            this.chkCam12.TabIndex = 12;
            this.chkCam12.Text = "12";
            this.chkCam12.UseVisualStyleBackColor = true;
            // 
            // chkCam11
            // 
            this.chkCam11.AutoSize = true;
            this.chkCam11.Location = new System.Drawing.Point(126, 67);
            this.chkCam11.Name = "chkCam11";
            this.chkCam11.Size = new System.Drawing.Size(38, 17);
            this.chkCam11.TabIndex = 11;
            this.chkCam11.Text = "11";
            this.chkCam11.UseVisualStyleBackColor = true;
            // 
            // chkCam10
            // 
            this.chkCam10.AutoSize = true;
            this.chkCam10.Location = new System.Drawing.Point(83, 67);
            this.chkCam10.Name = "chkCam10";
            this.chkCam10.Size = new System.Drawing.Size(38, 17);
            this.chkCam10.TabIndex = 10;
            this.chkCam10.Text = "10";
            this.chkCam10.UseVisualStyleBackColor = true;
            // 
            // chkCam9
            // 
            this.chkCam9.AutoSize = true;
            this.chkCam9.Location = new System.Drawing.Point(40, 67);
            this.chkCam9.Name = "chkCam9";
            this.chkCam9.Size = new System.Drawing.Size(32, 17);
            this.chkCam9.TabIndex = 9;
            this.chkCam9.Text = "9";
            this.chkCam9.UseVisualStyleBackColor = true;
            // 
            // chkCam8
            // 
            this.chkCam8.AutoSize = true;
            this.chkCam8.Location = new System.Drawing.Point(337, 44);
            this.chkCam8.Name = "chkCam8";
            this.chkCam8.Size = new System.Drawing.Size(32, 17);
            this.chkCam8.TabIndex = 8;
            this.chkCam8.Text = "8";
            this.chkCam8.UseVisualStyleBackColor = true;
            // 
            // chkCam7
            // 
            this.chkCam7.AutoSize = true;
            this.chkCam7.Location = new System.Drawing.Point(298, 44);
            this.chkCam7.Name = "chkCam7";
            this.chkCam7.Size = new System.Drawing.Size(32, 17);
            this.chkCam7.TabIndex = 7;
            this.chkCam7.Text = "7";
            this.chkCam7.UseVisualStyleBackColor = true;
            // 
            // chkCam6
            // 
            this.chkCam6.AutoSize = true;
            this.chkCam6.Location = new System.Drawing.Point(255, 44);
            this.chkCam6.Name = "chkCam6";
            this.chkCam6.Size = new System.Drawing.Size(32, 17);
            this.chkCam6.TabIndex = 6;
            this.chkCam6.Text = "6";
            this.chkCam6.UseVisualStyleBackColor = true;
            // 
            // chkCam5
            // 
            this.chkCam5.AutoSize = true;
            this.chkCam5.Location = new System.Drawing.Point(212, 44);
            this.chkCam5.Name = "chkCam5";
            this.chkCam5.Size = new System.Drawing.Size(32, 17);
            this.chkCam5.TabIndex = 5;
            this.chkCam5.Text = "5";
            this.chkCam5.UseVisualStyleBackColor = true;
            // 
            // chkCam4
            // 
            this.chkCam4.AutoSize = true;
            this.chkCam4.Location = new System.Drawing.Point(169, 44);
            this.chkCam4.Name = "chkCam4";
            this.chkCam4.Size = new System.Drawing.Size(32, 17);
            this.chkCam4.TabIndex = 4;
            this.chkCam4.Text = "4";
            this.chkCam4.UseVisualStyleBackColor = true;
            // 
            // chkCam3
            // 
            this.chkCam3.AutoSize = true;
            this.chkCam3.Location = new System.Drawing.Point(126, 44);
            this.chkCam3.Name = "chkCam3";
            this.chkCam3.Size = new System.Drawing.Size(32, 17);
            this.chkCam3.TabIndex = 3;
            this.chkCam3.Text = "3";
            this.chkCam3.UseVisualStyleBackColor = true;
            // 
            // chkCam2
            // 
            this.chkCam2.AutoSize = true;
            this.chkCam2.Location = new System.Drawing.Point(83, 44);
            this.chkCam2.Name = "chkCam2";
            this.chkCam2.Size = new System.Drawing.Size(32, 17);
            this.chkCam2.TabIndex = 2;
            this.chkCam2.Text = "2";
            this.chkCam2.UseVisualStyleBackColor = true;
            // 
            // chkCam1
            // 
            this.chkCam1.AutoSize = true;
            this.chkCam1.Location = new System.Drawing.Point(40, 44);
            this.chkCam1.Name = "chkCam1";
            this.chkCam1.Size = new System.Drawing.Size(32, 17);
            this.chkCam1.TabIndex = 1;
            this.chkCam1.Text = "1";
            this.chkCam1.UseVisualStyleBackColor = true;
            // 
            // chkVisiCamAll
            // 
            this.chkVisiCamAll.AutoSize = true;
            this.chkVisiCamAll.Location = new System.Drawing.Point(16, 21);
            this.chkVisiCamAll.Name = "chkVisiCamAll";
            this.chkVisiCamAll.Size = new System.Drawing.Size(37, 17);
            this.chkVisiCamAll.TabIndex = 0;
            this.chkVisiCamAll.Text = "All";
            this.chkVisiCamAll.UseVisualStyleBackColor = true;
            this.chkVisiCamAll.CheckedChanged += new System.EventHandler(this.chkVisiCamAll_CheckedChanged);
            // 
            // grbTimeSpan
            // 
            this.grbTimeSpan.Controls.Add(this.timePickerExpiryDate);
            this.grbTimeSpan.Controls.Add(this.timePickerActiveDate);
            this.grbTimeSpan.Controls.Add(this.label3);
            this.grbTimeSpan.Controls.Add(this.label2);
            this.grbTimeSpan.Controls.Add(this.chkTimeSpanEnable);
            this.grbTimeSpan.Location = new System.Drawing.Point(398, 118);
            this.grbTimeSpan.Name = "grbTimeSpan";
            this.grbTimeSpan.Size = new System.Drawing.Size(380, 111);
            this.grbTimeSpan.TabIndex = 4;
            this.grbTimeSpan.TabStop = false;
            this.grbTimeSpan.Text = "Time Span";
            // 
            // timePickerExpiryDate
            // 
            this.timePickerExpiryDate.Enabled = false;
            this.timePickerExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timePickerExpiryDate.Location = new System.Drawing.Point(226, 68);
            this.timePickerExpiryDate.Name = "timePickerExpiryDate";
            this.timePickerExpiryDate.Size = new System.Drawing.Size(133, 20);
            this.timePickerExpiryDate.TabIndex = 4;
            // 
            // timePickerActiveDate
            // 
            this.timePickerActiveDate.Enabled = false;
            this.timePickerActiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timePickerActiveDate.Location = new System.Drawing.Point(56, 68);
            this.timePickerActiveDate.Name = "timePickerActiveDate";
            this.timePickerActiveDate.Size = new System.Drawing.Size(133, 20);
            this.timePickerActiveDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expiry Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Activation Date";
            // 
            // chkTimeSpanEnable
            // 
            this.chkTimeSpanEnable.AutoSize = true;
            this.chkTimeSpanEnable.Location = new System.Drawing.Point(40, 28);
            this.chkTimeSpanEnable.Name = "chkTimeSpanEnable";
            this.chkTimeSpanEnable.Size = new System.Drawing.Size(59, 17);
            this.chkTimeSpanEnable.TabIndex = 0;
            this.chkTimeSpanEnable.Text = "Enable";
            this.chkTimeSpanEnable.UseVisualStyleBackColor = true;
            this.chkTimeSpanEnable.CheckedChanged += new System.EventHandler(this.chkTimeSpanEnable_CheckedChanged);
            // 
            // chkSkipPassword
            // 
            this.chkSkipPassword.AutoSize = true;
            this.chkSkipPassword.Location = new System.Drawing.Point(414, 254);
            this.chkSkipPassword.Name = "chkSkipPassword";
            this.chkSkipPassword.Size = new System.Drawing.Size(96, 17);
            this.chkSkipPassword.TabIndex = 5;
            this.chkSkipPassword.Text = "Skip Password";
            this.chkSkipPassword.UseVisualStyleBackColor = true;
            this.chkSkipPassword.CheckedChanged += new System.EventHandler(this.chkSkipPassword_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Confirm Password :\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Description :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(567, 274);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 20);
            this.txtName.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(567, 300);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(190, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // txtPWConfirm
            // 
            this.txtPWConfirm.Location = new System.Drawing.Point(567, 326);
            this.txtPWConfirm.Name = "txtPWConfirm";
            this.txtPWConfirm.PasswordChar = '*';
            this.txtPWConfirm.Size = new System.Drawing.Size(190, 20);
            this.txtPWConfirm.TabIndex = 13;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(567, 352);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(190, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(520, 383);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(601, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(682, 383);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 17;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeyboard.Location = new System.Drawing.Point(437, 383);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(28, 23);
            this.btnKeyboard.TabIndex = 74;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // chkPCViewNet
            // 
            this.chkPCViewNet.AutoSize = true;
            this.chkPCViewNet.Location = new System.Drawing.Point(11, 19);
            this.chkPCViewNet.Name = "chkPCViewNet";
            this.chkPCViewNet.Size = new System.Drawing.Size(66, 17);
            this.chkPCViewNet.TabIndex = 0;
            this.chkPCViewNet.Text = "Network";
            this.chkPCViewNet.UseVisualStyleBackColor = true;
            // 
            // chkPCRemoteConsole
            // 
            this.chkPCRemoteConsole.AutoSize = true;
            this.chkPCRemoteConsole.Location = new System.Drawing.Point(30, 42);
            this.chkPCRemoteConsole.Name = "chkPCRemoteConsole";
            this.chkPCRemoteConsole.Size = new System.Drawing.Size(104, 17);
            this.chkPCRemoteConsole.TabIndex = 1;
            this.chkPCRemoteConsole.Text = "Remote Console";
            this.chkPCRemoteConsole.UseVisualStyleBackColor = true;
            // 
            // chkPCRemoteEmap
            // 
            this.chkPCRemoteEmap.AutoSize = true;
            this.chkPCRemoteEmap.Location = new System.Drawing.Point(30, 65);
            this.chkPCRemoteEmap.Name = "chkPCRemoteEmap";
            this.chkPCRemoteEmap.Size = new System.Drawing.Size(93, 17);
            this.chkPCRemoteEmap.TabIndex = 2;
            this.chkPCRemoteEmap.Text = "Remote Emap";
            this.chkPCRemoteEmap.UseVisualStyleBackColor = true;
            // 
            // chkPCRemoteRecord
            // 
            this.chkPCRemoteRecord.AutoSize = true;
            this.chkPCRemoteRecord.Location = new System.Drawing.Point(30, 88);
            this.chkPCRemoteRecord.Name = "chkPCRemoteRecord";
            this.chkPCRemoteRecord.Size = new System.Drawing.Size(101, 17);
            this.chkPCRemoteRecord.TabIndex = 3;
            this.chkPCRemoteRecord.Text = "Remote Record";
            this.chkPCRemoteRecord.UseVisualStyleBackColor = true;
            // 
            // chkRemoteLogView
            // 
            this.chkRemoteLogView.AutoSize = true;
            this.chkRemoteLogView.Location = new System.Drawing.Point(190, 42);
            this.chkRemoteLogView.Name = "chkRemoteLogView";
            this.chkRemoteLogView.Size = new System.Drawing.Size(116, 17);
            this.chkRemoteLogView.TabIndex = 4;
            this.chkRemoteLogView.Text = "Remote LogViewer";
            this.chkRemoteLogView.UseVisualStyleBackColor = true;
            // 
            // chkIPCam
            // 
            this.chkIPCam.AutoSize = true;
            this.chkIPCam.Location = new System.Drawing.Point(190, 65);
            this.chkIPCam.Name = "chkIPCam";
            this.chkIPCam.Size = new System.Drawing.Size(75, 17);
            this.chkIPCam.TabIndex = 5;
            this.chkIPCam.Text = "IP Camera";
            this.chkIPCam.UseVisualStyleBackColor = true;
            // 
            // chkRemoteSetup
            // 
            this.chkRemoteSetup.AutoSize = true;
            this.chkRemoteSetup.Location = new System.Drawing.Point(190, 88);
            this.chkRemoteSetup.Name = "chkRemoteSetup";
            this.chkRemoteSetup.Size = new System.Drawing.Size(94, 17);
            this.chkRemoteSetup.TabIndex = 6;
            this.chkRemoteSetup.Text = "Remote Setup";
            this.chkRemoteSetup.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtRATime);
            this.groupBox4.Controls.Add(this.chkRATInfinite);
            this.groupBox4.Location = new System.Drawing.Point(30, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 48);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remote Access Time";
            // 
            // chkRATInfinite
            // 
            this.chkRATInfinite.AutoSize = true;
            this.chkRATInfinite.Location = new System.Drawing.Point(39, 21);
            this.chkRATInfinite.Name = "chkRATInfinite";
            this.chkRATInfinite.Size = new System.Drawing.Size(57, 17);
            this.chkRATInfinite.TabIndex = 1;
            this.chkRATInfinite.Text = "Infinite";
            this.chkRATInfinite.UseVisualStyleBackColor = true;
            this.chkRATInfinite.CheckedChanged += new System.EventHandler(this.chkRATInfinite_CheckedChanged);
            // 
            // txtRATime
            // 
            this.txtRATime.Location = new System.Drawing.Point(160, 19);
            this.txtRATime.Name = "txtRATime";
            this.txtRATime.Size = new System.Drawing.Size(85, 20);
            this.txtRATime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Minute";
            // 
            // grbPCViewer
            // 
            this.grbPCViewer.Controls.Add(this.groupBox4);
            this.grbPCViewer.Controls.Add(this.chkRemoteSetup);
            this.grbPCViewer.Controls.Add(this.chkIPCam);
            this.grbPCViewer.Controls.Add(this.chkRemoteLogView);
            this.grbPCViewer.Controls.Add(this.chkPCRemoteRecord);
            this.grbPCViewer.Controls.Add(this.chkPCRemoteEmap);
            this.grbPCViewer.Controls.Add(this.chkPCRemoteConsole);
            this.grbPCViewer.Controls.Add(this.chkPCViewNet);
            this.grbPCViewer.Location = new System.Drawing.Point(12, 235);
            this.grbPCViewer.Name = "grbPCViewer";
            this.grbPCViewer.Size = new System.Drawing.Size(380, 171);
            this.grbPCViewer.TabIndex = 2;
            this.grbPCViewer.TabStop = false;
            this.grbPCViewer.Text = "PCViewer";
            // 
            // FrmUserSettingAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPWConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSkipPassword);
            this.Controls.Add(this.grbTimeSpan);
            this.Controls.Add(this.grbVisibleCam);
            this.Controls.Add(this.grbPCViewer);
            this.Controls.Add(this.grbControlRight);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUserSettingAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add User";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbControlRight.ResumeLayout(false);
            this.grbControlRight.PerformLayout();
            this.grbVisibleCam.ResumeLayout(false);
            this.grbVisibleCam.PerformLayout();
            this.grbTimeSpan.ResumeLayout(false);
            this.grbTimeSpan.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grbPCViewer.ResumeLayout(false);
            this.grbPCViewer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAdmin;
        private System.Windows.Forms.RadioButton rdbUser;
        private System.Windows.Forms.GroupBox grbControlRight;
        private System.Windows.Forms.CheckBox chkAdvancedMode;
        private System.Windows.Forms.CheckBox chkPowerOff;
        private System.Windows.Forms.CheckBox chkPlayback;
        private System.Windows.Forms.CheckBox chkNetControl;
        private System.Windows.Forms.CheckBox chkRecord;
        private System.Windows.Forms.CheckBox chkSystemSetting;
        private System.Windows.Forms.CheckBox chkPTZSetup;
        private System.Windows.Forms.CheckBox chkGroupTreeMenu;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.CheckBox chkReboot;
        private System.Windows.Forms.CheckBox chkMinimize;
        private System.Windows.Forms.CheckBox chkPOS;
        private System.Windows.Forms.CheckBox chkScheduler;
        private System.Windows.Forms.CheckBox chkBackUp;
        private System.Windows.Forms.CheckBox chkEMap;
        private System.Windows.Forms.CheckBox chkPTZControl;
        private System.Windows.Forms.GroupBox grbVisibleCam;
        private System.Windows.Forms.CheckBox chkCam16;
        private System.Windows.Forms.CheckBox chkCam15;
        private System.Windows.Forms.CheckBox chkCam14;
        private System.Windows.Forms.CheckBox chkCam13;
        private System.Windows.Forms.CheckBox chkCam12;
        private System.Windows.Forms.CheckBox chkCam11;
        private System.Windows.Forms.CheckBox chkCam10;
        private System.Windows.Forms.CheckBox chkCam9;
        private System.Windows.Forms.CheckBox chkCam8;
        private System.Windows.Forms.CheckBox chkCam7;
        private System.Windows.Forms.CheckBox chkCam6;
        private System.Windows.Forms.CheckBox chkCam5;
        private System.Windows.Forms.CheckBox chkCam4;
        private System.Windows.Forms.CheckBox chkCam3;
        private System.Windows.Forms.CheckBox chkCam2;
        private System.Windows.Forms.CheckBox chkCam1;
        private System.Windows.Forms.CheckBox chkVisiCamAll;
        private System.Windows.Forms.Button btnVisiCamPrev;
        private System.Windows.Forms.Button btnVisiCamNext;
        private System.Windows.Forms.GroupBox grbTimeSpan;
        private System.Windows.Forms.DateTimePicker timePickerExpiryDate;
        private System.Windows.Forms.DateTimePicker timePickerActiveDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTimeSpanEnable;
        private System.Windows.Forms.CheckBox chkSkipPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPWConfirm;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.CheckBox chkPCViewNet;
        private System.Windows.Forms.CheckBox chkPCRemoteConsole;
        private System.Windows.Forms.CheckBox chkPCRemoteEmap;
        private System.Windows.Forms.CheckBox chkPCRemoteRecord;
        private System.Windows.Forms.CheckBox chkRemoteLogView;
        private System.Windows.Forms.CheckBox chkIPCam;
        private System.Windows.Forms.CheckBox chkRemoteSetup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRATime;
        private System.Windows.Forms.CheckBox chkRATInfinite;
        private System.Windows.Forms.GroupBox grbPCViewer;
    }
}
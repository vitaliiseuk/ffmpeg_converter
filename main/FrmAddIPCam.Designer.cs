namespace iNVMSMain
{
    partial class FrmAddIPCam
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
			this.txtAuthenPassword = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAuthenID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkAuthentication = new System.Windows.Forms.CheckBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblPort = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.lblIPAddress = new System.Windows.Forms.Label();
			this.cmbVideoFormatList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbModelList = new System.Windows.Forms.ComboBox();
			this.lblModel = new System.Windows.Forms.Label();
			this.cmbProtocolList = new System.Windows.Forms.ComboBox();
			this.chkEnableAudio = new System.Windows.Forms.CheckBox();
			this.btnSaveExit = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnKeyboard = new System.Windows.Forms.Button();
			this.cmbChannel = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnConfigDefaultPorts = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDeviceID = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioByDeviceID = new System.Windows.Forms.RadioButton();
			this.radioByIP = new System.Windows.Forms.RadioButton();
			this.chkDisplayOn = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAuthenPassword
			// 
			this.txtAuthenPassword.Location = new System.Drawing.Point(406, 308);
			this.txtAuthenPassword.Name = "txtAuthenPassword";
			this.txtAuthenPassword.Size = new System.Drawing.Size(150, 20);
			this.txtAuthenPassword.TabIndex = 21;
			this.txtAuthenPassword.Text = "123456";
			this.txtAuthenPassword.UseSystemPasswordChar = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(341, 311);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Password";
			// 
			// txtAuthenID
			// 
			this.txtAuthenID.Location = new System.Drawing.Point(93, 308);
			this.txtAuthenID.Name = "txtAuthenID";
			this.txtAuthenID.Size = new System.Drawing.Size(150, 20);
			this.txtAuthenID.TabIndex = 19;
			this.txtAuthenID.Text = "admin";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(58, 311);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(18, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "ID";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// chkAuthentication
			// 
			this.chkAuthentication.AutoSize = true;
			this.chkAuthentication.Checked = true;
			this.chkAuthentication.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAuthentication.Location = new System.Drawing.Point(14, 279);
			this.chkAuthentication.Name = "chkAuthentication";
			this.chkAuthentication.Size = new System.Drawing.Size(94, 17);
			this.chkAuthentication.TabIndex = 17;
			this.chkAuthentication.Text = "Authentication";
			this.chkAuthentication.UseVisualStyleBackColor = true;
			this.chkAuthentication.CheckedChanged += new System.EventHandler(this.chkAuthentication_CheckedChanged);
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(92, 179);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(63, 20);
			this.txtPort.TabIndex = 13;
			this.txtPort.Text = "34567";
			// 
			// lblPort
			// 
			this.lblPort.Location = new System.Drawing.Point(12, 182);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(64, 13);
			this.lblPort.TabIndex = 12;
			this.lblPort.Text = "Port";
			this.lblPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(92, 148);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(151, 20);
			this.txtIPAddress.TabIndex = 11;
			// 
			// lblIPAddress
			// 
			this.lblIPAddress.Location = new System.Drawing.Point(9, 151);
			this.lblIPAddress.Name = "lblIPAddress";
			this.lblIPAddress.Size = new System.Drawing.Size(67, 13);
			this.lblIPAddress.TabIndex = 10;
			this.lblIPAddress.Text = "Camera IP";
			this.lblIPAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbVideoFormatList
			// 
			this.cmbVideoFormatList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVideoFormatList.FormattingEnabled = true;
			this.cmbVideoFormatList.Items.AddRange(new object[] {
            "Auto"});
			this.cmbVideoFormatList.Location = new System.Drawing.Point(90, 80);
			this.cmbVideoFormatList.Name = "cmbVideoFormatList";
			this.cmbVideoFormatList.Size = new System.Drawing.Size(151, 21);
			this.cmbVideoFormatList.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Video Format";
			// 
			// cmbModelList
			// 
			this.cmbModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModelList.FormattingEnabled = true;
			this.cmbModelList.Items.AddRange(new object[] {
            "----"});
			this.cmbModelList.Location = new System.Drawing.Point(90, 46);
			this.cmbModelList.Name = "cmbModelList";
			this.cmbModelList.Size = new System.Drawing.Size(151, 21);
			this.cmbModelList.TabIndex = 5;
			// 
			// lblModel
			// 
			this.lblModel.AutoSize = true;
			this.lblModel.Location = new System.Drawing.Point(40, 49);
			this.lblModel.Name = "lblModel";
			this.lblModel.Size = new System.Drawing.Size(36, 13);
			this.lblModel.TabIndex = 4;
			this.lblModel.Text = "Model";
			// 
			// cmbProtocolList
			// 
			this.cmbProtocolList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProtocolList.FormattingEnabled = true;
			this.cmbProtocolList.Items.AddRange(new object[] {
            "ONVIF",
            "RTSP",
            "iLinkPro iHD Series",
            "XM XVR",
            "AVer NV Series"});
			this.cmbProtocolList.Location = new System.Drawing.Point(90, 12);
			this.cmbProtocolList.Name = "cmbProtocolList";
			this.cmbProtocolList.Size = new System.Drawing.Size(151, 21);
			this.cmbProtocolList.TabIndex = 3;
			this.cmbProtocolList.SelectedIndexChanged += new System.EventHandler(this.OnProtocolList_SelChange);
			// 
			// chkEnableAudio
			// 
			this.chkEnableAudio.AutoSize = true;
			this.chkEnableAudio.Location = new System.Drawing.Point(418, 246);
			this.chkEnableAudio.Name = "chkEnableAudio";
			this.chkEnableAudio.Size = new System.Drawing.Size(89, 17);
			this.chkEnableAudio.TabIndex = 1;
			this.chkEnableAudio.Text = "Enable Audio";
			this.chkEnableAudio.UseVisualStyleBackColor = true;
			// 
			// btnSaveExit
			// 
			this.btnSaveExit.Location = new System.Drawing.Point(220, 342);
			this.btnSaveExit.Name = "btnSaveExit";
			this.btnSaveExit.Size = new System.Drawing.Size(108, 26);
			this.btnSaveExit.TabIndex = 2;
			this.btnSaveExit.Text = "Save && Exit";
			this.btnSaveExit.UseVisualStyleBackColor = true;
			this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(334, 342);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(108, 26);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(448, 342);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(108, 26);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnKeyboard
			// 
			this.btnKeyboard.Image = global::iNVMSMain.Properties.Resources.keyboard_short;
			this.btnKeyboard.Location = new System.Drawing.Point(183, 342);
			this.btnKeyboard.Name = "btnKeyboard";
			this.btnKeyboard.Size = new System.Drawing.Size(31, 26);
			this.btnKeyboard.TabIndex = 71;
			this.btnKeyboard.UseVisualStyleBackColor = true;
			this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
			// 
			// cmbChannel
			// 
			this.cmbChannel.FormattingEnabled = true;
			this.cmbChannel.Location = new System.Drawing.Point(92, 209);
			this.cmbChannel.Name = "cmbChannel";
			this.cmbChannel.Size = new System.Drawing.Size(151, 21);
			this.cmbChannel.TabIndex = 73;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 72;
			this.label3.Text = "Channel";
			// 
			// btnConfigDefaultPorts
			// 
			this.btnConfigDefaultPorts.Location = new System.Drawing.Point(161, 177);
			this.btnConfigDefaultPorts.Name = "btnConfigDefaultPorts";
			this.btnConfigDefaultPorts.Size = new System.Drawing.Size(81, 23);
			this.btnConfigDefaultPorts.TabIndex = 74;
			this.btnConfigDefaultPorts.Text = "Default Ports";
			this.btnConfigDefaultPorts.UseVisualStyleBackColor = true;
			this.btnConfigDefaultPorts.Click += new System.EventHandler(this.btnConfigDefaultPorts_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(30, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 76;
			this.label8.Text = "Protocol";
			// 
			// txtDeviceID
			// 
			this.txtDeviceID.Location = new System.Drawing.Point(93, 243);
			this.txtDeviceID.Name = "txtDeviceID";
			this.txtDeviceID.Size = new System.Drawing.Size(150, 20);
			this.txtDeviceID.TabIndex = 84;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(23, 246);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(55, 13);
			this.label11.TabIndex = 83;
			this.label11.Text = "Device ID";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 119);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 13);
			this.label12.TabIndex = 85;
			this.label12.Text = "Connect by";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioByDeviceID);
			this.panel1.Controls.Add(this.radioByIP);
			this.panel1.Location = new System.Drawing.Point(91, 113);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(152, 21);
			this.panel1.TabIndex = 86;
			// 
			// radioByDeviceID
			// 
			this.radioByDeviceID.AutoSize = true;
			this.radioByDeviceID.Location = new System.Drawing.Point(83, 2);
			this.radioByDeviceID.Name = "radioByDeviceID";
			this.radioByDeviceID.Size = new System.Drawing.Size(73, 17);
			this.radioByDeviceID.TabIndex = 80;
			this.radioByDeviceID.TabStop = true;
			this.radioByDeviceID.Text = "Device ID";
			this.radioByDeviceID.UseVisualStyleBackColor = true;
			this.radioByDeviceID.CheckedChanged += new System.EventHandler(this.radioByDeviceID_CheckedChanged);
			// 
			// radioByIP
			// 
			this.radioByIP.AutoSize = true;
			this.radioByIP.Checked = true;
			this.radioByIP.Location = new System.Drawing.Point(1, 2);
			this.radioByIP.Name = "radioByIP";
			this.radioByIP.Size = new System.Drawing.Size(76, 17);
			this.radioByIP.TabIndex = 79;
			this.radioByIP.TabStop = true;
			this.radioByIP.Text = "IP Address";
			this.radioByIP.UseVisualStyleBackColor = true;
			this.radioByIP.CheckedChanged += new System.EventHandler(this.radioByIP_CheckedChanged);
			// 
			// chkDisplayOn
			// 
			this.chkDisplayOn.AutoSize = true;
			this.chkDisplayOn.Checked = true;
			this.chkDisplayOn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDisplayOn.Location = new System.Drawing.Point(299, 246);
			this.chkDisplayOn.Name = "chkDisplayOn";
			this.chkDisplayOn.Size = new System.Drawing.Size(77, 17);
			this.chkDisplayOn.TabIndex = 87;
			this.chkDisplayOn.Text = "Display On";
			this.chkDisplayOn.UseVisualStyleBackColor = true;
			// 
			// FrmAddIPCam
			// 
			this.AcceptButton = this.btnSaveExit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 376);
			this.Controls.Add(this.chkDisplayOn);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtDeviceID);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnConfigDefaultPorts);
			this.Controls.Add(this.cmbChannel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnKeyboard);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtAuthenPassword);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnSaveExit);
			this.Controls.Add(this.txtAuthenID);
			this.Controls.Add(this.chkEnableAudio);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.chkAuthentication);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.cmbProtocolList);
			this.Controls.Add(this.lblPort);
			this.Controls.Add(this.lblModel);
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.cmbModelList);
			this.Controls.Add(this.lblIPAddress);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbVideoFormatList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAddIPCam";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Camera";
			this.Load += new System.EventHandler(this.FrmAddIPCam_Load);
			this.Shown += new System.EventHandler(this.FrmAddIPCam_Shown);
			this.Move += new System.EventHandler(this.FrmAddIPCam_Move);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ComboBox cmbModelList;
        private System.Windows.Forms.Label lblModel;
		private System.Windows.Forms.ComboBox cmbProtocolList;
        private System.Windows.Forms.ComboBox cmbVideoFormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtAuthenPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAuthenID;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkAuthentication;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.CheckBox chkEnableAudio;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnKeyboard;
		private System.Windows.Forms.ComboBox cmbChannel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnConfigDefaultPorts;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDeviceID;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioByDeviceID;
		private System.Windows.Forms.RadioButton radioByIP;
		private System.Windows.Forms.CheckBox chkDisplayOn;
    }
}
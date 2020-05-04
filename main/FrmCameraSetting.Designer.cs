namespace iNVMSMain
{
    partial class FrmCameraSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCameraSetting));
            this.chkCameraSettingAll = new System.Windows.Forms.CheckBox();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkEnableAudio = new System.Windows.Forms.CheckBox();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.chkDisplayOn = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.TextBox();
            this.lblCamAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCamDescription = new System.Windows.Forms.TextBox();
            this.txtCamName = new System.Windows.Forms.TextBox();
            this.lblCamModel = new System.Windows.Forms.Label();
            this.lblCamProtocol = new System.Windows.Forms.Label();
            this.btnEditCamera = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSoftWDR = new System.Windows.Forms.CheckBox();
            this.txtSaturation = new System.Windows.Forms.TextBox();
            this.trackSaturation = new System.Windows.Forms.TrackBar();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.chkDefog = new System.Windows.Forms.CheckBox();
            this.txtHue = new System.Windows.Forms.TextBox();
            this.trackHue = new System.Windows.Forms.TrackBar();
            this.lblHue = new System.Windows.Forms.Label();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.trackContrast = new System.Windows.Forms.TrackBar();
            this.lblContrast = new System.Windows.Forms.Label();
            this.trackBright = new System.Windows.Forms.TrackBar();
            this.lblBright = new System.Windows.Forms.Label();
            this.txtBright = new System.Windows.Forms.TextBox();
            this.cmbDeinterlace = new System.Windows.Forms.ComboBox();
            this.chkNightView = new System.Windows.Forms.CheckBox();
            this.chkAutoBrightControl = new System.Windows.Forms.CheckBox();
            this.chkOriginalDisplayAspectRatio = new System.Windows.Forms.CheckBox();
            this.mnuCameraEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteAllCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnalogCam = new System.Windows.Forms.Button();
            this.btnAddXVRCamera = new System.Windows.Forms.Button();
            this.btnAddIPCamera = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeCamList = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCameraBinding = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteCamera = new System.Windows.Forms.Button();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.treeViewGroup = new System.Windows.Forms.TreeView();
            this.cameraPicker = new iNVMS.CustomControl.CameraPicker();
            this.grpCamera.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBright)).BeginInit();
            this.mnuCameraEdit.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCameraSettingAll
            // 
            this.chkCameraSettingAll.AutoSize = true;
            this.chkCameraSettingAll.Location = new System.Drawing.Point(10, 5);
            this.chkCameraSettingAll.Name = "chkCameraSettingAll";
            this.chkCameraSettingAll.Size = new System.Drawing.Size(37, 17);
            this.chkCameraSettingAll.TabIndex = 0;
            this.chkCameraSettingAll.Text = "All";
            this.chkCameraSettingAll.UseVisualStyleBackColor = true;
            this.chkCameraSettingAll.CheckedChanged += new System.EventHandler(this.chkCameraSettingAll_CheckedChanged);
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.txtDescription);
            this.grpCamera.Controls.Add(this.lblDescription);
            this.grpCamera.Controls.Add(this.chkEnableAudio);
            this.grpCamera.Controls.Add(this.txtChannel);
            this.grpCamera.Controls.Add(this.chkDisplayOn);
            this.grpCamera.Controls.Add(this.label4);
            this.grpCamera.Controls.Add(this.txtDisplayName1);
            this.grpCamera.Controls.Add(this.label2);
            this.grpCamera.Controls.Add(this.lblPort);
            this.grpCamera.Controls.Add(this.lblCamAddress);
            this.grpCamera.Controls.Add(this.label3);
            this.grpCamera.Controls.Add(this.label1);
            this.grpCamera.Controls.Add(this.txtCamDescription);
            this.grpCamera.Controls.Add(this.txtCamName);
            this.grpCamera.Controls.Add(this.lblCamModel);
            this.grpCamera.Controls.Add(this.lblCamProtocol);
            this.grpCamera.Location = new System.Drawing.Point(5, 102);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(269, 252);
            this.grpCamera.TabIndex = 22;
            this.grpCamera.TabStop = false;
            this.grpCamera.Text = "Camera Infomation";
            this.grpCamera.Enter += new System.EventHandler(this.grpCamera_Enter);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(87, 54);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(171, 20);
            this.txtDescription.TabIndex = 78;
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 77;
            this.lblDescription.Text = "Description";
            // 
            // chkEnableAudio
            // 
            this.chkEnableAudio.AutoSize = true;
            this.chkEnableAudio.Location = new System.Drawing.Point(160, 227);
            this.chkEnableAudio.Name = "chkEnableAudio";
            this.chkEnableAudio.Size = new System.Drawing.Size(89, 17);
            this.chkEnableAudio.TabIndex = 76;
            this.chkEnableAudio.Text = "Enable Audio";
            this.chkEnableAudio.UseVisualStyleBackColor = true;
            this.chkEnableAudio.CheckedChanged += new System.EventHandler(this.chkEnableAudio_CheckedChanged);
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(87, 193);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.ReadOnly = true;
            this.txtChannel.Size = new System.Drawing.Size(171, 20);
            this.txtChannel.TabIndex = 39;
            // 
            // chkDisplayOn
            // 
            this.chkDisplayOn.AutoSize = true;
            this.chkDisplayOn.Location = new System.Drawing.Point(28, 227);
            this.chkDisplayOn.Name = "chkDisplayOn";
            this.chkDisplayOn.Size = new System.Drawing.Size(77, 17);
            this.chkDisplayOn.TabIndex = 75;
            this.chkDisplayOn.Text = "Display On";
            this.chkDisplayOn.UseVisualStyleBackColor = true;
            this.chkDisplayOn.CheckedChanged += new System.EventHandler(this.chkDisplayOn_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Channel";
            // 
            // txtDisplayName1
            // 
            this.txtDisplayName1.Location = new System.Drawing.Point(87, 26);
            this.txtDisplayName1.Name = "txtDisplayName1";
            this.txtDisplayName1.Size = new System.Drawing.Size(171, 20);
            this.txtDisplayName1.TabIndex = 37;
            this.txtDisplayName1.TextChanged += new System.EventHandler(this.txtDisplayName1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Display Name";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(87, 163);
            this.lblPort.Name = "lblPort";
            this.lblPort.ReadOnly = true;
            this.lblPort.Size = new System.Drawing.Size(171, 20);
            this.lblPort.TabIndex = 35;
            // 
            // lblCamAddress
            // 
            this.lblCamAddress.Location = new System.Drawing.Point(87, 135);
            this.lblCamAddress.Name = "lblCamAddress";
            this.lblCamAddress.ReadOnly = true;
            this.lblCamAddress.Size = new System.Drawing.Size(171, 20);
            this.lblCamAddress.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Address";
            // 
            // txtCamDescription
            // 
            this.txtCamDescription.Location = new System.Drawing.Point(87, 108);
            this.txtCamDescription.Name = "txtCamDescription";
            this.txtCamDescription.ReadOnly = true;
            this.txtCamDescription.Size = new System.Drawing.Size(171, 20);
            this.txtCamDescription.TabIndex = 27;
            // 
            // txtCamName
            // 
            this.txtCamName.Location = new System.Drawing.Point(87, 82);
            this.txtCamName.Name = "txtCamName";
            this.txtCamName.ReadOnly = true;
            this.txtCamName.Size = new System.Drawing.Size(171, 20);
            this.txtCamName.TabIndex = 26;
            // 
            // lblCamModel
            // 
            this.lblCamModel.AutoSize = true;
            this.lblCamModel.Location = new System.Drawing.Point(12, 111);
            this.lblCamModel.Name = "lblCamModel";
            this.lblCamModel.Size = new System.Drawing.Size(36, 13);
            this.lblCamModel.TabIndex = 25;
            this.lblCamModel.Text = "Model";
            // 
            // lblCamProtocol
            // 
            this.lblCamProtocol.AutoSize = true;
            this.lblCamProtocol.Location = new System.Drawing.Point(12, 86);
            this.lblCamProtocol.Name = "lblCamProtocol";
            this.lblCamProtocol.Size = new System.Drawing.Size(31, 13);
            this.lblCamProtocol.TabIndex = 24;
            this.lblCamProtocol.Text = "Type";
            // 
            // btnEditCamera
            // 
            this.btnEditCamera.Location = new System.Drawing.Point(7, 361);
            this.btnEditCamera.Name = "btnEditCamera";
            this.btnEditCamera.Size = new System.Drawing.Size(130, 27);
            this.btnEditCamera.TabIndex = 38;
            this.btnEditCamera.Text = "Edit";
            this.btnEditCamera.UseVisualStyleBackColor = true;
            this.btnEditCamera.Click += new System.EventHandler(this.btnEditCamera_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSoftWDR);
            this.groupBox2.Controls.Add(this.txtSaturation);
            this.groupBox2.Controls.Add(this.trackSaturation);
            this.groupBox2.Controls.Add(this.lblSaturation);
            this.groupBox2.Controls.Add(this.chkDefog);
            this.groupBox2.Controls.Add(this.txtHue);
            this.groupBox2.Controls.Add(this.trackHue);
            this.groupBox2.Controls.Add(this.lblHue);
            this.groupBox2.Controls.Add(this.txtContrast);
            this.groupBox2.Controls.Add(this.trackContrast);
            this.groupBox2.Controls.Add(this.lblContrast);
            this.groupBox2.Controls.Add(this.trackBright);
            this.groupBox2.Controls.Add(this.lblBright);
            this.groupBox2.Controls.Add(this.txtBright);
            this.groupBox2.Controls.Add(this.cmbDeinterlace);
            this.groupBox2.Controls.Add(this.chkNightView);
            this.groupBox2.Controls.Add(this.chkAutoBrightControl);
            this.groupBox2.Controls.Add(this.chkOriginalDisplayAspectRatio);
            this.groupBox2.Location = new System.Drawing.Point(5, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 133);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Enhancement";
            // 
            // chkSoftWDR
            // 
            this.chkSoftWDR.AutoSize = true;
            this.chkSoftWDR.Location = new System.Drawing.Point(442, 48);
            this.chkSoftWDR.Name = "chkSoftWDR";
            this.chkSoftWDR.Size = new System.Drawing.Size(72, 17);
            this.chkSoftWDR.TabIndex = 37;
            this.chkSoftWDR.Text = "SoftWDR";
            this.chkSoftWDR.UseVisualStyleBackColor = true;
            this.chkSoftWDR.Visible = false;
            // 
            // txtSaturation
            // 
            this.txtSaturation.Location = new System.Drawing.Point(216, 101);
            this.txtSaturation.Name = "txtSaturation";
            this.txtSaturation.Size = new System.Drawing.Size(40, 20);
            this.txtSaturation.TabIndex = 35;
            this.txtSaturation.Text = "0";
            this.txtSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaturation.TextChanged += new System.EventHandler(this.txtSaturation_TextChanged);
            // 
            // trackSaturation
            // 
            this.trackSaturation.Location = new System.Drawing.Point(60, 101);
            this.trackSaturation.Maximum = 100;
            this.trackSaturation.Name = "trackSaturation";
            this.trackSaturation.Size = new System.Drawing.Size(154, 45);
            this.trackSaturation.TabIndex = 34;
            this.trackSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackSaturation.Scroll += new System.EventHandler(this.trackSaturation_Scroll);
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Location = new System.Drawing.Point(9, 103);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(55, 13);
            this.lblSaturation.TabIndex = 33;
            this.lblSaturation.Text = "Saturation";
            // 
            // chkDefog
            // 
            this.chkDefog.AutoSize = true;
            this.chkDefog.Location = new System.Drawing.Point(442, 20);
            this.chkDefog.Name = "chkDefog";
            this.chkDefog.Size = new System.Drawing.Size(55, 17);
            this.chkDefog.TabIndex = 36;
            this.chkDefog.Text = "Defog";
            this.chkDefog.UseVisualStyleBackColor = true;
            this.chkDefog.Visible = false;
            // 
            // txtHue
            // 
            this.txtHue.Location = new System.Drawing.Point(216, 75);
            this.txtHue.Name = "txtHue";
            this.txtHue.Size = new System.Drawing.Size(40, 20);
            this.txtHue.TabIndex = 32;
            this.txtHue.Text = "0";
            this.txtHue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHue.TextChanged += new System.EventHandler(this.txtHue_TextChanged);
            // 
            // trackHue
            // 
            this.trackHue.Location = new System.Drawing.Point(60, 75);
            this.trackHue.Maximum = 100;
            this.trackHue.Name = "trackHue";
            this.trackHue.Size = new System.Drawing.Size(154, 45);
            this.trackHue.TabIndex = 31;
            this.trackHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHue.Scroll += new System.EventHandler(this.trackHue_Scroll);
            // 
            // lblHue
            // 
            this.lblHue.AutoSize = true;
            this.lblHue.Location = new System.Drawing.Point(9, 78);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(27, 13);
            this.lblHue.TabIndex = 30;
            this.lblHue.Text = "Hue";
            // 
            // txtContrast
            // 
            this.txtContrast.Location = new System.Drawing.Point(216, 47);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(40, 20);
            this.txtContrast.TabIndex = 29;
            this.txtContrast.Text = "0";
            this.txtContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrast.TextChanged += new System.EventHandler(this.txtContrast_TextChanged);
            // 
            // trackContrast
            // 
            this.trackContrast.Location = new System.Drawing.Point(60, 49);
            this.trackContrast.Maximum = 100;
            this.trackContrast.Name = "trackContrast";
            this.trackContrast.Size = new System.Drawing.Size(154, 45);
            this.trackContrast.TabIndex = 3;
            this.trackContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackContrast.Scroll += new System.EventHandler(this.trackContrast_Scroll);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(9, 51);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(46, 13);
            this.lblContrast.TabIndex = 2;
            this.lblContrast.Text = "Contrast";
            // 
            // trackBright
            // 
            this.trackBright.Location = new System.Drawing.Point(60, 21);
            this.trackBright.Maximum = 100;
            this.trackBright.Name = "trackBright";
            this.trackBright.Size = new System.Drawing.Size(154, 45);
            this.trackBright.TabIndex = 1;
            this.trackBright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBright.Scroll += new System.EventHandler(this.trackBright_Scroll);
            // 
            // lblBright
            // 
            this.lblBright.AutoSize = true;
            this.lblBright.Location = new System.Drawing.Point(9, 23);
            this.lblBright.Name = "lblBright";
            this.lblBright.Size = new System.Drawing.Size(56, 13);
            this.lblBright.TabIndex = 0;
            this.lblBright.Text = "Brightness";
            // 
            // txtBright
            // 
            this.txtBright.Location = new System.Drawing.Point(216, 20);
            this.txtBright.Name = "txtBright";
            this.txtBright.Size = new System.Drawing.Size(40, 20);
            this.txtBright.TabIndex = 28;
            this.txtBright.Text = "0";
            this.txtBright.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBright.TextChanged += new System.EventHandler(this.txtBright_TextChanged);
            // 
            // cmbDeinterlace
            // 
            this.cmbDeinterlace.FormattingEnabled = true;
            this.cmbDeinterlace.Location = new System.Drawing.Point(472, 99);
            this.cmbDeinterlace.Name = "cmbDeinterlace";
            this.cmbDeinterlace.Size = new System.Drawing.Size(82, 21);
            this.cmbDeinterlace.TabIndex = 32;
            this.cmbDeinterlace.Visible = false;
            // 
            // chkNightView
            // 
            this.chkNightView.AutoSize = true;
            this.chkNightView.Location = new System.Drawing.Point(292, 62);
            this.chkNightView.Name = "chkNightView";
            this.chkNightView.Size = new System.Drawing.Size(77, 17);
            this.chkNightView.TabIndex = 30;
            this.chkNightView.Text = "Night View";
            this.chkNightView.UseVisualStyleBackColor = true;
            this.chkNightView.CheckedChanged += new System.EventHandler(this.chkNightView_CheckedChanged);
            // 
            // chkAutoBrightControl
            // 
            this.chkAutoBrightControl.AutoSize = true;
            this.chkAutoBrightControl.Location = new System.Drawing.Point(292, 23);
            this.chkAutoBrightControl.Name = "chkAutoBrightControl";
            this.chkAutoBrightControl.Size = new System.Drawing.Size(136, 17);
            this.chkAutoBrightControl.TabIndex = 29;
            this.chkAutoBrightControl.Text = "Auto Brightness Control";
            this.chkAutoBrightControl.UseVisualStyleBackColor = true;
            this.chkAutoBrightControl.CheckedChanged += new System.EventHandler(this.chkAutoBrightControl_CheckedChanged);
            // 
            // chkOriginalDisplayAspectRatio
            // 
            this.chkOriginalDisplayAspectRatio.AutoSize = true;
            this.chkOriginalDisplayAspectRatio.Location = new System.Drawing.Point(292, 104);
            this.chkOriginalDisplayAspectRatio.Name = "chkOriginalDisplayAspectRatio";
            this.chkOriginalDisplayAspectRatio.Size = new System.Drawing.Size(162, 17);
            this.chkOriginalDisplayAspectRatio.TabIndex = 34;
            this.chkOriginalDisplayAspectRatio.Text = "Original Display Aspect Ratio";
            this.chkOriginalDisplayAspectRatio.UseVisualStyleBackColor = true;
            // 
            // mnuCameraEdit
            // 
            this.mnuCameraEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteCamera,
            this.mnuDeleteAllCamera});
            this.mnuCameraEdit.Name = "mnuCameraEdit";
            this.mnuCameraEdit.Size = new System.Drawing.Size(125, 48);
            // 
            // mnuDeleteCamera
            // 
            this.mnuDeleteCamera.Name = "mnuDeleteCamera";
            this.mnuDeleteCamera.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteCamera.Text = "Delete";
            this.mnuDeleteCamera.Click += new System.EventHandler(this.mnuDeleteCamera_Click);
            // 
            // mnuDeleteAllCamera
            // 
            this.mnuDeleteAllCamera.Name = "mnuDeleteAllCamera";
            this.mnuDeleteAllCamera.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteAllCamera.Text = "Delete All";
            this.mnuDeleteAllCamera.Click += new System.EventHandler(this.mnuDeleteAllCamera_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(600, 556);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 28);
            this.btnOK.TabIndex = 44;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAnalogCam
            // 
            this.btnAnalogCam.Enabled = false;
            this.btnAnalogCam.Location = new System.Drawing.Point(16, 16);
            this.btnAnalogCam.Name = "btnAnalogCam";
            this.btnAnalogCam.Size = new System.Drawing.Size(151, 28);
            this.btnAnalogCam.TabIndex = 46;
            this.btnAnalogCam.Text = "Analog Camera";
            this.btnAnalogCam.UseVisualStyleBackColor = true;
            // 
            // btnAddXVRCamera
            // 
            this.btnAddXVRCamera.Location = new System.Drawing.Point(214, 16);
            this.btnAddXVRCamera.Name = "btnAddXVRCamera";
            this.btnAddXVRCamera.Size = new System.Drawing.Size(151, 28);
            this.btnAddXVRCamera.TabIndex = 46;
            this.btnAddXVRCamera.Text = "XVR Camera";
            this.btnAddXVRCamera.UseVisualStyleBackColor = true;
            this.btnAddXVRCamera.Click += new System.EventHandler(this.btnAddXVRCamera_Click);
            // 
            // btnAddIPCamera
            // 
            this.btnAddIPCamera.Location = new System.Drawing.Point(404, 16);
            this.btnAddIPCamera.Name = "btnAddIPCamera";
            this.btnAddIPCamera.Size = new System.Drawing.Size(151, 28);
            this.btnAddIPCamera.TabIndex = 46;
            this.btnAddIPCamera.Text = "IP Camera";
            this.btnAddIPCamera.UseVisualStyleBackColor = true;
            this.btnAddIPCamera.Click += new System.EventHandler(this.btnAddIPCam_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeCamList);
            this.groupBox4.Controls.Add(this.btnCameraBinding);
            this.groupBox4.Location = new System.Drawing.Point(603, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 267);
            this.groupBox4.TabIndex = 66;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Camera";
            // 
            // treeCamList
            // 
            this.treeCamList.ContextMenuStrip = this.mnuCameraEdit;
            this.treeCamList.ImageIndex = 2;
            this.treeCamList.ImageList = this.imageList;
            this.treeCamList.Location = new System.Drawing.Point(9, 19);
            this.treeCamList.Name = "treeCamList";
            this.treeCamList.SelectedImageIndex = 0;
            this.treeCamList.Size = new System.Drawing.Size(215, 208);
            this.treeCamList.TabIndex = 1;
            this.treeCamList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeCam_ItemDrag);
            this.treeCamList.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeCamList_DragEnter);
            this.treeCamList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.TreeCam_GiveFeedback);
            this.treeCamList.DoubleClick += new System.EventHandler(this.TreeCam_DoubleClick);
            this.treeCamList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeCamList_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_close.png");
            this.imageList.Images.SetKeyName(1, "folder_open.png");
            this.imageList.Images.SetKeyName(2, "ipcamera_small.png");
            // 
            // btnCameraBinding
            // 
            this.btnCameraBinding.Location = new System.Drawing.Point(8, 233);
            this.btnCameraBinding.Name = "btnCameraBinding";
            this.btnCameraBinding.Size = new System.Drawing.Size(216, 27);
            this.btnCameraBinding.TabIndex = 0;
            this.btnCameraBinding.Text = "Camera Binding";
            this.btnCameraBinding.UseVisualStyleBackColor = true;
            this.btnCameraBinding.Click += new System.EventHandler(this.btnIPCamPnPSetup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAnalogCam);
            this.groupBox1.Controls.Add(this.btnAddIPCamera);
            this.groupBox1.Controls.Add(this.btnAddXVRCamera);
            this.groupBox1.Location = new System.Drawing.Point(4, 542);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 53);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Camera";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnCancel.Location = new System.Drawing.Point(700, 556);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 28);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteCamera
            // 
            this.btnDeleteCamera.Location = new System.Drawing.Point(144, 361);
            this.btnDeleteCamera.Name = "btnDeleteCamera";
            this.btnDeleteCamera.Size = new System.Drawing.Size(129, 27);
            this.btnDeleteCamera.TabIndex = 39;
            this.btnDeleteCamera.Text = "Delete";
            this.btnDeleteCamera.UseVisualStyleBackColor = true;
            this.btnDeleteCamera.Click += new System.EventHandler(this.btnDeleteCamera_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Image = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.Location = new System.Drawing.Point(800, 556);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(33, 28);
            this.btnKeyboard.TabIndex = 70;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(565, 43);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(17, 39);
            this.btnNext.TabIndex = 71;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 43);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(17, 39);
            this.btnPrev.TabIndex = 72;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveGroup);
            this.groupBox3.Controls.Add(this.btnAddGroup);
            this.groupBox3.Controls.Add(this.treeViewGroup);
            this.groupBox3.Location = new System.Drawing.Point(603, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 254);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group";
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(164, 223);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(59, 23);
            this.btnRemoveGroup.TabIndex = 3;
            this.btnRemoveGroup.Text = "Remove";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(99, 223);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(59, 23);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // treeViewGroup
            // 
            this.treeViewGroup.AllowDrop = true;
            this.treeViewGroup.ImageIndex = 0;
            this.treeViewGroup.ImageList = this.imageList;
            this.treeViewGroup.Location = new System.Drawing.Point(8, 20);
            this.treeViewGroup.Name = "treeViewGroup";
            this.treeViewGroup.SelectedImageIndex = 0;
            this.treeViewGroup.Size = new System.Drawing.Size(215, 197);
            this.treeViewGroup.TabIndex = 1;
            this.treeViewGroup.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewGroup_AfterCollapse);
            this.treeViewGroup.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewGroup_BeforeExpand);
            this.treeViewGroup.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewGroup_ItemDrag);
            this.treeViewGroup.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewGroup_DragDrop);
            this.treeViewGroup.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewGroup_DragEnter);
            this.treeViewGroup.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewGroup_DragOver);
            // 
            // cameraPicker
            // 
            this.cameraPicker.CameraPerLine = 16;
            this.cameraPicker.Location = new System.Drawing.Point(33, 25);
            this.cameraPicker.Name = "cameraPicker";
            this.cameraPicker.Size = new System.Drawing.Size(526, 79);
            this.cameraPicker.TabIndex = 69;
            // 
            // FrmCameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 596);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnDeleteCamera);
            this.Controls.Add(this.btnEditCamera);
            this.Controls.Add(this.cameraPicker);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.chkCameraSettingAll);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCameraSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera Settings";
            this.Load += new System.EventHandler(this.frmCameraSetting_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.Move += new System.EventHandler(this.FrmCameraSetting_Move);
            this.grpCamera.ResumeLayout(false);
            this.grpCamera.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBright)).EndInit();
            this.mnuCameraEdit.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.CheckBox chkCameraSettingAll;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.TextBox txtCamDescription;
        private System.Windows.Forms.TextBox txtCamName;
        private System.Windows.Forms.Label lblCamModel;
		private System.Windows.Forms.Label lblCamProtocol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSaturation;
        private System.Windows.Forms.TrackBar trackSaturation;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.TextBox txtHue;
        private System.Windows.Forms.TrackBar trackHue;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.TrackBar trackContrast;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.TrackBar trackBright;
        private System.Windows.Forms.Label lblBright;
        private System.Windows.Forms.TextBox txtBright;
        private System.Windows.Forms.CheckBox chkAutoBrightControl;
        private System.Windows.Forms.CheckBox chkNightView;
		private System.Windows.Forms.ComboBox cmbDeinterlace;
		private System.Windows.Forms.CheckBox chkOriginalDisplayAspectRatio;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ContextMenuStrip mnuCameraEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuDeleteCamera;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteAllCamera;
        private System.Windows.Forms.Button btnAnalogCam;
        private System.Windows.Forms.Button btnAddXVRCamera;
		private System.Windows.Forms.Button btnAddIPCamera;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TreeView treeCamList;
		private System.Windows.Forms.Button btnCameraBinding;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lblCamAddress;
		private System.Windows.Forms.TextBox lblPort;
		private iNVMS.CustomControl.CameraPicker cameraPicker;
		private System.Windows.Forms.CheckBox chkSoftWDR;
		private System.Windows.Forms.CheckBox chkDefog;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnEditCamera;
        private System.Windows.Forms.Button btnDeleteCamera;
        private System.Windows.Forms.TextBox txtDisplayName1;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TreeView treeViewGroup;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button btnRemoveGroup;
		private System.Windows.Forms.Button btnAddGroup;
		private System.Windows.Forms.TextBox txtChannel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkEnableAudio;
		private System.Windows.Forms.CheckBox chkDisplayOn;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}
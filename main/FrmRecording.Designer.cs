namespace iNVMSMain
{
    partial class FrmRecording
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
            this.chkCamAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPostRecordTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreRecordTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioNoRecord = new System.Windows.Forms.RadioButton();
            this.radioVoiceDetectRecord = new System.Windows.Forms.RadioButton();
            this.radioSmartRecord = new System.Windows.Forms.RadioButton();
            this.radioMotionRecord = new System.Windows.Forms.RadioButton();
            this.radioKeyFrameRecord = new System.Windows.Forms.RadioButton();
            this.radioAlwaysRecord = new System.Windows.Forms.RadioButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAudioEnable = new System.Windows.Forms.CheckBox();
            this.grbMotionDetect = new System.Windows.Forms.GroupBox();
            this.btnMotionAdvanced = new System.Windows.Forms.Button();
            this.trackMotionSensitivity = new System.Windows.Forms.TrackBar();
            this.txtMotionSensitivity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grbVoiceDetect = new System.Windows.Forms.GroupBox();
            this.btnIntensityTest = new System.Windows.Forms.Button();
            this.trackVoiceIntensity = new System.Windows.Forms.TrackBar();
            this.txtIntensityTest1 = new System.Windows.Forms.TextBox();
            this.txtIntensityTest2 = new System.Windows.Forms.TextBox();
            this.txtVoiceIntensity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbQuality = new System.Windows.Forms.GroupBox();
            this.trackVideoQuality = new System.Windows.Forms.TrackBar();
            this.txtVideoQuality = new System.Windows.Forms.TextBox();
            this.grbFrameRate = new System.Windows.Forms.GroupBox();
            this.btnFrameDetail = new System.Windows.Forms.Button();
            this.trackFrameRateMin = new System.Windows.Forms.TrackBar();
            this.txtFrameRateMin = new System.Windows.Forms.TextBox();
            this.trackFrameRateMax = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFrameRateMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbVideoSize = new System.Windows.Forms.GroupBox();
            this.radioSubStream = new System.Windows.Forms.RadioButton();
            this.radioMainStream = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioCompressH265 = new System.Windows.Forms.RadioButton();
            this.radioCompressH264 = new System.Windows.Forms.RadioButton();
            this.radioCompressUseOriginal = new System.Windows.Forms.RadioButton();
            this.btnStorageOprDetail = new System.Windows.Forms.Button();
            this.chkStorageOpr = new System.Windows.Forms.CheckBox();
            this.chkVideoEncrypt = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.cameraPicker = new iNVMS.CustomControl.CameraPicker();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.scheduleCtrl = new GridCtrl.Grid();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grbMotionDetect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMotionSensitivity)).BeginInit();
            this.grbVoiceDetect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVoiceIntensity)).BeginInit();
            this.grbQuality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoQuality)).BeginInit();
            this.grbFrameRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrameRateMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrameRateMax)).BeginInit();
            this.grbVideoSize.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.cameraPicker.SuspendLayout();
            this.nvmsPlayer = new iNVMS.CustomControl.NVMSPlayer(this);
            ((System.ComponentModel.ISupportInitialize)(this.nvmsPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCamAll
            // 
            this.chkCamAll.AutoSize = true;
            this.chkCamAll.Location = new System.Drawing.Point(12, 6);
            this.chkCamAll.Name = "chkCamAll";
            this.chkCamAll.Size = new System.Drawing.Size(37, 17);
            this.chkCamAll.TabIndex = 0;
            this.chkCamAll.Text = "All";
            this.chkCamAll.UseVisualStyleBackColor = true;
            this.chkCamAll.CheckedChanged += new System.EventHandler(this.chkCamAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scheduleCtrl);
            this.groupBox2.Controls.Add(this.txtPostRecordTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPreRecordTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioNoRecord);
            this.groupBox2.Controls.Add(this.radioVoiceDetectRecord);
            this.groupBox2.Controls.Add(this.radioSmartRecord);
            this.groupBox2.Controls.Add(this.radioMotionRecord);
            this.groupBox2.Controls.Add(this.radioKeyFrameRecord);
            this.groupBox2.Controls.Add(this.radioAlwaysRecord);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnSchedule);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 203);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recording Mode";
            // 
            // txtPostRecordTime
            // 
            this.txtPostRecordTime.Location = new System.Drawing.Point(164, 177);
            this.txtPostRecordTime.Name = "txtPostRecordTime";
            this.txtPostRecordTime.Size = new System.Drawing.Size(100, 20);
            this.txtPostRecordTime.TabIndex = 5;
            this.txtPostRecordTime.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sec.";
            // 
            // txtPreRecordTime
            // 
            this.txtPreRecordTime.Location = new System.Drawing.Point(164, 154);
            this.txtPreRecordTime.Name = "txtPreRecordTime";
            this.txtPreRecordTime.Size = new System.Drawing.Size(100, 20);
            this.txtPreRecordTime.TabIndex = 5;
            this.txtPreRecordTime.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stop Record After";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sec.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Record Prior";
            // 
            // radioNoRecord
            // 
            this.radioNoRecord.AutoSize = true;
            this.radioNoRecord.Location = new System.Drawing.Point(190, 127);
            this.radioNoRecord.Name = "radioNoRecord";
            this.radioNoRecord.Size = new System.Drawing.Size(91, 17);
            this.radioNoRecord.TabIndex = 3;
            this.radioNoRecord.Text = "No Recording";
            this.radioNoRecord.UseVisualStyleBackColor = true;
            this.radioNoRecord.CheckedChanged += new System.EventHandler(this.radioNoRecord_CheckedChanged);
            // 
            // radioVoiceDetectRecord
            // 
            this.radioVoiceDetectRecord.AutoSize = true;
            this.radioVoiceDetectRecord.Location = new System.Drawing.Point(190, 104);
            this.radioVoiceDetectRecord.Name = "radioVoiceDetectRecord";
            this.radioVoiceDetectRecord.Size = new System.Drawing.Size(153, 17);
            this.radioVoiceDetectRecord.TabIndex = 3;
            this.radioVoiceDetectRecord.Text = "Voice Detection Recording";
            this.radioVoiceDetectRecord.UseVisualStyleBackColor = true;
            this.radioVoiceDetectRecord.CheckedChanged += new System.EventHandler(this.radioVoiceDetectRecord_CheckedChanged);
            // 
            // radioSmartRecord
            // 
            this.radioSmartRecord.AutoSize = true;
            this.radioSmartRecord.Location = new System.Drawing.Point(32, 127);
            this.radioSmartRecord.Name = "radioSmartRecord";
            this.radioSmartRecord.Size = new System.Drawing.Size(104, 17);
            this.radioSmartRecord.TabIndex = 3;
            this.radioSmartRecord.Text = "Smart Recording";
            this.radioSmartRecord.UseVisualStyleBackColor = true;
            this.radioSmartRecord.CheckedChanged += new System.EventHandler(this.radioSmartRecord_CheckedChanged);
            // 
            // radioMotionRecord
            // 
            this.radioMotionRecord.AutoSize = true;
            this.radioMotionRecord.Location = new System.Drawing.Point(32, 104);
            this.radioMotionRecord.Name = "radioMotionRecord";
            this.radioMotionRecord.Size = new System.Drawing.Size(109, 17);
            this.radioMotionRecord.TabIndex = 3;
            this.radioMotionRecord.Text = "Motion Recording";
            this.radioMotionRecord.UseVisualStyleBackColor = true;
            this.radioMotionRecord.CheckedChanged += new System.EventHandler(this.radioMotionRecord_CheckedChanged);
            // 
            // radioKeyFrameRecord
            // 
            this.radioKeyFrameRecord.AutoSize = true;
            this.radioKeyFrameRecord.Location = new System.Drawing.Point(190, 78);
            this.radioKeyFrameRecord.Name = "radioKeyFrameRecord";
            this.radioKeyFrameRecord.Size = new System.Drawing.Size(124, 17);
            this.radioKeyFrameRecord.TabIndex = 3;
            this.radioKeyFrameRecord.Text = "KeyFrame Recording";
            this.radioKeyFrameRecord.UseVisualStyleBackColor = true;
            this.radioKeyFrameRecord.CheckedChanged += new System.EventHandler(this.radioKeyFrameRecord_CheckedChanged);
            // 
            // radioAlwaysRecord
            // 
            this.radioAlwaysRecord.AutoSize = true;
            this.radioAlwaysRecord.Checked = true;
            this.radioAlwaysRecord.Location = new System.Drawing.Point(32, 78);
            this.radioAlwaysRecord.Name = "radioAlwaysRecord";
            this.radioAlwaysRecord.Size = new System.Drawing.Size(110, 17);
            this.radioAlwaysRecord.TabIndex = 3;
            this.radioAlwaysRecord.TabStop = true;
            this.radioAlwaysRecord.Text = "Always Recording";
            this.radioAlwaysRecord.UseVisualStyleBackColor = true;
            this.radioAlwaysRecord.CheckedChanged += new System.EventHandler(this.radioAlwaysRecord_CheckedChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(164, 127);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox4.Location = new System.Drawing.Point(164, 101);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Fuchsia;
            this.pictureBox3.Location = new System.Drawing.Point(7, 127);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Lime;
            this.pictureBox2.Location = new System.Drawing.Point(7, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Cyan;
            this.pictureBox6.Location = new System.Drawing.Point(164, 75);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Blue;
            this.pictureBox1.Location = new System.Drawing.Point(7, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(281, 31);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(60, 23);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAudioEnable);
            this.groupBox3.Location = new System.Drawing.Point(12, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 42);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio";
            // 
            // chkAudioEnable
            // 
            this.chkAudioEnable.AutoSize = true;
            this.chkAudioEnable.Checked = true;
            this.chkAudioEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAudioEnable.Enabled = false;
            this.chkAudioEnable.Location = new System.Drawing.Point(7, 19);
            this.chkAudioEnable.Name = "chkAudioEnable";
            this.chkAudioEnable.Size = new System.Drawing.Size(89, 17);
            this.chkAudioEnable.TabIndex = 0;
            this.chkAudioEnable.Text = "Enable Audio";
            this.chkAudioEnable.UseVisualStyleBackColor = true;
            // 
            // grbMotionDetect
            // 
            this.grbMotionDetect.Controls.Add(this.btnMotionAdvanced);
            this.grbMotionDetect.Controls.Add(this.trackMotionSensitivity);
            this.grbMotionDetect.Controls.Add(this.txtMotionSensitivity);
            this.grbMotionDetect.Controls.Add(this.label5);
            this.grbMotionDetect.Location = new System.Drawing.Point(12, 347);
            this.grbMotionDetect.Name = "grbMotionDetect";
            this.grbMotionDetect.Size = new System.Drawing.Size(349, 74);
            this.grbMotionDetect.TabIndex = 25;
            this.grbMotionDetect.TabStop = false;
            this.grbMotionDetect.Text = "Motion Detection";
            // 
            // btnMotionAdvanced
            // 
            this.btnMotionAdvanced.Location = new System.Drawing.Point(288, 45);
            this.btnMotionAdvanced.Name = "btnMotionAdvanced";
            this.btnMotionAdvanced.Size = new System.Drawing.Size(72, 23);
            this.btnMotionAdvanced.TabIndex = 3;
            this.btnMotionAdvanced.Text = "Advanced";
            this.btnMotionAdvanced.UseVisualStyleBackColor = true;
            this.btnMotionAdvanced.Visible = false;
            this.btnMotionAdvanced.Click += new System.EventHandler(this.btnSensitivityAdvance_Click);
            // 
            // trackMotionSensitivity
            // 
            this.trackMotionSensitivity.Location = new System.Drawing.Point(61, 25);
            this.trackMotionSensitivity.Maximum = 100;
            this.trackMotionSensitivity.Minimum = 1;
            this.trackMotionSensitivity.Name = "trackMotionSensitivity";
            this.trackMotionSensitivity.Size = new System.Drawing.Size(231, 45);
            this.trackMotionSensitivity.TabIndex = 2;
            this.trackMotionSensitivity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackMotionSensitivity.Value = 50;
            this.trackMotionSensitivity.Scroll += new System.EventHandler(this.trackSensitivity_Scroll);
            // 
            // txtMotionSensitivity
            // 
            this.txtMotionSensitivity.Location = new System.Drawing.Point(298, 26);
            this.txtMotionSensitivity.Name = "txtMotionSensitivity";
            this.txtMotionSensitivity.Size = new System.Drawing.Size(43, 20);
            this.txtMotionSensitivity.TabIndex = 1;
            this.txtMotionSensitivity.Text = "50";
            this.txtMotionSensitivity.TextChanged += new System.EventHandler(this.OnMotionSensitivityText_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sensitivity";
            // 
            // grbVoiceDetect
            // 
            this.grbVoiceDetect.Controls.Add(this.btnIntensityTest);
            this.grbVoiceDetect.Controls.Add(this.trackVoiceIntensity);
            this.grbVoiceDetect.Controls.Add(this.txtIntensityTest1);
            this.grbVoiceDetect.Controls.Add(this.txtIntensityTest2);
            this.grbVoiceDetect.Controls.Add(this.txtVoiceIntensity);
            this.grbVoiceDetect.Controls.Add(this.label6);
            this.grbVoiceDetect.Location = new System.Drawing.Point(12, 425);
            this.grbVoiceDetect.Name = "grbVoiceDetect";
            this.grbVoiceDetect.Size = new System.Drawing.Size(349, 96);
            this.grbVoiceDetect.TabIndex = 25;
            this.grbVoiceDetect.TabStop = false;
            this.grbVoiceDetect.Text = "Voice Detection";
            // 
            // btnIntensityTest
            // 
            this.btnIntensityTest.Location = new System.Drawing.Point(6, 68);
            this.btnIntensityTest.Name = "btnIntensityTest";
            this.btnIntensityTest.Size = new System.Drawing.Size(63, 23);
            this.btnIntensityTest.TabIndex = 3;
            this.btnIntensityTest.Text = "Test";
            this.btnIntensityTest.UseVisualStyleBackColor = true;
            this.btnIntensityTest.Visible = false;
            // 
            // trackVoiceIntensity
            // 
            this.trackVoiceIntensity.Location = new System.Drawing.Point(61, 37);
            this.trackVoiceIntensity.Maximum = 100;
            this.trackVoiceIntensity.Minimum = 1;
            this.trackVoiceIntensity.Name = "trackVoiceIntensity";
            this.trackVoiceIntensity.Size = new System.Drawing.Size(231, 45);
            this.trackVoiceIntensity.TabIndex = 2;
            this.trackVoiceIntensity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackVoiceIntensity.Value = 50;
            this.trackVoiceIntensity.Scroll += new System.EventHandler(this.trackIntensity_Scroll);
            // 
            // txtIntensityTest1
            // 
            this.txtIntensityTest1.Enabled = false;
            this.txtIntensityTest1.Location = new System.Drawing.Point(83, 70);
            this.txtIntensityTest1.Name = "txtIntensityTest1";
            this.txtIntensityTest1.Size = new System.Drawing.Size(198, 20);
            this.txtIntensityTest1.TabIndex = 1;
            this.txtIntensityTest1.Visible = false;
            // 
            // txtIntensityTest2
            // 
            this.txtIntensityTest2.Enabled = false;
            this.txtIntensityTest2.Location = new System.Drawing.Point(298, 67);
            this.txtIntensityTest2.Name = "txtIntensityTest2";
            this.txtIntensityTest2.Size = new System.Drawing.Size(43, 20);
            this.txtIntensityTest2.TabIndex = 1;
            this.txtIntensityTest2.Visible = false;
            // 
            // txtVoiceIntensity
            // 
            this.txtVoiceIntensity.Location = new System.Drawing.Point(298, 35);
            this.txtVoiceIntensity.Name = "txtVoiceIntensity";
            this.txtVoiceIntensity.Size = new System.Drawing.Size(43, 20);
            this.txtVoiceIntensity.TabIndex = 1;
            this.txtVoiceIntensity.Text = "50";
            this.txtVoiceIntensity.TextChanged += new System.EventHandler(this.OnVoiceIntensityText_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Intensity";
            // 
            // grbQuality
            // 
            this.grbQuality.Controls.Add(this.trackVideoQuality);
            this.grbQuality.Controls.Add(this.txtVideoQuality);
            this.grbQuality.Location = new System.Drawing.Point(372, 347);
            this.grbQuality.Name = "grbQuality";
            this.grbQuality.Size = new System.Drawing.Size(348, 74);
            this.grbQuality.TabIndex = 26;
            this.grbQuality.TabStop = false;
            this.grbQuality.Text = "Quality";
            // 
            // trackVideoQuality
            // 
            this.trackVideoQuality.Location = new System.Drawing.Point(6, 25);
            this.trackVideoQuality.Maximum = 100;
            this.trackVideoQuality.Name = "trackVideoQuality";
            this.trackVideoQuality.Size = new System.Drawing.Size(267, 45);
            this.trackVideoQuality.TabIndex = 2;
            this.trackVideoQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackVideoQuality.Value = 50;
            this.trackVideoQuality.Scroll += new System.EventHandler(this.trackQuality_Scroll);
            // 
            // txtVideoQuality
            // 
            this.txtVideoQuality.Location = new System.Drawing.Point(280, 25);
            this.txtVideoQuality.Name = "txtVideoQuality";
            this.txtVideoQuality.Size = new System.Drawing.Size(53, 20);
            this.txtVideoQuality.TabIndex = 1;
            this.txtVideoQuality.Text = "50";
            this.txtVideoQuality.TextChanged += new System.EventHandler(this.OnVideoQualityText_Changed);
            // 
            // grbFrameRate
            // 
            this.grbFrameRate.Controls.Add(this.btnFrameDetail);
            this.grbFrameRate.Controls.Add(this.trackFrameRateMin);
            this.grbFrameRate.Controls.Add(this.txtFrameRateMin);
            this.grbFrameRate.Controls.Add(this.trackFrameRateMax);
            this.grbFrameRate.Controls.Add(this.label8);
            this.grbFrameRate.Controls.Add(this.txtFrameRateMax);
            this.grbFrameRate.Controls.Add(this.label7);
            this.grbFrameRate.Location = new System.Drawing.Point(372, 425);
            this.grbFrameRate.Name = "grbFrameRate";
            this.grbFrameRate.Size = new System.Drawing.Size(348, 96);
            this.grbFrameRate.TabIndex = 27;
            this.grbFrameRate.TabStop = false;
            this.grbFrameRate.Text = "Frame Rate";
            // 
            // btnFrameDetail
            // 
            this.btnFrameDetail.Location = new System.Drawing.Point(279, 82);
            this.btnFrameDetail.Name = "btnFrameDetail";
            this.btnFrameDetail.Size = new System.Drawing.Size(63, 23);
            this.btnFrameDetail.TabIndex = 3;
            this.btnFrameDetail.Text = "Detail";
            this.btnFrameDetail.UseVisualStyleBackColor = true;
            this.btnFrameDetail.Visible = false;
            // 
            // trackFrameRateMin
            // 
            this.trackFrameRateMin.Location = new System.Drawing.Point(61, 47);
            this.trackFrameRateMin.Maximum = 30;
            this.trackFrameRateMin.Name = "trackFrameRateMin";
            this.trackFrameRateMin.Size = new System.Drawing.Size(212, 45);
            this.trackFrameRateMin.TabIndex = 2;
            this.trackFrameRateMin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackFrameRateMin.Value = 1;
            this.trackFrameRateMin.Scroll += new System.EventHandler(this.trackFrameMin_Scroll);
            // 
            // txtFrameRateMin
            // 
            this.txtFrameRateMin.Location = new System.Drawing.Point(280, 47);
            this.txtFrameRateMin.Name = "txtFrameRateMin";
            this.txtFrameRateMin.Size = new System.Drawing.Size(53, 20);
            this.txtFrameRateMin.TabIndex = 1;
            this.txtFrameRateMin.Text = "1";
            this.txtFrameRateMin.TextChanged += new System.EventHandler(this.OnFrameRateMinText_Changed);
            // 
            // trackFrameRateMax
            // 
            this.trackFrameRateMax.Location = new System.Drawing.Point(61, 16);
            this.trackFrameRateMax.Maximum = 30;
            this.trackFrameRateMax.Name = "trackFrameRateMax";
            this.trackFrameRateMax.Size = new System.Drawing.Size(212, 45);
            this.trackFrameRateMax.TabIndex = 2;
            this.trackFrameRateMax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackFrameRateMax.Value = 30;
            this.trackFrameRateMax.Scroll += new System.EventHandler(this.trackFrameMax_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Min";
            // 
            // txtFrameRateMax
            // 
            this.txtFrameRateMax.Location = new System.Drawing.Point(280, 12);
            this.txtFrameRateMax.Name = "txtFrameRateMax";
            this.txtFrameRateMax.Size = new System.Drawing.Size(53, 20);
            this.txtFrameRateMax.TabIndex = 1;
            this.txtFrameRateMax.Text = "30";
            this.txtFrameRateMax.TextChanged += new System.EventHandler(this.OnFrameRateMaxText_Changed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Max";
            // 
            // grbVideoSize
            // 
            this.grbVideoSize.Controls.Add(this.radioSubStream);
            this.grbVideoSize.Controls.Add(this.radioMainStream);
            this.grbVideoSize.Location = new System.Drawing.Point(13, 527);
            this.grbVideoSize.Name = "grbVideoSize";
            this.grbVideoSize.Size = new System.Drawing.Size(348, 42);
            this.grbVideoSize.TabIndex = 28;
            this.grbVideoSize.TabStop = false;
            this.grbVideoSize.Text = "Stream";
            // 
            // radioSubStream
            // 
            this.radioSubStream.AutoSize = true;
            this.radioSubStream.Location = new System.Drawing.Point(196, 18);
            this.radioSubStream.Name = "radioSubStream";
            this.radioSubStream.Size = new System.Drawing.Size(77, 17);
            this.radioSubStream.TabIndex = 1;
            this.radioSubStream.Text = "SubStream";
            this.radioSubStream.UseVisualStyleBackColor = true;
            this.radioSubStream.CheckedChanged += new System.EventHandler(this.radioSubStream_CheckedChanged);
            // 
            // radioMainStream
            // 
            this.radioMainStream.AutoSize = true;
            this.radioMainStream.Checked = true;
            this.radioMainStream.Location = new System.Drawing.Point(30, 18);
            this.radioMainStream.Name = "radioMainStream";
            this.radioMainStream.Size = new System.Drawing.Size(81, 17);
            this.radioMainStream.TabIndex = 0;
            this.radioMainStream.TabStop = true;
            this.radioMainStream.Text = "MainStream";
            this.radioMainStream.UseVisualStyleBackColor = true;
            this.radioMainStream.CheckedChanged += new System.EventHandler(this.radioMainStream_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioCompressH265);
            this.groupBox7.Controls.Add(this.radioCompressH264);
            this.groupBox7.Controls.Add(this.radioCompressUseOriginal);
            this.groupBox7.Location = new System.Drawing.Point(330, -54);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(349, 58);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Compression Type";
            this.groupBox7.Visible = false;
            // 
            // radioCompressH265
            // 
            this.radioCompressH265.AutoSize = true;
            this.radioCompressH265.Location = new System.Drawing.Point(263, 25);
            this.radioCompressH265.Name = "radioCompressH265";
            this.radioCompressH265.Size = new System.Drawing.Size(51, 17);
            this.radioCompressH265.TabIndex = 3;
            this.radioCompressH265.Text = "H265";
            this.radioCompressH265.UseVisualStyleBackColor = true;
            this.radioCompressH265.Visible = false;
            // 
            // radioCompressH264
            // 
            this.radioCompressH264.AutoSize = true;
            this.radioCompressH264.Location = new System.Drawing.Point(136, 25);
            this.radioCompressH264.Name = "radioCompressH264";
            this.radioCompressH264.Size = new System.Drawing.Size(51, 17);
            this.radioCompressH264.TabIndex = 0;
            this.radioCompressH264.Text = "H264";
            this.radioCompressH264.UseVisualStyleBackColor = true;
            this.radioCompressH264.Visible = false;
            // 
            // radioCompressUseOriginal
            // 
            this.radioCompressUseOriginal.AutoSize = true;
            this.radioCompressUseOriginal.Checked = true;
            this.radioCompressUseOriginal.Location = new System.Drawing.Point(23, 25);
            this.radioCompressUseOriginal.Name = "radioCompressUseOriginal";
            this.radioCompressUseOriginal.Size = new System.Drawing.Size(60, 17);
            this.radioCompressUseOriginal.TabIndex = 0;
            this.radioCompressUseOriginal.TabStop = true;
            this.radioCompressUseOriginal.Text = "Original";
            this.radioCompressUseOriginal.UseVisualStyleBackColor = true;
            this.radioCompressUseOriginal.Visible = false;
            // 
            // btnStorageOprDetail
            // 
            this.btnStorageOprDetail.Enabled = false;
            this.btnStorageOprDetail.Location = new System.Drawing.Point(544, 14);
            this.btnStorageOprDetail.Name = "btnStorageOprDetail";
            this.btnStorageOprDetail.Size = new System.Drawing.Size(87, 23);
            this.btnStorageOprDetail.TabIndex = 2;
            this.btnStorageOprDetail.Text = "Detail";
            this.btnStorageOprDetail.UseVisualStyleBackColor = true;
            this.btnStorageOprDetail.Visible = false;
            // 
            // chkStorageOpr
            // 
            this.chkStorageOpr.AutoSize = true;
            this.chkStorageOpr.Enabled = false;
            this.chkStorageOpr.Location = new System.Drawing.Point(343, 20);
            this.chkStorageOpr.Name = "chkStorageOpr";
            this.chkStorageOpr.Size = new System.Drawing.Size(143, 17);
            this.chkStorageOpr.TabIndex = 1;
            this.chkStorageOpr.Text = "Enable Storage Operator";
            this.chkStorageOpr.UseVisualStyleBackColor = true;
            this.chkStorageOpr.Visible = false;
            this.chkStorageOpr.CheckedChanged += new System.EventHandler(this.chkStorageOpr_CheckedChanged);
            // 
            // chkVideoEncrypt
            // 
            this.chkVideoEncrypt.AutoSize = true;
            this.chkVideoEncrypt.Enabled = false;
            this.chkVideoEncrypt.Location = new System.Drawing.Point(343, -1);
            this.chkVideoEncrypt.Name = "chkVideoEncrypt";
            this.chkVideoEncrypt.Size = new System.Drawing.Size(106, 17);
            this.chkVideoEncrypt.TabIndex = 1;
            this.chkVideoEncrypt.Text = "Video Encryption";
            this.chkVideoEncrypt.UseVisualStyleBackColor = true;
            this.chkVideoEncrypt.Visible = false;
            this.chkVideoEncrypt.CheckedChanged += new System.EventHandler(this.chkVideoEncrypt_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(514, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(408, 540);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(620, 540);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(100, 27);
            this.btnDefault.TabIndex = 33;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // cameraPicker
            // 
            this.cameraPicker.CameraPerLine = 16;
            this.cameraPicker.Controls.Add(this.btnStorageOprDetail);
            this.cameraPicker.Controls.Add(this.groupBox7);
            this.cameraPicker.Controls.Add(this.chkStorageOpr);
            this.cameraPicker.Controls.Add(this.chkVideoEncrypt);
            this.cameraPicker.Location = new System.Drawing.Point(94, 12);
            this.cameraPicker.Name = "cameraPicker";
            this.cameraPicker.Size = new System.Drawing.Size(528, 66);
            this.cameraPicker.TabIndex = 36;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeyboard.Location = new System.Drawing.Point(372, 540);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(30, 27);
            this.btnKeyboard.TabIndex = 37;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(628, 26);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(19, 41);
            this.btnNext.TabIndex = 38;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(69, 26);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(19, 41);
            this.btnPrev.TabIndex = 39;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // nvmsPlayer
            // 
            this.nvmsPlayer.Active = false;
            this.nvmsPlayer.AllowDrop = true;
            this.nvmsPlayer.BackColor = System.Drawing.Color.Black;
            this.nvmsPlayer.BindMode = false;
            this.nvmsPlayer.ClipRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.nvmsPlayer.DisplayInLive = false;
            this.nvmsPlayer.DragState = iNVMS.CustomControl.DragStateEnum.Move;
            this.nvmsPlayer.EnableAudio = false;
            this.nvmsPlayer.Index = 0;
            this.nvmsPlayer.IsDestroyed = false;
            this.nvmsPlayer.IsProcessing = false;
            this.nvmsPlayer.Location = new System.Drawing.Point(372, 104);
            this.nvmsPlayer.Name = "nvmsPlayer";
            this.nvmsPlayer.Owner = this;
            this.nvmsPlayer.PlayerState = iNVMS.CustomControl.PlayerStateEnum.CONNECTION_NONE;
            this.nvmsPlayer.PlayerType = iNVMS.CustomControl.PlayerTypeEnum.GroupPlayer;
            this.nvmsPlayer.PreviewMode = false;
            this.nvmsPlayer.Size = new System.Drawing.Size(348, 240);
            this.nvmsPlayer.TabIndex = 35;
            this.nvmsPlayer.TabStop = false;
            this.nvmsPlayer.ZoomOut = false;
            this.nvmsPlayer.ZoomRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // scheduleCtrl
            // 
            this.scheduleCtrl.AllowDrop = true;
            this.scheduleCtrl.BackColor = System.Drawing.SystemColors.Window;
            this.scheduleCtrl.CellColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red};
            this.scheduleCtrl.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.scheduleCtrl.GridOpacity = 100;
            this.scheduleCtrl.Location = new System.Drawing.Point(13, 19);
            this.scheduleCtrl.LockUpdates = false;
            this.scheduleCtrl.Name = "scheduleCtrl";
            this.scheduleCtrl.SelectedValue = 0;
            this.scheduleCtrl.Size = new System.Drawing.Size(260, 46);
            this.scheduleCtrl.TabIndex = 6;
            this.scheduleCtrl.Load += new System.EventHandler(this.OnScheduleView_Load);
            // 
            // FrmRecording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 582);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.cameraPicker);
            this.Controls.Add(this.nvmsPlayer);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.grbVideoSize);
            this.Controls.Add(this.grbFrameRate);
            this.Controls.Add(this.grbQuality);
            this.Controls.Add(this.grbVoiceDetect);
            this.Controls.Add(this.grbMotionDetect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkCamAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRecording";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recording Setting";
            this.Shown += new System.EventHandler(this.FrmRecording_Shown);
            this.Move += new System.EventHandler(this.FrmRecording_Move);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbMotionDetect.ResumeLayout(false);
            this.grbMotionDetect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMotionSensitivity)).EndInit();
            this.grbVoiceDetect.ResumeLayout(false);
            this.grbVoiceDetect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVoiceIntensity)).EndInit();
            this.grbQuality.ResumeLayout(false);
            this.grbQuality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoQuality)).EndInit();
            this.grbFrameRate.ResumeLayout(false);
            this.grbFrameRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrameRateMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrameRateMax)).EndInit();
            this.grbVideoSize.ResumeLayout(false);
            this.grbVideoSize.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.cameraPicker.ResumeLayout(false);
            this.cameraPicker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvmsPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.CheckBox chkCamAll;
        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.RadioButton radioAlwaysRecord;
        private System.Windows.Forms.RadioButton radioNoRecord;
        private System.Windows.Forms.RadioButton radioVoiceDetectRecord;
        private System.Windows.Forms.RadioButton radioSmartRecord;
        private System.Windows.Forms.RadioButton radioMotionRecord;
        private System.Windows.Forms.RadioButton radioKeyFrameRecord;
        private System.Windows.Forms.TextBox txtPostRecordTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreRecordTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAudioEnable;
        private System.Windows.Forms.GroupBox grbMotionDetect;
        private System.Windows.Forms.Button btnMotionAdvanced;
        private System.Windows.Forms.TrackBar trackMotionSensitivity;
        private System.Windows.Forms.TextBox txtMotionSensitivity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbVoiceDetect;
        private System.Windows.Forms.Button btnIntensityTest;
        private System.Windows.Forms.TrackBar trackVoiceIntensity;
        private System.Windows.Forms.TextBox txtVoiceIntensity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIntensityTest1;
        private System.Windows.Forms.TextBox txtIntensityTest2;
        private System.Windows.Forms.GroupBox grbQuality;
        private System.Windows.Forms.TrackBar trackVideoQuality;
        private System.Windows.Forms.TextBox txtVideoQuality;
        private System.Windows.Forms.GroupBox grbFrameRate;
        private System.Windows.Forms.Button btnFrameDetail;
        private System.Windows.Forms.TrackBar trackFrameRateMax;
        private System.Windows.Forms.TextBox txtFrameRateMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackFrameRateMin;
        private System.Windows.Forms.TextBox txtFrameRateMin;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox grbVideoSize;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioCompressH264;
        private System.Windows.Forms.RadioButton radioCompressUseOriginal;
        private System.Windows.Forms.CheckBox chkStorageOpr;
        private System.Windows.Forms.CheckBox chkVideoEncrypt;
		private System.Windows.Forms.Button btnStorageOprDetail;
		private iNVMS.CustomControl.NVMSPlayer nvmsPlayer;
		private iNVMS.CustomControl.CameraPicker cameraPicker;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RadioButton radioCompressH265;
		private System.Windows.Forms.RadioButton radioSubStream;
		private System.Windows.Forms.RadioButton radioMainStream;
        private System.Windows.Forms.Button btnDefault;
        private GridCtrl.Grid scheduleCtrl;
        private System.Windows.Forms.Button btnKeyboard;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
    }
}
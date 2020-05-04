namespace iNVMSMain
{
    partial class FrmRecordingSchedule
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
            this.tabRecordMode = new System.Windows.Forms.TabControl();
            this.pageWeekly = new System.Windows.Forms.TabPage();
            this.gridWeekSchedule = new GridCtrl.Grid();
            this.radioWeekNoRecord = new System.Windows.Forms.RadioButton();
            this.radioWeekVoiceRecord = new System.Windows.Forms.RadioButton();
            this.radioWeekSmartRecord = new System.Windows.Forms.RadioButton();
            this.radioWeekMotionRecord = new System.Windows.Forms.RadioButton();
            this.radioWeekKeyFrameRecord = new System.Windows.Forms.RadioButton();
            this.radioWeekAlwaysRecord = new System.Windows.Forms.RadioButton();
            this.picWeekNoRecord = new System.Windows.Forms.PictureBox();
            this.picWeekVoiceDetectRecord = new System.Windows.Forms.PictureBox();
            this.picWeekSmarRecord = new System.Windows.Forms.PictureBox();
            this.picWeekMotionRecord = new System.Windows.Forms.PictureBox();
            this.picWeekKeyFrameRecord = new System.Windows.Forms.PictureBox();
            this.picWeekAlwaysRecord = new System.Windows.Forms.PictureBox();
            this.pageDay = new System.Windows.Forms.TabPage();
            this.gridDaySchedule = new GridCtrl.Grid();
            this.radioDayNoRecording = new System.Windows.Forms.RadioButton();
            this.radioDayVoiceRecording = new System.Windows.Forms.RadioButton();
            this.radioDaySmartRecording = new System.Windows.Forms.RadioButton();
            this.radioDayMotionRecording = new System.Windows.Forms.RadioButton();
            this.radioDayKeyFrameRecording = new System.Windows.Forms.RadioButton();
            this.radioDayAlwaysRecording = new System.Windows.Forms.RadioButton();
            this.picDayNoRecord = new System.Windows.Forms.PictureBox();
            this.picDayVoiceRecord = new System.Windows.Forms.PictureBox();
            this.picDaySmartRecord = new System.Windows.Forms.PictureBox();
            this.picDayMotionRecord = new System.Windows.Forms.PictureBox();
            this.picDayKeyframeRecord = new System.Windows.Forms.PictureBox();
            this.picDayAlwaysRecord = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabRecordMode.SuspendLayout();
            this.pageWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekNoRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekVoiceDetectRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekSmarRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekMotionRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekKeyFrameRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekAlwaysRecord)).BeginInit();
            this.pageDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDayNoRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayVoiceRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDaySmartRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayMotionRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayKeyframeRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayAlwaysRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRecordMode
            // 
            this.tabRecordMode.Controls.Add(this.pageWeekly);
            this.tabRecordMode.Controls.Add(this.pageDay);
            this.tabRecordMode.Location = new System.Drawing.Point(12, 21);
            this.tabRecordMode.Name = "tabRecordMode";
            this.tabRecordMode.SelectedIndex = 0;
            this.tabRecordMode.Size = new System.Drawing.Size(560, 386);
            this.tabRecordMode.TabIndex = 0;
            // 
            // pageWeekly
            // 
            this.pageWeekly.BackColor = System.Drawing.Color.Gainsboro;
            this.pageWeekly.Controls.Add(this.gridWeekSchedule);
            this.pageWeekly.Controls.Add(this.radioWeekNoRecord);
            this.pageWeekly.Controls.Add(this.radioWeekVoiceRecord);
            this.pageWeekly.Controls.Add(this.radioWeekSmartRecord);
            this.pageWeekly.Controls.Add(this.radioWeekMotionRecord);
            this.pageWeekly.Controls.Add(this.radioWeekKeyFrameRecord);
            this.pageWeekly.Controls.Add(this.radioWeekAlwaysRecord);
            this.pageWeekly.Controls.Add(this.picWeekNoRecord);
            this.pageWeekly.Controls.Add(this.picWeekVoiceDetectRecord);
            this.pageWeekly.Controls.Add(this.picWeekSmarRecord);
            this.pageWeekly.Controls.Add(this.picWeekMotionRecord);
            this.pageWeekly.Controls.Add(this.picWeekKeyFrameRecord);
            this.pageWeekly.Controls.Add(this.picWeekAlwaysRecord);
            this.pageWeekly.Location = new System.Drawing.Point(4, 22);
            this.pageWeekly.Name = "pageWeekly";
            this.pageWeekly.Padding = new System.Windows.Forms.Padding(3);
            this.pageWeekly.Size = new System.Drawing.Size(552, 360);
            this.pageWeekly.TabIndex = 0;
            this.pageWeekly.Text = "Weekly";
            // 
            // gridWeekSchedule
            // 
            this.gridWeekSchedule.AllowDrop = true;
            this.gridWeekSchedule.BackColor = System.Drawing.SystemColors.Window;
            this.gridWeekSchedule.CellColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red};
            this.gridWeekSchedule.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.gridWeekSchedule.GridOpacity = 100;
            this.gridWeekSchedule.Location = new System.Drawing.Point(6, 118);
            this.gridWeekSchedule.LockUpdates = false;
            this.gridWeekSchedule.Name = "gridWeekSchedule";
            this.gridWeekSchedule.SelectedValue = 0;
            this.gridWeekSchedule.Size = new System.Drawing.Size(540, 236);
            this.gridWeekSchedule.TabIndex = 16;
            this.gridWeekSchedule.Load += new System.EventHandler(this.OnScheduleCtrl_Load);
            // 
            // radioWeekNoRecord
            // 
            this.radioWeekNoRecord.AutoSize = true;
            this.radioWeekNoRecord.Location = new System.Drawing.Point(304, 76);
            this.radioWeekNoRecord.Name = "radioWeekNoRecord";
            this.radioWeekNoRecord.Size = new System.Drawing.Size(91, 17);
            this.radioWeekNoRecord.TabIndex = 10;
            this.radioWeekNoRecord.TabStop = true;
            this.radioWeekNoRecord.Text = "No Recording";
            this.radioWeekNoRecord.UseVisualStyleBackColor = true;
            this.radioWeekNoRecord.CheckedChanged += new System.EventHandler(this.radioWeekNoRecord_CheckedChanged);
            // 
            // radioWeekVoiceRecord
            // 
            this.radioWeekVoiceRecord.AutoSize = true;
            this.radioWeekVoiceRecord.Location = new System.Drawing.Point(304, 27);
            this.radioWeekVoiceRecord.Name = "radioWeekVoiceRecord";
            this.radioWeekVoiceRecord.Size = new System.Drawing.Size(153, 17);
            this.radioWeekVoiceRecord.TabIndex = 12;
            this.radioWeekVoiceRecord.TabStop = true;
            this.radioWeekVoiceRecord.Text = "Voice Detection Recording";
            this.radioWeekVoiceRecord.UseVisualStyleBackColor = true;
            this.radioWeekVoiceRecord.CheckedChanged += new System.EventHandler(this.radioWeekVoiceRecord_CheckedChanged);
            // 
            // radioWeekSmartRecord
            // 
            this.radioWeekSmartRecord.AutoSize = true;
            this.radioWeekSmartRecord.Location = new System.Drawing.Point(146, 76);
            this.radioWeekSmartRecord.Name = "radioWeekSmartRecord";
            this.radioWeekSmartRecord.Size = new System.Drawing.Size(104, 17);
            this.radioWeekSmartRecord.TabIndex = 11;
            this.radioWeekSmartRecord.TabStop = true;
            this.radioWeekSmartRecord.Text = "Smart Recording";
            this.radioWeekSmartRecord.UseVisualStyleBackColor = true;
            this.radioWeekSmartRecord.CheckedChanged += new System.EventHandler(this.radioWeekSmartRecord_CheckedChanged);
            // 
            // radioWeekMotionRecord
            // 
            this.radioWeekMotionRecord.AutoSize = true;
            this.radioWeekMotionRecord.Location = new System.Drawing.Point(146, 53);
            this.radioWeekMotionRecord.Name = "radioWeekMotionRecord";
            this.radioWeekMotionRecord.Size = new System.Drawing.Size(109, 17);
            this.radioWeekMotionRecord.TabIndex = 13;
            this.radioWeekMotionRecord.TabStop = true;
            this.radioWeekMotionRecord.Text = "Motion Recording";
            this.radioWeekMotionRecord.UseVisualStyleBackColor = true;
            this.radioWeekMotionRecord.CheckedChanged += new System.EventHandler(this.radioWeekMotionRecord_CheckedChanged);
            // 
            // radioWeekKeyFrameRecord
            // 
            this.radioWeekKeyFrameRecord.AutoSize = true;
            this.radioWeekKeyFrameRecord.Location = new System.Drawing.Point(304, 53);
            this.radioWeekKeyFrameRecord.Name = "radioWeekKeyFrameRecord";
            this.radioWeekKeyFrameRecord.Size = new System.Drawing.Size(124, 17);
            this.radioWeekKeyFrameRecord.TabIndex = 15;
            this.radioWeekKeyFrameRecord.TabStop = true;
            this.radioWeekKeyFrameRecord.Text = "KeyFrame Recording";
            this.radioWeekKeyFrameRecord.UseVisualStyleBackColor = true;
            this.radioWeekKeyFrameRecord.CheckedChanged += new System.EventHandler(this.radioWeekKeyFrameRecord_CheckedChanged);
            // 
            // radioWeekAlwaysRecord
            // 
            this.radioWeekAlwaysRecord.AutoSize = true;
            this.radioWeekAlwaysRecord.Location = new System.Drawing.Point(146, 27);
            this.radioWeekAlwaysRecord.Name = "radioWeekAlwaysRecord";
            this.radioWeekAlwaysRecord.Size = new System.Drawing.Size(110, 17);
            this.radioWeekAlwaysRecord.TabIndex = 14;
            this.radioWeekAlwaysRecord.TabStop = true;
            this.radioWeekAlwaysRecord.Text = "Always Recording";
            this.radioWeekAlwaysRecord.UseVisualStyleBackColor = true;
            this.radioWeekAlwaysRecord.CheckedChanged += new System.EventHandler(this.radioWeekAlwaysRecord_CheckedChanged);
            // 
            // picWeekNoRecord
            // 
            this.picWeekNoRecord.BackColor = System.Drawing.Color.White;
            this.picWeekNoRecord.Location = new System.Drawing.Point(278, 76);
            this.picWeekNoRecord.Name = "picWeekNoRecord";
            this.picWeekNoRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekNoRecord.TabIndex = 6;
            this.picWeekNoRecord.TabStop = false;
            // 
            // picWeekVoiceDetectRecord
            // 
            this.picWeekVoiceDetectRecord.BackColor = System.Drawing.Color.Yellow;
            this.picWeekVoiceDetectRecord.Location = new System.Drawing.Point(278, 24);
            this.picWeekVoiceDetectRecord.Name = "picWeekVoiceDetectRecord";
            this.picWeekVoiceDetectRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekVoiceDetectRecord.TabIndex = 5;
            this.picWeekVoiceDetectRecord.TabStop = false;
            // 
            // picWeekSmarRecord
            // 
            this.picWeekSmarRecord.BackColor = System.Drawing.Color.Fuchsia;
            this.picWeekSmarRecord.Location = new System.Drawing.Point(121, 76);
            this.picWeekSmarRecord.Name = "picWeekSmarRecord";
            this.picWeekSmarRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekSmarRecord.TabIndex = 4;
            this.picWeekSmarRecord.TabStop = false;
            // 
            // picWeekMotionRecord
            // 
            this.picWeekMotionRecord.BackColor = System.Drawing.Color.Lime;
            this.picWeekMotionRecord.Location = new System.Drawing.Point(121, 50);
            this.picWeekMotionRecord.Name = "picWeekMotionRecord";
            this.picWeekMotionRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekMotionRecord.TabIndex = 7;
            this.picWeekMotionRecord.TabStop = false;
            // 
            // picWeekKeyFrameRecord
            // 
            this.picWeekKeyFrameRecord.BackColor = System.Drawing.Color.Cyan;
            this.picWeekKeyFrameRecord.Location = new System.Drawing.Point(278, 50);
            this.picWeekKeyFrameRecord.Name = "picWeekKeyFrameRecord";
            this.picWeekKeyFrameRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekKeyFrameRecord.TabIndex = 9;
            this.picWeekKeyFrameRecord.TabStop = false;
            // 
            // picWeekAlwaysRecord
            // 
            this.picWeekAlwaysRecord.BackColor = System.Drawing.Color.Blue;
            this.picWeekAlwaysRecord.Location = new System.Drawing.Point(121, 24);
            this.picWeekAlwaysRecord.Name = "picWeekAlwaysRecord";
            this.picWeekAlwaysRecord.Size = new System.Drawing.Size(20, 20);
            this.picWeekAlwaysRecord.TabIndex = 8;
            this.picWeekAlwaysRecord.TabStop = false;
            // 
            // pageDay
            // 
            this.pageDay.BackColor = System.Drawing.Color.Gainsboro;
            this.pageDay.Controls.Add(this.gridDaySchedule);
            this.pageDay.Controls.Add(this.radioDayNoRecording);
            this.pageDay.Controls.Add(this.radioDayVoiceRecording);
            this.pageDay.Controls.Add(this.radioDaySmartRecording);
            this.pageDay.Controls.Add(this.radioDayMotionRecording);
            this.pageDay.Controls.Add(this.radioDayKeyFrameRecording);
            this.pageDay.Controls.Add(this.radioDayAlwaysRecording);
            this.pageDay.Controls.Add(this.picDayNoRecord);
            this.pageDay.Controls.Add(this.picDayVoiceRecord);
            this.pageDay.Controls.Add(this.picDaySmartRecord);
            this.pageDay.Controls.Add(this.picDayMotionRecord);
            this.pageDay.Controls.Add(this.picDayKeyframeRecord);
            this.pageDay.Controls.Add(this.picDayAlwaysRecord);
            this.pageDay.Location = new System.Drawing.Point(4, 22);
            this.pageDay.Name = "pageDay";
            this.pageDay.Padding = new System.Windows.Forms.Padding(3);
            this.pageDay.Size = new System.Drawing.Size(552, 360);
            this.pageDay.TabIndex = 1;
            this.pageDay.Text = "Day";
            // 
            // gridDaySchedule
            // 
            this.gridDaySchedule.AllowDrop = true;
            this.gridDaySchedule.BackColor = System.Drawing.SystemColors.Window;
            this.gridDaySchedule.CellColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red};
            this.gridDaySchedule.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.gridDaySchedule.GridOpacity = 100;
            this.gridDaySchedule.Location = new System.Drawing.Point(11, 123);
            this.gridDaySchedule.LockUpdates = false;
            this.gridDaySchedule.Name = "gridDaySchedule";
            this.gridDaySchedule.SelectedValue = 0;
            this.gridDaySchedule.Size = new System.Drawing.Size(532, 49);
            this.gridDaySchedule.TabIndex = 29;
            this.gridDaySchedule.Load += new System.EventHandler(this.DayScheduleCtrl_Load);
            // 
            // radioDayNoRecording
            // 
            this.radioDayNoRecording.AutoSize = true;
            this.radioDayNoRecording.Location = new System.Drawing.Point(304, 76);
            this.radioDayNoRecording.Name = "radioDayNoRecording";
            this.radioDayNoRecording.Size = new System.Drawing.Size(91, 17);
            this.radioDayNoRecording.TabIndex = 23;
            this.radioDayNoRecording.TabStop = true;
            this.radioDayNoRecording.Text = "No Recording";
            this.radioDayNoRecording.UseVisualStyleBackColor = true;
            this.radioDayNoRecording.CheckedChanged += new System.EventHandler(this.radioDayNoRecording_CheckedChanged);
            // 
            // radioDayVoiceRecording
            // 
            this.radioDayVoiceRecording.AutoSize = true;
            this.radioDayVoiceRecording.Enabled = false;
            this.radioDayVoiceRecording.Location = new System.Drawing.Point(304, 27);
            this.radioDayVoiceRecording.Name = "radioDayVoiceRecording";
            this.radioDayVoiceRecording.Size = new System.Drawing.Size(153, 17);
            this.radioDayVoiceRecording.TabIndex = 25;
            this.radioDayVoiceRecording.TabStop = true;
            this.radioDayVoiceRecording.Text = "Voice Detection Recording";
            this.radioDayVoiceRecording.UseVisualStyleBackColor = true;
            this.radioDayVoiceRecording.CheckedChanged += new System.EventHandler(this.radioDayVoiceRecording_CheckedChanged);
            // 
            // radioDaySmartRecording
            // 
            this.radioDaySmartRecording.AutoSize = true;
            this.radioDaySmartRecording.Enabled = false;
            this.radioDaySmartRecording.Location = new System.Drawing.Point(146, 76);
            this.radioDaySmartRecording.Name = "radioDaySmartRecording";
            this.radioDaySmartRecording.Size = new System.Drawing.Size(104, 17);
            this.radioDaySmartRecording.TabIndex = 24;
            this.radioDaySmartRecording.TabStop = true;
            this.radioDaySmartRecording.Text = "Smart Recording";
            this.radioDaySmartRecording.UseVisualStyleBackColor = true;
            this.radioDaySmartRecording.CheckedChanged += new System.EventHandler(this.radioDaySmartRecording_CheckedChanged);
            // 
            // radioDayMotionRecording
            // 
            this.radioDayMotionRecording.AutoSize = true;
            this.radioDayMotionRecording.Location = new System.Drawing.Point(146, 53);
            this.radioDayMotionRecording.Name = "radioDayMotionRecording";
            this.radioDayMotionRecording.Size = new System.Drawing.Size(109, 17);
            this.radioDayMotionRecording.TabIndex = 26;
            this.radioDayMotionRecording.TabStop = true;
            this.radioDayMotionRecording.Text = "Motion Recording";
            this.radioDayMotionRecording.UseVisualStyleBackColor = true;
            this.radioDayMotionRecording.CheckedChanged += new System.EventHandler(this.radioDayMotionRecording_CheckedChanged);
            // 
            // radioDayKeyFrameRecording
            // 
            this.radioDayKeyFrameRecording.AutoSize = true;
            this.radioDayKeyFrameRecording.Location = new System.Drawing.Point(304, 53);
            this.radioDayKeyFrameRecording.Name = "radioDayKeyFrameRecording";
            this.radioDayKeyFrameRecording.Size = new System.Drawing.Size(124, 17);
            this.radioDayKeyFrameRecording.TabIndex = 28;
            this.radioDayKeyFrameRecording.TabStop = true;
            this.radioDayKeyFrameRecording.Text = "KeyFrame Recording";
            this.radioDayKeyFrameRecording.UseVisualStyleBackColor = true;
            this.radioDayKeyFrameRecording.CheckedChanged += new System.EventHandler(this.radioDayKeyFrameRecording_CheckedChanged);
            // 
            // radioDayAlwaysRecording
            // 
            this.radioDayAlwaysRecording.AutoSize = true;
            this.radioDayAlwaysRecording.Location = new System.Drawing.Point(146, 27);
            this.radioDayAlwaysRecording.Name = "radioDayAlwaysRecording";
            this.radioDayAlwaysRecording.Size = new System.Drawing.Size(110, 17);
            this.radioDayAlwaysRecording.TabIndex = 27;
            this.radioDayAlwaysRecording.TabStop = true;
            this.radioDayAlwaysRecording.Text = "Always Recording";
            this.radioDayAlwaysRecording.UseVisualStyleBackColor = true;
            this.radioDayAlwaysRecording.CheckedChanged += new System.EventHandler(this.radioDayAlwaysRecording_CheckedChanged);
            // 
            // picDayNoRecord
            // 
            this.picDayNoRecord.BackColor = System.Drawing.Color.White;
            this.picDayNoRecord.Location = new System.Drawing.Point(278, 76);
            this.picDayNoRecord.Name = "picDayNoRecord";
            this.picDayNoRecord.Size = new System.Drawing.Size(20, 20);
            this.picDayNoRecord.TabIndex = 19;
            this.picDayNoRecord.TabStop = false;
            // 
            // picDayVoiceRecord
            // 
            this.picDayVoiceRecord.BackColor = System.Drawing.Color.Yellow;
            this.picDayVoiceRecord.Location = new System.Drawing.Point(278, 24);
            this.picDayVoiceRecord.Name = "picDayVoiceRecord";
            this.picDayVoiceRecord.Size = new System.Drawing.Size(20, 20);
            this.picDayVoiceRecord.TabIndex = 18;
            this.picDayVoiceRecord.TabStop = false;
            // 
            // picDaySmartRecord
            // 
            this.picDaySmartRecord.BackColor = System.Drawing.Color.Fuchsia;
            this.picDaySmartRecord.Location = new System.Drawing.Point(121, 76);
            this.picDaySmartRecord.Name = "picDaySmartRecord";
            this.picDaySmartRecord.Size = new System.Drawing.Size(20, 20);
            this.picDaySmartRecord.TabIndex = 17;
            this.picDaySmartRecord.TabStop = false;
            // 
            // picDayMotionRecord
            // 
            this.picDayMotionRecord.BackColor = System.Drawing.Color.Lime;
            this.picDayMotionRecord.Location = new System.Drawing.Point(121, 50);
            this.picDayMotionRecord.Name = "picDayMotionRecord";
            this.picDayMotionRecord.Size = new System.Drawing.Size(20, 20);
            this.picDayMotionRecord.TabIndex = 20;
            this.picDayMotionRecord.TabStop = false;
            // 
            // picDayKeyframeRecord
            // 
            this.picDayKeyframeRecord.BackColor = System.Drawing.Color.Cyan;
            this.picDayKeyframeRecord.Location = new System.Drawing.Point(278, 50);
            this.picDayKeyframeRecord.Name = "picDayKeyframeRecord";
            this.picDayKeyframeRecord.Size = new System.Drawing.Size(20, 20);
            this.picDayKeyframeRecord.TabIndex = 22;
            this.picDayKeyframeRecord.TabStop = false;
            // 
            // picDayAlwaysRecord
            // 
            this.picDayAlwaysRecord.BackColor = System.Drawing.Color.Blue;
            this.picDayAlwaysRecord.Location = new System.Drawing.Point(121, 24);
            this.picDayAlwaysRecord.Name = "picDayAlwaysRecord";
            this.picDayAlwaysRecord.Size = new System.Drawing.Size(20, 20);
            this.picDayAlwaysRecord.TabIndex = 21;
            this.picDayAlwaysRecord.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(497, 426);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmRecordingSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 461);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabRecordMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRecordingSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recording Mode";
            this.tabRecordMode.ResumeLayout(false);
            this.pageWeekly.ResumeLayout(false);
            this.pageWeekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekNoRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekVoiceDetectRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekSmarRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekMotionRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekKeyFrameRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeekAlwaysRecord)).EndInit();
            this.pageDay.ResumeLayout(false);
            this.pageDay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDayNoRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayVoiceRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDaySmartRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayMotionRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayKeyframeRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDayAlwaysRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRecordMode;
        private System.Windows.Forms.TabPage pageWeekly;
		private System.Windows.Forms.TabPage pageDay;
        private System.Windows.Forms.RadioButton radioWeekNoRecord;
        private System.Windows.Forms.RadioButton radioWeekVoiceRecord;
        private System.Windows.Forms.RadioButton radioWeekSmartRecord;
        private System.Windows.Forms.RadioButton radioWeekMotionRecord;
        private System.Windows.Forms.RadioButton radioWeekKeyFrameRecord;
        private System.Windows.Forms.RadioButton radioWeekAlwaysRecord;
        private System.Windows.Forms.PictureBox picWeekNoRecord;
        private System.Windows.Forms.PictureBox picWeekVoiceDetectRecord;
        private System.Windows.Forms.PictureBox picWeekSmarRecord;
        private System.Windows.Forms.PictureBox picWeekMotionRecord;
        private System.Windows.Forms.PictureBox picWeekKeyFrameRecord;
		private System.Windows.Forms.PictureBox picWeekAlwaysRecord;
        private System.Windows.Forms.RadioButton radioDayNoRecording;
        private System.Windows.Forms.RadioButton radioDayVoiceRecording;
        private System.Windows.Forms.RadioButton radioDaySmartRecording;
        private System.Windows.Forms.RadioButton radioDayMotionRecording;
        private System.Windows.Forms.RadioButton radioDayKeyFrameRecording;
        private System.Windows.Forms.RadioButton radioDayAlwaysRecording;
        private System.Windows.Forms.PictureBox picDayNoRecord;
        private System.Windows.Forms.PictureBox picDayVoiceRecord;
        private System.Windows.Forms.PictureBox picDaySmartRecord;
        private System.Windows.Forms.PictureBox picDayMotionRecord;
        private System.Windows.Forms.PictureBox picDayKeyframeRecord;
        private System.Windows.Forms.PictureBox picDayAlwaysRecord;
        private System.Windows.Forms.Button btnOK;
		private GridCtrl.Grid gridWeekSchedule;
		private GridCtrl.Grid gridDaySchedule;
    }
}
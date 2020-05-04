namespace iNVMSMain
{
    partial class FrmSystemMiscellaneousSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutoScanPeriod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFreeSpaceLimit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStatusReport = new System.Windows.Forms.CheckBox();
            this.btnSetup = new System.Windows.Forms.Button();
            this.chkDesktopLock = new System.Windows.Forms.CheckBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.chkbeep = new System.Windows.Forms.CheckBox();
            this.chkShutdown = new System.Windows.Forms.CheckBox();
            this.chkMandatory = new System.Windows.Forms.CheckBox();
            this.chkOverlay = new System.Windows.Forms.CheckBox();
            this.chkLivePlayBack = new System.Windows.Forms.CheckBox();
            this.chkUage = new System.Windows.Forms.CheckBox();
            this.chkScreensaver = new System.Windows.Forms.CheckBox();
            this.chkask = new System.Windows.Forms.CheckBox();
            this.chkResequence = new System.Windows.Forms.CheckBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.chkOSK = new System.Windows.Forms.CheckBox();
            this.chkEnableNetwork = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTemperature = new System.Windows.Forms.ComboBox();
            this.cmdPlayBackMode = new System.Windows.Forms.ComboBox();
            this.txtPlayBackTime = new System.Windows.Forms.TextBox();
            this.cmdDateFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtScreensaver = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "AutoScan Period";
            // 
            // txtAutoScanPeriod
            // 
            this.txtAutoScanPeriod.Location = new System.Drawing.Point(166, 398);
            this.txtAutoScanPeriod.Name = "txtAutoScanPeriod";
            this.txtAutoScanPeriod.Size = new System.Drawing.Size(70, 20);
            this.txtAutoScanPeriod.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Sec";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 599);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 599);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtFreeSpaceLimit
            // 
            this.txtFreeSpaceLimit.Location = new System.Drawing.Point(193, 558);
            this.txtFreeSpaceLimit.Name = "txtFreeSpaceLimit";
            this.txtFreeSpaceLimit.Size = new System.Drawing.Size(89, 20);
            this.txtFreeSpaceLimit.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Keep free space of partition above";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 561);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "MB";
            // 
            // chkStatusReport
            // 
            this.chkStatusReport.AutoSize = true;
            this.chkStatusReport.Location = new System.Drawing.Point(18, 14);
            this.chkStatusReport.Name = "chkStatusReport";
            this.chkStatusReport.Size = new System.Drawing.Size(91, 17);
            this.chkStatusReport.TabIndex = 36;
            this.chkStatusReport.Text = "Status Report";
            this.chkStatusReport.UseVisualStyleBackColor = true;
            this.chkStatusReport.Click += new System.EventHandler(this.chkStatusReport_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(193, 10);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 22);
            this.btnSetup.TabIndex = 37;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            // 
            // chkDesktopLock
            // 
            this.chkDesktopLock.AutoSize = true;
            this.chkDesktopLock.Location = new System.Drawing.Point(18, 39);
            this.chkDesktopLock.Name = "chkDesktopLock";
            this.chkDesktopLock.Size = new System.Drawing.Size(93, 17);
            this.chkDesktopLock.TabIndex = 38;
            this.chkDesktopLock.Text = "Desktop Lock";
            this.chkDesktopLock.UseVisualStyleBackColor = true;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(193, 39);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 22);
            this.btnDetail.TabIndex = 39;
            this.btnDetail.Text = "Detail";
            this.btnDetail.UseVisualStyleBackColor = true;
            // 
            // chkbeep
            // 
            this.chkbeep.AutoSize = true;
            this.chkbeep.Location = new System.Drawing.Point(18, 64);
            this.chkbeep.Name = "chkbeep";
            this.chkbeep.Size = new System.Drawing.Size(104, 17);
            this.chkbeep.TabIndex = 40;
            this.chkbeep.Text = "Beep if no signal";
            this.chkbeep.UseVisualStyleBackColor = true;
            // 
            // chkShutdown
            // 
            this.chkShutdown.AutoSize = true;
            this.chkShutdown.Location = new System.Drawing.Point(18, 89);
            this.chkShutdown.Name = "chkShutdown";
            this.chkShutdown.Size = new System.Drawing.Size(143, 17);
            this.chkShutdown.TabIndex = 41;
            this.chkShutdown.Text = "Shut down OS when exit";
            this.chkShutdown.UseVisualStyleBackColor = true;
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.Location = new System.Drawing.Point(18, 114);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(123, 17);
            this.chkMandatory.TabIndex = 42;
            this.chkMandatory.Text = "Mandatory recording";
            this.chkMandatory.UseVisualStyleBackColor = true;
            // 
            // chkOverlay
            // 
            this.chkOverlay.AutoSize = true;
            this.chkOverlay.Location = new System.Drawing.Point(18, 139);
            this.chkOverlay.Name = "chkOverlay";
            this.chkOverlay.Size = new System.Drawing.Size(96, 17);
            this.chkOverlay.TabIndex = 43;
            this.chkOverlay.Text = "Enable overlay";
            this.chkOverlay.UseVisualStyleBackColor = true;
            // 
            // chkLivePlayBack
            // 
            this.chkLivePlayBack.AutoSize = true;
            this.chkLivePlayBack.Location = new System.Drawing.Point(18, 164);
            this.chkLivePlayBack.Name = "chkLivePlayBack";
            this.chkLivePlayBack.Size = new System.Drawing.Size(125, 17);
            this.chkLivePlayBack.TabIndex = 44;
            this.chkLivePlayBack.Text = "Enable Liveplayback";
            this.chkLivePlayBack.UseVisualStyleBackColor = true;
            // 
            // chkUage
            // 
            this.chkUage.AutoSize = true;
            this.chkUage.Location = new System.Drawing.Point(18, 207);
            this.chkUage.Name = "chkUage";
            this.chkUage.Size = new System.Drawing.Size(199, 17);
            this.chkUage.TabIndex = 45;
            this.chkUage.Text = "Increase memory usage of a process";
            this.chkUage.UseVisualStyleBackColor = true;
            // 
            // chkScreensaver
            // 
            this.chkScreensaver.AutoSize = true;
            this.chkScreensaver.Location = new System.Drawing.Point(18, 233);
            this.chkScreensaver.Name = "chkScreensaver";
            this.chkScreensaver.Size = new System.Drawing.Size(91, 17);
            this.chkScreensaver.TabIndex = 46;
            this.chkScreensaver.Text = "Screen Saver";
            this.chkScreensaver.UseVisualStyleBackColor = true;
            // 
            // chkask
            // 
            this.chkask.AutoSize = true;
            this.chkask.Location = new System.Drawing.Point(18, 259);
            this.chkask.Name = "chkask";
            this.chkask.Size = new System.Drawing.Size(301, 17);
            this.chkask.TabIndex = 47;
            this.chkask.Text = "Leave the system without asking user name and password";
            this.chkask.UseVisualStyleBackColor = true;
            // 
            // chkResequence
            // 
            this.chkResequence.AutoSize = true;
            this.chkResequence.Location = new System.Drawing.Point(18, 285);
            this.chkResequence.Name = "chkResequence";
            this.chkResequence.Size = new System.Drawing.Size(209, 17);
            this.chkResequence.TabIndex = 48;
            this.chkResequence.Text = "Resequence channels when autoscan";
            this.chkResequence.UseVisualStyleBackColor = true;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(18, 311);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(187, 17);
            this.chkRemember.TabIndex = 49;
            this.chkRemember.Text = "Remember playback display mode";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // chkOSK
            // 
            this.chkOSK.AutoSize = true;
            this.chkOSK.Location = new System.Drawing.Point(18, 350);
            this.chkOSK.Name = "chkOSK";
            this.chkOSK.Size = new System.Drawing.Size(136, 17);
            this.chkOSK.TabIndex = 50;
            this.chkOSK.Text = "Force to use small OSK";
            this.chkOSK.UseVisualStyleBackColor = true;
            // 
            // chkEnableNetwork
            // 
            this.chkEnableNetwork.AutoSize = true;
            this.chkEnableNetwork.Location = new System.Drawing.Point(18, 375);
            this.chkEnableNetwork.Name = "chkEnableNetwork";
            this.chkEnableNetwork.Size = new System.Drawing.Size(138, 17);
            this.chkEnableNetwork.TabIndex = 51;
            this.chkEnableNetwork.Text = "Enable network storage";
            this.chkEnableNetwork.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Templerature Display";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Playback Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 498);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Set Instant Playback\'s Play Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Date Format";
            // 
            // cmbTemperature
            // 
            this.cmbTemperature.FormattingEnabled = true;
            this.cmbTemperature.Location = new System.Drawing.Point(166, 432);
            this.cmbTemperature.Name = "cmbTemperature";
            this.cmbTemperature.Size = new System.Drawing.Size(70, 21);
            this.cmbTemperature.TabIndex = 56;
            // 
            // cmdPlayBackMode
            // 
            this.cmdPlayBackMode.FormattingEnabled = true;
            this.cmdPlayBackMode.Location = new System.Drawing.Point(166, 465);
            this.cmdPlayBackMode.Name = "cmdPlayBackMode";
            this.cmdPlayBackMode.Size = new System.Drawing.Size(114, 21);
            this.cmdPlayBackMode.TabIndex = 57;
            // 
            // txtPlayBackTime
            // 
            this.txtPlayBackTime.Location = new System.Drawing.Point(191, 496);
            this.txtPlayBackTime.Name = "txtPlayBackTime";
            this.txtPlayBackTime.Size = new System.Drawing.Size(90, 20);
            this.txtPlayBackTime.TabIndex = 58;
            // 
            // cmdDateFormat
            // 
            this.cmdDateFormat.FormattingEnabled = true;
            this.cmdDateFormat.Location = new System.Drawing.Point(167, 526);
            this.cmdDateFormat.Name = "cmdDateFormat";
            this.cmdDateFormat.Size = new System.Drawing.Size(114, 21);
            this.cmdDateFormat.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Sec";
            // 
            // txtScreensaver
            // 
            this.txtScreensaver.Location = new System.Drawing.Point(162, 233);
            this.txtScreensaver.Name = "txtScreensaver";
            this.txtScreensaver.Size = new System.Drawing.Size(73, 20);
            this.txtScreensaver.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Minute wait";
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeyboard.Location = new System.Drawing.Point(165, 344);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(31, 26);
            this.btnKeyboard.TabIndex = 74;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // FrmSystemMiscellaneousSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 634);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtScreensaver);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdDateFormat);
            this.Controls.Add(this.txtPlayBackTime);
            this.Controls.Add(this.cmdPlayBackMode);
            this.Controls.Add(this.cmbTemperature);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkEnableNetwork);
            this.Controls.Add(this.chkOSK);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.chkResequence);
            this.Controls.Add(this.chkask);
            this.Controls.Add(this.chkScreensaver);
            this.Controls.Add(this.chkUage);
            this.Controls.Add(this.chkLivePlayBack);
            this.Controls.Add(this.chkOverlay);
            this.Controls.Add(this.chkMandatory);
            this.Controls.Add(this.chkShutdown);
            this.Controls.Add(this.chkbeep);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.chkDesktopLock);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.chkStatusReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFreeSpaceLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAutoScanPeriod);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmSystemMiscellaneousSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Miscellaneous Setting";
            this.Load += new System.EventHandler(this.FrmSystemMiscellaneousSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAutoScanPeriod;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtFreeSpaceLimit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStatusReport;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.CheckBox chkDesktopLock;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.CheckBox chkbeep;
        private System.Windows.Forms.CheckBox chkShutdown;
        private System.Windows.Forms.CheckBox chkMandatory;
        private System.Windows.Forms.CheckBox chkOverlay;
        private System.Windows.Forms.CheckBox chkLivePlayBack;
        private System.Windows.Forms.CheckBox chkUage;
        private System.Windows.Forms.CheckBox chkScreensaver;
        private System.Windows.Forms.CheckBox chkask;
        private System.Windows.Forms.CheckBox chkResequence;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkOSK;
        private System.Windows.Forms.CheckBox chkEnableNetwork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTemperature;
        private System.Windows.Forms.ComboBox cmdPlayBackMode;
        private System.Windows.Forms.TextBox txtPlayBackTime;
        private System.Windows.Forms.ComboBox cmdDateFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtScreensaver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnKeyboard;
    }
}
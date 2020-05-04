namespace iNVMSMain
{
    partial class FrmAlarmAbnormalEvent
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
			this.chkSystemReboot = new System.Windows.Forms.CheckBox();
			this.chkAbnormReboot = new System.Windows.Forms.CheckBox();
			this.chkRecordSwitch = new System.Windows.Forms.CheckBox();
			this.chkNetworkSwitch = new System.Windows.Forms.CheckBox();
			this.chkHardDisk = new System.Windows.Forms.CheckBox();
			this.chkLANFail = new System.Windows.Forms.CheckBox();
			this.chkSMART = new System.Windows.Forms.CheckBox();
			this.chkRD = new System.Windows.Forms.CheckBox();
			this.chkTemperature = new System.Windows.Forms.CheckBox();
			this.cmbSMART = new System.Windows.Forms.ComboBox();
			this.cmbRD = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnIllegalEntry2 = new System.Windows.Forms.Button();
			this.btnIllegalEntry1 = new System.Windows.Forms.Button();
			this.chkIllegalEntry2 = new System.Windows.Forms.CheckBox();
			this.chkIllegalEntry1 = new System.Windows.Forms.CheckBox();
			this.chkFaceFind = new System.Windows.Forms.CheckBox();
			this.cmbFaceFind = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkSystemReboot
			// 
			this.chkSystemReboot.AutoSize = true;
			this.chkSystemReboot.Location = new System.Drawing.Point(24, 23);
			this.chkSystemReboot.Name = "chkSystemReboot";
			this.chkSystemReboot.Size = new System.Drawing.Size(98, 17);
			this.chkSystemReboot.TabIndex = 0;
			this.chkSystemReboot.Text = "System Reboot";
			this.chkSystemReboot.UseVisualStyleBackColor = true;
			// 
			// chkAbnormReboot
			// 
			this.chkAbnormReboot.AutoSize = true;
			this.chkAbnormReboot.Location = new System.Drawing.Point(24, 46);
			this.chkAbnormReboot.Name = "chkAbnormReboot";
			this.chkAbnormReboot.Size = new System.Drawing.Size(108, 17);
			this.chkAbnormReboot.TabIndex = 1;
			this.chkAbnormReboot.Text = "Abnormal Reboot";
			this.chkAbnormReboot.UseVisualStyleBackColor = true;
			// 
			// chkRecordSwitch
			// 
			this.chkRecordSwitch.AutoSize = true;
			this.chkRecordSwitch.Location = new System.Drawing.Point(24, 69);
			this.chkRecordSwitch.Name = "chkRecordSwitch";
			this.chkRecordSwitch.Size = new System.Drawing.Size(145, 17);
			this.chkRecordSwitch.TabIndex = 2;
			this.chkRecordSwitch.Text = "Recording is switched off";
			this.chkRecordSwitch.UseVisualStyleBackColor = true;
			// 
			// chkNetworkSwitch
			// 
			this.chkNetworkSwitch.AutoSize = true;
			this.chkNetworkSwitch.Location = new System.Drawing.Point(24, 92);
			this.chkNetworkSwitch.Name = "chkNetworkSwitch";
			this.chkNetworkSwitch.Size = new System.Drawing.Size(136, 17);
			this.chkNetworkSwitch.TabIndex = 3;
			this.chkNetworkSwitch.Text = "Network is switched off";
			this.chkNetworkSwitch.UseVisualStyleBackColor = true;
			// 
			// chkHardDisk
			// 
			this.chkHardDisk.AutoSize = true;
			this.chkHardDisk.Location = new System.Drawing.Point(24, 115);
			this.chkHardDisk.Name = "chkHardDisk";
			this.chkHardDisk.Size = new System.Drawing.Size(104, 17);
			this.chkHardDisk.TabIndex = 4;
			this.chkHardDisk.Text = "Hard Disk Failed";
			this.chkHardDisk.UseVisualStyleBackColor = true;
			// 
			// chkLANFail
			// 
			this.chkLANFail.AutoSize = true;
			this.chkLANFail.Location = new System.Drawing.Point(24, 138);
			this.chkLANFail.Name = "chkLANFail";
			this.chkLANFail.Size = new System.Drawing.Size(78, 17);
			this.chkLANFail.TabIndex = 5;
			this.chkLANFail.Text = "LAN Failed";
			this.chkLANFail.UseVisualStyleBackColor = true;
			// 
			// chkSMART
			// 
			this.chkSMART.AutoSize = true;
			this.chkSMART.Location = new System.Drawing.Point(24, 161);
			this.chkSMART.Name = "chkSMART";
			this.chkSMART.Size = new System.Drawing.Size(79, 17);
			this.chkSMART.TabIndex = 6;
			this.chkSMART.Text = "S.M.A.R.T.";
			this.chkSMART.UseVisualStyleBackColor = true;
			// 
			// chkRD
			// 
			this.chkRD.AutoSize = true;
			this.chkRD.Location = new System.Drawing.Point(24, 184);
			this.chkRD.Name = "chkRD";
			this.chkRD.Size = new System.Drawing.Size(48, 17);
			this.chkRD.TabIndex = 7;
			this.chkRD.Text = "R  D";
			this.chkRD.UseVisualStyleBackColor = true;
			// 
			// chkTemperature
			// 
			this.chkTemperature.AutoSize = true;
			this.chkTemperature.Location = new System.Drawing.Point(24, 207);
			this.chkTemperature.Name = "chkTemperature";
			this.chkTemperature.Size = new System.Drawing.Size(86, 17);
			this.chkTemperature.TabIndex = 8;
			this.chkTemperature.Text = "Temperature";
			this.chkTemperature.UseVisualStyleBackColor = true;
			// 
			// cmbSMART
			// 
			this.cmbSMART.FormattingEnabled = true;
			this.cmbSMART.Items.AddRange(new object[] {
            "HIGH_RISK",
            "LOW_RISK"});
			this.cmbSMART.Location = new System.Drawing.Point(229, 159);
			this.cmbSMART.Name = "cmbSMART";
			this.cmbSMART.Size = new System.Drawing.Size(93, 21);
			this.cmbSMART.TabIndex = 9;
			// 
			// cmbRD
			// 
			this.cmbRD.FormattingEnabled = true;
			this.cmbRD.Location = new System.Drawing.Point(229, 182);
			this.cmbRD.Name = "cmbRD";
			this.cmbRD.Size = new System.Drawing.Size(93, 21);
			this.cmbRD.TabIndex = 10;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "C",
            "F"});
			this.comboBox3.Location = new System.Drawing.Point(285, 205);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(37, 21);
			this.comboBox3.TabIndex = 11;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(229, 205);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(40, 20);
			this.textBox1.TabIndex = 12;
			this.textBox1.Text = "60";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(273, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(9, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "\'";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 208);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = ">";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnIllegalEntry2);
			this.groupBox1.Controls.Add(this.btnIllegalEntry1);
			this.groupBox1.Controls.Add(this.chkIllegalEntry2);
			this.groupBox1.Controls.Add(this.chkIllegalEntry1);
			this.groupBox1.Location = new System.Drawing.Point(12, 230);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(319, 73);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "illegal Entry";
			// 
			// btnIllegalEntry2
			// 
			this.btnIllegalEntry2.Location = new System.Drawing.Point(235, 39);
			this.btnIllegalEntry2.Name = "btnIllegalEntry2";
			this.btnIllegalEntry2.Size = new System.Drawing.Size(75, 23);
			this.btnIllegalEntry2.TabIndex = 3;
			this.btnIllegalEntry2.Text = "Detail";
			this.btnIllegalEntry2.UseVisualStyleBackColor = true;
			// 
			// btnIllegalEntry1
			// 
			this.btnIllegalEntry1.Location = new System.Drawing.Point(235, 16);
			this.btnIllegalEntry1.Name = "btnIllegalEntry1";
			this.btnIllegalEntry1.Size = new System.Drawing.Size(75, 23);
			this.btnIllegalEntry1.TabIndex = 2;
			this.btnIllegalEntry1.Text = "Detail";
			this.btnIllegalEntry1.UseVisualStyleBackColor = true;
			// 
			// chkIllegalEntry2
			// 
			this.chkIllegalEntry2.AutoSize = true;
			this.chkIllegalEntry2.Location = new System.Drawing.Point(12, 43);
			this.chkIllegalEntry2.Name = "chkIllegalEntry2";
			this.chkIllegalEntry2.Size = new System.Drawing.Size(47, 17);
			this.chkIllegalEntry2.TabIndex = 1;
			this.chkIllegalEntry2.Text = "2->1";
			this.chkIllegalEntry2.UseVisualStyleBackColor = true;
			// 
			// chkIllegalEntry1
			// 
			this.chkIllegalEntry1.AutoSize = true;
			this.chkIllegalEntry1.Location = new System.Drawing.Point(12, 20);
			this.chkIllegalEntry1.Name = "chkIllegalEntry1";
			this.chkIllegalEntry1.Size = new System.Drawing.Size(47, 17);
			this.chkIllegalEntry1.TabIndex = 0;
			this.chkIllegalEntry1.Text = "1->2";
			this.chkIllegalEntry1.UseVisualStyleBackColor = true;
			// 
			// chkFaceFind
			// 
			this.chkFaceFind.AutoSize = true;
			this.chkFaceFind.Location = new System.Drawing.Point(24, 309);
			this.chkFaceFind.Name = "chkFaceFind";
			this.chkFaceFind.Size = new System.Drawing.Size(82, 17);
			this.chkFaceFind.TabIndex = 16;
			this.chkFaceFind.Text = "Face Finder";
			this.chkFaceFind.UseVisualStyleBackColor = true;
			// 
			// cmbFaceFind
			// 
			this.cmbFaceFind.FormattingEnabled = true;
			this.cmbFaceFind.Items.AddRange(new object[] {
            "Camera1",
            "Camera2",
            "Camera3"});
			this.cmbFaceFind.Location = new System.Drawing.Point(229, 309);
			this.cmbFaceFind.Name = "cmbFaceFind";
			this.cmbFaceFind.Size = new System.Drawing.Size(93, 21);
			this.cmbFaceFind.TabIndex = 17;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(166, 335);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 18;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(247, 335);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmAbnormalEvent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(334, 366);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbFaceFind);
			this.Controls.Add(this.chkFaceFind);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.cmbRD);
			this.Controls.Add(this.cmbSMART);
			this.Controls.Add(this.chkTemperature);
			this.Controls.Add(this.chkRD);
			this.Controls.Add(this.chkSMART);
			this.Controls.Add(this.chkLANFail);
			this.Controls.Add(this.chkHardDisk);
			this.Controls.Add(this.chkNetworkSwitch);
			this.Controls.Add(this.chkRecordSwitch);
			this.Controls.Add(this.chkAbnormReboot);
			this.Controls.Add(this.chkSystemReboot);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmAbnormalEvent";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Abnormal Event";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSystemReboot;
        private System.Windows.Forms.CheckBox chkAbnormReboot;
        private System.Windows.Forms.CheckBox chkRecordSwitch;
        private System.Windows.Forms.CheckBox chkNetworkSwitch;
        private System.Windows.Forms.CheckBox chkHardDisk;
        private System.Windows.Forms.CheckBox chkLANFail;
        private System.Windows.Forms.CheckBox chkSMART;
        private System.Windows.Forms.CheckBox chkRD;
        private System.Windows.Forms.CheckBox chkTemperature;
        private System.Windows.Forms.ComboBox cmbSMART;
        private System.Windows.Forms.ComboBox cmbRD;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIllegalEntry2;
        private System.Windows.Forms.Button btnIllegalEntry1;
        private System.Windows.Forms.CheckBox chkIllegalEntry2;
        private System.Windows.Forms.CheckBox chkIllegalEntry1;
        private System.Windows.Forms.CheckBox chkFaceFind;
        private System.Windows.Forms.ComboBox cmbFaceFind;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
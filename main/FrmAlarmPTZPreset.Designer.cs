namespace iNVMSMain
{
    partial class FrmAlarmPTZPreset
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
			this.label1 = new System.Windows.Forms.Label();
			this.cmbSelectCam = new System.Windows.Forms.ComboBox();
			this.chkPTZEnable = new System.Windows.Forms.CheckBox();
			this.grbAlarmTrigger = new System.Windows.Forms.GroupBox();
			this.cmbTrigerPreset = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grbAlarmClose = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkAutoPan4 = new System.Windows.Forms.CheckBox();
			this.chkAutoPan2 = new System.Windows.Forms.CheckBox();
			this.chkAutoPan3 = new System.Windows.Forms.CheckBox();
			this.chkAutoPan1 = new System.Windows.Forms.CheckBox();
			this.cmbClosePreset = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grbAlarmTrigger.SuspendLayout();
			this.grbAlarmClose.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Camera";
			// 
			// cmbSelectCam
			// 
			this.cmbSelectCam.FormattingEnabled = true;
			this.cmbSelectCam.Items.AddRange(new object[] {
            "Camera1",
            "Camera2",
            "Camera3",
            "Camera4",
            "Camera5",
            "Camera6",
            "Camera7",
            "Camera8",
            "Camera9",
            "Camera10"});
			this.cmbSelectCam.Location = new System.Drawing.Point(111, 19);
			this.cmbSelectCam.Name = "cmbSelectCam";
			this.cmbSelectCam.Size = new System.Drawing.Size(121, 21);
			this.cmbSelectCam.TabIndex = 1;
			// 
			// chkPTZEnable
			// 
			this.chkPTZEnable.AutoSize = true;
			this.chkPTZEnable.Location = new System.Drawing.Point(26, 51);
			this.chkPTZEnable.Name = "chkPTZEnable";
			this.chkPTZEnable.Size = new System.Drawing.Size(59, 17);
			this.chkPTZEnable.TabIndex = 2;
			this.chkPTZEnable.Text = "Enable";
			this.chkPTZEnable.UseVisualStyleBackColor = true;
			this.chkPTZEnable.CheckedChanged += new System.EventHandler(this.chkPTZEnable_CheckedChanged);
			// 
			// grbAlarmTrigger
			// 
			this.grbAlarmTrigger.Controls.Add(this.cmbTrigerPreset);
			this.grbAlarmTrigger.Controls.Add(this.label2);
			this.grbAlarmTrigger.Enabled = false;
			this.grbAlarmTrigger.Location = new System.Drawing.Point(26, 87);
			this.grbAlarmTrigger.Name = "grbAlarmTrigger";
			this.grbAlarmTrigger.Size = new System.Drawing.Size(140, 139);
			this.grbAlarmTrigger.TabIndex = 3;
			this.grbAlarmTrigger.TabStop = false;
			this.grbAlarmTrigger.Text = "Alarm Trigger";
			// 
			// cmbTrigerPreset
			// 
			this.cmbTrigerPreset.FormattingEnabled = true;
			this.cmbTrigerPreset.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.cmbTrigerPreset.Location = new System.Drawing.Point(9, 41);
			this.cmbTrigerPreset.Name = "cmbTrigerPreset";
			this.cmbTrigerPreset.Size = new System.Drawing.Size(125, 21);
			this.cmbTrigerPreset.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Preset Number";
			// 
			// grbAlarmClose
			// 
			this.grbAlarmClose.Controls.Add(this.groupBox3);
			this.grbAlarmClose.Controls.Add(this.cmbClosePreset);
			this.grbAlarmClose.Controls.Add(this.label3);
			this.grbAlarmClose.Enabled = false;
			this.grbAlarmClose.Location = new System.Drawing.Point(172, 87);
			this.grbAlarmClose.Name = "grbAlarmClose";
			this.grbAlarmClose.Size = new System.Drawing.Size(140, 139);
			this.grbAlarmClose.TabIndex = 4;
			this.grbAlarmClose.TabStop = false;
			this.grbAlarmClose.Text = "Alarm Close";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkAutoPan4);
			this.groupBox3.Controls.Add(this.chkAutoPan2);
			this.groupBox3.Controls.Add(this.chkAutoPan3);
			this.groupBox3.Controls.Add(this.chkAutoPan1);
			this.groupBox3.Location = new System.Drawing.Point(9, 65);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(125, 68);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "AutoPan";
			// 
			// chkAutoPan4
			// 
			this.chkAutoPan4.AutoSize = true;
			this.chkAutoPan4.Location = new System.Drawing.Point(69, 42);
			this.chkAutoPan4.Name = "chkAutoPan4";
			this.chkAutoPan4.Size = new System.Drawing.Size(53, 17);
			this.chkAutoPan4.TabIndex = 3;
			this.chkAutoPan4.Text = "13-16";
			this.chkAutoPan4.UseVisualStyleBackColor = true;
			// 
			// chkAutoPan2
			// 
			this.chkAutoPan2.AutoSize = true;
			this.chkAutoPan2.Location = new System.Drawing.Point(69, 19);
			this.chkAutoPan2.Name = "chkAutoPan2";
			this.chkAutoPan2.Size = new System.Drawing.Size(41, 17);
			this.chkAutoPan2.TabIndex = 2;
			this.chkAutoPan2.Text = "5-8";
			this.chkAutoPan2.UseVisualStyleBackColor = true;
			// 
			// chkAutoPan3
			// 
			this.chkAutoPan3.AutoSize = true;
			this.chkAutoPan3.Location = new System.Drawing.Point(7, 43);
			this.chkAutoPan3.Name = "chkAutoPan3";
			this.chkAutoPan3.Size = new System.Drawing.Size(47, 17);
			this.chkAutoPan3.TabIndex = 1;
			this.chkAutoPan3.Text = "9-12";
			this.chkAutoPan3.UseVisualStyleBackColor = true;
			// 
			// chkAutoPan1
			// 
			this.chkAutoPan1.AutoSize = true;
			this.chkAutoPan1.Location = new System.Drawing.Point(7, 20);
			this.chkAutoPan1.Name = "chkAutoPan1";
			this.chkAutoPan1.Size = new System.Drawing.Size(41, 17);
			this.chkAutoPan1.TabIndex = 0;
			this.chkAutoPan1.Text = "1-4";
			this.chkAutoPan1.UseVisualStyleBackColor = true;
			// 
			// cmbClosePreset
			// 
			this.cmbClosePreset.FormattingEnabled = true;
			this.cmbClosePreset.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.cmbClosePreset.Location = new System.Drawing.Point(9, 41);
			this.cmbClosePreset.Name = "cmbClosePreset";
			this.cmbClosePreset.Size = new System.Drawing.Size(125, 21);
			this.cmbClosePreset.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Preset Number";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(182, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(62, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(250, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(62, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmPTZPreset
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 261);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grbAlarmClose);
			this.Controls.Add(this.grbAlarmTrigger);
			this.Controls.Add(this.chkPTZEnable);
			this.Controls.Add(this.cmbSelectCam);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmPTZPreset";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trigger PTZ Preset Setting";
			this.grbAlarmTrigger.ResumeLayout(false);
			this.grbAlarmTrigger.PerformLayout();
			this.grbAlarmClose.ResumeLayout(false);
			this.grbAlarmClose.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSelectCam;
        private System.Windows.Forms.CheckBox chkPTZEnable;
        private System.Windows.Forms.GroupBox grbAlarmTrigger;
        private System.Windows.Forms.GroupBox grbAlarmClose;
        private System.Windows.Forms.ComboBox cmbTrigerPreset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClosePreset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAutoPan3;
        private System.Windows.Forms.CheckBox chkAutoPan1;
        private System.Windows.Forms.CheckBox chkAutoPan4;
        private System.Windows.Forms.CheckBox chkAutoPan2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
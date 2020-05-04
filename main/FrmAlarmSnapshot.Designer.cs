namespace iNVMSMain
{
    partial class FrmAlarmSnapshot
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNumPic = new System.Windows.Forms.TextBox();
			this.txtSnapShot = new System.Windows.Forms.TextBox();
			this.cmbSelectCam = new System.Windows.Forms.ComboBox();
			this.cmbVideoSize = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDeleteImage = new System.Windows.Forms.TextBox();
			this.chkDeleteImages = new System.Windows.Forms.CheckBox();
			this.txtSavePath = new System.Windows.Forms.TextBox();
			this.btnSavePath = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Camera";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Video Size";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Number of Picture";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Snapshot Interval (Sec)";
			// 
			// txtNumPic
			// 
			this.txtNumPic.Location = new System.Drawing.Point(205, 81);
			this.txtNumPic.Name = "txtNumPic";
			this.txtNumPic.Size = new System.Drawing.Size(121, 20);
			this.txtNumPic.TabIndex = 4;
			// 
			// txtSnapShot
			// 
			this.txtSnapShot.Location = new System.Drawing.Point(205, 107);
			this.txtSnapShot.Name = "txtSnapShot";
			this.txtSnapShot.Size = new System.Drawing.Size(121, 20);
			this.txtSnapShot.TabIndex = 5;
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
			this.cmbSelectCam.Location = new System.Drawing.Point(205, 27);
			this.cmbSelectCam.Name = "cmbSelectCam";
			this.cmbSelectCam.Size = new System.Drawing.Size(121, 21);
			this.cmbSelectCam.TabIndex = 6;
			// 
			// cmbVideoSize
			// 
			this.cmbVideoSize.FormattingEnabled = true;
			this.cmbVideoSize.Location = new System.Drawing.Point(205, 54);
			this.cmbVideoSize.Name = "cmbVideoSize";
			this.cmbVideoSize.Size = new System.Drawing.Size(121, 21);
			this.cmbVideoSize.TabIndex = 7;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtDeleteImage);
			this.groupBox1.Controls.Add(this.chkDeleteImages);
			this.groupBox1.Controls.Add(this.txtSavePath);
			this.groupBox1.Controls.Add(this.btnSavePath);
			this.groupBox1.Location = new System.Drawing.Point(12, 149);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(314, 100);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Save Path";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(281, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "MB";
			// 
			// txtDeleteImage
			// 
			this.txtDeleteImage.Enabled = false;
			this.txtDeleteImage.Location = new System.Drawing.Point(193, 65);
			this.txtDeleteImage.Name = "txtDeleteImage";
			this.txtDeleteImage.Size = new System.Drawing.Size(85, 20);
			this.txtDeleteImage.TabIndex = 9;
			// 
			// chkDeleteImages
			// 
			this.chkDeleteImages.AutoSize = true;
			this.chkDeleteImages.Location = new System.Drawing.Point(11, 67);
			this.chkDeleteImages.Name = "chkDeleteImages";
			this.chkDeleteImages.Size = new System.Drawing.Size(119, 17);
			this.chkDeleteImages.TabIndex = 4;
			this.chkDeleteImages.Text = "Delete Images After";
			this.chkDeleteImages.UseVisualStyleBackColor = true;
			this.chkDeleteImages.CheckedChanged += new System.EventHandler(this.chkDeleteImages_CheckedChanged);
			// 
			// txtSavePath
			// 
			this.txtSavePath.Location = new System.Drawing.Point(11, 30);
			this.txtSavePath.Name = "txtSavePath";
			this.txtSavePath.Size = new System.Drawing.Size(253, 20);
			this.txtSavePath.TabIndex = 3;
			// 
			// btnSavePath
			// 
			this.btnSavePath.Location = new System.Drawing.Point(270, 29);
			this.btnSavePath.Name = "btnSavePath";
			this.btnSavePath.Size = new System.Drawing.Size(34, 23);
			this.btnSavePath.TabIndex = 2;
			this.btnSavePath.Text = "...";
			this.btnSavePath.UseVisualStyleBackColor = true;
			this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(251, 262);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(170, 262);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmSnapshot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 294);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmbVideoSize);
			this.Controls.Add(this.cmbSelectCam);
			this.Controls.Add(this.txtSnapShot);
			this.Controls.Add(this.txtNumPic);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmSnapshot";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmAlarmSnapshot";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumPic;
        private System.Windows.Forms.TextBox txtSnapShot;
        private System.Windows.Forms.ComboBox cmbSelectCam;
        private System.Windows.Forms.ComboBox cmbVideoSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDeleteImage;
        private System.Windows.Forms.CheckBox chkDeleteImages;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
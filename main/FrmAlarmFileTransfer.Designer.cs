namespace iNVMSMain
{
    partial class FrmAlarmFileTransfer
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
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtFTPSever = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtNumOfPic = new System.Windows.Forms.TextBox();
			this.txtBeforeAlarm = new System.Windows.Forms.TextBox();
			this.cmbUploadImage = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "FTP Sever";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Port";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "ID";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Password";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Number of Picture";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 154);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Before Alarm (Sec)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 180);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Upload Image";
			// 
			// txtFTPSever
			// 
			this.txtFTPSever.Location = new System.Drawing.Point(129, 21);
			this.txtFTPSever.Name = "txtFTPSever";
			this.txtFTPSever.Size = new System.Drawing.Size(143, 20);
			this.txtFTPSever.TabIndex = 7;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(129, 47);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(143, 20);
			this.txtPort.TabIndex = 8;
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(129, 73);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(143, 20);
			this.txtID.TabIndex = 9;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(129, 99);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(143, 20);
			this.txtPassword.TabIndex = 10;
			// 
			// txtNumOfPic
			// 
			this.txtNumOfPic.Location = new System.Drawing.Point(129, 125);
			this.txtNumOfPic.Name = "txtNumOfPic";
			this.txtNumOfPic.Size = new System.Drawing.Size(143, 20);
			this.txtNumOfPic.TabIndex = 11;
			// 
			// txtBeforeAlarm
			// 
			this.txtBeforeAlarm.Location = new System.Drawing.Point(129, 151);
			this.txtBeforeAlarm.Name = "txtBeforeAlarm";
			this.txtBeforeAlarm.Size = new System.Drawing.Size(143, 20);
			this.txtBeforeAlarm.TabIndex = 12;
			// 
			// cmbUploadImage
			// 
			this.cmbUploadImage.FormattingEnabled = true;
			this.cmbUploadImage.Items.AddRange(new object[] {
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
			this.cmbUploadImage.Location = new System.Drawing.Point(129, 177);
			this.cmbUploadImage.Name = "cmbUploadImage";
			this.cmbUploadImage.Size = new System.Drawing.Size(143, 21);
			this.cmbUploadImage.TabIndex = 13;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(129, 213);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 23);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(208, 213);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 23);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmFileTransfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 241);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbUploadImage);
			this.Controls.Add(this.txtBeforeAlarm);
			this.Controls.Add(this.txtNumOfPic);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtFTPSever);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmFileTransfer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FTP Setting";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFTPSever;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNumOfPic;
        private System.Windows.Forms.TextBox txtBeforeAlarm;
        private System.Windows.Forms.ComboBox cmbUploadImage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
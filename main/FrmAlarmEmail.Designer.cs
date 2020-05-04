namespace iNVMSMain
{
    partial class FrmAlarmEmail
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
			this.txtMailPassword = new System.Windows.Forms.TextBox();
			this.txtMailID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chkSSL = new System.Windows.Forms.CheckBox();
			this.chkAuthentication = new System.Windows.Forms.CheckBox();
			this.txtMailSeverPort = new System.Windows.Forms.TextBox();
			this.txtMailSeverIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnTextAccount = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.txtMailSubject = new System.Windows.Forms.TextBox();
			this.txtMailCC = new System.Windows.Forms.TextBox();
			this.txtMailTo = new System.Windows.Forms.TextBox();
			this.txtMailFrom = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.chkAttchImagePath = new System.Windows.Forms.CheckBox();
			this.cmbAttachImage = new System.Windows.Forms.ComboBox();
			this.cmbEmdImageSize = new System.Windows.Forms.ComboBox();
			this.txtEmdFrameSize = new System.Windows.Forms.TextBox();
			this.txtNoticeIntval = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtAutoDisconnet = new System.Windows.Forms.TextBox();
			this.cmbAutoDial = new System.Windows.Forms.ComboBox();
			this.chkAutoDisconnet = new System.Windows.Forms.CheckBox();
			this.chkAutoDialup = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtMailPassword);
			this.groupBox1.Controls.Add(this.txtMailID);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.chkSSL);
			this.groupBox1.Controls.Add(this.chkAuthentication);
			this.groupBox1.Controls.Add(this.txtMailSeverPort);
			this.groupBox1.Controls.Add(this.txtMailSeverIP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 112);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mail Sever";
			// 
			// txtMailPassword
			// 
			this.txtMailPassword.Enabled = false;
			this.txtMailPassword.Location = new System.Drawing.Point(278, 78);
			this.txtMailPassword.Name = "txtMailPassword";
			this.txtMailPassword.Size = new System.Drawing.Size(126, 20);
			this.txtMailPassword.TabIndex = 9;
			// 
			// txtMailID
			// 
			this.txtMailID.Enabled = false;
			this.txtMailID.Location = new System.Drawing.Point(97, 78);
			this.txtMailID.Name = "txtMailID";
			this.txtMailID.Size = new System.Drawing.Size(108, 20);
			this.txtMailID.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(219, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Password";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "ID";
			// 
			// chkSSL
			// 
			this.chkSSL.AutoSize = true;
			this.chkSSL.Location = new System.Drawing.Point(216, 55);
			this.chkSSL.Name = "chkSSL";
			this.chkSSL.Size = new System.Drawing.Size(46, 17);
			this.chkSSL.TabIndex = 5;
			this.chkSSL.Text = "SSL";
			this.chkSSL.UseVisualStyleBackColor = true;
			// 
			// chkAuthentication
			// 
			this.chkAuthentication.AutoSize = true;
			this.chkAuthentication.Location = new System.Drawing.Point(20, 55);
			this.chkAuthentication.Name = "chkAuthentication";
			this.chkAuthentication.Size = new System.Drawing.Size(94, 17);
			this.chkAuthentication.TabIndex = 4;
			this.chkAuthentication.Text = "Authentication";
			this.chkAuthentication.UseVisualStyleBackColor = true;
			this.chkAuthentication.CheckedChanged += new System.EventHandler(this.chkAuthentication_CheckedChanged);
			// 
			// txtMailSeverPort
			// 
			this.txtMailSeverPort.Location = new System.Drawing.Point(261, 26);
			this.txtMailSeverPort.Name = "txtMailSeverPort";
			this.txtMailSeverPort.Size = new System.Drawing.Size(35, 20);
			this.txtMailSeverPort.TabIndex = 3;
			this.txtMailSeverPort.Text = "25";
			// 
			// txtMailSeverIP
			// 
			this.txtMailSeverIP.Location = new System.Drawing.Point(97, 26);
			this.txtMailSeverIP.Name = "txtMailSeverIP";
			this.txtMailSeverIP.Size = new System.Drawing.Size(148, 20);
			this.txtMailSeverIP.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(249, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = ":";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "SMTP Sever";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnTextAccount);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.rtbMessage);
			this.groupBox2.Controls.Add(this.txtMailSubject);
			this.groupBox2.Controls.Add(this.txtMailCC);
			this.groupBox2.Controls.Add(this.txtMailTo);
			this.groupBox2.Controls.Add(this.txtMailFrom);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(12, 126);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(410, 173);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mail";
			// 
			// btnTextAccount
			// 
			this.btnTextAccount.Location = new System.Drawing.Point(278, 144);
			this.btnTextAccount.Name = "btnTextAccount";
			this.btnTextAccount.Size = new System.Drawing.Size(117, 23);
			this.btnTextAccount.TabIndex = 10;
			this.btnTextAccount.Text = "Test Account";
			this.btnTextAccount.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(237, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Message";
			// 
			// rtbMessage
			// 
			this.rtbMessage.Location = new System.Drawing.Point(240, 32);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbMessage.Size = new System.Drawing.Size(155, 108);
			this.rtbMessage.TabIndex = 8;
			this.rtbMessage.Text = "";
			// 
			// txtMailSubject
			// 
			this.txtMailSubject.Location = new System.Drawing.Point(97, 120);
			this.txtMailSubject.Name = "txtMailSubject";
			this.txtMailSubject.Size = new System.Drawing.Size(137, 20);
			this.txtMailSubject.TabIndex = 7;
			// 
			// txtMailCC
			// 
			this.txtMailCC.Location = new System.Drawing.Point(97, 89);
			this.txtMailCC.Name = "txtMailCC";
			this.txtMailCC.Size = new System.Drawing.Size(137, 20);
			this.txtMailCC.TabIndex = 6;
			// 
			// txtMailTo
			// 
			this.txtMailTo.Location = new System.Drawing.Point(97, 60);
			this.txtMailTo.Name = "txtMailTo";
			this.txtMailTo.Size = new System.Drawing.Size(137, 20);
			this.txtMailTo.TabIndex = 5;
			// 
			// txtMailFrom
			// 
			this.txtMailFrom.Location = new System.Drawing.Point(97, 32);
			this.txtMailFrom.Name = "txtMailFrom";
			this.txtMailFrom.Size = new System.Drawing.Size(137, 20);
			this.txtMailFrom.TabIndex = 4;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 123);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Subject :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 92);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(27, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "CC :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(26, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "To :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "From :";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.chkAttchImagePath);
			this.groupBox3.Controls.Add(this.cmbAttachImage);
			this.groupBox3.Controls.Add(this.cmbEmdImageSize);
			this.groupBox3.Controls.Add(this.txtEmdFrameSize);
			this.groupBox3.Controls.Add(this.txtNoticeIntval);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Location = new System.Drawing.Point(12, 299);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(410, 139);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "E-Mail Notice Setting";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(346, 55);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(47, 13);
			this.label14.TabIndex = 9;
			this.label14.Text = "(Frames)";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(240, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 13);
			this.label13.TabIndex = 8;
			this.label13.Text = "Minutes";
			// 
			// chkAttchImagePath
			// 
			this.chkAttchImagePath.AutoSize = true;
			this.chkAttchImagePath.Location = new System.Drawing.Point(20, 112);
			this.chkAttchImagePath.Name = "chkAttchImagePath";
			this.chkAttchImagePath.Size = new System.Drawing.Size(166, 17);
			this.chkAttchImagePath.TabIndex = 7;
			this.chkAttchImagePath.Text = "Attach Image Recording Path";
			this.chkAttchImagePath.UseVisualStyleBackColor = true;
			// 
			// cmbAttachImage
			// 
			this.cmbAttachImage.FormattingEnabled = true;
			this.cmbAttachImage.Items.AddRange(new object[] {
            "Camera1",
            "Camera2",
            "Camera3",
            "Camera4",
            "Camera5"});
			this.cmbAttachImage.Location = new System.Drawing.Point(240, 81);
			this.cmbAttachImage.Name = "cmbAttachImage";
			this.cmbAttachImage.Size = new System.Drawing.Size(100, 21);
			this.cmbAttachImage.TabIndex = 6;
			// 
			// cmbEmdImageSize
			// 
			this.cmbEmdImageSize.FormattingEnabled = true;
			this.cmbEmdImageSize.Items.AddRange(new object[] {
            "352*240",
            "176*120",
            "88*60",
            "Original"});
			this.cmbEmdImageSize.Location = new System.Drawing.Point(134, 52);
			this.cmbEmdImageSize.Name = "cmbEmdImageSize";
			this.cmbEmdImageSize.Size = new System.Drawing.Size(100, 21);
			this.cmbEmdImageSize.TabIndex = 5;
			// 
			// txtEmdFrameSize
			// 
			this.txtEmdFrameSize.Location = new System.Drawing.Point(240, 52);
			this.txtEmdFrameSize.Name = "txtEmdFrameSize";
			this.txtEmdFrameSize.Size = new System.Drawing.Size(100, 20);
			this.txtEmdFrameSize.TabIndex = 4;
			// 
			// txtNoticeIntval
			// 
			this.txtNoticeIntval.Location = new System.Drawing.Point(134, 24);
			this.txtNoticeIntval.Name = "txtNoticeIntval";
			this.txtNoticeIntval.Size = new System.Drawing.Size(100, 20);
			this.txtNoticeIntval.TabIndex = 3;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(17, 84);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(70, 13);
			this.label12.TabIndex = 2;
			this.label12.Text = "Attach Image";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(17, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(90, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "Embedded Image";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(76, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "Notice Interval";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.txtAutoDisconnet);
			this.groupBox4.Controls.Add(this.cmbAutoDial);
			this.groupBox4.Controls.Add(this.chkAutoDisconnet);
			this.groupBox4.Controls.Add(this.chkAutoDialup);
			this.groupBox4.Location = new System.Drawing.Point(12, 440);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(410, 78);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Modem Dial up Setting";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(346, 55);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(39, 13);
			this.label15.TabIndex = 4;
			this.label15.Text = "Minute";
			// 
			// txtAutoDisconnet
			// 
			this.txtAutoDisconnet.Location = new System.Drawing.Point(240, 52);
			this.txtAutoDisconnet.Name = "txtAutoDisconnet";
			this.txtAutoDisconnet.Size = new System.Drawing.Size(100, 20);
			this.txtAutoDisconnet.TabIndex = 3;
			// 
			// cmbAutoDial
			// 
			this.cmbAutoDial.FormattingEnabled = true;
			this.cmbAutoDial.Location = new System.Drawing.Point(240, 25);
			this.cmbAutoDial.Name = "cmbAutoDial";
			this.cmbAutoDial.Size = new System.Drawing.Size(100, 21);
			this.cmbAutoDial.TabIndex = 2;
			// 
			// chkAutoDisconnet
			// 
			this.chkAutoDisconnet.AutoSize = true;
			this.chkAutoDisconnet.Location = new System.Drawing.Point(20, 55);
			this.chkAutoDisconnet.Name = "chkAutoDisconnet";
			this.chkAutoDisconnet.Size = new System.Drawing.Size(136, 17);
			this.chkAutoDisconnet.TabIndex = 1;
			this.chkAutoDisconnet.Text = "Auto Disconnect After :";
			this.chkAutoDisconnet.UseVisualStyleBackColor = true;
			// 
			// chkAutoDialup
			// 
			this.chkAutoDialup.AutoSize = true;
			this.chkAutoDialup.Location = new System.Drawing.Point(20, 27);
			this.chkAutoDialup.Name = "chkAutoDialup";
			this.chkAutoDialup.Size = new System.Drawing.Size(84, 17);
			this.chkAutoDialup.TabIndex = 0;
			this.chkAutoDialup.Text = "Auto Dial up";
			this.chkAutoDialup.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(252, 529);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(347, 529);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmEmail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 561);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmEmail";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "E-mail Setting";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMailPassword;
        private System.Windows.Forms.TextBox txtMailID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.CheckBox chkAuthentication;
        private System.Windows.Forms.TextBox txtMailSeverPort;
        private System.Windows.Forms.TextBox txtMailSeverIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMailSubject;
        private System.Windows.Forms.TextBox txtMailCC;
        private System.Windows.Forms.TextBox txtMailTo;
        private System.Windows.Forms.TextBox txtMailFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnTextAccount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbAttachImage;
        private System.Windows.Forms.ComboBox cmbEmdImageSize;
        private System.Windows.Forms.TextBox txtEmdFrameSize;
        private System.Windows.Forms.TextBox txtNoticeIntval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkAttchImagePath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAutoDisconnet;
        private System.Windows.Forms.CheckBox chkAutoDialup;
        private System.Windows.Forms.ComboBox cmbAutoDial;
        private System.Windows.Forms.TextBox txtAutoDisconnet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
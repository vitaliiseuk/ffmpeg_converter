namespace iNVMSMain
{
    partial class FrmAlarmMMS
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
			this.btnEnterPincode = new System.Windows.Forms.Button();
			this.cmbComPort = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rtbSMSMessage = new System.Windows.Forms.RichTextBox();
			this.btnSMSTest = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.chkSMSEnable = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rtbMMSMessage = new System.Windows.Forms.RichTextBox();
			this.btnMMSTest = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnMMSExport = new System.Windows.Forms.Button();
			this.btnMMSImport = new System.Windows.Forms.Button();
			this.txtMMSC = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtMMSProxy = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtMMSAPN = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtMSResponse = new System.Windows.Forms.TextBox();
			this.txtMMSResult = new System.Windows.Forms.TextBox();
			this.txtMMSPassword = new System.Windows.Forms.TextBox();
			this.txtMMSLogin = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chkMMSEnable = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnEnterPincode);
			this.groupBox1.Controls.Add(this.cmbComPort);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(460, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Modem Setup";
			// 
			// btnEnterPincode
			// 
			this.btnEnterPincode.Location = new System.Drawing.Point(337, 18);
			this.btnEnterPincode.Name = "btnEnterPincode";
			this.btnEnterPincode.Size = new System.Drawing.Size(117, 23);
			this.btnEnterPincode.TabIndex = 2;
			this.btnEnterPincode.Text = "Enter Pincode";
			this.btnEnterPincode.UseVisualStyleBackColor = true;
			// 
			// cmbComPort
			// 
			this.cmbComPort.FormattingEnabled = true;
			this.cmbComPort.Location = new System.Drawing.Point(126, 20);
			this.cmbComPort.Name = "cmbComPort";
			this.cmbComPort.Size = new System.Drawing.Size(166, 21);
			this.cmbComPort.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "ComPort :";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtPhoneNumber);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 62);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(460, 46);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(126, 19);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(166, 20);
			this.txtPhoneNumber.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Phone Num :";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rtbSMSMessage);
			this.groupBox3.Controls.Add(this.btnSMSTest);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.chkSMSEnable);
			this.groupBox3.Location = new System.Drawing.Point(12, 111);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(460, 100);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "SMS Setting";
			// 
			// rtbSMSMessage
			// 
			this.rtbSMSMessage.Location = new System.Drawing.Point(126, 39);
			this.rtbSMSMessage.Name = "rtbSMSMessage";
			this.rtbSMSMessage.Size = new System.Drawing.Size(328, 55);
			this.rtbSMSMessage.TabIndex = 3;
			this.rtbSMSMessage.Text = "";
			// 
			// btnSMSTest
			// 
			this.btnSMSTest.Location = new System.Drawing.Point(18, 71);
			this.btnSMSTest.Name = "btnSMSTest";
			this.btnSMSTest.Size = new System.Drawing.Size(75, 23);
			this.btnSMSTest.TabIndex = 2;
			this.btnSMSTest.Text = "SMS Test";
			this.btnSMSTest.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Message Text :";
			// 
			// chkSMSEnable
			// 
			this.chkSMSEnable.AutoSize = true;
			this.chkSMSEnable.Location = new System.Drawing.Point(18, 19);
			this.chkSMSEnable.Name = "chkSMSEnable";
			this.chkSMSEnable.Size = new System.Drawing.Size(59, 17);
			this.chkSMSEnable.TabIndex = 0;
			this.chkSMSEnable.Text = "Enable";
			this.chkSMSEnable.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rtbMMSMessage);
			this.groupBox4.Controls.Add(this.btnMMSTest);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.comboBox1);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.txtSubject);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.btnMMSExport);
			this.groupBox4.Controls.Add(this.btnMMSImport);
			this.groupBox4.Controls.Add(this.txtMMSC);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.txtMMSProxy);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.txtMMSAPN);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.txtMSResponse);
			this.groupBox4.Controls.Add(this.txtMMSResult);
			this.groupBox4.Controls.Add(this.txtMMSPassword);
			this.groupBox4.Controls.Add(this.txtMMSLogin);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.chkMMSEnable);
			this.groupBox4.Location = new System.Drawing.Point(12, 214);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(460, 311);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "MMS Setting";
			// 
			// rtbMMSMessage
			// 
			this.rtbMMSMessage.Location = new System.Drawing.Point(125, 250);
			this.rtbMMSMessage.Name = "rtbMMSMessage";
			this.rtbMMSMessage.Size = new System.Drawing.Size(328, 55);
			this.rtbMMSMessage.TabIndex = 24;
			this.rtbMMSMessage.Text = "";
			// 
			// btnMMSTest
			// 
			this.btnMMSTest.Location = new System.Drawing.Point(18, 282);
			this.btnMMSTest.Name = "btnMMSTest";
			this.btnMMSTest.Size = new System.Drawing.Size(75, 23);
			this.btnMMSTest.TabIndex = 23;
			this.btnMMSTest.Text = "MMS Test";
			this.btnMMSTest.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(15, 250);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 13);
			this.label13.TabIndex = 22;
			this.label13.Text = "Message Text :";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
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
			this.comboBox1.Location = new System.Drawing.Point(337, 223);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(116, 21);
			this.comboBox1.TabIndex = 21;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 226);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(189, 13);
			this.label12.TabIndex = 20;
			this.label12.Text = "Attach Image when Sensor is triggered";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(126, 197);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(327, 20);
			this.txtSubject.TabIndex = 19;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(15, 200);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(49, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "Subject :";
			// 
			// btnMMSExport
			// 
			this.btnMMSExport.Location = new System.Drawing.Point(337, 168);
			this.btnMMSExport.Name = "btnMMSExport";
			this.btnMMSExport.Size = new System.Drawing.Size(116, 23);
			this.btnMMSExport.TabIndex = 17;
			this.btnMMSExport.Text = "Export...";
			this.btnMMSExport.UseVisualStyleBackColor = true;
			this.btnMMSExport.Click += new System.EventHandler(this.btnMMSExport_Click);
			// 
			// btnMMSImport
			// 
			this.btnMMSImport.Location = new System.Drawing.Point(126, 168);
			this.btnMMSImport.Name = "btnMMSImport";
			this.btnMMSImport.Size = new System.Drawing.Size(117, 23);
			this.btnMMSImport.TabIndex = 16;
			this.btnMMSImport.Text = "Import...";
			this.btnMMSImport.UseVisualStyleBackColor = true;
			this.btnMMSImport.Click += new System.EventHandler(this.btnMMSImport_Click);
			// 
			// txtMMSC
			// 
			this.txtMMSC.Location = new System.Drawing.Point(126, 142);
			this.txtMMSC.Name = "txtMMSC";
			this.txtMMSC.Size = new System.Drawing.Size(327, 20);
			this.txtMMSC.TabIndex = 15;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(15, 145);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(45, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "MMSC :";
			// 
			// txtMMSProxy
			// 
			this.txtMMSProxy.Location = new System.Drawing.Point(126, 116);
			this.txtMMSProxy.Name = "txtMMSProxy";
			this.txtMMSProxy.Size = new System.Drawing.Size(327, 20);
			this.txtMMSProxy.TabIndex = 13;
			this.txtMMSProxy.Text = "10.1.1.1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "VMP Proxy :";
			// 
			// txtMMSAPN
			// 
			this.txtMMSAPN.Location = new System.Drawing.Point(126, 90);
			this.txtMMSAPN.Name = "txtMMSAPN";
			this.txtMMSAPN.Size = new System.Drawing.Size(327, 20);
			this.txtMMSAPN.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "APN :";
			// 
			// txtMSResponse
			// 
			this.txtMSResponse.Enabled = false;
			this.txtMSResponse.Location = new System.Drawing.Point(337, 58);
			this.txtMSResponse.Name = "txtMSResponse";
			this.txtMSResponse.Size = new System.Drawing.Size(117, 20);
			this.txtMSResponse.TabIndex = 9;
			this.txtMSResponse.Text = "N/A";
			// 
			// txtMMSResult
			// 
			this.txtMMSResult.Enabled = false;
			this.txtMMSResult.Location = new System.Drawing.Point(337, 32);
			this.txtMMSResult.Name = "txtMMSResult";
			this.txtMMSResult.Size = new System.Drawing.Size(116, 20);
			this.txtMMSResult.TabIndex = 8;
			this.txtMMSResult.Text = "N/A";
			// 
			// txtMMSPassword
			// 
			this.txtMMSPassword.Location = new System.Drawing.Point(126, 64);
			this.txtMMSPassword.Name = "txtMMSPassword";
			this.txtMMSPassword.Size = new System.Drawing.Size(117, 20);
			this.txtMMSPassword.TabIndex = 7;
			// 
			// txtMMSLogin
			// 
			this.txtMMSLogin.Location = new System.Drawing.Point(126, 36);
			this.txtMMSLogin.Name = "txtMMSLogin";
			this.txtMMSLogin.Size = new System.Drawing.Size(117, 20);
			this.txtMMSLogin.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(262, 67);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Response :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(262, 39);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Result :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Password :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Login :";
			// 
			// chkMMSEnable
			// 
			this.chkMMSEnable.AutoSize = true;
			this.chkMMSEnable.Location = new System.Drawing.Point(18, 19);
			this.chkMMSEnable.Name = "chkMMSEnable";
			this.chkMMSEnable.Size = new System.Drawing.Size(59, 17);
			this.chkMMSEnable.TabIndex = 1;
			this.chkMMSEnable.Text = "Enable";
			this.chkMMSEnable.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(390, 531);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(306, 531);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmMMS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 561);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmMMS";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmAlarmMMS";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnterPincode;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSMSEnable;
        private System.Windows.Forms.Button btnSMSTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbSMSMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkMMSEnable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMSResponse;
        private System.Windows.Forms.TextBox txtMMSResult;
        private System.Windows.Forms.TextBox txtMMSPassword;
        private System.Windows.Forms.TextBox txtMMSLogin;
        private System.Windows.Forms.TextBox txtMMSC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMMSProxy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMMSAPN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMMSExport;
        private System.Windows.Forms.Button btnMMSImport;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtbMMSMessage;
        private System.Windows.Forms.Button btnMMSTest;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
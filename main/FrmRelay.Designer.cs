namespace iNVMSMain
{
    partial class FrmRelay
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
            this.cmbRelay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApplyToAll = new System.Windows.Forms.Button();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.btnExternIO = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.txtInputNo = new System.Windows.Forms.TextBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbTest = new System.Windows.Forms.GroupBox();
            this.ptbTest = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRetrieveTime = new System.Windows.Forms.TextBox();
            this.txtIntervalTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPulseTrigEnable = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTest)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRelay
            // 
            this.cmbRelay.FormattingEnabled = true;
            this.cmbRelay.Location = new System.Drawing.Point(12, 12);
            this.cmbRelay.Name = "cmbRelay";
            this.cmbRelay.Size = new System.Drawing.Size(310, 21);
            this.cmbRelay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(135, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(187, 20);
            this.txtName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApplyToAll);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 54);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Location = new System.Drawing.Point(123, 20);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(75, 23);
            this.btnApplyToAll.TabIndex = 1;
            this.btnApplyToAll.Text = "Apply to All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(6, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(59, 17);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // btnExternIO
            // 
            this.btnExternIO.Location = new System.Drawing.Point(247, 87);
            this.btnExternIO.Name = "btnExternIO";
            this.btnExternIO.Size = new System.Drawing.Size(75, 23);
            this.btnExternIO.TabIndex = 4;
            this.btnExternIO.Text = "External IO";
            this.btnExternIO.UseVisualStyleBackColor = true;
            this.btnExternIO.Click += new System.EventHandler(this.btnExternIO_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbDescription);
            this.groupBox2.Controls.Add(this.txtInputNo);
            this.groupBox2.Controls.Add(this.txtCardNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 118);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Content";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(123, 74);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(181, 37);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // txtInputNo
            // 
            this.txtInputNo.Location = new System.Drawing.Point(123, 48);
            this.txtInputNo.Name = "txtInputNo";
            this.txtInputNo.Size = new System.Drawing.Size(100, 20);
            this.txtInputNo.TabIndex = 4;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(123, 22);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(100, 20);
            this.txtCardNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Input No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Card No.";
            // 
            // grbTest
            // 
            this.grbTest.Controls.Add(this.ptbTest);
            this.grbTest.Controls.Add(this.btnTest);
            this.grbTest.Enabled = false;
            this.grbTest.Location = new System.Drawing.Point(12, 244);
            this.grbTest.Name = "grbTest";
            this.grbTest.Size = new System.Drawing.Size(310, 87);
            this.grbTest.TabIndex = 6;
            this.grbTest.TabStop = false;
            this.grbTest.Text = "Test";
            // 
            // ptbTest
            // 
            this.ptbTest.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ptbTest.Location = new System.Drawing.Point(30, 25);
            this.ptbTest.Name = "ptbTest";
            this.ptbTest.Size = new System.Drawing.Size(100, 50);
            this.ptbTest.TabIndex = 2;
            this.ptbTest.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(148, 39);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRetrieveTime);
            this.groupBox4.Controls.Add(this.txtIntervalTime);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.chkPulseTrigEnable);
            this.groupBox4.Location = new System.Drawing.Point(12, 334);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 106);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pulse Trigger";
            // 
            // txtRetrieveTime
            // 
            this.txtRetrieveTime.Location = new System.Drawing.Point(123, 72);
            this.txtRetrieveTime.Name = "txtRetrieveTime";
            this.txtRetrieveTime.Size = new System.Drawing.Size(100, 20);
            this.txtRetrieveTime.TabIndex = 6;
            // 
            // txtIntervalTime
            // 
            this.txtIntervalTime.Location = new System.Drawing.Point(123, 46);
            this.txtIntervalTime.Name = "txtIntervalTime";
            this.txtIntervalTime.Size = new System.Drawing.Size(100, 20);
            this.txtIntervalTime.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sec.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Sec.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Retrieve Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Interval Time";
            // 
            // chkPulseTrigEnable
            // 
            this.chkPulseTrigEnable.AutoSize = true;
            this.chkPulseTrigEnable.Enabled = false;
            this.chkPulseTrigEnable.Location = new System.Drawing.Point(6, 24);
            this.chkPulseTrigEnable.Name = "chkPulseTrigEnable";
            this.chkPulseTrigEnable.Size = new System.Drawing.Size(124, 17);
            this.chkPulseTrigEnable.TabIndex = 0;
            this.chkPulseTrigEnable.Text = "Enable Pulse Trigger";
            this.chkPulseTrigEnable.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(247, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 459);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmRelay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 491);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExternIO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRelay);
            this.MaximizeBox = false;
            this.Name = "FrmRelay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relay Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTest)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApplyToAll;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Button btnExternIO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox txtInputNo;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.GroupBox grbTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtRetrieveTime;
        private System.Windows.Forms.TextBox txtIntervalTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkPulseTrigEnable;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox ptbTest;
    }
}
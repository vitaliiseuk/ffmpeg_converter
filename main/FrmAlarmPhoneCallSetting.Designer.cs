namespace iNVMSMain
{
    partial class FrmAlarmPhoneCallSetting
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
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnVoiceRecord = new System.Windows.Forms.Button();
			this.btnVoiceFilePath = new System.Windows.Forms.Button();
			this.txtVoiceFilePath = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Phone Number";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Description";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(129, 24);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(143, 20);
			this.txtPhoneNumber.TabIndex = 2;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(129, 50);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(143, 20);
			this.txtDescription.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnVoiceRecord);
			this.groupBox1.Controls.Add(this.btnVoiceFilePath);
			this.groupBox1.Controls.Add(this.txtVoiceFilePath);
			this.groupBox1.Location = new System.Drawing.Point(12, 85);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 80);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Voice File";
			// 
			// btnVoiceRecord
			// 
			this.btnVoiceRecord.Location = new System.Drawing.Point(13, 50);
			this.btnVoiceRecord.Name = "btnVoiceRecord";
			this.btnVoiceRecord.Size = new System.Drawing.Size(75, 23);
			this.btnVoiceRecord.TabIndex = 2;
			this.btnVoiceRecord.Text = "Record";
			this.btnVoiceRecord.UseVisualStyleBackColor = true;
			this.btnVoiceRecord.Click += new System.EventHandler(this.btnVoiceRecord_Click);
			// 
			// btnVoiceFilePath
			// 
			this.btnVoiceFilePath.Location = new System.Drawing.Point(217, 22);
			this.btnVoiceFilePath.Name = "btnVoiceFilePath";
			this.btnVoiceFilePath.Size = new System.Drawing.Size(37, 23);
			this.btnVoiceFilePath.TabIndex = 1;
			this.btnVoiceFilePath.Text = "...";
			this.btnVoiceFilePath.UseVisualStyleBackColor = true;
			this.btnVoiceFilePath.Click += new System.EventHandler(this.btnVoiceFilePath_Click);
			// 
			// txtVoiceFilePath
			// 
			this.txtVoiceFilePath.Location = new System.Drawing.Point(13, 24);
			this.txtVoiceFilePath.Name = "txtVoiceFilePath";
			this.txtVoiceFilePath.Size = new System.Drawing.Size(197, 20);
			this.txtVoiceFilePath.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(208, 171);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(129, 171);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(63, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmPhoneCallSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 201);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtPhoneNumber);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmPhoneCallSetting";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Call Out Setting";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoiceRecord;
        private System.Windows.Forms.Button btnVoiceFilePath;
        private System.Windows.Forms.TextBox txtVoiceFilePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
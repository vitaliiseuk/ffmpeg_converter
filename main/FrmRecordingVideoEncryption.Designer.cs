namespace iNVMSMain
{
    partial class FrmRecordingVideoEncryption
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.chkPasswordShow = new System.Windows.Forms.CheckBox();
            this.rtbPasswordWarning = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(260, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Confirm Password :";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(12, 85);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(260, 20);
            this.txtPasswordConfirm.TabIndex = 1;
            // 
            // chkPasswordShow
            // 
            this.chkPasswordShow.AutoSize = true;
            this.chkPasswordShow.Location = new System.Drawing.Point(15, 111);
            this.chkPasswordShow.Name = "chkPasswordShow";
            this.chkPasswordShow.Size = new System.Drawing.Size(102, 17);
            this.chkPasswordShow.TabIndex = 2;
            this.chkPasswordShow.Text = "Show Password";
            this.chkPasswordShow.UseVisualStyleBackColor = true;
            // 
            // rtbPasswordWarning
            // 
            this.rtbPasswordWarning.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rtbPasswordWarning.Enabled = false;
            this.rtbPasswordWarning.Location = new System.Drawing.Point(12, 140);
            this.rtbPasswordWarning.Name = "rtbPasswordWarning";
            this.rtbPasswordWarning.Size = new System.Drawing.Size(257, 80);
            this.rtbPasswordWarning.TabIndex = 3;
            this.rtbPasswordWarning.Text = "Warning:\nKindly note down your password. It is not possible to decode video strea" +
                "m with invalid password. Password once lost can not be recovered.\n";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(194, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(113, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmRecordingVideoEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbPasswordWarning);
            this.Controls.Add(this.chkPasswordShow);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmRecordingVideoEncryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmRecordingVideoEncryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.CheckBox chkPasswordShow;
        private System.Windows.Forms.RichTextBox rtbPasswordWarning;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
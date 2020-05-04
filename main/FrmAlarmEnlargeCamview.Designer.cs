namespace iNVMSMain
{
    partial class FrmAlarmEnlargeCamview
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
			this.cmbCameraSelect = new System.Windows.Forms.ComboBox();
			this.rdbOneChannel = new System.Windows.Forms.RadioButton();
			this.rdbFullChannel = new System.Windows.Forms.RadioButton();
			this.txtRetrieveTime = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkRetrieveTime = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbCameraSelect
			// 
			this.cmbCameraSelect.FormattingEnabled = true;
			this.cmbCameraSelect.Items.AddRange(new object[] {
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
			this.cmbCameraSelect.Location = new System.Drawing.Point(12, 22);
			this.cmbCameraSelect.Name = "cmbCameraSelect";
			this.cmbCameraSelect.Size = new System.Drawing.Size(138, 21);
			this.cmbCameraSelect.TabIndex = 0;
			// 
			// rdbOneChannel
			// 
			this.rdbOneChannel.AutoSize = true;
			this.rdbOneChannel.Location = new System.Drawing.Point(30, 61);
			this.rdbOneChannel.Name = "rdbOneChannel";
			this.rdbOneChannel.Size = new System.Drawing.Size(73, 17);
			this.rdbOneChannel.TabIndex = 1;
			this.rdbOneChannel.TabStop = true;
			this.rdbOneChannel.Text = "1 Channel";
			this.rdbOneChannel.UseVisualStyleBackColor = true;
			// 
			// rdbFullChannel
			// 
			this.rdbFullChannel.AutoSize = true;
			this.rdbFullChannel.Location = new System.Drawing.Point(177, 61);
			this.rdbFullChannel.Name = "rdbFullChannel";
			this.rdbFullChannel.Size = new System.Drawing.Size(83, 17);
			this.rdbFullChannel.TabIndex = 2;
			this.rdbFullChannel.TabStop = true;
			this.rdbFullChannel.Text = "Full Channel";
			this.rdbFullChannel.UseVisualStyleBackColor = true;
			// 
			// txtRetrieveTime
			// 
			this.txtRetrieveTime.Enabled = false;
			this.txtRetrieveTime.Location = new System.Drawing.Point(144, 90);
			this.txtRetrieveTime.Name = "txtRetrieveTime";
			this.txtRetrieveTime.Size = new System.Drawing.Size(75, 20);
			this.txtRetrieveTime.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(222, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Sec.";
			// 
			// chkRetrieveTime
			// 
			this.chkRetrieveTime.AutoSize = true;
			this.chkRetrieveTime.Location = new System.Drawing.Point(30, 92);
			this.chkRetrieveTime.Name = "chkRetrieveTime";
			this.chkRetrieveTime.Size = new System.Drawing.Size(92, 17);
			this.chkRetrieveTime.TabIndex = 5;
			this.chkRetrieveTime.Text = "Retrieve Time";
			this.chkRetrieveTime.UseVisualStyleBackColor = true;
			this.chkRetrieveTime.CheckedChanged += new System.EventHandler(this.chkRetrieveTime_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(63, 126);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(144, 126);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmEnlargeCamview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 161);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkRetrieveTime);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRetrieveTime);
			this.Controls.Add(this.rdbFullChannel);
			this.Controls.Add(this.rdbOneChannel);
			this.Controls.Add(this.cmbCameraSelect);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmEnlargeCamview";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enlarge Camera View";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCameraSelect;
        private System.Windows.Forms.RadioButton rdbOneChannel;
        private System.Windows.Forms.RadioButton rdbFullChannel;
        private System.Windows.Forms.TextBox txtRetrieveTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRetrieveTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
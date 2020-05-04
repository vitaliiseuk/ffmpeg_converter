namespace iNVMSMain
{
    partial class FrmNetworkBandwidth
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
            this.rdbByChannel = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.grbByChannel = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbByChannelRate = new System.Windows.Forms.ComboBox();
            this.cmbByChannelCam = new System.Windows.Forms.ComboBox();
            this.grbAll = new System.Windows.Forms.GroupBox();
            this.txtTotalLimit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grbByChannel.SuspendLayout();
            this.grbAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbByChannel
            // 
            this.rdbByChannel.AutoSize = true;
            this.rdbByChannel.Location = new System.Drawing.Point(12, 12);
            this.rdbByChannel.Name = "rdbByChannel";
            this.rdbByChannel.Size = new System.Drawing.Size(79, 17);
            this.rdbByChannel.TabIndex = 0;
            this.rdbByChannel.Text = "By Channel";
            this.rdbByChannel.UseVisualStyleBackColor = true;
            this.rdbByChannel.CheckedChanged += new System.EventHandler(this.rdbByChannel_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(12, 106);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.Click += new System.EventHandler(this.rdbAll_Click);
            // 
            // grbByChannel
            // 
            this.grbByChannel.Controls.Add(this.label1);
            this.grbByChannel.Controls.Add(this.cmbByChannelRate);
            this.grbByChannel.Controls.Add(this.cmbByChannelCam);
            this.grbByChannel.Location = new System.Drawing.Point(23, 35);
            this.grbByChannel.Name = "grbByChannel";
            this.grbByChannel.Size = new System.Drawing.Size(249, 59);
            this.grbByChannel.TabIndex = 1;
            this.grbByChannel.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "KB/s";
            // 
            // cmbByChannelRate
            // 
            this.cmbByChannelRate.FormattingEnabled = true;
            this.cmbByChannelRate.Location = new System.Drawing.Point(133, 20);
            this.cmbByChannelRate.Name = "cmbByChannelRate";
            this.cmbByChannelRate.Size = new System.Drawing.Size(73, 21);
            this.cmbByChannelRate.TabIndex = 2;
            // 
            // cmbByChannelCam
            // 
            this.cmbByChannelCam.FormattingEnabled = true;
            this.cmbByChannelCam.Location = new System.Drawing.Point(6, 20);
            this.cmbByChannelCam.Name = "cmbByChannelCam";
            this.cmbByChannelCam.Size = new System.Drawing.Size(121, 21);
            this.cmbByChannelCam.TabIndex = 2;
            // 
            // grbAll
            // 
            this.grbAll.Controls.Add(this.txtTotalLimit);
            this.grbAll.Controls.Add(this.label3);
            this.grbAll.Controls.Add(this.label2);
            this.grbAll.Enabled = false;
            this.grbAll.Location = new System.Drawing.Point(23, 128);
            this.grbAll.Name = "grbAll";
            this.grbAll.Size = new System.Drawing.Size(249, 60);
            this.grbAll.TabIndex = 2;
            this.grbAll.TabStop = false;
            // 
            // txtTotalLimit
            // 
            this.txtTotalLimit.Location = new System.Drawing.Point(133, 25);
            this.txtTotalLimit.Name = "txtTotalLimit";
            this.txtTotalLimit.Size = new System.Drawing.Size(73, 20);
            this.txtTotalLimit.TabIndex = 1;
            this.txtTotalLimit.Text = "1024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "KB/s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Limit";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmNetworkBandwidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbAll);
            this.Controls.Add(this.grbByChannel);
            this.Controls.Add(this.rdbAll);
            this.Controls.Add(this.rdbByChannel);
            this.MaximizeBox = false;
            this.Name = "FrmNetworkBandwidth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bandwidth Setting";
            this.grbByChannel.ResumeLayout(false);
            this.grbByChannel.PerformLayout();
            this.grbAll.ResumeLayout(false);
            this.grbAll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbByChannel;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.GroupBox grbByChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbByChannelRate;
        private System.Windows.Forms.ComboBox cmbByChannelCam;
        private System.Windows.Forms.GroupBox grbAll;
        private System.Windows.Forms.TextBox txtTotalLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
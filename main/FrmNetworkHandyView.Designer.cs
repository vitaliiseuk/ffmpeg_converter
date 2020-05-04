namespace iNVMSMain
{
    partial class FrmNetworkHandyView
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
            this.rdbVideoSize3 = new System.Windows.Forms.RadioButton();
            this.rdbVideoSize2 = new System.Windows.Forms.RadioButton();
            this.rdbVideoSize1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.trackQuality = new System.Windows.Forms.TrackBar();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVideoSize3);
            this.groupBox1.Controls.Add(this.rdbVideoSize2);
            this.groupBox1.Controls.Add(this.rdbVideoSize1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video Size";
            // 
            // rdbVideoSize3
            // 
            this.rdbVideoSize3.AutoSize = true;
            this.rdbVideoSize3.Location = new System.Drawing.Point(268, 26);
            this.rdbVideoSize3.Name = "rdbVideoSize3";
            this.rdbVideoSize3.Size = new System.Drawing.Size(53, 17);
            this.rdbVideoSize3.TabIndex = 0;
            this.rdbVideoSize3.TabStop = true;
            this.rdbVideoSize3.Text = "88*60";
            this.rdbVideoSize3.UseVisualStyleBackColor = true;
            this.rdbVideoSize3.Click += new System.EventHandler(this.rdbVideoSize3_Click);
            // 
            // rdbVideoSize2
            // 
            this.rdbVideoSize2.AutoSize = true;
            this.rdbVideoSize2.Location = new System.Drawing.Point(151, 26);
            this.rdbVideoSize2.Name = "rdbVideoSize2";
            this.rdbVideoSize2.Size = new System.Drawing.Size(65, 17);
            this.rdbVideoSize2.TabIndex = 0;
            this.rdbVideoSize2.TabStop = true;
            this.rdbVideoSize2.Text = "176*120";
            this.rdbVideoSize2.UseVisualStyleBackColor = true;
            this.rdbVideoSize2.Click += new System.EventHandler(this.rdbVideoSize2_Click);
            // 
            // rdbVideoSize1
            // 
            this.rdbVideoSize1.AutoSize = true;
            this.rdbVideoSize1.Location = new System.Drawing.Point(32, 26);
            this.rdbVideoSize1.Name = "rdbVideoSize1";
            this.rdbVideoSize1.Size = new System.Drawing.Size(65, 17);
            this.rdbVideoSize1.TabIndex = 0;
            this.rdbVideoSize1.TabStop = true;
            this.rdbVideoSize1.Text = "352*240";
            this.rdbVideoSize1.UseVisualStyleBackColor = true;
            this.rdbVideoSize1.Click += new System.EventHandler(this.rdbVideoSize1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuality);
            this.groupBox2.Controls.Add(this.trackQuality);
            this.groupBox2.Location = new System.Drawing.Point(12, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quality";
            // 
            // txtQuality
            // 
            this.txtQuality.Location = new System.Drawing.Point(268, 30);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(86, 20);
            this.txtQuality.TabIndex = 1;
            this.txtQuality.Text = "70";
            // 
            // trackQuality
            // 
            this.trackQuality.Location = new System.Drawing.Point(16, 30);
            this.trackQuality.Maximum = 100;
            this.trackQuality.Name = "trackQuality";
            this.trackQuality.Size = new System.Drawing.Size(230, 45);
            this.trackQuality.TabIndex = 0;
            this.trackQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackQuality.Value = 70;
            this.trackQuality.Scroll += new System.EventHandler(this.trackQuality_Scroll);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(297, 176);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(135, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmNetworkHandyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 206);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmNetworkHandyView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JPEG Setting";
            this.Load += new System.EventHandler(this.FrmNetworkHandyView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbVideoSize3;
        private System.Windows.Forms.RadioButton rdbVideoSize2;
        private System.Windows.Forms.RadioButton rdbVideoSize1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackQuality;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
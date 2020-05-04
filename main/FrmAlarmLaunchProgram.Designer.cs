namespace iNVMSMain
{
    partial class FrmAlarmLaunchProgram
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
			this.chkMultipleInstance = new System.Windows.Forms.CheckBox();
			this.grbProgramPath = new System.Windows.Forms.GroupBox();
			this.txtProgramPath = new System.Windows.Forms.TextBox();
			this.btnProgramPath = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grbProgramPath.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkMultipleInstance
			// 
			this.chkMultipleInstance.AutoSize = true;
			this.chkMultipleInstance.Location = new System.Drawing.Point(12, 22);
			this.chkMultipleInstance.Name = "chkMultipleInstance";
			this.chkMultipleInstance.Size = new System.Drawing.Size(111, 17);
			this.chkMultipleInstance.TabIndex = 0;
			this.chkMultipleInstance.Text = "Multiple Instances";
			this.chkMultipleInstance.UseVisualStyleBackColor = true;
			this.chkMultipleInstance.CheckedChanged += new System.EventHandler(this.chkMultipleInstance_CheckedChanged);
			// 
			// grbProgramPath
			// 
			this.grbProgramPath.Controls.Add(this.txtProgramPath);
			this.grbProgramPath.Controls.Add(this.btnProgramPath);
			this.grbProgramPath.Enabled = false;
			this.grbProgramPath.Location = new System.Drawing.Point(12, 49);
			this.grbProgramPath.Name = "grbProgramPath";
			this.grbProgramPath.Size = new System.Drawing.Size(310, 59);
			this.grbProgramPath.TabIndex = 1;
			this.grbProgramPath.TabStop = false;
			this.grbProgramPath.Text = "Program Path";
			// 
			// txtProgramPath
			// 
			this.txtProgramPath.Location = new System.Drawing.Point(11, 22);
			this.txtProgramPath.Name = "txtProgramPath";
			this.txtProgramPath.Size = new System.Drawing.Size(253, 20);
			this.txtProgramPath.TabIndex = 1;
			// 
			// btnProgramPath
			// 
			this.btnProgramPath.Location = new System.Drawing.Point(270, 21);
			this.btnProgramPath.Name = "btnProgramPath";
			this.btnProgramPath.Size = new System.Drawing.Size(34, 23);
			this.btnProgramPath.TabIndex = 0;
			this.btnProgramPath.Text = "...";
			this.btnProgramPath.UseVisualStyleBackColor = true;
			this.btnProgramPath.Click += new System.EventHandler(this.btnProgramPath_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(247, 126);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(166, 126);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmLaunchProgram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 161);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.grbProgramPath);
			this.Controls.Add(this.chkMultipleInstance);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmLaunchProgram";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Launch Program Setting";
			this.grbProgramPath.ResumeLayout(false);
			this.grbProgramPath.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMultipleInstance;
        private System.Windows.Forms.GroupBox grbProgramPath;
        private System.Windows.Forms.Button btnProgramPath;
        private System.Windows.Forms.TextBox txtProgramPath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
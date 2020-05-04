namespace iNVMSMain
{
	partial class FrmAlertLog
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(6, 19);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(523, 208);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(436, 250);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(96, 26);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(314, 250);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(96, 26);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Location = new System.Drawing.Point(2, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(538, 235);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Event";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(198, 250);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 26);
			this.button1.TabIndex = 4;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// FrmAlertLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 290);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmAlertLog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Alert Status";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
	}
}
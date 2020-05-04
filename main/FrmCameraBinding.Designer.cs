namespace iNVMSMain
{
	partial class FrmCameraBinding
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.nvmsPlayerController = new iNVMS.CustomControl.NVMSPlayerController();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnAutoBind = new System.Windows.Forms.Button();
			this.btnUnbindAll = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(902, 550);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(89, 27);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(1011, 550);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(89, 27);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.panel1.Controls.Add(this.nvmsPlayerController);
			this.panel1.Location = new System.Drawing.Point(16, 51);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1084, 490);
			this.panel1.TabIndex = 4;
			// 
			// nvmsPlayerController
			// 
			this.nvmsPlayerController.ActivePlayerUpdated = false;
			this.nvmsPlayerController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nvmsPlayerController.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.nvmsPlayerController.BindMode = false;
			this.nvmsPlayerController.DragState = iNVMS.CustomControl.DragStateEnum.Move;
			this.nvmsPlayerController.IsRecording = false;
			this.nvmsPlayerController.IsStreamming = false;
			this.nvmsPlayerController.Location = new System.Drawing.Point(3, 3);
			this.nvmsPlayerController.Name = "nvmsPlayerController";
			this.nvmsPlayerController.SelectedPlayerIndex = -1;
			this.nvmsPlayerController.Size = new System.Drawing.Size(1078, 484);
			this.nvmsPlayerController.TabIndex = 0;
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(14, 12);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(21, 30);
			this.btnPrev.TabIndex = 7;
			this.btnPrev.Text = "<";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(912, 11);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(21, 30);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = ">";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnAutoBind
			// 
			this.btnAutoBind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutoBind.Location = new System.Drawing.Point(939, 11);
			this.btnAutoBind.Name = "btnAutoBind";
			this.btnAutoBind.Size = new System.Drawing.Size(74, 29);
			this.btnAutoBind.TabIndex = 9;
			this.btnAutoBind.Text = "AutoBind";
			this.btnAutoBind.UseVisualStyleBackColor = true;
			this.btnAutoBind.Click += new System.EventHandler(this.btnAutoBind_Click);
			// 
			// btnUnbindAll
			// 
			this.btnUnbindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnbindAll.Location = new System.Drawing.Point(1023, 11);
			this.btnUnbindAll.Name = "btnUnbindAll";
			this.btnUnbindAll.Size = new System.Drawing.Size(74, 29);
			this.btnUnbindAll.TabIndex = 10;
			this.btnUnbindAll.Text = "Unbind All";
			this.btnUnbindAll.UseVisualStyleBackColor = true;
			this.btnUnbindAll.Click += new System.EventHandler(this.btnUnbindAll_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtAddress);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(17, 544);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(754, 38);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(558, 13);
			this.txtPort.Name = "txtPort";
			this.txtPort.ReadOnly = true;
			this.txtPort.Size = new System.Drawing.Size(159, 20);
			this.txtPort.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(523, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Port";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(333, 13);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.ReadOnly = true;
			this.txtAddress.Size = new System.Drawing.Size(175, 20);
			this.txtAddress.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(282, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Address";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(104, 12);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(159, 20);
			this.txtName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(62, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// FrmCameraBinding
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1112, 584);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnUnbindAll);
			this.Controls.Add(this.btnAutoBind);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "FrmCameraBinding";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CameraBinding";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.Form_Shown);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private iNVMS.CustomControl.NVMSPlayerController nvmsPlayerController;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnAutoBind;
		private System.Windows.Forms.Button btnUnbindAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
	}
}
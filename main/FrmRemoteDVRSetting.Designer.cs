namespace iNVMSMain
{
    partial class FrmRemoteDVRSetting
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
			this.lblIP = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbChannel = new System.Windows.Forms.ComboBox();
			this.cmbManufacture = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.lblUserID = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnPrevChannel = new System.Windows.Forms.Button();
			this.btnNextChannel = new System.Windows.Forms.Button();
			this.txtPreviewChannel = new System.Windows.Forms.TextBox();
			this.btnKeyboard = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.nvmsPlayer = new iNVMS.CustomControl.NVMSPlayer(this);
			this.SuspendLayout();
			// 
			// lblIP
			// 
			this.lblIP.AutoSize = true;
			this.lblIP.Location = new System.Drawing.Point(19, 55);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(17, 13);
			this.lblIP.TabIndex = 0;
			this.lblIP.Text = "IP";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbChannel);
			this.groupBox1.Controls.Add(this.cmbManufacture);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtUserID);
			this.groupBox1.Controls.Add(this.lblUserID);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtIP);
			this.groupBox1.Controls.Add(this.lblIP);
			this.groupBox1.Location = new System.Drawing.Point(9, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(308, 244);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// cmbChannel
			// 
			this.cmbChannel.FormattingEnabled = true;
			this.cmbChannel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
			this.cmbChannel.Location = new System.Drawing.Point(95, 202);
			this.cmbChannel.Name = "cmbChannel";
			this.cmbChannel.Size = new System.Drawing.Size(195, 21);
			this.cmbChannel.TabIndex = 12;
			// 
			// cmbManufacture
			// 
			this.cmbManufacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbManufacture.FormattingEnabled = true;
			this.cmbManufacture.Items.AddRange(new object[] {
            "iLinkPro iHD Series",
            "XM XVR",
            "AVer NV Series"});
			this.cmbManufacture.Location = new System.Drawing.Point(95, 15);
			this.cmbManufacture.Name = "cmbManufacture";
			this.cmbManufacture.Size = new System.Drawing.Size(196, 21);
			this.cmbManufacture.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Manufacture";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Channel";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(95, 163);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(196, 20);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Text = "123456";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Password";
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(95, 125);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(196, 20);
			this.txtUserID.TabIndex = 5;
			this.txtUserID.Text = "admin";
			// 
			// lblUserID
			// 
			this.lblUserID.AutoSize = true;
			this.lblUserID.Location = new System.Drawing.Point(19, 127);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(43, 13);
			this.lblUserID.TabIndex = 4;
			this.lblUserID.Text = "User ID";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(95, 87);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(196, 20);
			this.txtPort.TabIndex = 3;
			this.txtPort.Text = "34567";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Port";
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(95, 51);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(196, 20);
			this.txtIP.TabIndex = 1;
			this.txtIP.Text = "50.73.87.211";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(47, 256);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 26);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "Save && Exit";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(237, 256);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(142, 256);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(80, 26);
			this.btnConnect.TabIndex = 4;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnPrevChannel
			// 
			this.btnPrevChannel.Location = new System.Drawing.Point(458, 257);
			this.btnPrevChannel.Name = "btnPrevChannel";
			this.btnPrevChannel.Size = new System.Drawing.Size(23, 23);
			this.btnPrevChannel.TabIndex = 16;
			this.btnPrevChannel.Text = "<";
			this.btnPrevChannel.UseVisualStyleBackColor = true;
			this.btnPrevChannel.Visible = false;
			this.btnPrevChannel.Click += new System.EventHandler(this.btnPrevChannel_Click);
			// 
			// btnNextChannel
			// 
			this.btnNextChannel.Location = new System.Drawing.Point(538, 257);
			this.btnNextChannel.Name = "btnNextChannel";
			this.btnNextChannel.Size = new System.Drawing.Size(23, 23);
			this.btnNextChannel.TabIndex = 17;
			this.btnNextChannel.Text = ">";
			this.btnNextChannel.UseVisualStyleBackColor = true;
			this.btnNextChannel.Visible = false;
			this.btnNextChannel.Click += new System.EventHandler(this.btnNextChannel_Click);
			// 
			// txtPreviewChannel
			// 
			this.txtPreviewChannel.Location = new System.Drawing.Point(487, 259);
			this.txtPreviewChannel.Name = "txtPreviewChannel";
			this.txtPreviewChannel.ReadOnly = true;
			this.txtPreviewChannel.Size = new System.Drawing.Size(46, 20);
			this.txtPreviewChannel.TabIndex = 18;
			this.txtPreviewChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPreviewChannel.Visible = false;
			// 
			// btnKeyboard
			// 
			this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
			this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnKeyboard.Location = new System.Drawing.Point(9, 256);
			this.btnKeyboard.Name = "btnKeyboard";
			this.btnKeyboard.Size = new System.Drawing.Size(31, 26);
			this.btnKeyboard.TabIndex = 72;
			this.btnKeyboard.UseVisualStyleBackColor = true;
			this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
			// 
			// nvmsPlayer
			// 
			this.nvmsPlayer.Active = false;
			this.nvmsPlayer.AllowDrop = true;
			this.nvmsPlayer.BackColor = System.Drawing.Color.Black;
			this.nvmsPlayer.BindMode = false;
			this.nvmsPlayer.ClipRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.nvmsPlayer.DragState = iNVMS.CustomControl.DragStateEnum.Move;
			this.nvmsPlayer.Index = 0;
			this.nvmsPlayer.IsProcessing = false;
			this.nvmsPlayer.Location = new System.Drawing.Point(324, 12);
			this.nvmsPlayer.Name = "nvmsPlayer";
			this.nvmsPlayer.PlayerState = iNVMS.CustomControl.PlayerStateEnum.CONNECTION_NONE;
			this.nvmsPlayer.PreviewMode = false;
			this.nvmsPlayer.Size = new System.Drawing.Size(350, 236);
			this.nvmsPlayer.TabIndex = 0;
			this.nvmsPlayer.TabStop = false;
			this.nvmsPlayer.ZoomOut = false;
			// 
			// FrmRemoteDVRSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(686, 291);
			this.Controls.Add(this.nvmsPlayer);
			this.Controls.Add(this.btnKeyboard);
			this.Controls.Add(this.txtPreviewChannel);
			this.Controls.Add(this.btnNextChannel);
			this.Controls.Add(this.btnPrevChannel);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmRemoteDVRSetting";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XVR Camera";
			this.Load += new System.EventHandler(this.FrmRemoteDVRSetting_Load);
			this.Shown += new System.EventHandler(this.FrmRemoteDVRSetting_Shown);
			this.Move += new System.EventHandler(this.FrmRemoteDVRSetting_Move);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nvmsPlayer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbManufacture;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnConnect;
		private iNVMS.CustomControl.NVMSPlayer nvmsPlayer;
		private System.Windows.Forms.Button btnPrevChannel;
		private System.Windows.Forms.Button btnNextChannel;
		private System.Windows.Forms.TextBox txtPreviewChannel;
		private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Button btnKeyboard;
    }
}
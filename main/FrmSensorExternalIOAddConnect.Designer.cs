namespace iNVMSMain
{
    partial class FrmSensorExternalIOAddConnect
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
			this.grbIPSetting = new System.Windows.Forms.GroupBox();
			this.btnSwitchIODevice = new System.Windows.Forms.Button();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rdbEthernet = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbBrand = new System.Windows.Forms.ComboBox();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rdbRS232 = new System.Windows.Forms.RadioButton();
			this.grbPortSetting = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbParity = new System.Windows.Forms.ComboBox();
			this.cmbStopBits = new System.Windows.Forms.ComboBox();
			this.cmbDataBits = new System.Windows.Forms.ComboBox();
			this.cmbBaudRate = new System.Windows.Forms.ComboBox();
			this.txtComPort = new System.Windows.Forms.TextBox();
			this.grbIPSetting.SuspendLayout();
			this.grbPortSetting.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbIPSetting
			// 
			this.grbIPSetting.Controls.Add(this.btnSwitchIODevice);
			this.grbIPSetting.Controls.Add(this.txtIPAddress);
			this.grbIPSetting.Controls.Add(this.label2);
			this.grbIPSetting.Location = new System.Drawing.Point(15, 106);
			this.grbIPSetting.Name = "grbIPSetting";
			this.grbIPSetting.Size = new System.Drawing.Size(257, 100);
			this.grbIPSetting.TabIndex = 9;
			this.grbIPSetting.TabStop = false;
			this.grbIPSetting.Text = "IP Setting";
			// 
			// btnSwitchIODevice
			// 
			this.btnSwitchIODevice.Location = new System.Drawing.Point(6, 62);
			this.btnSwitchIODevice.Name = "btnSwitchIODevice";
			this.btnSwitchIODevice.Size = new System.Drawing.Size(245, 23);
			this.btnSwitchIODevice.TabIndex = 2;
			this.btnSwitchIODevice.Text = "Switch IO Device";
			this.btnSwitchIODevice.UseVisualStyleBackColor = true;
			this.btnSwitchIODevice.Click += new System.EventHandler(this.btnSwitchIODevice_Click);
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(71, 29);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(180, 20);
			this.txtIPAddress.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "IP Address :";
			// 
			// rdbEthernet
			// 
			this.rdbEthernet.AutoSize = true;
			this.rdbEthernet.Checked = true;
			this.rdbEthernet.Location = new System.Drawing.Point(12, 79);
			this.rdbEthernet.Name = "rdbEthernet";
			this.rdbEthernet.Size = new System.Drawing.Size(65, 17);
			this.rdbEthernet.TabIndex = 8;
			this.rdbEthernet.TabStop = true;
			this.rdbEthernet.Text = "Ethernet";
			this.rdbEthernet.UseVisualStyleBackColor = true;
			this.rdbEthernet.CheckedChanged += new System.EventHandler(this.rdbEthernet_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Brand :";
			// 
			// cmbBrand
			// 
			this.cmbBrand.FormattingEnabled = true;
			this.cmbBrand.Items.AddRange(new object[] {
            "MOXA",
            "AVer"});
			this.cmbBrand.Location = new System.Drawing.Point(86, 42);
			this.cmbBrand.Name = "cmbBrand";
			this.cmbBrand.Size = new System.Drawing.Size(180, 21);
			this.cmbBrand.TabIndex = 6;
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Checked = true;
			this.chkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnable.Location = new System.Drawing.Point(12, 12);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(59, 17);
			this.chkEnable.TabIndex = 5;
			this.chkEnable.Text = "Enable";
			this.chkEnable.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(110, 432);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(191, 432);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// rdbRS232
			// 
			this.rdbRS232.AutoSize = true;
			this.rdbRS232.Location = new System.Drawing.Point(12, 221);
			this.rdbRS232.Name = "rdbRS232";
			this.rdbRS232.Size = new System.Drawing.Size(84, 17);
			this.rdbRS232.TabIndex = 11;
			this.rdbRS232.TabStop = true;
			this.rdbRS232.Text = "RS-232/485";
			this.rdbRS232.UseVisualStyleBackColor = true;
			// 
			// grbPortSetting
			// 
			this.grbPortSetting.Controls.Add(this.label7);
			this.grbPortSetting.Controls.Add(this.label6);
			this.grbPortSetting.Controls.Add(this.label5);
			this.grbPortSetting.Controls.Add(this.label4);
			this.grbPortSetting.Controls.Add(this.label3);
			this.grbPortSetting.Controls.Add(this.cmbParity);
			this.grbPortSetting.Controls.Add(this.cmbStopBits);
			this.grbPortSetting.Controls.Add(this.cmbDataBits);
			this.grbPortSetting.Controls.Add(this.cmbBaudRate);
			this.grbPortSetting.Controls.Add(this.txtComPort);
			this.grbPortSetting.Enabled = false;
			this.grbPortSetting.Location = new System.Drawing.Point(15, 255);
			this.grbPortSetting.Name = "grbPortSetting";
			this.grbPortSetting.Size = new System.Drawing.Size(257, 166);
			this.grbPortSetting.TabIndex = 10;
			this.grbPortSetting.TabStop = false;
			this.grbPortSetting.Text = "Port Setting";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Parity :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 109);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Stop Bits :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Data Bits :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Baud Rate :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "COM Port :";
			// 
			// cmbParity
			// 
			this.cmbParity.FormattingEnabled = true;
			this.cmbParity.Location = new System.Drawing.Point(130, 133);
			this.cmbParity.Name = "cmbParity";
			this.cmbParity.Size = new System.Drawing.Size(121, 21);
			this.cmbParity.TabIndex = 4;
			// 
			// cmbStopBits
			// 
			this.cmbStopBits.FormattingEnabled = true;
			this.cmbStopBits.Location = new System.Drawing.Point(130, 106);
			this.cmbStopBits.Name = "cmbStopBits";
			this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
			this.cmbStopBits.TabIndex = 3;
			// 
			// cmbDataBits
			// 
			this.cmbDataBits.FormattingEnabled = true;
			this.cmbDataBits.Location = new System.Drawing.Point(130, 79);
			this.cmbDataBits.Name = "cmbDataBits";
			this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
			this.cmbDataBits.TabIndex = 2;
			// 
			// cmbBaudRate
			// 
			this.cmbBaudRate.FormattingEnabled = true;
			this.cmbBaudRate.Location = new System.Drawing.Point(130, 52);
			this.cmbBaudRate.Name = "cmbBaudRate";
			this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
			this.cmbBaudRate.TabIndex = 1;
			// 
			// txtComPort
			// 
			this.txtComPort.Location = new System.Drawing.Point(130, 26);
			this.txtComPort.Name = "txtComPort";
			this.txtComPort.Size = new System.Drawing.Size(121, 20);
			this.txtComPort.TabIndex = 0;
			// 
			// FrmSensorExternalIOAddConnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 461);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.rdbRS232);
			this.Controls.Add(this.grbPortSetting);
			this.Controls.Add(this.grbIPSetting);
			this.Controls.Add(this.rdbEthernet);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbBrand);
			this.Controls.Add(this.chkEnable);
			this.MaximizeBox = false;
			this.Name = "FrmSensorExternalIOAddConnect";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Connection";
			this.grbIPSetting.ResumeLayout(false);
			this.grbIPSetting.PerformLayout();
			this.grbPortSetting.ResumeLayout(false);
			this.grbPortSetting.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbIPSetting;
        private System.Windows.Forms.Button btnSwitchIODevice;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbEthernet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdbRS232;
        private System.Windows.Forms.GroupBox grbPortSetting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.TextBox txtComPort;

    }
}
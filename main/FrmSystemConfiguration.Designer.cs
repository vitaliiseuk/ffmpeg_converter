namespace iNVMSMain
{
    partial class FrmSystemConfiguration
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
            this.btnUsageInfo = new System.Windows.Forms.Button();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnPPPoESetting = new System.Windows.Forms.Button();
            this.btnSoundSetting = new System.Windows.Forms.Button();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnDeviceManager = new System.Windows.Forms.Button();
            this.btnPhoneOption = new System.Windows.Forms.Button();
            this.btnMapNetwork = new System.Windows.Forms.Button();
            this.btnDisconnectNet = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsageInfo
            // 
            this.btnUsageInfo.Location = new System.Drawing.Point(59, 21);
            this.btnUsageInfo.Name = "btnUsageInfo";
            this.btnUsageInfo.Size = new System.Drawing.Size(144, 34);
            this.btnUsageInfo.TabIndex = 0;
            this.btnUsageInfo.Text = "Usage Info";
            this.btnUsageInfo.UseVisualStyleBackColor = true;
            this.btnUsageInfo.Click += new System.EventHandler(this.btnUsageInfo_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Location = new System.Drawing.Point(59, 61);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(144, 34);
            this.btnKeyboard.TabIndex = 1;
            this.btnKeyboard.Text = "Keyboard/Input Methods";
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnPPPoESetting
            // 
            this.btnPPPoESetting.Location = new System.Drawing.Point(59, 101);
            this.btnPPPoESetting.Name = "btnPPPoESetting";
            this.btnPPPoESetting.Size = new System.Drawing.Size(144, 34);
            this.btnPPPoESetting.TabIndex = 2;
            this.btnPPPoESetting.Text = "PPPoE Setting";
            this.btnPPPoESetting.UseVisualStyleBackColor = true;
            this.btnPPPoESetting.Click += new System.EventHandler(this.btnPPPoESetting_Click);
            // 
            // btnSoundSetting
            // 
            this.btnSoundSetting.Location = new System.Drawing.Point(59, 141);
            this.btnSoundSetting.Name = "btnSoundSetting";
            this.btnSoundSetting.Size = new System.Drawing.Size(144, 34);
            this.btnSoundSetting.TabIndex = 3;
            this.btnSoundSetting.Text = "Sound Setting";
            this.btnSoundSetting.UseVisualStyleBackColor = true;
            this.btnSoundSetting.Click += new System.EventHandler(this.btnSoundSetting_Click);
            // 
            // btnPrinter
            // 
            this.btnPrinter.Location = new System.Drawing.Point(59, 181);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(144, 34);
            this.btnPrinter.TabIndex = 4;
            this.btnPrinter.Text = "Printer";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // btnDeviceManager
            // 
            this.btnDeviceManager.Location = new System.Drawing.Point(221, 21);
            this.btnDeviceManager.Name = "btnDeviceManager";
            this.btnDeviceManager.Size = new System.Drawing.Size(144, 34);
            this.btnDeviceManager.TabIndex = 5;
            this.btnDeviceManager.Text = "Device Manager";
            this.btnDeviceManager.UseVisualStyleBackColor = true;
            this.btnDeviceManager.Click += new System.EventHandler(this.btnDeviceManager_Click);
            // 
            // btnPhoneOption
            // 
            this.btnPhoneOption.Location = new System.Drawing.Point(221, 61);
            this.btnPhoneOption.Name = "btnPhoneOption";
            this.btnPhoneOption.Size = new System.Drawing.Size(144, 34);
            this.btnPhoneOption.TabIndex = 6;
            this.btnPhoneOption.Text = "Phone and Modem Options";
            this.btnPhoneOption.UseVisualStyleBackColor = true;
            this.btnPhoneOption.Click += new System.EventHandler(this.btnPhoneOption_Click);
            // 
            // btnMapNetwork
            // 
            this.btnMapNetwork.Location = new System.Drawing.Point(221, 101);
            this.btnMapNetwork.Name = "btnMapNetwork";
            this.btnMapNetwork.Size = new System.Drawing.Size(144, 34);
            this.btnMapNetwork.TabIndex = 7;
            this.btnMapNetwork.Text = "Map Network Drive";
            this.btnMapNetwork.UseVisualStyleBackColor = true;
            this.btnMapNetwork.Click += new System.EventHandler(this.btnMapNetwork_Click);
            // 
            // btnDisconnectNet
            // 
            this.btnDisconnectNet.Location = new System.Drawing.Point(221, 141);
            this.btnDisconnectNet.Name = "btnDisconnectNet";
            this.btnDisconnectNet.Size = new System.Drawing.Size(144, 34);
            this.btnDisconnectNet.TabIndex = 8;
            this.btnDisconnectNet.Text = "Disconnect Network Driver";
            this.btnDisconnectNet.UseVisualStyleBackColor = true;
            this.btnDisconnectNet.Click += new System.EventHandler(this.btnDisconnectNet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSystemConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 235);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDisconnectNet);
            this.Controls.Add(this.btnMapNetwork);
            this.Controls.Add(this.btnPhoneOption);
            this.Controls.Add(this.btnDeviceManager);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnSoundSetting);
            this.Controls.Add(this.btnPPPoESetting);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnUsageInfo);
            this.MaximizeBox = false;
            this.Name = "FrmSystemConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Configuration Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsageInfo;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnPPPoESetting;
        private System.Windows.Forms.Button btnSoundSetting;
        private System.Windows.Forms.Button btnPrinter;
        private System.Windows.Forms.Button btnDeviceManager;
        private System.Windows.Forms.Button btnPhoneOption;
        private System.Windows.Forms.Button btnMapNetwork;
        private System.Windows.Forms.Button btnDisconnectNet;
        private System.Windows.Forms.Button btnSave;
    }
}
namespace iNVMSMain
{
    partial class FrmRelayExternalIOAddConnectSwitchDevice
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
            this.listDeviceInfo = new System.Windows.Forms.ListView();
            this.columnModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMacAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubnetMask = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGateway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listDeviceInfo
            // 
            this.listDeviceInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnModule,
            this.columnMacAddress,
            this.columnIPAddress,
            this.columnSubnetMask,
            this.columnGateway});
            this.listDeviceInfo.GridLines = true;
            this.listDeviceInfo.Location = new System.Drawing.Point(8, 26);
            this.listDeviceInfo.Name = "listDeviceInfo";
            this.listDeviceInfo.Size = new System.Drawing.Size(618, 163);
            this.listDeviceInfo.TabIndex = 0;
            this.listDeviceInfo.UseCompatibleStateImageBehavior = false;
            this.listDeviceInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnModule
            // 
            this.columnModule.Text = "Module";
            this.columnModule.Width = 200;
            // 
            // columnMacAddress
            // 
            this.columnMacAddress.Text = "Mac Address";
            this.columnMacAddress.Width = 100;
            // 
            // columnIPAddress
            // 
            this.columnIPAddress.Text = "IP Address";
            this.columnIPAddress.Width = 100;
            // 
            // columnSubnetMask
            // 
            this.columnSubnetMask.Text = "Subnet Mask";
            this.columnSubnetMask.Width = 100;
            // 
            // columnGateway
            // 
            this.columnGateway.Text = "Gateway";
            this.columnGateway.Width = 100;
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(8, 226);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Start Search";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(551, 226);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmRelayExternalIOAddConnectSwitchDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 261);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.listDeviceInfo);
            this.MaximizeBox = false;
            this.Name = "FrmRelayExternalIOAddConnectSwitchDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search IO Device";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listDeviceInfo;
        private System.Windows.Forms.ColumnHeader columnModule;
        private System.Windows.Forms.ColumnHeader columnMacAddress;
        private System.Windows.Forms.ColumnHeader columnIPAddress;
        private System.Windows.Forms.ColumnHeader columnSubnetMask;
        private System.Windows.Forms.ColumnHeader columnGateway;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Button btnExit;
    }
}
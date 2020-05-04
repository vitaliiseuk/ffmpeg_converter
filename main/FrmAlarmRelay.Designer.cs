namespace iNVMSMain
{
    partial class FrmAlarmRelay
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
			this.listAlarmRelay = new System.Windows.Forms.ListView();
			this.columnNumbr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnON = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chkRetrieveTime = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRetrieveTime = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listAlarmRelay
			// 
			this.listAlarmRelay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumbr,
            this.columnName,
            this.columnON});
			this.listAlarmRelay.GridLines = true;
			this.listAlarmRelay.Location = new System.Drawing.Point(12, 12);
			this.listAlarmRelay.Name = "listAlarmRelay";
			this.listAlarmRelay.Size = new System.Drawing.Size(260, 242);
			this.listAlarmRelay.TabIndex = 0;
			this.listAlarmRelay.UseCompatibleStateImageBehavior = false;
			this.listAlarmRelay.View = System.Windows.Forms.View.Details;
			// 
			// columnNumbr
			// 
			this.columnNumbr.Text = "No.";
			this.columnNumbr.Width = 38;
			// 
			// columnName
			// 
			this.columnName.Text = "Name";
			this.columnName.Width = 181;
			// 
			// columnON
			// 
			this.columnON.Text = "ON";
			this.columnON.Width = 136;
			// 
			// chkRetrieveTime
			// 
			this.chkRetrieveTime.AutoSize = true;
			this.chkRetrieveTime.Location = new System.Drawing.Point(12, 274);
			this.chkRetrieveTime.Name = "chkRetrieveTime";
			this.chkRetrieveTime.Size = new System.Drawing.Size(92, 17);
			this.chkRetrieveTime.TabIndex = 8;
			this.chkRetrieveTime.Text = "Retrieve Time";
			this.chkRetrieveTime.UseVisualStyleBackColor = true;
			this.chkRetrieveTime.CheckedChanged += new System.EventHandler(this.chkRetrieveTime_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(204, 275);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Sec.";
			// 
			// txtRetrieveTime
			// 
			this.txtRetrieveTime.Enabled = false;
			this.txtRetrieveTime.Location = new System.Drawing.Point(126, 272);
			this.txtRetrieveTime.Name = "txtRetrieveTime";
			this.txtRetrieveTime.Size = new System.Drawing.Size(75, 20);
			this.txtRetrieveTime.TabIndex = 6;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(116, 305);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(197, 305);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmRelay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 341);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkRetrieveTime);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRetrieveTime);
			this.Controls.Add(this.listAlarmRelay);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmRelay";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmAlarmRelay";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listAlarmRelay;
        private System.Windows.Forms.ColumnHeader columnNumbr;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnON;
        private System.Windows.Forms.CheckBox chkRetrieveTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRetrieveTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
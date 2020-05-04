namespace iNVMSMain
{
    partial class FrmSensorExternalIO
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
            this.btnIOMap = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnectDelete = new System.Windows.Forms.Button();
            this.btnConnectEdit = new System.Windows.Forms.Button();
            this.btnConnectAdd = new System.Windows.Forms.Button();
            this.listConnection = new System.Windows.Forms.ListView();
            this.ptbIOMap = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIOMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIOMap
            // 
            this.btnIOMap.Location = new System.Drawing.Point(12, 329);
            this.btnIOMap.Name = "btnIOMap";
            this.btnIOMap.Size = new System.Drawing.Size(75, 23);
            this.btnIOMap.TabIndex = 7;
            this.btnIOMap.Text = "I/OMap";
            this.btnIOMap.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(547, 329);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnectDelete);
            this.groupBox1.Controls.Add(this.btnConnectEdit);
            this.groupBox1.Controls.Add(this.btnConnectAdd);
            this.groupBox1.Controls.Add(this.listConnection);
            this.groupBox1.Location = new System.Drawing.Point(218, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 311);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // btnConnectDelete
            // 
            this.btnConnectDelete.Location = new System.Drawing.Point(270, 280);
            this.btnConnectDelete.Name = "btnConnectDelete";
            this.btnConnectDelete.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDelete.TabIndex = 3;
            this.btnConnectDelete.Text = "Delete";
            this.btnConnectDelete.UseVisualStyleBackColor = true;
            // 
            // btnConnectEdit
            // 
            this.btnConnectEdit.Location = new System.Drawing.Point(167, 280);
            this.btnConnectEdit.Name = "btnConnectEdit";
            this.btnConnectEdit.Size = new System.Drawing.Size(75, 23);
            this.btnConnectEdit.TabIndex = 2;
            this.btnConnectEdit.Text = "Edit";
            this.btnConnectEdit.UseVisualStyleBackColor = true;
            // 
            // btnConnectAdd
            // 
            this.btnConnectAdd.Location = new System.Drawing.Point(65, 280);
            this.btnConnectAdd.Name = "btnConnectAdd";
            this.btnConnectAdd.Size = new System.Drawing.Size(75, 23);
            this.btnConnectAdd.TabIndex = 1;
            this.btnConnectAdd.Text = "Add\r\n";
            this.btnConnectAdd.UseVisualStyleBackColor = true;
            this.btnConnectAdd.Click += new System.EventHandler(this.btnConnectAdd_Click);
            // 
            // listConnection
            // 
            this.listConnection.Location = new System.Drawing.Point(6, 22);
            this.listConnection.Name = "listConnection";
            this.listConnection.Size = new System.Drawing.Size(392, 251);
            this.listConnection.TabIndex = 0;
            this.listConnection.UseCompatibleStateImageBehavior = false;
            // 
            // ptbIOMap
            // 
            this.ptbIOMap.BackColor = System.Drawing.Color.White;
            this.ptbIOMap.Location = new System.Drawing.Point(12, 15);
            this.ptbIOMap.Name = "ptbIOMap";
            this.ptbIOMap.Size = new System.Drawing.Size(200, 304);
            this.ptbIOMap.TabIndex = 4;
            this.ptbIOMap.TabStop = false;
            // 
            // FrmSensorExternalIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.btnIOMap);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ptbIOMap);
            this.MaximizeBox = false;
            this.Name = "FrmSensorExternalIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "External IO Setup";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbIOMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIOMap;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnectDelete;
        private System.Windows.Forms.Button btnConnectEdit;
        private System.Windows.Forms.Button btnConnectAdd;
        private System.Windows.Forms.ListView listConnection;
        private System.Windows.Forms.PictureBox ptbIOMap;
    }
}
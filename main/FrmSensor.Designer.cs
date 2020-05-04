namespace iNVMSMain
{
    partial class FrmSensor
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
            this.grbTest = new System.Windows.Forms.GroupBox();
            this.ptbTest = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.txtInputNo = new System.Windows.Forms.TextBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExternIO = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSensor = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grbTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTest
            // 
            this.grbTest.Controls.Add(this.ptbTest);
            this.grbTest.Controls.Add(this.btnTest);
            this.grbTest.Location = new System.Drawing.Point(12, 235);
            this.grbTest.Name = "grbTest";
            this.grbTest.Size = new System.Drawing.Size(310, 87);
            this.grbTest.TabIndex = 12;
            this.grbTest.TabStop = false;
            this.grbTest.Text = "Test";
            // 
            // ptbTest
            // 
            this.ptbTest.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ptbTest.Location = new System.Drawing.Point(30, 25);
            this.ptbTest.Name = "ptbTest";
            this.ptbTest.Size = new System.Drawing.Size(100, 50);
            this.ptbTest.TabIndex = 2;
            this.ptbTest.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(148, 39);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbDescription);
            this.groupBox2.Controls.Add(this.txtInputNo);
            this.groupBox2.Controls.Add(this.txtCardNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 118);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Content";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(123, 74);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(181, 37);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // txtInputNo
            // 
            this.txtInputNo.Location = new System.Drawing.Point(123, 48);
            this.txtInputNo.Name = "txtInputNo";
            this.txtInputNo.Size = new System.Drawing.Size(100, 20);
            this.txtInputNo.TabIndex = 4;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(123, 22);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(100, 20);
            this.txtCardNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Input No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Card No.";
            // 
            // btnExternIO
            // 
            this.btnExternIO.Location = new System.Drawing.Point(247, 79);
            this.btnExternIO.Name = "btnExternIO";
            this.btnExternIO.Size = new System.Drawing.Size(75, 23);
            this.btnExternIO.TabIndex = 10;
            this.btnExternIO.Text = "External IO";
            this.btnExternIO.UseVisualStyleBackColor = true;
            this.btnExternIO.Click += new System.EventHandler(this.btnExternIO_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(135, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(187, 20);
            this.txtName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // cmbSensor
            // 
            this.cmbSensor.FormattingEnabled = true;
            this.cmbSensor.Items.AddRange(new object[] {
            "Sensor1",
            "Sensor2",
            "Sensor3",
            "Sensor4",
            "Sensor5",
            "Sensor6",
            "Sensor7",
            "Sensor8",
            "Sensor9",
            "Sensor10"});
            this.cmbSensor.Location = new System.Drawing.Point(12, 12);
            this.cmbSensor.Name = "cmbSensor";
            this.cmbSensor.Size = new System.Drawing.Size(310, 21);
            this.cmbSensor.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(247, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 332);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExternIO);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSensor);
            this.MaximizeBox = false;
            this.Name = "FrmSensor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sensor Setting";
            this.grbTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTest;
        private System.Windows.Forms.PictureBox ptbTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox txtInputNo;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExternIO;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSensor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

    }
}
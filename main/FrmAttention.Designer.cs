namespace iNVMSMain
{
    partial class FrmAttention
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPreferredNumber = new System.Windows.Forms.TextBox();
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the number what you see.";
            // 
            // txtPreferredNumber
            // 
            this.txtPreferredNumber.Enabled = false;
            this.txtPreferredNumber.Location = new System.Drawing.Point(26, 60);
            this.txtPreferredNumber.Name = "txtPreferredNumber";
            this.txtPreferredNumber.Size = new System.Drawing.Size(53, 20);
            this.txtPreferredNumber.TabIndex = 1;
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Location = new System.Drawing.Point(98, 60);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(53, 20);
            this.txtUserNumber.TabIndex = 2;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackgroundImage = global::iNVMSMain.Properties.Resources.keyboard_short;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeyboard.Location = new System.Drawing.Point(194, 54);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(31, 26);
            this.btnKeyboard.TabIndex = 74;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 28);
            this.btnOK.TabIndex = 75;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmAttention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 103);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.txtPreferredNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAttention";
            this.Text = "Attention";
            this.Load += new System.EventHandler(this.FrmAttention_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPreferredNumber;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnOK;
    }
}
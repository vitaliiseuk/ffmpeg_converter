namespace iNVMSMain
{
    partial class FrmAlarmSound
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnRecord = new System.Windows.Forms.Button();
			this.btnSoundPath = new System.Windows.Forms.Button();
			this.txtSoundPath = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdbPlaySequence = new System.Windows.Forms.RadioButton();
			this.rdbInterrupt = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnPlay);
			this.groupBox1.Controls.Add(this.btnRecord);
			this.groupBox1.Controls.Add(this.btnSoundPath);
			this.groupBox1.Controls.Add(this.txtSoundPath);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 87);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sound Path";
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(232, 55);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 3;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			// 
			// btnRecord
			// 
			this.btnRecord.Location = new System.Drawing.Point(133, 55);
			this.btnRecord.Name = "btnRecord";
			this.btnRecord.Size = new System.Drawing.Size(75, 23);
			this.btnRecord.TabIndex = 2;
			this.btnRecord.Text = "Record";
			this.btnRecord.UseVisualStyleBackColor = true;
			// 
			// btnSoundPath
			// 
			this.btnSoundPath.Location = new System.Drawing.Point(278, 17);
			this.btnSoundPath.Name = "btnSoundPath";
			this.btnSoundPath.Size = new System.Drawing.Size(29, 23);
			this.btnSoundPath.TabIndex = 1;
			this.btnSoundPath.Text = "...";
			this.btnSoundPath.UseVisualStyleBackColor = true;
			this.btnSoundPath.Click += new System.EventHandler(this.btnSoundPath_Click);
			// 
			// txtSoundPath
			// 
			this.txtSoundPath.Location = new System.Drawing.Point(6, 19);
			this.txtSoundPath.Name = "txtSoundPath";
			this.txtSoundPath.Size = new System.Drawing.Size(266, 20);
			this.txtSoundPath.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdbPlaySequence);
			this.groupBox2.Controls.Add(this.rdbInterrupt);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(12, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 96);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Play Mode";
			// 
			// rdbPlaySequence
			// 
			this.rdbPlaySequence.AutoSize = true;
			this.rdbPlaySequence.Location = new System.Drawing.Point(23, 66);
			this.rdbPlaySequence.Name = "rdbPlaySequence";
			this.rdbPlaySequence.Size = new System.Drawing.Size(111, 17);
			this.rdbPlaySequence.TabIndex = 2;
			this.rdbPlaySequence.TabStop = true;
			this.rdbPlaySequence.Text = "Play by Sequence";
			this.rdbPlaySequence.UseVisualStyleBackColor = true;
			// 
			// rdbInterrupt
			// 
			this.rdbInterrupt.AutoSize = true;
			this.rdbInterrupt.Location = new System.Drawing.Point(23, 43);
			this.rdbInterrupt.Name = "rdbInterrupt";
			this.rdbInterrupt.Size = new System.Drawing.Size(64, 17);
			this.rdbInterrupt.TabIndex = 1;
			this.rdbInterrupt.TabStop = true;
			this.rdbInterrupt.Text = "Interrupt";
			this.rdbInterrupt.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "New Warning Sound";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(200, 210);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(63, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(269, 210);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(63, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmAlarmSound
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 241);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "FrmAlarmSound";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Alarm Sound Setting";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoundPath;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSoundPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbPlaySequence;
        private System.Windows.Forms.RadioButton rdbInterrupt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
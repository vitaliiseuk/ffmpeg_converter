﻿namespace iNVMSMain
{
    partial class FrmRecordingMotionAdvanced
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
            this.btnRegion1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labRegion1 = new System.Windows.Forms.Label();
            this.trackRegion1 = new System.Windows.Forms.TrackBar();
            this.trackRegion2 = new System.Windows.Forms.TrackBar();
            this.labRegion2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegion2 = new System.Windows.Forms.Button();
            this.trackRegion3 = new System.Windows.Forms.TrackBar();
            this.labRegion3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegion3 = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nvmsPlayer = new iNVMS.CustomControl.NVMSPlayer(this);
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvmsPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegion1
            // 
            this.btnRegion1.Location = new System.Drawing.Point(473, 13);
            this.btnRegion1.Name = "btnRegion1";
            this.btnRegion1.Size = new System.Drawing.Size(194, 23);
            this.btnRegion1.TabIndex = 0;
            this.btnRegion1.Text = "Region1";
            this.btnRegion1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sensitivity";
            // 
            // labRegion1
            // 
            this.labRegion1.AutoSize = true;
            this.labRegion1.Location = new System.Drawing.Point(647, 71);
            this.labRegion1.Name = "labRegion1";
            this.labRegion1.Size = new System.Drawing.Size(19, 13);
            this.labRegion1.TabIndex = 2;
            this.labRegion1.Text = "50";
            // 
            // trackRegion1
            // 
            this.trackRegion1.Location = new System.Drawing.Point(468, 66);
            this.trackRegion1.Maximum = 100;
            this.trackRegion1.Name = "trackRegion1";
            this.trackRegion1.Size = new System.Drawing.Size(173, 45);
            this.trackRegion1.TabIndex = 3;
            this.trackRegion1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRegion1.Value = 50;
            this.trackRegion1.Scroll += new System.EventHandler(this.trackRegion1_Scroll);
            // 
            // trackRegion2
            // 
            this.trackRegion2.Location = new System.Drawing.Point(468, 172);
            this.trackRegion2.Maximum = 100;
            this.trackRegion2.Name = "trackRegion2";
            this.trackRegion2.Size = new System.Drawing.Size(173, 45);
            this.trackRegion2.TabIndex = 7;
            this.trackRegion2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRegion2.Value = 50;
            this.trackRegion2.Scroll += new System.EventHandler(this.trackRegion2_Scroll);
            // 
            // labRegion2
            // 
            this.labRegion2.AutoSize = true;
            this.labRegion2.Location = new System.Drawing.Point(647, 177);
            this.labRegion2.Name = "labRegion2";
            this.labRegion2.Size = new System.Drawing.Size(19, 13);
            this.labRegion2.TabIndex = 6;
            this.labRegion2.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sensitivity";
            // 
            // btnRegion2
            // 
            this.btnRegion2.Location = new System.Drawing.Point(473, 119);
            this.btnRegion2.Name = "btnRegion2";
            this.btnRegion2.Size = new System.Drawing.Size(194, 23);
            this.btnRegion2.TabIndex = 4;
            this.btnRegion2.Text = "Region2";
            this.btnRegion2.UseVisualStyleBackColor = true;
            // 
            // trackRegion3
            // 
            this.trackRegion3.Location = new System.Drawing.Point(468, 286);
            this.trackRegion3.Maximum = 100;
            this.trackRegion3.Name = "trackRegion3";
            this.trackRegion3.Size = new System.Drawing.Size(173, 45);
            this.trackRegion3.TabIndex = 11;
            this.trackRegion3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRegion3.Value = 50;
            this.trackRegion3.Scroll += new System.EventHandler(this.trackRegion3_Scroll);
            // 
            // labRegion3
            // 
            this.labRegion3.AutoSize = true;
            this.labRegion3.Location = new System.Drawing.Point(647, 291);
            this.labRegion3.Name = "labRegion3";
            this.labRegion3.Size = new System.Drawing.Size(19, 13);
            this.labRegion3.TabIndex = 10;
            this.labRegion3.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sensitivity";
            // 
            // btnRegion3
            // 
            this.btnRegion3.Location = new System.Drawing.Point(473, 230);
            this.btnRegion3.Name = "btnRegion3";
            this.btnRegion3.Size = new System.Drawing.Size(194, 23);
            this.btnRegion3.TabIndex = 8;
            this.btnRegion3.Text = "Region3";
            this.btnRegion3.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(592, 337);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 12;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(495, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(387, 335);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // nvmsPlayer
            // 
            this.nvmsPlayer.Active = false;
            this.nvmsPlayer.AllowDrop = true;
            this.nvmsPlayer.BackColor = System.Drawing.Color.Black;
            this.nvmsPlayer.BindMode = false;
            this.nvmsPlayer.Index = 0;
            this.nvmsPlayer.IsProcessing = false;
            this.nvmsPlayer.Location = new System.Drawing.Point(10, 12);
            this.nvmsPlayer.Name = "nvmsPlayer";
            this.nvmsPlayer.PlayerState = iNVMS.CustomControl.PlayerStateEnum.CONNECTION_NONE;
            this.nvmsPlayer.PreviewMode = false;
            this.nvmsPlayer.Size = new System.Drawing.Size(451, 309);
            this.nvmsPlayer.TabIndex = 13;
            this.nvmsPlayer.TabStop = false;
            // 
            // FrmRecordingMotionAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 370);
            this.Controls.Add(this.nvmsPlayer);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.trackRegion3);
            this.Controls.Add(this.labRegion3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRegion3);
            this.Controls.Add(this.trackRegion2);
            this.Controls.Add(this.labRegion2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRegion2);
            this.Controls.Add(this.trackRegion1);
            this.Controls.Add(this.labRegion1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegion1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRecordingMotionAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Motion Advance Setting";
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRegion3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvmsPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button btnRegion1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labRegion1;
        private System.Windows.Forms.TrackBar trackRegion1;
        private System.Windows.Forms.TrackBar trackRegion2;
        private System.Windows.Forms.Label labRegion2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegion2;
        private System.Windows.Forms.TrackBar trackRegion3;
        private System.Windows.Forms.Label labRegion3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegion3;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
		private iNVMS.CustomControl.NVMSPlayer nvmsPlayer;
    }
}
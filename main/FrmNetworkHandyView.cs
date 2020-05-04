using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;

namespace iNVMSMain
{
    public partial class FrmNetworkHandyView : Form
    {
        public string selected_video_size;

        public FrmNetworkHandyView()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            selected_video_size = iNVMSConfig.NetworkConfig.m_networkHandyView.VideoSize;
            txtQuality.Text = iNVMSConfig.NetworkConfig.m_networkHandyView.VideoQuality;
            trackQuality.Value = Convert.ToInt32(txtQuality.Text);

            if (selected_video_size == rdbVideoSize1.Name)
                rdbVideoSize1.Checked = true;
            else if (selected_video_size == rdbVideoSize2.Name)
                rdbVideoSize2.Checked = true;
            else if (selected_video_size == rdbVideoSize3.Name)
                rdbVideoSize3.Checked = true;
        }

        private void trackQuality_Scroll(object sender, EventArgs e)
        {
            txtQuality.Text = trackQuality.Value.ToString();
        }

        private void FrmNetworkHandyView_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            iNVMSConfig.NetworkConfig.m_networkHandyView.VideoSize = selected_video_size;
            iNVMSConfig.NetworkConfig.m_networkHandyView.VideoQuality = txtQuality.Text;
        }

        private void rdbVideoSize3_Click(object sender, EventArgs e)
        {
            if (rdbVideoSize3.Checked)
                selected_video_size = rdbVideoSize3.Name;
        }

        private void rdbVideoSize2_Click(object sender, EventArgs e)
        {
            if (rdbVideoSize2.Checked)
                selected_video_size = rdbVideoSize2.Name;
        }

        private void rdbVideoSize1_Click(object sender, EventArgs e)
        {
            if (rdbVideoSize1.Checked)
                selected_video_size = rdbVideoSize1.Name;
        }
    }
}

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
    public partial class FrmNetworkBandwidth : Form
    {
        public string[] cam_channel = {"camera1", "camera2", "camera3", "camera4", "camera5", "camera6", "camera7", "camera8", "camera9", "camera10"};
        public int[] bandwidth = { 512, 1024, 2048 };

        public FrmNetworkBandwidth()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            rdbByChannel.Checked = iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannel;
            rdbAll.Checked = iNVMSConfig.NetworkConfig.m_networkBandwidth.AllChannel;
            
            if (rdbByChannel.Checked)
            {
                updateGrbByChannel();
            }

            if (rdbAll.Checked)
            {
                updateGrbAll();
            }
            //Console.WriteLine(rdbByChannel.Checked);
        }

        private void rdbByChannel_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbByChannel.Checked)
            {
                grbByChannel.Enabled = true;
                grbAll.Enabled = false;

                updateGrbByChannel();
            }
            else
            {
                grbByChannel.Enabled = false;
                grbAll.Enabled = true;

                updateGrbAll();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannel = rdbByChannel.Checked;
            iNVMSConfig.NetworkConfig.m_networkBandwidth.AllChannel = rdbAll.Checked;

            if (rdbByChannel.Checked)
            {
                iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannelCam = cmbByChannelCam.SelectedItem.ToString();
                iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannelRate = Convert.ToInt32(cmbByChannelRate.SelectedItem.ToString());
            }

            if (rdbAll.Checked)
            {
                iNVMSConfig.NetworkConfig.m_networkBandwidth.TotalLimit = txtTotalLimit.Text;
            }
        }

        private void rdbAll_Click(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                grbByChannel.Enabled = false;
                grbAll.Enabled = true;
                updateGrbAll();
            }
            else
            {
                grbByChannel.Enabled = true;
                grbAll.Enabled = false;

                updateGrbByChannel();
            }
        }

        private void updateGrbByChannel()
        {
            cmbByChannelCam.Items.Clear();
            foreach (string value in cam_channel)
                cmbByChannelCam.Items.Add(value);

            int index1 = cmbByChannelCam.Items.IndexOf(iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannelCam);
            cmbByChannelCam.SelectedIndex = index1;

            cmbByChannelRate.Items.Clear();
            foreach (int value in bandwidth)
                cmbByChannelRate.Items.Add(value);

            index1 = cmbByChannelRate.Items.IndexOf(iNVMSConfig.NetworkConfig.m_networkBandwidth.ByChannelRate);
            cmbByChannelRate.SelectedIndex = index1;
        }

        private void updateGrbAll()
        {
            txtTotalLimit.Text = iNVMSConfig.NetworkConfig.m_networkBandwidth.TotalLimit;
        }
    }
}

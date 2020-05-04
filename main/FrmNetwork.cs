using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace iNVMSMain
{
    public partial class FrmNetwork : Form
    {
        private string[] sync_server = { "www.edu.com" };
        public int i;
        public int num_of_checkbox;
        public int cam_pages;
        public int crt_page;
        public bool[] trans_cams = new bool[64];

        public FrmNetwork()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
                        
            Array.Clear(trans_cams, 0, trans_cams.Length);
            
            num_of_checkbox = 16;
            cam_pages = (int) Math.Ceiling(Convert.ToDecimal(iNVMSConfig.MaxCameraCount / num_of_checkbox));
            crt_page = 1;
            
            UpdateData(false);
        }

        private void chkWhiteList_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWhiteList.Checked)
            {
                btnWhiteList.Enabled = true;
            }
            else
            {
                btnWhiteList.Enabled = false;
            }
        }
		public void UpdateData(bool bUpdateValue)
		{
			if (bUpdateValue)
			{
				iNVMSConfig.NetworkConfig.RtspEnabled = chkRTSPEnable.Checked;
				iNVMSConfig.NetworkConfig.RtspStreamPort = Int32.Parse(txtRTSPPort.Text);
                iNVMSConfig.NetworkConfig.ServerName = txtServerName.Text;
                iNVMSConfig.NetworkConfig.TransCamAll = chkTransCamAll.Checked;
                iNVMSConfig.NetworkConfig.ServerIP = cmbSeverIP.SelectedItem.ToString();
                iNVMSConfig.NetworkConfig.RemotePort = txtRemotePort.Text;
                iNVMSConfig.NetworkConfig.DomainName = txtDomainName.Text;
                iNVMSConfig.NetworkConfig.DNSID = txtDNSID.Text;
                iNVMSConfig.NetworkConfig.DNSPassword = txtDNSPassword.Text;
                iNVMSConfig.NetworkConfig.DNSServerPort = txtDNSServerPort.Text;
                
                iNVMSConfig.NetworkConfig.AnomyLogin = chkAnomyLogin.Checked;
                if (chkAnomyLogin.Checked)
                    iNVMSConfig.NetworkConfig.PCViewPort = txtPCViewPort.Text;

                iNVMSConfig.NetworkConfig.RemoteEnable = chkRemoteEnable.Checked;
                if (chkRemoteEnable.Checked)
                    iNVMSConfig.NetworkConfig.RemoteServerPort = txtRemoteSeverPort.Text;

                iNVMSConfig.NetworkConfig.TalkWeb = chkTalkWeb.Checked;
                if (chkTalkWeb.Checked)
                    iNVMSConfig.NetworkConfig.WebPort = txtWebPort.Text;

                iNVMSConfig.NetworkConfig.TimeServer = txtTimeSever.Text;

                iNVMSConfig.NetworkConfig.AutoSyncEnable = chkAutoSyncEnable.Checked;
                if (chkAutoSyncEnable.Checked)
                    iNVMSConfig.NetworkConfig.AutoSync = cmbAutoSync.SelectedItem.ToString();

                iNVMSConfig.NetworkConfig.RTSPEnable = chkRTSPEnable.Checked;
                if (chkRTSPEnable.Checked)
                    iNVMSConfig.NetworkConfig.RTSPPort = txtRTSPPort.Text;

                iNVMSConfig.NetworkConfig.UFTP = chkUFTP.Checked;
                iNVMSConfig.NetworkConfig.OriginSecurity = chkOriginSecurity.Checked;
                iNVMSConfig.NetworkConfig.WhiteList = chkWhiteList.Checked;
                iNVMSConfig.NetworkConfig.HandyView = chkHandyView.Checked;
                iNVMSConfig.NetworkConfig.BandLimit = chkBandLimit.Checked;

                iNVMSConfig.NetworkConfig.Quality = trackQuality.Value;
                iNVMSConfig.NetworkConfig.Frame = trackFrame.Value;

                for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
                {
                    iNVMSConfig.NetworkConfig.TransCams[i] = trans_cams[i];
                }
			}
			else
			{
				chkRTSPEnable.Checked = iNVMSConfig.NetworkConfig.RtspEnabled;
				txtRTSPPort.Text = iNVMSConfig.NetworkConfig.RtspStreamPort.ToString();
                txtServerName.Text = iNVMSConfig.NetworkConfig.ServerName;
                txtRemotePort.Text = iNVMSConfig.NetworkConfig.RemotePort;
                chkTransCamAll.Checked = iNVMSConfig.NetworkConfig.TransCamAll;
                txtDomainName.Text = iNVMSConfig.NetworkConfig.DomainName;
                txtDNSID.Text = iNVMSConfig.NetworkConfig.DNSID;
                txtDNSPassword.Text = iNVMSConfig.NetworkConfig.DNSPassword;
                txtDNSServerPort.Text = iNVMSConfig.NetworkConfig.DNSServerPort;

                chkRemoteEnable.Checked = iNVMSConfig.NetworkConfig.RemoteEnable;
                if (chkRemoteEnable.Checked)
                {
                    txtRemoteSeverPort.Enabled = true;
                    txtRemoteSeverPort.Text = iNVMSConfig.NetworkConfig.RemoteServerPort;
                } else {
                    txtRemoteSeverPort.Enabled = false;
                }

                chkAnomyLogin.Checked = iNVMSConfig.NetworkConfig.AnomyLogin;
                if (chkAnomyLogin.Checked)
                {
                    txtPCViewPort.Enabled = true;
                    txtPCViewPort.Text = iNVMSConfig.NetworkConfig.PCViewPort;
                } else {
                    txtPCViewPort.Enabled = false;
                }

                chkTalkWeb.Checked = iNVMSConfig.NetworkConfig.TalkWeb;
                if (chkTalkWeb.Checked)
                {
                    txtWebPort.Enabled = true;
                    txtWebPort.Text = iNVMSConfig.NetworkConfig.WebPort;
                } else {
                    txtWebPort.Enabled = false;
                }
                
                txtTimeSever.Text = iNVMSConfig.NetworkConfig.TimeServer;

                chkAutoSyncEnable.Checked = iNVMSConfig.NetworkConfig.AutoSyncEnable;
                if (chkAutoSyncEnable.Checked)
                {
                    cmbAutoSync.Enabled = true;
                    
                    cmbAutoSync.Items.Clear();
                    foreach (string str in sync_server)
                    {
                        cmbAutoSync.Items.Add(str);
                    }
                    cmbAutoSync.SelectedIndex = 0;

                    int selectedIndex1 = cmbAutoSync.Items.IndexOf(iNVMSConfig.NetworkConfig.AutoSync);
                    cmbAutoSync.SelectedIndex = selectedIndex1;
                } else {
                    cmbAutoSync.Enabled = false;
                }

                chkRTSPEnable.Checked = iNVMSConfig.NetworkConfig.RTSPEnable;
                if (chkRTSPEnable.Checked)
                {
                    txtRTSPPort.Enabled = true;
                    txtRTSPPort.Text = iNVMSConfig.NetworkConfig.RTSPPort;
                } else {
                    txtRTSPPort.Enabled = false;
                }

                chkUFTP.Checked = iNVMSConfig.NetworkConfig.UFTP;
                chkOriginSecurity.Checked = iNVMSConfig.NetworkConfig.OriginSecurity;
                chkWhiteList.Checked = iNVMSConfig.NetworkConfig.WhiteList;
                chkHandyView.Checked = iNVMSConfig.NetworkConfig.HandyView;
                chkBandLimit.Checked = iNVMSConfig.NetworkConfig.BandLimit;

                trackQuality.Value = iNVMSConfig.NetworkConfig.Quality;
                trackFrame.Value = iNVMSConfig.NetworkConfig.Frame;

                int selectedIndex = cmbSeverIP.Items.IndexOf(iNVMSConfig.NetworkConfig.ServerIP);
                cmbSeverIP.SelectedIndex = selectedIndex;

                for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
                {
                    trans_cams[i] = iNVMSConfig.NetworkConfig.TransCams[i];
                }
                for (i = 1; i <= num_of_checkbox ; i++)
                {
                    ((CheckBox)grbTransCams.Controls["chkTransCam" + i.ToString()]).Checked = iNVMSConfig.NetworkConfig.TransCams[i-1];
                }
			}
		}
        private void chkHandyView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHandyView.Checked)
            {
                btnHandyView.Enabled = true;
            }
            else
            {
                btnHandyView.Enabled = false;
            }
        }

        private void chkBandLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBandLimit.Checked)
            {
                btnBandLimit.Enabled = true;
            }
            else
            {
                btnBandLimit.Enabled = false;
            }
        }

        private void btnHandyView_Click(object sender, EventArgs e)
        {
            FrmNetworkHandyView frmNetworkHandy = new FrmNetworkHandyView();

            if (frmNetworkHandy.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnBandLimit_Click(object sender, EventArgs e)
        {
            FrmNetworkBandwidth frmNetworkBandwidth = new FrmNetworkBandwidth();

            if (frmNetworkBandwidth.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

		private void btnOK_Click(object sender, EventArgs e)
		{
            UpdateData(true);
		}

        private void btnSeverIP_Click(object sender, EventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string ipaddr = "";

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipaddr = ip.ToString();

                    string caption = "Network Detail";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    string netmask = "";
                    netmask = ReturnSubnetmask(ipaddr);

                    var defaultGateway =
                       from nics in NetworkInterface.GetAllNetworkInterfaces()
                       from props in nics.GetIPProperties().GatewayAddresses
                       where nics.OperationalStatus == OperationalStatus.Up
                    select props.Address.ToString();

                    string gateway = defaultGateway.First();

                    string rlt = "IP: " + ipaddr + "\n" + "Subnet: " + netmask + "\n" + "Gateway: " + gateway;

                    // Displays the MessageBox.
                    result = MessageBox.Show(rlt, caption, buttons);

                    break;
                }
            }
        }

        private string ReturnSubnetmask (string ipaddress)
        {
            uint firstOctet = ReturnFirtsOctet(ipaddress);
            if (firstOctet >= 0 && firstOctet <= 127)
                return "255.0.0.0";
            else if (firstOctet >= 128 && firstOctet <= 191)
                return "255.255.0.0";
            else if (firstOctet >= 192 && firstOctet <= 223)
                return "255.255.255.0";
            else return "0.0.0.0";
        }

        private uint ReturnFirtsOctet (string ipAddress)
        {
            IPAddress iPAddress = IPAddress.Parse(ipAddress);
            byte[] byteIP = iPAddress.GetAddressBytes();
            uint ipInUint = (uint)byteIP[0];
            return ipInUint;
        }
        

        private void btnTransCamNext_Click(object sender, EventArgs e)
        {
            if (crt_page < cam_pages)
            {
                crt_page += 1;

                for (i = 1; i <= num_of_checkbox; i++)
                {
                    grbTransCams.Controls["chkTransCam" + i.ToString()].Text = ((crt_page - 1) * num_of_checkbox + i).ToString();
                    ((CheckBox)grbTransCams.Controls["chkTransCam" + i.ToString()]).Checked = trans_cams[(crt_page - 1) * num_of_checkbox + i - 1];
                }
            }
        }

        private void btnTransCamPrev_Click(object sender, EventArgs e)
        {
            if (crt_page > 1)
            {
                crt_page -= 1;

                for (i = 1; i <= num_of_checkbox; i++)
                {
                    grbTransCams.Controls["chkTransCam" + i.ToString()].Text = ((crt_page - 1) * num_of_checkbox + i).ToString();
                    ((CheckBox)grbTransCams.Controls["chkTransCam" + i.ToString()]).Checked = trans_cams[(crt_page - 1) * num_of_checkbox + i - 1];
                }
            }
        }

        private bool allCheckBoxTrue()
        {
            bool all_true = false;

            for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
            {
                if (trans_cams[i] == false)
                {
                    all_true = false;
                    break;
                }

                all_true = true;
            }

            if (all_true)
                return true;
            else
                return false;
        }

        private void processCamCheckBox(int i)
        {
            if (((CheckBox) grbTransCams.Controls["chkTransCam" + i.ToString()]).Checked)
            {
                trans_cams[(crt_page - 1) * num_of_checkbox + i - 1] = true;

                //Console.WriteLine(allCheckBoxTrue());

                if (allCheckBoxTrue())
                    chkTransCamAll.Checked = true;
                else
                    chkTransCamAll.Checked = false;
            }
            else
            {
                trans_cams[(crt_page - 1) * num_of_checkbox + i - 1] = false;
                chkTransCamAll.Checked = false;
            }
        }

        private void chkTransCam1_Click(object sender, EventArgs e)
        {
            processCamCheckBox(1);
        }

        private void chkTransCam2_Click(object sender, EventArgs e)
        {
            processCamCheckBox(2);
        }

        private void chkTransCam3_Click(object sender, EventArgs e)
        {
            processCamCheckBox(3);
        }

        private void chkTransCam4_Click(object sender, EventArgs e)
        {
            processCamCheckBox(4);
        }

        private void chkTransCam5_Click(object sender, EventArgs e)
        {
            processCamCheckBox(5);
        }

        private void chkTransCam6_Click(object sender, EventArgs e)
        {
            processCamCheckBox(6);
        }

        private void chkTransCam7_Click(object sender, EventArgs e)
        {
            processCamCheckBox(7);
        }

        private void chkTransCam8_Click(object sender, EventArgs e)
        {
            processCamCheckBox(8);
        }

        private void chkTransCam9_Click(object sender, EventArgs e)
        {
            processCamCheckBox(9);
        }

        private void chkTransCam10_Click(object sender, EventArgs e)
        {
            processCamCheckBox(10);
        }

        private void chkTransCam11_Click(object sender, EventArgs e)
        {
            processCamCheckBox(11);
        }

        private void chkTransCam12_Click(object sender, EventArgs e)
        {
            processCamCheckBox(12);
        }

        private void chkTransCam13_Click(object sender, EventArgs e)
        {
            processCamCheckBox(13);
        }

        private void chkTransCam14_Click(object sender, EventArgs e)
        {
            processCamCheckBox(14);
        }

        private void chkTransCam15_Click(object sender, EventArgs e)
        {
            processCamCheckBox(15);
        }

        private void chkTransCam16_Click(object sender, EventArgs e)
        {
            processCamCheckBox(16);
        }

        private void chkTransCamAll_Click(object sender, EventArgs e)
        {
            if (chkTransCamAll.Checked)
            {
                foreach (Control c in grbTransCams.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }

                for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
                {
                    trans_cams[i] = true;
                }
            }
            else
            {
                foreach (Control c in grbTransCams.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }

                for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
                {
                    trans_cams[i] = false;
                }
            }
        }

        private void chkRemoteEnable_Click(object sender, EventArgs e)
        {
            if (chkRemoteEnable.Checked)
                txtRemoteSeverPort.Enabled = true;
            else
                txtRemoteSeverPort.Enabled = false;
        }

        private void chkAnomyLogin_Click(object sender, EventArgs e)
        {
            if (chkAnomyLogin.Checked)
                txtPCViewPort.Enabled = true;
            else
                txtPCViewPort.Enabled = false;
        }

        private void chkTalkWeb_Click(object sender, EventArgs e)
        {
            if (chkTalkWeb.Checked)
                txtWebPort.Enabled = true;
            else
                txtWebPort.Enabled = false;
        }

        private void chkAutoSyncEnable_Click(object sender, EventArgs e)
        {
            if (chkAutoSyncEnable.Checked)
            {
                cmbAutoSync.Enabled = true;

                cmbAutoSync.Items.Clear();
                foreach (string str in sync_server)
                {
                    cmbAutoSync.Items.Add(str);
                }
                cmbAutoSync.SelectedIndex = 0;
            }
            else
                cmbAutoSync.Enabled = false;
        }

        private void chkRTSPEnable_Click(object sender, EventArgs e)
        {
            if (chkRTSPEnable.Checked)
                txtRTSPPort.Enabled = true;
            else
                txtRTSPPort.Enabled = false;
        }

        private void btnWhiteList_Click(object sender, EventArgs e)
        {

        }
    }
}

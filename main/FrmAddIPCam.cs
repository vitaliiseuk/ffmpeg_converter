using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;
using iNVMS.CustomControl;
using System.IO;
using System.Diagnostics;

namespace iNVMSMain
{
    public partial class FrmAddIPCam : Form
    {
		NVMSDeviceInfo m_deviceInfo;
		public bool IsNewDevice { get; set; }
		private bool LoadLastCamInfo { get; set; }
		private NVMSPlayer nvmsPlayer;
        public int selected_cam_index = -1;

		public int IPCameraMode
		{
			get
			{
				return iNVMSConfig.IPAddedLast;
			}
			set
			{
				if (iNVMSConfig.IPAddedLast != value)
					LoadLastCamInfo = false;

				iNVMSConfig.IPAddedLast = value;
				if (iNVMSConfig.IPAddedLast == 1)
				{
					cmbProtocolList.SelectedIndex = 0;
				}
				else
				{
					cmbProtocolList.SelectedIndex = 2;
				}
				FrmADDIPCam_RefreshControls();
			}
		}
		public NVMSDeviceInfo DeviceInfo { 
			get
			{
				return m_deviceInfo;
			}
			set
			{
				if (value == null)
					return;

				m_deviceInfo = value;

				cmbProtocolList.SelectedIndex = cmbProtocolList.FindString(value.Name);
				
				cmbModelList.SelectedIndex = cmbModelList.FindString(value.Model);
				

				txtAuthenID.Text = value.UserName;
				txtAuthenPassword.Text = value.Password;
				radioByDeviceID.Checked = value.UseSerialID;
				txtIPAddress.Text = value.UseSerialID ? value.ServerIPAddress : value.IPAddress;
				txtPort.Text = value.UseSerialID ? value.ServerPort.ToString() : value.Port.ToString();
				txtDeviceID.Text = value.SerialID;
				chkEnableAudio.Checked = value.EnableAudio;
				chkDisplayOn.Checked = value.DisplayOn;

				FrmADDIPCam_RefreshControls();

                if (cmbChannel.Items.Count > value.Channel)
				    cmbChannel.SelectedIndex = value.Channel;

				int nModelIndex = cmbModelList.FindString(value.Model);
				if (nModelIndex >= 0)
					cmbModelList.Select(nModelIndex, 1);

				int nNameIndex = cmbProtocolList.FindString(value.Name);
				if (nNameIndex >= 0)
					cmbModelList.Select(nNameIndex, 1);

				LoadLastCamInfo = false;
			} 
		}
        public FrmAddIPCam()
        {
            InitializeComponent();
			nvmsPlayer = new NVMSPlayer(this);
			nvmsPlayer.PreviewMode = true;
			nvmsPlayer.PlayerType = PlayerTypeEnum.PreviewPlayer;
			nvmsPlayer.SetBound(new Rectangle(265, 12, 280, 210));
			nvmsPlayer.ShowHide(true);
			Controls.Add(nvmsPlayer);

			for (int i = 1; i <= 64; i++)
				cmbChannel.Items.Add(i.ToString());
			if (IsNewDevice)
				cmbChannel.Items.Add("All");
			cmbProtocolList.SelectedIndex = 0;
			cmbModelList.SelectedIndex = 0;

			nvmsPlayer.PlayerType = PlayerTypeEnum.PreviewPlayer;

			cmbVideoFormatList.SelectedIndex = 0;

			m_deviceInfo = new NVMSDeviceInfo();
			LoadLastCamInfo = true;
        }
        private void FrmADDIPCam_RefreshControls()
        {
            //if (radProtocol.Checked == true)
            {
                cmbProtocolList.Enabled = true;
                cmbModelList.Enabled = true;
                cmbVideoFormatList.Enabled = true;
                txtIPAddress.Enabled = true;
                txtPort.Enabled = true;
				//if (m_deviceInfo != null && cmbChannel.Items.Count > m_deviceInfo.Channel)
				//	cmbChannel.SelectedIndex = m_deviceInfo.Channel;
				//else
				//	cmbChannel.SelectedIndex = 0;

                Console.Write("AAA");
                Console.WriteLine(cmbChannel.SelectedIndex);
            }

            txtAuthenID.Enabled = chkAuthentication.Checked;
            txtAuthenPassword.Enabled = chkAuthentication.Checked;

			if (cmbProtocolList.SelectedIndex == 1)	//RTSP
			{
				lblIPAddress.Text = "URL";
				txtPort.Enabled = false;
				txtAuthenPassword.Enabled = false;
				txtAuthenID.Enabled = false;
			}
			else
			{
				lblIPAddress.Text = "IP Address";
				txtPort.Enabled = true;
				txtAuthenPassword.Enabled = true;
				txtAuthenID.Enabled = true;
			}

			txtDeviceID.Enabled = radioByDeviceID.Checked;
			lblIPAddress.Text = radioByDeviceID.Checked ? "Server IP" : "Camera IP";
			lblPort.Text = "Port";
        }

        private void FrmAddIPCam_Load(object sender, EventArgs e)
        {
            FrmADDIPCam_RefreshControls();

            cmbChannel.SelectedIndex = cmbChannel.Items.IndexOf(selected_cam_index.ToString());
            
            //btnSaveExit.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void radProtocol_CheckedChanged(object sender, EventArgs e)
        {
            FrmADDIPCam_RefreshControls();
        }

        private void radURL_CheckedChanged(object sender, EventArgs e)
        {
            FrmADDIPCam_RefreshControls();
        }

        private void chkAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            FrmADDIPCam_RefreshControls();
        }

		private NVMSDeviceInfo GetDeviceInfo()
		{
			NVMSDeviceInfo devInfo_back = m_deviceInfo.Clone();
			m_deviceInfo = new NVMSDeviceInfo();

			//if (radProtocol.Checked == true)
			{
				m_deviceInfo.Name = cmbProtocolList.Text;
				m_deviceInfo.Model = cmbModelList.Text;
				m_deviceInfo.UseSerialID = radioByDeviceID.Checked;
				ushort nPort = 0;
				ushort.TryParse(txtPort.Text, out nPort);
				if (radioByDeviceID.Checked)
				{
					m_deviceInfo.ServerIPAddress = txtIPAddress.Text;
					m_deviceInfo.ServerPort = nPort;
				}
				else
				{
					m_deviceInfo.IPAddress = txtIPAddress.Text;
					m_deviceInfo.Port = nPort;
				}
				m_deviceInfo.VideoFormat = cmbVideoFormatList.Text;
				m_deviceInfo.EnableAudio = chkEnableAudio.Checked;
				m_deviceInfo.DisplayOn = chkDisplayOn.Checked;
				m_deviceInfo.SerialID = txtDeviceID.Text;
				//DeviceInfo.TotalChannels = 1;
				if (IsNewDevice && cmbChannel.Text == "All")
					m_deviceInfo.Channel = -1;
				else
					m_deviceInfo.Channel = Int32.Parse(cmbChannel.Text) - 1;

				m_deviceInfo.AliasName = cmbProtocolList.SelectedIndex < 2 ? "Camera" : "DVR";
			}
			//else
			//{
			//	m_deviceInfo.Name = "URL";
			//	m_deviceInfo.AliasName = "Camera(URL)";
			//	m_deviceInfo.Channel = 0;
			//}

            if (!IsNewDevice)
                m_deviceInfo.ID = devInfo_back.ID;      //K 20171027. ID is null when edit camera
			m_deviceInfo.UserName = txtAuthenID.Text;
			m_deviceInfo.Password = txtAuthenPassword.Text;
			m_deviceInfo.EnableAudio = chkEnableAudio.Checked;
			m_deviceInfo.DeviceUpdated = IsNewDevice || !iNVMSConfig.CompareDeviceInfo(m_deviceInfo, devInfo_back);
			m_deviceInfo.UseSerialID = radioByDeviceID.Checked;
			m_deviceInfo.SerialID = txtDeviceID.Text;
			return DeviceInfo;
		}
		private async void btnSaveExit_Click(object sender, EventArgs e)
		{
			if (radioByDeviceID.Checked == false)
			{
				if (string.IsNullOrEmpty(txtIPAddress.Text))
				{
					string strIPAddressAlias = cmbProtocolList.SelectedIndex == 1 ? "URL" : "IP address";
					MessageBox.Show("Please enter " + strIPAddressAlias + ".", "Missing " + strIPAddressAlias);
					txtIPAddress.Focus();
					return;
				}
			}
			else
			{
				if (string.IsNullOrEmpty(txtIPAddress.Text))
				{
					MessageBox.Show("Please enter IP address of cloud server", "Missing Server Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					txtIPAddress.Focus();
					return;
				}
			}
			iNVMSConfig.GeneralConfig.LastConfigIPCamera = GetDeviceInfo();
			await nvmsPlayer.StopRealPlay();
			this.DialogResult = DialogResult.OK;
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private async void btnConnect_Click(object sender, EventArgs e)
		{
			await nvmsPlayer.StopRealPlay();
			NVMSDeviceInfo devInfo = GetDeviceInfo();
			CameraObject camera = new CameraObject();
			camera.DeviceInfo = devInfo;

			camera.ClientInfo.PreviewMode = false;

			if (devInfo.Name == "ONVIF")
            {
				 camera.SDK = new OnVIFCamSDK(camera);
            }
			else if (devInfo.Name == "RTSP")
			{
				camera.SDK = new RTSPSDK(camera);
			}
			else if (devInfo.Name == "iLinkPro iHD Series" || devInfo.Name == "XM XVR")
				camera.SDK = new H264NetSDK(camera);
			else if (devInfo.Name == "AVer NV Series")
				camera.SDK = new AVerDSSNVSDK(camera);

			await nvmsPlayer.StartRealPlay(camera, iNVMSConfig.GeneralConfig.DefaultFPSForPreview);
		}

		private void OnProtocolList_SelChange(object sender, EventArgs e)
		{
			UpdateModelList();
		}
      
		private void UpdateModelList()
		{
			cmbModelList.Items.Clear();
			//temporary code. need to be updated for new camera integration
			switch (cmbProtocolList.SelectedIndex)
			{
				case 0:	//onvif
					cmbModelList.Items.Add("----");
					lblIPAddress.Text = "IP Address";
					txtPort.Enabled = true;
					txtAuthenID.Enabled = true;
					txtAuthenPassword.Enabled = true;
					txtPort.Text = iNVMSConfig.GeneralConfig.DefaultPort_ONVIF.ToString();
					break;
				case 1:	//rtsp
					cmbModelList.Items.Add("TCP");
					cmbModelList.Items.Add("UDP");
					lblIPAddress.Text = "URL";
					txtPort.Enabled = false;
					txtAuthenID.Enabled = false;
					txtAuthenPassword.Enabled = false;
					txtPort.Text = iNVMSConfig.GeneralConfig.DefaultPort_RTSP.ToString();
					break;
				case 2:
				case 3:
				case 4:
					cmbModelList.Items.Add("----");
					lblIPAddress.Text = "IP Address";
					txtPort.Enabled = true;
					txtAuthenID.Enabled = true;
					txtAuthenPassword.Enabled = true;
					txtPort.Text = iNVMSConfig.GeneralConfig.DefaultPort_XM.ToString();
					break;
				default:
					cmbModelList.Items.Add("----");
					lblIPAddress.Text = "IP Address";
					txtPort.Enabled = true;
					txtAuthenID.Enabled = true;
					txtAuthenPassword.Enabled = true;
					break;
			}

			if (cmbProtocolList.SelectedIndex == 2 || cmbProtocolList.SelectedIndex == 3)		//XM SVR
			{
				radioByIP.Enabled = true;
				radioByDeviceID.Enabled = true;
			}
			else
			{
				radioByIP.Enabled = false;
				radioByDeviceID.Enabled = false;

				radioByIP.Checked = true;
				radioByDeviceID.Checked = false;
			}
			cmbModelList.SelectedIndex = 0;
		}

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
            Process.Start(path);
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
			nvmsPlayer.StopRealPlay();
			//if (nvmsPlayer.Camera != null)
			//	nvmsPlayer.Camera.SDK.StopRealPlay(0);
        }

		private void FrmAddIPCam_Shown(object sender, EventArgs e)
		{
			if (LoadLastCamInfo && iNVMSConfig.GeneralConfig.LastConfigIPCamera != null)
			{
				string alias = iNVMSConfig.IPAddedLast == 1? "Camera" : "DVR";
				if (iNVMSConfig.GeneralConfig.LastConfigIPCamera.AliasName == alias)
					DeviceInfo = iNVMSConfig.GeneralConfig.LastConfigIPCamera;
			}

			nvmsPlayer.ShowHide(true);
		}

		private void FrmAddIPCam_Move(object sender, EventArgs e)
		{
			nvmsPlayer.ShowHide(true);
		}

		private void btnConfigDefaultPorts_Click(object sender, EventArgs e)
		{
			FrmConfigDefaultPort frmConfigDefaultPort = new FrmConfigDefaultPort();
			if (frmConfigDefaultPort.ShowDialog(this) == DialogResult.OK)
			{

			}
		}

		private void radioByIP_CheckedChanged(object sender, EventArgs e)
		{
			FrmADDIPCam_RefreshControls();
		}

		private void radioByDeviceID_CheckedChanged(object sender, EventArgs e)
		{
			FrmADDIPCam_RefreshControls();
		}
    }
}

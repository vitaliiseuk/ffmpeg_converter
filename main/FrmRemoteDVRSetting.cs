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
using System.Threading.Tasks;

namespace iNVMSMain
{
    public partial class FrmRemoteDVRSetting : Form
    {
		private NVMSDeviceInfo m_deviceInfo;
//		private int m_nPreviewChannel = 0;
		private CameraObject cameraToConnectTry = null;
		public bool IsNewDevice { get; set; }
		private bool LoadLastCamInfo { get; set; }
		public NVMSDeviceInfo DeviceInfo
		{
			get
			{
				return m_deviceInfo;
			}
			set
			{
				if (value == null)
					return;

				m_deviceInfo = value;
				if (value.Name == "iLinkPro iHD Series")
					cmbManufacture.SelectedIndex = 0;
				else if (value.Name == "XM SVR")
					cmbManufacture.SelectedIndex = 1;
				else if (value.Name == "AVer NV Series")
					cmbManufacture.SelectedIndex = 2;
				txtUserID.Text = value.UserName;
				txtPassword.Text = value.Password;
				txtIP.Text = value.IPAddress;
				txtPort.Text = value.Port.ToString();
				cmbChannel.SelectedIndex = value.Channel;
				LoadLastCamInfo = false;
			}
		}
        public FrmRemoteDVRSetting()
        {
            InitializeComponent();
			m_deviceInfo = new NVMSDeviceInfo();
			cmbManufacture.SelectedIndex = 0; //AVer DSS
			cmbChannel.SelectedIndex = 0;

			nvmsPlayer.PlayerType = PlayerTypeEnum.PreviewPlayer;

			m_deviceInfo = new NVMSDeviceInfo();
			nvmsPlayer.ShowHide(true);
			LoadLastCamInfo = true;
        }

        private void FrmRemoteDVRSetting_Load(object sender, EventArgs e)
        {

            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
			iNVMSConfig.GeneralConfig.LastConfigXVR = GetDeviceInfo();
			nvmsPlayer.StopRealPlay();
			if (Owner != null)
				Owner.Activate();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
			await nvmsPlayer.StopRealPlay();
			if (Owner != null)
				Owner.Activate();
        }

		private NVMSDeviceInfo GetDeviceInfo()
		{
			NVMSDeviceInfo devInfo_back = m_deviceInfo.Clone();

			m_deviceInfo = new NVMSDeviceInfo();
			m_deviceInfo.Name = cmbManufacture.Text;
			m_deviceInfo.Model = "----";
			m_deviceInfo.UserName = txtUserID.Text;
			m_deviceInfo.Password = txtPassword.Text;
			m_deviceInfo.IPAddress = txtIP.Text;
			//DeviceInfo.TotalChannels = Int32.Parse(txtChannel.Text);
			m_deviceInfo.Channel = Int32.Parse(cmbChannel.Text) - 1;
			try
			{
				m_deviceInfo.Port = ushort.Parse(txtPort.Text);
			}
			catch (FormatException)
			{
				m_deviceInfo.Port = 0;
			}
			m_deviceInfo.AliasName = "DVR";
			m_deviceInfo.DeviceUpdated = IsNewDevice || !iNVMSConfig.CompareDeviceInfo(devInfo_back, m_deviceInfo);

			return DeviceInfo;
		}
		private async void btnConnect_Click(object sender, EventArgs e)
		{
			NVMSDeviceInfo devInfo = GetDeviceInfo();
			if (cameraToConnectTry == null)
				cameraToConnectTry = new CameraObject();

			cameraToConnectTry.DeviceInfo = devInfo.Clone();
			if (cameraToConnectTry.SDK == null)
			{
				if (cameraToConnectTry.DeviceInfo.Name == "AVer NV Series")
					cameraToConnectTry.SDK = new AVerDSSNVSDK(cameraToConnectTry);
				else if (cameraToConnectTry.DeviceInfo.Name == "iLinkPro iHD Series" || cameraToConnectTry.DeviceInfo.Name == "XM XVR")
					cameraToConnectTry.SDK = new H264NetSDK(cameraToConnectTry);
			}

			//cameraToConnectTry.CameraOption.MyChannelNum = m_nPreviewChannel;

			//m_nPreviewChannel = 0;
			Task<bool> ret = PreviewCamera();
			bool bRet = await ret;
			//if (bRet)
			//	txtPreviewChannel.Text = (m_nPreviewChannel + 1).ToString() + "/" + cameraToConnectTry.DeviceInfo.TotalChannels.ToString();
		}

		private void btnNextChannel_Click(object sender, EventArgs e)
		{
			//if (cameraToConnectTry == null)
			//	return;

			//m_nPreviewChannel++;
			//if (m_nPreviewChannel >= cameraToConnectTry.DeviceInfo.TotalChannels)
			//{
			//	m_nPreviewChannel = cameraToConnectTry.DeviceInfo.TotalChannels;
			//	return;
			//}

			//txtPreviewChannel.Text = (m_nPreviewChannel + 1).ToString() + "/" + cameraToConnectTry.DeviceInfo.TotalChannels.ToString();
			//cameraToConnectTry.CameraOption.MyChannelNum = m_nPreviewChannel;

			//await PreviewCamera();
		}

		private async Task<bool> PreviewCamera()
		{
			await nvmsPlayer.StopRealPlay(true);
			Task<bool> ret = nvmsPlayer.StartRealPlay(cameraToConnectTry, iNVMSConfig.GeneralConfig.DefaultFPSForPreview);
			bool bRet = await ret;
			return bRet;
		}
		private void btnPrevChannel_Click(object sender, EventArgs e)
		{
			//if (cameraToConnectTry == null)
			//	return;

			//m_nPreviewChannel--;
			//if (m_nPreviewChannel < 0)
			//{
			//	m_nPreviewChannel = 0;
			//	return;
			//}

			//txtPreviewChannel.Text = (m_nPreviewChannel + 1).ToString() + "/" + cameraToConnectTry.DeviceInfo.TotalChannels.ToString();
			//cameraToConnectTry.CameraOption.MyChannelNum = m_nPreviewChannel;

			//await PreviewCamera();
		}

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

		private void FrmRemoteDVRSetting_Shown(object sender, EventArgs e)
		{
			if (LoadLastCamInfo && iNVMSConfig.GeneralConfig.LastConfigXVR != null)
				DeviceInfo = iNVMSConfig.GeneralConfig.LastConfigXVR;

			nvmsPlayer.ShowHide(true);
		}

		private void FrmRemoteDVRSetting_Move(object sender, EventArgs e)
		{
			nvmsPlayer.ShowHide(true);
		}
    }
}

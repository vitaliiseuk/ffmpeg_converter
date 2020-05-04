using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iNVMS.SDK;

namespace iNVMSMain
{
	public partial class FrmConfigDefaultPort : Form
	{
		public FrmConfigDefaultPort()
		{
			InitializeComponent();
			txtXMXVR.Text = iNVMSConfig.GeneralConfig.DefaultPort_XM.ToString();
			txtONVIF.Text = iNVMSConfig.GeneralConfig.DefaultPort_ONVIF.ToString();
			txtRTSP.Text = iNVMSConfig.GeneralConfig.DefaultPort_RTSP.ToString();
			txtAVer.Text = iNVMSConfig.GeneralConfig.DefaultPort_AVER.ToString();
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			txtXMXVR.Text = GeneralSettingsDef.DefaultPort_XM_ORG.ToString();
			txtONVIF.Text = GeneralSettingsDef.DefaultPort_ONVIF_ORG.ToString();
			txtRTSP.Text = GeneralSettingsDef.DefaultPort_RTSP_ORG.ToString();
			txtAVer.Text = GeneralSettingsDef.DefaultPort_AVER_ORG.ToString();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				iNVMSConfig.GeneralConfig.DefaultPort_XM = int.Parse(txtXMXVR.Text);
				iNVMSConfig.GeneralConfig.DefaultPort_RTSP = int.Parse(txtRTSP.Text);
				iNVMSConfig.GeneralConfig.DefaultPort_ONVIF = int.Parse(txtONVIF.Text);
				iNVMSConfig.GeneralConfig.DefaultPort_AVER = int.Parse(txtAVer.Text);
			}
			catch
			{

			}

			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}

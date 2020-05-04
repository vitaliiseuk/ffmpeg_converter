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
	public partial class FrmDisplaySelectForCam : Form
	{
		private CheckBox[] chkCameras = new CheckBox[iNVMSConfig.MaxCameraCount];
		public FrmDisplaySelectForCam()
		{
			InitializeComponent();
			Screen[] screens = Screen.AllScreens;
            
			CreateControls();
			int i;
			for (i = 0; i < screens.Count(); i++)
			{
                //MessageBox.Show(iNVMSConfig.SystemConfig.m_dualMonitorSetitng.MonitorConfig[i]);

				if (iNVMSConfig.SystemConfig.m_dualMonitorSetitng.MonitorConfig[i] != "Display Cameras")
				{
					string strItem = string.Format("Monitor {0}", i + 1);
					cmbMonitors.Items.Add(strItem);
				}
			}

			if (cmbMonitors.Items.Count > 0)
				cmbMonitors.SelectedIndex = 0;
		}
		private void CreateControls()
		{
			int x_start = 20;
			int y_start = 80;
			int y_offset = 10;
			int x_offset = 10;
			Size chkSize = new Size(80, 20);

			int i;
			for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
			{
				chkCameras[i] = new CheckBox();
				chkCameras[i].Bounds = new Rectangle(x_start + (i % 8) * (x_offset + chkSize.Width), y_start + (i / 8) * 50, chkSize.Width, chkSize.Height);
				chkCameras[i].Text = String.Format("Camera{0}", i + 1);
				chkCameras[i].Tag = i;
				chkCameras[i].CheckedChanged += chkCamera_CheckedChanged;
				Controls.Add(chkCameras[i]);
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			iNVMSConfig.SaveAllSettings();
		}

		private void cmbMonitors_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nMonitor = 0;
			int.TryParse(cmbMonitors.Text.Substring(8, cmbMonitors.Text.Length - 8), out nMonitor);
			nMonitor = nMonitor - 1;
			for (int i = 0; i < iNVMSConfig.MaxCameraCount; i++)
			{
				if (iNVMSConfig.SystemConfig.m_miscellaneousSetting.DisplayCamera[i] == nMonitor)
					chkCameras[i].Checked = true;
				else
					chkCameras[i].Checked = false;
			}
		}

		private void chkCamera_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkCamera = sender as CheckBox;
			int nCamera = (int)chkCamera.Tag;

			int nMonitor = 0;
			int.TryParse(cmbMonitors.Text.Substring(8, cmbMonitors.Text.Length - 8), out nMonitor);
            string tt1 = cmbMonitors.Text;
			nMonitor = nMonitor - 1;

			if (nMonitor >= 0)
			{
				iNVMSConfig.SystemConfig.m_miscellaneousSetting.DisplayCamera[nCamera] = chkCamera.Checked ? nMonitor : 0;
			}
		}

		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			int nMonitor = 0;
			int.TryParse(cmbMonitors.Text.Substring(8, cmbMonitors.Text.Length - 8), out nMonitor);
			nMonitor = nMonitor - 1;

			if (nMonitor < 0)
				return;
			for (int i = 0; i < iNVMSConfig.MaxCameraCount; i++)
			{
				chkCameras[i].Checked = false;
				iNVMSConfig.SystemConfig.m_miscellaneousSetting.DisplayCamera[i] = nMonitor;
			}
		}
		private void btnDeselectAll_Click(object sender, EventArgs e)
		{
			int nMonitor = 0;
			int.TryParse(cmbMonitors.Text.Substring(8, cmbMonitors.Text.Length - 8), out nMonitor);
			nMonitor = nMonitor - 1;

			if (nMonitor < 0)
				return;

			for (int i = 0; i < iNVMSConfig.MaxCameraCount; i++)
			{
				chkCameras[i].Checked = false;
				iNVMSConfig.SystemConfig.m_miscellaneousSetting.DisplayCamera[i] = 0;
			}
		}

        private void FrmDisplaySelectForCam_Load(object sender, EventArgs e)
        {

        }
    }
}

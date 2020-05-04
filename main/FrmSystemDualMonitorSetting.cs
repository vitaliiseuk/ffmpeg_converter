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
    public partial class FrmSystemDualMonitorSetting : Form
    {
        public FrmSystemDualMonitorSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
			ConfigComboBoxContents();
        }
		private void ApplyConfig()
		{
			ComboBox[] comboBoxes = {cmbPrimary, comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, 
									comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15};

			int i;
			bool bConfigChanged = false;
			for (i = 0; i < 16; i++)
			{
				if (iNVMSConfig.SystemConfig.m_dualMonitorSetitng.MonitorConfig[i] != comboBoxes[i].Text)
					bConfigChanged = true;

				iNVMSConfig.SystemConfig.m_dualMonitorSetitng.MonitorConfig[i] = comboBoxes[i].Text;
			}
			if (bConfigChanged)
			{

			}
		}
        private void btnOK_Click(object sender, EventArgs e)
        {
			ApplyConfig();
        }

		private void ConfigComboBoxContents()
		{
			Screen[] screens = Screen.AllScreens;
			ComboBox[] comboBoxes = {cmbPrimary, comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, 
									comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15};

			int i;
			for (i = 0; i < screens.Length; i++)
				comboBoxes[i].Enabled = true;

            //Console.WriteLine();
            //Console.WriteLine(comboBoxes[0].Enabled);

			for (; i < 16; i++)
				comboBoxes[i].Enabled = false;

			for (i = 0; i < 16; i++)
			{
				if (i == 0)
					comboBoxes[i].Items.Add("VMS");
				comboBoxes[i].Items.Add("Playback");
				comboBoxes[i].Items.Add("Emap");
				comboBoxes[i].Items.Add("Display Cameras");

				string config = iNVMSConfig.SystemConfig.m_dualMonitorSetitng.MonitorConfig[i];
				if (config == "Playback")
					comboBoxes[i].SelectedIndex = 0;
				else if (config == "Emap")
					comboBoxes[i].SelectedIndex = 1;
				else if (config == "Display Cameras")
					comboBoxes[i].SelectedIndex = 2;
			}

			cmbPrimary.Enabled = false;
			cmbPrimary.SelectedIndex = 0;
		}

		private void btnSelectCameras_Click(object sender, EventArgs e)
		{
			ApplyConfig();
			FrmDisplaySelectForCam frmSelectCam = new FrmDisplaySelectForCam();
			if (frmSelectCam.ShowDialog(this) == DialogResult.OK)
			{

			}
		}
    }
}

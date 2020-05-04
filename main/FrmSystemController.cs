using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using iNVMS.SDK;

namespace iNVMSMain
{
    public partial class FrmSystemController : Form
    {
        private string[] sysControl = { "System Controller Pro", "System Controller Pro 485" };
        private int[] portNumber = { 8000, 8080 };

        public FrmSystemController()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.OK;

            chkEnable.Checked = iNVMSConfig.SystemConfig.m_systemController.Enable;

            if (iNVMSConfig.SystemConfig.m_systemController.Enable == true)
            {
                cmbModel.Items.Clear();
                foreach (string str in sysControl)
                {
                    cmbModel.Items.Add(str);
                }

                if (iNVMSConfig.SystemConfig.m_systemController.Model == sysControl[0])
                {
                    cmbModel.SelectedIndex = 0;

                    cmbPort.Enabled = false;
                    nudDVRID.Enabled = false;
                } else if (iNVMSConfig.SystemConfig.m_systemController.Model == sysControl[1]) {

                    cmbModel.SelectedIndex = 1;

                    cmbPort.Enabled = true;
                    cmbPort.Items.Clear();
                    foreach (int value in portNumber)
                        cmbPort.Items.Add(value);

                    int selectedIndex = cmbPort.Items.IndexOf(iNVMSConfig.SystemConfig.m_systemController.Port);
                    cmbPort.SelectedIndex = selectedIndex;

                    nudDVRID.Enabled = true;
                    nudDVRID.Value = iNVMSConfig.SystemConfig.m_systemController.DVRID;
                }
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                cmbModel.Enabled = true;

                cmbModel.Items.Clear();
                foreach (string str in sysControl)
                {
                    cmbModel.Items.Add(str);
                }
                cmbModel.SelectedIndex = 0;
            }
            else
            {
                cmbModel.Enabled = false;
                cmbPort.Enabled = false;
                nudDVRID.Enabled = false;
            }
        }

        private void FrmSystemController_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbModel.SelectedIndex == 1)
            {
                cmbPort.Enabled = true;
                nudDVRID.Enabled = true;

                cmbPort.Items.Clear();
                foreach (int value in portNumber)
                    cmbPort.Items.Add(value);

                cmbPort.SelectedIndex = 0;
            }
            else
            {
                cmbPort.Enabled = false;
                nudDVRID.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            iNVMSConfig.SystemConfig.m_systemController.Enable = chkEnable.Checked;
            if (chkEnable.Checked)
            {
                iNVMSConfig.SystemConfig.m_systemController.Model = cmbModel.SelectedItem.ToString();

                if (iNVMSConfig.SystemConfig.m_systemController.Model == sysControl[1])
                {
                    iNVMSConfig.SystemConfig.m_systemController.Port = Convert.ToInt32(cmbPort.SelectedItem.ToString());
                    iNVMSConfig.SystemConfig.m_systemController.DVRID = (int)nudDVRID.Value;
                }
            }
        }
    }
}

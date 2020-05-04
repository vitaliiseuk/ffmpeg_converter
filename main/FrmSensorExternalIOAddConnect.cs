using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iNVMSMain
{
    public partial class FrmSensorExternalIOAddConnect : Form
    {
        public FrmSensorExternalIOAddConnect()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void rdbEthernet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEthernet.Checked)
            {
                grbIPSetting.Enabled = true;
                grbPortSetting.Enabled = false;
            }
            else
            {
                grbIPSetting.Enabled = false;
                grbPortSetting.Enabled = true;
            }
        }

        private void btnSwitchIODevice_Click(object sender, EventArgs e)
        {
            FrmSensorExternalIOAddConnectSwitchDevice frmSensorExternalIOAddConnectSwitchDevice = new FrmSensorExternalIOAddConnectSwitchDevice();

            if (frmSensorExternalIOAddConnectSwitchDevice.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

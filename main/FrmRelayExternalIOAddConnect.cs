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
    public partial class FrmRelayExternalIOAddConnect : Form
    {
        public FrmRelayExternalIOAddConnect()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void rdbRS232_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRS232.Checked)
            {
                grbPortSetting.Enabled = true;
            }
            else
            {
                grbPortSetting.Enabled = false;
            }
        }

        private void rdbEthernet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEthernet.Checked)
            {
                grbIPSetting.Enabled = true;
            }
            else
            {
                grbIPSetting.Enabled = false;
            }
        }

        private void btnSwitchIODevice_Click(object sender, EventArgs e)
        {
            FrmRelayExternalIOAddConnectSwitchDevice frmRelaySwitchDevice = new FrmRelayExternalIOAddConnectSwitchDevice();

            if (frmRelaySwitchDevice.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

 
    }
}

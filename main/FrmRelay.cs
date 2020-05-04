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
    public partial class FrmRelay : Form
    {
        public FrmRelay()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                grbTest.Enabled = true;
                chkPulseTrigEnable.Enabled = true;

            }
            else
            {
                grbTest.Enabled = false;
                chkPulseTrigEnable.Enabled = false;
            }
        }

        private void btnExternIO_Click(object sender, EventArgs e)
        {
            FrmRelayExternalIO frmRelayExternIO = new FrmRelayExternalIO();

            if (frmRelayExternIO.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

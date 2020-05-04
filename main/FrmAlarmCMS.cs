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
    public partial class FrmAlarmCMS : Form
    {
        public FrmAlarmCMS()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkTransIPAdr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransIPAdr.Checked)
            {
                grbAllowList.Enabled = true;
            }
            else
            {
                grbAllowList.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAlarmCMSAddIP frmAlarmAddIP = new FrmAlarmCMSAddIP();

            if (frmAlarmAddIP.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

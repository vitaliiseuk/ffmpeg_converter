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
    public partial class FrmAlarmEnlargeCamview : Form
    {
        public FrmAlarmEnlargeCamview()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkRetrieveTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetrieveTime.Checked)
            {
                txtRetrieveTime.Enabled = true;
            }
            else
            {
                txtRetrieveTime.Enabled = false;
            }
        }
    }
}

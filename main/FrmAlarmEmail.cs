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
    public partial class FrmAlarmEmail : Form
    {
        public FrmAlarmEmail()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuthentication.Checked)
            {
                txtMailID.Enabled = true;
                txtMailPassword.Enabled = true;
            }
            else
            {
                txtMailID.Enabled = false;
                txtMailPassword.Enabled = false;
            }
        }

    }
}

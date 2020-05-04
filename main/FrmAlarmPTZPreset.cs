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
    public partial class FrmAlarmPTZPreset : Form
    {
        public FrmAlarmPTZPreset()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkPTZEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPTZEnable.Checked)
            {
                grbAlarmTrigger.Enabled = true;
                grbAlarmClose.Enabled = true;
            }
            else
            {
                grbAlarmTrigger.Enabled = false;
                grbAlarmClose.Enabled = false;
            }
        }

    }
}

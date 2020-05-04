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
    public partial class FrmAlarmRecord : Form
    {
        public FrmAlarmRecord()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                foreach(Control c in grbRecordCams.Controls)
                {
                    if(c.GetType()==typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach(Control c in grbRecordCams.Controls)
                {
                    if(c.GetType()==typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }


    }
}

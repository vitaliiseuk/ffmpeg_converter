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
    public partial class FrmAlarmPOSKeyword : Form
    {
        public FrmAlarmPOSKeyword()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnKeyAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeywordAdd.Text))
            {
                listKeyword.Enabled = true;
                listKeyword.Columns.Add(txtKeywordAdd.Text,100);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                foreach (Control c in POSCams.Controls)
                {
                    if(c.GetType()==typeof(CheckBox))
                    {
                        ((CheckBox) c).Checked=true;
                    }
                }
            }
            else
            {
                foreach(Control c in POSCams.Controls)
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

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
    public partial class FrmBackupQuickBackup : Form
    {
        SaveFileDialog saveFileDialog;

        public FrmBackupQuickBackup()
        {
            
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\";

        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBackCamAll.Checked)
            {
                foreach(Control c in chkBackCamAll.Controls)
                {
                    if(c.GetType()==typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in chkBackCamAll.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }
    }
}

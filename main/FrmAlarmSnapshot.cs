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
    public partial class FrmAlarmSnapshot : Form
    {
        SaveFileDialog saveFileDialog;

        public FrmAlarmSnapshot()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\";

        }

        private void chkDeleteImages_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteImages.Checked)
            {
                txtDeleteImage.Enabled = true;
            }
            else
            {
                txtDeleteImage.Enabled = false;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

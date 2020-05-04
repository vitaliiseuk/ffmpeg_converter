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
    public partial class FrmAlarmLaunchProgram : Form
    {
        OpenFileDialog openFileDialog;

        public FrmAlarmLaunchProgram()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "Exe file(*.exe)|*.exe";

        }

        private void chkMultipleInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMultipleInstance.Checked)
            {
                grbProgramPath.Enabled = true;
            }
            else
            {
                grbProgramPath.Enabled = false;
            }
        }

        private void btnProgramPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

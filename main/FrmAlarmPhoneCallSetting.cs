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
    public partial class FrmAlarmPhoneCallSetting : Form
    {
        OpenFileDialog openFileDialog;

        public FrmAlarmPhoneCallSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "All(*.*)|*.*";

        }

        private void btnVoiceFilePath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnVoiceRecord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want to create a new sound file ?");
        }
    }
}

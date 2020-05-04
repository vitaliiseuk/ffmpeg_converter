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
    public partial class FrmAlarmPhoneCall : Form
    {
        public FrmAlarmPhoneCall()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAlarmPhoneCallSetting frmAlarmPhoneCallSetting = new FrmAlarmPhoneCallSetting();

            if (frmAlarmPhoneCallSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

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
    public partial class FrmSensor : Form
    {
        public FrmSensor()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnExternIO_Click(object sender, EventArgs e)
        {
            FrmSensorExternalIO frmSensorExternalIO = new FrmSensorExternalIO();

            if (frmSensorExternalIO.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

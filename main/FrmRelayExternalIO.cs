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
    public partial class FrmRelayExternalIO : Form
    {
        public FrmRelayExternalIO()
        {
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnectAdd_Click(object sender, EventArgs e)
        {
            FrmRelayExternalIOAddConnect frmRelayExternIOConnectAdd = new FrmRelayExternalIOAddConnect();

            if (frmRelayExternIOConnectAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}

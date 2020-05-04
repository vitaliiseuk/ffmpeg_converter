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
    public partial class FrmRecordingMotionAdvance : Form
    {
        public FrmRecordingMotionAdvance()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void trackRegion1_Scroll(object sender, EventArgs e)
        {
            labRegion1.Text = trackRegion1.Value.ToString();
        }

        private void trackRegion2_Scroll(object sender, EventArgs e)
        {
            labRegion2.Text = trackRegion2.Value.ToString();
        }

        private void trackRegion3_Scroll(object sender, EventArgs e)
        {
            labRegion3.Text = trackRegion3.Value.ToString();
        }
    }
}

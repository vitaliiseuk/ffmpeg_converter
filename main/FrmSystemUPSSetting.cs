using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;

namespace iNVMSMain
{
    public partial class FrmSystemUPSSetting : Form
    {
        public FrmSystemUPSSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void FrmSystemUPSSetting_Load(object sender, EventArgs e)
        {
            txtSupplyStatus.Text = iNVMSConfig.SystemConfig.m_upsSetting.SupplyStatus;
            txtLifeTime.Text = iNVMSConfig.SystemConfig.m_upsSetting.LifeTime.ToString();
            txtFuelGauging.Text = iNVMSConfig.SystemConfig.m_upsSetting.FuelGauge.ToString();
            txtCapacityBelow.Text = iNVMSConfig.SystemConfig.m_upsSetting.CapacityBelow.ToString();
        }
                
        private void btnOK_Click(object sender, EventArgs e)
        {
            iNVMSConfig.SystemConfig.m_upsSetting.SupplyStatus = txtSupplyStatus.Text;
            iNVMSConfig.SystemConfig.m_upsSetting.LifeTime = Convert.ToInt32(txtLifeTime.Text);
            iNVMSConfig.SystemConfig.m_upsSetting.FuelGauge = Convert.ToInt32(txtFuelGauging.Text);
            iNVMSConfig.SystemConfig.m_upsSetting.CapacityBelow = Convert.ToInt32(txtCapacityBelow.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iNVMS.SDK;
namespace iNVMSMain
{
    public partial class FrmSystemPreviewStreamSetting : Form
    {
        public FrmSystemPreviewStreamSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

			if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_1_MainStream)
				radioLayout1Main.Checked = true;
			else
				radioLayout1Sub.Checked = true;

			if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_4_MainStream)
				radioLayout4Main.Checked = true;
			else
				radioLayout4Sub.Checked = true;

			if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_6_MainStream)
				radioLayout6Main.Checked = true;
			else
				radioLayout6Sub.Checked = true;

            if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_9_MainStream)
                radioLayout9Main.Checked = true;
            else
                radioLayout9Sub.Checked = true;

            if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_16_MainStream)
				radioLayout16Main.Checked = true;
			else
				radioLayout16Sub.Checked = true;

			if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_32_MainStream)
				radioLayout36Main.Checked = true;
			else
				radioLayout36Sub.Checked = true;

			if (iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_64_MainStream)
				radioLayout64Main.Checked = true;
			else
				radioLayout64Sub.Checked = true;
        }

		private void btnOK_Click(object sender, EventArgs e)
		{
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_1_MainStream = radioLayout1Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_4_MainStream = radioLayout4Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_6_MainStream = radioLayout6Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_9_MainStream = radioLayout9Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_16_MainStream = radioLayout16Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_32_MainStream = radioLayout36Main.Checked;
			iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_64_MainStream = radioLayout64Main.Checked;
		}
    }
}

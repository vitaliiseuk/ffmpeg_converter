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
    public partial class FrmSystemConfiguration : Form
    {
        private iNVMS.SDK.SystemData sd = new iNVMS.SDK.SystemData();
        public FrmSystemConfiguration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsageInfo_Click(object sender, EventArgs e)
        {
            FrmSystemConfigurationUsageInfo frmsyStemConfigUsageInfo = new FrmSystemConfigurationUsageInfo();

            if (frmsyStemConfigUsageInfo.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        /// <summary>
        /// run "control /name Microsoft.Language"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            string cmdStr = "control /name Microsoft.Language";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run devmgmt.msc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeviceManager_Click(object sender, EventArgs e)
        {
            string cmdStr = "devmgmt.msc";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run "control mmsys.cpl sounds"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSoundSetting_Click(object sender, EventArgs e)
        {
            string cmdStr = "control mmsys.cpl sounds";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run  "control printers"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            string cmdStr = "control printers";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run "control modem.cpl"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoneOption_Click(object sender, EventArgs e)
        {
            string cmdStr = "control modem.cpl";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run "RunDll32.exe shell32.dll,SHHelpShortcuts_RunDLL Connect"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapNetwork_Click(object sender, EventArgs e)
        {
            string cmdStr = "RunDll32.exe shell32.dll,SHHelpShortcuts_RunDLL Connect";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run "net use /del *"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnectNet_Click(object sender, EventArgs e)
        {
            string cmdStr = "net use /del *";
            sd.runCmd(cmdStr);
        }

        /// <summary>
        /// run "control inetcpl.cpl,,4"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPPPoESetting_Click(object sender, EventArgs e)
        {
            string cmdStr = "control inetcpl.cpl,,4";
            sd.runCmd(cmdStr);
        }
    }
}

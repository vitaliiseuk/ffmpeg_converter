using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;
using System.IO;
using System.Diagnostics;

namespace iNVMSMain
{
    public partial class FrmSystemMiscellaneousSetting : Form
    {
        public FrmSystemMiscellaneousSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
			txtAutoScanPeriod.Text = iNVMSConfig.SystemConfig.m_miscellaneousSetting.AutoScanInterval.ToString();
			txtFreeSpaceLimit.Text = iNVMSConfig.SystemConfig.m_miscellaneousSetting.FreeSpaceOfPartition.ToString();

            chkStatusReport.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.StatusReport;
            chkDesktopLock.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.DesktopLock;
            chkbeep.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.BeepSignal;
            chkShutdown.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.ShutDownOs;
            chkMandatory.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.MandatoryRecording;
            chkOverlay.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableOverlay;
            chkLivePlayBack.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableLivePlayBack;
            chkUage.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.IncreaseMemoryUsage;
            chkScreensaver.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.ScreenSaver;

            chkask.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.LeaveSystem;
            chkResequence.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.ResequenceChannel;
            chkRemember.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.RememberPlayBackMode;
            chkOSK.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.OSK;
            chkEnableNetwork.Checked = iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableNetworkStorage;

            txtScreensaver.Text = iNVMSConfig.SystemConfig.m_miscellaneousSetting.ScreenSaveMin;
            txtAutoScanPeriod.Text = iNVMSConfig.SystemConfig.m_miscellaneousSetting.AutoScanInterval.ToString();
            txtPlayBackTime.Text = iNVMSConfig.SystemConfig.m_miscellaneousSetting.PlayBackTime;

            if (chkStatusReport.Checked)
                btnSetup.Enabled = true;
            else
                btnSetup.Enabled = false;

            if (chkDesktopLock.Checked)
                btnDetail.Enabled = true;
            else
                btnDetail.Enabled = false;

            if (chkScreensaver.Checked)
                txtScreensaver.Enabled = true;
            else
                txtScreensaver.Enabled = false;

            if (chkOSK.Checked)
                btnKeyboard.Enabled = true;
            else
                btnKeyboard.Enabled = false;

            cmbTemperature.DropDownStyle = ComboBoxStyle.DropDownList;
            cmdPlayBackMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmdDateFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            
            cmbTemperature.Items.Add("C");
            cmdDateFormat.Items.Add("mm/dd/year");
            cmdPlayBackMode.Items.Add("Select date and time");

            cmbTemperature.SelectedIndex = 0;
            cmdPlayBackMode.SelectedIndex = 0;
            cmdDateFormat.SelectedIndex = 0;
        }

		private void FrmSystemMiscellaneousSetting_Load(object sender, EventArgs e)
		{
			    
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Int32.TryParse(txtAutoScanPeriod.Text, out iNVMSConfig.SystemConfig.m_miscellaneousSetting.AutoScanInterval);
			Int32.TryParse(txtFreeSpaceLimit.Text, out iNVMSConfig.SystemConfig.m_miscellaneousSetting.FreeSpaceOfPartition);

            iNVMSConfig.SystemConfig.m_miscellaneousSetting.StatusReport = chkStatusReport.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.DesktopLock = chkDesktopLock.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.BeepSignal = chkbeep.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.ShutDownOs = chkShutdown.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.MandatoryRecording = chkMandatory.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableOverlay = chkOverlay.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableLivePlayBack = chkLivePlayBack.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.IncreaseMemoryUsage = chkUage.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.ScreenSaver = chkScreensaver.Checked;

            iNVMSConfig.SystemConfig.m_miscellaneousSetting.LeaveSystem = chkask.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.ResequenceChannel = chkResequence.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.RememberPlayBackMode = chkRemember.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.OSK = chkOSK.Checked;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.EnableNetworkStorage = chkEnableNetwork.Checked;

            iNVMSConfig.SystemConfig.m_miscellaneousSetting.ScreenSaveMin = txtScreensaver.Text;
            iNVMSConfig.SystemConfig.m_miscellaneousSetting.PlayBackTime = txtPlayBackTime.Text;
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;

            Process.Start(path);
        }

        private void chkStatusReport_Click(object sender, EventArgs e)
        {
            if (chkStatusReport.Checked)
                btnSetup.Enabled = true;
            else
                btnSetup.Enabled = false;
        }
    }
}

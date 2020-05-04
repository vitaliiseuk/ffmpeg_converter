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
    public partial class FrmAlarm : Form
    {
        public FrmAlarm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnAbnormEvent_Click(object sender, EventArgs e)
        {
            FrmAlarmAbnormalEvent frmAlarmAbnormEvent = new FrmAlarmAbnormalEvent();

            if (frmAlarmAbnormEvent.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPOSKeyword_Click(object sender, EventArgs e)
        {
            FrmAlarmPOSKeyword frmAlarmPOSKeyword = new FrmAlarmPOSKeyword();

            if (frmAlarmPOSKeyword.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnAlarmMessage_Click(object sender, EventArgs e)
        {
            FrmAlarmMessage frmAlarmMessage = new FrmAlarmMessage();

            if (frmAlarmMessage.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPanic_Click(object sender, EventArgs e)
        {
            FrmAlarmButton frmAlarmButton = new FrmAlarmButton();

            if (frmAlarmButton.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEnlargeCamView_Click(object sender, EventArgs e)
        {
            FrmAlarmEnlargeCamview frmAlarmEnlargeCamView = new FrmAlarmEnlargeCamview();

            if (frmAlarmEnlargeCamView.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnRelayOutput_Click(object sender, EventArgs e)
        {
            FrmAlarmRelay frmAlarmRelay = new FrmAlarmRelay();

            if (frmAlarmRelay.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPlayWarnSound_Click(object sender, EventArgs e)
        {
            FrmAlarmSound frmAlarmSoundSetting = new FrmAlarmSound();

            if (frmAlarmSoundSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            FrmAlarmEmail frmAlarmEmail = new FrmAlarmEmail();

            if (frmAlarmEmail.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnFileTrans_Click(object sender, EventArgs e)
        {
            FrmAlarmFileTransfer frmAlarmFileTransfer = new FrmAlarmFileTransfer();

            if (frmAlarmFileTransfer.ShowDialog(this) == DialogResult.OK)
            {

            }

        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            FrmAlarmRecord frmAlarmRecord = new FrmAlarmRecord();

            if (frmAlarmRecord.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            FrmAlarmMMS frmAlarmMMS = new FrmAlarmMMS();

            if (frmAlarmMMS.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPTZPreset_Click(object sender, EventArgs e)
        {
            FrmAlarmPTZPreset frmAlarmPTZPreset = new FrmAlarmPTZPreset();

            if (frmAlarmPTZPreset.ShowDialog(this) == DialogResult.OK)
            {

            }
        }


        private void chkAlarmSOP_CheckedChanged(object sender, EventArgs e)
        {

            MessageBox.Show("Please edit your SOP setting first.");
        }

        private void btnAlarmSOP_Click(object sender, EventArgs e)
        {
            FrmAlarmSOP frmAlarmSOP = new FrmAlarmSOP();

            if (frmAlarmSOP.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSendToCMS_Click(object sender, EventArgs e)
        {
            FrmAlarmCMS frmAlarmCMS = new FrmAlarmCMS();

            if (frmAlarmCMS.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnLaunchProgram_Click(object sender, EventArgs e)
        {
            FrmAlarmLaunchProgram frmAlarmLaunchProgram = new FrmAlarmLaunchProgram();

            if (frmAlarmLaunchProgram.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSnapShot_Click(object sender, EventArgs e)
        {
            FrmAlarmSnapshot frmAlarmSnapshot = new FrmAlarmSnapshot();

            if (frmAlarmSnapshot.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnMakePhoneCall_Click(object sender, EventArgs e)
        {
            FrmAlarmPhoneCall frmAlarmPhoneCall = new FrmAlarmPhoneCall();

            if (frmAlarmPhoneCall.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkAlmResetTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlmResetTime.Checked)
            {
                txtAlmResetTime.Enabled = true;
            }
            else
            {
                txtAlmResetTime.Enabled = false;
            }
        }
    }
}

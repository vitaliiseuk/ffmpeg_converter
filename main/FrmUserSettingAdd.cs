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
    public partial class FrmUserSettingAdd : Form
    {
        private bool[] CameraVisibleState = new bool[64];
        private int nTotalPanelCount = 4;
        private int nVisibleCamPerPanel = 16;
        private int nVisibleCamPanelCount = 0;
        public UserInfo userInfo;
        public FrmUserSettingAdd()
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void chkTimeSpanEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimeSpanEnable.Checked)
            {
                timePickerActiveDate.Enabled = true;
                timePickerExpiryDate.Enabled = true;
            }
            else
            {
                timePickerActiveDate.Enabled = false;
                timePickerExpiryDate.Enabled = false;
            }
        }
        public void SetUserInfo(UserInfo user)
        {
            userInfo = user;
            txtName.Text = userInfo.ID;
            txtPassword.Text = AccountSettingsDef.Decrypt(userInfo.Password, userInfo.ID);
            txtPWConfirm.Text = txtPassword.Text;
            txtDescription.Text = txtDescription.Text;

            rdbUser.Checked = user.Level_Plain == "User";
            rdbAdmin.Checked = user.Level_Plain == "Administrator";

            chkSystemSetting.Checked = user.GetPermission(USER_PERMISSION.SystemSetting);
            chkRecord.Checked = user.GetPermission(USER_PERMISSION.Record);
            chkNetControl.Checked = user.GetPermission(USER_PERMISSION.NetworkControl);
            chkPlayback.Checked = user.GetPermission(USER_PERMISSION.Playback);
            chkPowerOff.Checked = user.GetPermission(USER_PERMISSION.PowerOff);
            chkAdvancedMode.Checked = user.GetPermission(USER_PERMISSION.AdvancedMode);
            chkPTZControl.Checked = user.GetPermission(USER_PERMISSION.PTZControl);
            chkEMap.Checked = user.GetPermission(USER_PERMISSION.EMap);
            chkBackUp.Checked = user.GetPermission(USER_PERMISSION.Backup);
            chkScheduler.Checked = user.GetPermission(USER_PERMISSION.Scheduler);
            chkPOS.Checked = user.GetPermission(USER_PERMISSION.POS);
            chkMinimize.Checked = user.GetPermission(USER_PERMISSION.Minimize);
            chkReboot.Checked = user.GetPermission(USER_PERMISSION.Reboot);
            chkExport.Checked = user.GetPermission(USER_PERMISSION.Export);
            chkPTZSetup.Checked = user.GetPermission(USER_PERMISSION.PTZSetup);

            chkPCViewNet.Checked = user.GetPermission(USER_PERMISSION.Network);
            chkPCRemoteConsole.Checked = user.GetPermission(USER_PERMISSION.RemoteConsole);
            chkPCRemoteEmap.Checked = user.GetPermission(USER_PERMISSION.RemoteEmap);
            chkPCRemoteRecord.Checked = user.GetPermission(USER_PERMISSION.RemoteRecord);
            chkRemoteLogView.Checked = user.GetPermission(USER_PERMISSION.RemoteLogViewer);
            chkIPCam.Checked = user.GetPermission(USER_PERMISSION.IPCamera);
            chkRemoteSetup.Checked = user.GetPermission(USER_PERMISSION.RemoteSetup);
            chkRATInfinite.Checked = user.GetPermission(USER_PERMISSION.RemoteAccessInfinite);
            chkTimeSpanEnable.Checked = user.GetPermission(USER_PERMISSION.TimeSpanEnable);

            int nBaseIndex = (int)USER_PERMISSION.Camera1;
            //CheckBox[] checkBoxes = { chkCam1, chkCam2, chkCam3, chkCam4, chkCam5, chkCam6, chkCam7, chkCam8, chkCam9, chkCam10, chkCam11, chkCam12, 
            //                          chkCam13, chkCam14, chkCam15, chkCam16};
            int i;
            for (i = 0; i < 64; i++)
            {
                CameraVisibleState[i] = user.GetPermission((USER_PERMISSION)(nBaseIndex + i));
            }

            RefreshCamLabel();
        }
        public UserInfo GetUesrInfo()
        {
            userInfo = new UserInfo();

            userInfo.ID = txtName.Text;
            userInfo.Password = AccountSettingsDef.Encrypt(txtPassword.Text, txtName.Text);
            userInfo.Description = txtDescription.Text;
            userInfo.Level_Plain = rdbAdmin.Checked == true ? "Administrator" : "User";

            if (!rdbAdmin.Checked)
            {
                userInfo.SetPermission(USER_PERMISSION.SystemSetting, chkSystemSetting.Checked);
                userInfo.SetPermission(USER_PERMISSION.Record, chkRecord.Checked);
                userInfo.SetPermission(USER_PERMISSION.NetworkControl, chkNetControl.Checked);
                userInfo.SetPermission(USER_PERMISSION.Playback, chkPlayback.Checked);
                userInfo.SetPermission(USER_PERMISSION.PowerOff, chkPowerOff.Checked);
                userInfo.SetPermission(USER_PERMISSION.AdvancedMode, chkAdvancedMode.Checked);
                userInfo.SetPermission(USER_PERMISSION.PTZControl, chkPTZControl.Checked);
                userInfo.SetPermission(USER_PERMISSION.EMap, chkEMap.Checked);
                userInfo.SetPermission(USER_PERMISSION.Backup, chkBackUp.Checked);
                userInfo.SetPermission(USER_PERMISSION.Scheduler, chkScheduler.Checked);
                userInfo.SetPermission(USER_PERMISSION.POS, chkPOS.Checked);
                userInfo.SetPermission(USER_PERMISSION.Minimize, chkMinimize.Checked);
                userInfo.SetPermission(USER_PERMISSION.Reboot, chkReboot.Checked);
                userInfo.SetPermission(USER_PERMISSION.Export, chkExport.Checked);
                userInfo.SetPermission(USER_PERMISSION.PTZSetup, chkPTZSetup.Checked);
                userInfo.SetPermission(USER_PERMISSION.Network, chkPCViewNet.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteConsole, chkPCRemoteConsole.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteEmap, chkPCRemoteEmap.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteRecord, chkPCRemoteRecord.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteLogViewer, chkRemoteLogView.Checked);
                userInfo.SetPermission(USER_PERMISSION.IPCamera, chkIPCam.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteSetup, chkRemoteSetup.Checked);
                userInfo.SetPermission(USER_PERMISSION.RemoteAccessInfinite, chkRATInfinite.Checked);
                userInfo.SetPermission(USER_PERMISSION.TimeSpanEnable, chkTimeSpanEnable.Checked);

                int nBaseIndex = (int)USER_PERMISSION.Camera1;
                for (int i = 0; i < 64; i++)
                    userInfo.SetPermission((USER_PERMISSION)(nBaseIndex + i), CameraVisibleState[i]);
            }
            return userInfo;
        }
        private void chkSkipPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkipPassword.Checked)
            {
                txtPassword.Enabled = false;
                txtPWConfirm.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
                txtPWConfirm.Enabled = true;
            }
        }

        private void chkRATInfinite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRATInfinite.Checked)
            {
                txtRATime.Enabled = false;
            }
            else
            {
                txtRATime.Enabled = true;
            }
        }

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAdmin.Checked)
            {
                grbControlRight.Enabled = false;
                grbPCViewer.Enabled = false;
                grbVisibleCam.Enabled = false;
                grbTimeSpan.Enabled = false;
            }
            else
            {
                grbControlRight.Enabled = true;
                grbPCViewer.Enabled = true;
                grbVisibleCam.Enabled = true;
                grbTimeSpan.Enabled = true;
            }
        }

        private void chkVisiCamAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisiCamAll.Checked)
            {
                foreach (Control c in grbVisibleCam.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in grbVisibleCam.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;

            Process.Start(path);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCamVisibleState();
            if (txtPassword.Text.CompareTo(txtPWConfirm.Text) != 0)
                MessageBox.Show("Passwords do not match.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                DialogResult = DialogResult.OK;
        }
        private void SetCamVisibleState()
        {
            int nBaseIndex = nVisibleCamPanelCount * nVisibleCamPerPanel;
            CheckBox[] checkBoxes = { chkCam1, chkCam2, chkCam3, chkCam4, chkCam5, chkCam6, chkCam7, chkCam8, chkCam9, chkCam10, chkCam11, chkCam12, 
                                      chkCam13, chkCam14, chkCam15, chkCam16};
            for (int i = nBaseIndex; i < nBaseIndex + nVisibleCamPerPanel; i++)
                CameraVisibleState[i] = checkBoxes[i - nBaseIndex].Checked;
        }
        private void btnVisiCamNext_Click(object sender, EventArgs e)
        {
            if (nVisibleCamPanelCount >= nTotalPanelCount - 1)
                return;
            SetCamVisibleState();
            nVisibleCamPanelCount++;
            RefreshCamLabel();
        }

        private void btnVisiCamPrev_Click(object sender, EventArgs e)
        {
            if (nVisibleCamPanelCount <= 0)
                return;

            SetCamVisibleState();
            nVisibleCamPanelCount--;
            RefreshCamLabel();
        }

        private void RefreshCamLabel()
        {
            CheckBox[] checkBoxes = { chkCam1, chkCam2, chkCam3, chkCam4, chkCam5, chkCam6, chkCam7, chkCam8, chkCam9, chkCam10, chkCam11, chkCam12, 
                                      chkCam13, chkCam14, chkCam15, chkCam16};

            int nBaseIndex = nVisibleCamPanelCount * nVisibleCamPerPanel;

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Text = (nBaseIndex + i + 1).ToString();
                checkBoxes[i].Checked = CameraVisibleState[i + nBaseIndex];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using iNVMS.SDK;
using System.Globalization;

namespace iNVMSMain
{
    public partial class FrmSystemSettings : Form
    {
        private iNVMS.SDK.SystemData sd = new iNVMS.SDK.SystemData();

        public List<String> storage_paths = new List<String>();
        public string rm_storage_paths = "";

        public FrmSystemSettings()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            
            UpdateData(false);
        }

        public void UpdateData(bool bUpdateValue)
        {
            if (bUpdateValue)
            {
                iNVMSConfig.SystemConfig.m_loginSetting.AutoLogin = chkAutoLogin.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.AskPasswordForLogin = chkAskPassword.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.AutoRecord = chkAutoRecord.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.AutoStartNetwork = chkAutoStartNetwork.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.LoginCompactMode = chkLoginCompact.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.SilentLaunch = chkSilentLaunch.Checked;
                iNVMSConfig.SystemConfig.m_loginSetting.GuestMode = chkGuestMode.Checked;
                iNVMSConfig.SystemConfig.m_dualMonitorSetitng.Enable = chkEnableDualMonitor.Checked;
				iNVMSConfig.SystemConfig.UseGPU = chkUseGPU.Checked;
                iNVMSConfig.SystemConfig.DeleteRecord = chkDeleteRecord.Checked;
                iNVMSConfig.SystemConfig.MovetoRecord = chkMoveTo.Checked;
                iNVMSConfig.SystemConfig.DeleteTimeInterval = Convert.ToInt32(txtDeleteRecord.Text);
                iNVMSConfig.SystemConfig.DeleteEventInterval = Convert.ToInt32(txtDeleteEvent.Text);
                iNVMSConfig.SystemConfig.MovetoPath = txtMoveTo.Text;
                iNVMSConfig.SystemConfig.UPSEnable = chkUPSEnable.Checked;
                iNVMSConfig.SystemConfig.AttentionEnable = chkAttentionEnable.Checked;
                iNVMSConfig.SystemConfig.TimesPerDay = Convert.ToInt32(txtTimesPerDay.Text);
                iNVMSConfig.SystemConfig.DeleteEvent = checkBox1.Checked;
                iNVMSConfig.SystemConfig.DefaultUser = cmbDefaultUser.SelectedItem.ToString();

                iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Clear();
                foreach (string value in storage_paths)
                {
                    iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Add(value);
                }
            }
            else
            {
                chkAutoLogin.Checked = iNVMSConfig.SystemConfig.m_loginSetting.AutoLogin;
                chkAskPassword.Checked = iNVMSConfig.SystemConfig.m_loginSetting.AskPasswordForLogin;
                chkAutoRecord.Checked = iNVMSConfig.SystemConfig.m_loginSetting.AutoRecord;
                chkAutoStartNetwork.Checked = iNVMSConfig.SystemConfig.m_loginSetting.AutoStartNetwork;
                chkLoginCompact.Checked = iNVMSConfig.SystemConfig.m_loginSetting.LoginCompactMode;
                chkSilentLaunch.Checked = iNVMSConfig.SystemConfig.m_loginSetting.SilentLaunch;
                chkGuestMode.Checked = iNVMSConfig.SystemConfig.m_loginSetting.GuestMode;
                chkEnableDualMonitor.Checked = iNVMSConfig.SystemConfig.m_dualMonitorSetitng.Enable;
				chkUseGPU.Checked = iNVMSConfig.SystemConfig.UseGPU;
                chkDeleteRecord.Checked = iNVMSConfig.SystemConfig.DeleteRecord;
                chkMoveTo.Checked = iNVMSConfig.SystemConfig.MovetoRecord;
                txtDeleteRecord.Text = iNVMSConfig.SystemConfig.DeleteTimeInterval.ToString();
                txtDeleteEvent.Text = iNVMSConfig.SystemConfig.DeleteEventInterval.ToString();
                txtMoveTo.Text = iNVMSConfig.SystemConfig.MovetoPath;
                chkUPSEnable.Checked = iNVMSConfig.SystemConfig.UPSEnable;
                chkAttentionEnable.Checked = iNVMSConfig.SystemConfig.AttentionEnable;
                txtTimesPerDay.Text = iNVMSConfig.SystemConfig.TimesPerDay.ToString();
                checkBox1.Checked = iNVMSConfig.SystemConfig.DeleteEvent;

                RefreshStroageListView();

                storage_paths.Clear();
                foreach (string value in iNVMSConfig.SystemConfig.m_storageSetting.VideoPath)
                {
                    storage_paths.Add(value);
                }

                if (chkAttentionEnable.Checked == true)
                {
                    txtTimesPerDay.Enabled = true;
                }
                else
                {
                    txtTimesPerDay.Enabled = false;
                }

                //Console.WriteLine("-------------");
                //Console.WriteLine(iNVMSConfig.AccountConfig.UserList.Count);
                int sel_index = 0;

                for (int i = 0; i < iNVMSConfig.AccountConfig.UserList.Count; i++)
                {
                    //Console.WriteLine(iNVMSConfig.AccountConfig.UserList[i].ID);
                    if (iNVMSConfig.SystemConfig.DefaultUser == iNVMSConfig.AccountConfig.UserList[i].ID)
                        sel_index = i;

                    cmbDefaultUser.Items.Add(iNVMSConfig.AccountConfig.UserList[i].ID);
                }
                cmbDefaultUser.SelectedIndex = sel_index;
            }
        }
		public string QueryFolderPath()
		{
			string folderPath = "";
			FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
			if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
			{
				folderPath = folderBrowserDialog1.SelectedPath;
			}

			return folderPath;
		}

		private void RefreshStroageListView()
		{
			listViewStoragePath.Items.Clear();
			foreach (string strPath in iNVMSConfig.SystemConfig.m_storageSetting.VideoPath)
			{
				float fTotalGigaByte = .0f;
				float fFreeGigaByte = .0f;
				
				bool bRet = LocalServiceProvider.GetDriveSpaceInfo(strPath, ref fTotalGigaByte, ref fFreeGigaByte);
				string[] strRow = {fFreeGigaByte.ToString("0.00") + "GB", fTotalGigaByte.ToString("0.00") + "GB"};
				listViewStoragePath.Items.Add(strPath).SubItems.AddRange(strRow);
			}
		}
        private void chkDeleteRecord_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDeleteRecord.Checked)
            {
                txtDeleteRecord.Enabled = true;

                if (iNVMSConfig.SystemConfig.is_delete_set == false)
                {
                    iNVMSConfig.SystemConfig.setDate = DateTime.Now;
                    iNVMSConfig.SystemConfig.is_delete_set = true;
                }
            }
            else
            {
                iNVMSConfig.SystemConfig.is_delete_set = false;
                txtDeleteRecord.Enabled = false;
            }
        }

        private void chkDeleteEvent_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkMoveTo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveTo.Checked)
            {
                txtMoveTo.Enabled = true;
                btnMoveTo.Enabled = true;
            }
            else
            {
                txtMoveTo.Enabled = false;
                btnMoveTo.Enabled = false;
            }
        }

        private void btnMoveTo_click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtMoveTo.Text = openFileDialog.SelectedPath;
                iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Clear();
                iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Add(txtMoveTo.Text);

                storage_paths.Clear();
                storage_paths.Add(txtMoveTo.Text);

                RefreshStroageListView();

            }

        }

        private void btnConfigImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Filter = "Configure File (*.cfg)|*.cfg|All files (*.*)|*.*";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                //Create a filestream
                FileStream fStr;
                try
                {
                    //Set filestream to the result of the pick of the user
                    fStr = new FileStream(theDialog.FileName, FileMode.Open, FileAccess.Read);

                    //Create a streamreader, sr, to read the file
                    StreamReader sr = new StreamReader(fStr);
                    //While the end of the file has not been reached...
                    while (sr.Peek() >= 0)
                    {
                        //Create a 'line' that contains the current line of the textfile
                        string line = sr.ReadLine();
                        //Console.WriteLine(line);

                        string[] temp = line.Split(new char[] { ',' });
                        
                        // Storage Path
                        if (temp[0] == "VideoPath")
                        {
                            storage_paths.Clear();
                            for (int i = 1; i < temp.Length; i++)
                            {
                                storage_paths.Add(temp[i]);
                            }

                            listViewStoragePath.Items.Clear();
                            foreach (string strPath in storage_paths)
                            {
                                float fTotalGigaByte = .0f;
                                float fFreeGigaByte = .0f;

                                bool bRet = LocalServiceProvider.GetDriveSpaceInfo(strPath, ref fTotalGigaByte, ref fFreeGigaByte);
                                string[] strRow = { fFreeGigaByte.ToString("0.00") + "GB", fTotalGigaByte.ToString("0.00") + "GB" };
                                listViewStoragePath.Items.Add(strPath).SubItems.AddRange(strRow);
                            }
                        } else if (temp[0] == "DeleteRecord")
                        {
                            if (temp[1] == "True")
                            {
                                chkDeleteRecord.Checked = true;
                                txtDeleteRecord.Text = temp[2];
                            } else {
                                chkDeleteRecord.Checked = false;
                                txtDeleteRecord.Enabled = false;
                            }
                        } else if (temp[0] == "MovetoRecord")
                        {
                            if (temp[1] == "True")
                            {
                                chkMoveTo.Checked = true;
                                txtMoveTo.Text = temp[2];
                            }
                            else
                            {
                                chkMoveTo.Checked = false;
                                txtMoveTo.Enabled = false;
                            }
                        }
                        else if (temp[0] == "UseGPU")     // GPU Frame
                        {
                            if (temp[1] == "True")
                            {
                                chkUseGPU.Checked = true;
                                btnGPUSetting.Enabled = true;
                            }
                            else
                            {
                                chkUseGPU.Checked = false;
                                btnGPUSetting.Enabled = false;
                            }
                        }
                        else if (temp[0] == "AutoScanInterval")       // Miscella Frame
                        {
                            Int32.TryParse(temp[1], out iNVMSConfig.SystemConfig.m_miscellaneousSetting.AutoScanInterval);
                        } else if (temp[0] == "FreeSpaceOfPartition")
                        {
                            Int32.TryParse(temp[1], out iNVMSConfig.SystemConfig.m_miscellaneousSetting.FreeSpaceOfPartition);
                        }
                        else if (temp[0] == "DualMonitor")        // Monitor Frame
                        {
                            if (temp[1] == "True")
                            {
                                chkEnableDualMonitor.Checked = true;
                                btnDualMonSetting.Enabled = true;
                            } else {
                                chkEnableDualMonitor.Checked = false;
                                btnDualMonSetting.Enabled = false;
                            }
                        }
                        else if (temp[0] == "AutoLogin")      // Login Frame
                        {
                            if (temp[1] == "True")
                                chkAutoLogin.Checked = true;
                            else
                                chkAutoLogin.Checked = false;
                        } else if (temp[0] == "AskPassword")
                        {
                            if (temp[1] == "True")
                                chkAskPassword.Checked = true;
                            else
                                chkAskPassword.Checked = false;
                        } else if (temp[0] == "AutoRecord")
                        {
                            if (temp[1] == "True")
                                chkAutoRecord.Checked = true;
                            else
                                chkAutoRecord.Checked = false;
                        } else if (temp[0] == "AutoStartNetwork")
                        {
                            if (temp[1] == "True")
                                chkAutoStartNetwork.Checked = true;
                            else
                                chkAutoStartNetwork.Checked = false;
                        } else if (temp[0] == "LoginCompact")
                        {
                            if (temp[1] == "True")
                                chkLoginCompact.Checked = true;
                            else
                                chkLoginCompact.Checked = false;
                        } else if (temp[0] == "SilentLaunch")
                        {
                            if (temp[1] == "True")
                                chkSilentLaunch.Checked = true;
                            else
                                chkSilentLaunch.Checked = false;
                        } else if (temp[0] == "GuestMode")
                        {
                            if (temp[1] == "True")
                                chkGuestMode.Checked = true;
                            else
                                chkGuestMode.Checked = false;
                        }
                        else if (temp[0] == "Preview_1_MainStream")       // Preview Stream Setting
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_1_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_1_MainStream = false;
                        } else if (temp[0] == "Preview_4_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_4_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_4_MainStream = false;
                        } else if (temp[0] == "Preview_6_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_6_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_6_MainStream = false;
                        } else if (temp[0] == "Preview_9_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_9_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_9_MainStream = false;
                        } else if (temp[0] == "Preview_16_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_16_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_16_MainStream = false;
                        } else if (temp[0] == "Preview_32_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_32_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_32_MainStream = false;
                        } else if (temp[0] == "Preview_64_MainStream")
                        {
                            if (temp[1] == "True")
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_64_MainStream = true;
                            else
                                iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_64_MainStream = false;
                        }
                        else if (temp[0] == "UPSEnable")         // UPS Frame
                        {
                            if (temp[1] == "True")
                            {
                                chkUPSEnable.Checked = true;
                                btnUPSSetting.Enabled = true;

                                iNVMSConfig.SystemConfig.m_upsSetting.SupplyStatus = temp[2];
                                iNVMSConfig.SystemConfig.m_upsSetting.LifeTime = Convert.ToInt32(temp[3]);
                                iNVMSConfig.SystemConfig.m_upsSetting.FuelGauge = Convert.ToInt32(temp[4]);
                                iNVMSConfig.SystemConfig.m_upsSetting.CapacityBelow = Convert.ToInt32(temp[5]);
                            }
                            else
                            {
                                chkUPSEnable.Checked = false;
                                btnUPSSetting.Enabled = false;
                            }
                        }
                        else if (temp[0] == "SystemController")      // SystemController
                        {
                            if (temp[1] == "True")
                            {
                                iNVMSConfig.SystemConfig.m_systemController.Enable = true;
                                iNVMSConfig.SystemConfig.m_systemController.Model = temp[2];
                                if (iNVMSConfig.SystemConfig.m_systemController.Model == "System Controller Pro 485")
                                {
                                    iNVMSConfig.SystemConfig.m_systemController.Port = Convert.ToInt32(temp[3]);
                                    iNVMSConfig.SystemConfig.m_systemController.DVRID = Convert.ToInt32(temp[4]);
                                }
                            } else {
                                iNVMSConfig.SystemConfig.m_systemController.Enable = false;
                            }
                        }
                    }
                    //Close the file so other modules can access it
                    sr.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error opening file", "Error message");
                }

            }
        }

        private void btnConfigExport_Click(object sender, EventArgs e)
        {
            string config_string = "";

            // Building output text
            if (listViewStoragePath.Items.Count != 0)
            {
                config_string += "VideoPath";
                List<string> list = listViewStoragePath.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
                foreach (var value in list)
                {
                    config_string += "," + value;
                }
                config_string += "\n";
            }

            if (chkDeleteRecord.Checked)
            {
                config_string += "DeleteRecord" + "," + chkDeleteRecord.Checked + "," + txtDeleteRecord.Text;
            } else {
                config_string += "DeleteRecord" + "," + chkDeleteRecord.Checked;
            }
            config_string += "\n";

            if (chkMoveTo.Checked)
            {
                config_string += "MovetoRecord" + "," + chkMoveTo.Checked + "," + txtMoveTo.Text;
            } else {
                config_string += "MovetoRecord" + "," + chkMoveTo.Checked;
            }
            config_string += "\n";

            config_string += "UseGPU" + "," + chkUseGPU.Checked;
            config_string += "\n";

            config_string += "AutoScanInterval" + "," + iNVMSConfig.SystemConfig.m_miscellaneousSetting.AutoScanInterval;
            config_string += "\n";

            config_string += "FreeSpaceOfPartition" + "," + iNVMSConfig.SystemConfig.m_miscellaneousSetting.FreeSpaceOfPartition;
            config_string += "\n";

            config_string += "DualMonitor" + "," + chkEnableDualMonitor.Checked;
            config_string += "\n";

            config_string += "AutoLogin" + "," + chkAutoLogin.Checked;
            config_string += "\n";

            config_string += "AskPassword" + "," + chkAskPassword.Checked;
            config_string += "\n";

            config_string += "AutoRecord" + "," + chkAutoRecord.Checked;
            config_string += "\n";

            config_string += "AutoStartNetwork" + "," + chkAutoStartNetwork.Checked;
            config_string += "\n";

            config_string += "LoginCompact" + "," + chkLoginCompact.Checked;
            config_string += "\n";

            config_string += "SilentLaunch" + "," + chkSilentLaunch.Checked;
            config_string += "\n";

            config_string += "GuestMode" + "," + chkGuestMode.Checked;
            config_string += "\n";

            config_string += "Preview_1_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_1_MainStream;
            config_string += "\n";

            config_string += "Preview_4_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_4_MainStream;
            config_string += "\n";

            config_string += "Preview_6_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_6_MainStream;
            config_string += "\n";

            config_string += "Preview_9_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_9_MainStream;
            config_string += "\n";

            config_string += "Preview_16_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_16_MainStream;
            config_string += "\n";

            config_string += "Preview_32_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_32_MainStream;
            config_string += "\n";

            config_string += "Preview_64_MainStream" + "," + iNVMSConfig.SystemConfig.m_previewStreamSetting.Preview_64_MainStream;
            config_string += "\n";

            if (chkUPSEnable.Checked)
            {
                config_string += "UPSEnable" + "," + chkUPSEnable.Checked;
                config_string += "," + iNVMSConfig.SystemConfig.m_upsSetting.SupplyStatus;
                config_string += "," + iNVMSConfig.SystemConfig.m_upsSetting.LifeTime;
                config_string += "," + iNVMSConfig.SystemConfig.m_upsSetting.FuelGauge;
                config_string += "," + iNVMSConfig.SystemConfig.m_upsSetting.CapacityBelow;
            } else {
                config_string += "UPSEnable" + "," + chkUPSEnable.Checked;
            }
            config_string += "\n";

            if (iNVMSConfig.SystemConfig.m_systemController.Enable)
            {
                if (iNVMSConfig.SystemConfig.m_systemController.Model == "System Controller Pro")
                {
                    config_string += "SystemController" + "," + iNVMSConfig.SystemConfig.m_systemController.Enable;
                    config_string += "," + iNVMSConfig.SystemConfig.m_systemController.Model;
                } else if (iNVMSConfig.SystemConfig.m_systemController.Model == "System Controller Pro 485") {
                    config_string += "SystemController" + "," + iNVMSConfig.SystemConfig.m_systemController.Enable;
                    config_string += "," + iNVMSConfig.SystemConfig.m_systemController.Model;
                    config_string += "," + iNVMSConfig.SystemConfig.m_systemController.Port;
                    config_string += "," + iNVMSConfig.SystemConfig.m_systemController.DVRID;
                }
            } else{
                config_string += "SystemController" + "," + iNVMSConfig.SystemConfig.m_systemController.Enable;
            }
            // End of Building


            // Saving into configure file (*.cfg)
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "new.cfg";
            // set filters - this can be done in properties as well
            savefile.Filter = "Configure File (*.cfg)|*.cfg|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string name = savefile.FileName;
                File.WriteAllText(name, config_string);
            }

            Console.WriteLine(config_string);
        }

        private void btnMiscelSetting_Click(object sender, EventArgs e)
        {
            FrmSystemMiscellaneousSetting frmSystemMiscellaneousSetting = new FrmSystemMiscellaneousSetting();

            if (frmSystemMiscellaneousSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkEnableDualMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDualMonitor.Checked)
            {
                btnDualMonSetting.Enabled = true;
            }
            else
            {
                btnDualMonSetting.Enabled = false;
            }
        }

        private void btnDualMonSetting_Click(object sender, EventArgs e)
        {
            FrmSystemDualMonitorSetting frmSystemDualMonitorSetting = new FrmSystemDualMonitorSetting();

            if (frmSystemDualMonitorSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPOSSetting_Click(object sender, EventArgs e)
        {
            FrmSystemPOSSetting frmSystemPosSetting = new FrmSystemPOSSetting();

            if (frmSystemPosSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkUPSEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUPSEnable.Checked)
            {
                btnUPSSetting.Enabled = true;
            }
            else
            {
                btnUPSSetting.Enabled = false;
            }
        }

        private void btnUPSSetting_Click(object sender, EventArgs e)
        {
            FrmSystemUPSSetting frmSystemUPSSetting = new FrmSystemUPSSetting();

            if (frmSystemUPSSetting.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSystenConfigSetting_Click(object sender, EventArgs e)
        {
            FrmSystemConfiguration frmSystemConfig = new FrmSystemConfiguration();

            if (frmSystemConfig.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSystemControllerSetting_Click(object sender, EventArgs e)
        {
            FrmSystemController frmSystemController = new FrmSystemController();

            if (frmSystemController.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnPrevStream_Click(object sender, EventArgs e)
        {
            FrmSystemPreviewStreamSetting frmPreviewStreamSetting = new FrmSystemPreviewStreamSetting();

            if(frmPreviewStreamSetting.ShowDialog(this)==DialogResult.OK)
            {

            }
        }

		private void btnDelete_Click(object sender, EventArgs e)
		{
            storage_paths.Clear();

			for (int i = listViewStoragePath.Items.Count - 1; i >= 0; i--)
			{
				if (listViewStoragePath.Items[i].Selected)
				{
                    listViewStoragePath.Items[i].Remove();
                    continue;
				}

                storage_paths.Add(listViewStoragePath.Items[i].SubItems[0].Text);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
            UpdateData(true);
			SystemSettingDef.SaveToFile(SystemSettingDef.GetDefaultSystemConfigPath(), iNVMSConfig.SystemConfig);
		}


        /*show on-screen keyboard*/
        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;

            Process.Start(path);
        }

        private void btnDefault_Click(object sender, EventArgs e)
		{
            iNVMSConfig.SystemConfig.m_loginSetting.AutoLogin = true;
            iNVMSConfig.SystemConfig.m_loginSetting.AskPasswordForLogin = true;
            iNVMSConfig.SystemConfig.m_loginSetting.AutoRecord = false;
            iNVMSConfig.SystemConfig.m_loginSetting.AutoStartNetwork = false;
            iNVMSConfig.SystemConfig.m_loginSetting.LoginCompactMode = false;
            iNVMSConfig.SystemConfig.m_loginSetting.SilentLaunch = true;
            iNVMSConfig.SystemConfig.m_loginSetting.GuestMode = false;
            iNVMSConfig.SystemConfig.m_dualMonitorSetitng.Enable = true;
            iNVMSConfig.SystemConfig.UseGPU = true;
            iNVMSConfig.SystemConfig.DeleteRecord = false;
            iNVMSConfig.SystemConfig.MovetoRecord = true;
            iNVMSConfig.SystemConfig.DeleteTimeInterval = 7;
            iNVMSConfig.SystemConfig.DeleteEventInterval = 7;
            iNVMSConfig.SystemConfig.MovetoPath = "";
            iNVMSConfig.SystemConfig.UPSEnable = true;
            iNVMSConfig.SystemConfig.AttentionEnable = true;
            iNVMSConfig.SystemConfig.TimesPerDay = 24;
            iNVMSConfig.SystemConfig.DeleteEvent = false;

            UpdateData(false);
            SystemSettingDef.SaveToFile(SystemSettingDef.GetDefaultSystemConfigPath(), iNVMSConfig.SystemConfig);
        }

        private void FrmSystemSettings_Load(object sender, EventArgs e)
        {
            // show the save directories list

            /*string strPath = @"c:\Data"; // default path is 'C:/data'
            Directory.CreateDirectory(strPath);
            if (!iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Contains(strPath))
            {
                iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Add(strPath);
            }
            
            RefreshStroageListView();*/

            // show system languages
            CultureInfo ci = CultureInfo.InstalledUICulture;

            comboBox1.Items.Add(ci.DisplayName);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add(ci.DisplayName);
            comboBox2.SelectedIndex = 0;

            if (chkAttentionEnable.Checked)
            {
                txtTimesPerDay.Enabled = true;
            }
            else
            {
                txtTimesPerDay.Enabled = false;
            }

            string file_name = @"Config\Attention";
            try
            {
                if (!File.Exists(file_name))
                {
                    File.Create(file_name);
                }
            } catch (Exception)
            {

            }

            if (checkBox1.Checked)
            {
                txtDeleteEvent.Enabled = true;
            }
            else
            {
                txtDeleteEvent.Enabled = false;
            }
        }

        private void btnGPUSetting_Click(object sender, EventArgs e)
        {

        }

        private void chkUseGPU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGPU.Checked)
                btnGPUSetting.Enabled = true;
            else
                btnGPUSetting.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void chkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            string abs_path = Path.GetFullPath("iNVMS.exe");
            //MessageBox.Show(abs_path);

            if (chkAutoLogin.Checked == true)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("iNVMS", abs_path);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.DeleteValue("iNVMS", false);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(iNVMSMain.click_record_button);

            MessageBox.Show("Recording size calculation is available when recording starts.", "iNVMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //if (iNVMSMain.click_record_button == false)
            //    return;

            FrmRecordingCalculator frm_recording_calculator = new FrmRecordingCalculator();
            if (frm_recording_calculator.ShowDialog(this) == DialogResult.OK)
            {

            }
            frm_recording_calculator.Dispose();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            FrmSystemAttentionAnalysis frmSystemAttentionAnalysis = new FrmSystemAttentionAnalysis();
            if (frmSystemAttentionAnalysis.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkAttentionEnable_Click(object sender, EventArgs e)
        {
            if (chkAttentionEnable.Checked)
            {
                txtTimesPerDay.Enabled = true;
                iNVMSMain.att_on = true;
            }
            else
            {
                txtTimesPerDay.Enabled = false;
                iNVMSMain.att_on = false;
            }
        }

        private void txtTimesPerDay_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTimesPerDay.Text) > 24)
            {
                MessageBox.Show("Please enter an integer between 1 and 24", "Limit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimesPerDay.Text = "24";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtDeleteEvent.Enabled = true;
            }
            else
            {
                txtDeleteEvent.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strPath = QueryFolderPath();
            if (String.IsNullOrEmpty(strPath))
                return;

            System.IO.DriveInfo drive_cur = new System.IO.DriveInfo(Directory.GetCurrentDirectory());
            System.IO.DriveInfo drive_record = new System.IO.DriveInfo(strPath);
            string drive_cur_letter = drive_cur.Name;
            string drive_record_letter = drive_record.Name;
            if (drive_cur_letter == drive_record_letter)
            {
                MessageBox.Show("Please select another partition rather than which iNVMS is running on.", "Select Partition", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!LocalServiceProvider.CheckClusterSize64K(strPath))
            {
                if (MessageBox.Show("To save disk space, iNVMS recommends you to select a partition which has 64KB of allocation unit size." +
                    Environment.NewLine + "Are you sure you want to record on selected partition?", "Select Partition", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            storage_paths.Add(strPath);
            float fTotalGigaByte = .0f;
            float fFreeGigaByte = .0f;

            bool bRet = LocalServiceProvider.GetDriveSpaceInfo(strPath, ref fTotalGigaByte, ref fFreeGigaByte);
            string[] strRow = { fFreeGigaByte.ToString("0.00") + "GB", fTotalGigaByte.ToString("0.00") + "GB" };
            listViewStoragePath.Items.Add(strPath).SubItems.AddRange(strRow);

            //iNVMSConfig.SystemConfig.m_storageSetting.VideoPath.Add(strPath);
            //RefreshStroageListView();
        }
    }
}

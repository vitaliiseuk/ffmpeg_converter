using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using iNVMS.SDK;
using iNVMS.CustomControl;
namespace iNVMSMain
{
    public partial class FrmAllSettings : Form
    {
		private Bitmap m_bmpBackground;
		private Bitmap m_bmpButtonNormal;
		public iNVMSMain MainForm { get; set; }
		PngButton m_btnSystem;
		PngButton m_btnCameras;
		PngButton m_btnRecord;
		PngButton m_btnNetwork;
		PngButton m_btnPTZ;
		PngButton m_btnSchedule;
		PngButton m_btnAlert;
		PngButton m_btnIVS;
		PngButton m_btnIntegration;
		PngButton m_btnBackup;
		PngButton m_btnUser;
		PngButton m_btnVE;
		PngButton m_btnOK;
		PngButton m_btnCancel;
		PngButton m_btnClose;

        public FrmAllSettings()
        {
            InitializeComponent();
			m_bmpBackground = new Bitmap(Properties.Resources.pngSettingsBk);
			m_bmpButtonNormal = new Bitmap(Properties.Resources.pngSettingsButtonNormal);
			this.Width = m_bmpBackground.Width;
			this.Height = m_bmpBackground.Height;

			m_btnSystem = new PngButton();
			m_btnCameras = new PngButton();
			m_btnRecord = new PngButton();
			m_btnNetwork = new PngButton();
			m_btnPTZ = new PngButton();
			m_btnSchedule = new PngButton();
			m_btnAlert = new PngButton();
			m_btnIVS = new PngButton();
			m_btnIntegration = new PngButton();
			m_btnBackup = new PngButton();
			m_btnUser = new PngButton();
			m_btnVE = new PngButton();
			m_btnOK = new PngButton();
			m_btnCancel = new PngButton();
			m_btnClose = new PngButton();

			m_btnOK.DialogResult = DialogResult.OK;
			m_btnCancel.DialogResult = DialogResult.Cancel;
			m_btnClose.DialogResult = DialogResult.Cancel;
			LayoutControls();

			this.BackColor = Color.Green;
			this.TransparencyKey = Color.Green;
        }

		public string GetResourceTextFile(string filename)
		{
			string result = string.Empty;

			using (Stream stream = this.GetType().Assembly.
					   GetManifestResourceStream("iNVMSMain.resource.xml." + "skin.xml"))
			{
				using (StreamReader sr = new StreamReader(stream))
				{
					result = sr.ReadToEnd();
				}
			}
			return result;
		}
	
		private void LayoutControls()
		{
			string strLayoutXML = GetResourceTextFile("skinXML");
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(strLayoutXML);

			Rectangle rcControl = new Rectangle();
			rcControl.X = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonStartX"));
			rcControl.Y = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonStartY"));
			rcControl.Width = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonWidth"));
			rcControl.Height = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonHeight"));

			int nHorzOffset = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonMarginHorz"));
			int nVertOffset = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonMarginVert"));
			int nButtonCount = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonCount"));
			int nButtonInLine = Int32.Parse(iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "SettingsButtonInLine"));

			PngButton[] buttonGroup = { m_btnSystem, m_btnCameras, m_btnRecord, m_btnNetwork, m_btnSchedule, 
									  m_btnAlert, m_btnIVS, m_btnIntegration, m_btnBackup, m_btnUser};
			String[] buttonNames = new String[]{"System", "Camera", "Record", "Network", "Schedule", 
										"Alert", "IVS", "Integration", "Backup", "User"};

			int i;
			Rectangle rcControlBack = rcControl;
			for (i = 0; i < nButtonCount / 2; i++)
			{
				AddButton(ref buttonGroup[i], rcControl, rcControl, ButtonClick_EventHandler, buttonNames[i]);
				rcControl.Offset(nHorzOffset + rcControl.Width, 0);
			}

			rcControl = rcControlBack;
			rcControl.Y += nVertOffset + rcControl.Height;

			for (i = 0; i < nButtonCount / 2; i++)
			{
				AddButton(ref buttonGroup[i + nButtonInLine], rcControl, rcControl, ButtonClick_EventHandler, buttonNames[i + nButtonInLine]);
				rcControl.Offset(nHorzOffset + rcControl.Width, 0);
			}

			string strXMlValue = iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "OKButton");
			rcControl = iNVMSMain.ParseLayoutPosition(strXMlValue);
			AddButton(ref m_btnOK, rcControl, rcControl, ButtonClick_EventHandler, "OK");

			strXMlValue = iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "CancelButton");
			rcControl = iNVMSMain.ParseLayoutPosition(strXMlValue);
			AddButton(ref m_btnCancel, rcControl, rcControl, ButtonClick_EventHandler, "Cancel");

			strXMlValue = iNVMSMain.GetConfigValue(xmlDoc, "SettingsDialog", "CloseButton");
			rcControl = iNVMSMain.ParseLayoutPosition(strXMlValue);
			AddButton(ref m_btnClose, rcControl, rcControl, ButtonClick_EventHandler, "Close");
		}

		public void ButtonClick_EventHandler(Object sender, EventArgs e)
		{
			PngButton button = (PngButton)sender;
			switch (button.AccessibleName)
			{
				case "System":
                    FrmSystemSettings frmSystemSettings = new FrmSystemSettings();
                    if (frmSystemSettings.ShowDialog(this) == DialogResult.OK)
                    {
						MainForm.LayoutForMultiMonitor();
                    }
					break;
				case "Camera":
					FrmCameraSetting frmCamSetting = new FrmCameraSetting();
					try
					{
						if (frmCamSetting.ShowDialog(this) == DialogResult.OK)
						{
							MainForm.RefreshCameraConnection(true);
							if (MainForm.IsTreeViewMode)
								MainForm.PopulateCameraTree();
						}
					}
					catch (Exception ex)
					{
						iNVMSConfig.DumpException(ex);
					}
					
					break;
				case "Record":
					FrmRecording frmRecording = new FrmRecording();

					try
					{
						if (frmRecording.ShowDialog(this) == DialogResult.OK)
						{

						}
					}
					catch(Exception ex)
					{
						iNVMSConfig.DumpException(ex);
					}
					break;
				case "Network":
					FrmNetwork frmNetwork = new FrmNetwork();

					if (frmNetwork.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "PTZ":
					FrmAlarmPTZPreset frmPTZSetting = new FrmAlarmPTZPreset();

					if (frmPTZSetting.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "Schedule":
					FrmSchedule frmSchedule = new FrmSchedule();

					if (frmSchedule.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "Alert":
					FrmAlarm frmAlarmSettings = new FrmAlarm();

					if (frmAlarmSettings.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "IVS":
					break;
				case "Integration":
					FrmSystemPOSSetting frmSystemPosSetting = new FrmSystemPOSSetting();

					if (frmSystemPosSetting.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "Backup":
					FrmBackup frmBackup = new FrmBackup();

					if (frmBackup.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "User":
					FrmUserSetting frmUser = new FrmUserSetting();

					if (frmUser.ShowDialog(this) == DialogResult.OK)
					{

					}
					break;
				case "VE":
					break;
				case "OK":
                    iNVMSConfig.SaveAllSettings();
					break;
				case "Cancel":
					break;
				case "Close":
					break;
				default:
					break;
			}

			Owner.Activate();
		}
		private void AddButton(ref PngButton button, Rectangle rcButton, Rectangle rcImgNormal, EventHandler clickHandler, string strAlias = "", bool bShowAlias = false)
		{
			button.Bounds = rcButton;
			button.SetBkNormalImage(m_bmpButtonNormal, rcImgNormal);
			button.AccessibleName = strAlias;
			button.DrawAliasText = bShowAlias;
			button.Click += clickHandler;
			Controls.Add(button);
		}
        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSystemSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCameraSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUserSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAlarmSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRelaySetting_Click(object sender, EventArgs e)
        {
            FrmRelay frmRelay = new FrmRelay();

            if (frmRelay.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnSensorSetting_Click(object sender, EventArgs e)
        {
            FrmSensor frmSensor = new FrmSensor();

            if (frmSensor.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnBackupSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnScheduleSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNetworkSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRecordingSetting_Click(object sender, EventArgs e)
        {
            
        }

		private void Form_OnPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(m_bmpBackground, new Point(0, 0));
		}

		private void OnForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.Y < 30)
				{
					iNVMSMain.ReleaseCapture();
					iNVMSMain.SendMessage(Handle, iNVMSMain.WM_NCLBUTTONDOWN, iNVMSMain.HT_CAPTION, 0);
				}
			}
		}

        private void FrmAllSettings_Load(object sender, EventArgs e)
        {

        }
    }
}

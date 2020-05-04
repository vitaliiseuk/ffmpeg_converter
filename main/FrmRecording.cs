using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;
using iNVMS.CustomControl;
using System.IO;
using System.Diagnostics;

namespace iNVMSMain
{
    public partial class FrmRecording : Form
    {
		private int m_nSelectedChannel = -1;
        public int SelectedScheduleValue { get; set; }
        public FrmRecording()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
			cameraPicker.LayoutCameraButtons(16);
			nvmsPlayer.PreviewMode = true;
            SelectedScheduleValue = 1;
			cameraPicker.SelectChannelActionDelegate = SelectChannelAction;
			cameraPicker.ApplyOption = ApplyOptionChanges;
			scheduleCtrl.SelectedValue = 1;

			nvmsPlayer.PlayerType = PlayerTypeEnum.PreviewPlayer;
			if (iNVMSConfig.ConnectedCameraCount > 0)
				cameraPicker.SelectCamera(0);
			else
				btnSchedule.Enabled = false;

			nvmsPlayer.ShowHide(true);
			nvmsPlayer.MouseDown += new MouseEventHandler(Player_MouseDown);
        }
		private void Player_MouseDown(object sender, MouseEventArgs e)
		{

		}
		private void ClosePreviewChannel()
		{
			foreach (CameraObject cam in iNVMSConfig.CameraDevices.DeviceList)
				cam.ClientInfo.PreviewMode = false;

			H264NetSDK.DVR_ClosePlayStream(iNVMSConfig.MaxCameraCount * 2 + 1);
		}

        private void trackSensitivity_Scroll(object sender, EventArgs e)
        {
            txtMotionSensitivity.Text = trackMotionSensitivity.Value.ToString();
        }

        private void trackIntensity_Scroll(object sender, EventArgs e)
        {
            txtVoiceIntensity.Text = trackVoiceIntensity.Value.ToString();
        }

        private void trackQuality_Scroll(object sender, EventArgs e)
        {
            txtVideoQuality.Text = trackVideoQuality.Value.ToString();
        }

        private void trackFrameMax_Scroll(object sender, EventArgs e)
        {
            txtFrameRateMax.Text = trackFrameRateMax.Value.ToString();
        }

        private void chkMaskEnable_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkShieldEnable_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkStorageOpr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStorageOpr.Checked)
            {
                btnStorageOprDetail.Enabled = true;
            }
            else
            {
                btnStorageOprDetail.Enabled = false;
            }
        }

        private void trackFrameMin_Scroll(object sender, EventArgs e)
        {
            txtFrameRateMin.Text = trackFrameRateMin.Value.ToString();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            FrmRecordingSchedule frmRecordingSchedule = new FrmRecordingSchedule();

			frmRecordingSchedule.SetSchedule(scheduleCtrl.GetSchedule());
            frmRecordingSchedule.CameraIndex = m_nSelectedChannel;
	
			if (frmRecordingSchedule.ShowDialog(this) == DialogResult.OK)
			{
				CameraObject camera = iNVMSConfig.DeviceAt(m_nSelectedChannel);
				scheduleCtrl.SetWeekSchedule(camera.RecordOption.RecordSchedule);
			}
            
        }

        private void btnSensitivityAdvance_Click(object sender, EventArgs e)
        {
            FrmRecordingMotionAdvanced frmRecordingMotionAdvance = new FrmRecordingMotionAdvanced();

            if (frmRecordingMotionAdvance.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void chkVideoEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVideoEncrypt.Checked)
            {
                FrmRecordingVideoEncryption frmRecordingVideoEncryption = new FrmRecordingVideoEncryption();

                if (frmRecordingVideoEncryption.ShowDialog(this) == DialogResult.OK)
                {

                }
            }

        }

		private void groupBox8_Enter(object sender, EventArgs e)
		{

		}

		private void RefreshRecordOptionValues(int nCam)
		{
			CameraObject camera = iNVMSConfig.DeviceAt(nCam);
			if (camera == null)
				return;

			if (camera.RecordOption.RecordStreamNum == -1)
			{
				radioMainStream.Checked = true;
				radioSubStream.Checked = false;
			}
			else
			{
				radioMainStream.Checked = false;
				radioSubStream.Checked = true;
			}

			radioAlwaysRecord.Checked = camera.RecordOption.RecordMode == RecordModes.AlwaysRecording;
			radioMotionRecord.Checked = camera.RecordOption.RecordMode == RecordModes.MotionRecording;
            radioSmartRecord.Checked = camera.RecordOption.RecordMode == RecordModes.SmartRecording;
            radioVoiceDetectRecord.Checked = camera.RecordOption.RecordMode == RecordModes.VoiceRecording;
            radioKeyFrameRecord.Checked = camera.RecordOption.RecordMode == RecordModes.KeyFrameRecording;
			radioNoRecord.Checked = camera.RecordOption.RecordMode == RecordModes.NoRecording;

			txtPreRecordTime.Text = camera.RecordOption.PreRecordTime.ToString();
			txtPostRecordTime.Text = camera.RecordOption.PostRecordTime.ToString();

			txtMotionSensitivity.Text = camera.RecordOption.MotionSensitivity1.ToString();
			txtVoiceIntensity.Text = camera.RecordOption.VoiceIntensity.ToString();

			trackMotionSensitivity.Value = camera.RecordOption.MotionSensitivity1;
			trackVoiceIntensity.Value = camera.RecordOption.VoiceIntensity;

			txtVideoQuality.Text = camera.RecordOption.VideoQuality.ToString();
			trackVideoQuality.Value = camera.RecordOption.VideoQuality;

			txtFrameRateMax.Text = camera.RecordOption.FrameRateMax.ToString();
			txtFrameRateMin.Text = camera.RecordOption.FrameRateMin.ToString();

			trackFrameRateMax.Value = camera.RecordOption.FrameRateMax;
			trackFrameRateMin.Value = camera.RecordOption.FrameRateMin;

			radioCompressUseOriginal.Checked = camera.RecordOption.CompressType == VideoCompressTypes.Original;
			radioCompressH264.Checked = camera.RecordOption.CompressType == VideoCompressTypes.H264;
			radioCompressH265.Checked = camera.RecordOption.CompressType == VideoCompressTypes.H265;

			scheduleCtrl.SetWeekSchedule(camera.RecordOption.RecordSchedule);
		}

		private RecordOptions GetCurrentOption()
		{
			RecordOptions options = new RecordOptions();

			options.RecordStreamNum = radioMainStream.Checked == true ? -1 : -2;

			if (radioAlwaysRecord.Checked)
				options.RecordMode = RecordModes.AlwaysRecording;
			else if (radioMotionRecord.Checked)
				options.RecordMode = RecordModes.MotionRecording;
            else if (radioVoiceDetectRecord.Checked)
                options.RecordMode = RecordModes.VoiceRecording;
            else if (radioSmartRecord.Checked)
                options.RecordMode = RecordModes.SmartRecording;
            else if (radioKeyFrameRecord.Checked)
				options.RecordMode = RecordModes.KeyFrameRecording;
			else if (radioNoRecord.Checked)
				options.RecordMode = RecordModes.NoRecording;

			options.PreRecordTime = Int32.Parse(txtPreRecordTime.Text);
			options.PostRecordTime = Int32.Parse(txtPostRecordTime.Text);

			options.MotionSensitivity1 = Int32.Parse(txtMotionSensitivity.Text);
			options.VoiceIntensity = Int32.Parse(txtVoiceIntensity.Text);

			options.MotionSensitivity1 = trackMotionSensitivity.Value;
			options.VoiceIntensity = trackVoiceIntensity.Value;

			options.VideoQuality = Int32.Parse(txtVideoQuality.Text);
			options.VideoQuality = trackVideoQuality.Value;

			options.FrameRateMax = Int32.Parse(txtFrameRateMax.Text);
			options.FrameRateMin = Int32.Parse(txtFrameRateMin.Text);

			options.FrameRateMax = trackFrameRateMax.Value;
			options.FrameRateMin = trackFrameRateMin.Value;

			options.RecordSchedule = scheduleCtrl.GetSchedule();

			if (radioCompressUseOriginal.Checked)
				options.CompressType = VideoCompressTypes.Original;
			else if (radioCompressH264.Checked)
				options.CompressType = VideoCompressTypes.H264;
			else if (radioCompressH265.Checked)
				options.CompressType = VideoCompressTypes.H265;

			return options;
		}
		private void ApplyOptionChanges(int nCam)
		{
			if (nCam < 0)
				return;

			CameraObject camera = iNVMSConfig.DeviceAt(nCam);

			RecordOptions recordOption = GetCurrentOption();

			camera.RecordOption = recordOption;

		}

		public async void SelectChannelAction(int nChannel)
		{
			//if (m_nSelectedCamera == nChannel)
			//	return;

            m_nSelectedChannel = nChannel;

			await nvmsPlayer.StopRealPlay(true);
			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[nChannel];
			if (nBindedCamera < 0)
			{
				ClosePreviewChannel();
				return;
			}
			RefreshRecordOptionValues(nBindedCamera);
			CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);

			if (camera == null)
			{
				ClosePreviewChannel();
				return;
			}

			foreach (CameraObject cam in iNVMSConfig.CameraDevices.DeviceList)
				cam.ClientInfo.PreviewMode = false;

			if (camera.DeviceInfo.Name == "iLinkPro iHD Series" || camera.DeviceInfo.Name == "XM XVR")
			{
				if (!H264NetSDK.StreamOpenState[iNVMSConfig.MaxCameraCount * 2 + 1])
				{
					H264NetSDK.DVR_OpenPlayStream(iNVMSConfig.MaxCameraCount * 2 + 1);
					H264NetSDK.StreamOpenState[iNVMSConfig.MaxCameraCount * 2 + 1] = true;
					H264NetSDK.StreamPlayState[iNVMSConfig.MaxCameraCount * 2 + 1] = false;
				}
				H264NetSDK.H264_PLAY_Play(iNVMSConfig.MaxCameraCount * 2 + 1, nvmsPlayer.Handle);
				camera.ClientInfo.PreviewMode = true;
				H264NetSDK.H264_DVR_MakeKeyFrame(camera.SDK.LoginID[0], camera.DeviceInfo.Channel, 1);
				return;
			}
			else
			{
				ClosePreviewChannel();
			}

			CameraObject cameraTemp = new CameraObject();
			cameraTemp.DeviceInfo = camera.DeviceInfo;
			cameraTemp.CameraOption = camera.CameraOption;
			cameraTemp.ClientInfo.StreamNum = -2;

			if (camera.DeviceInfo.Name == "FHIPCamera")
				cameraTemp.SDK = new FHIPCamSDK(cameraTemp);
			else if (camera.DeviceInfo.Name == "AVer NV Series")
				cameraTemp.SDK = new AVerDSSNVSDK(camera);
			else if (camera.DeviceInfo.Name == "ONVIF")
				cameraTemp.SDK = new OnVIFCamSDK(cameraTemp);
			else if (camera.DeviceInfo.Name == "RTSP")
				cameraTemp.SDK = new RTSPSDK(camera);

            cameraTemp.DeviceInfo.DeviceUpdated = true;
			await nvmsPlayer.StartRealPlay(cameraTemp, iNVMSConfig.GeneralConfig.DefaultFPSForPreview);

		}

		private void radioMainStream_CheckedChanged(object sender, EventArgs e)
		{
			int nStreamNum = radioMainStream.Checked == true ? -1 : -2;

			if (chkCamAll.Checked)
			{
                foreach (CameraObject camera in iNVMSConfig.CameraDevices.DeviceList)
					camera.RecordOption.RecordStreamNum = nStreamNum;
			}
			else if (m_nSelectedChannel >= 0)
			{
				int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
				CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
				if (camera != null)
					camera.RecordOption.RecordStreamNum = nStreamNum;
			}
				
		}

		private void radioSubStream_CheckedChanged(object sender, EventArgs e)
		{
			int nStreamNum = radioMainStream.Checked == true ? -1 : -2;

			if (chkCamAll.Checked)
			{
                foreach (CameraObject camera in iNVMSConfig.CameraDevices.DeviceList)
					camera.RecordOption.RecordStreamNum = nStreamNum;
			}
			else if (m_nSelectedChannel >= 0)
			{
				int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
				CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
				if (camera != null)
					camera.RecordOption.RecordStreamNum = nStreamNum;
			}
		}

		private void chkCamAll_CheckedChanged(object sender, EventArgs e)
		{
			cameraPicker.SelectAll(chkCamAll.Checked);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			//if (chkCamAll.Checked)
			//	ApplyChanges();
			//else
			//	StoreChanges(m_nSelectedCamera);

			cameraPicker.ApplyOptionToSelectedCameras();
			nvmsPlayer.StopRealPlay();
			nvmsPlayer.Dispose();
			NVMSCameraList.SaveToFile(NVMSCameraList.GetDefaultDeviceConfigPath(), iNVMSConfig.CameraDevices);
			if (Owner != null)
				Owner.Activate();

			ClosePreviewChannel();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			nvmsPlayer.StopRealPlay();
			nvmsPlayer.Dispose();
			if (Owner != null)
				Owner.Activate();

			ClosePreviewChannel();
		}

        private void OnScheduleView_Load(object sender, EventArgs e)
        {
            const int nRows = 7;
            const int nCols = 24;
            const int nHeaderRows = 0;
            const int nHeaderCols = 0;

            const int nTotalRows = nRows + nHeaderRows;
            const int nTotalCols = nCols + nHeaderCols;

            const int nHeaderColRatio = 2;
            const int nHeaderRowRatio = 1;

            const int nWidthDiv = nCols + nHeaderCols * nHeaderColRatio;
            const int nHeightDiv = nRows + nHeaderRows * nHeaderRowRatio;

            scheduleCtrl.CellColors = new Color[] { Color.White, Color.Blue, Color.Lime, Color.Magenta, Color.Yellow, Color.Cyan };
            scheduleCtrl.LockUpdates = true;

            float rowHeight = (float)scheduleCtrl.Height / (float)nHeightDiv;
            float colWidth = (float)scheduleCtrl.Width / (float)nWidthDiv;

            for (int r = 0; r < nTotalRows; r++)
            {
                uint top = (uint)(rowHeight * r + 0.5f);
                uint height = (uint)(rowHeight * (r + 1) - top + 0.5f);
                scheduleCtrl.AddRow(height);
            }

            for (int c = 0; c < nTotalCols; c++)
            {
                uint left = (uint)(colWidth * c + 0.5f);
                uint width = (uint)(colWidth * (c + 1) - left + 0.5f);
                if (c < nHeaderCols)
                    scheduleCtrl.AddColumn(width * nHeaderColRatio);
                else
                    scheduleCtrl.AddColumn(width);
            }

			scheduleCtrl.SetFixedRowCount(nHeaderRows);
			scheduleCtrl.SetFixedColumnCount(nHeaderCols);

            if (scheduleCtrl.GetFixedRowCount() > 0)
            {
                string[] weekName = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                for (int r = scheduleCtrl.GetFixedRowCount(); r < scheduleCtrl.rowList.Count; r++)
                {
                    scheduleCtrl.GetCell(r, 0).Value = weekName[r - scheduleCtrl.GetFixedRowCount()];
                }
            }

            if (scheduleCtrl.GetFixedColumnCount() > 0)
            {
                for (int c = scheduleCtrl.GetFixedColumnCount(); c < scheduleCtrl.colList.Count; c++)
                {
                    scheduleCtrl.GetCell(0, c).Value = (c - scheduleCtrl.GetFixedColumnCount()).ToString("00");
                }
            }

            if (m_nSelectedChannel >= 0)
            {
                scheduleCtrl.SetWeekSchedule(iNVMSConfig.DeviceAt(m_nSelectedChannel).RecordOption.RecordSchedule);
            }
            Invalidate();
        }

        private void radioAlwaysRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 1;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }
        private void radioMotionRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 2;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }

        private void radioSmartRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 3;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }

        private void radioKeyFrameRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 5;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }

        private void radioVoiceDetectRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 4;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }

        private void radioNoRecord_CheckedChanged(object sender, EventArgs e)
        {
            SelectedScheduleValue = 0;
            scheduleCtrl.SelectedValue = SelectedScheduleValue;
        }

		private void OnMotionSensitivityText_Changed(object sender, EventArgs e)
		{
			trackMotionSensitivity.Value = Int32.Parse(txtMotionSensitivity.Text);
		}

		private void OnVoiceIntensityText_Changed(object sender, EventArgs e)
		{
			trackVoiceIntensity.Value = Int32.Parse(txtVoiceIntensity.Text);
		}

		private void OnVideoQualityText_Changed(object sender, EventArgs e)
		{
			trackVideoQuality.Value = Int32.Parse(txtVideoQuality.Text);
		}

		private void OnFrameRateMaxText_Changed(object sender, EventArgs e)
		{
			trackFrameRateMax.Value = Int32.Parse(txtFrameRateMax.Text);
		}

		private void OnFrameRateMinText_Changed(object sender, EventArgs e)
		{
			trackFrameRateMin.Value = Int32.Parse(txtFrameRateMin.Text);
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			txtPreRecordTime.Text = "3";
			txtPostRecordTime.Text = "3";
			chkAudioEnable.Checked = true;

			trackMotionSensitivity.Value = 50;
			trackVoiceIntensity.Value = 50;
			radioCompressUseOriginal.Checked = true;
			trackVideoQuality.Value = 50;
			trackFrameRateMax.Value = 30;
			trackFrameRateMin.Value = 1;
			radioMainStream.Checked = true;

			txtMotionSensitivity.Text = "50";
			txtVideoQuality.Text = "50";
			txtFrameRateMax.Text = "30";
			txtFrameRateMin.Text = "1";
		}

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
            Process.Start(path);
        }

		private void btnPrev_Click(object sender, EventArgs e)
		{
			cameraPicker.ShiftChannels(true);
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			cameraPicker.ShiftChannels(false);
		}

		private void FrmRecording_Shown(object sender, EventArgs e)
		{
			nvmsPlayer.ShowHide(true);
		}

		private void FrmRecording_Move(object sender, EventArgs e)
		{
			nvmsPlayer.ShowHide(true);
		}

        private void FrmRecording_Load(object sender, EventArgs e)
        {

        }
    }
}

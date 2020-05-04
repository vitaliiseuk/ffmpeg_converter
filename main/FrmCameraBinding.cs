using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iNVMS.CustomControl;
using iNVMS.SDK;

namespace iNVMSMain
{
	public partial class FrmCameraBinding : Form
	{
		private PngButton[] m_btnCamera;
		private Point m_ptPickStart = new Point();
		private int m_nBaseCamIndex = 0;
		private int m_nCameraToShow = 0;
		private bool m_bBindInfoChanged = false;
		private int[] m_bindInfoBackup = new int[iNVMSConfig.MaxCameraCount];
		private Rectangle m_rcStartBound = new Rectangle();

		public bool BindInfoChanged
		{
			get
			{
				return m_bBindInfoChanged;
			}
		}
		public FrmCameraBinding()
		{
			InitializeComponent();
			btnOK.DialogResult = DialogResult.OK;
			btnCancel.DialogResult = DialogResult.Cancel;
			nvmsPlayerController.BindMode = true;
			nvmsPlayerController.PlayerSelectActionDelegate = PlayerSelectAction;
			nvmsPlayerController.ContextMenuProc = ProcPlayerContextMenu;
			m_btnCamera = new PngButton[iNVMSConfig.MaxCameraCount];
			int i;
			for (i = 0; i < iNVMSConfig.MaxCameraCount; i++)
			{
				m_btnCamera[i] = new PngButton();
				m_bindInfoBackup[i] = iNVMSConfig.CameraConfig.CameraBindInfo[i];
			}
			nvmsPlayerController.BindCameraToPlayer();
		}

		private void MoveToIndex(int nIndex)
		{
			m_nBaseCamIndex = nIndex;
			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
			{
				if (i >= m_nBaseCamIndex && i < m_nBaseCamIndex + m_nCameraToShow && iNVMSConfig.CameraConfig.CameraBindInfo[i] < 0)
					m_btnCamera[i].Show();
				else
					m_btnCamera[i].Hide();
			}
		}
		public void CameraSelectAction(int nCam)
		{
			nvmsPlayerController.ActivatePlayer(nCam);
		}

		public void PlayerSelectAction(int nPlayer)
		{
			int nCamera = nvmsPlayerController.Players[nPlayer].BindedCameraIndex;

			if (nCamera < 0)
				return;

			RefreshCameraInfo(nCamera);
		}

		private void ProcPlayerContextMenu(string strCommand, int nPlayer)
		{
			if (strCommand.Equals("Unbind"))
			{
				BindCamera(nvmsPlayerController.Players[nPlayer].BindedCameraIndex, nPlayer, false);
			}
			else if (strCommand.Equals("Edit"))
			{

			}
			else if (strCommand.Equals("Reconnect"))
			{

			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			m_bBindInfoChanged = false;
			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
			{
				if (m_bindInfoBackup[i] != iNVMSConfig.CameraConfig.CameraBindInfo[i])
				{
					m_bBindInfoChanged = true;
					break;
				}
			}
			if (m_bBindInfoChanged)
			{
				iNVMSConfig.SaveAllSettings();

			}
		}

		public void AddCameraButtons()
		{
			Bitmap bmpCamera = new Bitmap(Properties.Resources.ipcamera1);
			int nButtonWidth = bmpCamera.Width;
			int nButtonHeight = bmpCamera.Height;
			int nMargin = 10;
			int nCamButtonCount = (btnNext.Left - btnPrev.Right - nMargin) / (nButtonWidth + nMargin);
			int nButtonMargin = (btnNext.Left - btnPrev.Right - nMargin) / nCamButtonCount - nButtonWidth;

			m_nCameraToShow = nCamButtonCount;

			Rectangle rcCamButton = new Rectangle();
			rcCamButton.X = btnPrev.Right + nMargin / 2;
			rcCamButton.Y = nMargin;
			rcCamButton.Width = nButtonWidth;
			rcCamButton.Height = nButtonHeight;

			Rectangle rcCamButton_back = rcCamButton;

			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
			{
				if (i % nCamButtonCount == 0)
					rcCamButton = rcCamButton_back;

				m_btnCamera[i].SetBkNormalImage(bmpCamera);
				m_btnCamera[i].Bounds = rcCamButton;
				m_btnCamera[i].AccessibleName = (i + 1).ToString();
				m_btnCamera[i].DrawAliasText = true;
				m_btnCamera[i].MouseDown += CamButton_MouseDown;
				m_btnCamera[i].MouseMove += CamButton_MouseMove;
				m_btnCamera[i].MouseUp += CamButton_MouseUp;
				Controls.Add(m_btnCamera[i]);
				rcCamButton.Offset(nButtonMargin + nButtonWidth, 0);
			}
		}

		private void CamButton_MouseDown(object sender, MouseEventArgs e)
		{
			PngButton button = (PngButton)sender;
			int nIndex = int.Parse(button.AccessibleName) - 1;
			if (nIndex < 0)
				return;
			m_btnCamera[nIndex].BringToFront();
			m_rcStartBound = button.Bounds;
			m_ptPickStart = button.PointToScreen(e.Location);
		}

		private void BindCamera(int nCamera, int nPlayer, bool bBind = true)
		{
			if (bBind)
			{
				if (nvmsPlayerController.Players[nPlayer].BindedCameraIndex >= 0)
					BindCamera(nvmsPlayerController.Players[nPlayer].BindedCameraIndex, nPlayer, false);
				iNVMSConfig.CameraConfig.CameraBindInfo[nCamera] = nPlayer;
				nvmsPlayerController.BindCamera(nCamera, nPlayer);
				m_btnCamera[nCamera].Hide();
			}
			else
			{
				iNVMSConfig.CameraConfig.CameraBindInfo[nCamera] = -1;
				nvmsPlayerController.BindCamera(nCamera, nPlayer, false);
				m_btnCamera[nCamera].Show();
			}
		}
		private void CamButton_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				PngButton button = (PngButton)sender;
				int nIndex = int.Parse(button.AccessibleName) - 1;

				Point ptCurrent = button.PointToScreen(e.Location);
				Rectangle newBound = m_rcStartBound;
				newBound.Offset(ptCurrent.X - m_ptPickStart.X, ptCurrent.Y - m_ptPickStart.Y);
				m_btnCamera[nIndex].Location = newBound.Location;

				nvmsPlayerController.GetPlayerFromPoint(ptCurrent, true);
			}
			
		}

		private void CamButton_MouseUp(object sender, MouseEventArgs e)
		{
			PngButton button = (PngButton)sender;
			int nIndex = int.Parse(button.AccessibleName) - 1;
			Point ptDropped = button.PointToScreen(e.Location);
			m_btnCamera[nIndex].Bounds = m_rcStartBound;

			int nBindedPlayer= nvmsPlayerController.GetPlayerFromPoint(ptDropped, true);
			if (nBindedPlayer >= 0)
			{
				BindCamera(nIndex, nBindedPlayer);
			}
			RefreshCameraInfo(nIndex);
		}
		private void Form_Shown(object sender, EventArgs e)
		{
			nvmsPlayerController.SwitchLayout(PlayerLayout.Layout_8x8, true);
			AddCameraButtons();
			MoveToIndex(0);
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			if (m_nBaseCamIndex <= 0)
				return;

			MoveToIndex(m_nBaseCamIndex - m_nCameraToShow);
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (m_nCameraToShow + m_nBaseCamIndex >= iNVMSConfig.ConnectedCameraCount)
				return;
			MoveToIndex(m_nBaseCamIndex + m_nCameraToShow);
		}

		private void btnAutoBind_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
			{
				BindCamera(i, i);
			}
		}

		private void btnUnbindAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
			{
				int nBindedPlayer = iNVMSConfig.CameraConfig.CameraBindInfo[i];
				if (nBindedPlayer >= 0)
					BindCamera(i, nBindedPlayer, false);
			}
		}

		private void RefreshCameraInfo(int nCam)
		{
			CameraObject camera = iNVMSConfig.DeviceAt(nCam);
			if (nCam < 0 || camera.SDK == null)
			{
				txtName.Text = "";
				txtAddress.Text = "";
				txtPort.Text = "";
			}
			else
			{
				NVMSDeviceInfo devInfo = camera.DeviceInfo;

				txtName.Text = devInfo.Name;
				txtAddress.Text = devInfo.IPAddress;
				txtPort.Text = devInfo.Port.ToString();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < iNVMSConfig.ConnectedCameraCount; i++)
				iNVMSConfig.CameraConfig.CameraBindInfo[i] = m_bindInfoBackup[i];
		}
	}
}

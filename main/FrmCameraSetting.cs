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
using OnvifMng;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace iNVMSMain
{
    public partial class FrmCameraSetting : Form
    {
		private bool m_bCameraModifid;
		private int m_nSelectedChannel = -1;
		private CameraObject cameraToConnectTry;
		private bool m_bOptionValueChanged;
		private NVMSPlayer nvmsPlayer;

        private int cur_cam_index = 0;
        public bool CameraModified
		{
			get { return m_bCameraModifid; }
		}

        int m_nCamSelRange = 0;

		public FrmCameraSetting()
		{
			InitializeComponent();
			if (!iNVMSConfig.CameraDevices.IsEmpty())
			{
				PopulateCameraTree();
				PopulateGroupTree();
			}
			cameraPicker.LayoutCameraButtons(16);
			cameraPicker.SelectChannelActionDelegate = SelectChannelAction;
			cameraPicker.ApplyOption += ApplyOptionChanges;

			nvmsPlayer = new NVMSPlayer(this);
			//nvmsPlayer.Location = new System.Drawing.Point(280, 108);
			//nvmsPlayer.Size = new System.Drawing.Size(302, 233);
			nvmsPlayer.PreviewMode = true;
			nvmsPlayer.PlayerType = PlayerTypeEnum.PreviewPlayer;
			nvmsPlayer.SetBound(new Rectangle(280, 108, 302, 233));
			nvmsPlayer.ShowHide(true);

			Controls.Add(nvmsPlayer);
			cameraPicker.SelectCamera(0);
			
			treeCamList.MouseDown += (sender, args) => treeCamList.SelectedNode = treeCamList.GetNodeAt(args.X, args.Y);
			treeViewGroup.MouseDown += (sender, args) => treeViewGroup.SelectedNode = treeViewGroup.GetNodeAt(args.X, args.Y);
			treeViewGroup.MouseUp += new MouseEventHandler(treeViewGroup_MouseUp);

			nvmsPlayer.DragDrop += new DragEventHandler(Player_DragDrop);
			nvmsPlayer.DragEnter += new DragEventHandler(Player_DragEnter);
			nvmsPlayer.HandleDestroyed += new EventHandler(Player_HandleDestroyed);
		}
        private void frmCameraSetting_InitVideoAdjustSetting()
        {
            trackBright.Value = 50;
            txtBright.Text = trackBright.Value.ToString();

            trackContrast.Value = 50;
            txtContrast.Text = trackContrast.Value.ToString();

            trackHue.Value = 50;
            txtHue.Text = trackHue.Value.ToString();

            trackSaturation.Value = 50;
            txtSaturation.Text = trackSaturation.Value.ToString();
        }

        private void frmCameraSetting_RefreshCamSelRangeNumbers()
        {
            if (m_nCamSelRange == 0)
            {

            }
            else if (m_nCamSelRange == 1)
            {
               
            }
            else if (m_nCamSelRange == 2)
            {
                
            }
            else if (m_nCamSelRange == 3)
            {
               
            }
        }

		public TreeNode GetTreeNodeFromCamera(CameraObject camera)
		{
			string strCameraNodeName = "";
			if (string.IsNullOrEmpty(camera.CameraOption.DisplayName))
				strCameraNodeName = "Camera" + (camera.ClientInfo.PlayerChannel + 1).ToString();
			else
				strCameraNodeName = camera.CameraOption.DisplayName;

			TreeNode node = new TreeNode(strCameraNodeName, 2, 2);

			TreeNode nodeName = new TreeNode(camera.DeviceInfo.Name, 10, 10);
			node.Nodes.Add(nodeName);

			TreeNode nodeIP = new TreeNode(camera.DeviceInfo.IPAddress, 10, 10);
			node.Nodes.Add(nodeIP);


			if (camera.DeviceInfo.AliasName == "DVR")
			{
				TreeNode nodeChannel = new TreeNode("Channel" + (camera.DeviceInfo.Channel + 1).ToString(), 10, 10);
				node.Nodes.Add(nodeChannel);
			}
			node.Tag = camera;

			return node;
		}
		private void treeViewGroup_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode selNode = treeViewGroup.SelectedNode;
				if (selNode == null)
					return;
				else if (selNode.Parent == null || selNode.Parent.Parent == null)
				{
					ContextMenu ctxMenu = new ContextMenu();
					MenuItem mnuItem = new MenuItem("Rename");
					mnuItem.Click += TreeViewContext_EventHandler;
					ctxMenu.MenuItems.Add(mnuItem);

					mnuItem = new MenuItem("Delete");
					mnuItem.Click += TreeViewContext_EventHandler;
					ctxMenu.MenuItems.Add(mnuItem);

					ctxMenu.Show(treeViewGroup, e.Location);
				}
			}
		}
		protected void TreeViewContext_EventHandler(object sender, EventArgs e)
		{
			MenuItem item = sender as MenuItem;
			if (item.Text == "Rename")
			{
				TreeNode selNode = treeViewGroup.SelectedNode;
				if (selNode.Parent == null)		//group
				{
					if (selNode.Text == "Default")
					{
						if (MessageBox.Show("You can not rename default group" + Environment.NewLine + "Do you want to add a new group?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							FrmInput frmInput = new FrmInput();
							if (frmInput.ShowDialog(this) == DialogResult.OK)
							{
								iNVMSConfig.CameraConfig.AddGroup(frmInput.NewName);
							}
						}
					}
					else
					{
						FrmInput frminput = new FrmInput();
						frminput.NewName = selNode.Text;

						if (frminput.ShowDialog(this) == DialogResult.OK)
						{
							iNVMSConfig.CameraConfig.RenameGroup(selNode.Text, frminput.NewName);
							selNode.Text = frminput.NewName;
						}
					}
				}
				else if (selNode.Parent.Parent != null)	//sub item
				{

				}
				else//camera
				{
					CameraObject camera = selNode.Tag as CameraObject;
					if (camera == null)
						return;

					FrmInput frminput = new FrmInput();
					frminput.NewName = selNode.Text;

					if (frminput.ShowDialog(this) == DialogResult.OK)
					{
						camera.CameraOption.DisplayName = frminput.NewName;
						if (m_nSelectedChannel == camera.ClientInfo.PlayerChannel)
						{
							int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
							RefreshCameraInfoPanel(nBindedCamera);
						}
					}
				}

			}
			else if (item.Text == "Delete")
			{
				TreeNode selNode = treeViewGroup.SelectedNode;
				if (selNode.Parent == null)		//group
				{
					int nGroupID = treeViewGroup.Nodes.IndexOf(selNode);
					iNVMSConfig.CameraDevices.DeleteGroup(nGroupID);
					PopulateGroupTree();
				}
				else if (selNode.Parent.Parent != null)	//sub item
				{

				}
				else//camera
				{
					CameraObject camera = selNode.Tag as CameraObject;

					if (camera == null)
					{
						return;
					}

					if (MessageBox.Show("Are you sure you want to delete selected camera?", "Camera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DeleteCamera(iNVMSConfig.CameraDevices.DeviceList.IndexOf(camera));
					}
				}
			}
		}

		public void PopulateCameraTree()
		{
			treeCamList.Nodes.Clear();
			int index = 1;
			//int nChannelCount = 0;
			foreach (CameraObject camera in iNVMSConfig.CameraDevices.DeviceList)
			{
				if (camera == null)
					continue;

				//if (strLastGUID != camera.DeviceInfo.ID)
				{
					//string strItemText = "Camera " + index.ToString("00");// +" : " + camera.DeviceInfo.IPAddress + "";
					//TreeNode node = new TreeNode(strItemText, 2, 2);

					//TreeNode nodeName = new TreeNode(camera.DeviceInfo.Name, 10, 10);
					//node.Nodes.Add(nodeName);

					//TreeNode nodeIP = new TreeNode(camera.DeviceInfo.IPAddress, 10, 10);
					//node.Nodes.Add(nodeIP);


					//if (camera.DeviceInfo.AliasName == "DVR")
					//{
					//	TreeNode nodeChannel = new TreeNode("Channel" + (camera.DeviceInfo.Channel + 1).ToString(), 10, 10);
					//	node.Nodes.Add(nodeChannel);
					//}
					//node.Tag = camera;

					TreeNode node = GetTreeNodeFromCamera(camera);
					treeCamList.Nodes.Add(node);
					index++;
					//nChannelCount = 0;
				}
			}
		}

		public void PopulateGroupTree()
		{
			treeViewGroup.Nodes.Clear();
			foreach(CameraGroupInfo group in iNVMSConfig.CameraConfig.CameraGroup)
			{
				TreeNode node = new TreeNode(group.Name, 0, 0);
				node.Tag = group;
				treeViewGroup.Nodes.Add(node);
			}

			foreach(CameraObject camera in iNVMSConfig.CameraDevices.DeviceList)
			{
				TreeNode groupNode = treeViewGroup.Nodes[camera.GroupID];

				TreeNode cameraNode = GetTreeNodeFromCamera(camera);
				groupNode.Nodes.Add(cameraNode);
			}
		}
        private void frmCameraSetting_Load(object sender, EventArgs e)
        {
            m_nCamSelRange = 0;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            frmCameraSetting_RefreshCamSelRangeNumbers();
            //frmCameraSetting_InitVideoAdjustSetting();

            chkAutoBrightControl.Enabled = true;
            chkNightView.Enabled = true;

  
        }
      
        private void btnCamSelectPrev_Click(object sender, EventArgs e)
        {
            m_nCamSelRange = (m_nCamSelRange == 0) ? 0 : m_nCamSelRange - 1;
            frmCameraSetting_RefreshCamSelRangeNumbers();
        }

        private void btnCamSelectNext_Click(object sender, EventArgs e)
        {
            m_nCamSelRange = (m_nCamSelRange == 3) ? 3 : m_nCamSelRange + 1;
            frmCameraSetting_RefreshCamSelRangeNumbers();
        }

        private void UpdateVideoColor()
        {
			try
			{
				int nSaturation = Int32.Parse(txtSaturation.Text);
				int nBrightness = Int32.Parse(txtBright.Text);
				int nConstrast = Int32.Parse(txtContrast.Text);
				int nHue = Int32.Parse(txtHue.Text);

				CameraObject camera = iNVMSConfig.DeviceAt(m_nSelectedChannel);

				if (camera != null)
				{
					camera.CameraOption.Saturation = nSaturation;
					camera.CameraOption.Brightness = nBrightness;
					camera.CameraOption.Hue = nHue;
					camera.CameraOption.Contrast = nConstrast;
					camera.SDK.SetLocalColor(nBrightness, nConstrast, nHue, nSaturation);
				}

				if (cameraToConnectTry != null)
				{
					cameraToConnectTry.CameraOption.Saturation = nSaturation;
					cameraToConnectTry.CameraOption.Brightness = nBrightness;
					cameraToConnectTry.CameraOption.Hue = nHue;
					cameraToConnectTry.CameraOption.Contrast = nConstrast;
					cameraToConnectTry.SDK.SetLocalColor(nBrightness, nConstrast, nHue, nSaturation);
				}
			}
            catch(Exception)
			{

			}
        }
        private void trackBright_Scroll(object sender, EventArgs e)
        {
            txtBright.Text = trackBright.Value.ToString();
            UpdateVideoColor();
        }

        private void trackContrast_Scroll(object sender, EventArgs e)
        {
            txtContrast.Text = trackContrast.Value.ToString();
            UpdateVideoColor();
        }

        private void trackHue_Scroll(object sender, EventArgs e)
        {
            txtHue.Text = trackHue.Value.ToString();
            UpdateVideoColor();
        }

        private void trackSaturation_Scroll(object sender, EventArgs e)
        {
            txtSaturation.Text = trackSaturation.Value.ToString();
            UpdateVideoColor();
        }

        private void txtBright_TextChanged(object sender, EventArgs e)
        {
			m_bOptionValueChanged = true;
            try
            {
                trackBright.Value = Int32.Parse(txtBright.Text);
            }
            catch(Exception)
            {
                trackBright.Value = 0;
            }
            
        }

        private void txtContrast_TextChanged(object sender, EventArgs e)
        {
			m_bOptionValueChanged = true;
            try
            {
                trackContrast.Value = Int32.Parse(txtContrast.Text);
            }
            catch (Exception)
            {
				trackContrast.Value = 0;
            }
        }

        private void txtHue_TextChanged(object sender, EventArgs e)
        {
			m_bOptionValueChanged = true;
			try
			{
				trackHue.Value = Int32.Parse(txtHue.Text);
			}
			catch(Exception)
			{
				trackHue.Value = 0;
			}
        }

        private void txtSaturation_TextChanged(object sender, EventArgs e)
        {
			m_bOptionValueChanged = true;
			try
			{
				trackSaturation.Value = Int32.Parse(txtSaturation.Text);
			}
			catch(Exception)
			{
				trackSaturation.Value = 0;
			}
        }

		private NVMSDeviceInfo ShowAddIpCamDialog(bool bIPCameraMode, NVMSDeviceInfo defaultInfo = null, bool bAddNew = false)
		{
			FrmAddIPCam frmAddIPCam = new FrmAddIPCam();
			frmAddIPCam.IPCameraMode = bIPCameraMode ? 1 : 0;
			frmAddIPCam.IsNewDevice = bAddNew;
			frmAddIPCam.DeviceInfo = defaultInfo;
            frmAddIPCam.selected_cam_index = m_nSelectedChannel + 1;

			if (frmAddIPCam.ShowDialog(this) == DialogResult.OK)
				return frmAddIPCam.DeviceInfo;

			return null;
		}

		private void btnRemoteDVRSetup_Click(object sender, EventArgs e)
		{
			AddXVRCamera();
		}

		private NVMSDeviceInfo ShowSetupDVRDialog(NVMSDeviceInfo defaultInfo = null, bool bAddNew = true)
		{
			FrmRemoteDVRSetting frmRemoteDVR = new FrmRemoteDVRSetting();
			frmRemoteDVR.DeviceInfo = defaultInfo;
			frmRemoteDVR.IsNewDevice = bAddNew;
			if (frmRemoteDVR.ShowDialog(this) == DialogResult.OK)
			{
				return frmRemoteDVR.DeviceInfo;
			}
			return null;
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			nvmsPlayer.StopRealPlay();
			ClosePreviewChannel();
			cameraPicker.ApplyOptionToSelectedCameras();

            //Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine(iNVMSConfig.CameraDevices.DeviceList.Count);
            //Console.WriteLine(iNVMSConfig.CameraDevices.DeviceList[0].CameraOption.Description);
            //Console.WriteLine("-----------------------------------------------");

            NVMSCameraList.SaveToFile(NVMSCameraList.GetDefaultDeviceConfigPath(), iNVMSConfig.CameraDevices);
			nvmsPlayer.Dispose();
		}

		private async void mnuDeleteCamera_Click(object sender, EventArgs e)
		{
			if (treeCamList.SelectedNode != null)
			{
				CameraObject camera = null;
				if (treeCamList.SelectedNode.Parent != null)
					camera = treeCamList.SelectedNode.Parent.Tag as CameraObject;
				else
					camera = treeCamList.SelectedNode.Tag as CameraObject;

				if (camera == null)
				{
					return;
				}

                if (MessageBox.Show("Are you sure you want to delete selected camera?", "Camera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await iNVMSConfig.CameraDevices.DeleteCamera(camera);
                    treeCamList.SelectedNode.Remove();
                    //treeCamList.Nodes.Remove(treeCamList.SelectedNode);
                    PopulateCameraTree();
					PopulateGroupTree();
                    m_bCameraModifid = true;
                    iNVMSConfig.SaveAllSettings();

					//cameraPicker.LayoutCameraButtons(16);
					cameraPicker.RefreshCameraIcons();

				}
			}
		}

		private void mnuAddRemoteDVR_Click(object sender, EventArgs e)
		{
			if (AddXVRCamera())
			{
				int nChannelBack = m_nSelectedChannel;
				m_nSelectedChannel = -1;
				SelectChannelAction(nChannelBack);
			}
		}
		private bool AddXVRCamera()
		{
			NVMSDeviceInfo devInfo = ShowSetupDVRDialog(null, true);
			if (devInfo == null)
				return false;

			m_bCameraModifid = true;

			//----------add all cameras of DVR-----------
			//for (int i = 0; i < devInfo.TotalChannels; i++)
			{
				CameraObject camera = new CameraObject();
				camera.DeviceInfo = devInfo.Clone();
				camera.ClientInfo.PlayerChannel = m_nSelectedChannel;
				iNVMSConfig.CameraDevices.AddCamera(camera);
				iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel] = iNVMSConfig.ConnectedCameraCount - 1;
			}
			//---------------------------------------------
			//---------------------------------------------
			PopulateCameraTree();
			PopulateGroupTree();
			//cameraPicker.LayoutCameraButtons(16);

			cameraPicker.RefreshCameraIcons();
			cameraPicker.SelectCamera(m_nSelectedChannel);
			iNVMSConfig.SaveAllSettings();
			return true;
		}
		private async void AddAllCamerasFromDVR(NVMSDeviceInfo devInfo)
		{
			CameraObject camera = new CameraObject();
			devInfo.Channel = 0;
			camera.DeviceInfo = devInfo.Clone();
			camera.ClientInfo.PlayerChannel = m_nSelectedChannel;
			iNVMSConfig.CameraDevices.AddCamera(camera);
			iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel] = iNVMSConfig.ConnectedCameraCount - 1;

			int nChannelCount = await Task.Run<int>(()=>camera.SDK.GetTotalChannelCount());
			if (nChannelCount > 1)
			{
				for (int i = 1; i < nChannelCount; i++)
				{
					CameraObject newCam = new CameraObject();
					newCam.DeviceInfo = devInfo.Clone();
					newCam.DeviceInfo.Channel = i;
					int nNewChannel = iNVMSConfig.CameraConfig.GetFreeChannel();
					if (nNewChannel == -1)
					{
						break;
					}

					newCam.ClientInfo.PlayerChannel = nNewChannel;
					iNVMSConfig.CameraDevices.AddCamera(newCam);
					iNVMSConfig.CameraConfig.CameraBindInfo[nNewChannel] = iNVMSConfig.ConnectedCameraCount - 1;
				}
			}
			else
			{

			}
			PopulateCameraTree();
			PopulateGroupTree();
			m_bCameraModifid = true;
			cameraPicker.RefreshCameraIcons();
			cameraPicker.SelectCamera(m_nSelectedChannel);
		}
		private bool AddCamera(bool bIPCameraMode)
		{
			NVMSDeviceInfo devInfo = ShowAddIpCamDialog(bIPCameraMode, null, true);
			if (devInfo == null)
				return false;

			if (!bIPCameraMode && devInfo.Channel == -1)		//20171103. Add all cameras from DVR
			{
				AddAllCamerasFromDVR(devInfo);
			}
			else
			{
				CameraObject camera = new CameraObject();
				camera.DeviceInfo = devInfo.Clone();
				camera.ClientInfo.PlayerChannel = m_nSelectedChannel;
                
				iNVMSConfig.CameraDevices.AddCamera(camera);
				iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel] = iNVMSConfig.ConnectedCameraCount - 1;
                
				PopulateCameraTree();
				PopulateGroupTree();
				m_bCameraModifid = true;

				cameraPicker.RefreshCameraIcons();
				cameraPicker.SelectCamera(m_nSelectedChannel);
			}

			iNVMSConfig.SaveAllSettings();
			return true;
		}
		private void mnuAddIPCamera_Click(object sender, EventArgs e)
		{
			AddCamera(true);
		}

		private void treeCamList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode destinationNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
			}
		}
		private int GetSelectedNodeIndex(TreeView tree)
		{
			int nIndex = 0;
			int nSelectedIndex = -1;
			foreach(TreeNode node in tree.Nodes)
			{
				if (node.IsSelected)
					nSelectedIndex = nIndex;

				nIndex++;
			}

			return nSelectedIndex;
		}
		private void treeCamList_NodeMouseDblClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				TreeNode destinationNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
				CameraObject camera = (CameraObject)destinationNode.Tag;
				if (camera.DeviceInfo.AliasName == "Camera")
				{
					NVMSDeviceInfo devInfo = ShowAddIpCamDialog(true, camera.DeviceInfo);
					if (devInfo == null)
						return;
					int nSelectedIndex = GetSelectedNodeIndex(treeCamList);
					
					camera.DeviceInfo = devInfo;

					if (camera.DeviceInfo.DeviceUpdated && nSelectedIndex == m_nSelectedChannel)
						SelectChannelAction(m_nSelectedChannel);

					PopulateCameraTree();
					PopulateGroupTree();
				}
				else
				{
					NVMSDeviceInfo devInfo = ShowAddIpCamDialog(false, camera.DeviceInfo, false);
					if (devInfo == null)
						return;

					camera.DeviceInfo = devInfo;

					int nSelectedIndex = GetSelectedNodeIndex(treeCamList);
					if (camera.DeviceInfo.DeviceUpdated && nSelectedIndex == m_nSelectedChannel)
						SelectChannelAction(m_nSelectedChannel);
					PopulateCameraTree();
					PopulateGroupTree();
				}

			}
		}

		private void ApplyOptionChanges(int nChannel)
		{
			if (!m_bOptionValueChanged)
				return;

			if (nChannel < 0)
				return;

			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[nChannel];

			if (nBindedCamera >= 0)
			{
				CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
				camera.CameraOption = GetCurrentOption();
			}
		}

		private CameraOptions GetCurrentOption()
		{
			CameraOptions option = new CameraOptions();

			option.DisplayName = txtDisplayName1.Text;
            option.Description = txtDescription.Text;
			option.Brightness = trackBright.Value;
			option.Contrast = trackContrast.Value;
			option.Hue = trackHue.Value;
			option.Saturation = trackSaturation.Value;

            return option;
		}
		private void ClosePreviewChannel()
		{
			foreach (CameraObject cam in iNVMSConfig.CameraDevices.DeviceList)
				cam.ClientInfo.PreviewMode = false;

			H264NetSDK.DVR_ClosePlayStream(iNVMSConfig.MaxCameraCount * 2 + 1);
		}
		public async void SelectChannelAction(int nChannel)
		{
            m_nSelectedChannel = nChannel;
			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[nChannel];

			btnEditCamera.Enabled = nBindedCamera >= 0;
			btnDeleteCamera.Enabled = nBindedCamera >= 0;
			btnAddXVRCamera.Enabled = nBindedCamera < 0;
			btnAddIPCamera.Enabled = nBindedCamera < 0;

			RefreshCameraInfoPanel(nBindedCamera);

			await nvmsPlayer.StopRealPlay(true);

			if (nBindedCamera < 0)
			{
				ClosePreviewChannel();
				return;
			}

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
					H264NetSDK.StreamPlayState[iNVMSConfig.MaxCameraCount * 2 + 1] = true;
				}
				H264NetSDK.H264_PLAY_Play(iNVMSConfig.MaxCameraCount * 2 + 1, nvmsPlayer.Handle);
				camera.ClientInfo.PreviewMode = true;
				H264NetSDK.H264_DVR_MakeKeyFrame(camera.SDK.LoginID[0], camera.DeviceInfo.Channel, 1);
				if (!camera.SDK.IsConnected())
				{
					await Task.Run<bool>(() => camera.SDK.Connect());
				}
				return;
			}
			else
			{
				ClosePreviewChannel();
			}
			cameraToConnectTry = new CameraObject();
			cameraToConnectTry.DeviceInfo = camera.DeviceInfo.Clone();
			cameraToConnectTry.CameraOption = camera.CameraOption;
			cameraToConnectTry.ClientInfo.StreamNum = -2;

			if (camera.DeviceInfo.Name == "FHIPCamera")
				cameraToConnectTry.SDK = new FHIPCamSDK(cameraToConnectTry);
			else if (camera.DeviceInfo.Name == "AVer NV Series")
				cameraToConnectTry.SDK = new AVerDSSNVSDK(cameraToConnectTry);
			else if (camera.DeviceInfo.Name == "ONVIF")
				cameraToConnectTry.SDK = new OnVIFCamSDK(cameraToConnectTry);
			else if (camera.DeviceInfo.Name == "RTSP")
				cameraToConnectTry.SDK = new RTSPSDK(cameraToConnectTry);

			cameraToConnectTry.DeviceInfo.DeviceUpdated = true;

			//await nvmsPlayer.StartRealPlay(cameraTemp, iNVMSConfig.GeneralConfig.DefaultFPSForPreview);
			await PreviewCamera();
			//cameraToConnectTry.SDK.SetLocalColor(cameraToConnectTry.CameraOption.Brightness, cameraToConnectTry.CameraOption.Contrast, cameraToConnectTry.CameraOption.Hue, cameraToConnectTry.CameraOption.Saturation);
			//int nBrightness = 50, nContrast = 50, nSaturation = 50, nHue = 50;
			//if (nvmsPlayer.GetVideoColor(ref nBrightness, ref nContrast, ref nSaturation, ref nHue))
			//{
			//	trackBright.Value = nBrightness;
			//	trackContrast.Value = nContrast;
			//	trackSaturation.Value = nSaturation;
			//	trackHue.Value = nHue;
			//}
			
		}
	
		private void RefreshCameraInfoPanel(int nCam)
		{
            cur_cam_index = nCam;
			CameraObject camera = iNVMSConfig.DeviceAt(nCam);

            if (camera == null)
            {
                txtDisplayName1.Text = "";
                txtDescription.Text = "";

                txtCamName.Text = "";
                txtCamDescription.Text = "";
                lblCamAddress.Text = "";
                lblPort.Text = "";

                trackBright.Value = 0;
                trackHue.Value = 0;
                trackSaturation.Value = 0;
                trackContrast.Value = 0;

                txtBright.Text = "";//camera.CameraOption.Brightness.ToString();
                txtContrast.Text = "";
                txtHue.Text = "";
                txtSaturation.Text = "";
				txtChannel.Text = "";
				chkEnableAudio.Checked = false;
				chkDisplayOn.Checked = false;
            }
            else
            {

                txtDisplayName1.Text = camera.CameraOption.DisplayName;
                txtDescription.Text = camera.CameraOption.Description;

                txtCamName.Text = camera.DeviceInfo.Name;
				txtCamDescription.Text = "";
				lblCamAddress.Text = camera.DeviceInfo.IPAddress;
				lblPort.Text = camera.DeviceInfo.Port.ToString();

				int nBrightness = 0;
				int nConstrast = 0;
				int nHue = 0;
				int nSaturation = 0;

				camera.SDK.GetLocalColor(ref nBrightness, ref nConstrast, ref nSaturation, ref nHue);
				camera.CameraOption.Brightness = nBrightness;
				camera.CameraOption.Saturation = nSaturation;
				camera.CameraOption.Hue = nHue;
				camera.CameraOption.Contrast = nConstrast;

				if (camera.CameraOption.Brightness >= trackBright.Minimum && camera.CameraOption.Brightness <= trackBright.Maximum)
					trackBright.Value = camera.CameraOption.Brightness;

				if (camera.CameraOption.Hue >= trackBright.Minimum && camera.CameraOption.Hue <= trackBright.Maximum)
					trackHue.Value = camera.CameraOption.Hue;

				if (camera.CameraOption.Saturation >= trackBright.Minimum && camera.CameraOption.Saturation <= trackBright.Maximum)
					trackSaturation.Value = camera.CameraOption.Saturation;

				if (camera.CameraOption.Contrast >= trackBright.Minimum && camera.CameraOption.Contrast <= trackBright.Maximum)
					trackContrast.Value = camera.CameraOption.Contrast;

				txtBright.Text = nBrightness.ToString();//camera.CameraOption.Brightness.ToString();
				txtContrast.Text = camera.CameraOption.Contrast.ToString();
				txtHue.Text = camera.CameraOption.Hue.ToString();
				txtSaturation.Text = camera.CameraOption.Saturation.ToString();

				txtChannel.Text = (camera.DeviceInfo.Channel + 1).ToString();
				chkEnableAudio.Checked = camera.DeviceInfo.EnableAudio;
				chkDisplayOn.Checked = camera.DeviceInfo.DisplayOn;
            }

			m_bOptionValueChanged = false;
		}
        private async void mnuDeleteAllCamera_Click(object sender, EventArgs e)
        {
			if (iNVMSConfig.CameraDevices.DeviceList.Count <= 0)
				return;

            if (MessageBox.Show("Are you sure you want to delete all cameras?", "Camera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await Task.Run<bool>(() => iNVMSConfig.CameraDevices.DeleteAll());
            PopulateCameraTree();
			PopulateGroupTree();
			m_bCameraModifid = true;

			//cameraPicker.LayoutCameraButtons(16);
			cameraPicker.RefreshCameraIcons();
			SelectChannelAction(m_nSelectedChannel);
        }

        private void btnAddIPCam_Click(object sender, EventArgs e)
        {
			AddCamera(true);
        }

        private void btnAddXVRCamera_Click(object sender, EventArgs e)
        {
			AddCamera(false);
			//AddXVRCamera();
        }

		private void chkCameraSettingAll_CheckedChanged(object sender, EventArgs e)
		{
			cameraPicker.SelectAll(chkCameraSettingAll.Checked);
		}

		private void btnIPCamPnPSetup_Click(object sender, EventArgs e)
		{
			FrmCameraBinding dlg = new FrmCameraBinding();
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				if (dlg.BindInfoChanged)
					m_bCameraModifid = true;
			}
		}

		private void grpCamera_Enter(object sender, EventArgs e)
		{

		}

		private void Form_Shown(object sender, EventArgs e)
		{
			//nvmsPlayer.ShowHide(true);
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			nvmsPlayer.StopRealPlay();
			nvmsPlayer.Dispose();
			ClosePreviewChannel();
		}
		private void UpdateCameraTreeNode(CameraObject camera)
		{
			foreach (TreeNode node in treeCamList.Nodes)
			{
				CameraObject nodeCamera = node.Tag as CameraObject;
				if (nodeCamera == camera)
				{
					if (string.IsNullOrEmpty(camera.CameraOption.DisplayName))
						node.Text = "Camera" + (camera.ClientInfo.PlayerChannel + 1).ToString();
					else
						node.Text = camera.CameraOption.DisplayName;
					break;
				}
			}
			TreeNode groupNode = treeViewGroup.Nodes[camera.GroupID];
			if (groupNode == null)
				return;

			foreach (TreeNode node in groupNode.Nodes)
			{
				CameraObject nodeCamera = node.Tag as CameraObject;
				if (nodeCamera == camera)
				{
					if (string.IsNullOrEmpty(camera.CameraOption.DisplayName))
						node.Text = "Camera" + (camera.ClientInfo.PlayerChannel + 1).ToString();
					else
						node.Text = camera.CameraOption.DisplayName;

					return;
				}
			}
		}
		private void DisplayName_Changed(object sender, EventArgs e)
		{
			if (m_nSelectedChannel < 0)
				return;

			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
			CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
			if (camera != null)
			{
                camera.CameraOption.DisplayName = txtDisplayName1.Text;
				nvmsPlayer.UpdateDisplayName(txtDisplayName1.Text);
				UpdateCameraTreeNode(camera);
			}
			else
				nvmsPlayer.UpdateDisplayName();
		}

		private void btnEditCamera_Click(object sender, EventArgs e)
		{
			CameraObject camera = iNVMSConfig.DeviceAtWithChannel(m_nSelectedChannel);

			if (EditCameraInfo(camera))
			{
				RefreshCameraInfoPanel(m_nSelectedChannel);
                if (camera.DeviceInfo.DeviceUpdated)		//refresh current play with new device info
                {
					camera.SDK.Connect();
                    int nSelCam_bak = m_nSelectedChannel;
                    m_nSelectedChannel = -1;
					SelectChannelAction(nSelCam_bak);
                }
			}
		}

		private bool EditCameraInfo(CameraObject camera)
		{
			if (camera == null)
				return false;

			NVMSDeviceInfo devInfo = ShowAddIpCamDialog(true, camera.DeviceInfo, camera.DeviceInfo.AliasName == "Camera");
			if (devInfo == null)
				return false;

			if (camera.DeviceInfo.Name != devInfo.Name)
			{
				camera.SDK.StopRealPlay(0);
				camera.SDK.Logout(0);
				if (devInfo.Name == "FHIPCamera")
					camera.SDK = new FHIPCamSDK(camera);
				else if (devInfo.Name == "iLinkPro iHD Series" || devInfo.Name == "XM XVR")
					camera.SDK = new H264NetSDK(camera);
				else if (devInfo.Name == "AVer NV Series")
					camera.SDK = new AVerDSSNVSDK(camera);
				else if (devInfo.Name == "ONVIF")
					camera.SDK = new OnVIFCamSDK(camera);
				else if (devInfo.Name == "RTSP")
					camera.SDK = new RTSPSDK(camera);
			}
			camera.DeviceInfo = devInfo.Clone();
			PopulateCameraTree();
			PopulateGroupTree();

			return true;
		}
		private async void DeleteCamera(int nCam)
		{
			CameraObject camera = iNVMSConfig.DeviceAt(nCam);

			await iNVMSConfig.CameraDevices.DeleteCamera(camera);
			PopulateCameraTree();
			PopulateGroupTree();
			m_bCameraModifid = true;
			iNVMSConfig.SaveAllSettings();

			//cameraPicker.LayoutCameraButtons(16);
			cameraPicker.RefreshCameraIcons();
			RefreshCameraInfoPanel(-1);
			//cameraPicker.SelectCamera(0);
		}
        private async void btnDeleteCamera_Click(object sender, EventArgs e)
        {
			int nCam = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
            if (nCam < 0)
                return;

            if (MessageBox.Show("Are you sure you want to remove selected camera?", "Camera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
				await nvmsPlayer.StopRealPlay();
				DeleteCamera(nCam);
            }
		}

		private void OnCameraTree_MouseDown(object sender, MouseEventArgs e)
		{
		}

		private void OnCameraTree_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void Player_DragDrop(object sender, DragEventArgs e)
		{
			TreeNode node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
			CameraObject camera = node.Tag as CameraObject;

			int nChannel = camera.ClientInfo.PlayerChannel;
			if (nChannel >= 0)
				cameraPicker.SelectCamera(nChannel);
		}

		private void Player_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
			Cursor.Current = new Cursor(Properties.Resources.ipcamera.Handle);
		}

		private void TreeCamList_MouseDown(object sender, MouseEventArgs e)
		{
			//TreeNode node = treeCamList.SelectedNode;

			//if (node == null)
			//	return;

			//if (node.Parent != null)
			//	node = node.Parent;

			//CameraObject camera = node.Tag as CameraObject;

			//DoDragDrop(camera, DragDropEffects.All);
		}

		private void TreeCam_ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode node = treeCamList.SelectedNode;

			if (node == null)
				return;

			if (node.Parent != null)
				node = node.Parent;

			treeCamList.DoDragDrop(node, DragDropEffects.Copy);
		}

		private void TreeCam_DoubleClick(object sender, EventArgs e)
		{
			TreeNode node = treeCamList.SelectedNode;

			if (node == null)
				return;

			if (node.Parent == null)
				return;

			CameraObject camera = node.Parent.Tag as CameraObject;
			if (EditCameraInfo(camera))
				RefreshCameraInfoPanel(node.Parent.Index);
		}

		private void TreeCam_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
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

		private async Task<bool> PreviewCamera()
		{
			await nvmsPlayer.StopRealPlay(true);
			Task<bool> ret = nvmsPlayer.StartRealPlay(cameraToConnectTry, iNVMSConfig.GeneralConfig.DefaultFPSForPreview);
			bool bRet = await ret;
			return bRet;
		}

		private void btnAddGroup_Click(object sender, EventArgs e)
		{
			FrmInput frmInput = new FrmInput();
			if (frmInput.ShowDialog(this) == DialogResult.OK)
			{
				iNVMSConfig.CameraConfig.AddGroup(frmInput.NewName);
				PopulateGroupTree();
			}
		}

		private void treeViewGroup_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Parent == null)
			{
				e.Node.SelectedImageIndex = 1;
				e.Node.ImageIndex = 1;
			}
		}

		private void treeViewGroup_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent == null)
			{
				e.Node.ImageIndex = 0;
				e.Node.SelectedImageIndex = 0;
			}
		}

		private void treeViewGroup_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
			Cursor.Current = new Cursor(Properties.Resources.ipcamera.Handle);
		}

		private void treeViewGroup_DragDrop(object sender, DragEventArgs e)
		{
			Point targetPoint = treeViewGroup.PointToClient(new Point(e.X, e.Y));
			TreeNode targetNode = treeViewGroup.GetNodeAt(targetPoint);

			if (targetNode == null)
				return;

			while (targetNode.Parent != null)
				targetNode = targetNode.Parent;

			int nGroupID = treeViewGroup.Nodes.IndexOf(targetNode);

			TreeNode node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
			CameraObject camera = node.Tag as CameraObject;

			if (camera.GroupID == nGroupID)
				return;
			else
			{
				foreach (TreeNode subNode in treeViewGroup.Nodes[camera.GroupID].Nodes)
				{
					CameraObject cameraNode = subNode.Tag as CameraObject;
					if (cameraNode == camera)
					{
						treeViewGroup.Nodes[camera.GroupID].Nodes.Remove(subNode);
						break;
					}
				}
			}
			camera.GroupID = nGroupID;
			
			TreeNode newNode = GetTreeNodeFromCamera(camera);

			targetNode.Nodes.Add(newNode);
		}
		private void Player_HandleDestroyed(object sender, EventArgs e)
		{
			nvmsPlayer.IsDestroyed = true;
		}
		private void treeCamList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void treeViewGroup_DragOver(object sender, DragEventArgs e)
		{
			Point targetPoint = treeViewGroup.PointToClient(new Point(e.X, e.Y));
			TreeNode targetNode = treeViewGroup.GetNodeAt(targetPoint);

			TreeNode node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
			CameraObject camera = node.Tag as CameraObject;

			int nGroupID = treeViewGroup.Nodes.IndexOf(targetNode);

			if (targetNode != null)
			{
				treeViewGroup.Focus();
				treeViewGroup.SelectedNode = targetNode;
			}
		}

		private void mnuRenameGroup_Click(object sender, EventArgs e)
		{
			TreeNode selNode = treeViewGroup.SelectedNode;
			if (selNode == null)
				return;

			if (selNode.Parent != null)		//rename camera 
			{
				
			}
			else
			{
				
			}
		}

		private void mnuTreeViewGroupDelete_Click(object sender, EventArgs e)
		{
			TreeNode selNode = treeViewGroup.SelectedNode;
			if (selNode == null)
				return;

			int nGroupID = treeViewGroup.Nodes.IndexOf(selNode);
			iNVMSConfig.CameraDevices.DeleteGroup(nGroupID);
		}

		private void btnRemoveGroup_Click(object sender, EventArgs e)
		{
			TreeNode selNode = treeViewGroup.SelectedNode;
			if (selNode == null)
				return;

			int nGroupID = treeViewGroup.Nodes.IndexOf(selNode);
			if (nGroupID == 0)
			{
				MessageBox.Show("You can't delete Default group", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				iNVMSConfig.CameraDevices.DeleteGroup(nGroupID);
			}
		}

		private void treeViewGroup_ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode node = treeViewGroup.SelectedNode;

			if (node == null)
				return;

			if (node.Parent == null)
				return;

			if (node.Nodes.Count < 3)
				return;

			treeViewGroup.DoDragDrop(node, DragDropEffects.Copy);
		}

		private void txtDisplayName1_TextChanged(object sender, EventArgs e)
		{
			m_bOptionValueChanged = true;
			DisplayName_Changed(sender, e);
		}

		private void FrmCameraSetting_Move(object sender, EventArgs e)
		{
			nvmsPlayer.ShowHide(true);
		}

		private void chkDisplayOn_CheckedChanged(object sender, EventArgs e)
		{
			if (m_nSelectedChannel < 0)
				return;

			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
			CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
			if (camera != null)
			{
				camera.DeviceInfo.DisplayOn = chkDisplayOn.Checked;
			}
		}

		private void chkEnableAudio_CheckedChanged(object sender, EventArgs e)
		{
			if (m_nSelectedChannel < 0)
				return;

			int nBindedCamera = iNVMSConfig.CameraConfig.CameraBindInfo[m_nSelectedChannel];
			CameraObject camera = iNVMSConfig.DeviceAt(nBindedCamera);
			if (camera != null)
			{
				camera.CameraOption.EnableAudio = chkEnableAudio.Checked;
			}
		}

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            CameraObject camera = iNVMSConfig.DeviceAt(cur_cam_index);
            if (camera != null)
            {
                camera.CameraOption.Description = txtDescription.Text;
                iNVMSConfig.SaveAllSettings();
            }
        }

        private void chkNightView_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoBrightControl_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

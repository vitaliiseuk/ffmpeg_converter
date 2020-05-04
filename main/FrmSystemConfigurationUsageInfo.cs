using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Windows.Forms;
using iNVMS.SDK;
using System.Net.NetworkInformation;

namespace iNVMSMain
{
    public partial class FrmSystemConfigurationUsageInfo : Form
    {
        private iNVMS.SDK.SystemData sd = new iNVMS.SDK.SystemData();
        public iNVMS.SDK.SystemData.netInfo[] stNetInfo;
        private static int netIdx = 0;

        private NetworkInterface[] nicArr;
        private NetworkInterface nic;
        private IPv4InterfaceStatistics interfaceStats;
        private long prev_bytes = 0;
        private Random rnd;
        private long total_fps = 0;
        private long total_bps_0 = 0;
        private long total_bps_1 = 0;

        private long t1 = 0;
        private long t2 = 0;
        private long t3 = 0;


        bool iscontinue = true;
        public FrmSystemConfigurationUsageInfo()
        {
            InitializeComponent();

            listStoragePath.Items.Clear();
            foreach (string strPath in iNVMSConfig.SystemConfig.m_storageSetting.VideoPath)
            {
                float fTotalGigaByte = .0f;
                float fFreeGigaByte = .0f;

                bool bRet = LocalServiceProvider.GetDriveSpaceInfo(strPath, ref fTotalGigaByte, ref fFreeGigaByte);
                string[] strRow = { fFreeGigaByte.ToString("0.00") + "GB", fTotalGigaByte.ToString("0.00") + "GB" };
                listStoragePath.Items.Add(strPath).SubItems.AddRange(strRow);
            }
        }

        private void UpdateData()
        {
            //
            string s;
            double d;
            string[] memInfo;

            try
            {
                s = sd.GetProcessorData();
                lblCpuPercent.Text = s;
                d = double.Parse(s.Substring(0, s.IndexOf("%")));
                dataChartCpu.UpdateChart(d);

                // virtual memory
                memInfo = sd.GetMemoryVData();
                lblvTotalM.Text = memInfo[0];
                lblvUsedM.Text = memInfo[1];
                lblvPercentM.Text = memInfo[2];
                d = double.Parse(memInfo[2].Substring(0, memInfo[2].IndexOf("%")));
                vMemChart.UpdateChart(d);

                //physical memory
                memInfo = sd.GetMemoryPData();
                lblpTotalM.Text = memInfo[0];
                lblpUsedM.Text = memInfo[1];
                lblpPercentM.Text = memInfo[2];
                d = double.Parse(memInfo[2].Substring(0, memInfo[2].IndexOf("%")));
                pMemChart.UpdateChart(d);

                interfaceStats = nic.GetIPv4Statistics();
                //Console.WriteLine((interfaceStats.BytesReceived - prev_bytes).ToString());

                total_fps = 0;
                total_bps_0 = 0;
                total_bps_1 = 0;

                rnd = new Random();

                for (int i = 0; i < iNVMSConfig.CameraConfig.CameraBindInfo.Length; i++)
                {
                    if (iNVMSConfig.CameraConfig.CameraBindInfo[i] != -1)
                    {
                        t1 = rnd.Next(14, 16) + rnd.Next(14, 16);
                        t2 = Convert.ToInt64((interfaceStats.BytesReceived - prev_bytes) / 1024);
                        t3 = Convert.ToInt64((interfaceStats.BytesReceived - prev_bytes) / 1024) * 3;
                        dataGridViewCameraInfoD.Rows[i].Cells[2].Value = t1.ToString() + " f/s";
                        dataGridViewCameraInfoD.Rows[i].Cells[3].Value = t2.ToString() + " k/s";
                        dataGridViewCameraInfoD.Rows[i].Cells[4].Value = t3.ToString() + " k/s";

                        total_fps += t1;
                        total_bps_0 += t2;
                        total_bps_1 += t3;

                        prev_bytes = interfaceStats.BytesReceived;
                    }
                    else
                    {
                        dataGridViewCameraInfoD.Rows[i].Cells[2].Value = "0 f/s";
                        dataGridViewCameraInfoD.Rows[i].Cells[3].Value = "0 k/s";
                        dataGridViewCameraInfoD.Rows[i].Cells[4].Value = "0 k/s";
                    }
                }

                dataGridViewCameraInfoT.Rows[0].Cells[2].Value = total_fps.ToString() + " f/s";
                dataGridViewCameraInfoT.Rows[0].Cells[3].Value = total_bps_0.ToString() + " k/s";
                dataGridViewCameraInfoT.Rows[0].Cells[4].Value = total_bps_1.ToString() + " k/s";
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            // cpu usage
  

        }
        private void FrmSystemConfigurationUsageInfo_Load(object sender, EventArgs e)
        {

            UpdateData();

            timer1.Interval = 1000;
            timer1.Start();

            timer2.Interval = 1000;
            //timer2.Start();

            //load network info
            try
            {
                stNetInfo = sd.GetNetData();
                if (stNetInfo != null)
                {
                    for (int i = 0; i < stNetInfo.Length; i++)
                    {
                        cmbNetwork.Items.Add(stNetInfo[i].netName);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

            int num_active_cams = 0;
            for (int i = 0; i < iNVMSConfig.CameraConfig.CameraBindInfo.Length; i++)
            {
                dataGridViewCameraInfoD.Rows.Add();

                dataGridViewCameraInfoD.Rows[i].Cells[0].Value = i;
                dataGridViewCameraInfoD.Rows[i].Cells[1].Value = "Camera " + (i+1).ToString();
                if (iNVMSConfig.CameraConfig.CameraBindInfo[i] != -1)
                {
                    dataGridViewCameraInfoD.Rows[i].Cells[5].Value = "Connected";
                    num_active_cams += 1;
                }
                else
                {
                    dataGridViewCameraInfoD.Rows[i].Cells[5].Value = "None";
                }
            }

            dataGridViewCameraInfoT.Rows[0].Cells[1].Value = "Name";
            dataGridViewCameraInfoT.Rows[0].Cells[5].Value = "a:0 / w:0 / IPcam:" + num_active_cams.ToString();

            // Grab all local interfaces to this computer
            nicArr = NetworkInterface.GetAllNetworkInterfaces();
            nic = nicArr[0];
        }

        public void UpdateNetworkInterface()
        {
            try
            {
                stNetInfo = sd.GetNetData();
                lblNetOrigSpeed.Text = stNetInfo[netIdx].netOrigSpeed;
                if (stNetInfo[netIdx].netStatus)
                    lblNetStatus.Text = "Connected";
                else
                    lblNetStatus.Text = "Disconnected";
                lblNetUsedSpeed.Text = stNetInfo[netIdx].netUsedSpeed;
                lblNetPercent.Text = stNetInfo[netIdx].netPercent;
                double dUse = double.Parse(stNetInfo[netIdx].netUsedSpeed.Substring(0, stNetInfo[netIdx].netUsedSpeed.IndexOf(" ")));
                //double dUse = double.Parse(stNetInfo[netIdx].netUsedSpeed.Substring(0, stNetInfo[netIdx].netUsedSpeed.IndexOf("%")));
                dataChartNet.UpdateChart(dUse);

                

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        private void FrmSystemConfigurationUsageInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            iscontinue = false;
            timer1.Stop();
            timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void cmbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer2.Stop();
            netIdx = cmbNetwork.SelectedIndex;
            timer2.Start();

            //MessageBox.Show(stNetInfo[i].netName);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateNetworkInterface();
        }
    }
}

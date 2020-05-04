using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Shell32;
using AxAXVLC;
using System.Diagnostics;
using System.Threading;
using iNVMS.SDK;

namespace iNVMSMain
{
    public partial class FrmRecordingCalculator : Form
    {
        public List<string> outputLines = new List<string>();
        public double ratio_time_capacity = 0.0;

        public FrmRecordingCalculator()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = txtHdSize.Text;
            int hd_size = 0;

            if (int.TryParse(t1, out hd_size))
            {
                double days = hd_size / ratio_time_capacity;
                double min = days - 0.7;
                double max = days + 0.2;
                if (min < 0.0)
                    min = days;
                txtRecodingTime.Text = min.ToString("0.0") + " - " + max.ToString("0.0");
            }
            else
            {
                MessageBox.Show("Input is not number or valid value.", "Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRecordingCalculator_Load(object sender, EventArgs e)
        {
            txtTotalRecordingTime.Enabled = false;
            txtHdSize.Enabled = false;
            txtRecodingTime.Enabled = false;

            Thread thread = new Thread(new ThreadStart(runThread));
            thread.Start();
        }

        public void runThread() {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                Console.WriteLine("Hello, world");
            
                //path to ffmpeg (I HATE!!! MS special folders)
                string ffPath = @"./bin/ffmpeg.exe";
                string strCommand = "";

                double total_secs = 0.0;
                double total_length = 0.0;

                List<string> paths = iNVMSConfig.SystemConfig.m_storageSetting.VideoPath;

                int total_files = 0;
                int crt_files = 0;

                if (paths.Count != 0)
                {
                    foreach (string val in paths)
                    {
                        int fCount = Directory.GetFiles(val, "*", SearchOption.AllDirectories).Length;
                        total_files += fCount;
                    }

                    //Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
                    //Console.WriteLine(total_files);

                    foreach (string value in paths)
                    {
                        string[] directories = Directory.GetDirectories(value);

                        foreach (string d in directories)
                        {
                            string[] files = Directory.GetFiles(d);

                            foreach (string file_value in files)
                            {
                                //Console.WriteLine(file_value);

                                outputLines.Clear();
                                strCommand = string.Concat(" -i \"", file_value, "\"");

                                Process processFfmpeg = new Process();

                                processFfmpeg.StartInfo.Arguments = strCommand;
                                processFfmpeg.StartInfo.FileName = ffPath;

                                //I have to say that I struggled for a while with the order that I setup the process.
                                //But this order below I know to work


                                processFfmpeg.StartInfo.UseShellExecute = false;
                                processFfmpeg.StartInfo.RedirectStandardOutput = true;
                                processFfmpeg.StartInfo.RedirectStandardError = true;
                                processFfmpeg.StartInfo.CreateNoWindow = true;
                                processFfmpeg.ErrorDataReceived += processFfmpeg_OutData;
                                processFfmpeg.OutputDataReceived += processFfmpeg_OutData;
                                processFfmpeg.EnableRaisingEvents = true;
                                processFfmpeg.Start();
                                processFfmpeg.BeginOutputReadLine();
                                processFfmpeg.BeginErrorReadLine();
                                processFfmpeg.WaitForExit();
                                processFfmpeg.Close();
                                processFfmpeg.Dispose();

                                //I filter the lines because I only want 'Duration' this time
                                string oStr = "";
                                foreach (string str in outputLines)
                                {
                                    //Console.WriteLine(str);
                                    if (str.Contains("Duration"))
                                    {
                                        oStr = str;
                                    }
                                }

                                //Console.WriteLine(oStr);
                                string[] t1 = (oStr.Trim()).Split(',');
                                string[] t2 = (t1[0].Trim()).Split(' ');
                                string[] t3 = (t2[1].Trim()).Split(':');

                                //Console.WriteLine(t3[0]);
                                //Console.WriteLine(t3[1]);
                                //Console.WriteLine(t3[2]);

                                double secs = Double.Parse(t3[0]) * 3600 + Double.Parse(t3[1]) * 60 + Double.Parse(t3[2]);
                                //Console.WriteLine(secs);


                                long length = new FileInfo(file_value).Length;
                                //Console.WriteLine(length);

                                total_secs += secs;
                                total_length += Convert.ToDouble(length);

                                crt_files += 1;

                                //Console.WriteLine(crt_files);

                                try
                                {
                                    progressBar1.Invoke((MethodInvoker)delegate
                                    {
                                        progressBar1.Value = 100 * crt_files / total_files;
                                    });
                                }
                                catch (Exception) { return; }
                            }
                        }
                    }
                }

                Console.WriteLine(total_secs);
                Console.WriteLine(total_length);

                ratio_time_capacity = total_length / total_secs * 3600 * 24 / 1024 / 1024 / 1024;
                Console.WriteLine(ratio_time_capacity);

                double days = total_secs * 0.1 / 3600 / 24;
                //Console.WriteLine(days.ToString("0.0"));

                try
                {
                    txtTotalRecordingTime.Invoke((MethodInvoker)delegate {
                        double min = days - 0.7;
                        double max = days + 0.2;

                        if (min < 0.0)
                            min = days;
                        txtTotalRecordingTime.Text = min.ToString("0.0") + " - " + max.ToString("0.0");
                    });
                }
                catch (Exception) { return; }

                try
                {
                    txtHdSize.Invoke((MethodInvoker)delegate {
                        txtHdSize.Enabled = true;
                    });
                }
                catch (Exception) { return; }

                try
                {
                    txtRecodingTime.Invoke((MethodInvoker)delegate {
                        txtRecodingTime.Enabled = true;
                    });
                }
                catch (Exception) { return; }



            //foreach (string strPath in iNVMSConfig.SystemConfig.m_storageSetting.VideoPath)
            //{
            //    float fTotalGigaByte = .0f;
            //    float fFreeGigaByte = .0f;

            //    bool bRet = LocalServiceProvider.GetDriveSpaceInfo(strPath, ref fTotalGigaByte, ref fFreeGigaByte);
            //    string[] strRow = { fFreeGigaByte.ToString("0.00") + "GB", fTotalGigaByte.ToString("0.00") + "GB" };


            //}
        }

        private void processFfmpeg_OutData(object sender, DataReceivedEventArgs e)
        {
            //The data we want is in e.Data, you must be careful of null strings
            string strMessage = e.Data;
            if (outputLines != null && strMessage != null && strMessage.Length > 0)
            {
                outputLines.Add(string.Concat(strMessage, "\n"));
                //Try a Console output here to see all of the output. Particularly
                //useful when you are examining the packets and working out timeframes
                //Console.WriteLine(strMessage);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

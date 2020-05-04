using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using AxAXVLC;
using iNVMS.SDK;
using System.IO;

namespace iNVMSMain
{
    public partial class FrmPlayBack : Form
    {
        public int i, j;
        public int segment = 1;
        List<string> col_list = new List<string>(new string[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
        public List<AxVLCPlugin2> Players = new List<AxVLCPlugin2>();
        public List<PictureBox> PlayerThumbs = new List<PictureBox>();
        public int page = 0;
        public PlayBackDetails PlayBackList = new PlayBackDetails();    // total loaded record date
        public int recordedCamCount = 0;        // the number of cams which has record data
        public List<string> active_cams = new List<string>(new string[] { "01" });   // selected list of cams
        public string selected_hour = "";       // selected hour

        public string crt_date = "";
        public int fast = 1;
        public int slow = 1;

        public FrmPlayBack()
        {
            InitializeComponent();
        }

        private void FrmPlayBack_Load(object sender, EventArgs e)
        {
            exitBtn.Top = (int)(this.Height * 0.9);

            grbVideoView.Location = new Point((int)(this.Width * 0.005), (int)(this.Height * 0.01));
            grbVideoView.Width = (int)(this.Width * 0.85);
            grbVideoView.Height = (int)(this.Height * 0.77);

            int w = grbVideoView.Width;
            int h = grbVideoView.Height;

            videoViewLayout();

            grbLayoutButton.Location = new Point((int)(w * 0.111), (int)(h * 1.02));
            grbCamera.Location = new Point((int)(w * 1.01), (int)(h - grbCamera.Height));
            grbVideoButton.Location = new Point((int)(w * 0.5), (int)(h * 1.1));
            
            lblStatus.Location = new Point((int)(w * 0.8), (int)(h * 1.025));
            trackSlider.Location = new Point((int)(w * 0.195), (int)(h * 1.2));

            dataGridView1.Location = new Point((int)(w * 0.2), (int)(h * 1.25));

            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Selected = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            pictureBox1.Size = new Size((int)(w * 1.08), (int)(h * 1.16));
            pictureBox1.Location = new Point(0, 0);

            pictureBox2.Location = new Point((int)(w * 1.02), (int)(h - grbCamera.Height - pictureBox2.Height));

            for (i = 0; i < 1; i++)
            {
                for (j = 0; j < 24; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = j < 10 ? "0" + j.ToString() : j.ToString();
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkGray;
                }
            }
            
        }

        public void lbsi_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            //Console.WriteLine(label.Name);
            active_cams.Clear();

            for (i = 0; i < Players.Count; i++)
            {
                Players[i].playlist.stop();
                Players[i].playlist.items.clear();
            }

            for (i = 0; i < PlayerThumbs.Count; i++)
            {
                PlayerThumbs[i].Visible = true;
            }

            for (i = 0; i < 32; i++)
            {
                grbCamera.Controls["label" + (i + 1).ToString()].BackColor = Color.DarkGray;
            }

            int interval = segment * segment;
            int val = ((Convert.ToInt32(label.Text) - 1) % 32) / interval;
            for (i = val * interval; i < (val + 1) * interval; i++)
            {
                if (i == 32)
                    break;

                grbCamera.Controls["label" + (i + 1).ToString()].BackColor = Color.IndianRed;
                active_cams.Add(grbCamera.Controls["label" + (i + 1).ToString()].Text);
            }

            label.BackColor = Color.DarkRed;
            
            for (i = 0; i < PlayBackList.cams.Count; i++)
            {
                if (PlayBackList.hours[i] == selected_hour)
                {
                    int cam_index = active_cams.IndexOf(PlayBackList.cams[i]);
                    
                    if (cam_index != -1)
                    {
                        PlayerThumbs[cam_index].Visible = false;
                        Players[cam_index].playlist.stop();
                        Players[cam_index].playlist.items.clear();
                        var uri = new Uri(PlayBackList.file_name[i]);
                        var convertedURI = uri.AbsoluteUri;
                        Players[cam_index].playlist.add(convertedURI);
                        Players[cam_index].playlist.play();

                        lblStatus.Text = "Playback: " + PlayBackList.cams[i] + "-" + PlayBackList.hours[i];
                    }
                }
            }
        }

        private void videoViewLayout ()
        {
            for (i = 0; i < segment; i++)
            {
                for (j = 0; j < segment; j++)
                {
                    AxVLCPlugin2 player0 = new AxVLCPlugin2();
                    grbVideoView.Controls.Add(player0);
                    
                    player0.Size = new Size((int)(grbVideoView.Width / segment - 5), (int)(grbVideoView.Height / segment - 5));
                    player0.Location = new Point(j * (5 + player0.Width), i * (5 + player0.Height));

                    PictureBox pic0 = new PictureBox();
                    pic0.Image = Properties.Resources.video;
                    pic0.BackColor = Color.Black;
                    grbVideoView.Controls.Add(pic0);
                    grbVideoView.Controls.SetChildIndex(pic0, 0);
                    pic0.SizeMode = PictureBoxSizeMode.Zoom;
                    pic0.Size = new Size(player0.Height / 2, player0.Height / 2);
                    pic0.Location = new Point(player0.Left + (player0.Width - pic0.Width) / 2, player0.Top + (player0.Height - pic0.Height) / 2);

                    Players.Add(player0);
                    PlayerThumbs.Add(pic0);
                }
            }
        }

        private void layoutBtn1_Click(object sender, EventArgs e)
        {
            segment = 1;
            Players.Clear();
            PlayerThumbs.Clear();
            grbVideoView.Controls.Clear();
            videoViewLayout();

            for (i = 1; i < 33; i++)
            {
                grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;
            }
            active_cams.Clear();
            //Console.WriteLine(Players.Count);
        }

        private void layoutBtn2_Click(object sender, EventArgs e)
        {
            segment = 2;
            Players.Clear();
            PlayerThumbs.Clear();
            grbVideoView.Controls.Clear();
            videoViewLayout();

            for (i = 1; i < 33; i++)
            {
                grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;
            }
            active_cams.Clear();
            //Console.WriteLine(Players.Count);
        }

        private void layoutBtn3_Click(object sender, EventArgs e)
        {
            segment = 3;
            Players.Clear();
            PlayerThumbs.Clear();
            grbVideoView.Controls.Clear();
            videoViewLayout();

            for (i = 1; i < 33; i++)
            {
                grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;
            }
            active_cams.Clear();
            //Console.WriteLine(Players.Count);
        }

        private void layoutBtn4_Click(object sender, EventArgs e)
        {
            segment = 4;
            Players.Clear();
            PlayerThumbs.Clear();
            grbVideoView.Controls.Clear();
            videoViewLayout();

            for (i = 1; i < 33; i++)
            {
                grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;
            }
            active_cams.Clear();
            //Console.WriteLine(Players.Count);
        }

        private void label33_Click(object sender, EventArgs e)
        {
            int temp;

            if (page == 1)
            {
                for (i = 1; i < 33; i++)
                {
                    grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;

                    temp = Convert.ToInt32(grbCamera.Controls["Label" + i.ToString()].Text) - 32;
                    if (temp < 10)
                        grbCamera.Controls["Label" + i.ToString()].Text = "0" + temp.ToString();
                    else
                        grbCamera.Controls["Label" + i.ToString()].Text = temp.ToString();
                }
                page -= 1;
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                for (i = 1; i < 33; i++)
                {
                    grbCamera.Controls["Label" + i.ToString()].Text = (Convert.ToInt32(grbCamera.Controls["Label" + i.ToString()].Text) + 32).ToString();
                    grbCamera.Controls["Label" + i.ToString()].BackColor = Color.DarkGray;
                }
                page += 1;
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            FrmPlayBackArchive frmPlayBackArchive = new FrmPlayBackArchive();

            crt_date = "";
            for (i = 0; i < 24; i++)
            {
                dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.DarkGray;
            }

            for (i = 0; i < Players.Count; i++)
            {
                Players[i].playlist.stop();
                Players[i].playlist.items.clear();
            }

            for (i = 0; i < 32; i++)
            {
                grbCamera.Controls["label" + (i + 1).ToString()].BackColor = Color.DarkGray;
            }

            for (i = 0; i < PlayerThumbs.Count; i++)
            {
                PlayerThumbs[i].Visible = true;
            }

            PlayBackList.cams.Clear();
            PlayBackList.hours.Clear();
            PlayBackList.file_name.Clear();
            active_cams.Clear();

            if (frmPlayBackArchive.ShowDialog(this) == DialogResult.OK)
            {
                crt_date = frmPlayBackArchive.selected_date;
            }

            if (crt_date == "")
                return;

            //Console.WriteLine(crt_date);

            string[] temp = crt_date.Split(' ');
            string[] date_array = temp[0].Split('/');
            if (date_array[0].Length == 1)
                date_array[0] = "0" + date_array[0];
            if (date_array[1].Length == 1)
                date_array[1] = "0" + date_array[1];

            string rlt = date_array[2] + "_" + date_array[0] + "_" + date_array[1];
            //Console.WriteLine(rlt);

            List<string> paths = iNVMSConfig.SystemConfig.m_storageSetting.VideoPath;

            if (paths.Count != 0)
            {
                foreach (string value in paths)
                {
                    //Console.WriteLine(value);

                    string[] directories = Directory.GetDirectories(value);

                    if (directories.Count() != 0)
                        recordedCamCount = directories.Count();

                    foreach (string d in directories)
                    {
                        //Console.WriteLine(d);
                        string[] files = Directory.GetFiles(d);
                        foreach (string file_value in files)
                        {
                            //Console.WriteLine(file_value);
                            if (file_value.Contains(rlt))
                            {
                                temp = d.Split('\\');
                                string cam_name = temp[temp.Length - 1];
                                cam_name = cam_name.Substring(6);

                                temp = file_value.Split('\\');
                                string record_hour = temp[temp.Length - 1];
                                temp = record_hour.Split('_');
                                record_hour = temp[4];

                                //Console.WriteLine("+++++++++++++++++++++++++++++++++");
                                //Console.WriteLine(cam_name);
                                //Console.WriteLine(record_hour);
                                
                                int c_index = col_list.IndexOf(record_hour);
                                dataGridView1.Rows[0].Cells[c_index].Style.BackColor = Color.Blue;

                                PlayBackList.cams.Add(cam_name);
                                PlayBackList.hours.Add(record_hour);
                                PlayBackList.file_name.Add(file_value);
                            }
                        }
                    }
                }

                for (i = 0; i < PlayBackList.cams.Count; i++)
                {
                    if (PlayBackList.hours[i] == selected_hour)
                    {
                        int cam_index = active_cams.IndexOf(PlayBackList.cams[i]);

                        if (cam_index != -1)
                        {
                            PlayerThumbs[cam_index].Visible = false;
                            Players[cam_index].playlist.stop();
                            Players[cam_index].playlist.items.clear();
                            var uri = new Uri(PlayBackList.file_name[i]);
                            var convertedURI = uri.AbsoluteUri;
                            Players[cam_index].playlist.add(convertedURI);
                            Players[cam_index].playlist.play();

                            lblStatus.Text = "Playback: " + PlayBackList.cams[i] + "-" + PlayBackList.hours[i];
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].playlist.stop();
                Players[i].playlist.items.clear();
            }

            for (i = 0; i < PlayerThumbs.Count; i++)
            {
                PlayerThumbs[i].Visible = true;
            }

            selected_hour = dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();

            trackSlider.Value = 10 * e.ColumnIndex;

            for (i = 0; i < PlayBackList.cams.Count; i++)
            {
                if (PlayBackList.hours[i] == selected_hour)
                {
                    int cam_index = active_cams.IndexOf(PlayBackList.cams[i]);

                    if (cam_index != -1)
                    {
                        PlayerThumbs[cam_index].Visible = false;
                        Players[cam_index].playlist.stop();
                        Players[cam_index].playlist.items.clear();
                        var uri = new Uri(PlayBackList.file_name[i]);
                        var convertedURI = uri.AbsoluteUri;
                        Players[cam_index].playlist.add(convertedURI);
                        Players[cam_index].playlist.play();

                        lblStatus.Text = "Playback: " + PlayBackList.cams[i] + "-" + PlayBackList.hours[i];
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].playlist.pause();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].playlist.play();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.position -= 0.1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.position = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.position = 0.9;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (fast == 6)
                return;

            fast += 1;

            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.rate *= 2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fast == 1)
                return;

            fast -= 1;

            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.rate /= 2;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.time += 41;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 0; i < Players.Count; i++)
            {
                Players[i].input.time -= 41;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class PlayBackDetails
    { 
        public List<string> cams = new List<string>();
        public List<string> hours = new List<string>();
        public List<string> file_name = new List<string>();
    }

}

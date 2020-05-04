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

namespace iNVMSMain
{
    public partial class FrmBackup : Form
    {
        SaveFileDialog saveFileDialog;
        List<string> row_list = new List<string>();
        List<string> col_list = new List<string>(new string[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
        List<List<string>> file_paths = new List<List<string>>();

        public FrmBackup()
        {
            InitializeComponent();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Filter = "All Files(*.*)|*.*";

            for (int i = 0; i < 64; i++)
            {
                if (i < 9)
                    row_list.Add("0" + (i + 1).ToString());
                else
                    row_list.Add((i + 1).ToString());
            }

            List<string> track = new List<string>();
            for (int m = 0; m < 64; m++)
            {
                track.Clear();

                for (int n = 0; n < 24; n++)
                    track.Add("");

                file_paths.Add(track);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAutoPartition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoPartition.Checked)
            {
                rdbCDR.Enabled = true;
                rdbDVDR.Enabled = true;
            }
            else
            {
                rdbCDR.Enabled = false;
                rdbDVDR.Enabled = false;
            }
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnQuickBackup_Click(object sender, EventArgs e)
        {
            FrmBackupQuickBackup frmBackupQuickBackup = new FrmBackupQuickBackup();

            if (frmBackupQuickBackup.ShowDialog(this) == DialogResult.OK)
            {
                
            }
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 64; i++)
            {
                dataGridView1.Rows.Add(" ", " ");
                if (i < 9)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = "0" + (i + 1).ToString();
                }
                else
                {
                    dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Silver;

            monthCalendar1.SetDate(DateTime.Now);
            monthCalendar1.TodayDate = DateTime.Now;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Console.WriteLine("OOOOOOOOOOOOO");

            //Clear DataGridView
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }

            string crt_date = monthCalendar1.SelectionRange.Start.ToString();
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
                foreach (string value in paths)
                {
                    //Console.WriteLine(value);

                    string[] directories = Directory.GetDirectories(value);
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

                                //Console.WriteLine(cam_name);
                                //Console.WriteLine(record_hour);

                                int r_index = row_list.IndexOf(cam_name);
                                int c_index = col_list.IndexOf(record_hour);

                                //Console.WriteLine(row_list[0]);
                                //Console.WriteLine(row_list[1]);
                                //Console.WriteLine(row_list[2]);
                                //Console.WriteLine(r_index);
                                //Console.WriteLine(c_index);

                                file_paths[r_index][c_index] = file_value;

                                dataGridView1.Rows[r_index].Cells[c_index].Style.BackColor = Color.Blue;
                            }
                        }
                    }
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Blue)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                txtSelectedFiles.Text = (Convert.ToInt32(txtSelectedFiles.Text) + 1).ToString();

                long length = new System.IO.FileInfo(file_paths[e.RowIndex][e.ColumnIndex]).Length;
                textBox2.Text = (Convert.ToInt64(textBox2.Text) + length).ToString();

            } else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Blue;
                txtSelectedFiles.Text = (Convert.ToInt32(txtSelectedFiles.Text) - 1).ToString();

                long length = new System.IO.FileInfo(file_paths[e.RowIndex][e.ColumnIndex]).Length;
                textBox2.Text = (Convert.ToInt64(textBox2.Text) - length).ToString();
            }
        }

        private void btnBackupNow_Click(object sender, EventArgs e)
        {
            List<string> backfiles = new List<string>();

            for (int m = 0; m < 64; m++)
            {
                for (int n = 0; n < 24; n++)
                {
                    if (dataGridView1.Rows[m].Cells[n].Style.BackColor == Color.Red)
                    {
                        backfiles.Add(file_paths[m][n]);
                    }
                }
            }

            for (int i = 0; i < backfiles.Count; i++)
            {
                //Console.WriteLine(backfiles[i]);
                string[] tt = backfiles[i].Split('\\');

                string dest = txtBackupPath.Text + "\\" + tt[tt.Length - 1];

                //Console.WriteLine("+++++++++++++++++++++++++");
                //Console.WriteLine(backfiles[i]);
                //Console.WriteLine(dest);
                //Console.WriteLine("+++++++++++++++++++++++++");

                File.Copy(backfiles[i], dest, true);
            }
        }
    }
}

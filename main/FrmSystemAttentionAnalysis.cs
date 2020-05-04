using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iNVMSMain
{
    public partial class FrmSystemAttentionAnalysis : Form
    {

        public List<string> date_list = new List<string>();
        public List<List<int>> response_time_list = new List<List<int>>();

        public FrmSystemAttentionAnalysis()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\";
            //saveFileDialog.FilterIndex = 1;

            // set a default file name
            saveFileDialog.FileName = "new.csv";
            // set filters - this can be done in properties as well
            saveFileDialog.Filter = "Configure File (*.csv)|*.cfg|All files (*.*)|*.*";

            string config_string = "Date";

            for (int i = 0; i < 24; i++)
            {
                config_string += ("," + i.ToString());
            }

            config_string += "\n";

            for (int i = 0; i < date_list.Count; i++)
            {
                config_string += date_list[i];

                for (int j = 0; j < response_time_list[i].Count; j++)
                {
                    config_string += ("," + response_time_list[i][j].ToString());
                }

                config_string += "\n";
            }

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                File.WriteAllText(name, config_string);
            }
        }

        private void FrmSystemAttentionAnalysis_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 23;
            chart1.ChartAreas[0].AxisY.Maximum = 1000;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 100;
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Response Time(Sec)";

            string in_text = "";
            in_text = File.ReadAllText(@"Config/Attention");

            in_text = in_text.TrimEnd(',');

            string[] t1 = in_text.Split(',');
            for (int i = 0; i < t1.Length; i+= 25)
            {
                date_list.Add(t1[i]);

                List<int> t2 = new List<int>();
                for (int j = 1; j < 25; j++)
                {
                    t2.Add(Convert.ToInt32(t1[i + j]));
                }
                response_time_list.Add(t2);
            }

            string t3 = DateTimePicker1.Value.ToString();
            string[] t4 = t3.Split(' ');
            string crt_date = t4[0].Trim();

            int date_index = date_list.IndexOf(crt_date);

            if (date_index == -1)
            {
                return;
            }

            for (int i = 0; i < response_time_list[date_index].Count; i++)
            {
                chart1.Series["Series1"].Points.AddY(Convert.ToInt32(response_time_list[date_index][i]));
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTimePicker1.Value.ToString(), "A", MessageBoxButtons.OK);

            string t1 = DateTimePicker1.Value.ToString();
            string[] t2 = t1.Split(' ');
            string crt_date = t2[0].Trim();

            int date_index = date_list.IndexOf(crt_date);

            if (date_index == -1)
            {
                return;
            }

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < response_time_list[date_index].Count; i++)
            {
                chart1.Series["Series1"].Points.AddY(Convert.ToInt32(response_time_list[date_index][i]));
            }
            
            //MessageBox.Show(crt_date, "A", MessageBoxButtons.OK);
        }
    }
}

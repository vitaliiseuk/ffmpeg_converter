using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iNVMSMain
{
    public partial class FrmAttention : Form
    {
        public DateTime EndTime { get; set; }

        public FrmAttention()
        {
            InitializeComponent();
        }

        private void FrmAttention_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int attention_cam_number = rnd.Next(0, 65);

            txtPreferredNumber.Text = attention_cam_number.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int rlt;

            if (int.TryParse(txtUserNumber.Text, out rlt))
            {
                if (txtPreferredNumber.Text == txtUserNumber.Text)
                {
                    this.EndTime = DateTime.Now;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;

            Process.Start(path);
        }
    }
}

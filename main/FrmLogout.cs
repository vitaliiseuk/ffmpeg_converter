using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iNVMS.SDK;

namespace iNVMSMain
{
    public enum PowerCode { None, Close, Reboot, Minimize, Compact, Login, Guest, About}
    public partial class FrmLogout : Form
    {
        public delegate bool PowerCommandDelegate(PowerCode code);
        public PowerCommandDelegate PowerCommandDelegateProc;
        public PowerCode Code { get; set; }
        public FrmLogout()
        {
            InitializeComponent();
            if (iNVMSConfig.AccountConfig.LastUser != null)
            {
                txtUser.Text = iNVMSConfig.CurrentUser.ID;
                txtLevel.Text = iNVMSConfig.CurrentUser.Level_Plain;
            }
            
            btnCancel.DialogResult = DialogResult.Cancel;
            //btnLogin.DialogResult = DialogResult.Cancel;
            //btnGuest.DialogResult = DialogResult.Cancel;
            //btnAbout.DialogResult = DialogResult.Cancel;
            //btnMinimize.DialogResult = DialogResult.Cancel;
            btnCompact.DialogResult = DialogResult.OK;
            btnReboot.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!iNVMSConfig.CheckPermission(USER_PERMISSION.PowerOff))
                return;

            Code = PowerCode.Close;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);

            btnExit.DialogResult = DialogResult.OK;
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (!iNVMSConfig.CheckPermission(USER_PERMISSION.PowerOff))
                return;

            Code = PowerCode.Reboot;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Code = PowerCode.Login;
            if (PowerCommandDelegateProc != null)
                if (PowerCommandDelegateProc(Code))
                    DialogResult = DialogResult.OK;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Code = PowerCode.About;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            Code = PowerCode.Guest;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Code = PowerCode.None;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Code = PowerCode.Minimize;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);
        }

        private void btnCompact_Click(object sender, EventArgs e)
        {
            Code = PowerCode.Compact;
            if (PowerCommandDelegateProc != null)
                PowerCommandDelegateProc(Code);
        }
    }
}

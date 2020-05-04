using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iNVMS.SDK;
namespace iNVMSMain
{
    public partial class FrmUserSetting : Form
    {
        private List<UserInfo> m_lstUser = new List<UserInfo>();
        public FrmUserSetting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            if (iNVMSConfig.AccountConfig.UserList.Count == 0)
            {

            }
            else
            {
                foreach (UserInfo user in iNVMSConfig.AccountConfig.UserList)
                    m_lstUser.Add(user);

                ListRegisteredUsers();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUserSettingAdd frmUserAdd = new FrmUserSettingAdd();

            if (frmUserAdd.ShowDialog(this) == DialogResult.OK)
            {
                UserInfo newUserInfo = frmUserAdd.GetUesrInfo();

                bool bExist = false;
                foreach (UserInfo user in m_lstUser)
                {
                    if (user.ID.CompareTo(newUserInfo.ID) == 0)
                    {
                        bExist = true;
                        MessageBox.Show(user.ID + " already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (!bExist)
                    m_lstUser.Add(newUserInfo);

                ListRegisteredUsers();
            }
        }

        private void ListRegisteredUsers()
        {
            listUser.Items.Clear();
            foreach (UserInfo user in m_lstUser)
            {
                ListViewItem lvi = new ListViewItem(user.Level_Plain);
                lvi.SubItems.Add(user.ID);
                lvi.SubItems.Add(user.Description);

                listUser.Items.Add(lvi);
                lvi.Tag = user;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = listUser.SelectedItems[0];
            UserInfo userTag = (UserInfo)lvi.Tag;

            int nIndex = m_lstUser.IndexOf(userTag);
            FrmUserSettingAdd frmUserAdd = new FrmUserSettingAdd();
            frmUserAdd.SetUserInfo(userTag);
            if (frmUserAdd.ShowDialog() == DialogResult.OK)
            {
                userTag = frmUserAdd.GetUesrInfo();
                lvi.Tag = userTag;
                m_lstUser[nIndex] = userTag;

                ListRegisteredUsers();
            }
        }

        private void OnUserList_ItemSelChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool bEnable =  listUser.SelectedItems.Count > 0 ? true : false;
            btnEdit.Enabled = bEnable;
            btnDelete.Enabled = bEnable;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete selected user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (ListViewItem lvi in listUser.SelectedItems)
            {
                UserInfo userTag = (UserInfo)lvi.Tag;
                int nIndex = m_lstUser.IndexOf(userTag);
                if (nIndex > 0)
                    m_lstUser.RemoveAt(nIndex);
            }

            ListRegisteredUsers();
        }

        private void OnUserList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = listUser.SelectedItems[0];
            UserInfo userTag = (UserInfo)lvi.Tag;

            int nIndex = m_lstUser.IndexOf(userTag);
            FrmUserSettingAdd frmUserAdd = new FrmUserSettingAdd();
            frmUserAdd.SetUserInfo(userTag);
            if (frmUserAdd.ShowDialog() == DialogResult.OK)
            {
                userTag = frmUserAdd.GetUesrInfo();
                lvi.Tag = userTag;
                m_lstUser[nIndex] = userTag;

                ListRegisteredUsers();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            iNVMSConfig.AccountConfig.UserList.Clear();

            foreach (UserInfo user in m_lstUser)
                iNVMSConfig.AccountConfig.UserList.Add(user);

            AccountSettingsDef.SaveToFile(AccountSettingsDef.GetDefaultAccountConfigPath(), iNVMSConfig.AccountConfig);
        }
    }
}

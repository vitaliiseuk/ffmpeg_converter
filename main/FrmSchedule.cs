using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GridCtrl;
using iNVMS.SDK;
using System.IO;

namespace iNVMSMain
{
    public partial class FrmSchedule : Form
    {
        List<string> weekName = new List<string>(new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" });

        int[] table_data = new int[168];

        int i, j, k;

        SaveFileDialog saveFileDialog;
        public FrmSchedule()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\";

            

			picSchedule.SelectedValue = 0;
			rdbWeekly.Checked = true;

            calendarFrom.SetDate(DateTime.Now);
            calendarTo.SetDate(DateTime.Now.AddMonths(1));
            calendarFrom.TodayDate = DateTime.Now;
            calendarTo.TodayDate = DateTime.Now;

            
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            string rlt = "";
            for (i = 0; i < 168; i++)
            {
                rlt += table_data[i].ToString();
            }

            // Saving into configure file (*.cfg)
            // set a default file name
            saveFileDialog.FileName = "new.cfg";

            // set filters - this can be done in properties as well
            saveFileDialog.Filter = "Configure File (*.cfg)|*.cfg|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;

                txtBackupPath.Text = name;
                File.WriteAllText(name, rlt);
            }

            iNVMSConfig.ScheduleConfig.BackupPath = txtBackupPath.Text;
            ScheduleSettingDef.SaveToFile(ScheduleSettingDef.GetDefaultScheduleConfigPath(), iNVMSConfig.ScheduleConfig);
        }
        

        private void cmbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cmbSchedule.SelectedItem.ToString();

            if (str == "Record")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRecord.ss[i];
            else if (str == "Backup")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleBackup.ss[i];
            else if (str == "Enable Network")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleEnableNetwork.ss[i];
            else if (str == "Reboot")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleReboot.ss[i];
            else if (str == "Disable Alarm")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleDisableAlarm.ss[i];
            else if (str == "Turn on Relay1")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRelay1.ss[i];
            else if (str == "Turn on Relay2")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRelay2.ss[i];
            else if (str == "Turn on Relay3")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRelay3.ss[i];
            else if (str == "Turn on Relay4")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRelay4.ss[i];
            else if (str == "Turn on Relay5")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRelay5.ss[i];
            
            k = 0;
            for (i = 1; i < 8; i++)
                for (j = 1; j < 25; j++)
                {
                    //Console.WriteLine(k);
                    picSchedule.GetCell(i, j).currentColor = picSchedule.CellColors[table_data[k]];
                    k += 1;
                }
            
            Invalidate();
            picSchedule.Refresh();

            if (str == "Record")
            {

                labBackupPath.Visible = false;
                txtBackupPath.Visible = false;
                btnBackupPath.Visible = false;
                rdbMirrorBackup.Visible = false;
                rdbIncrementalBackup.Visible = false;
                chkDelOver.Visible = false;

                btnAll.Visible = true;

                chkUserLogin.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
            }
            else if ( str == "Backup" )
            {
                labBackupPath.Visible = true;
                txtBackupPath.Visible = true;
                btnBackupPath.Visible = true;
                rdbMirrorBackup.Visible = true;
                rdbIncrementalBackup.Visible = true;
                chkDelOver.Visible = true;
                
                btnAll.Visible = false;
                chkUserLogin.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
            }
            else if (str == "Enable Network")
            {
                
                labBackupPath.Visible = false;
                txtBackupPath.Visible = false;
                btnBackupPath.Visible = false;
                rdbMirrorBackup.Visible = false;
                rdbIncrementalBackup.Visible = false;
                chkDelOver.Visible = false;

                btnAll.Visible = true;

                chkUserLogin.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                
                MessageBox.Show("Do you want to save your change ?", "DVR Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else if (str == "Reboot")
            {
                labBackupPath.Visible = false;
                txtBackupPath.Visible = false;
                btnBackupPath.Visible = false;
                rdbMirrorBackup.Visible = false;
                rdbIncrementalBackup.Visible = false;
                chkDelOver.Visible = false;
                btnAll.Visible = false;

                chkUserLogin.Visible = true;
                labUserName.Visible = true;
                labPassword.Visible = true;
                txtUserName.Visible = true;
                txtPassword.Visible = true;
            }
            else  if (str == "Disable Alarm")
            {
                labBackupPath.Visible = false;
                txtBackupPath.Visible = false;
                btnBackupPath.Visible = false;
                rdbMirrorBackup.Visible = false;
                rdbIncrementalBackup.Visible = false;
                chkDelOver.Visible = false;

                btnAll.Visible = true;

                chkUserLogin.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                MessageBox.Show("Do you want to save your change ?", "DVR Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                labBackupPath.Visible = false;
                txtBackupPath.Visible = false;
                btnBackupPath.Visible = false;
                rdbMirrorBackup.Visible = false;
                rdbIncrementalBackup.Visible = false;
                chkDelOver.Visible = false;

                btnAll.Visible = true;

                chkUserLogin.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
            }
   
        }

        private void chkUserLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserLogin.Checked)
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

		private void picSchedule_OnCellSelect(Cell cell)
		{
            //Console.WriteLine(cell.row.cellList[0].Value);

            //Console.WriteLine(cell.row.cellList.IndexOf(cell));
            //Console.WriteLine(weekName.IndexOf(cell.row.cellList[0].Value.ToString()));

            int r, c, index;

            r = weekName.IndexOf(cell.row.cellList[0].Value.ToString());
            c = cell.row.cellList.IndexOf(cell) - 1;

            index = r * 24 + c;

            table_data[index] = picSchedule.SelectedValue;
        }

		private void OnScheduleControl_Load (object sender, EventArgs e)
		{
			const int nRows = 7;
			const int nCols = 24;
			const int nHeaderRows = 1;
			const int nHeaderCols = 1;

			const int nTotalRows = nRows + nHeaderRows;
			const int nTotalCols = nCols + nHeaderCols;

			const int nHeaderColRatio = 2;
			const int nHeaderRowRatio = 1;

			const int nWidthDiv = nCols + nHeaderCols * nHeaderColRatio;
			const int nHeightDiv = nRows + nHeaderRows * nHeaderRowRatio;

			picSchedule.LockUpdates = true;
			uint rowHeight = (uint)((picSchedule.Height - 4) / nHeightDiv + 0.5);
			uint colWidth = (uint)((picSchedule.Width - 8) / nWidthDiv + 0.5);

			for (int r = 0; r < nTotalRows; r++)
			{
				picSchedule.AddRow(rowHeight);
			}

			for (int c = 0; c < nTotalCols; c++)
			{
				if (c == 0)
					picSchedule.AddColumn(colWidth * nHeaderColRatio);
				else
					picSchedule.AddColumn(colWidth);
			}

			for (int r = 1; r < picSchedule.rowList.Count; r++)
			{
				picSchedule.GetCell(r, 0).Value = weekName[r - 1];
			}

			for (int c = 1; c < picSchedule.colList.Count; c++)
			{
				picSchedule.GetCell(0, c).Value = (c - 1).ToString("00");
			}

			picSchedule.SetFixedRowCount(nHeaderRows);
			picSchedule.SetFixedColumnCount(nHeaderCols);

			picSchedule.OnCellSelect += new GridCtrl.Grid.CellSelectDelegate(picSchedule_OnCellSelect);

			Invalidate();
		}

		private void rdbWeekly_CheckedChanged(object sender, EventArgs e)
		{
			picSchedule.SelectedValue = 0;
		}

		private void rdbOneTime_CheckedChanged(object sender, EventArgs e)
		{
			picSchedule.SelectedValue = 1;
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (i = 1; i < 8; i++)
                for (j = 1; j < 25; j++)
                {
                    //Console.WriteLine(k);
                    picSchedule.GetCell(i, j).currentColor = picSchedule.CellColors[2];                    
                }
            
            Invalidate();
            picSchedule.Refresh();

            for (i = 0; i < 168; i++)
            {
                table_data[i] = 2;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (i = 1; i < 8; i++)
                for (j = 1; j < 25; j++)
                {
                    //Console.WriteLine(k);
                    picSchedule.GetCell(i, j).currentColor = picSchedule.CellColors[picSchedule.SelectedValue];
                }

            Invalidate();
            picSchedule.Refresh();

            for (i = 0; i < 168; i++)
            {
                table_data[i] = picSchedule.SelectedValue;
            }
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            cmbSchedule.SelectedIndex = 0;
            if (cmbSchedule.SelectedItem.ToString() == "Record")
                for (i = 0; i < 168; i++)
                    table_data[i] = iNVMSConfig.ScheduleConfig.m_scheduleRecord.ss[i];

            txtBackupPath.Text = iNVMSConfig.ScheduleConfig.BackupPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSchedule.SelectedItem.ToString() == "Record")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRecord.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Backup")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleBackup.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Enable Network")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleEnableNetwork.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Reboot")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleReboot.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Disable Alarm")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleDisableAlarm.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Turn on Relay1")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRelay1.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Turn on Relay2")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRelay2.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Turn on Relay3")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRelay3.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Turn on Relay4")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRelay4.ss[i] = table_data[i];
            else if (cmbSchedule.SelectedItem.ToString() == "Turn on Relay5")
                for (i = 0; i < 168; i++)
                    iNVMSConfig.ScheduleConfig.m_scheduleRelay5.ss[i] = table_data[i];

            ScheduleSettingDef.SaveToFile(ScheduleSettingDef.GetDefaultScheduleConfigPath(), iNVMSConfig.ScheduleConfig);
        }
    }
}
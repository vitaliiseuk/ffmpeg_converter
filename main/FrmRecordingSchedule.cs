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
    public partial class FrmRecordingSchedule : Form
    {
		private int nSelectedValue = 1;
        public int CameraIndex { get; set; }
        public FrmRecordingSchedule()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
			radioWeekAlwaysRecord.Checked = true;
            CameraIndex = -1;
        }

		private void OnScheduleCtrl_Load(object sender, EventArgs e)
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

			gridWeekSchedule.CellColors = new Color[] { Color.White, Color.Blue, Color.Lime, Color.Magenta, Color.Yellow, Color.Cyan };
			gridWeekSchedule.LockUpdates = true;

			float rowHeight = (float)gridWeekSchedule.Height / (float)nHeightDiv;
			float colWidth = (float)gridWeekSchedule.Width / (float)nWidthDiv;


			for (int r = 0; r < nTotalRows; r++)
			{
				uint top = (uint)(rowHeight * r + 0.5f);
				uint height = (uint)(rowHeight * (r + 1) - top + 0.5f);
				gridWeekSchedule.AddRow(height);
			}

			for (int c = 0; c < nTotalCols; c++)
			{
				uint left = (uint)(colWidth * c + 0.5f);

				if (c < nHeaderCols)
				{
					uint width = (uint)(colWidth * (c + nHeaderColRatio) - left + 0.5f);
					gridWeekSchedule.AddColumn(width);
				}
				else
				{
					uint width = (uint)(colWidth * (c + 1) - left + 0.5f);
					gridWeekSchedule.AddColumn(width);
				}
			}

			gridWeekSchedule.SetFixedRowCount(nHeaderRows);
			gridWeekSchedule.SetFixedColumnCount(nHeaderCols);

			string[] weekName = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
			for (int r = gridWeekSchedule.GetFixedRowCount(); r < gridWeekSchedule.rowList.Count; r++)
			{
				gridWeekSchedule.GetCell(r, 0).Value = weekName[r - gridWeekSchedule.GetFixedRowCount()];
			}

            for (int c = gridWeekSchedule.GetFixedColumnCount(); c < gridWeekSchedule.colList.Count; c++)
			{
				gridWeekSchedule.GetCell(0, c).Value = (c - gridWeekSchedule.GetFixedColumnCount()).ToString("00");
			}	

            if (CameraIndex >= 0)
            {
                CameraObject camera = iNVMSConfig.DeviceAt(CameraIndex);

                if (camera != null)
                {
                    gridWeekSchedule.SetWeekSchedule(camera.RecordOption.RecordSchedule);
                }
            }
			Invalidate();
		}

		private void radioWeekAlwaysRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 1;
			gridWeekSchedule.SelectedValue = nSelectedValue;
		}

		private void radioWeekMotionRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 2;

			gridWeekSchedule.SelectedValue = nSelectedValue;
		}
		private void radioWeekSmartRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 3;

			gridWeekSchedule.SelectedValue = nSelectedValue;
		}
		private void radioWeekVoiceRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 4;

			gridWeekSchedule.SelectedValue = nSelectedValue;
		}

		private void radioWeekKeyFrameRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 5;

			gridWeekSchedule.SelectedValue = nSelectedValue;
		}

		private void radioWeekNoRecord_CheckedChanged(object sender, EventArgs e)
		{
			nSelectedValue = 0;

			gridWeekSchedule.SelectedValue = nSelectedValue;
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CameraIndex >= 0)
            {
                CameraObject camera = iNVMSConfig.DeviceAt(CameraIndex);
                camera.RecordOption.RecordSchedule = gridWeekSchedule.GetSchedule();
            }
        }

		public void SetSchedule(int[][] schedule)
		{
			gridWeekSchedule.SetWeekSchedule(schedule);
		}

		private void DayScheduleCtrl_Load(object sender, EventArgs e)
		{
			const int nRows = 1;
			const int nCols = 24;
			const int nHeaderRows = 1;
			const int nHeaderCols = 0;

			const int nTotalRows = nRows + nHeaderRows;
			const int nTotalCols = nCols + nHeaderCols;

			const int nHeaderColRatio = 2;
			const int nHeaderRowRatio = 1;

			const int nWidthDiv = nCols + nHeaderCols * nHeaderColRatio;
			const int nHeightDiv = nRows + nHeaderRows * nHeaderRowRatio;

			gridDaySchedule.CellColors = new Color[] { Color.White, Color.Blue, Color.Lime, Color.Magenta, Color.Yellow, Color.Cyan };
			gridDaySchedule.LockUpdates = true;

			float rowHeight = (float)gridDaySchedule.Height / (float)nHeightDiv;
			float colWidth = (float)gridDaySchedule.Width / (float)nWidthDiv;


			for (int r = 0; r < nTotalRows; r++)
			{
				uint top = (uint)(rowHeight * r + 0.5f);
				uint height = (uint)(rowHeight * (r + 1) - top + 0.5f);
				gridDaySchedule.AddRow(height);
			}

			for (int c = 0; c < nTotalCols; c++)
			{
				uint left = (uint)(colWidth * c + 0.5f);

				if (c < nHeaderCols)
				{
					uint width = (uint)(colWidth * (c + nHeaderColRatio) - left + 0.5f);
					gridDaySchedule.AddColumn(width);
				}
				else
				{
					uint width = (uint)(colWidth * (c + 1) - left + 0.5f);
					gridDaySchedule.AddColumn(width);
				}
			}

			gridDaySchedule.SetFixedRowCount(nHeaderRows);
			gridDaySchedule.SetFixedColumnCount(nHeaderCols);

			//string[] weekName = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
			//for (int r = gridWeekSchedule.GetFixedRowCount(); r < gridWeekSchedule.rowList.Count; r++)
			//{
			//	gridWeekSchedule.GetCell(r, 0).Value = weekName[r - gridWeekSchedule.GetFixedRowCount()];
			//}

			for (int c = gridDaySchedule.GetFixedColumnCount(); c < gridDaySchedule.colList.Count; c++)
			{
				gridDaySchedule.GetCell(0, c).Value = (c - gridDaySchedule.GetFixedColumnCount()).ToString("00");
			}

			if (CameraIndex >= 0)
			{
				CameraObject camera = iNVMSConfig.DeviceAt(CameraIndex);

				if (camera != null)
				{
					gridDaySchedule.SetWeekSchedule(camera.RecordOption.RecordSchedule);
				}
			}
			Invalidate();
		}

		private void radioDayAlwaysRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 1;
		}

		private void radioDayMotionRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 2;
		}

		private void radioDaySmartRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 3;
		}

		private void radioDayVoiceRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 4;
		}

		private void radioDayKeyFrameRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 5;
		}

		private void radioDayNoRecording_CheckedChanged(object sender, EventArgs e)
		{
			gridDaySchedule.SelectedValue = 0;
		}
    }
}

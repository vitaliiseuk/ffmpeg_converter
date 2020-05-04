using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iNVMSMain
{
	public partial class FrmInput : Form
	{
		private string m_strName;
		public String NewName
		{
			get
			{
				return m_strName;
			}
			set
			{
				m_strName = value;
				textBox1.Text = m_strName;
			}
		}
		public FrmInput()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			NewName = textBox1.Text;
		}
	}
}

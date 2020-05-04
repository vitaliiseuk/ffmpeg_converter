using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iNVMS.SDK;

namespace iNVMSMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static public iNVMSMain mainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//try
			{
                iNVMSConfig.LoadAllSettings();
                if (!iNVMSConfig.iNVMSLogin())
                {
                    Application.Exit();
                    return;
                }
				Application.Run(mainForm = new iNVMSMain());
			}
			//catch(Exception e)
			//{
			//	iNVMSConfig.DumpException(e);
			//}
        }
    }
}

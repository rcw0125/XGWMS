using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WeightApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Public.ShowFlash();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleApplication.Run(new frmLogin());
            
            if (frmMain.isRunMain == true)
            {
                Application.Run(new frmMain());
            }
        }
    }
}
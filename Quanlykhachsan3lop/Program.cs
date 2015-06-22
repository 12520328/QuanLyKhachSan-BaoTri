using DevExpress.XtraSplashScreen;
using Quanlykhachsan3lop.Màn_Hình;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Quanlykhachsan3lop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogIn fLogin = new frmLogIn();
            if(fLogin.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(typeof(SplashScreen1));
                Thread.Sleep(4000);
                SplashScreenManager.CloseForm();
                Application.Run(new frmMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}

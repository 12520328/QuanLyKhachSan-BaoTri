using DevExpress.XtraSplashScreen;
using Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong;
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
            //Application.Run(new frmLogIn());
            Application.Run(new frmLogIn());
        }
    }
}

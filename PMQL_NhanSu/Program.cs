using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_NhanSu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_UngTuyen());
            //Application.Run(new Menu());
            //Application.Run(new Frm_LuongCaNhan());

            Application.Run(new Form1());

            //Application.Run(new Menu());
            // Application.Run(new frm_UngTuyen());
        }
    }
}

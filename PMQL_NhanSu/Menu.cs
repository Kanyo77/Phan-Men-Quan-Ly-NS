using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_NhanSu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Menu menu_From = new Frm_Menu();
            menu_From.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_LuongCaNhan menu_From = new Frm_LuongCaNhan();
            menu_From.ShowDialog(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_TongBaoCao menu_From = new Frm_TongBaoCao();
            menu_From.ShowDialog(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_TaiKhoan menu_From = new Frm_TaiKhoan();
            menu_From.ShowDialog();
        }
    }
}

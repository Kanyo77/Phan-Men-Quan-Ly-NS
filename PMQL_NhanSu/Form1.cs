using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_NhanSu
{
    public partial class Form1 : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user, password;
            user = textBox1.Text;
            password = textBox2.Text;

            try
            {
                String querry = "SELECT * FROM public.\"DangNhap\" WHERE \"user\"='" + textBox1.Text + "' and password='" + textBox2.Text + "'";

                NpgsqlDataAdapter ada = new NpgsqlDataAdapter(querry,con);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    user = textBox1.Text;
                    password = textBox2.Text;

                    MessageBox.Show("Đăng Nhập thành công ");

                    this.Hide();

                    Menu menu_From = new Menu();
                    menu_From.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                    textBox2.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Không được để trống thông tin");
            }

        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frm_UngTuyen menu_From = new frm_UngTuyen();
            menu_From.ShowDialog();
        }
    }
}

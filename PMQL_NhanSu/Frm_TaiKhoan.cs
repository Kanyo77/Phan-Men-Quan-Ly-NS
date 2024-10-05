using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_NhanSu
{
    public partial class Frm_TaiKhoan : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;
        public Frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            string sqlINSET = "INSERT INTO public.\"DangNhap\" VALUES( @user,@password)";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();

                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            string sqlINSET = "UPDATE  public.\"DangNhap\" SET password=@password WHERE user=@user ";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }
        }
    }
}

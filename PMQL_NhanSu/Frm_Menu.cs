using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PMQL_NhanSu
{
    public partial class Frm_Menu : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void ketnoicsdl()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"TTUngVien\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void TimTen()
        {
            con.Open();
            string sql = "select * from public.\"TTUngVien\" where hoten like '%" + textBox1.Text + "%' ";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void GioiTinh()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"GioiTinh\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable table1 = new DataTable();
            da.Fill(table1);
            cbb_gioitinh.DataSource = table1;
            cbb_gioitinh.DisplayMember = "gioitinh";
            cbb_gioitinh.ValueMember = "gioitinh";
            con.Close();
        }
        private void Quoctich()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"QuocTich\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable table1 = new DataTable();
            da.Fill(table1);
            cbb_quoctich.DataSource = table1;
            cbb_quoctich.DisplayMember = "quoctich";
            cbb_quoctich.ValueMember = "quoctich";
            con.Close();
        }
        private void Dantoc()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"Dantoc\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable table1 = new DataTable();
            da.Fill(table1);
            cbb_dantoc.DataSource = table1;
            cbb_dantoc.DisplayMember = "dantoc";
            cbb_dantoc.ValueMember = "dantoc";
            con.Close();
        }
        private void Tongiao()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"TonGiao\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable table1 = new DataTable();
            da.Fill(table1);
            cbb_tongiao.DataSource = table1;
            cbb_tongiao.DisplayMember = "tongiao";
            cbb_tongiao.ValueMember = "TonGiao";
            con.Close();
        }
        private void PhongBan()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"PhongBan\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable table1 = new DataTable();
            da.Fill(table1);
            cbb_tinhtrangvieclam.DataSource = table1;
            cbb_tinhtrangvieclam.DisplayMember = "phongban";
            cbb_tinhtrangvieclam.ValueMember = "phongban";
            con.Close();
        }
        private void label23_Click_1(object sender, EventArgs e)
        {

        }


        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            ketnoicsdl();

            GioiTinh();
            Quoctich();
            Dantoc();
            Tongiao();
            PhongBan();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                dtp_ngaysinh.CustomFormat = "MMMM dd, yyyy - dddd";
                dateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd";

                string sqlINSET = "INSERT INTO public.\"TT_NhanVien\" VALUES( @manv, @hoten, @gioitinh, @ngaysinh, @cccd, @email, @sodt, @dantoc, @tongiao, @quoctich, @noisinh, @dcthuongchu, @dctamchu, @tthocvan, @ttchuyenmon, @hocham, @phongban, @luong, @ngaylamviec)";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
                cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cbb_gioitinh.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", NpgsqlTypes.NpgsqlDbType.Date, dtp_ngaysinh.Value.Date);
                cmd.Parameters.AddWithValue("@cccd", Int64.Parse(txt_cccd.Text));

                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@sodt", Int64.Parse(txt_sodienthoai.Text));
                cmd.Parameters.AddWithValue("@dantoc", cbb_dantoc.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@tongiao", cbb_tongiao.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@quoctich", cbb_quoctich.SelectedValue.ToString());

                cmd.Parameters.AddWithValue("@noisinh", txt_noisinh.Text);
                cmd.Parameters.AddWithValue("@dcthuongchu", txt_dctamtru.Text);
                cmd.Parameters.AddWithValue("@dctamchu", txt_diachithtr.Text);
                cmd.Parameters.AddWithValue("@tthocvan", txt_trinhdohv.Text);
                cmd.Parameters.AddWithValue("@ttchuyenmon", txt_trinhdochm.Text);

                cmd.Parameters.AddWithValue("@hocham", txt_hocham.Text);
                cmd.Parameters.AddWithValue("@phongban", cbb_tinhtrangvieclam.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@luong", Int64.Parse(txt_masothue.Text));

                cmd.Parameters.AddWithValue("@ngaylamviec", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker2.Value.Date);
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
            string sqlINSET = "UPDATE public.\"TT_NhanVien\" SET   hoten=@hoten, gioitinh=@gioitinh, ngaysinh=@ngaysinh, cccd=@cccd, email=@email, sodt=@sodt, dantoc=@dantoc, tongiao=@tongiao, quoctich=@quoctich, noisinh=@noisinh, dcthuongchu=@dcthuongchu, dctamchu=@dctamchu, tthocvan=@tthocvan, ttchuyenmon=@ttchuyenmon, hocham=@hocham, phongban=@phongban, luong=@luong, ngaylamviec=@ngaylamviec WHERE manv=@manv";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

            cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
            cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
            cmd.Parameters.AddWithValue("@gioitinh", cbb_gioitinh.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@ngaysinh", NpgsqlTypes.NpgsqlDbType.Date, dtp_ngaysinh.Value.Date);
            cmd.Parameters.AddWithValue("@cccd", Int64.Parse(txt_cccd.Text));

            cmd.Parameters.AddWithValue("@email", txt_email.Text);
            cmd.Parameters.AddWithValue("@sodt", Int64.Parse(txt_sodienthoai.Text));
            cmd.Parameters.AddWithValue("@dantoc", cbb_dantoc.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@tongiao", cbb_tongiao.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@quoctich", cbb_quoctich.SelectedValue.ToString());

            cmd.Parameters.AddWithValue("@noisinh", txt_noisinh.Text);
            cmd.Parameters.AddWithValue("@dcthuongchu", txt_dctamtru.Text);
            cmd.Parameters.AddWithValue("@dctamchu", txt_diachithtr.Text);
            cmd.Parameters.AddWithValue("@tthocvan", txt_trinhdohv.Text);
            cmd.Parameters.AddWithValue("@ttchuyenmon", txt_trinhdochm.Text);

            cmd.Parameters.AddWithValue("@hocham", txt_hocham.Text);
            cmd.Parameters.AddWithValue("@phongban", cbb_tinhtrangvieclam.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@luong", Int64.Parse(txt_masothue.Text));
            cmd.Parameters.AddWithValue("@ngaylamviec", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker2.Value.Date);


            cmd.ExecuteNonQuery();
            con.Close();

                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }

        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_manv.Text = dataGridView1.Rows[e.RowIndex].Cells["manv"].FormattedValue.ToString();
                txt_hoten.Text = dataGridView1.Rows[e.RowIndex].Cells["hoten"].FormattedValue.ToString();
                dtp_ngaysinh.Text = dataGridView1.Rows[e.RowIndex].Cells["ngaysinh"].FormattedValue.ToString();
                cbb_gioitinh.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["gioitinh"].FormattedValue.ToString();
                txt_cccd.Text = dataGridView1.Rows[e.RowIndex].Cells["cccd"].FormattedValue.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
                txt_sodienthoai.Text = dataGridView1.Rows[e.RowIndex].Cells["sodt"].FormattedValue.ToString();
                cbb_dantoc.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["dantoc"].FormattedValue.ToString();
                cbb_tongiao.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["tongiao"].FormattedValue.ToString();
                cbb_quoctich.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["quoctich"].FormattedValue.ToString();
               
                txt_noisinh.Text = dataGridView1.Rows[e.RowIndex].Cells["noisinh"].FormattedValue.ToString();
                txt_dctamtru.Text = dataGridView1.Rows[e.RowIndex].Cells["dcthuongchu"].FormattedValue.ToString();
                txt_diachithtr.Text = dataGridView1.Rows[e.RowIndex].Cells["dctamchu"].FormattedValue.ToString();
                txt_trinhdohv.Text = dataGridView1.Rows[e.RowIndex].Cells["tthocvan"].FormattedValue.ToString();
                txt_trinhdochm.Text = dataGridView1.Rows[e.RowIndex].Cells["ttchuyenmon"].FormattedValue.ToString();
                txt_hocham.Text = dataGridView1.Rows[e.RowIndex].Cells["hocham"].FormattedValue.ToString();
                cbb_tinhtrangvieclam.Text = dataGridView1.Rows[e.RowIndex].Cells["phongban"].FormattedValue.ToString();
                
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                dtp_ngaysinh.CustomFormat = "MMMM dd, yyyy - dddd";
                con.Open();
                string sqlINSET = "DELETE from public.\"TT_NhanVien\" where manv=@manv ";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
               
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            TimTen();

           
        }
    }
}

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
    public partial class frm_UngTuyen : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;

        public frm_UngTuyen()
        {
            InitializeComponent();
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

        private void frm_UngTuyen_Load(object sender, EventArgs e)
        {
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
                dtp_ngaysinh.CustomFormat = "MMMM dd, yyyy - dddd";
                con.Open();
                string sqlINSET = "INSERT INTO public.\"TTUngVien\" VALUES( @manv, @hoten, @gioitinh, @ngaysinh, @cccd, @email, @sodt, @dantoc, @tongiao, @quoctich, @noisinh, @dcthuongchu, @dctamchu, @tthocvan, @ttchuyenmon, @hocham, @phongban)";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
                cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cbb_gioitinh.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", NpgsqlTypes.NpgsqlDbType.Date, dtp_ngaysinh.Value.Date);
                // cmd.Parameters.AddWithValue("@cccd", Int64.Parse(txt_cccd.Text));
                
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
            /*
            string  input1 = dateTimePicker1.Text;
            string input2 = dateTimePicker2.Text;

            d1 as DateTime = DateTime.Parse(input1);
            d2 as DateTime = DateTime.Parse(input2);

            days as Single = (d1 - d2).ToTalDays;    
            */
            /*
            DateTime Star = dateTimePicker2.Value;
            DateTime End = dateTimePicker1.Value;

            int Days = Star.Day - End.Day;

            // int Luong = Days * 7000000;
            txt_cccd.Text = Days.ToString();
           // textBox1 = Days;
            */
            //MessageBox.Show(Luong.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            string sqlINSET = "UPDATE public.\"TTUngVien\" SET   hoten=@hoten, gioitinh=@gioitinh, ngaysinh=@ngaysinh, cccd=@cccd, email=@email, sodt=@sodt, dantoc=@dantoc, tongiao=@tongiao, quoctich=@quoctich, noisinh=@noisinh, dcthuongchu=@dcthuongchu, dctamchu=@dctamchu, tthocvan=@tthocvan, ttchuyenmon=@ttchuyenmon, hocham=@hocham, phongban=@phongban WHERE manv=@manv";
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

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
    public partial class Frm_LuongCaNhan : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;
        public Frm_LuongCaNhan()
        {
            InitializeComponent();
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
        
        private void ketnoicsdl()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"TT_NhanVien\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void ketnoicsdl2()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"BL_NhanVien\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView2.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_manv.Text = dataGridView1.Rows[e.RowIndex].Cells["manv"].FormattedValue.ToString();
                txt_hoten.Text = dataGridView1.Rows[e.RowIndex].Cells["hoten"].FormattedValue.ToString();
                cbb_tinhtrangvieclam.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["phongban"].FormattedValue.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
                txt_cccd.Text = dataGridView1.Rows[e.RowIndex].Cells["cccd"].FormattedValue.ToString();
                dateTimePicker1.Text =dataGridView1.Rows[e.RowIndex].Cells["ngaylamviec"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["luong"].FormattedValue.ToString();
                //textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[""].FormattedValue.ToString();
                //dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[""].FormattedValue.ToString();
            }
            }

            private void button1_Click(object sender, EventArgs e)
        {
            DateTime Star = dateTimePicker2.Value;
            DateTime End = dateTimePicker1.Value;

            int Days = Star.Day - End.Day;


            textBox2.Text = Days.ToString();
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void Frm_LuongCaNhan_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            ketnoicsdl2();
            PhongBan();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float Luongngay = (float.Parse(textBox1.Text) / 30);

            int LuongThang = (int)(Luongngay * (int.Parse(textBox2.Text)));
            //  int Tong = int.Parse(LuongThang);
            textBox3.Text= LuongThang.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            dateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd";

            con.Open();
            string sqlINSET = "INSERT INTO public.\"BL_NhanVien\" VALUES( @manv, @hoten, @phongban, @email, @cccd, @ngaylamviec, @Songaylam, @ngayltinhluong, @Luongtong )";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

            cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
            cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
            cmd.Parameters.AddWithValue("@phongban", cbb_tinhtrangvieclam.SelectedValue.ToString());  
            cmd.Parameters.AddWithValue("@email",txt_email.Text);

            cmd.Parameters.AddWithValue("@cccd", Int64.Parse(txt_cccd.Text));
            cmd.Parameters.AddWithValue("@ngaylamviec", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Songaylam", Int64.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@ngayltinhluong", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@Luongtong", Int64.Parse(textBox3.Text));
         
            cmd.ExecuteNonQuery();
            con.Close();

            dataGridView1.Refresh();

                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["manv"].FormattedValue.ToString();
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["hoten"].FormattedValue.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["phongban"].FormattedValue.ToString();
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
            textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["cccd"].FormattedValue.ToString();
            dateTimePicker4.Text = dataGridView2.Rows[e.RowIndex].Cells["ngaylamviec"].FormattedValue.ToString();
            
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["Songaylam"].FormattedValue.ToString();
            dateTimePicker3.Text = dataGridView2.Rows[e.RowIndex].Cells["ngayltinhluong"].FormattedValue.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["Luongtong"].FormattedValue.ToString();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string sendTo1 = textBox10.Text;
            string sendTo2 = textBox9.Text;
            string sendTo3 = textBox6.Text;
            string sendTo4 = dateTimePicker4.Text;
            string sendTo5 = textBox5.Text;
            string sendTo6 = textBox4.Text;
            string ngaylam = dateTimePicker3.Text;
    
            richTextBox1.SelectionFont = new Font("Lucinda Console", 8);
            richTextBox1.SelectedText = "Công Ty TNHH T-A.\n 168a Văn Thn P8 Q6.\n";
            richTextBox1.SelectedText = "  MNV:" + sendTo1 + " \n";

            richTextBox1.SelectedText = "BANG LUONG CA NHAN";
            richTextBox1.SelectionFont = new Font("Lucinda Console", 8);
            richTextBox1.SelectedText = "   Ngay:" + DateTime.Now + " \n";
            richTextBox1.SelectedText = "  Họ tên nhân viên:" + sendTo2 + " \n";
            richTextBox1.SelectedText = "  Phòng ban:" + sendTo3 + " \n";
            richTextBox1.SelectedText = "   Ngày vào làm:" + sendTo4 + " \n";
            richTextBox1.SelectedText = "   Ngày nhận lương:" + ngaylam + " \n";
            richTextBox1.SelectedText = "   Số ngày làm:" + sendTo5 + " \n";
            richTextBox1.SelectedText = "   Lương tổng:" + sendTo6 + " \n";

            richTextBox1.SelectedText = "   Kèm theo: Chứng từ gốc \n";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "Người lập phiếu - - - - - Người nhận tiền - - - - - Thử quỹ - - - - - Kế toán trưởng - - - - - Giám đốc\n";

            richTextBox1.Text += "(Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên)\n";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string sendTo1 = textBox17.Text;
            string sendTo2 = textBox16.Text;
            string sendTo3 = textBox13.Text;
            string sendTo4 = dateTimePicker6.Text;
            string sendTo5 = textBox12.Text;
            string sendTo6 = textBox11.Text;
            string ngaylam = dateTimePicker5.Text;

            richTextBox1.SelectionFont = new Font("Lucinda Console", 8);
            richTextBox1.SelectedText = "Công Ty TNHH T-A.\n 168a Văn Thn P8 Q6.\n";
            richTextBox1.SelectedText = "  MNV:" + sendTo1 + " \n";

            richTextBox1.SelectedText = "BANG LUONG CA NHAN";
            richTextBox1.SelectionFont = new Font("Lucinda Console", 8);
            richTextBox1.SelectedText = "   Ngay:" + DateTime.Now + " \n";
            richTextBox1.SelectedText = "  Họ tên nhân viên:" + sendTo2 + " \n";
            richTextBox1.SelectedText = "  Phòng ban:" + sendTo3 + " \n";
            richTextBox1.SelectedText = "   Ngày vào làm:" + sendTo4 + " \n";
            richTextBox1.SelectedText = "   Ngày nhận lương:" + ngaylam + " \n";
            richTextBox1.SelectedText = "   Số ngày làm:" + sendTo5 + " \n";
            richTextBox1.SelectedText = "   Lương tổng:" + sendTo6 + " \n";

            richTextBox1.SelectedText = "   Kèm theo: Chứng từ gốc \n";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "Người lập phiếu - - - - - Người nhận tiền - - - - - Thử quỹ - - - - - Kế toán trưởng - - - - - Giám đốc\n";

            richTextBox1.Text += "(Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên) - - (Kí ghi rõ họ tên)\n";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phòng It - Lương:9000000" +
                "\nPhòng Kinh tế - Lương:8500000\n" +
                "Phòng Marketin - Lương:8000000\n" +
                "Phòng Nhân sự - Lương:7000000\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
             try
            {
               

                con.Open();

              dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
              dateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd";

              string sqlINSET = "UPDATE public.\"BL_NhanVien\" SET hoten=@hoten, phongban=@phongban, email=@email, cccd=@cccd, ngaylamviec=@ngaylamviec, Songaylam=@Songaylam, ngayltinhluong=@ngayltinhluong, Luongtong=@Luongtong WHERE manv=@manv";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlINSET, con);

                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
                cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
                cmd.Parameters.AddWithValue("@phongban", cbb_tinhtrangvieclam.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@email", txt_email.Text);

                cmd.Parameters.AddWithValue("@cccd", Int64.Parse(txt_cccd.Text));
                cmd.Parameters.AddWithValue("@ngaylamviec", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Songaylam", Int64.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@ngayltinhluong", NpgsqlTypes.NpgsqlDbType.Date, dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@Luongtong", Int64.Parse(textBox3.Text));

                cmd.ExecuteNonQuery();
                con.Close();

                dataGridView1.Refresh();
            
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu");

            }
    
        }
    }
}

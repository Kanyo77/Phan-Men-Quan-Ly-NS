using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_NhanSu
{
    public partial class Frm_BaoCao : Form
    {
        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;Database=QL_NhanSu;User Id=postgres;Password=123456789");
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(strConnection);
        private static string strConnection;
        private void ketnoicsdl()
        {
            con.Open();
            string sql = " SELECT * FROM public.\"BL_NhanVien\" ";  // lay het du lieu trong bang sinh vien
            NpgsqlCommand com = new NpgsqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        public Frm_BaoCao()
        {
            InitializeComponent();
        }

        private void Frm_BaoCao_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // e.Graphics.DrawImage(bitmap, 0,0);
            //e.Graphics.DrawString(printPreviewDialog1.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,0, dataGridView1.Width , dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
            */
            //printPreviewDialog1.ShowDialog();


            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();



        }

        

        }
    }


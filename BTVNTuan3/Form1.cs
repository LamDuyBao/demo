
using System.Data.SqlClient;
using System.Data;

namespace BTVNTuan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadForm()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnstr);
            conn.Open();
            string sqlStr = string.Format("SELECT *FROM SinhVien");
           
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtSinhVien = new DataTable();
            adapter.Fill(dtSinhVien);
            gvSinhVien.DataSource = dtSinhVien;
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnstr);
                // Ket noi
                conn.Open();
                string sqlStr = string.Format("INSERT INTO SinhVien(HoTen , MSSV, QueQuan, NgaySinh, CMND, Email, DT) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                              txtHoTen.Text, txtMSSV.Text, txtQueQuan.Text, dtNgaySinh.Value.Date,
                                              txtCMND.Text, txtEmail.Text, txtSDT.Text);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("them thanh cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("them that bai" + ex);
            }
            LoadForm();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnstr);
                // Ket noi
                conn.Open();
                string sqlStr = string.Format("DELETE FROM SinhVien WHERE MSSV = '{0}';", txtMSSV.Text);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoa that bai" + ex);
            }
            LoadForm();
        }
    }
}
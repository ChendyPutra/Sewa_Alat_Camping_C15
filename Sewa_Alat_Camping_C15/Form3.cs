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

namespace Sewa_Alat_Camping_C15
{
    public partial class DataBarang : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;

        public DataBarang()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtIdBarang.Text.Trim() == "" || txtNama.Text.Trim() == "" || txtHarga.Text.Trim() == "" ||
                 txtStok.Text.Trim() == "" || txtKeterangan.Text.Trim() == "")
            {
                MessageBox.Show("Data Tidak Lengkap", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into dbo.alat_camping (no_alat, nama_alat, harga, stock, kondisi) values(@no_alat, @nama_alat, @harga, @stock, @kondisi)", conn);
                        cmd.Parameters.AddWithValue("@no_alat", txtIdBarang.Text);
                        cmd.Parameters.AddWithValue("@nama_alat", txtNama.Text);
                        cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                        cmd.Parameters.AddWithValue("@stock", txtStok.Text);
                        cmd.Parameters.AddWithValue("@kondisi", txtKeterangan.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insert Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ClearData();
                    ShowData();
                    
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
        void ShowData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.alat_camping", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvBarang.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed \n Error" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        void ClearData()
        {
            txtIdBarang.Text = "";
            txtNama.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
            txtKeterangan.Text = "";
        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.alat_camping where no_alat like @search or nama_alat like @search or merek like @search", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvBarang.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed \n Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataBarang_Load(object sender, EventArgs e)
        {
            ShowData();
            ClearData();
        }


        private void dgvBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvBarang.Rows[e.RowIndex];
                txtIdBarang.Text = row.Cells["no_alat"].Value.ToString();
                txtNama.Text = row.Cells["nama_alat"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
                txtStok.Text = row.Cells["stock"].Value.ToString();
                txtKeterangan.Text = row.Cells["kondisi"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            txtIdBarang.Text = "";
            txtNama.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
            txtKeterangan.Text = "";
            txtIdBarang.Enabled = true;
            txtNama.Enabled = true;
            txtHarga.Enabled = true;
            txtStok.Enabled = true;
            txtKeterangan.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtNama.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("delete from dbo.alat_camping where no_alat=@no_alat", conn);
                        cmd.Parameters.AddWithValue("@no_alat", txtIdBarang.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtIdBarang.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ShowData();
                    ClearData();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtIdBarang.Text.Trim() == "" || txtNama.Text.Trim() == "" || txtHarga.Text.Trim() == "" || txtStok.Text.Trim() == "" || txtKeterangan.Text.Trim() == "")
            {
                MessageBox.Show("Data Tidak Lengkap", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("update dbo.alat_camping set nama_alat=@nama_alat, harga=@harga, stock=@stock, kondisi=@kondisi where no_alat=@no_alat", conn);
                        cmd.Parameters.AddWithValue("@nama_alat", txtNama.Text);
                        cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                        cmd.Parameters.AddWithValue("@stock", txtStok.Text);
                        cmd.Parameters.AddWithValue("@kondisi", txtKeterangan.Text);
                        cmd.Parameters.AddWithValue("@no_alat", txtIdBarang.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ShowData();
                    ClearData();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClearData();
            ShowData();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtIdBarang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

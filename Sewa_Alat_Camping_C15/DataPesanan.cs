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
    public partial class DataPesanan : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;
        public DataPesanan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtidpesan.Text.Trim() == "" || txtidpemilik.Text.Trim() == "" || txtidcs.Text.Trim() == "" || txtidbarang.Text.Trim() == "" || txtidkurir.Text.Trim() == "" || txtjumalat.Text.Trim() == "" || txtdate.Text.Trim() == "")
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
                        cmd = new SqlCommand("insert into dbo.pesanan (id_pesanan, id_pemilik, NIK, no_alat, id_driver, tanggal_pesan, jumlah_alat) values(@id_pesanan, @id_pemilik, @NIK, @no_alat, @id_driver, @tanggal_pesan, jumlah_alat)", conn);
                        cmd.Parameters.AddWithValue("@id_pesanan", txtidpesan.Text);
                        cmd.Parameters.AddWithValue("@id_pemilik", txtidpemilik.Text);
                        cmd.Parameters.AddWithValue("@NIK", txtidcs.Text);
                        cmd.Parameters.AddWithValue("@no_alat", txtidbarang.Text);
                        cmd.Parameters.AddWithValue("@id_driver", txtidkurir.Text);
                        cmd.Parameters.AddWithValue("@tanggal_pesan", txtdate.Text);
                        cmd.Parameters.AddWithValue("@jumlah_alat", txtjumalat.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insert Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pesanan", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvPesanan.DataSource = data;
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
            txtidpesan.Text = "";
            txtidpemilik.Text = "";
            txtidcs.Text = "";
            txtidbarang.Text = "";
            txtidkurir.Text = "";
            txtdate.Text = "";
            txtjumalat.Text = "";

        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pesanan where id_pesanan like @search or NIK like @search or merek like @search", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvPesanan.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed \n Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvPesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvPesanan.Rows[e.RowIndex];
                txtidpesan.Text = row.Cells["id_pesanan"].Value.ToString();
                txtidpemilik.Text = row.Cells["id_pemilik"].Value.ToString();
                txtidcs.Text = row.Cells["NIK"].Value.ToString();
                txtidbarang.Text = row.Cells["no_alat"].Value.ToString();
                txtidkurir.Text = row.Cells["id_driver"].Value.ToString();
                txtdate.Text = row.Cells["tanggal_pesan"].Value.ToString();
                txtjumalat.Text = row.Cells["jumlah_alat"].Value.ToString();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtidbarang.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("delete from dbo.pesanan where id_pesanan=@id_pesanan", conn);
                        cmd.Parameters.AddWithValue("@id_pesanan", txtidpesan.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtidpesan.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtidpesan.Text.Trim() == "" || txtidpemilik.Text.Trim() == "" || txtidcs.Text.Trim() == "" || txtidbarang.Text.Trim() == "" || txtidkurir.Text.Trim() == "" || txtjumalat.Text.Trim() == "" || txtdate.Text.Trim() == "")            
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
                        cmd = new SqlCommand("update dbo.pesanan set id_pemilik=@id_pemilik, NIK=@NIK, no_alat=@no_alat, id_driver=@id_driver, tanggal_pesan=@tanggal_pesan, jumlah_alat=@jumlah_alat where id_pesanan=@id_pesanan", conn);
                        cmd.Parameters.AddWithValue("@id_pesanan", txtidpesan.Text);
                        cmd.Parameters.AddWithValue("@id_pemilik", txtidpemilik.Text);
                        cmd.Parameters.AddWithValue("@NIK", txtidcs.Text);
                        cmd.Parameters.AddWithValue("@no_alat", txtidbarang.Text);
                        cmd.Parameters.AddWithValue("@id_driver", txtidkurir.Text);
                        cmd.Parameters.AddWithValue("@tanggal_pesan", txtdate.Text);
                        cmd.Parameters.AddWithValue("@jumlah_alat", txtjumalat.Text);
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
    }
}

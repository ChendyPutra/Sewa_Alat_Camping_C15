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
    public partial class DataKurir : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;
        public DataKurir()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtidkurir.Text.Trim() == "" || txtnamakurir.Text.Trim() == "" || cbjeniskdr.Text.Trim() == "" ||
                txtpnk.Text.Trim() == "" )
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
                        cmd = new SqlCommand("insert into dbo.kurir (id_driver, nama_driver, jenis_kendaraan, plat_nomor) values(@id_driver, @nama_driver, @jenis_kendaraan, @plat_nomor)", conn);
                        cmd.Parameters.AddWithValue("@id_driver", txtidkurir.Text);
                        cmd.Parameters.AddWithValue("@nama_driver", txtnamakurir.Text);
                        cmd.Parameters.AddWithValue("@jenis_kendaraan", cbjeniskdr.Text);
                        cmd.Parameters.AddWithValue("@plat_nomor", txtpnk.Text);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtidkurir.Text.Trim() == "" || txtnamakurir.Text.Trim() == "" || cbjeniskdr.Text.Trim() == "" ||
                txtpnk.Text.Trim() == "")
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
                        cmd = new SqlCommand("update dbo.kurir set nama_driver=@nama_driver, jenis_kendaraan=@jenis_kendaraan, plat_nomor=@plat_nomor  where id_driver=@id_driver", conn);
                        cmd.Parameters.AddWithValue("@id_driver", txtidkurir.Text);
                        cmd.Parameters.AddWithValue("@nama_driver", txtnamakurir.Text);
                        cmd.Parameters.AddWithValue("@jenis_kendaraan", cbjeniskdr.Text);
                        cmd.Parameters.AddWithValue("@plat_nomor", txtpnk.Text);
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtnamakurir.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("delete from dbo.kurir where id_driver=@id_driver", conn);
                        cmd.Parameters.AddWithValue("@id_driver", txtidkurir.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtidkurir.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClearData();
            ShowData();
        }
        void ShowData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.kurir", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvKurir.DataSource = data;
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
            txtidkurir.Text = "";
            txtnamakurir.Text = "";
            cbjeniskdr.Text = "";
            txtpnk.Text = "";
        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.kurir where id_driver like @search or nama_driver like @search or merek like @search", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvKurir.DataSource = data;
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

        private void dgvKurir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvKurir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvKurir.Rows[e.RowIndex];
                txtidkurir.Text = row.Cells["id_driver"].Value.ToString();
                txtnamakurir.Text = row.Cells["nama_driver"].Value.ToString();
                cbjeniskdr.Text = row.Cells["jenis_kendaraan"].Value.ToString();
                txtpnk.Text = row.Cells["plat_nomor"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}

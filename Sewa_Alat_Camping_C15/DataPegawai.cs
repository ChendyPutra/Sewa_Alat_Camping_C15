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
    public partial class DataPegawai : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;
        public DataPegawai()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtIdPegawai.Text.Trim() == "" || txtnamaPegawai.Text.Trim() == "" || txtnohp.Text.Trim() == "" || txtalamat.Text.Trim() == "")
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
                        cmd = new SqlCommand("insert into dbo.pegawai (NIK, nama,no_telepon, alamat) values(@NIK, @nama, @no_telepon, @alamat)", conn);
                        cmd.Parameters.AddWithValue("@NIK", txtIdPegawai.Text);
                        cmd.Parameters.AddWithValue("@nama", txtnamaPegawai.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtIdPegawai.Text.Trim() == "" || txtnamaPegawai.Text.Trim() == "" || txtnohp.Text.Trim() == "" || txtalamat.Text.Trim() == "" )
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
                        cmd = new SqlCommand("update dbo.pegawai set NIK=@NIK, nama=@nama, no_telepon=@no_telepon, alamat=@alamat where NIK=@NIK", conn); 
                        cmd.Parameters.AddWithValue("@NIK", txtIdPegawai.Text);
                        cmd.Parameters.AddWithValue("@nama", txtnamaPegawai.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
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
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtnamaPegawai.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        string query = "DELETE FROM dbo.pegawai WHERE NIK = @NIK";
                        using (SqlCommand cmd = new SqlCommand(query, conn)) cmd.Parameters.Add("@NIK", txtIdPegawai.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtIdPegawai.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClearData();
            ShowData();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        void ShowData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pegawai", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvPegawai.DataSource = data;
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
            txtIdPegawai.Text = "";
            txtnamaPegawai.Text = "";
            txtnohp.Text = "";
            txtalamat.Text = "";
        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pegawai where NIK like @search or nama like @search or merek like @search", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvPegawai.DataSource = data;
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
        private void dgvPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvPegawai.Rows[e.RowIndex];
                txtIdPegawai.Text = row.Cells["NIK"].Value.ToString();
                txtnamaPegawai.Text = row.Cells["nama"].Value.ToString();
                txtnohp.Text = row.Cells["no_telepon"].Value.ToString();
                txtalamat.Text = row.Cells["alamat"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}

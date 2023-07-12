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
    public partial class Form7 : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;
        public Form7()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtidpemilik.Text.Trim() == "" || txtnamatoko.Text.Trim() == "" || txtemail.Text.Trim() == "" ||
                txtnohp.Text.Trim() == "" || txtalamat.Text.Trim() == "")
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
                        cmd = new SqlCommand("insert into dbo.pemilik (id_pemilik, nama_toko, alamat, no_telepon, email) values(@id_pemilik, @nama_toko, @alamat, @no_telepon, @email)", conn);
                        cmd.Parameters.AddWithValue("@id_pemilik", txtidpemilik.Text);
                        cmd.Parameters.AddWithValue("@nama_toko", txtnamatoko.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
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
            if (txtidpemilik.Text.Trim() == "" || txtnamatoko.Text.Trim() == "" || txtemail.Text.Trim() == "" ||
                txtnohp.Text.Trim() == "" || txtalamat.Text.Trim() == "")
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
                        cmd = new SqlCommand("update dbo.pemilik set nama_toko=@nama_toko, alamat=@alamat, no_telepon=@no_telepon, email=@email where id_pemilik=@id_pemilik", conn);
                        cmd.Parameters.AddWithValue("@id_pemilik", txtidpemilik.Text);
                        cmd.Parameters.AddWithValue("@nama_toko", txtnamatoko.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
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
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtnamatoko.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("delete from dbo.pemilik where id_pemilik=@id_pemilik", conn);
                        cmd.Parameters.AddWithValue("@id_pemilik", txtidpemilik.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtidpemilik.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pemilik", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvPemilik.DataSource = data;
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
            txtidpemilik.Text = "";
            txtnamatoko.Text = "";
            txtnohp.Text = "";
            txtalamat.Text = "";
            txtemail.Text = "";
        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.pemilik where id_pemilik like @search or nama_toko like @search or merek like @search", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvPemilik.DataSource = data;
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
        private void dgvPemilik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvPemilik.Rows[e.RowIndex];
                txtidpemilik.Text = row.Cells["id_pemilik"].Value.ToString();
                txtnamatoko.Text = row.Cells["nama_toko"].Value.ToString();
                txtnohp.Text = row.Cells["no_telepon"].Value.ToString();
                txtalamat.Text = row.Cells["alamat"].Value.ToString();
                txtemail.Text = row.Cells["email"].Value.ToString();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void txtidpemilik_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

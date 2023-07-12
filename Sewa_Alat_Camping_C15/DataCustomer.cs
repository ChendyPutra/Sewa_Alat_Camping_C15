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
    public partial class DataCustomer : Form
    {
        private string conn = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123";
        private SqlConnection koneksi;
        private SqlCommand cmd;
        public DataCustomer()
        {
            InitializeComponent();
            koneksi = new SqlConnection(conn);

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtidcs.Text.Trim() == "" || txtnamacs.Text.Trim() == "" || txtnohp.Text.Trim() == "" ||
               txtalamat.Text.Trim() == "" || txtusername.Text.Trim() == "" || txtpass.Text.Trim() == "")
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
                        cmd = new SqlCommand("insert into dbo.costumer (nik, nama, alamat, no_telepon, username, pass) values(@nik, @nama, @alamat, @no_telepon, @username, @pass)", conn);
                        cmd.Parameters.AddWithValue("@nik", txtidcs.Text);
                        cmd.Parameters.AddWithValue("@nama", txtnamacs.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);

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
            if (txtidcs.Text.Trim() == "" || txtnamacs.Text.Trim() == "" || txtnohp.Text.Trim() == "" ||
               txtalamat.Text.Trim() == "" || txtusername.Text.Trim() == "" || txtpass.Text.Trim() == "")
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
                        cmd = new SqlCommand("update dbo.costumer set nama=@nama, alamat=@alamat, no_telepon=@no_telepon, username=@username, pass=@pass where nik=@nik", conn);
                        cmd.Parameters.AddWithValue("@nik", txtidcs.Text);
                        cmd.Parameters.AddWithValue("@nama", txtnamacs.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtnohp.Text);
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);
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
                if (MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data " + txtnamacs.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                    {
                        conn.Open();
                        cmd = new SqlCommand("delete from dbo.costumer where nik=@nik", conn);
                        cmd.Parameters.AddWithValue("@nik", txtidcs.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Data " + txtidcs.Text + " Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.costumer", conn);
                    DataTable data = new DataTable();
                    Tampil.SelectCommand.ExecuteNonQuery();
                    Tampil.Fill(data);
                    dgvCustomer.DataSource = data;
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
            txtidcs.Text = "";
            txtnamacs.Text = "";
            txtnohp.Text = "";
            txtalamat.Text = "";
            txtusername.Text = "";
            txtpass.Text = "";

        }
        void Search()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=Final_Project_C15;User ID=sa; Password=123"))
                {
                    conn.Open();
                    SqlDataAdapter Tampil = new SqlDataAdapter("SELECT * FROM dbo.costumer where nik like @search or nama like @search ", conn);
                    Tampil.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable data = new DataTable();
                    Tampil.Fill(data);
                    dgvCustomer.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed \n Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvBarang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvCustomer.Rows[e.RowIndex];
                txtidcs.Text = row.Cells["nik"].Value.ToString();
                txtnamacs.Text = row.Cells["nama"].Value.ToString();
                txtnohp.Text = row.Cells["no_telepon"].Value.ToString();
                txtalamat.Text = row.Cells["alamat"].Value.ToString();
                txtusername.Text = row.Cells["username"].Value.ToString();
                txtpass.Text = row.Cells["pass"].Value.ToString();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}

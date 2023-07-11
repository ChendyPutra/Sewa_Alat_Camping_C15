using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sewa_Alat_Camping_C15
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            submenu1();
        }
        private void submenu1()
        {
            panelMaster.Visible = false;
        }
        private void hide()
        {
            if (panelMaster.Visible == true)
                panelMaster.Visible = false;
        }

        private void show(Panel sub)
        {
            if (sub.Visible == false)
            {
                hide();
                sub.Visible = true;
            }
            else
                sub.Visible = false;
        }

        private Form activeForm = null;
        private void tampilan(Form tampil)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = tampil;
            tampil.TopLevel = false;
            tampil.FormBorderStyle = FormBorderStyle.None;
            tampil.Dock = DockStyle.Fill;
            panelHsl.Controls.Add(tampil);
            panelHsl.Tag = tampil;
            tampil.BringToFront();
            tampil.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampilan(new DataBarang());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tampilan(new DataPesanan());

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHasil_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHsl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            show(panelMaster);
        }

        private void panelMaster_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

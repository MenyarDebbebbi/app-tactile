using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tactile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddProducts obj = new AddProducts();
            obj.Show();
            obj.TopMost = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AddSupliers obj = new AddSupliers();
            obj.Show();
            obj.TopMost = true;

        }

        private void label8_Click(object sender, EventArgs e)
        {
            AddCostumers obj = new AddCostumers();
            obj.Show();
            obj.TopMost = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

            ViewProducts obj = new ViewProducts();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewSulpiers obj = new ViewSulpiers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewCostumer obj = new ViewCostumer();
            obj.Show();
            obj.TopMost = true;
        }
    }
}

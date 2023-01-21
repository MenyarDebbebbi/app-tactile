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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            billings obj = new billings();
            obj.Show();
            this.Hide();
        }

        private void log_Click(object sender, EventArgs e)
        {
            if(name.Text==""|| pass.Text=="")
            {
                MessageBox.Show("Enter Your informations ");
            }
            else if(name.Text== "Admin"  || pass.Text=="Password ")
            {
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Worng use ");
            }
        }
    }
}

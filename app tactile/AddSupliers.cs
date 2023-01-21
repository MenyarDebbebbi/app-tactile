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

namespace app_tactile
{
    public partial class AddSupliers : Form
    {
        public AddSupliers()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void AddSupliers_Load(object sender, EventArgs e)
        {

        }
       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");
     private void Reset()
        {
            supname.Text = "";
            supadresse.Text = "";
            supphone.Text = "";
            rq.Text = "";
        }
            private void save_Click(object sender, EventArgs e)
        {

            if (supname.Text == "" || supadresse.Text == ""|| supphone.Text == "" ||rq.Text == "")
            {
                MessageBox.Show("messing information !");
                con.Close();
               Reset();

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into supliertbl (supname ,supadresse ,supphone, suprem)values(@sn,@sa,@sp,@r)", con);
                    cmd.Parameters.AddWithValue("@sn", supname.Text);
                    cmd.Parameters.AddWithValue("@sa", supadresse.Text);
                    cmd.Parameters.AddWithValue("@sp", supphone.Text);
                    cmd.Parameters.AddWithValue("r",rq.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("prodects saved !");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}

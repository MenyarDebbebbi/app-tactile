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
    public partial class AddCostumers : Form
    {
        public AddCostumers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");
        private void reset()
        {
           cosname.Text = "";
           cosadresse.Text = "";
            cosphone.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (cosname.Text == "" || cosadresse.Text == ""||cosphone.Text == "" )
            {
                MessageBox.Show("messing information !");
                con.Close();
                reset();

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into customertbl (cutname  ,cutadd, cutphone)values(@cn,@ca,@cu)", con);
                    cmd.Parameters.AddWithValue("@cn", cosname.Text);
                    cmd.Parameters.AddWithValue("@ca", cosadresse.Text);
                    cmd.Parameters.AddWithValue("@cu", cosphone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Costumer  saved !");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
    }

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace app_tactile
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");
        private void reset()
        {
            pname.Text = "";
            pqt.Text ="";
            pcat.SelectedIndex =-1;
            pprice.Text = "";
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (pname.Text == "" || pcat.SelectedIndex == -1 || pprice.Text == "" || pqt.Text == "")
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
                    SqlCommand cmd = new SqlCommand("Insert into producttbl (pname ,pcet ,pprix, pqty)values(@pn,@pc,@pp,@pq)",con);
                    cmd.Parameters.AddWithValue("@pn", pname.Text);
                    cmd.Parameters.AddWithValue("@pc", pcat.SelectedItem);
                    cmd.Parameters.AddWithValue("@pp",pprice.Text);
                    cmd.Parameters.AddWithValue("@pq", pqt.Text);
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

        private void pcat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}

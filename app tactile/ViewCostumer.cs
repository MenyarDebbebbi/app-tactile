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
    public partial class ViewCostumer : Form
    {
        public ViewCostumer()
        {
            InitializeComponent();
            displaycos();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");

        private void displaycos()
        {
            con.Open();
            string querry = "Select * from customertbl ";
            SqlDataAdapter sta = new SqlDataAdapter(querry, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sta);
            var ds = new DataSet();
            sta.Fill(ds);
            datacos.DataSource = ds.Tables[0];
            con.Close();
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        cosname.Text = datacos.SelectedRows[0].Cells[1].Value.ToString();
           cosadresse.Text = datacos.SelectedRows[0].Cells[2].Value.ToString();
           cosphone.Text = datacos.SelectedRows[0].Cells[3].Value.ToString();

            if (cosname.Text == "")
            {
                key = 0;
            }
            else { key = Convert.ToInt32(datacos.SelectedRows[0].Cells[0].Value.ToString()); }

        }

        private void ViewCostumer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cosname.Text == "" || cosadresse.Text == "" || cosphone.Text == "" ||key==0)
            {
                MessageBox.Show("messing information !!");
                con.Close();
                displaycos();
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update customertbl set cutname=@cn ,cutadd=@ca ,cutphone=@cu where cutId=@pkey", con);
                    cmd.Parameters.AddWithValue("@cn", cosname.Text);
                    cmd.Parameters.AddWithValue("@ca", cosadresse.Text);
                    cmd.Parameters.AddWithValue("cu", cosphone.Text);
                    cmd.Parameters.AddWithValue("@pkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("costumer updated!");
                    con.Close();
                    //Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("select the costumer!");
                con.Close();


            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  customertbl where cutId=@key", con);
                    cmd.Parameters.AddWithValue("key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("costumer deleted !");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            AddProducts obj = new AddProducts();
            obj.Show();
            obj.TopMost = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewProducts obj = new ViewProducts();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AddSupliers obj = new AddSupliers();
            obj.Show();
            obj.TopMost = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewSulpiers obj = new ViewSulpiers();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AddCostumers obj = new AddCostumers();
            obj.Show();
            obj.TopMost = true;
        }
    }
}
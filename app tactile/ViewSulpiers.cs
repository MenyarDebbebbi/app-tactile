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
    public partial class ViewSulpiers : Form
    {
        public ViewSulpiers()
        {
            InitializeComponent();
            displaysup();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewSulpiers obj = new ViewSulpiers();
            obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewSulpiers_Load(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //supname.Text =datasup.SelectedRows[0].Cells[1].Value.ToString();
           // supadresse.Text = datasup.SelectedRows[0].Cells[2].Value.ToString();
           // supphone.Text = datasup.SelectedRows[0].Cells[3].Value.ToString();
          //  supr.Text = datasup.SelectedRows[0].Cells[4].Value.ToString();

            if (supname.Text == "")
            {
                key = 0;
            }
            else { key = Convert.ToInt32(datasup.SelectedRows[0].Cells[0].Value.ToString()); }

        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");
        private void displaysup()
        {
            con.Open();
            string querry = "Select * from supliertbl ";
            SqlDataAdapter sta = new SqlDataAdapter(querry, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sta);
            var ds = new DataSet();
            sta.Fill(ds);
            datasup.DataSource = ds.Tables[0];
            con.Close();
        }
        private void reset()
        {

            supname.Text = "";
            supphone.Text = "";
            supadresse.Text = "";
            supr.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (supname.Text == "")
            {
                MessageBox.Show("messing information !");
                con.Close();
                displaysup();
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update supliertbl set supname=@sn ,supadresse=@sa ,supphone=@sp, suprem=@sr where supId=@pkey", con);
                    cmd.Parameters.AddWithValue("@sn", supname.Text);
                    cmd.Parameters.AddWithValue("@sa", supadresse.Text);
                    cmd.Parameters.AddWithValue("@sp", supphone.Text);
                    cmd.Parameters.AddWithValue("@sr", supr.Text);
                    cmd.Parameters.AddWithValue("@pkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("supliers updated!");
                    con.Close();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (key == 0)
            {
                MessageBox.Show("select the suplier!");
                con.Close();


            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  supliertbl where supId=@key", con);
                    cmd.Parameters.AddWithValue("key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("suplier deleted !");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void label8_Click(object sender, EventArgs e)
        {
            AddCostumers obj = new AddCostumers();
            obj.Show();
            obj.TopMost = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
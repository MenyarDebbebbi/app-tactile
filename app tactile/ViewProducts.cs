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
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
            displayprod();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
         
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

        private void label6_Click(object sender, EventArgs e)
        {
            ViewCostumer obj = new ViewCostumer();
            obj.Show();
            obj.TopMost = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
       
       int key = 0;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      //  pname.Text =dataproduct.SelectedRows[1].Cells[1].Value.ToString();
         //  pcat.SelectedItem = dataproduct.SelectedRows[0].Cells[2].Value.ToString();
          // pprice.Text = dataproduct.SelectedRows[0].Cells[3].Value.ToString();
          // pqt.Text = dataproduct.SelectedRows[0].Cells[4].Value.ToString();
            if (pname.Text == "")
            { 
                key = 0; 
            }
            else { key =Convert.ToInt32( dataproduct.SelectedRows[0].Cells[0].Value.ToString()); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pika;Integrated Security=True;Connect Timeout=30");
        private void displayprod()
        {
            con.Open();
            string querry = "Select * from producttbl ";
            SqlDataAdapter sta = new SqlDataAdapter(querry, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sta);
            var ds = new DataSet();
            sta.Fill(ds);
            dataproduct.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        { if (key== 0)
            {
                MessageBox.Show("select the product!");
                con.Close();
            }
            else
            { try
                {con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  producttbl where pid=@key",con );
                    cmd.Parameters.AddWithValue("pkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("product deleted !");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void reset()
        {

            pname.Text = "";
            pqt.Text = "";
            pcat.SelectedIndex = -1;
            pprice.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (pname.Text == "" || pcat.SelectedIndex == -1 || pprice.Text == "" || pqt.Text == "")
            {
                MessageBox.Show("messing information !");
                con.Close();
                displayprod();
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update producttbl set pname=@pn ,pcet=@pc ,pprix=@pp, pqty=@pq where pid=@pkey", con);
                    cmd.Parameters.AddWithValue("@pn", pname.Text);
                    cmd.Parameters.AddWithValue("@pc", pcat.SelectedItem);
                    cmd.Parameters.AddWithValue("@pp", pprice.Text);
                    cmd.Parameters.AddWithValue("@pq", pqt.Text);
                    cmd.Parameters.AddWithValue("@pkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("prodects updated!");
                    con.Close();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label5_Click(object sender, EventArgs e)
        {
            AddSupliers obj = new AddSupliers();
            obj.Show();
            obj.TopMost = true;
        }
    }
}

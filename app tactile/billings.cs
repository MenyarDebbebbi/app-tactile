using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tactile
{
    public partial class billings : Form
    {
        public billings()
        {
            InitializeComponent();
        }

        private void billings_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            login obj  = new login();
            obj.Show();
            this.Hide();
            
        }
        

        private void searchproducts()
        {
            con.Open();
            string querry = "Select * from producttbl where pname= "+"'" +search.Text +"'";
            SqlDataAdapter sta = new SqlDataAdapter(querry, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sta);
            var ds = new DataSet();
            sta.Fill(ds);
            dg.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            searchproducts();
            search.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            searchproducts();
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
            dg.DataSource = ds.Tables[0];
            con.Close();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            displayprod();
            search.Text = "";
        }
        string pname;
        int key = 1;
        int pprice, stock;
        int n = 0 , total=0;
        private void add_Click(object sender, EventArgs e)
        {
            if(key==0)
            { MessageBox.Show("Select A product Please");
            }
            else if (qty.Text=="")
            {
                MessageBox.Show("select Quantity");
            }
            else
            {
                int subtotal = Convert.ToInt32(qty.Text) *pprice;
                total = total + subtotal;

               DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(dgv);
                newrow.Cells[0].Value = num.Text;
                newrow.Cells[1].Value =pname;
                newrow.Cells[2].Value =qty.Text ;
                newrow.Cells[3].Value = pprice;
                newrow.Cells[4].Value = subtotal;
                dgv.Rows.Add(newrow);
                n++;
                sub.Text = "" + total;
               

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void vat_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        private void vat_KeyDown(object sender, KeyEventArgs e)
        { 
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vat_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double v = Convert.ToDouble(vat.Text) / 100 * (Convert.ToInt32(sub.Text));
                tax.Text = "" + v;
                grdtotal.Text =""+ Convert.ToInt32(sub.Text) + (Convert.ToDouble(tax.Text));
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sub_TextChanged(object sender, EventArgs e)
        {

        }

        string pame;
        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
               pame=(dgv.SelectedRows[0].Cells[1].Value.ToString());
               pprice= Convert.ToInt32(dg.SelectedRows[0].Cells[3].Value.ToString());
                stock =Convert.ToInt32(dg.SelectedRows[0].Cells[4].Value.ToString());

                if (cosname.Text == "")
                {
                    key = 0;
                }
                else { key = Convert.ToInt32(dg.SelectedRows[0].Cells[0].Value.ToString()); }

            }
        }
    }
}

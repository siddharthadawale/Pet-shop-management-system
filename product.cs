using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pet_junction
{
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
            displayproduct();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");



        private void displayproduct()
        {
            /*Con.Open();
            string query = " Select * from Employeetbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder =new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            // emplyeedgv.Da
            
            
           // emplyeedgv.DataSource = ds.Tables[0];

            Con.Close();*/

            Con.Open();
            string Query = "Select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            productDGV.DataSource = ds.Tables[0];


            Con.Close();
        }

        private void Clear()
        {
            ProdNametb.Text = "";
            ProdCategorycb.SelectedIndex = 0;
            ProdQuantitytb.Text = "";
            ProdPricetb.Text = "";
        }
        int Key = 0;

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            homes obj = new homes();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            employees obj = new employees();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            customer obj = new customer();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ProdNametb.Text == "" || ProdCategorycb.SelectedIndex == -1 || ProdQuantitytb.Text == "" || ProdPricetb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {

                if (!Regex.IsMatch(ProdNametb.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Product Name should contain only alphabets");
                    return;
                }

                // Validate phone textbox
                if (!Regex.IsMatch(ProdQuantitytb.Text, @"^\d+$"))
                {
                    MessageBox.Show("Quantity should contain only  digits");
                    return;
                }
                if (!Regex.IsMatch(ProdPricetb.Text, @"^\d+$"))
                {
                    MessageBox.Show("Price should contain only numbers");
                    return;
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into ProductTbl (PrName,PrCat,PrQty,PrPrice) values  (@PN, @PC,@PQ, @PP)", Con);
                        cmd.Parameters.AddWithValue("@PN", ProdNametb.Text);
                        cmd.Parameters.AddWithValue("@PC", ProdCategorycb.Text);
                        cmd.Parameters.AddWithValue("@PQ", ProdQuantitytb.Text);
                        cmd.Parameters.AddWithValue("@PP", ProdPricetb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product added !");

                        Con.Close();

                        displayproduct();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                
            }
        }

        private void productDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdNametb.Text = productDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdCategorycb.Text = productDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdQuantitytb.Text = productDGV.SelectedRows[0].Cells[3].Value.ToString();
            ProdPricetb.Text = productDGV.SelectedRows[0].Cells[4].Value.ToString();



            if (ProdNametb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(productDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (ProdNametb.Text == "" || ProdCategorycb.SelectedIndex == -1 || ProdQuantitytb.Text == "" || ProdPricetb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {

                if (!Regex.IsMatch(ProdNametb.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Product Name should contain only alphabets");
                    return;
                }

                // Validate phone textbox
                if (!Regex.IsMatch(ProdQuantitytb.Text, @"^\d+$"))
                {
                    MessageBox.Show("Quantity should contain only  digits");
                    return;
                }
                if (!Regex.IsMatch(ProdPricetb.Text, @"^\d+$"))
                {
                    MessageBox.Show("Price should contain only numbers");
                    return;
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("Update ProductTbl set PrName=@PN,PrCAt=@PC,PrQty=@PQ,PrPrice=@PP where PrId=@ProdKey", Con);
                        cmd.Parameters.AddWithValue("@PN", ProdNametb.Text);
                        cmd.Parameters.AddWithValue("@PC", ProdCategorycb.Text);
                        cmd.Parameters.AddWithValue("@PQ", ProdQuantitytb.Text);
                        cmd.Parameters.AddWithValue("@PP", ProdPricetb.Text);

                        cmd.Parameters.AddWithValue("@ProdKey", Key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product updated !");

                        Con.Close();

                        displayproduct();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an product !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where PrId= @ProdKey", Con);
                    cmd.Parameters.AddWithValue("@ProdKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted !");

                    Con.Close();

                    displayproduct();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProdNametb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

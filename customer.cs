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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            displaycustomer();
        }
        private void displaycustomer()
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
            string Query = "Select * from Customertbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            customerDGV.DataSource = ds.Tables[0];


            Con.Close();
        }

        private void Clear()
        {
            CustNametb.Text = "";
            CustAddtb.Text = "";
            CustPhonetb.Text = "";

        }
        int Key = 0;


        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            homes obj = new homes();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            product obj = new product();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            employees obj = new employees();
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

            if (CustNametb.Text == "" || CustAddtb.Text == "" || CustPhonetb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {
                if (!Regex.IsMatch(CustNametb.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Name should contain only alphabets");
                    return;
                }

                // Validate phone textbox
                if (!Regex.IsMatch(CustPhonetb.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Phone should contain only 10 digits");
                    return;
                }

                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Customertbl (CustName,CustAdd,CustPhone) values  (@CN, @CA, @CP)", Con);
                        cmd.Parameters.AddWithValue("@CN", CustNametb.Text);
                        cmd.Parameters.AddWithValue("@cA", CustAddtb.Text);
                        cmd.Parameters.AddWithValue("@CP", CustPhonetb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("customer added !");

                        Con.Close();

                        displaycustomer();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                
                
            }
        }

        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNametb.Text = customerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustAddtb.Text = customerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhonetb.Text = customerDGV.SelectedRows[0].Cells[3].Value.ToString();



            if (CustNametb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(customerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (CustNametb.Text == "" || CustAddtb.Text == "" || CustPhonetb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Customertbl set CustName=@CN,CustAdd=@CA,CustPhone=@CP where Custid=@CustKey", Con);
                    cmd.Parameters.AddWithValue("@CN", CustNametb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddtb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhonetb.Text);
                    cmd.Parameters.AddWithValue("@CustKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("customer Updated !");

                    Con.Close();

                    displaycustomer();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an employee !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Customertbl where Custid= @CustKey", Con);
                    cmd.Parameters.AddWithValue("@CustKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("customer deleted !");

                    Con.Close();

                    displaycustomer();
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
    }
}

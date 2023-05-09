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
using System.Xml.Linq;

namespace pet_junction
{
    public partial class employees : Form
    {
        public employees()
        {
            InitializeComponent();
            displayemployees();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");



        private void displayemployees()
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
            string Query = "Select * from Employeetbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            employeeDGV.DataSource = ds.Tables[0];


            Con.Close();
        }

        private void Clear()
        {
            empnametb.Text = "";
            empaddtb.Text = "";
            empphonetb.Text = "";
            emppasstb.Text = "";
        }
        int Key = 0;
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
            if (empnametb.Text == "" || empaddtb.Text == "" || empphonetb.Text == "" || emppasstb.Text == "" || empdobtb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {
                // Validate name textbox
                if (!Regex.IsMatch(empnametb.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Name should contain only alphabets");
                    return;
                }

                // Validate phone textbox
                if (!Regex.IsMatch(empphonetb.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Phone should contain only 10 digits");
                    return;
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into EmployeeTbl (EmpName,EmpAdd,EmpDOB,EmpPhone,EmpPass) values  (@EN, @EA,@ED, @EP, @EPa)", Con);
                        cmd.Parameters.AddWithValue("@EN", empnametb.Text);
                        cmd.Parameters.AddWithValue("@EA", empaddtb.Text);
                        cmd.Parameters.AddWithValue("@ED", empdobtb.Text);
                        cmd.Parameters.AddWithValue("@EP", empphonetb.Text);
                        cmd.Parameters.AddWithValue("@EPa", emppasstb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("employees added !");

                        Con.Close();

                        displayemployees();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
        }

        private void employeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            empnametb.Text = employeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            empaddtb.Text = employeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            empdobtb.Text = employeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            empphonetb.Text = employeeDGV.SelectedRows[0].Cells[4].Value.ToString();

            emppasstb.Text = employeeDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (empnametb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(employeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (empnametb.Text == "" || empaddtb.Text == "" || empphonetb.Text == "" || emppasstb.Text == "" || empdobtb.Text == "")
            {
                MessageBox.Show("Missing info !");
            }
            else
            {
                if (!Regex.IsMatch(empnametb.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Name should contain only alphabets");
                    return;
                }

                // Validate phone textbox
                if (!Regex.IsMatch(empphonetb.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Phone should contain only 10 digits");
                    return;
                }
                if (!Regex.IsMatch(emppasstb.Text, @"^(?=.*[^\w\s]).{6,}$"))
                {
                    MessageBox.Show("Password should contain at least one symbol and more than 5 letters");
                    return;
                }


                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("Update EmployeeTbl set EmpName=@EN,EmpAdd=@EA,EmpDOB=@ED,EmpPhone=@EP,EmpPass=@EPa where EmpNum=@EKey", Con);
                        cmd.Parameters.AddWithValue("@EN", empnametb.Text);
                        cmd.Parameters.AddWithValue("@EA", empaddtb.Text);
                        cmd.Parameters.AddWithValue("@ED", empdobtb.Text);
                        cmd.Parameters.AddWithValue("@EP", empphonetb.Text);
                        cmd.Parameters.AddWithValue("@EPa", emppasstb.Text);
                        cmd.Parameters.AddWithValue("@EKey", Key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("employees updated !");

                        Con.Close();

                        displayemployees();
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
                MessageBox.Show("Select an employee !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EmpNum= @EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("employees deleted !");

                    Con.Close();

                    displayemployees();
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

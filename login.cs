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

namespace pet_junction
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public string EmployeeName { get; set; }
        //SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");
        private void login1_Click(object sender, EventArgs e)
        {



            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Replace "YourConnectionString" with your actual database connection string
            string connectionString = "Data Source=LAPTOP-QJKJGLL1\\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeeTbl WHERE EmpName = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["EmpPass"].ToString();

                            if (password == storedPassword)
                            {
                                // Authentication successful
                                string employeeName = reader["EmpName"].ToString();

                                // Create an instance of the next form
                                homes obj = new homes();

                                // Set the EmployeeName property to the employee name that was entered in the login form
                                obj.EmployeeName = usernameTextBox.Text;

                                // Show the next form
                                obj.Show();

                                // Close the login form
                                this.Hide();

                                // Do something with the authenticated employee
                                // For example, show a main application form



                                // Close the login form
                                //this.Close();
                                //this.Hide();
                            }
                            else
                            {
                                // Authentication failed
                                MessageBox.Show("Invalid username or password.");

                            }
                        }
                        else
                        {
                            // Authentication failed
                            MessageBox.Show("Invalid username or password.");

                        }
                    }
                }
            }





















        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, this havent configured yet.!!");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class homes : Form
    {
        public string EmployeeName { get; set; }
        public homes()
        {
            InitializeComponent();
            countdog();
            countbird();
            countcat();
            countfood();
            finance();
            //countfood();
            //EmpNameLbl.Text = Employee;
            EmployeeNameLabel.Text = /*"Welcome, " +*/ EmployeeName; /* + "!";*/
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");

        private void countdog()
        {
            string animal = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat='" + animal + "'", Con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            DogLbl.Text = dataTable.Rows[0][0].ToString();
            Con.Close();
        }

        private void countcat()
        {
            string animal = "cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat='" + animal + "'", Con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            CatLbl.Text = dataTable.Rows[0][0].ToString();
            Con.Close();
        }

        private void countbird()
        {
            string animal = "bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat='" + animal + "'", Con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            BirdLbl.Text = dataTable.Rows[0][0].ToString();
            Con.Close();
        }
        private void finance()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(Amt) from BillTbl ", Con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            sales1.Text = dataTable.Rows[0][0].ToString();
            Con.Close();
        }

        private void countfood()
        {
            string itemtype = "food";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat='" + itemtype + "'", Con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foodlbl.Text = dataTable.Rows[0][0].ToString();
            Con.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            customer obj = new customer();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }
    }
}

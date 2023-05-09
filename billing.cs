using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pet_junction
{
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
            //EmpNameLbl.Text = login.Employee;
            GetCustomers();
            displayProduct();
            displaytransaction();


            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "ID";
            column.Name = "ID";


            billDGV.Columns.Add(column);

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "PrName";
            column1.Name = "PrName";
            billDGV.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Qty";
            column2.Name = "Qty";
            billDGV.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Price";
            column3.Name = "Price";
            billDGV.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Total";
            column4.Name = "Total";
            billDGV.Columns.Add(column4);


        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30");

        private void GetCustomers()
        {


            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Custid from Customertbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Custid", typeof(int));
            dt.Load(Rdr);
            BillCustidcb.ValueMember = "Custid";
            BillCustidcb.DataSource = dt;
            Con.Close();





        }

        private void displayProduct()
        {


            Con.Open();
            string Query = "Select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            billproductDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void displaytransaction()
        {


            Con.Open();
            string Query = "Select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            billtransactionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        public class Customer
        {
            public string Custid { get; set; }
        }

        private void GetCustName()
        {
            


            /* ####################   error solution try for drop down name satrsts here #################
            // Create a list of Customer objects to hold the Custid values
            List<Customer> customers = new List<Customer>();

            // Open the database connection
            using (SqlConnection con1 = new SqlConnection(@"Data Source=LAPTOP-QJKJGLL1\SQLEXPRESS;Initial Catalog=PetShopDb;Integrated Security=True;Connect Timeout=30"))
            {
                // Create a SqlCommand object to retrieve the Custid values from your Customertbl table
                using (SqlCommand cmd1 = new SqlCommand("SELECT Custid FROM Customertbl", con1))
                {
                    // Open the database connection

                    con1.Open();
                    // Execute the SQL command and retrieve the Custid values
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string custid = reader["Custid"].ToString();
                            Customer customer = new Customer() { Custid = custid };
                            customers.Add(customer);
                        }
                    }
                    
                }
                con1.Close();
            }
            

            // Finally, populate the ComboBox with the Custid values
            BillCustidcb.DisplayMember = "Custid";
            BillCustidcb.ValueMember = "Custid";
            BillCustidcb.DataSource = customers;

            // You can reselect the item by setting the SelectedValue property to the desired Custid value
            BillCustidcb.SelectedValue = "1";

            */



            Con.Open();
            string customerno = BillCustidcb.SelectedValue.ToString();
            string Query = " select * from Customertbl where Custid=' " + customerno + " '";

            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                BillCustnametb.Text = dr["CustName"].ToString();
            }
            Con.Close();

        }


        private void updatestock()
        {
            try
            {
                int newqty = Stock - Convert.ToInt32(BillProdqtytb.Text);
                Con.Open();

                SqlCommand cmd = new SqlCommand("Update ProductTbl set PrQty=@PQ where PrId=@PKey", Con);
                cmd.Parameters.AddWithValue("@PQ", newqty);
                cmd.Parameters.AddWithValue("@PKey", Key);

                cmd.ExecuteNonQuery();
                Con.Close();
                displayProduct();


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Message);

            }
        }



        int n = 0, GrdTotal = 0;
        int Key = 0, Stock = 0;


        /*private void Clear()
        {
            ProdNametb.Text = "";
            ProdCategorycb.SelectedIndex = 0;
            ProdQuantitytb.Text = "";
            ProdPricetb.Text = "";
        }*/


        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            customer obj = new customer();
            obj.Show();
            this.Hide();
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }




        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (BillProdqtytb.Text == "" || Convert.ToInt32(BillProdqtytb.Text) > Stock)
            {
                MessageBox.Show("no enough quantity in store");
            }
            else if (BillProdqtytb.Text == ""/* || Key == 0*/)
            {
                MessageBox.Show("missing info !!");
            }
            else
            {
                //DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();


                //billDGV.Columns.Add(column);

                //DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                //billDGV.Columns.Add(column1);
                // DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                //billDGV.Columns.Add(column2);
                //DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
                //billDGV.Columns.Add(column3);
                //DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
                //billDGV.Columns.Add(column4);

                int total = Convert.ToInt32(BillProdqtytb.Text) * Convert.ToInt32(BillProdpricetb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(billDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BillProdnametb.Text;
                newRow.Cells[2].Value = BillProdqtytb.Text;
                newRow.Cells[3].Value = BillProdpricetb.Text;
                newRow.Cells[4].Value = total;
                GrdTotal = GrdTotal + total;
                billDGV.Rows.Add(newRow);
                n++;
                TotalLbl.Text = "Rs" + GrdTotal;
                updatestock();
                Reset();



            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            homes obj = new homes();
            obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            employees obj = new employees();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            product obj = new product();
            obj.Show();
            this.Hide();

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void EmpNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BillCustidcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustName();
        }

        private void Reset()
        {
            BillProdnametb.Text = "";
            BillProdqtytb.Text = "";
            Stock = 0;
            Key = 0;
        }

        private void billproductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BillProdnametb.Text = billproductDGV.SelectedRows[0].Cells[1].Value.ToString();
            Stock = Convert.ToInt32(billproductDGV.SelectedRows[0].Cells[3].Value.ToString());
            BillProdpricetb.Text = billproductDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (BillCustnametb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(billproductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        private void InsertBill()
        {
            try
            {
                EmpNameLbl.Text = "Admin";
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into BillTbl (Bdate,Custid,CustName,EmpName,Amt) values  (@BD, @CI,@CN,@EN,@Am)", Con);
                cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@CI", BillCustidcb.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@CN", BillCustnametb.Text);
                cmd.Parameters.AddWithValue("@EN", EmpNameLbl.Text);
                cmd.Parameters.AddWithValue("@Am", GrdTotal);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill added !");
                GrdTotal = 0;

                Con.Close();

                displaytransaction();
                // Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string prodname;
        private void printbtn_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            InsertBill();

        }

        int prodid, prodqty, prodprice, tottal, pos = 60;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Pet Junction", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID Product    Price     Qty         Total", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));

            foreach (DataGridViewRow row in billDGV.Rows)
            {



                /*
                 DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "PrName";
            column1.Name = "PrName";
            billDGV.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Qty";
            column2.Name = "Qty";
            billDGV.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Price";
            column3.Name = "Price";
            billDGV.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Total";
            column4.Name = "Total";
            billDGV.Columns.Add(column4);*/
                prodid = Convert.ToInt32(row.Cells["ID"].Value);
                prodname = "" + row.Cells["PrName"].Value;
                prodprice = Convert.ToInt32(row.Cells["Qty"].Value);
                prodqty = Convert.ToInt32(row.Cells["Price"].Value);
                tottal = Convert.ToInt32(row.Cells["Total"].Value);

                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;

            }

            e.Graphics.DrawString("Grand Total : Rs" + GrdTotal, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("########## Pet Junction ########## ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            billDGV.Rows.Clear();
            billDGV.Refresh();
            pos = 100;

            n = 0;


        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

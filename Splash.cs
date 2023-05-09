using Bunifu.UI.WinForms.Helpers.Transitions;

namespace pet_junction
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();


            timer1.Start();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
        int startp = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*myprogress.Maximum = 100;
            startp += 1;
            if (startp <= myprogress.Maximum)
            {
                myprogress.Value = startp;
            }

            percentagelbl.Text = startp + "%";
            if (myprogress.Value == 100)
            {
                myprogress.Value = 0;
                login obj = new login();
                obj.Show();
                this.Hide();
                timer1.Stop();
            }*/
            if (myprogress.Value >= myprogress.Maximum) // Check if progress bar value is already at maximum
            {
                myprogress.Value = 0; // Reset progress bar
                login obj = new login();
                obj.Show();
                this.Hide();
                timer1.Stop();
            }
            else
            {

                startp += 1;
                myprogress.Maximum = 100;
                if (startp <= myprogress.Maximum)
                {
                    myprogress.Value = startp;
                }
                percentagelbl.Text = startp + "%";
            }
        }
    }
}
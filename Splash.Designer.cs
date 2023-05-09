namespace pet_junction
{
    partial class Splash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            pictureBox1 = new PictureBox();
            bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            myprogress = new Bunifu.UI.WinForms.BunifuProgressBar();
            percentagelbl = new Bunifu.UI.WinForms.BunifuLabel();
            bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 35;
            bunifuElipse2.TargetControl = this;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(623, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // bunifuLabel1
            // 
            bunifuLabel1.AllowParentOverrides = false;
            bunifuLabel1.AutoEllipsis = false;
            bunifuLabel1.CursorType = Cursors.Default;
            bunifuLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            bunifuLabel1.ForeColor = Color.FromArgb(128, 64, 0);
            bunifuLabel1.Location = new Point(138, 53);
            bunifuLabel1.Name = "bunifuLabel1";
            bunifuLabel1.RightToLeft = RightToLeft.No;
            bunifuLabel1.Size = new Size(461, 106);
            bunifuLabel1.TabIndex = 1;
            bunifuLabel1.Text = "Pet Junction";
            bunifuLabel1.TextAlignment = ContentAlignment.TopCenter;
            bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // myprogress
            // 
            myprogress.AllowAnimations = false;
            myprogress.Animation = 0;
            myprogress.AnimationSpeed = 220;
            myprogress.AnimationStep = 10;
            myprogress.BackColor = Color.FromArgb(223, 223, 223);
            myprogress.BackgroundImage = (Image)resources.GetObject("myprogress.BackgroundImage");
            myprogress.BorderColor = Color.FromArgb(223, 223, 223);
            myprogress.BorderRadius = 9;
            myprogress.BorderThickness = 1;
            myprogress.Location = new Point(141, 303);
            myprogress.Maximum = 100;
            myprogress.MaximumValue = 100;
            myprogress.Minimum = 0;
            myprogress.MinimumValue = 0;
            myprogress.Name = "myprogress";
            myprogress.Orientation = Orientation.Horizontal;
            myprogress.ProgressBackColor = Color.FromArgb(223, 223, 223);
            myprogress.ProgressColorLeft = Color.LightSkyBlue;
            myprogress.ProgressColorRight = Color.DodgerBlue;
            myprogress.Size = new Size(458, 29);
            myprogress.TabIndex = 2;
            myprogress.Value = 50;
            myprogress.ValueByTransition = 50;
            // 
            // percentagelbl
            // 
            percentagelbl.AllowParentOverrides = false;
            percentagelbl.AutoEllipsis = false;
            percentagelbl.CursorType = Cursors.Default;
            percentagelbl.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            percentagelbl.ForeColor = Color.RosyBrown;
            percentagelbl.Location = new Point(425, 266);
            percentagelbl.Name = "percentagelbl";
            percentagelbl.RightToLeft = RightToLeft.No;
            percentagelbl.Size = new Size(38, 31);
            percentagelbl.TabIndex = 3;
            percentagelbl.Text = "%%";
            percentagelbl.TextAlignment = ContentAlignment.TopCenter;
            percentagelbl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            bunifuLabel3.AllowParentOverrides = false;
            bunifuLabel3.AutoEllipsis = false;
            bunifuLabel3.CursorType = Cursors.Default;
            bunifuLabel3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            bunifuLabel3.ForeColor = Color.FromArgb(64, 64, 0);
            bunifuLabel3.Location = new Point(221, 266);
            bunifuLabel3.Name = "bunifuLabel3";
            bunifuLabel3.RightToLeft = RightToLeft.No;
            bunifuLabel3.Size = new Size(107, 31);
            bunifuLabel3.TabIndex = 4;
            bunifuLabel3.Text = "Loading....";
            bunifuLabel3.TextAlignment = ContentAlignment.TopCenter;
            bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            bunifuLabel3.Click += bunifuLabel3_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // bunifuLabel2
            // 
            bunifuLabel2.AllowParentOverrides = false;
            bunifuLabel2.AutoEllipsis = false;
            bunifuLabel2.CursorType = Cursors.Default;
            bunifuLabel2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            bunifuLabel2.ForeColor = SystemColors.ControlText;
            bunifuLabel2.Location = new Point(48, 425);
            bunifuLabel2.Name = "bunifuLabel2";
            bunifuLabel2.RightToLeft = RightToLeft.No;
            bunifuLabel2.Size = new Size(222, 31);
            bunifuLabel2.TabIndex = 5;
            bunifuLabel2.Text = "Design & developed :";
            bunifuLabel2.TextAlignment = ContentAlignment.TopCenter;
            bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel4
            // 
            bunifuLabel4.AllowParentOverrides = false;
            bunifuLabel4.AutoEllipsis = false;
            bunifuLabel4.CursorType = Cursors.Default;
            bunifuLabel4.Font = new Font("Javanese Text", 22.2F, FontStyle.Italic, GraphicsUnit.Point);
            bunifuLabel4.ForeColor = SystemColors.ControlText;
            bunifuLabel4.Location = new Point(276, 405);
            bunifuLabel4.Name = "bunifuLabel4";
            bunifuLabel4.RightToLeft = RightToLeft.No;
            bunifuLabel4.Size = new Size(368, 84);
            bunifuLabel4.TabIndex = 6;
            bunifuLabel4.Text = "Siddharth and Aalhad .  ";
            bunifuLabel4.TextAlignment = ContentAlignment.TopCenter;
            bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(738, 501);
            Controls.Add(bunifuLabel4);
            Controls.Add(bunifuLabel2);
            Controls.Add(bunifuLabel3);
            Controls.Add(percentagelbl);
            Controls.Add(myprogress);
            Controls.Add(bunifuLabel1);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Splash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Splash_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuLabel percentagelbl;
        private Bunifu.UI.WinForms.BunifuProgressBar myprogress;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
    }
}
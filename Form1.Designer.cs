namespace WinFormsApp1
{
    partial class Form1
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            fullname2_textBox1 = new TextBox();
            password2_textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = Properties.Resources.omborxona_root_01;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(12, 84);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(493, 425);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 26F, FontStyle.Bold);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(11, 10, 41);
            guna2HtmlLabel1.Location = new Point(818, 126);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(95, 43);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Login";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.Right;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Bold);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(11, 10, 41);
            guna2HtmlLabel2.Location = new Point(556, 252);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(59, 26);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "F.I.O";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.Anchor = AnchorStyles.Right;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Bold);
            guna2HtmlLabel3.ForeColor = Color.FromArgb(11, 10, 41);
            guna2HtmlLabel3.Location = new Point(504, 373);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(111, 26);
            guna2HtmlLabel3.TabIndex = 5;
            guna2HtmlLabel3.Text = "Password";
            // 
            // guna2GradientButton1
            // 
            guna2GradientButton1.Anchor = AnchorStyles.Right;
            guna2GradientButton1.AutoRoundedCorners = true;
            guna2GradientButton1.CustomizableEdges = customizableEdges3;
            guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2GradientButton1.FillColor = Color.FromArgb(0, 192, 192);
            guna2GradientButton1.FillColor2 = Color.Navy;
            guna2GradientButton1.Font = new Font("Arial Rounded MT Bold", 14F);
            guna2GradientButton1.ForeColor = Color.White;
            guna2GradientButton1.Location = new Point(818, 464);
            guna2GradientButton1.Name = "guna2GradientButton1";
            guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientButton1.Size = new Size(199, 45);
            guna2GradientButton1.TabIndex = 6;
            guna2GradientButton1.Text = "Kirish";
            guna2GradientButton1.Click += guna2GradientButton1_Click;
            // 
            // fullname2_textBox1
            // 
            fullname2_textBox1.Anchor = AnchorStyles.Right;
            fullname2_textBox1.Location = new Point(621, 252);
            fullname2_textBox1.Multiline = true;
            fullname2_textBox1.Name = "fullname2_textBox1";
            fullname2_textBox1.Size = new Size(396, 51);
            fullname2_textBox1.TabIndex = 7;
            fullname2_textBox1.TextChanged += fullname2_textBox1_TextChanged;
            // 
            // password2_textBox2
            // 
            password2_textBox2.Anchor = AnchorStyles.Right;
            password2_textBox2.Location = new Point(621, 365);
            password2_textBox2.Multiline = true;
            password2_textBox2.Name = "password2_textBox2";
            password2_textBox2.Size = new Size(396, 48);
            password2_textBox2.TabIndex = 8;
            password2_textBox2.TextChanged += password2_textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1050, 592);
            Controls.Add(password2_textBox2);
            Controls.Add(fullname2_textBox1);
            Controls.Add(guna2GradientButton1);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2PictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private TextBox fullname2_textBox1;
        private TextBox password2_textBox2;
    }
}

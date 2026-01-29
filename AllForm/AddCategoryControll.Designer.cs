namespace WinFormsApp1.AllForm
{
    partial class AddCategoryControll
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            save_guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            add_category_textBox1 = new TextBox();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial Rounded MT Bold", 24F);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(224, 224, 224);
            guna2HtmlLabel1.Location = new Point(260, 100);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(310, 39);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Kategoriya qo'shish";
            // 
            // save_guna2GradientButton1
            // 
            save_guna2GradientButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            save_guna2GradientButton1.BorderRadius = 12;
            save_guna2GradientButton1.CustomizableEdges = customizableEdges1;
            save_guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray;
            save_guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            save_guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            save_guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            save_guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            save_guna2GradientButton1.FillColor = Color.Blue;
            save_guna2GradientButton1.FillColor2 = Color.Green;
            save_guna2GradientButton1.Font = new Font("Arial Rounded MT Bold", 14F);
            save_guna2GradientButton1.ForeColor = Color.White;
            save_guna2GradientButton1.Location = new Point(549, 478);
            save_guna2GradientButton1.Name = "save_guna2GradientButton1";
            save_guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            save_guna2GradientButton1.Size = new Size(200, 45);
            save_guna2GradientButton1.TabIndex = 2;
            save_guna2GradientButton1.Text = "Saqlash";
            save_guna2GradientButton1.Click += save_guna2GradientButton1_Click;
            // 
            // guna2WinProgressIndicator1
            // 
            guna2WinProgressIndicator1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            guna2WinProgressIndicator1.AnimationSpeed = 72;
            guna2WinProgressIndicator1.AutoStart = true;
            guna2WinProgressIndicator1.Cursor = Cursors.No;
            guna2WinProgressIndicator1.Location = new Point(50, 46);
            guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            guna2WinProgressIndicator1.ProgressColor = Color.Cyan;
            guna2WinProgressIndicator1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2WinProgressIndicator1.Size = new Size(136, 138);
            guna2WinProgressIndicator1.TabIndex = 3;
            // 
            // add_category_textBox1
            // 
            add_category_textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            add_category_textBox1.Location = new Point(260, 261);
            add_category_textBox1.Multiline = true;
            add_category_textBox1.Name = "add_category_textBox1";
            add_category_textBox1.Size = new Size(489, 122);
            add_category_textBox1.TabIndex = 4;
            add_category_textBox1.TextChanged += add_category_textBox1_TextChanged;
            // 
            // AddCategoryControll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 43, 78);
            Controls.Add(add_category_textBox1);
            Controls.Add(guna2WinProgressIndicator1);
            Controls.Add(save_guna2GradientButton1);
            Controls.Add(guna2HtmlLabel1);
            Name = "AddCategoryControll";
            Size = new Size(872, 559);
            Load += AddCategoryControll_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton save_guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
        private TextBox add_category_textBox1;
    }
}

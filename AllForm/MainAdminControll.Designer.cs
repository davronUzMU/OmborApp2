namespace WinFormsApp1.AllForm
{
    partial class MainAdminControll
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2ComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            search_guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2ComboBox2
            // 
            guna2ComboBox2.AutoRoundedCorners = true;
            guna2ComboBox2.BackColor = Color.Transparent;
            guna2ComboBox2.Cursor = Cursors.Hand;
            guna2ComboBox2.CustomizableEdges = customizableEdges1;
            guna2ComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox2.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox2.Font = new Font("Segoe UI", 10F);
            guna2ComboBox2.ForeColor = Color.FromArgb(68, 88, 112);
            guna2ComboBox2.HoverState.BorderColor = Color.Blue;
            guna2ComboBox2.HoverState.FillColor = Color.FromArgb(0, 192, 0);
            guna2ComboBox2.HoverState.ForeColor = Color.White;
            guna2ComboBox2.ItemHeight = 30;
            guna2ComboBox2.Location = new Point(14, 18);
            guna2ComboBox2.Name = "guna2ComboBox2";
            guna2ComboBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox2.Size = new Size(225, 36);
            guna2ComboBox2.TabIndex = 4;
            guna2ComboBox2.SelectedIndexChanged += guna2ComboBox2_SelectedIndexChanged;
            // 
            // search_guna2TextBox1
            // 
            search_guna2TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            search_guna2TextBox1.AutoRoundedCorners = true;
            search_guna2TextBox1.CustomizableEdges = customizableEdges3;
            search_guna2TextBox1.DefaultText = "";
            search_guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            search_guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            search_guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            search_guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            search_guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            search_guna2TextBox1.Font = new Font("Segoe UI", 9F);
            search_guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            search_guna2TextBox1.IconLeft = Properties.Resources.mingcute__search_fill;
            search_guna2TextBox1.IconLeftSize = new Size(25, 25);
            search_guna2TextBox1.Location = new Point(521, 18);
            search_guna2TextBox1.Name = "search_guna2TextBox1";
            search_guna2TextBox1.PlaceholderText = "Qidiruv";
            search_guna2TextBox1.SelectedText = "";
            search_guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            search_guna2TextBox1.Size = new Size(308, 36);
            search_guna2TextBox1.TabIndex = 5;
            search_guna2TextBox1.TextChanged += search_guna2TextBox1_TextChanged;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2DataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Cursor = Cursors.SizeAll;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(14, 69);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.Size = new Size(815, 435);
            guna2DataGridView1.TabIndex = 6;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.FromArgb(224, 224, 224);
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 25;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // MainAdminControll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 43, 78);
            Controls.Add(guna2DataGridView1);
            Controls.Add(search_guna2TextBox1);
            Controls.Add(guna2ComboBox2);
            Name = "MainAdminControll";
            Size = new Size(853, 554);
            Load += MainAdminControll_Load;
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox2;
        private Guna.UI2.WinForms.Guna2TextBox search_guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Services;

namespace WinFormsApp1.AllForm
{
    public partial class AddCategoryControll : UserControl
    {
        private readonly CategoryService _categoryService;

        public AddCategoryControll(CategoryService categoryService)
        {
            _categoryService = categoryService;
            InitializeComponent();
        }

        private void add_category_textBox1_TextChanged(object sender, EventArgs e)
        {
            add_category_textBox1.Font = new Font("Consolas", 14, FontStyle.Regular);
            add_category_textBox1.ForeColor = Color.DarkBlue;
        }

        private void save_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(add_category_textBox1.Text))
            {
                MessageBox.Show("Kategoriya nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cc =add_category_textBox1.Text.Trim();
            _categoryService.AddCategory(cc);

            MessageBox.Show("Kategoriya muvaffaqiyatli qo'shildi!", "Muvaffaqiyatli", MessageBoxButtons.OK, MessageBoxIcon.Information);
            add_category_textBox1.Clear();
        }

        private void AddCategoryControll_Load(object sender, EventArgs e)
        {

        }
    }
}

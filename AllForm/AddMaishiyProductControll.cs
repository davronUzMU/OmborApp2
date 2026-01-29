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
    public partial class AddMaishiyProductControll : UserControl
    {
        private readonly CategoryService _categoryService;
        private readonly DepartmentService _departmentService;
        private readonly ProductEEService _productEEService;

        public AddMaishiyProductControll(ProductEEService productEEService, CategoryService categoryService, DepartmentService departmentService)
        {
            _productEEService = productEEService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            InitializeComponent();
        }
        //public AddMaishiyProductControll()
        //{
        //    InitializeComponent();
        //}

        private void AddMaishiyProductControll_Load(object sender, EventArgs e)
        {
            var categories = _categoryService.GetCategoryAll();
            category_guna2ComboBox2.DataSource = categories;
            category_guna2ComboBox2.DisplayMember = "CategoryName";
            category_guna2ComboBox2.ValueMember = "Id";

            // Department ComboBox Load
            var departments = _departmentService.GetDepartmentAll();
            department_guna2ComboBox1.DataSource = departments;
            department_guna2ComboBox1.DisplayMember = "DepartmentName";
            department_guna2ComboBox1.ValueMember = "Id";
        }

        private void department_guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void category_guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void total_guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void location_guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void information_guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(name_guna2TextBox1.Text))
                {
                    MessageBox.Show("Mahsulot nomini kiriting!");
                    return;
                }

                if (!int.TryParse(total_guna2TextBox4.Text, out int totalNumber))
                {
                    MessageBox.Show("Soni faqat raqam bo‘lishi kerak!");
                    return;
                }

                // Fix for CS8605: Unboxing a possibly null value.
                if (category_guna2ComboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Iltimos, kategoriya tanlang!");
                    return;
                }
                if (department_guna2ComboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Iltimos, bo'lim tanlang!");
                    return;
                }

                var newProductEE = new Models.ProductHousehold
                {
                    ProductName = name_guna2TextBox1.Text,
                    TotalNumber = totalNumber,
                    locationProduct = location_guna2TextBox2.Text,
                    ProductDescription = information_guna2TextBox3.Text,
                    CategoryId = (int)category_guna2ComboBox2.SelectedValue!,
                    DepartmentId = (int)department_guna2ComboBox1.SelectedValue!,
                    ManagerId = SessionData.ManagerId,
                    ProductType = "Xo'jalik  maqsulotlari"
                };

                _productEEService.AddProductEE(newProductEE);

                MessageBox.Show("Mahsulot muvaffaqiyatli qo‘shildi ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                name_guna2TextBox1.Clear();
                total_guna2TextBox4.Clear();
                location_guna2TextBox2.Clear();
                information_guna2TextBox3.Clear();
                category_guna2ComboBox2.SelectedIndex = 0;
                department_guna2ComboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class AddTexProductControll : UserControl
    {
        private readonly CategoryService _categoryService;
        private readonly DepartmentService _departmentService;
        private readonly ProductTexService _productTexService;

        public AddTexProductControll(ProductTexService productTexService, CategoryService categoryService, DepartmentService departmentService)
        {
            _productTexService = productTexService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            //information
        }

        private void AddTexProductControll_Load(object sender, EventArgs e)
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

        private void total_guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void location_guna2TextBox3_TextChanged(object sender, EventArgs e)
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

                if (!int.TryParse(total_guna2TextBox2.Text, out int totalNumber))
                {
                    MessageBox.Show("Soni faqat raqam bo‘lishi kerak!");
                    return;
                }

                // Fix for CS8605: Unboxing a possibly null value.
                if (category_guna2ComboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Kategoriya tanlanmagan!");
                    return;
                }
                if (department_guna2ComboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Bo'lim tanlanmagan!");
                    return;
                }

                var newProduct = new Models.ProductTexnologiya
                {
                    ProductName = name_guna2TextBox1.Text,
                    TotalNumber = totalNumber,
                    locationProduct = location_guna2TextBox3.Text,
                    ProductDescription = inf_guna2TextBox1.Text,
                    CategoryId = Convert.ToInt32(category_guna2ComboBox2.SelectedValue),
                    DepartmentId = Convert.ToInt32(department_guna2ComboBox1.SelectedValue),
                    ManagerId = SessionData.ManagerId
                };

                _productTexService.AddProductTex(newProduct);

                MessageBox.Show("Mahsulot muvaffaqiyatli qo‘shildi ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                name_guna2TextBox1.Clear();
                total_guna2TextBox2.Clear();
                location_guna2TextBox3.Clear();
                inf_guna2TextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inf_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

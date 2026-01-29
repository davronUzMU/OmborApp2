using Guna.UI2.WinForms;
using WinFormsApp1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1.AllForm
{
    public partial class SuperAdminForm : Form
    {
        AdminControllForm adminControllForm;
        ManagerControllForm managerControllForm;
        ProductControllForm productControllForm ;
        MainDeagramControll mainDeagramControll;


        private readonly SuperAdminService _superAdminService;
        private readonly AdminService _adminService;
        private readonly CategoryService _categoryService;
        private readonly DepartmentService _departmentService;
        private readonly ManagerService _managerService;
        private readonly ProductEEService _productEEService;
        private readonly ProductREService _productREService;
        private readonly ProductTexService _productTexService;

        private readonly ProductEEHistoryService _productEEHistoryService;
        private readonly ProductTexHistoryService _productTexHistoryService;
        private readonly ProductREHistoryService _productREHistoryService;

        public SuperAdminForm(SuperAdminService superAdminService, 
            AdminService adminService, 
            CategoryService categoryService, 
            DepartmentService departmentService, 
            ManagerService managerService, 
            ProductEEService productEEService, 
            ProductREService productREService, 
            ProductTexService productTexService,
            ProductEEHistoryService productEEHistory,
            ProductTexHistoryService productTexHistoryService,
            ProductREHistoryService productREHistory)
        {
            _superAdminService = superAdminService;
            _adminService = adminService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            _managerService = managerService;
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;

            adminControllForm = new AdminControllForm(this, _superAdminService, _adminService,
                           _categoryService, _departmentService, _managerService,
                           _productEEService, _productREService, _productTexService);
            managerControllForm = new ManagerControllForm(_managerService);
            productControllForm = new ProductControllForm(_productEEService,_productREService,_productTexService,_departmentService,_categoryService);
            mainDeagramControll = new MainDeagramControll();

            _productEEHistoryService = productEEHistory;
            _productTexHistoryService = productTexHistoryService;
            _productREHistoryService = productREHistory;

            InitializeComponent();
        }

        public void LoadUserControl(UserControl uc)
        {
            guna2GradientPanel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            guna2GradientPanel1.Controls.Add(uc);
        }


        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new Form1(
                _superAdminService, _adminService,
                _categoryService, _departmentService, _managerService,
                _productEEService, _productREService, _productTexService,
                _productEEHistoryService,_productTexHistoryService,_productREHistoryService);
            form1.Show();
        }
        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SuperAdminForm_Load(object sender, EventArgs e)
        {
            LoadUserControl(mainDeagramControll);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // shu yerdan boshqa userControllarlarni kirish mumkin

        }

        private void admin_guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(adminControllForm);
        }

        private void manager_guna2Button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(managerControllForm);
        }

        private void product_guna2Button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(productControllForm);
        }

        private void all_information_guna2GradientButton1_Click(object sender, EventArgs e)
        {
           LoadUserControl(mainDeagramControll);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            //  text label
        }
    }
}

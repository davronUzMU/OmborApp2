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
    public partial class AdminPanellForm : Form
    {
        MainAdminControll mainAdminControll;
        GenerationManagerKey generationManagerKey;
        AllManagerControll allManagerControll;
        AddDepartmentControll departmentControll;

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

        public AdminPanellForm(SuperAdminService superAdminService, 
            AdminService adminService, 
            CategoryService categoryService, 
            DepartmentService departmentService, 
            ManagerService managerService, 
            ProductEEService productEEService, 
            ProductREService productREService, 
            ProductTexService productTexService,
            ProductEEHistoryService productEEHistoryService,
            ProductTexHistoryService productTexHistoryService,
            ProductREHistoryService productREHistoryService)
        {
           
            _superAdminService = superAdminService;
            _adminService = adminService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            _managerService = managerService;
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;

            generationManagerKey = new GenerationManagerKey(_adminService);
            allManagerControll = new AllManagerControll(_managerService);
            departmentControll = new AddDepartmentControll(_departmentService);
            mainAdminControll = new MainAdminControll(_productEEService,_productREService,_productTexService);

            _productEEHistoryService = productEEHistoryService;
            _productTexHistoryService = productTexHistoryService;
            _productREHistoryService = productREHistoryService;

            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            guna2Panel3.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(uc);
        }

        private void AdminPanellForm_Load(object sender, EventArgs e)
        {
            LoadUserControl(mainAdminControll);
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void root_guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(mainAdminControll);
        }

        private void generate_manager_guna2Button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(generationManagerKey);
        }

        private void all_manager_guna2Button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(allManagerControll);
        }

        private void department_guna2Button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(departmentControll);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new Form1(
                _superAdminService,
                _adminService,
                _categoryService,
                _departmentService,
                _managerService,
                _productEEService,
                _productREService,
                _productTexService,
                _productEEHistoryService,
                _productTexHistoryService,
                _productREHistoryService
                );
            form1.ShowDialog();
        }
    }
}

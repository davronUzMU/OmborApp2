
using WinFormsApp1.AllForm;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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



        public Form1(SuperAdminService superAdminService, 
            AdminService adminService, 
            CategoryService categoryService, 
            DepartmentService departmentService, 
            ManagerService managerService, 
            ProductEEService productEEService,
            ProductREService productREService,
            ProductTexService productTexService,
            ProductEEHistoryService productEEHistoryService,
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
            _productEEHistoryService = productEEHistoryService;
            _productTexHistoryService = productTexHistoryService;
            _productREHistoryService = productREHistory;
            InitializeComponent();
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // picture box
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string fullname = fullname2_textBox1.Text.Trim();
            string code = password2_textBox2.Text.Trim();

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Iltimos, ism va kodni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1?? SuperAdmin tekshirish
            bool isSuperAdmin = _superAdminService.Login(fullname, code);
            if (isSuperAdmin)
            {
                MessageBox.Show("Super Admin sifatida tizimga kirdingiz!", "Muvaffaqiyatli", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFormSafely(new SuperAdminForm(
                    _superAdminService, _adminService,
                    _categoryService, _departmentService, _managerService,
                    _productEEService, _productREService, _productTexService,_productEEHistoryService,_productTexHistoryService,_productREHistoryService));
                return;
            }

            // 2?? Admin sifatida kirish
            var admin = _adminService.LoginWithCode(fullname, code);
            if (admin != null)
            {
                MessageBox.Show($"Admin sifatida tizimga kirdingiz! {admin.District}", "Xush kelibsiz", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFormSafely(new AdminPanellForm(
                     _superAdminService, _adminService,
                    _categoryService, _departmentService, _managerService,
                    _productEEService, _productREService, _productTexService,_productEEHistoryService,_productTexHistoryService,_productREHistoryService));
                return;
            }

            // 3?? Manager sifatida kirish
            var manager = _managerService.Login(fullname, code);
            if (manager != null)
            {
                MessageBox.Show("Manager sifatida tizimga kirdingiz!", "Xush kelibsiz", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SessionData.ManagerId = manager.Id;

                OpenFormSafely(new ManagerPanelForm(
                     _superAdminService, _adminService,
                    _categoryService, _departmentService, _managerService,
                    _productEEService, _productREService, _productTexService,_productEEHistoryService,_productTexHistoryService,_productREHistoryService
                    ));
                return;
            }

            // 4?? Hech biri to‘g‘ri bo‘lmasa
            MessageBox.Show("Login ma'lumotlari noto‘g‘ri! Iltimos, qayta urinib ko‘ring.", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void OpenFormSafely(Form panelForm)
        {
            this.Hide();

            // Agar forma yopilsa => Form1 yana ko‘rinadi
            panelForm.FormClosed += (s, args) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };

            // Agar Form1 maksimal bo‘lsa, panel ham shunday bo‘ladi
            if (this.WindowState == FormWindowState.Maximized)
                panelForm.WindowState = FormWindowState.Maximized;
            else
                panelForm.StartPosition = FormStartPosition.CenterScreen;

            panelForm.ShowDialog();
        }

        private void fullname2_textBox1_TextChanged(object sender, EventArgs e)
        {
            fullname2_textBox1.Font = new Font("Consolas", 14, FontStyle.Regular);
            fullname2_textBox1.ForeColor = Color.DarkGreen;
        }

        private void password2_textBox2_TextChanged(object sender, EventArgs e)
        {
            password2_textBox2.Font = new Font("Consolas", 14, FontStyle.Regular);
            password2_textBox2.ForeColor = Color.DarkGreen;
        }
    }
}

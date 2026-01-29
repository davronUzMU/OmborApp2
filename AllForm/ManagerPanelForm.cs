using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.AI_service;
using WinFormsApp1.Services;

namespace WinFormsApp1.AllForm
{
    public partial class ManagerPanelForm : Form
    {
        MainManagerControll mainManagerControl;
        AddCategoryControll addCategoryControl;
        AddTexProductControll addTexProductControl;
        AddKochmasMulkControll addKochmasMulkControl;
        AddMaishiyProductControll addMaishiyProductControl;

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

        public ManagerPanelForm(SuperAdminService superAdminService, 
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

            _productEEHistoryService = productEEHistoryService;
            _productTexHistoryService = productTexHistoryService;
            _productREHistoryService = productREHistoryService;

            addCategoryControl = new AddCategoryControll(_categoryService);
            addTexProductControl = new AddTexProductControll(_productTexService, _categoryService, _departmentService);
            addKochmasMulkControl = new AddKochmasMulkControll(_productREService, _categoryService, _departmentService);
            addMaishiyProductControl = new AddMaishiyProductControll(_productEEService, _categoryService, _departmentService);
            mainManagerControl = new MainManagerControll(
                _productEEService,
                _productREService,
                _productTexService,
                _categoryService,      // 4th argument: CategoryService
                _departmentService,    // 5th argument: DepartmentService

                _productEEHistoryService,
                _productTexHistoryService,
                _productREHistoryService


);
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            guna2Panel4.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            guna2Panel4.Controls.Add(uc);
        }

        private void admin_root_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LoadUserControl(mainManagerControl);
        }

        private void category_guna2Button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(addCategoryControl);
        }

        private void tex_product_guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(addTexProductControl);
        }

        private void k_m_guna2Button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(addKochmasMulkControl);
        }

        private void m_m_guna2Button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(addMaishiyProductControl);
        }

        private void ManagerPanelForm_Load(object sender, EventArgs e)
        {
            LoadUserControl(mainManagerControl);
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
            //   shu yerdan boshqa userControllarlarni kirish mumkin
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
                _productREHistoryService);
            form1.ShowDialog();

        }

        //private async Task ShowAIDialog()
        //{
        //    using (Form form = new Form())
        //    {
        //        form.Text = "AI Chat";
        //        form.StartPosition = FormStartPosition.CenterParent;
        //        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        //        form.ClientSize = new Size(450, 350);
        //        form.MaximizeBox = false;
        //        form.MinimizeBox = false;

        //        int y = 10;

        //        // Chat tarix textbox
        //        TextBox txtChatHistory = new TextBox
        //        {
        //            Location = new Point(10, y),
        //            Size = new Size(420, 220),
        //            Multiline = true,
        //            ReadOnly = true,
        //            ScrollBars = ScrollBars.Vertical
        //        };
        //        form.Controls.Add(txtChatHistory);

        //        y += 230;

        //        // User input textbox
        //        TextBox txtUserMessage = new TextBox
        //        {
        //            Location = new Point(10, y),
        //            Size = new Size(320, 25)
        //        };
        //        form.Controls.Add(txtUserMessage);

        //        // Send button
        //        Button btnSend = new Button
        //        {
        //            Text = "Yuborish",
        //            Location = new Point(340, y),
        //            Size = new Size(90, 25),
        //            BackColor = Color.FromArgb(46, 51, 73),
        //            ForeColor = Color.White,
        //            FlatStyle = FlatStyle.Flat
        //        };
        //        form.Controls.Add(btnSend);

        //        // ChatAIService tayyorlash
       

        //        var chatService = new ChatAIService(config, _productTexService, _productEEService, _productREService);

        //        string? aiResponse = await chatService.AskAsync("Salom");
        //        Console.WriteLine(aiResponse);

        //        btnSend.Click += async (s, ev) =>
        //        {
        //            string userMessage = txtUserMessage.Text.Trim();
        //            if (string.IsNullOrEmpty(userMessage)) return;

        //            txtChatHistory.AppendText($"Siz: {userMessage}\r\n");
        //            txtUserMessage.Clear();
        //            btnSend.Enabled = false;

        //            try
        //            {
        //                string? aiResponse = await chatService.AskAsync(userMessage);
        //                txtChatHistory.AppendText($"AI: {aiResponse}\r\n\r\n");
        //            }
        //            catch (Exception ex)
        //            {
        //                txtChatHistory.AppendText($"Xato: {ex.Message}\r\n");
        //            }

        //            btnSend.Enabled = true;
        //        };

        //        form.ShowDialog(this);
        //    }
        //}


        //private void ai_guna2Button1_Click(object sender, EventArgs e)
        //{
        //    // AI funksiyasi
        //    ShowAIDialog();
        //}

    }
}

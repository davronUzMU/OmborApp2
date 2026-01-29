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
    public partial class AdminGenerationKeyControll : UserControl
    {

        private readonly SuperAdminForm _parentForm;
        private readonly SuperAdminService _superAdminService;
        private readonly AdminControllForm _adminControlPage;

        public AdminGenerationKeyControll(SuperAdminForm parentForm,SuperAdminService superAdminService, AdminControllForm adminControlPage)
        {
            _parentForm = parentForm;
            _superAdminService = superAdminService;
            _adminControlPage = adminControlPage;
            InitializeComponent();
        }

        private void logout_guna2ImageButton1_Click(object sender, EventArgs e)
        {
            _parentForm.LoadUserControl(_adminControlPage);
        }

        private void AdminGenerationKeyControll_Load(object sender, EventArgs e)
        {

        }

        private void who_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // for who
        }

        private void secret_key_guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //var district = who_guna2TextBox1.Text.Trim();

            //if (string.IsNullOrEmpty(district))
            //{
            //    MessageBox.Show("Hudud nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// 2) Kodni generatsiya qilish
            //var codeLog = _superAdminService.GenerateCode(district);

            //// 3) Hosil bo‘lgan kodni ko‘rsatish (textbox yoki labelga)
            //secret_key_guna2TextBox2.Text = codeLog.GeneratedCode;

            //// 4) Xabar berish
            //MessageBox.Show($"Kod muvaffaqiyatli yaratildi:\n\n{codeLog.GeneratedCode}",
            //    "Muvaffaqiyatli",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);

            var district = who_guna2TextBox1.Text.Trim();
            if (string.IsNullOrEmpty(district))
            {
                MessageBox.Show("District nomini kiriting!");
                return;
            }

            var codeLog = _superAdminService.GenerateCode(district);
            secret_key_guna2TextBox2.Text = codeLog.GeneratedCode;

            MessageBox.Show($"✅ Kod yaratildi: {codeLog.GeneratedCode}");

            // 🔹 DataGridView yangilash
            _adminControlPage.RefreshData();
            
        }
    }
}

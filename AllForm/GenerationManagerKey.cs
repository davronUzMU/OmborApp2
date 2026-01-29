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
    // manager uchun key generatsiya qilish
    public partial class GenerationManagerKey : UserControl
    {
        private readonly AdminService _adminService;

        public GenerationManagerKey(AdminService adminService)
        {
            _adminService = adminService;
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var generatedCode = _adminService.ManagerCode(); // Kod generatsiya happens here

                // Keyni textboxga yozamiz
                generation_key_guna2TextBox2.Text = generatedCode.Code;

                MessageBox.Show("Manager uchun kod muvaffaqiyatli yaratildi ✅",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // kerak emas
        }

        private void generation_key_guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            generation_key_guna2TextBox2.Font = new Font("Consolas", 14, FontStyle.Regular);
            generation_key_guna2TextBox2.ForeColor = Color.DarkGreen;
        }

        private void GenerationManagerKey_Load(object sender, EventArgs e)
        {
              
        }

      
    }
}

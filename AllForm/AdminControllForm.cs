using Guna.UI2.WinForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;
using WinFormsApp1.Services;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace WinFormsApp1.AllForm
{
    public partial class AdminControllForm : UserControl
    {
        private readonly SuperAdminService _superAdminService;
        private readonly AdminService _adminService;
        private readonly CategoryService _categoryService;
        private readonly DepartmentService _departmentService;
        private readonly ManagerService _managerService;
        private readonly ProductEEService _productEEService;
        private readonly ProductREService _productREService;
        private readonly ProductTexService _productTexService;

        private readonly SuperAdminForm _superAdminForm;

        public AdminControllForm(SuperAdminForm superAdminForm, SuperAdminService superAdminService, AdminService adminService, CategoryService categoryService, DepartmentService departmentService, ManagerService managerService, ProductEEService productEEService, ProductREService productREService, ProductTexService productTexService)
        {
            _superAdminForm = superAdminForm;
            _superAdminService = superAdminService;
            _adminService = adminService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            _managerService = managerService;
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
        }

        private List<Admin> _admins = new();
        private List<AdminCodeLog> _adminCodes = new();

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            //_superAdminForm.LoadUserControl(adminGenerationKeyControll);
            var page = new AdminGenerationKeyControll(_superAdminForm, _superAdminService, this);
            _superAdminForm.LoadUserControl(page);
        }

        private void AdminControllForm_Load(object sender, EventArgs e)
        {
            StyleDataGrid();
            guna2ComboBox1.Items.Add("Adminlar");
            guna2ComboBox1.Items.Add("Admin Kodlar");
            guna2ComboBox1.SelectedIndex = 0;

            RefreshData();

            LoadAdmins();
        }
        public void RefreshData()
        {
            if (guna2ComboBox1.SelectedIndex == 0)
                LoadAdmins();
            else
                LoadAdminCodes();
        }

        private void LoadAdmins()
        {
            _admins = _adminService.GetAllAdmins();
            DisplayAdmins(_admins);
        }
        private void DisplayAdmins(List<Admin> admins)
        {
            data_guna2DataGridView1.Columns.Clear();
            data_guna2DataGridView1.DataSource = admins.Select(a => new
            {
                a.Id,
                a.FullName,
                a.Code,
                a.District,
                Status = a.IsActive ? "Active" : "Inactive",
                Created = a.CreatedAt.ToString("yyyy-MM-dd HH:mm")
            }).ToList();

            data_guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAdminCodes()
        {
            _adminCodes = _superAdminService.GetAllGeneratedCodes();
            DisplayAdminCodes(_adminCodes);
        }

        private void DisplayAdminCodes(List<AdminCodeLog> codes)
        {
            data_guna2DataGridView1.Columns.Clear();
            data_guna2DataGridView1.DataSource = codes.Select(c => new
            {
                c.Id,
                c.GeneratedCode,
                c.District,
                c.CreatedAt,
                c.Used,
                UsedAt = c.UsedAt?.ToString("yyyy-MM-dd HH:mm") ?? "-"
            }).ToList();

            data_guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }




        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string q = search_guna2TextBox1.Text.ToLower();

            if (guna2ComboBox1.SelectedIndex == 0) // Adminlar
            {
                var filtered = _admins.Where(a =>
                    a.FullName.ToLower().Contains(q) ||
                    a.Code.ToLower().Contains(q) ||
                    a.District.ToLower().Contains(q))
                    .ToList();

                DisplayAdmins(filtered);
            }
            else // Admin Kodlar
            {
                var filtered = _adminCodes.Where(c =>
                    c.GeneratedCode.ToLower().Contains(q) ||
                    c.District.ToLower().Contains(q))
                    .ToList();

                DisplayAdminCodes(filtered);
            }
        }

        private void data_guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void excel_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            using var package = new OfficeOpenXml.ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Data");

            if (guna2ComboBox1.SelectedIndex == 0) // Adminlar Excel
            {
                sheet.Cells[1, 1].Value = "Full Name";
                sheet.Cells[1, 2].Value = "Code";
                sheet.Cells[1, 3].Value = "District";
                sheet.Cells[1, 4].Value = "Status";
                sheet.Cells[1, 5].Value = "Created";

                int r = 2;
                foreach (var a in _admins)
                {
                    sheet.Cells[r, 1].Value = a.FullName;
                    sheet.Cells[r, 2].Value = a.Code;
                    sheet.Cells[r, 3].Value = a.District;
                    sheet.Cells[r, 4].Value = a.IsActive ? "Active" : "Inactive";
                    sheet.Cells[r, 5].Value = a.CreatedAt;
                    r++;
                }
            }
            else // Admin Code Logs Excel
            {
                sheet.Cells[1, 1].Value = "Code";
                sheet.Cells[1, 2].Value = "District";
                sheet.Cells[1, 3].Value = "Created";
                sheet.Cells[1, 4].Value = "Used";
                sheet.Cells[1, 5].Value = "Used At";

                int r = 2;
                foreach (var c in _adminCodes)
                {
                    sheet.Cells[r, 1].Value = c.GeneratedCode;
                    sheet.Cells[r, 2].Value = c.District;
                    sheet.Cells[r, 3].Value = c.CreatedAt;
                    sheet.Cells[r, 4].Value = c.Used;
                    sheet.Cells[r, 5].Value = c.UsedAt;
                    r++;
                }
            }

            sheet.Cells.AutoFitColumns();

            using var dialog = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
                package.SaveAs(new System.IO.FileInfo(dialog.FileName));

            MessageBox.Show("✅ Excel saqlandi!");

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBox 
            if (guna2ComboBox1.SelectedIndex == 0)
                LoadAdmins();
            else
                LoadAdminCodes();
        }


        private void StyleDataGrid()
        {
            data_guna2DataGridView1.BorderStyle = BorderStyle.None;
            data_guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            data_guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            data_guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 51, 73);
            data_guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            data_guna2DataGridView1.BackgroundColor = Color.White;
            data_guna2DataGridView1.RowHeadersVisible = false;

            data_guna2DataGridView1.EnableHeadersVisualStyles = false;
            data_guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            data_guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            data_guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            data_guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            data_guna2DataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            data_guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_guna2DataGridView1.ColumnHeadersHeight = 35;
            data_guna2DataGridView1.RowTemplate.Height = 32;
            data_guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}

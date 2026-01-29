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
    public partial class ManagerControllForm : UserControl
    {
        private readonly ManagerService _managerService;

        private List<Manager> _managers = new();
        private List<ManagerCode> _managerCodes = new();

        public ManagerControllForm(ManagerService managerService)
        {
            _managerService = managerService;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
        }
        

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           RefreshData();
        }

        private void RefreshData()
        {
            if (guna2ComboBox1.SelectedIndex == 0)
                LoadManagers();
        }

        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string q = search_guna2TextBox1.Text.ToLower();

            if (guna2ComboBox1.SelectedIndex == 0)
                DisplayManagers(_managers.Where(x =>
                    x.FullName.ToLower().Contains(q) ||
                    x.ManagerCode.ToLower().Contains(q)).ToList());
           
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(guna2DataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

            if (guna2ComboBox1.SelectedIndex == 0)
                _managerService.DeleteManager(id);
            else
                _managerService.DeleteManagerCode(id);

            RefreshData();
        }

        private void excel_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            using var p = new ExcelPackage();
            var sheet = p.Workbook.Worksheets.Add("Data");

            if (guna2ComboBox1.SelectedIndex == 0)
            {
                sheet.Cells[1, 1].Value = "To'liq F.I.O";
                sheet.Cells[1, 2].Value = "Manajer uchun kod";
                sheet.Cells[1, 3].Value = "holati";
                sheet.Cells[1, 4].Value = "yaratilgan vaqt";

                int r = 2;
                foreach (var x in _managers)
                {
                    sheet.Cells[r, 1].Value = x.FullName;
                    sheet.Cells[r, 2].Value = x.ManagerCode;
                    sheet.Cells[r, 3].Value = x.IsActive ? "Active" : "Inactive";
                    sheet.Cells[r, 4].Value = x.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                    r++;
                }
            }
            else
            {
                sheet.Cells[1, 1].Value = "Code";
                sheet.Cells[1, 2].Value = "GeneratedBy";
                sheet.Cells[1, 3].Value = "Used";
                sheet.Cells[1, 4].Value = "Created";

                int r = 2;
                foreach (var x in _managerCodes)
                {
                    sheet.Cells[r, 1].Value = x.Code;
                    sheet.Cells[r, 2].Value = x.GeneratedBy;
                    sheet.Cells[r, 3].Value = x.Used;
                    sheet.Cells[r, 4].Value = x.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                    r++;
                }
            }

            sheet.Cells.AutoFitColumns();
            SaveFileDialog dlg = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" };
            if (dlg.ShowDialog() == DialogResult.OK)
                p.SaveAs(new System.IO.FileInfo(dlg.FileName));
        }

        private void ManagerControllForm_Load(object sender, EventArgs e)
        {
            StyleGrid();

            guna2ComboBox1.Items.Add("Eski → Yangi");
            guna2ComboBox1.Items.Add("Yangi → Eski");
            guna2ComboBox1.SelectedIndex = 0;

            LoadManagers();
        }
        private void LoadManagers()
        {
            _managers = _managerService.GetManagerAll();
            ApplySortManagers();
        }
        private void ApplySortManagers()
        {
            bool ascending = guna2ComboBox1.SelectedIndex == 0;
            var sorted = ascending
                ? _managers.OrderBy(x => x.CreatedAt).ToList()
                : _managers.OrderByDescending(x => x.CreatedAt).ToList();

            DisplayManagers(sorted);
        }
        private void DisplayManagers(List<Manager> list)
        {
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.DataSource = list.Select(x => new
            {
                x.Id,
                x.FullName,
                x.ManagerCode,
                Status = x.IsActive ? "Active" : "Inactive",
                Created = x.CreatedAt.ToString("yyyy-MM-dd HH:mm")
            }).ToList();

            AddDeleteButton();
        }
        private void AddDeleteButton()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "O‘chirish";
            btn.Text = "🗑️ Delete";
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.BackColor = Color.LightCoral;
            guna2DataGridView1.Columns.Add(btn);
        }
        private void StyleGrid()
        {
            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 51, 73);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            guna2DataGridView1.BackgroundColor = Color.White;
            guna2DataGridView1.RowHeadersVisible = false;

            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            guna2DataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.RowTemplate.Height = 32;
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}

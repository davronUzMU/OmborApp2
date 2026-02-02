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
using WinFormsApp1.Services;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace WinFormsApp1.AllForm
{
    public partial class ProductControllForm : UserControl
    {
        private readonly ProductEEService _productEEService;
        private readonly ProductREService _productREService;
        private readonly ProductTexService _productTexService;
        private readonly DepartmentService _departmentService;
        private readonly CategoryService _categoryService;



        private List<dynamic> _currentList = new();

        public ProductControllForm(ProductEEService productEEService, ProductREService productREService, ProductTexService productTexService,DepartmentService departmentService,CategoryService categoryService)
        {
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;
            _departmentService = departmentService;
            _categoryService = categoryService;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            InitializeComponent();
        }
        
       

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
               string search = search_guna2TextBox1.Text.ToLower();

             if (string.IsNullOrWhiteSpace(search))
             {
               guna2DataGridView1.DataSource = null;
               guna2DataGridView1.DataSource = _currentList;
               AddDeleteButton();
               return;
              }

            List<dynamic> filtered;

         // Ko‘chmas Mulk
           if (guna2ComboBox1.SelectedIndex == 0)
           {
           filtered = _currentList
               .Where(x =>
                  (x.productLocation ?? "").ToLower().Contains(search) ||
                  (x.ProductDescription ?? "").ToLower().Contains(search))
             .ToList();
           }
        // Maishiy Mahsulotlar
        else if (guna2ComboBox1.SelectedIndex == 1)
           {
          filtered = _currentList
              .Where(x =>
                 (x.ProductName ?? "").ToLower().Contains(search) ||
                 (x.locationProduct ?? "").ToLower().Contains(search) ||
                 (x.ProductDescription ?? "").ToLower().Contains(search))
             .ToList();
          }
          // Texnika
          else
          {
          filtered = _currentList
              .Where(x =>
                 (x.ProductName ?? "").ToLower().Contains(search) ||
                 (x.locationProduct ?? "").ToLower().Contains(search) ||
                 (x.ProductDescription ?? "").ToLower().Contains(search))
             .ToList();
              }

            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = filtered;
            AddDeleteButton();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(guna2DataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

            DialogResult confirm = MessageBox.Show("Rostdan o‘chirmoqchimisiz?", "Tasdiqlash", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            if (guna2ComboBox1.SelectedIndex == 0)
                _productREService.DeleteProductRE(id);
            else if (guna2ComboBox1.SelectedIndex == 1)
                _productEEService.DeleteProductEE(id);
            else
                _productTexService.DeleteProductTex(id);

            RefreshData();
        }

        private void excel_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // EXCEL
          
        }

        private void ProductControllForm_Load(object sender, EventArgs e)
        {
            StyleGrid();

            guna2ComboBox1.Items.Add("Ko‘chmas Mulklar");
            guna2ComboBox1.Items.Add("Maishiy Mahsulotlar");
            guna2ComboBox1.Items.Add("Texnika");
            guna2ComboBox1.SelectedIndex = 0;

            RefreshData();
        }
        private void RefreshData()
        {
            if (guna2ComboBox1.SelectedIndex == 0)
                LoadRealEstate();
            else if (guna2ComboBox1.SelectedIndex == 1)
                LoadHousehold();
            else
                LoadTechnology();
        }
        private void LoadRealEstate()
        {
            var data = _productREService.GetProductREAll();
            _currentList=data.Select(x => new
            {
                x.Id,
                x.ManagerId,
                x.CategoryId,
                x.DepartmentId,
                x.productLocation,
                x.ProductDescription,
                x.TotalNumber,
                Created = x.CreatedAt.ToString("yyyy-MM-dd HH:mm")
            }).Cast<dynamic>().ToList();

            Display(_currentList);
        }

        private void LoadHousehold()
        {
            var data = _productEEService.GetProductEEAll();

            _currentList = data.Select(x => new
            {
                x.Id,
                x.ManagerId,
                x.CategoryId,
                x.DepartmentId,
                x.ProductName,
                x.locationProduct,
                x.ProductDescription,
                x.TotalNumber,
                Created = x.CreatedAt.ToString("yyyy-MM-dd HH:mm")
            }).Cast<dynamic>().ToList();

            Display(_currentList);
        }

        private void LoadTechnology()
        {
            var data = _productTexService.GetProductTexAll();
            _currentList = data.Select(x => new
            {
                x.Id,
                x.ManagerId,
                x.CategoryId,
                x.DepartmentId,
                x.ProductName,
                x.locationProduct,
                x.ProductDescription,
                x.TotalNumber,
                Created = x.CreatedAt.ToString("yyyy-MM-dd HH:mm")
            }).Cast<dynamic>().ToList();

            Display(_currentList);
        }

        private void Display(List<dynamic> list)
        {
            _currentList = list;
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.DataSource = list;

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

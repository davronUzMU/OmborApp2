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
    public partial class MainAdminControll : UserControl
    {
        private readonly ProductEEService _productEEService;
        private readonly ProductREService _productREService;
        private readonly ProductTexService _productTexService;

        public List<dynamic> _currentList = new();
        public MainAdminControll(ProductEEService productEEService, ProductREService productREService, ProductTexService productTexService)
        {
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;
            InitializeComponent();
        }
    

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void LoadRealEstate()
        {
            var data = _productREService.GetProductREAll();

            _currentList = data.Select(x => new
            {
                x.Id,
                x.ProductType,
                x.ManagerId,
                x.CategoryId,
                x.DepartmentId,
                Location = x.productLocation,
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
                x.ProductType,
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
                x.ProductType,
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
        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_guna2TextBox1.Text))
            {
                RefreshData();
                return;
            }

            var key = search_guna2TextBox1.Text.Trim();

            var filtered = _currentList.Where(x =>
                x.ToString().Contains(key, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            Display(filtered);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                string currentLocation = "";

                // Location nomlari turli xil bo‘lgani uchun tekshiramiz
                if (guna2DataGridView1.Columns.Contains("Location"))
                    currentLocation = guna2DataGridView1.Rows[e.RowIndex].Cells["Location"].Value?.ToString() ?? string.Empty;
                else if (guna2DataGridView1.Columns.Contains("locationProduct"))
                    currentLocation = guna2DataGridView1.Rows[e.RowIndex].Cells["locationProduct"].Value?.ToString() ?? string.Empty;
                else if (guna2DataGridView1.Columns.Contains("productLocation"))
                    currentLocation = guna2DataGridView1.Rows[e.RowIndex].Cells["productLocation"].Value?.ToString() ?? string.Empty;


                EditProduct(id, currentLocation);
            }
        }

        private void EditProduct(int id, string oldLocation)
        {
            // edit button uchun

            string newLocation = Microsoft.VisualBasic.Interaction.InputBox(
               "Yangi location kiriting:",
                 "Location tahrirlash",
                 oldLocation
               );

            if (string.IsNullOrWhiteSpace(newLocation))
                return;

            // Qaysi kategoriya tanlanganini bilamiz
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                _productREService.UpdateLocation(id, newLocation);
            }
            else if (guna2ComboBox2.SelectedIndex == 1)
            {
                _productEEService.UpdateLocation(id, newLocation);
            }
            else
            {
                _productTexService.UpdateLocation(id, newLocation);
            }

            RefreshData();
        }

        private void MainAdminControll_Load(object sender, EventArgs e)
        {
            StyleGrid();

            guna2ComboBox2.Items.Add("Ko‘chmas Mulklar");
            guna2ComboBox2.Items.Add("Maishiy Mahsulotlar");
            guna2ComboBox2.Items.Add("Texnika");
            guna2ComboBox2.SelectedIndex = 0;

            RefreshData();
        }

        private void StyleGrid()
        {
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 250);
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

        private void Display(List<dynamic> list)
        {
            //_currentList = list;
            //guna2DataGridView1.Columns.Clear();
            //guna2DataGridView1.DataSource = list;

            _currentList = list;

            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.DataSource = list;

            // Edit button column
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            editBtn.Name = "Edit";
            editBtn.HeaderText = "Edit";
            editBtn.Text = "Edit";
            editBtn.UseColumnTextForButtonValue = true;
            editBtn.Width = 80;

            guna2DataGridView1.Columns.Add(editBtn);

        }
        private void RefreshData()
        {
            if (guna2ComboBox2.SelectedIndex == 0)
                LoadRealEstate();
            else if (guna2ComboBox2.SelectedIndex == 1)
                LoadHousehold();
            else
                LoadTechnology();
        }
    }
}

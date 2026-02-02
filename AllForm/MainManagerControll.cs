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
    public partial class MainManagerControll : UserControl
    {
        private readonly ProductEEService _productEEService;
        private readonly ProductREService _productREService;
        private readonly ProductTexService _productTexService;
        private readonly DepartmentService _departmentService;
        private readonly CategoryService _categoryService;

        private readonly ProductEEHistoryService _productEEHistoryService;
        private readonly ProductTexHistoryService _productTexHistoryService;
        private readonly ProductREHistoryService _productREHistoryService;



        public List<dynamic> _currentList = new();

        public MainManagerControll(ProductEEService productEEService,
            ProductREService productREService,
            ProductTexService productTexService,
            CategoryService categoryService,
            DepartmentService departmentService,
            ProductEEHistoryService productEEHistoryService,
            ProductTexHistoryService productTexHistoryService,
            ProductREHistoryService productREHistoryService)
        {
            _productEEService = productEEService;
            _productREService = productREService;
            _productTexService = productTexService;
            _categoryService = categoryService;
            _departmentService = departmentService;

            _productEEHistoryService = productEEHistoryService;
            _productTexHistoryService = productTexHistoryService;
            _productREHistoryService = productREHistoryService;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
        }
        
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {
                dynamic product = guna2DataGridView1.Rows[e.RowIndex].DataBoundItem;
                ShowEditDialog(product);
            }
        }
        private void ShowEditDialog(dynamic product)
        {
            string selected = guna2ComboBox1.SelectedItem?.ToString() ?? "";

            using (Form form = new Form())
            {
                form.Text = "Mahsulotni tahrirlash";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(400, 350);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                int y = 30;

                // **Name / Location label**
                Label lblA = new Label { Location = new Point(20, y), AutoSize = true };
                TextBox txtA = new TextBox { Location = new Point(150, y - 3), Width = 220 };
                y += 40;

                // Description
                Label lblDesc = new Label { Text = "Tavsif:", Location = new Point(20, y), AutoSize = true };
                TextBox txtDesc = new TextBox { Location = new Point(150, y - 3), Width = 220 };
                y += 40;

                // TotalNumber
                Label lblTotal = new Label { Text = "Soni:", Location = new Point(20, y), AutoSize = true };
                TextBox txtTotal = new TextBox { Location = new Point(150, y - 3), Width = 220 };
                y += 40;

                // Save button
                Button btnSave = new Button()
                {
                    Text = "Saqlash",
                    BackColor = Color.FromArgb(46, 51, 73),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(150, y),
                    Width = 220
                };

                // ==== Modelga qarab UI va boshlang‘ich qiymatlar ====
                if (selected == "Maishiy-buyumlar") // ProductHousehold
                {
                    lblA.Text = "Mahsulot nomi:";
                    txtA.Text = product.ProductName;

                    txtDesc.Text = product.ProductDescription;
                    txtTotal.Text = product.TotalNumber.ToString();
                }
                else if (selected == "Ko'chmas-mulk") // ProductRealEstate
                {
                    lblA.Text = "Manzili:";
                    txtA.Text = product.productLocation;

                    txtDesc.Text = product.ProductDescription;
                    txtTotal.Text = product.TotalNumber.ToString();
                }
                else // Texnika-buyumlari – ProductTexnologiya
                {
                    lblA.Text = "Mahsulot nomi:";
                    txtA.Text = product.ProductName;

                    txtDesc.Text = product.ProductDescription;
                    txtTotal.Text = product.TotalNumber.ToString();

                    //lblCode.Visible = txtCode.Visible = true;
                    //txtCode.Text = product.UnicalCode;
                }

                // Controls ga qo‘shamiz
                form.Controls.AddRange(new Control[] {
            lblA, txtA, lblDesc, txtDesc, lblTotal, txtTotal, btnSave
        });

                // === SAQLASH ===
                btnSave.Click += (s, ev) =>
                {
                    if (selected == "Maishiy-buyumlar")
                    {
                        var data=_productEEService.GetById(product.Id);
                        
                        var productEE = new ProductHouseHoldHistory { 
                            ProductHouseHoldId = data.Id,
                            ProductName = data.ProductName,
                            TotalNumber = data.TotalNumber,
                            ProductDescription = data.ProductDescription,
                            CreatedAt = DateTime.UtcNow
                        };
                        
                        _productEEHistoryService.AddProductHistory(productEE);

                        product.ProductName = txtA.Text;
                        product.ProductDescription = txtDesc.Text;
                        product.TotalNumber = int.Parse(txtTotal.Text);
                        //product.UnicalCode = txtCode.Text;
                        
                        _productEEService.UpdateProductEE(product);
                    }
                    else if (selected == "Ko'chmas-mulk")
                    {
                        var data = _productREService.GetProductREById(product.Id);

                        var productRE = new ProductRealEstateHistory
                        {
                             ProductRealEstateId = data.Id,
                             productLocation = data.productLocation,
                             TotalNumber = data.TotalNumber,
                             ProductDescription = data.ProductDescription,
                             CreatedAt = DateTime.UtcNow
                        };
                        _productREHistoryService.AddProductREHistory(productRE);


                        product.productLocation = txtA.Text;
                        product.ProductDescription = txtDesc.Text;
                        product.TotalNumber = int.Parse(txtTotal.Text);
                        _productREService.UpdateProductRE(product);
                    }
                    else
                    {
                        var data = _productTexService.GetProductTexById(product.Id);
                        var productTex=new ProductTexnologyHistory
                        {
                            ProductTexnologyId = data.Id,
                            ProductName = data.ProductName,
                            TotalNumber = data.TotalNumber,
                            ProductDescription = data.ProductDescription,
                            CreatedAt = DateTime.UtcNow
                        };
                        _productTexHistoryService.AddProductTexHistory(productTex);


                        product.ProductName = txtA.Text;
                        product.ProductDescription = txtDesc.Text;
                        product.TotalNumber = int.Parse(txtTotal.Text);
                        //product.UnicalCode = txtCode.Text;
                        _productTexService.UpdateProductTex(product);
                    }


                    MessageBox.Show("Ma'lumot yangilandi ✅", "Tayyor",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    form.Close();
                    LoadDataAsync();
                };

                form.ShowDialog();
            }
        }
        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
             string search = search_guna2TextBox1.Text.ToLower();
             string selected = guna2ComboBox1.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(search))
            {
               guna2DataGridView1.DataSource = null;
               guna2DataGridView1.DataSource = _currentList;
               return;
            }

           List<dynamic> filtered;

          if (selected == "Maishiy-buyumlar")
          {
          filtered = _currentList
            .Where(x =>
                x.ProductName.ToLower().Contains(search) ||
                x.ProductDescription.ToLower().Contains(search) ||
                x.locationProduct.ToLower().Contains(search))
            .ToList();
          }
          else if (selected == "Ko'chmas-mulk")
          {
            filtered = _currentList
             .Where(x =>
                x.productLocation.ToLower().Contains(search) ||
                x.ProductDescription.ToLower().Contains(search))
            .ToList();
           }
           else // Texnika-buyumlari
           {
            filtered = _currentList
                .Where(x =>
                  x.ProductName.ToLower().Contains(search) ||
                  x.ProductDescription.ToLower().Contains(search) ||
                  x.locationProduct.ToLower().Contains(search))
            .ToList();
           }

         guna2DataGridView1.DataSource = null;
         guna2DataGridView1.DataSource = filtered;
        }
        

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            RefreshData();
            LoadDataAsync();

        }
        public void RefreshData()
        {
            string selected = guna2ComboBox1.SelectedItem?.ToString() ?? "";

            if (selected == "Maishiy-buyumlar")
                LoadHousehold();       // ProductEEService
            else if (selected == "Ko'chmas-mulk")
                LoadRealEstate();      // ProductREService
            else if (selected == "Texnika-buyumlari")
                LoadTechnology();      // ProductTexService
        }

        // Misol uchun metodlar:
        private void LoadHousehold()
        {
            _currentList = _productEEService.GetProductEEAll().
                Where(c=>c.ManagerId==SessionData.ManagerId)
                .Cast<dynamic>().ToList();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = _currentList;
        }

        private void LoadRealEstate()
        {
            //_currentList = _productREService.GetProductREAll().Cast<dynamic>().ToList();
            _currentList = _productREService.GetProductREAll().
                Where(x=>x.ManagerId ==SessionData.ManagerId).
                Cast<dynamic>().ToList();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = _currentList;
        }

        private void LoadTechnology()
        {
            _currentList = _productTexService.GetProductTexAll().
                Where(y=>y.ManagerId==SessionData.ManagerId)
                .Cast<dynamic>().ToList();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = _currentList;
        }

        private void MainManagerControll_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.AddRange(new string[] { "Maishiy-buyumlar", "Ko'chmas-mulk", "Texnika-buyumlari" });
            guna2ComboBox1.SelectedIndex = 0;
            LoadDataAsync();
            AddEditColumn();
            StyleDataGrid();
        }
        private Task LoadDataAsync()
        {
            string? selected = guna2ComboBox1.SelectedItem?.ToString();

            if (selected == "Maishiy-buyumlar")
                _currentList = _productEEService.GetProductEEAll()
                    .Where(x => x.ManagerId == SessionData.ManagerId)
                    .Cast<dynamic>().ToList();

            else if (selected == "Ko'chmas-mulk")
                _currentList = _productREService.GetProductREAll()
                    .Where(x => x.ManagerId == SessionData.ManagerId)
                    .Cast<dynamic>().ToList();

            else if (selected == "Texnika-buyumlari")
                _currentList = _productTexService.GetProductTexAll()
                    .Where(x => x.ManagerId == SessionData.ManagerId)
                    .Cast<dynamic>().ToList();

            else
                _currentList = new();

            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = _currentList;

            return Task.CompletedTask;
        }

        private void AddEditColumn()
        {
            if (!guna2DataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                edit.Name = "Edit";
                edit.HeaderText = "Edit";
                edit.Text = "Edit";
                edit.UseColumnTextForButtonValue = true;
                guna2DataGridView1.Columns.Add(edit);
            }
        }
        private void StyleDataGrid()
        {
            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 51, 73);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            guna2DataGridView1.BackgroundColor = Color.White;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.GridColor = Color.Silver;
        }

        private void excel_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // excel
            if (_currentList.Count == 0)
            {
                MessageBox.Show("Ma’lumot yo‘q!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Products");

            string selected = guna2ComboBox1.SelectedItem?.ToString() ?? "";

            // sarlavhalar
            int col = 1;
            sheet.Cells[1, col++].Value = "ID";
            sheet.Cells[1, col++].Value = "Manajer";
            sheet.Cells[1, col++].Value = "Bo'lim";
            sheet.Cells[1, col++].Value = "Kategoriya";

            if (selected == "Ko'chmas-mulk")
            {
                sheet.Cells[1, col++].Value = "Maqsulot joylashgan joy";
                sheet.Cells[1, col++].Value = "Qo'shimcha ma'lumotlar";
                sheet.Cells[1, col++].Value = "Maqsulot soni";
                sheet.Cells[1, col++].Value = "Vaqt";
            }
            else // Maishiy-buyumlar va Texnika
            {
                sheet.Cells[1, col++].Value = "Maqsulot nomi";
                sheet.Cells[1, col++].Value = "Maqsulot joylashgan joy";
                sheet.Cells[1, col++].Value = "Qo'shimcha ma'lumotlar";
                sheet.Cells[1, col++].Value = "Maqsulot soni";
                sheet.Cells[1, col++].Value = "Maqsulot kodi";
                sheet.Cells[1, col++].Value = "Vaqt";
            }

            int row = 2;

            foreach (var item in _currentList)
            {
                col = 1;

                sheet.Cells[row, col++].Value = item.Id;
                sheet.Cells[row, col++].Value = item.ManagerId;
                
                sheet.Cells[row, col++].Value = _departmentService.GetDepartmentAll()
                    .FirstOrDefault(d => d.Id == item.DepartmentId)?.DepartmentName;
                sheet.Cells[row, col++].Value = _categoryService.GetCategoryAll()
                    .FirstOrDefault(c => c.Id == item.CategoryId)?.CategoryName;

                if (selected == "Ko'chmas-mulk")
                {
                    sheet.Cells[row, col++].Value = item.productLocation;
                    sheet.Cells[row, col++].Value = item.ProductDescription;
                    sheet.Cells[row, col++].Value = item.TotalNumber;
                    sheet.Cells[row, col++].Value = item.CreatedAt.ToString("HH:mm - dd/MM/yyyy");
                }
                else
                {
                    sheet.Cells[row, col++].Value = item.ProductName;
                    sheet.Cells[row, col++].Value = item.locationProduct;
                    sheet.Cells[row, col++].Value = item.ProductDescription;
                    sheet.Cells[row, col++].Value = item.TotalNumber;
                    sheet.Cells[row, col++].Value = item.UnicalCode;
                    sheet.Cells[row, col++].Value = item.CreatedAt.ToString("HH:mm - dd/MM/yyyy");
                }

                row++;
            }

            sheet.Cells.AutoFitColumns();

            using var dialog = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
                package.SaveAs(new System.IO.FileInfo(dialog.FileName));

            MessageBox.Show("✅ Excel saqlandi!", "Tayyor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

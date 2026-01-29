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
    public partial class AllManagerControll : UserControl
    {
        private readonly ManagerService _managerService;

        public AllManagerControll(ManagerService managerService)
        {
            _managerService = managerService;
            InitializeComponent();
        }
       

        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            var searchTxt = search_guna2TextBox1.Text.ToLower();

            var filtered = _managerService.GetManagerAll()
                .Where(x => x.FullName.ToLower().Contains(searchTxt) ||
                            x.ManagerCode.ToLower().Contains(searchTxt))
                .Select(x => new
                {
                    x.Id,
                    FISH = x.FullName,
                    Kod = x.ManagerCode,
                    Holati = x.IsActive ? "Faol" : "Faol emas",
                    Sana = x.CreatedAt.ToLocalTime().ToString("dd.MM.yyyy HH:mm")
                })
                .ToList();

            guna2DataGridView1.DataSource = filtered;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AllManagerControll_Load(object sender, EventArgs e)
        {
            LoadManagers();
            StyleDataGrid();
        }

        private void LoadManagers()
        {
            var data = _managerService.GetManagerAll()
                .Select(x => new
                {
                    x.Id,
                    FISH = x.FullName,
                    Kod = x.ManagerCode,
                    Holati = x.IsActive ? "Faol" : "Faol emas",
                    Sana = x.CreatedAt.ToLocalTime().ToString("dd.MM.yyyy HH:mm")
                })
                .ToList();

            guna2DataGridView1.DataSource = data;
        }

        private void StyleDataGrid()
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

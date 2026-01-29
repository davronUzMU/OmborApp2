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
    public partial class AddDepartmentControll : UserControl
    {
        private readonly DepartmentService _departmentService;
        public AddDepartmentControll(DepartmentService departmentService)
        {
            _departmentService = departmentService;
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Edit
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                object? cellValue = guna2DataGridView1.Rows[e.RowIndex].Cells["DepartmentName"].Value;
                string oldName = cellValue?.ToString() ?? string.Empty;

                string newName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Yangi nomni kiriting:", "Edit Department", oldName);

                if (!string.IsNullOrEmpty(newName))
                {
                    _departmentService.UpdateDepartment(new Models.Department()
                    {
                        Id = id,
                        DepartmentName = newName
                    });
                    LoadDepartments();
                }
            }

            // Delete
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                if (MessageBox.Show("Rostdan o'chirmoqchimisiz?", "Delete", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    _departmentService.DeleteDepartment(id);
                    LoadDepartments();
                }
            }
        }

        private void add_department_guna2GradientButton1_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = "Bo‘lim qo‘shish";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(350, 180);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                // Label
                Label lbl = new Label();
                lbl.Text = "Bo‘lim nomi:";
                lbl.Location = new Point(20, 30);
                lbl.AutoSize = true;
                form.Controls.Add(lbl);

                // TextBox
                TextBox txtName = new TextBox();
                txtName.Location = new Point(120, 27);
                txtName.Width = 200;
                form.Controls.Add(txtName);

                // Save button
                Button btnSave = new Button();
                btnSave.Text = "Saqlash";
                btnSave.BackColor = Color.FromArgb(46, 51, 73);
                btnSave.ForeColor = Color.White;
                btnSave.FlatStyle = FlatStyle.Flat;
                btnSave.Location = new Point(120, 80);
                btnSave.Width = 200;
                form.Controls.Add(btnSave);

                btnSave.Click += (s, ev) =>
                {
                    string depName = txtName.Text.Trim();

                    if (string.IsNullOrEmpty(depName))
                    {
                        MessageBox.Show("Bo‘lim nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _departmentService.AddDepartment(new Models.Department
                    {
                        DepartmentName = depName
                    });

                    MessageBox.Show("Bo‘lim muvaffaqiyatli qo‘shildi!", "Tayyor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.Close();
                    LoadDepartments(); // yangilash
                };

                form.ShowDialog();
            }
        }

        private void search_guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            var all = _departmentService.GetDepartmentAll();
            var filtered = all.Where(x => x.DepartmentName.Contains(search_guna2TextBox1.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            guna2DataGridView1.DataSource = filtered;
        }

        private void AddDepartmentControll_Load(object sender, EventArgs e)
        {
            StyleDataGrid();
            LoadDepartments();
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

        private void LoadDepartments()
        {
            guna2DataGridView1.Columns.Clear();
            var list = _departmentService.GetDepartmentAll();

            guna2DataGridView1.DataSource = list;

            // Edit tugma
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            editBtn.Name = "Edit";
            editBtn.Text = "Edit";
            editBtn.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(editBtn);

            // Delete tugma
            DataGridViewButtonColumn delBtn = new DataGridViewButtonColumn();
            delBtn.Name = "Delete";
            delBtn.Text = "Delete";
            delBtn.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(delBtn);
        }

    }
}

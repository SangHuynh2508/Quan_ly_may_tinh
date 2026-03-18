using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSupplier : Form
    {
        NhaCungCapBUS bus = new NhaCungCapBUS();
        public frmSupplier()
        {
            InitializeComponent();
            LoadData();
            txtMaNCC.ReadOnly = true;
            ResetForm();
        }
        void LoadData()
        {
            dataGridView1.DataSource = bus.LayTatCa();
            dataGridView1.ReadOnly = true;
        }
        void ResetForm()
        {
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMaNCC.Text = bus.PhatSinhMaTuDong().ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = int.Parse(txtMaNCC.Text),
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChi.Text,
                SoDienThoai = txtSDT.Text
            };

            try
            {
                bus.Them(ncc);
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                LoadData(); 
                ResetForm(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = int.Parse(txtMaNCC.Text),
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChi.Text,
                SoDienThoai = txtSDT.Text
            };
            bus.Sua(ncc);
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            int ma = int.Parse(txtMaNCC.Text);
            bus.Xoa(ma);
            LoadData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;

namespace GUI
{
    public partial class frmSupplier : Form
    {
        NhaCungCapBUS bus = new NhaCungCapBUS();
        public frmSupplier()
        {
            InitializeComponent();
            txtMaNCC.ReadOnly = true;
            LoadData();
            ResetForm();

            // Gán sự kiện cho các nút nếu chưa có
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        void LoadData()
        {
            dataGridView1.DataSource = bus.LayTatCa().Select(n => new {
                MaNCC = n.MaNCC,
                TenNCC = n.TenNCC,
                DiaChi = n.DiaChi,
                SoDienThoai = n.SoDienThoai
            }).ToList();
            dataGridView1.ReadOnly = true;

            // Đặt tiêu đề cột cho đẹp
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["MaNCC"].HeaderText = "Mã NCC";
                dataGridView1.Columns["TenNCC"].HeaderText = "Tên NCC";
                dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            }
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
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
                return;
            }

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
            MessageBox.Show("Sửa thành công!");
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            DialogResult dr = MessageBox.Show("Xác nhận xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int ma = int.Parse(txtMaNCC.Text);
                bus.Xoa(ma);
                LoadData();
                ResetForm();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

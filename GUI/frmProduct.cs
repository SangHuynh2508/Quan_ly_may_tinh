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
    public partial class frmProduct : Form
    {
        private SanPhamBUS bus = new SanPhamBUS();
        private LoaiSanPhamBUS loaiBus = new LoaiSanPhamBUS();
        private bool isNew = true;

        public frmProduct()
        {
            InitializeComponent();
            LoadData();
            LoadCategories();
            txtMaSP.ReadOnly = true;
            cmbLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            ResetForm();

            // Gán sự kiện
            btnCapNhat.Click += btnCapNhat_Click;
            btnThoat.Click += btnThoat_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void LoadData()
        {
            dataGridView1.DataSource = bus.GetAll().Select(s => new {
                MaSP = s.MaSanPham,
                TenSP = s.TenSanPham,
                Loai = s.LoaiSanPham.TenLoai,
                Hang = s.HangSanXuat,
                GiaNhap = s.GiaNhap,
                GiaBan = s.GiaBan,
                SoLuong = s.SoLuongTon,
                MaLoai = s.MaLoai
            }).ToList();

            if (dataGridView1.Columns.Contains("MaLoai"))
                dataGridView1.Columns["MaLoai"].Visible = false;
        }

        private void LoadCategories()
        {
            cmbLoaiSP.DataSource = loaiBus.GetAll();
            cmbLoaiSP.DisplayMember = "TenLoai";
            cmbLoaiSP.ValueMember = "MaLoai";
            cmbLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ResetForm()
        {
            txtTenSP.Clear();
            txtHangSX.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            txtMaSP.Text = bus.PhatSinhMaTuDong().ToString();
            isNew = true;
            btnCapNhat.Text = "Thêm";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtHangSX.Text = row.Cells["Hang"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuong"].Value.ToString();
                cmbLoaiSP.SelectedValue = row.Cells["MaLoai"].Value;

                isNew = false;
                btnCapNhat.Text = "Cập nhật";
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham
                {
                    MaSanPham = int.Parse(txtMaSP.Text),
                    TenSanPham = txtTenSP.Text,
                    MaLoai = (int)cmbLoaiSP.SelectedValue,
                    HangSanXuat = txtHangSX.Text,
                    GiaNhap = decimal.Parse(txtGiaNhap.Text),
                    GiaBan = decimal.Parse(txtGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuongTon.Text)
                };

                string result = bus.Upsert(sp, isNew);
                MessageBox.Show(result);
                if (result.Contains("thành công"))
                {
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập. " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

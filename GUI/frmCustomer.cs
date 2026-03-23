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
    public partial class frmCustomer : Form
    {
        KhachHangBUS bus = new KhachHangBUS();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            txtMaKhachHang.ReadOnly = true;
            LoadTreeViewKhachHang();
            ResetForm();

            // Gán sự kiện
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnNhapLai.Click += btnNhapLai_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ResetForm()
        {
            txtTenKhachHang.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaKhachHang.Text = bus.PhatSinhMaTuDong().ToString();
            dataGridView1.DataSource = null;
        }
        private void LoadTreeViewKhachHang()
        {
            treeView1.Nodes.Clear();

        
            TreeNode rootNode = new TreeNode("Danh sách khách hàng");
            var dsKhachHang = bus.LayDanhSach();

            foreach (var kh in dsKhachHang)
            {
       
                TreeNode customerNode = new TreeNode(kh.HoTen);

             
                customerNode.Name = kh.MaKhachHang.ToString();

          
                customerNode.Tag = kh;

                rootNode.Nodes.Add(customerNode);
            }

            treeView1.Nodes.Add(rootNode);
            rootNode.Expand();
        }


        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dataGridView1.Columns["NgayMua"].HeaderText = "Ngày Mua";
                dataGridView1.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";

                dataGridView1.Columns["ThanhToan"].HeaderText = "Đã Thanh Toán (VNĐ)";
                dataGridView1.Columns["ThanhToan"].DefaultCellStyle.Format = "N0";
                if (dataGridView1.Columns["NgayMua"] != null)
                {
                    dataGridView1.Columns["NgayMua"].ReadOnly = true;
                }
                dataGridView1.Columns["TenSanPham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                KhachHang kh = e.Node.Tag as KhachHang;

                if (kh != null)
                {
                    txtMaKhachHang.Text = kh.MaKhachHang.ToString();
                    txtTenKhachHang.Text = kh.HoTen;
                    txtSDT.Text = kh.SoDienThoai;
                    txtDiaChi.Text = kh.DiaChi;

                
                    int maKH = kh.MaKhachHang;
                    dataGridView1.DataSource = bus.LayLichSuMuaHang(maKH);
                    FormatDataGridView();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            KhachHang kh = new KhachHang
            {
                MaKhachHang = int.Parse(txtMaKhachHang.Text),
                HoTen = txtTenKhachHang.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            try
            {
                bus.Them(kh);
                MessageBox.Show("Thêm thành công!");
                LoadTreeViewKhachHang();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text)) return;

            KhachHang kh = new KhachHang
            {
                MaKhachHang = int.Parse(txtMaKhachHang.Text),
                HoTen = txtTenKhachHang.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            try
            {
                bus.Sua(kh);
                MessageBox.Show("Cập nhật thành công!");
                LoadTreeViewKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

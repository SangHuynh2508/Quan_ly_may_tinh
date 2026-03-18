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
            LoadTreeViewKhachHang();
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
                    txtTenKhachHang.Text = kh.HoTen;
                    txtSDT.Text = kh.SoDienThoai;
                    txtDiaChi.Text = kh.DiaChi;

                
                    int maKH = int.Parse(e.Node.Name);
                    dataGridView1.DataSource = bus.LayLichSuMuaHang(maKH);
                    FormatDataGridView();
                }
            }
        }
    }
}

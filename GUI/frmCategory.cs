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

namespace GUI
{
    public partial class frmCategory : Form
    {
        private LoaiSanPhamBUS bus = new LoaiSanPhamBUS();

        public frmCategory()
        {
            InitializeComponent();
            LoadData();

            // Gán sự kiện cho các nút nếu chưa có trong Designer
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void LoadData()
        {
            dataGridView1.DataSource = bus.GetAll().Select(l => new {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai
            }).ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string result = bus.Add(txtTenLoai.Text);
            MessageBox.Show(result);
            if (result == "Thêm thành công!")
            {
                txtTenLoai.Clear();
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int maLoai = (int)dataGridView1.CurrentRow.Cells["MaLoai"].Value;
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa loại này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string result = bus.Delete(maLoai);
                    MessageBox.Show(result);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm để xóa!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmStaff : Form
    {
        private NguoiDungBUS bus = new NguoiDungBUS();

        public frmStaff()
        {
            InitializeComponent();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = true;
            txtSDT.Enabled = false; // Entity không có SDT
            cmbQuyenHan.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Cấu hình ListView
            listView1.Columns.Add("Mã NV", 100);
            listView1.Columns.Add("Họ Tên", 200);
            listView1.Columns.Add("Tên Đăng Nhập", 150);
            listView1.Columns.Add("Quyền Hạn", 150);

            LoadRoles();
            LoadData();
            ResetForm();

            // Gán sự kiện
            btnTaoMoi.Click += btnTaoMoi_Click;
            btnXoaBo.Click += btnXoaBo_Click;
            btnNhapLai.Click += btnNhapLai_Click;
            btnThoat.Click += btnThoat_Click;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private void LoadRoles()
        {
            // Giả định 1: Admin, 2: Nhân viên
            cmbQuyenHan.Items.Clear();
            cmbQuyenHan.DisplayMember = "Text";
            cmbQuyenHan.ValueMember = "Value";
            cmbQuyenHan.Items.Add(new { Text = "Admin", Value = 1 });
            cmbQuyenHan.Items.Add(new { Text = "Nhân viên", Value = 2 });
            cmbQuyenHan.SelectedIndex = 1;
        }

        private void LoadData()
        {
            var list = bus.LayTatCa();
            listView1.Items.Clear();
            foreach (var u in list)
            {
                ListViewItem item = new ListViewItem(u.MaNguoiDung.ToString());
                item.SubItems.Add(u.HoTen ?? "");
                item.SubItems.Add(u.TenDangNhap ?? "");
                item.SubItems.Add(u.VaiTro != null ? u.VaiTro.TenVaiTro : "Chưa xác định");
                item.Tag = u; // Lưu object để dùng sau
                listView1.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            txtTenDangNhap.Clear();
            txtMaNV.Text = bus.PhatSinhMaTuDong().ToString();
            cmbQuyenHan.SelectedIndex = 1;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                NguoiDung u = (NguoiDung)listView1.SelectedItems[0].Tag;
                
                // Điền vào textbox
                txtMaNV.Text = u.MaNguoiDung.ToString();
                txtHoTen.Text = u.HoTen;
                txtTenDangNhap.Text = u.TenDangNhap;
                
                if (u.MaVaiTro == 1) cmbQuyenHan.SelectedIndex = 0;
                else cmbQuyenHan.SelectedIndex = 1;

                // Hiển thị thông tin vào DataGridView (chỉ 1 dòng của nhân viên này)
                var details = new List<object> {
                    new {
                        Mã_NV = u.MaNguoiDung,
                        Họ_Tên = u.HoTen,
                        Tên_ĐN = u.TenDangNhap,
                        Quyền = u.VaiTro != null ? u.VaiTro.TenVaiTro : "Chưa xác định"
                    }
                };
                dataGridView1.DataSource = details;
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên và tên đăng nhập!");
                return;
            }

            int maNV = int.Parse(txtMaNV.Text);
            dynamic selectedRole = cmbQuyenHan.SelectedItem;
            
            NguoiDung u = new NguoiDung
            {
                MaNguoiDung = maNV,
                HoTen = txtHoTen.Text,
                TenDangNhap = txtTenDangNhap.Text,
                MaVaiTro = selectedRole.Value
            };

            try
            {
                // Kiểm tra xem mã nhân viên đã tồn tại chưa để quyết định Thêm hay Sửa
                var existingIds = bus.LayTatCa().Select(x => x.MaNguoiDung).ToList();
                
                if (existingIds.Contains(maNV))
                {
                    bus.Sua(u);
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                }
                else
                {
                    bus.Them(u);
                    MessageBox.Show("Thêm nhân viên mới thành công!");
                }
                
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) return;
            int maND = int.Parse(txtMaNV.Text);

            DialogResult dr = MessageBox.Show("Xác nhận xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    bus.Xoa(maND);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

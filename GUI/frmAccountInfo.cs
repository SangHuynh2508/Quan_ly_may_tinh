using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;

namespace GUI
{
    public partial class frmAccountInfo : Form
    {
        public frmAccountInfo()
        {
            InitializeComponent();
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            NguoiDungBUS bus = new NguoiDungBUS();

            string ketQua = bus.UpdateUserFullName(CurrentUser.MaNguoiDung, txtHoTen.Text);

            if (ketQua == "Cập nhật thành công!")
            {
                // Cập nhật lại biến hệ thống để đồng bộ
                CurrentUser.HoTen = txtHoTen.Text;
                MessageBox.Show("Đã lưu thông tin!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAccountInfo_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = CurrentUser.TenDangNhap;
            txtMaVaiTro.Text = CurrentUser.VaiTro;
            txtHoTen.Text = CurrentUser.HoTen;
            txtTenDangNhap.ReadOnly = true;
            txtMaVaiTro.ReadOnly = true;
        }
    }
}
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
    public partial class frmChangePassword : Form
    {
        private NguoiDungBUS bus = new NguoiDungBUS();

        public frmChangePassword()
        {
            InitializeComponent();
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhan.UseSystemPasswordChar = true;

            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            btnThoat.Click += btnThoat_Click;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtMatKhauMoi.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtXacNhan.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maND = CurrentUser.MaNguoiDung;
            string oldPass = txtMatKhauCu.Text;
            string newPass = txtMatKhauMoi.Text;
            string confirmPass = txtXacNhan.Text;

            string result = bus.ChangePassword(maND, oldPass, newPass, confirmPass);
            MessageBox.Show(result);

            if (result == "Đổi mật khẩu thành công!")
            {
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

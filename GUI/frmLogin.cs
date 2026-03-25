using System;
using System.Windows.Forms;
using BUS;
using DAL;

namespace GUI
{
    public partial class frmLogin : Form
    {
        private LoginBUS loginBUS = new LoginBUS();

        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            NguoiDung user = loginBUS.CheckLogin(username, password);

            if (user != null)
            {
                CurrentUser.MaNguoiDung = user.MaNguoiDung;
                CurrentUser.TenDangNhap = user.TenDangNhap;
                CurrentUser.HoTen = user.HoTen;
                CurrentUser.VaiTro = user.VaiTro != null ? user.VaiTro.TenVaiTro : "";

                frmMain f = new frmMain();

                this.Hide();
                f.ShowDialog();

                if (f.IsLogout)
                {
                    ResetLoginForm();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void ResetLoginForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();

            CurrentUser.MaNguoiDung = 0;
            CurrentUser.TenDangNhap = null;
            CurrentUser.HoTen = null;
            CurrentUser.VaiTro = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
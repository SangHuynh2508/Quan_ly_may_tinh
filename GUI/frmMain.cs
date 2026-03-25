using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmMain : Form
    {
        public bool IsLogout { get; private set; } = false;

        public frmMain()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            lblWelcome.ForeColor = Color.FromArgb(33, 37, 41);
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            StyleButton(btnProduct, Color.FromArgb(0, 123, 255));
            StyleButton(btnCategory, Color.FromArgb(23, 162, 184));
            StyleButton(btnCustomer, Color.FromArgb(40, 167, 69));
            StyleButton(btnSupplier, Color.FromArgb(255, 193, 7));
            StyleButton(btnStaff, Color.FromArgb(111, 66, 193));
            StyleButton(btnLogout, Color.FromArgb(108, 117, 125));
            StyleButton(btnExit, Color.FromArgb(220, 53, 69));
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Xin chào: " + CurrentUser.HoTen;

            if (CurrentUser.VaiTro == "Nhân viên")
            {
                btnStaff.Enabled = false;
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct f = new frmProduct();
            f.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            f.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer f = new frmCustomer();
            f.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier f = new frmSupplier();
            f.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff f = new frmStaff();
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            IsLogout = true;

            CurrentUser.MaNguoiDung = 0;
            CurrentUser.TenDangNhap = null;
            CurrentUser.HoTen = null;
            CurrentUser.VaiTro = null;

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            IsLogout = false;
            this.Close();
        }
    }
}
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

            StyleButton(btnImport, Color.FromArgb(13, 110, 253));
            StyleButton(btnSales, Color.FromArgb(25, 135, 84));
            StyleButton(btnReportRevenue, Color.FromArgb(255, 128, 0));

            StyleButton(btnLogout, Color.FromArgb(108, 117, 125));
            StyleButton(btnExit, Color.FromArgb(220, 53, 69));

            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
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

        // Admin = MaVaiTro = 1
        private bool IsAdmin()
        {
            return CurrentUser.MaVaiTro == 1;
        }

        private void SetupRoleUI()
        {
            bool isAdmin = IsAdmin();

            
            btnStaff.Visible = isAdmin;
            btnStaff.Enabled = isAdmin;

            mnuStaff.Visible = isAdmin;
            mnuAdmin.Visible = isAdmin;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string roleName = CurrentUser.MaVaiTro == 1 ? "Admin" : "Nhân viên";
            lblWelcome.Text = "Xin chào: " + CurrentUser.HoTen + " (" + roleName + ")";
            SetupRoleUI();
        }

        private void OpenChildForm(Form form)
        {
            form.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProduct());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategory());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomer());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSupplier());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStaff());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmImport());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSales());
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReportRevenue());
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProduct());
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategory());
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomer());
        }

        private void mnuSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSupplier());
        }

        private void mnuStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStaff());
        }

        private void mnuImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmImport());
        }

        private void mnuSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSales());
        }

        private void mnuRevenueReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReportRevenue());
        }

        private void mnuAccountInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAccountInfo());
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChangePassword());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutSystem();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitSystem();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            LogoutSystem();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            ExitSystem();
        }

        private void LogoutSystem()
        {
            IsLogout = true;

            CurrentUser.MaNguoiDung = 0;
            CurrentUser.TenDangNhap = null;
            CurrentUser.HoTen = null;
            CurrentUser.VaiTro = null;
            CurrentUser.MatKhau = null;
            CurrentUser.MaVaiTro = 0;

            this.Close();
        }

        private void ExitSystem()
        {
            IsLogout = false;
            this.Close();
        }
    }
}
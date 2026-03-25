using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL;

namespace GUI
{
    public partial class frmReportRevenue : Form
    {
        private QLMayTinhDB dbContext;

        public frmReportRevenue()
        {
            InitializeComponent();
            dbContext = new QLMayTinhDB();
        }

        private void frmReportRevenue_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            // Tự động load báo cáo
            LoadReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

                // 1. Báo cáo doanh thu theo ngày
                var report = (from hd in dbContext.HoaDons
                              join ct in dbContext.ChiTietHoaDons on hd.MaHoaDon equals ct.MaHoaDon
                              join sp in dbContext.SanPhams on ct.MaSanPham equals sp.MaSanPham
                              where hd.NgayLap >= fromDate && hd.NgayLap <= toDate
                              group new { hd, ct, sp } by hd.NgayLap.Date into g
                              select new
                              {
                                  Ngay = g.Key,
                                  SoLuongHoaDon = g.Select(x => x.hd.MaHoaDon).Distinct().Count(),
                                  TongDoanhThu = g.Sum(x => x.ct.ThanhTien),
                                  TongLoiNhuan = g.Sum(x => x.ct.ThanhTien - (x.ct.SoLuong * x.sp.GiaNhap))
                              }).OrderBy(x => x.Ngay).ToList();

                dgvReport.DataSource = report;

                // Định dạng cột
                dgvReport.Columns["Ngay"].HeaderText = "Ngày";
                dgvReport.Columns["SoLuongHoaDon"].HeaderText = "Số hóa đơn";
                dgvReport.Columns["TongDoanhThu"].HeaderText = "Doanh thu";
                dgvReport.Columns["TongLoiNhuan"].HeaderText = "Lợi nhuận";

                dgvReport.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                dgvReport.Columns["TongLoiNhuan"].DefaultCellStyle.Format = "N0";
                dgvReport.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // 2. Tổng doanh thu và lợi nhuận
                var totals = (from hd in dbContext.HoaDons
                              join ct in dbContext.ChiTietHoaDons on hd.MaHoaDon equals ct.MaHoaDon
                              join sp in dbContext.SanPhams on ct.MaSanPham equals sp.MaSanPham
                              where hd.NgayLap >= fromDate && hd.NgayLap <= toDate
                              select new
                              {
                                  DoanhThu = ct.ThanhTien,
                                  LoiNhuan = ct.ThanhTien - (ct.SoLuong * sp.GiaNhap)
                              }).ToList();

                decimal totalRevenue = totals.Sum(x => x.DoanhThu);
                decimal totalProfit = totals.Sum(x => x.LoiNhuan);

                txtTotalRevenue.Text = totalRevenue.ToString("N0") + " VNĐ";
                txtTotalProfit.Text = totalProfit.ToString("N0") + " VNĐ";

                // 3. Top 10 sản phẩm bán chạy
                var topProducts = (from ct in dbContext.ChiTietHoaDons
                                   join hd in dbContext.HoaDons on ct.MaHoaDon equals hd.MaHoaDon
                                   join sp in dbContext.SanPhams on ct.MaSanPham equals sp.MaSanPham
                                   where hd.NgayLap >= fromDate && hd.NgayLap <= toDate
                                   group ct by new { ct.MaSanPham, sp.TenSanPham } into g
                                   select new
                                   {
                                       MaSanPham = g.Key.MaSanPham,
                                       TenSanPham = g.Key.TenSanPham,
                                       SoLuongBan = g.Sum(x => x.SoLuong),
                                       DoanhThu = g.Sum(x => x.ThanhTien)
                                   })
                                   .OrderByDescending(x => x.SoLuongBan)
                                   .Take(10)
                                   .ToList();

                dgvTopProducts.DataSource = topProducts;

                dgvTopProducts.Columns["MaSanPham"].HeaderText = "Mã SP";
                dgvTopProducts.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                dgvTopProducts.Columns["SoLuongBan"].HeaderText = "Số lượng bán";
                dgvTopProducts.Columns["DoanhThu"].HeaderText = "Doanh thu";

                dgvTopProducts.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";

                dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Xuất báo cáo Excel";
                saveFileDialog.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement export to Excel
                    // Bạn có thể sử dụng thư viện EPPlus hoặc ClosedXML để export
                    MessageBox.Show("Chức năng xuất Excel đang được phát triển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
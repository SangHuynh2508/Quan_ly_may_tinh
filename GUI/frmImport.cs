using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL;
using BUS;

namespace GUI
{
    public partial class frmImport : Form
    {
        private List<ImportDetail> importDetails;
        private decimal totalAmount = 0;
        private QLMayTinhDB dbContext;

        public class ImportDetail
        {
            public int MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGiaNhap { get; set; }
            public decimal ThanhTien { get; set; }
        }

        public frmImport()
        {
            InitializeComponent();
            dbContext = new QLMayTinhDB();
            importDetails = new List<ImportDetail>();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvImportDetails.AutoGenerateColumns = false;
            dgvImportDetails.Columns.Clear();

            dgvImportDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaSanPham",
                HeaderText = "Mã SP",
                DataPropertyName = "MaSanPham",
                Width = 80
            });

            dgvImportDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSanPham",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSanPham",
                Width = 300
            });

            dgvImportDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Width = 100
            });

            dgvImportDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGiaNhap",
                HeaderText = "Giá nhập",
                DataPropertyName = "DonGiaNhap",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvImportDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvImportDetails.DataSource = null;
        }

        private void RefreshGrid()
        {
            dgvImportDetails.DataSource = null;
            dgvImportDetails.DataSource = importDetails;
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadProducts();
            GenerateInvoiceNumber();
            dtpImportDate.Value = DateTime.Now;
            txtStaffName.Text = CurrentUser.HoTen;
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = dbContext.NhaCungCaps.ToList();
                cboSupplier.DataSource = suppliers;
                cboSupplier.DisplayMember = "TenNCC";
                cboSupplier.ValueMember = "MaNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = dbContext.SanPhams.ToList();
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "TenSanPham";
                cboProduct.ValueMember = "MaSanPham";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedValue != null && cboProduct.SelectedValue is int)
            {
                int productId = (int)cboProduct.SelectedValue;
                LoadProductPrice(productId);
            }
        }

        private void LoadProductPrice(int productId)
        {
            try
            {
                var product = dbContext.SanPhams.Find(productId);
                if (product != null)
                {
                    txtPrice.Text = product.GiaNhap.ToString("N0");
                    CalculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải giá sản phẩm: " + ex.Message);
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal price) && numQuantity.Value > 0)
            {
                decimal total = price * numQuantity.Value;
                txtTotal.Text = total.ToString("N0");
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (int)cboProduct.SelectedValue;
            string productName = cboProduct.Text;
            int quantity = (int)numQuantity.Value;
            decimal total = price * quantity;

            // Kiểm tra sản phẩm đã có trong danh sách chưa
            var existing = importDetails.FirstOrDefault(x => x.MaSanPham == productId);
            if (existing != null)
            {
                // Cập nhật số lượng
                existing.SoLuong += quantity;
                existing.ThanhTien = existing.DonGiaNhap * existing.SoLuong;
            }
            else
            {
                // Thêm mới
                importDetails.Add(new ImportDetail
                {
                    MaSanPham = productId,
                    TenSanPham = productName,
                    SoLuong = quantity,
                    DonGiaNhap = price,
                    ThanhTien = total
                });
            }

            UpdateTotalAmount();
            RefreshGrid();
            ClearInputFields();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvImportDetails.CurrentRow != null)
            {
                var detail = dgvImportDetails.CurrentRow.DataBoundItem as ImportDetail;
                if (detail != null)
                {
                    importDetails.Remove(detail);
                    UpdateTotalAmount();
                    RefreshGrid();
                }
            }
        }

        private void UpdateTotalAmount()
        {
            totalAmount = importDetails.Sum(x => x.ThanhTien);
            // Có thể thêm label hiển thị tổng tiền
        }

        private void ClearInputFields()
        {
            numQuantity.Value = 1;
            txtPrice.Clear();
            txtTotal.Clear();
            if (cboProduct.Items.Count > 0)
                cboProduct.SelectedIndex = -1;
        }

        private void GenerateInvoiceNumber()
        {
            txtInvoiceNumber.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (importDetails.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo phiếu nhập
                var phieuNhap = new PhieuNhap
                {
                    NgayNhap = dtpImportDate.Value,
                    MaNCC = (int)cboSupplier.SelectedValue,
                    MaNguoiDung = CurrentUser.MaNguoiDung,
                    TongTien = totalAmount
                };

                dbContext.PhieuNhaps.Add(phieuNhap);
                dbContext.SaveChanges();

                // Thêm chi tiết phiếu nhập và cập nhật tồn kho
                foreach (var detail in importDetails)
                {
                    var chiTiet = new ChiTietPhieuNhap
                    {
                        MaPhieuNhap = phieuNhap.MaPhieuNhap,
                        MaSanPham = detail.MaSanPham,
                        SoLuong = detail.SoLuong,
                        DonGiaNhap = detail.DonGiaNhap,
                        ThanhTien = detail.ThanhTien
                    };

                    dbContext.ChiTietPhieuNhaps.Add(chiTiet);

                    // Cập nhật số lượng tồn kho
                    var product = dbContext.SanPhams.Find(detail.MaSanPham);
                    if (product != null)
                    {
                        product.SoLuongTon += detail.SoLuong;
                        product.GiaNhap = detail.DonGiaNhap; // Cập nhật giá nhập mới
                    }
                }

                dbContext.SaveChanges();

                MessageBox.Show($"Nhập hàng thành công!\nMã phiếu nhập: {phieuNhap.MaPhieuNhap}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            importDetails.Clear();
            totalAmount = 0;
            RefreshGrid();
            GenerateInvoiceNumber();
            dtpImportDate.Value = DateTime.Now;
            if (cboSupplier.Items.Count > 0)
                cboSupplier.SelectedIndex = -1;
            ClearInputFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
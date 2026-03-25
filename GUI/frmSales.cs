using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using BUS;

namespace GUI
{
    public partial class frmSales : Form
    {
        private List<SaleDetail> cart;
        private decimal totalAmount = 0;
        private QLMayTinhDB dbContext;

        public class SaleDetail
        {
            public int MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGiaBan { get; set; }
            public decimal GiamGia { get; set; }
            public decimal ThanhTien { get; set; }
        }

        public frmSales()
        {
            InitializeComponent();
            dbContext = new QLMayTinhDB();
            cart = new List<SaleDetail>();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaSanPham",
                HeaderText = "Mã SP",
                DataPropertyName = "MaSanPham",
                Width = 80
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSanPham",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSanPham",
                Width = 300
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Width = 100
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGiaBan",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGiaBan",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GiamGia",
                HeaderText = "Giảm giá",
                DataPropertyName = "GiamGia",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.DataSource = null;
        }

        private void RefreshGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            GenerateInvoiceNumber();
            dtpSaleDate.Value = DateTime.Now;
            txtStaffName.Text = CurrentUser.HoTen;
            txtDiscount.Text = "0";
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = dbContext.KhachHangs.ToList();
                cboCustomer.DataSource = customers;
                cboCustomer.DisplayMember = "HoTen";
                cboCustomer.ValueMember = "MaKhachHang";

                // Thêm option khách lẻ
                cboCustomer.Items.Insert(0, new { MaKhachHang = 0, HoTen = "Khách lẻ" });
                cboCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = dbContext.SanPhams.Where(p => p.SoLuongTon > 0).ToList();
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
                    txtUnitPrice.Text = product.GiaBan.ToString("N0");
                    CalculateSubTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải giá sản phẩm: " + ex.Message);
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateSubTotal();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {
            if (decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), out decimal price) &&
                numQuantity.Value > 0)
            {
                decimal discount = decimal.TryParse(txtDiscount.Text.Replace(",", ""), out decimal d) ? d : 0;
                decimal total = price * numQuantity.Value;
                decimal subTotal = total - discount;
                txtSubTotal.Text = subTotal.ToString("N0");
            }
            else
            {
                txtSubTotal.Text = "0";
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

            int productId = (int)cboProduct.SelectedValue;
            var product = dbContext.SanPhams.Find(productId);

            if (product == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (product.SoLuongTon < numQuantity.Value)
            {
                MessageBox.Show($"Sản phẩm chỉ còn {product.SoLuongTon} sản phẩm trong kho!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), out decimal price) || price <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numQuantity.Value;
            decimal discount = decimal.TryParse(txtDiscount.Text.Replace(",", ""), out decimal d) ? d : 0;
            decimal total = price * quantity;
            decimal subTotal = total - discount;

            // Kiểm tra sản phẩm đã có trong giỏ chưa
            var existing = cart.FirstOrDefault(x => x.MaSanPham == productId);
            if (existing != null)
            {
                existing.SoLuong += quantity;
                existing.ThanhTien = (existing.DonGiaBan * existing.SoLuong) - existing.GiamGia;
            }
            else
            {
                cart.Add(new SaleDetail
                {
                    MaSanPham = productId,
                    TenSanPham = product.TenSanPham,
                    SoLuong = quantity,
                    DonGiaBan = price,
                    GiamGia = discount,
                    ThanhTien = subTotal
                });
            }

            UpdateTotalAmount();
            RefreshGrid();
            ClearInputFields();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                var detail = dgvCart.CurrentRow.DataBoundItem as SaleDetail;
                if (detail != null)
                {
                    cart.Remove(detail);
                    UpdateTotalAmount();
                    RefreshGrid();
                }
            }
        }

        private void UpdateTotalAmount()
        {
            totalAmount = cart.Sum(x => x.ThanhTien);
            txtTotal.Text = totalAmount.ToString("N0");
            CalculateChange();
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(txtAmountPaid.Text.Replace(",", ""), out decimal amountPaid))
            {
                decimal change = amountPaid - totalAmount;
                txtChange.Text = change >= 0 ? change.ToString("N0") : "0";
            }
            else
            {
                txtChange.Text = "0";
            }
        }

        private void ClearInputFields()
        {
            numQuantity.Value = 1;
            txtUnitPrice.Clear();
            txtDiscount.Text = "0";
            txtSubTotal.Clear();
            if (cboProduct.Items.Count > 0)
                cboProduct.SelectedIndex = -1;
        }

        private void GenerateInvoiceNumber()
        {
            txtInvoiceNumber.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmountPaid.Text.Replace(",", ""), out decimal amountPaid) || amountPaid < totalAmount)
            {
                MessageBox.Show($"Số tiền khách trả không đủ!\nTổng tiền: {totalAmount:N0} VNĐ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo hóa đơn
                var hoaDon = new HoaDon
                {
                    NgayLap = dtpSaleDate.Value,
                    MaKhachHang = GetCustomerId(),
                    MaNguoiDung = CurrentUser.MaNguoiDung,
                    TongTien = totalAmount,
                    GiamGia = cart.Sum(x => x.GiamGia),
                    ThanhToan = totalAmount
                };

                dbContext.HoaDons.Add(hoaDon);
                dbContext.SaveChanges();

                // Thêm chi tiết hóa đơn và cập nhật tồn kho
                foreach (var detail in cart)
                {
                    var chiTiet = new ChiTietHoaDon
                    {
                        MaHoaDon = hoaDon.MaHoaDon,
                        MaSanPham = detail.MaSanPham,
                        SoLuong = detail.SoLuong,
                        DonGiaBan = detail.DonGiaBan,
                        ThanhTien = detail.ThanhTien
                    };

                    dbContext.ChiTietHoaDons.Add(chiTiet);

                    // Cập nhật số lượng tồn kho
                    var product = dbContext.SanPhams.Find(detail.MaSanPham);
                    if (product != null)
                    {
                        product.SoLuongTon -= detail.SoLuong;
                    }
                }

                dbContext.SaveChanges();

                MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {hoaDon.MaHoaDon}\nTổng tiền: {totalAmount:N0} VNĐ\nKhách trả: {amountPaid:N0} VNĐ\nTiền thừa: {(amountPaid - totalAmount):N0} VNĐ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetCustomerId()
        {
            if (cboCustomer.SelectedValue != null)
            {
                var selected = cboCustomer.SelectedItem;
                var property = selected.GetType().GetProperty("MaKhachHang");
                if (property != null)
                {
                    int id = (int)property.GetValue(selected);
                    return id == 0 ? (int?)null : id;
                }
                return (int?)cboCustomer.SelectedValue;
            }
            return null;
        }

        private void ResetForm()
        {
            cart.Clear();
            totalAmount = 0;
            RefreshGrid();
            GenerateInvoiceNumber();
            dtpSaleDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            txtAmountPaid.Clear();
            txtTotal.Clear();
            txtChange.Clear();
            ClearInputFields();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
namespace GUI
{
    partial class frmImport
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvImportDetails;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblImportDate;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.TextBox txtStaffName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvImportDetails = new System.Windows.Forms.DataGridView();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportDetails
            // 
            this.dgvImportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportDetails.Location = new System.Drawing.Point(14, 250);
            this.dgvImportDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvImportDetails.Name = "dgvImportDetails";
            this.dgvImportDetails.RowHeadersWidth = 62;
            this.dgvImportDetails.Size = new System.Drawing.Size(968, 438);
            this.dgvImportDetails.TabIndex = 0;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(135, 38);
            this.cboSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(281, 28);
            this.cboSupplier.TabIndex = 1;
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(135, 88);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(393, 28);
            this.cboProduct.TabIndex = 2;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(135, 138);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(112, 26);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(135, 188);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(168, 26);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(387, 137);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(168, 26);
            this.txtTotal.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(672, 138);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 38);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm vào phiếu";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(844, 700);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 38);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Xóa dòng";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(720, 700);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu phiếu nhập";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(596, 700);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(34, 41);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(111, 20);
            this.lblSupplier.TabIndex = 10;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(34, 91);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(86, 20);
            this.lblProduct.TabIndex = 11;
            this.lblProduct.Text = "Sản phẩm:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(34, 140);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(76, 20);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(34, 191);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(78, 20);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "Giá nhập:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(293, 140);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 20);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Thành tiền:";
            // 
            // lblImportDate
            // 
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Location = new System.Drawing.Point(562, 41);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(89, 20);
            this.lblImportDate.TabIndex = 15;
            this.lblImportDate.Text = "Ngày nhập:";
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpImportDate.Location = new System.Drawing.Point(652, 38);
            this.dtpImportDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(157, 26);
            this.dtpImportDate.TabIndex = 16;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(652, 88);
            this.txtInvoiceNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(157, 26);
            this.txtInvoiceNumber.TabIndex = 17;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(562, 91);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(101, 20);
            this.lblInvoiceNumber.TabIndex = 18;
            this.lblInvoiceNumber.Text = "Số phiếu NK:";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(592, 138);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(83, 20);
            this.lblStaff.TabIndex = 19;
            this.lblStaff.Text = "Nhân viên:";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(790, 134);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(157, 26);
            this.txtStaffName.TabIndex = 20;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 758);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.dtpImportDate);
            this.Controls.Add(this.lblImportDate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.dgvImportDetails);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmImport";
            this.Text = "Quản lý Nhập hàng";
            this.Load += new System.EventHandler(this.frmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
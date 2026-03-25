namespace GUI
{
    partial class frmReportRevenue
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.TextBox txtTotalRevenue;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.TextBox txtTotalProfit;
        private System.Windows.Forms.Label lblTopProducts;
        private System.Windows.Forms.DataGridView dgvTopProducts;

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
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.txtTotalRevenue = new System.Windows.Forms.TextBox();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.txtTotalProfit = new System.Windows.Forms.TextBox();
            this.lblTopProducts = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(112, 25);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(134, 26);
            this.dtpFromDate.TabIndex = 0;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(112, 62);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(134, 26);
            this.dtpToDate.TabIndex = 1;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(281, 25);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(112, 38);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "Xem báo cáo";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(281, 62);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(112, 38);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(14, 125);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 62;
            this.dgvReport.Size = new System.Drawing.Size(968, 312);
            this.dgvReport.TabIndex = 4;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(22, 29);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 20);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(22, 66);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(81, 20);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(450, 25);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(125, 20);
            this.lblTotalRevenue.TabIndex = 7;
            this.lblTotalRevenue.Text = "Tổng doanh thu:";
            // 
            // txtTotalRevenue
            // 
            this.txtTotalRevenue.Location = new System.Drawing.Point(581, 25);
            this.txtTotalRevenue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalRevenue.Name = "txtTotalRevenue";
            this.txtTotalRevenue.ReadOnly = true;
            this.txtTotalRevenue.Size = new System.Drawing.Size(168, 26);
            this.txtTotalRevenue.TabIndex = 8;
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Location = new System.Drawing.Point(450, 59);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(117, 20);
            this.lblTotalProfit.TabIndex = 9;
            this.lblTotalProfit.Text = "Tổng lợi nhuận:";
            // 
            // txtTotalProfit
            // 
            this.txtTotalProfit.Location = new System.Drawing.Point(581, 56);
            this.txtTotalProfit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalProfit.Name = "txtTotalProfit";
            this.txtTotalProfit.ReadOnly = true;
            this.txtTotalProfit.Size = new System.Drawing.Size(168, 26);
            this.txtTotalProfit.TabIndex = 10;
            // 
            // lblTopProducts
            // 
            this.lblTopProducts.AutoSize = true;
            this.lblTopProducts.Location = new System.Drawing.Point(22, 462);
            this.lblTopProducts.Name = "lblTopProducts";
            this.lblTopProducts.Size = new System.Drawing.Size(204, 20);
            this.lblTopProducts.TabIndex = 11;
            this.lblTopProducts.Text = "Top 10 sản phẩm bán chạy:";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Location = new System.Drawing.Point(14, 488);
            this.dgvTopProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.RowHeadersWidth = 62;
            this.dgvTopProducts.Size = new System.Drawing.Size(968, 250);
            this.dgvTopProducts.TabIndex = 12;
            // 
            // frmReportRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 758);
            this.Controls.Add(this.dgvTopProducts);
            this.Controls.Add(this.lblTopProducts);
            this.Controls.Add(this.txtTotalProfit);
            this.Controls.Add(this.lblTotalProfit);
            this.Controls.Add(this.txtTotalRevenue);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReportRevenue";
            this.Text = "Báo cáo Doanh thu & Lợi nhuận";
            this.Load += new System.EventHandler(this.frmReportRevenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
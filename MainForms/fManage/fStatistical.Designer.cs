
namespace MainForms.fManage
{
    partial class fStatistical
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fStatistical));
            this.panel1 = new System.Windows.Forms.Panel();
            this.nupTo = new System.Windows.Forms.NumericUpDown();
            this.nudfrom = new System.Windows.Forms.NumericUpDown();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblInvoiceNum = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtgvDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrinkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgvBill = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Snow;
            this.panel1.Controls.Add(this.nupTo);
            this.panel1.Controls.Add(this.nudfrom);
            this.panel1.Controls.Add(this.lblTotalMoney);
            this.panel1.Controls.Add(this.lblInvoiceNum);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtgvDetail);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtgvBill);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 709);
            this.panel1.TabIndex = 0;
            // 
            // nupTo
            // 
            this.nupTo.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupTo.Location = new System.Drawing.Point(524, 117);
            this.nupTo.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupTo.Name = "nupTo";
            this.nupTo.Size = new System.Drawing.Size(159, 31);
            this.nupTo.TabIndex = 37;
            this.nupTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudfrom
            // 
            this.nudfrom.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudfrom.Location = new System.Drawing.Point(328, 117);
            this.nudfrom.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudfrom.Name = "nudfrom";
            this.nudfrom.Size = new System.Drawing.Size(159, 31);
            this.nudfrom.TabIndex = 36;
            this.nudfrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.BackColor = System.Drawing.Color.White;
            this.lblTotalMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI Symbol", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalMoney.Location = new System.Drawing.Point(675, 634);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(324, 49);
            this.lblTotalMoney.TabIndex = 35;
            this.lblTotalMoney.Text = "100.000 VND";
            this.lblTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvoiceNum
            // 
            this.lblInvoiceNum.BackColor = System.Drawing.Color.White;
            this.lblInvoiceNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInvoiceNum.Font = new System.Drawing.Font("Segoe UI Symbol", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceNum.Location = new System.Drawing.Point(232, 634);
            this.lblInvoiceNum.Name = "lblInvoiceNum";
            this.lblInvoiceNum.Size = new System.Drawing.Size(104, 49);
            this.lblInvoiceNum.TabIndex = 34;
            this.lblInvoiceNum.Text = "10";
            this.lblInvoiceNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(503, 644);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 32);
            this.label12.TabIndex = 31;
            this.label12.Text = "Total Money:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(21, 644);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 32);
            this.label11.TabIndex = 30;
            this.label11.Text = "Invoice Number:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(534, 168);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(299, 31);
            this.dateTo.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(490, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 28);
            this.label10.TabIndex = 28;
            this.label10.Text = "To:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(178, 168);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(300, 31);
            this.dateFrom.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(110, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 28);
            this.label9.TabIndex = 26;
            this.label9.Text = "From:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgvDetail
            // 
            this.dtgvDetail.AllowUserToAddRows = false;
            this.dtgvDetail.BackgroundColor = System.Drawing.Color.Snow;
            this.dtgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.BillId,
            this.DrinkId,
            this.Quantity});
            this.dtgvDetail.Location = new System.Drawing.Point(503, 250);
            this.dtgvDetail.MultiSelect = false;
            this.dtgvDetail.Name = "dtgvDetail";
            this.dtgvDetail.ReadOnly = true;
            this.dtgvDetail.RowHeadersWidth = 62;
            this.dtgvDetail.RowTemplate.Height = 33;
            this.dtgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDetail.Size = new System.Drawing.Size(506, 359);
            this.dtgvDetail.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // BillId
            // 
            this.BillId.HeaderText = "Bill\'s Id";
            this.BillId.MinimumWidth = 8;
            this.BillId.Name = "BillId";
            this.BillId.ReadOnly = true;
            this.BillId.Width = 150;
            // 
            // DrinkId
            // 
            this.DrinkId.HeaderText = "DrinkId";
            this.DrinkId.MinimumWidth = 8;
            this.DrinkId.Name = "DrinkId";
            this.DrinkId.ReadOnly = true;
            this.DrinkId.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(719, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 28);
            this.label8.TabIndex = 24;
            this.label8.Text = "Bill Details";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(216, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 28);
            this.label7.TabIndex = 23;
            this.label7.Text = "Bill";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(945, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 50);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(493, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 41);
            this.label6.TabIndex = 20;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(270, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "Price:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(705, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 50);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(328, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(355, 34);
            this.txtSearch.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(254, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 28);
            this.label4.TabIndex = 15;
            this.label4.Text = "Search:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgvBill
            // 
            this.dtgvBill.AllowUserToAddRows = false;
            this.dtgvBill.BackgroundColor = System.Drawing.Color.Snow;
            this.dtgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Id,
            this.StaffId,
            this.DayOfSale,
            this.Discount,
            this.Total});
            this.dtgvBill.Location = new System.Drawing.Point(0, 250);
            this.dtgvBill.MultiSelect = false;
            this.dtgvBill.Name = "dtgvBill";
            this.dtgvBill.ReadOnly = true;
            this.dtgvBill.RowHeadersWidth = 62;
            this.dtgvBill.RowTemplate.Height = 33;
            this.dtgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvBill.Size = new System.Drawing.Size(497, 359);
            this.dtgvBill.TabIndex = 4;
            this.dtgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvBill_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "#";
            this.STT.MinimumWidth = 8;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 35;
            // 
            // StaffId
            // 
            this.StaffId.HeaderText = "StaffId";
            this.StaffId.MinimumWidth = 8;
            this.StaffId.Name = "StaffId";
            this.StaffId.ReadOnly = true;
            this.StaffId.Width = 65;
            // 
            // DayOfSale
            // 
            this.DayOfSale.HeaderText = "Day";
            this.DayOfSale.MinimumWidth = 8;
            this.DayOfSale.Name = "DayOfSale";
            this.DayOfSale.ReadOnly = true;
            this.DayOfSale.Width = 95;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.MinimumWidth = 8;
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 85;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 8;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1009, 49);
            this.label1.TabIndex = 3;
            this.label1.Text = "STATISTICAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "fStatistical";
            this.Size = new System.Drawing.Size(1009, 709);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dtgvDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblInvoiceNum;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrinkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.NumericUpDown nupTo;
        private System.Windows.Forms.NumericUpDown nudfrom;
    }
}

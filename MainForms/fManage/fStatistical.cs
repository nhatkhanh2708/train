using MainForms.Controllers;
using System;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fStatistical : UserControl
    {
        private BillController billController;
        private BillDetailController detailController;

        public fStatistical()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            loadBills(null, null, null, null, null);
        }

        private void loadBills(string seachString, DateTime? dayFrom, DateTime? dayTo, Decimal? priceFrom, Decimal? priceTo)
        {
            if (billController == null)
                billController = new BillController();

            var bills = billController.Gets(seachString, dayFrom, dayTo, priceFrom, priceTo);
            dtgvBill.Rows.Clear();

            decimal totalbill = 0;
            foreach(var b in bills)
            {
                var total = billController.GetTotal(b.Id);
                var discount = billController.GetDiscount(b.Id);
                var _tt = total - (total * discount) / 100;
                dtgvBill.Rows.Add(dtgvBill.Rows.Count + 1, b.Id.ToString(), b.StaffId.ToString(), b.DayOfSale, discount.ToString(), _tt.ToString("#,##"));
                totalbill += _tt;
            }
            var num = dtgvBill.Rows.Count;
            lblInvoiceNum.Text = num.ToString();
            lblTotalMoney.Text = totalbill.ToString("#,##");
        }

        private void loadBillDetails(int billId)
        {
            if (detailController == null)
                detailController = new BillDetailController();
            var detail = detailController.Gets(billId);
            dtgvDetail.Rows.Clear();
            foreach(var d in detail)
            {
                dtgvDetail.Rows.Add(dtgvDetail.Rows.Count + 1, d.Id.ToString(), d.BillId.ToString(), d.DrinkId.ToString(), d.Quantity.ToString());
            }
        }

        private void dtgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dtgvBill.NewRowIndex || e.RowIndex < 0)
                return;
            var id = (string)dtgvBill.Rows[e.RowIndex].Cells["Id"].Value;
            loadBillDetails(Int32.Parse(id));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadBills(null, null, null, null, null);
            txtSearch.Text = "";
            nudfrom.Value = 0;
            nupTo.Value = 0;
            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var s = txtSearch.Text;
            decimal? pf = nudfrom.Value == 0? null: nudfrom.Value;
            decimal? pt = nupTo.Value==0? null:nupTo.Value;
            var df = dateFrom.Value;
            var dt = dateTo.Value;
            if(DateTime.Compare(df, dt) >= 0)
                loadBills(s, df, dt, null, null);
            else
                loadBills(s, df, dt, pf, pt);
        }
    }
}

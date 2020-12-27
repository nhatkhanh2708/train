using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainForms.fSell
{
    public partial class fPromotion_Cf : Form
    {
        private int indexRow;
        public fPromotion_Cf()
        {
            InitializeComponent();
            load();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void load()
        {
            var pros = new PromotionController().Gets(null, null, null, 0);
            var pro_detail = new PromotionDetailController();
            List<PromotionDetailDto> list = new List<PromotionDetailDto>();
            foreach(var p in pros) {
                list.AddRange(pro_detail.Gets(p.Id));
            }

            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["PromotionId"].Visible = false;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            var id = row.Cells["Id"].Value.ToString();
            var discount =(decimal) row.Cells["Discount"].Value;
            fSellCoffee.GetProDetailId(Int32.Parse(id), discount);
            Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            var title = (string)dataGridView1.Rows[e.RowIndex].Cells["Content"].Value;
            lblTitle.Text = title;
            var discount = dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            lblDiscount.Text = discount + " %";
            indexRow = e.RowIndex;
        }
    }
}

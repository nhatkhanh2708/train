using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fPromotion : UserControl
    {
        BindingSource tblPro = new BindingSource();
        BindingSource tblDetail = new BindingSource();

        private PromotionController promotionController;
        private PromotionDetailController promotionDetailController;

        private bool flagBindingDetail = false;

        private readonly string comingsoon = "Coming Soon";
        private readonly string still = "Still";
        private readonly string expired = "Expired";

        public fPromotion()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            dtgvPro.DataSource = tblPro;
            dtgvDetail.DataSource = tblDetail;
            if (promotionController == null)
                promotionController = new PromotionController();

            promotionController.UpdateStatusByTimeNow();
            loadPromotions(null, null, null, null);            
            addBinding();
        }

        private void loadPromotions(string searchString, DateTime? start, DateTime? finish, sbyte? status)
        {
            if (promotionController == null)
                promotionController = new PromotionController();

            tblPro.DataSource = promotionController.Gets(searchString, start, finish, status).ToList();
        }

        private void loadDetail(int PromotionId)
        {
            if (promotionDetailController == null)
                promotionDetailController = new PromotionDetailController();

                tblDetail.DataSource = promotionDetailController.Gets(PromotionId).ToList();

            if (!flagBindingDetail)
            {
                addBindingDetail();
                flagBindingDetail = true;
            }
        }

        private void loadCbxDetail(int promotionId)
        {
            var promotion = promotionController.Get(promotionId);
            List<PromotionDto> list = new List<PromotionDto>();
            if(promotion.Status == -1)
            {
                list.Add(promotion);
            }
            else
            {
                var list1 = promotionController.Gets(null, null, null, 0).ToList();
                var list2 = promotionController.Gets(null, null, null, 1).ToList();
                list.AddRange(list1);
                list.AddRange(list2);
            }

            cbxPromotion.DataSource = list;
            cbxPromotion.DisplayMember = "Title";
        }

        private void addBinding()
        {
            txtId.DataBindings.Add(new Binding("Text", dtgvPro.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtTitle.DataBindings.Add(new Binding("Text", dtgvPro.DataSource, "Title", true, DataSourceUpdateMode.Never));
            dateStart.DataBindings.Add(new Binding("Value", dtgvPro.DataSource, "StartDate", true, DataSourceUpdateMode.Never));
            dateFinish.DataBindings.Add(new Binding("Value", dtgvPro.DataSource, "FinishDate", true, DataSourceUpdateMode.Never));
        }

        private void addBindingDetail()
        {
            txtDetailId.DataBindings.Add(new Binding("Text", dtgvDetail.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtContent.DataBindings.Add(new Binding("Text", dtgvDetail.DataSource, "Content", true, DataSourceUpdateMode.Never));
            nudDiscount.DataBindings.Add(new Binding("Value", dtgvDetail.DataSource, "Discount", true, DataSourceUpdateMode.Never));
        }

        private void refresh()
        {
            loadPromotions(null, null, null, null);
            txtSearch.Text = "";
            cbxStatus.SelectedIndex = 0;
            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
            MakeEmpty();
            DetailMakeEmpty();
        }

        private void MakeEmpty()
        {
            lblStatus.Text = "";
            txtId.Text = "";
            txtTitle.Text = "";
            dateStart.Value = DateTime.Now;
            dateFinish.Value = DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void ChangeBtnDetail(bool status)
        {
            btnAddDetail.Visible = status;
            btnEditDetail.Visible = status;
            btnDeleteDetail.Visible = status;
        }

        private void ChangeBtnPro(bool stop, bool delete)
        {
            btnDeletePro.Visible = delete;
            btnStop.Visible = stop;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (dtgvPro.SelectedCells.Count > 0 && !string.IsNullOrEmpty(txtId.Text))
            {
                var status = (sbyte)dtgvPro.SelectedCells[0].OwningRow.Cells["Status"].Value;
                btnDetailMakeEmpty.Visible = true;

                string _messstt = "";
                if (status == -1)
                {
                    _messstt = expired;
                    ChangeBtnPro(false, false);
                    ChangeBtnDetail(false);
                    btnDetailMakeEmpty.Visible = false;

                }
                else if (status == 0)
                {
                    _messstt = still;
                    ChangeBtnPro(true, false);
                    ChangeBtnDetail(true);
                }
                else
                {
                    _messstt = comingsoon;
                    ChangeBtnPro(false, true);
                    ChangeBtnDetail(true);
                }
                int id = (int)dtgvPro.SelectedCells[0].OwningRow.Cells["Id"].Value;
                lblStatus.Text = _messstt;
                loadCbxDetail(id);
                loadDetail(id);
            }
            else
                dtgvDetail.Rows.Clear();
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            var startdate = dateStart.Value;
            var finishdate = dateFinish.Value;
            var status = promotionController.GetStatus(startdate, finishdate);

            promotionController.Create(
                new PromotionDto()
                {
                    Title = title,
                    StartDate = startdate,
                    FinishDate = finishdate,
                    Status = status
                });

            MessageBox.Show("You added promotion successfully", "Notification");
            loadTable();
        }

        private void btnEditPro_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (!string.IsNullOrEmpty(id))
            {
                string title = txtTitle.Text;
                var startdate = dateStart.Value;
                var finishdate = dateFinish.Value;
                var status = promotionController.GetStatus(startdate, finishdate);

                var promotion = promotionController.Get(Int32.Parse(id));
                promotion.Title = title;
                promotion.StartDate = startdate;
                promotion.FinishDate = finishdate;
                promotion.Status = status;

                promotionController.Update(promotion);

                MessageBox.Show("You updated promotion successfully", "Notification");
                loadTable();
            }
        }

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                promotionController.Delete(Int32.Parse(id));

                MessageBox.Show("You deleted promotion successfully", "Notification");
                loadTable();
            }
        }

        private void txtDetailId_TextChanged(object sender, EventArgs e)
        {
            if (dtgvDetail.SelectedCells.Count > 0 && !string.IsNullOrEmpty(txtDetailId.Text))
            {
                int id = (int)dtgvDetail.SelectedCells[0].OwningRow.Cells["PromotionId"].Value;
                int index = -1;
                int i = 0;

                foreach (PromotionDto c in cbxPromotion.Items)
                {
                    if (c.Id == id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbxPromotion.SelectedIndex = index;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (!string.IsNullOrEmpty(id))
            {
                var promotion = promotionController.Get(Int32.Parse(id));
                promotion.Status = -1;

                promotionController.Update(promotion);

                MessageBox.Show("You stopped promotion successfully", "Notification");
                loadTable();
            }
        }

        private void DetailMakeEmpty()
        {
            cbxPromotion.SelectedIndex = 0;
            txtDetailId.Text = "";
            nudDiscount.Value = 0;
            txtContent.Text = "";
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var promotion = (PromotionDto) cbxPromotion.SelectedValue;
            int id = promotion.Id;
            string content = txtContent.Text;
            int discount = (int)nudDiscount.Value;
            promotionDetailController.Create(new PromotionDetailDto()
            {
                PromotionId = id,
                Content = content,
                Discount = discount
            });

            MessageBox.Show("You added promotion detail successfully", "Notification");
            loadDetail(id);
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            string idDetail = txtDetailId.Text;
            if (!string.IsNullOrEmpty(idDetail))
            {
                var promotion = (PromotionDto)cbxPromotion.SelectedValue;
                int promotionid = promotion.Id;
                string content = txtContent.Text;
                int discount = (int)nudDiscount.Value;

                var detail = promotionDetailController.Get(Int32.Parse(idDetail));
                detail.PromotionId = promotionid;
                detail.Content = content;
                detail.Discount = discount;

                promotionDetailController.Update(detail);
                MessageBox.Show("You updated promotion detail successfully", "Notification");
                loadDetail(Int32.Parse(txtId.Text));
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            string _idDetail = txtDetailId.Text;
            if (!string.IsNullOrEmpty(_idDetail))
            {
                promotionDetailController.Delete(Int32.Parse(_idDetail));

                MessageBox.Show("You deleted promotion detail successfully", "Notification");
                loadDetail(Int32.Parse(txtId.Text));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            DateTime? from = null;
            DateTime? to = null;
            if (GetCompareDateFrom_To())
            {
                from = dateFrom.Value;
                to = dateTo.Value;
            }
            var search = txtSearch.Text;
            var stt = GetStatus_Search();
            loadPromotions(search, from, to, stt);
        }

        private sbyte? GetStatus_Search()
        {
            var status = cbxStatus.SelectedItem.ToString();
            sbyte? stt = null;
            if (status == comingsoon)
                stt = 1;
            else if (status == still)
                stt = 0;
            else if (status == expired)
                stt = -1;
            return stt;
        }

        private bool GetCompareDateFrom_To()
        {
            var to = dateTo.Value;
            var from = dateFrom.Value;
            var _compareto = DateTime.Compare(DateTime.Now, to);
            var _comparefrom = DateTime.Compare(DateTime.Now, from);
            return (DateTime.Compare(from, to) >= 0 || (_comparefrom == 0 && _compareto == 0)) ? false : true;
        }

        private void btnMakeEmpty_Click(object sender, EventArgs e)
        {
            MakeEmpty();
        }

        private void btnDetailMakeEmpty_Click(object sender, EventArgs e)
        {
            DetailMakeEmpty();
        }
    }
}

using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fSell
{
    public partial class fSellCoffee : Form
    {
        private readonly int staffId;
        private DrinkController drinkController;
        private int indexRow;
        private static int? proDetailId = null;
        private static decimal discount = 0;
        private Dictionary<int, int> list_drink;
        private int drinkId;
        private int total = 0;
        private int pay = 0;
        public fSellCoffee(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            load();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(" Do you want to exit ? ", "Exit", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                //nothing in here
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void load()
        {
            loadName_Date();
            loadCbxCategories();
            loadflp(null, null);
        }

        private void loadName_Date()
        {
            var staff = new StaffController().Get(staffId);
            lblNameStaff.Text = staff.Name;
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void loadCbxCategories()
        {
            var categories = new DrinkCategoryController().Gets(null).ToList();

            foreach (var c in categories)
            {
                cbxCategories.Items.Add(c);
            }
            cbxCategories.DisplayMember = "Title";
        }

        private void loadflp(int? category, string searchString)
        {
            if (drinkController == null)
                drinkController = new DrinkController();

            var drinks = drinkController.Gets(category, searchString, null, null, true);
            foreach (var d in drinks)
            {
                Create_pnl(d);
            }
        }

        private void Create_pnl(DrinkDto drink)
        {
            var pic = new PictureBox();
            pic.Width = 235;
            pic.Height = 235;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.Cursor = Cursors.Hand;

            Image img = null;
            if (drink.Img != null)
                img = ImageStatic.ConvertBinary2Img(drink.Img);
            pic.BackgroundImage = img;

            var _lblname = new Label();
            _lblname.Text = drink.Name;
            _lblname.Dock = DockStyle.Bottom;
            _lblname.Height = 55;
            _lblname.TextAlign = ContentAlignment.MiddleCenter;
            _lblname.BackColor = Color.FromArgb(241, 242, 246);
            _lblname.ForeColor = Color.FromArgb(0,0,0);
            _lblname.Font = new Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pic.Controls.Add(_lblname);

            var _lblprice = new Label();
            _lblprice.Text = drink.Price.ToString("#,##");
            _lblprice.TextAlign = ContentAlignment.MiddleCenter;
            _lblprice.Height = 35;
            _lblprice.Width = 100;
            _lblprice.BackColor = Color.FromArgb(55, 66, 250);
            _lblprice.ForeColor = Color.FromArgb(255, 255, 255);
            _lblprice.Font = new Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pic.Controls.Add(_lblprice);

            flowLayoutPanel1.Controls.Add(pic);
            pic.Tag = drink.Id.ToString();
            pic.Click += new EventHandler(OnClick);
        }

        private void OnClick(object sender, EventArgs e)
        {
            string id = ((PictureBox)sender).Tag.ToString();
            var drink = drinkController.Get(Int32.Parse(id));
            lblName.Text = drink.Name;
            lblPrice.Text = drink.Price.ToString("#,##");
            drinkId = drink.Id;
            bool flag = false;
            int _num = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(Int32.Parse(row.Cells["Id"].Value.ToString()) == drink.Id)
                {
                    _num = Int32.Parse(row.Cells["Number"].Value.ToString());
                    indexRow = row.Index;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                btnOrder.Enabled = false;
                ChangeBtn(false, true);   
            }
            else
            {
                btnOrder.Enabled = true;
                ChangeBtn(true, false);
            }
            numericUpDown1.Value = _num;
        }

        private int? GetCategoryId()
        {
            if (cbxCategories.SelectedIndex == 0)
                return null;
            var category = (DrinkCategoryDto) cbxCategories.SelectedItem;
            return category.Id;            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            txtSearch.Text = "";
            cbxCategories.SelectedIndex = 0;
            loadflp(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var categoryId = GetCategoryId();
            var search = txtSearch.Text;
            flowLayoutPanel1.Controls.Clear();
            loadflp(categoryId, search);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            add();
        }

        private void add()
        {
            dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, drinkId.ToString(), lblName.Text, lblPrice.Text, numericUpDown1.Value.ToString());
            if (list_drink == null)
                list_drink = new Dictionary<int, int>();
            list_drink.Add(drinkId,(int) numericUpDown1.Value);
            var _price = lblPrice.Text;
            total += (int) decimal.Parse(_price) * (int) numericUpDown1.Value;
            Setlbl();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                var drink = (string)dataGridView1.Rows[e.RowIndex].Cells["Drink"].Value;
                if(lblName.Text == drink)
                {
                    lblName.Text = "";
                    lblPrice.Text = "";
                    numericUpDown1.Value = 1;
                }

                var id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var price = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                var num = dataGridView1.Rows[e.RowIndex].Cells["Number"].Value.ToString();
                total -= Int32.Parse(price) * Int32.Parse(num);
                list_drink.Remove(Int32.Parse(id));
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                Setlbl();
            }
            else
            {
                var drink =(string) dataGridView1.Rows[e.RowIndex].Cells["Drink"].Value;
                lblName.Text = drink;
                var price = (string)dataGridView1.Rows[e.RowIndex].Cells["Price"].Value;
                lblPrice.Text = price.ToString();
                var num = (string)dataGridView1.Rows[e.RowIndex].Cells["Number"].Value;
                numericUpDown1.Value = Int32.Parse(num);
                ChangeBtn(false, true);
                indexRow = e.RowIndex;
            }
        }

        private void ChangeBtn(bool order, bool update)
        {
            btnUpdate.Visible = update;
            btnOrder.Visible = order;
        }

        private void btnAllDelete_Click(object sender, EventArgs e)
        {
            SetEmpty();
            ChangeBtn(true, false);
            btnOrder.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow updateRow = dataGridView1.Rows[indexRow];
            var _price = updateRow.Cells["Price"].Value.ToString();
            var _num_old = updateRow.Cells["Number"].Value.ToString();
            total -= (int) decimal.Parse(_price) * Int32.Parse(_num_old);
            updateRow.Cells["Number"].Value = numericUpDown1.Value.ToString();
            var _num_new = (int) numericUpDown1.Value;
            total += (int) decimal.Parse(_price) * _num_new;
            var id = updateRow.Cells["Id"].Value.ToString();
            list_drink[Int32.Parse(id)] =(int) numericUpDown1.Value;
            Setlbl();
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            var pro = new fPromotion_Cf();
            pro.ShowDialog();
            loadPro();
        }

        public static void GetProDetailId(int id, decimal _discount)
        {
            proDetailId = id;
            discount = _discount;
        }

        private void loadPro()
        {
            if(proDetailId != null)
            {
                btnDelPro.Visible = true;
            }
            else
            {
                btnDelPro.Visible = false;
            }
            lblDiscount.Text = discount.ToString();
        }

        private void btnDelPro_Click(object sender, EventArgs e)
        {
            proDetailId = null;
            discount = 0;
            lblDiscount.Text = discount.ToString();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var bill = new BillDto()
            {
                DayOfSale = DateTime.Now,
                PromotionDetailId = proDetailId,
                StaffId = staffId
            };
            var billctrl = new BillController();
            billctrl.Create(bill);
            
            var billDetailctrl = new BillDetailController();
            var billId = billctrl.GetIdLast();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var id = row.Cells["Id"].Value.ToString();
                var num = row.Cells["Number"].Value.ToString();
                var billDetail = new BillDetailDto()
                {
                    BillId = billId,
                    DrinkId = Int32.Parse(id),
                    Quantity = Int32.Parse(num)
                };
                billDetailctrl.Create(billDetail);
            }
            MessageBox.Show("You paymented successfully", "Notification");
            SetEmpty();
            refresh();
        }

        private void SetEmpty()
        {
            lblName.Text = "";
            lblDiscount.Text = "0";
            lblPrice.Text = "";
            lblPay.Text = "0";
            lblTotal.Text = "0";
            numericUpDown1.Value = 1;
            dataGridView1.Rows.Clear();
            discount = 0;
            proDetailId = null;
            list_drink = null;
            total = 0;
            pay = 0;
        }

        private void Setlbl()
        {
            lblTotal.Text = total.ToString("#,##");
            pay = total - (total *(int) discount) / 100;
            lblPay.Text = pay.ToString("#,##");
        }

        private void lblDiscount_TextChanged(object sender, EventArgs e)
        {
            pay = total - (total * (int) discount) / 100;
            lblPay.Text = pay.ToString("#,##");
        }
    }
}

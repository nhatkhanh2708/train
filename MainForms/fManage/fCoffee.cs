using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fCoffee : UserControl
    {
        private BindingSource tblDrink = new BindingSource();

        private DrinkController drinkController;
        private DrinkCategoryController drinkCategoryController;

        private string fileImg = "";

        public fCoffee()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            dataGridView1.DataSource = tblDrink;
            loadDrinks(null, null, null, null, null);
            loadCategories();
            addBinding();            
        }

        private void loadDrinks(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status)
        {
            if(drinkController == null)
                drinkController = new DrinkController();

            tblDrink.DataSource = drinkController.Gets(drinkCategoryId, searchString, priceFrom, priceTo, status).ToList();
            dataGridView1.Columns["Img"].Visible = false;
        }

        private void loadCategories()
        {
            if(drinkCategoryController == null)
                drinkCategoryController = new DrinkCategoryController();

            cbxCategory.DataSource = drinkCategoryController.Gets(null).ToList();
            cbxCategory.DisplayMember = "Title";

            var categories = drinkCategoryController.Gets(null).ToList();
            foreach (var c in categories)
            {
                cbxCategories.Items.Add(c);
            }
            cbxCategories.DisplayMember = "Title";
        }

        private void addBinding()
        {
            txtId.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtDescript.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Descript", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        private void refresh()
        {
            loadDrinks(null, null, null, null, null);
            cbxCategories.SelectedItem = "All";
            txtSearch.Text = "";
            cbxStatus.SelectedItem = "All";
            nudPriceFrom.Value = 0;
            nudPriceTo.Value = 0;
            MakeEmpty();
            changeVisibleBtn(false, true);
        }

        private void MakeEmpty()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDescript.Text = "";
            txtPrice.Text = "";
            cbxCategory.SelectedIndex = 0;
            pictureBox1.BackgroundImage = null;
        }

        private void loadTable()
        {
            var search = txtSearch.Text;
            var category = GetCategoryId_Search();
            var priceFrom = nudPriceFrom.Value;
            var priceTo = GetPriceTo();
            var status = GetStatus();
            loadDrinks(category, search, priceFrom, priceTo, status);            
        }

        private void changeVisibleBtn(bool btnRe, bool btnAED)
        {
            btnRecovery.Visible = btnRe;
            btnAdd.Visible = btnAED;
            btnEdit.Visible = btnAED;
            btnDelete.Visible = btnAED;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0 && !string.IsNullOrEmpty(txtId.Text))
            {
                int id = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["DrinkCategoryId"].Value;
                int index = -1;
                int i = 0;

                foreach(DrinkCategoryDto c in cbxCategory.Items)
                {
                    if(c.Id == id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbxCategory.SelectedIndex = index;
                bool status = (bool)dataGridView1.SelectedCells[0].OwningRow.Cells["Status"].Value;

                if(status == false)
                {
                    changeVisibleBtn(true, false);
                }
                else
                {
                    changeVisibleBtn(false, true);
                }

                byte[] img = (byte[])dataGridView1.SelectedCells[0].OwningRow.Cells["Img"].Value;

                if (img != null)
                    pictureBox1.BackgroundImage = ImageStatic.ConvertBinary2Img(img);
                else
                    pictureBox1.BackgroundImage = null;
            }
            else
                pictureBox1.BackgroundImage = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            var categoryId = GetCategoryId();
            string descript = txtDescript.Text;
            decimal price = (txtPrice.Text=="")? 0 : decimal.Parse(txtPrice.Text);
            byte[] img = null;

            if(!string.IsNullOrEmpty(fileImg))
                img = ImageStatic.ConvertImg2Binary(pictureBox1.BackgroundImage);

            var drink = new DrinkDto
            {
                Name = name,
                DrinkCategoryId = categoryId,
                Descript = descript,
                Price = price,
                Img = img,
                Status = true
            };
            drinkController.Create(drink);

            MessageBox.Show("You added drink successfully", "Notification");
            loadTable();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (!string.IsNullOrEmpty(id)) 
            {
                var drink = drinkController.Get(Int32.Parse(id));
                drink.Name = txtName.Text;
                drink.Descript = txtDescript.Text;

                drink.DrinkCategoryId = GetCategoryId();
                drink.Price = (txtPrice.Text == "") ? 0 : decimal.Parse(txtPrice.Text);

                byte[] img = null;

                if (!string.IsNullOrEmpty(fileImg))
                {
                    img = ImageStatic.ConvertImg2Binary(pictureBox1.BackgroundImage);
                }

                if(img != null)
                    drink.Img = img;

                drinkController.Update(drink);
                MessageBox.Show("You updated drink successfully", "Notification");
                loadTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var drink = drinkController.Get(Int32.Parse(id));
                drink.Status = false;
                drinkController.Update(drink);

                MessageBox.Show("You deleted drink successfully", "Notification");
                loadTable();
            }
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (!string.IsNullOrEmpty(id))
            {
                var drink = drinkController.Get(Int32.Parse(id));
                drink.Status = true;
                drinkController.Update(drink);

                MessageBox.Show("You have successfully restored the drink", "Notification");
                loadTable();
            }
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "JPEG|*.jpg",
                ValidateNames = true,
                Multiselect = false
            })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    fileImg = ofd.FileName;
                    pictureBox1.BackgroundImage = Image.FromFile(fileImg);
                    pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
            }
        }

        private bool? GetStatus()
        {
            var status = cbxStatus.SelectedItem.ToString();
            bool? stt = null;
            if (status == "Active")
                stt = true;
            else if (status == "Inactive")
                stt = false;
            return stt;
        }

        private int? GetCategoryId_Search()
        {
            if (cbxCategories.SelectedIndex == 0)
                return null;
            var category = (DrinkCategoryDto) cbxCategories.SelectedItem;
            return category.Id;
        }

        private decimal? GetPriceTo()
        {
            var priceTo = nudPriceTo.Value;
            if (priceTo == 0)
                return null;
            return priceTo;
        }

        private int GetCategoryId()
        {
            var category = (DrinkCategoryDto)cbxCategory.SelectedValue;
            return category.Id;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void btnMakeEmpty_Click(object sender, EventArgs e)
        {
            MakeEmpty();
        }
    }
}

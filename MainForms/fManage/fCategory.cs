using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fCategory : UserControl
    {
        private DrinkCategoryController drinkCategoryController;
        private BindingSource tblCategories = new BindingSource();

        public fCategory()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            dataGridView1.DataSource = tblCategories;
            loadDrinkCategories();
            addBinding();
        }
        private void loadDrinkCategories()
        {
            if (drinkCategoryController == null)
                drinkCategoryController = new DrinkCategoryController();
            //Get all categories in db
            tblCategories.DataSource = drinkCategoryController.Gets(null).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            loadDrinkCategories();
            txtName.Text = "";
            txtId.Text = "";
        }

        private void addBinding()
        {
            txtId.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Title", true, DataSourceUpdateMode.Never));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var drinkCategoryDto = new DrinkCategoryDto
            {
                Title = txtName.Text
            };
            drinkCategoryController.Create(drinkCategoryDto);

            MessageBox.Show("You added new category successfully", "Notification");
            refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if(!string.IsNullOrEmpty(id))
            {
                var category = drinkCategoryController.Get(Int32.Parse(id));
                category.Title = txtName.Text;
                drinkCategoryController.Update(category);

                MessageBox.Show("You updated category successfully", "Notification");
                refresh();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if(!string.IsNullOrEmpty(id))
            {
                var checkId = drinkCategoryController.IsIdEmptyInDrinks(Int32.Parse(id));

                if(checkId)
                {
                    drinkCategoryController.Delete(Int32.Parse(id));
                    MessageBox.Show("You deleted category successfully", "Notification");
                    refresh();
                }
                else
                    MessageBox.Show("You can't delete this category because drinks using this catgoryId !!!", "Notification");
            }
        }

    }
}

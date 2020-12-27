using Application.DTOs;
using MainForms.Controllers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fStaff : UserControl
    {
        private BindingSource tblStaffs = new BindingSource();
        private StaffController staffController;
        private string fileImg = "";

        public fStaff()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            dataGridView1.DataSource = tblStaffs;
            loadStaffs(null, null, null);
            addBinding();
        }

        private void loadStaffs(string searchString, string position, bool? status)
        {
            if (staffController == null)
                staffController = new StaffController();

            tblStaffs.DataSource = staffController.Gets(searchString, position, status).ToList();
            dataGridView1.Columns["Img"].Visible = false;
        }

        private void addBinding()
        {
            txtId.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtPhone.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            txtStreet.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Street", true, DataSourceUpdateMode.Never));
            txtWard.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Ward", true, DataSourceUpdateMode.Never));
            txtCity.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "City", true, DataSourceUpdateMode.Never));
            txtSalary.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Salary", true, DataSourceUpdateMode.Never));
            dateTimePicker1.DataBindings.Add(new Binding("Value", dataGridView1.DataSource, "DateOfBirth", true, DataSourceUpdateMode.Never));
        }

        private void refresh()
        {
            loadStaffs(null, null, null);
            txtSearch.Text = "";
            cbxPositionSearch.SelectedIndex = 0;
            cbxStatus.SelectedIndex = 0;
            MakeEmpty();
            changeVisibleBtn(false, true);
        }

        private void MakeEmpty()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtStreet.Text = "";
            txtWard.Text = "";
            txtCity.Text = "";
            txtSalary.Text = "";
            picImg.BackgroundImage = null;
        }

        private void loadTable()
        {
            var search = txtSearch.Text;
            var position = GetPosition();
            var stt = GetStatus();
            loadStaffs(search, position, stt);            
        }

        private void changeVisibleBtn(bool btnRe, bool btnAED)
        {
            btnRecovery.Visible = btnRe;
            btnAdd.Visible = btnAED;
            btnEdit.Visible = btnAED;
            btnDelete.Visible = btnAED;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && !string.IsNullOrEmpty(txtId.Text))
            {
                string position = (string)dataGridView1.SelectedCells[0].OwningRow.Cells["Position"].Value;
                cbxPosition.SelectedItem = position;

                bool status = (bool)dataGridView1.SelectedCells[0].OwningRow.Cells["Status"].Value;

                if (status == false)
                {
                    changeVisibleBtn(true, false);
                }
                else
                {
                    changeVisibleBtn(false, true);
                }

                bool gender = (bool)dataGridView1.SelectedCells[0].OwningRow.Cells["Gender"].Value;

                if (gender)
                    radMale.Checked = true;
                else
                    radFemale.Checked = true;

                int id = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["Id"].Value;

                var accController = new AccountController();
                var acc = accController.GetByStaffId(id);

                btnCreateAcc.Visible = (acc == null && status == true) ? true : false;

                byte[] img = (byte[])dataGridView1.SelectedCells[0].OwningRow.Cells["Img"].Value;

                if (img != null)
                    picImg.BackgroundImage = ImageStatic.ConvertBinary2Img(img);
                else
                    picImg.BackgroundImage = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private bool GetGender()
        {
            if (radMale.Checked)
                return true;
            return false;
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            var staff = staffController.Get(Int32.Parse(txtId.Text));
            staff.Status = true;
            staffController.Update(staff);

            var accountController = new AccountController();
            var acc = accountController.GetByStaffId(Int32.Parse(txtId.Text));

            if(acc != null)
            {
                acc.Status = true;
                accountController.Update(acc, null);
            }

            MessageBox.Show("You have successfully restored the staff", "Notification");
            loadTable();            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            bool gender = GetGender();
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            var date = dateTimePicker1.Value;
            string street = txtStreet.Text;
            string ward = txtWard.Text;
            string city = txtCity.Text;
            string position = cbxPosition.SelectedItem.ToString();
            decimal salary = ( txtSalary.Text == "" ) ? 0 : decimal.Parse(txtSalary.Text);

            byte[] img = null;

            if (!string.IsNullOrEmpty(fileImg))
            {
                img = ImageStatic.ConvertImg2Binary(picImg.BackgroundImage);
            }

            staffController.Create(
                new StaffDto
                {
                    Name = name,
                    Gender = gender,
                    Email = email,
                    Phone = phone,
                    DateOfBirth = date,
                    Street = street,
                    Ward = ward,
                    City = city,
                    Position = position,
                    Salary = salary,
                    Img = img,
                    Status = true
                });

            MessageBox.Show("You added staff successfully", "Notification");
            loadTable();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var staff = staffController.Get(Int32.Parse(id));

                staff.Name = txtName.Text;
                staff.Gender = GetGender();
                staff.Email = txtEmail.Text;
                staff.DateOfBirth = dateTimePicker1.Value;
                staff.Phone = txtPhone.Text;
                staff.Street = txtStreet.Text;
                staff.Ward = txtWard.Text;
                staff.City = txtCity.Text;
                staff.Position = cbxPosition.SelectedItem.ToString();
                staff.Salary = (txtSalary.Text == "") ? 0 : decimal.Parse(txtSalary.Text);

                byte[] img = null;

                if (!string.IsNullOrEmpty(fileImg))
                {
                    img = ImageStatic.ConvertImg2Binary(picImg.BackgroundImage);
                }

                if (img != null)
                    staff.Img = img;

                staffController.Update(staff);

                MessageBox.Show("You updated staff successfully", "Notification");
                loadTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var staff = staffController.Get(Int32.Parse(id));
                staff.Status = false;
                staffController.Update(staff);

                var accountController = new AccountController();
                var acc = accountController.GetByStaffId(Int32.Parse(id));

                if(acc != null) {
                    acc.Status = false;
                    accountController.Update(acc, null);
                }

                MessageBox.Show("You deleted staff successfully", "Notification");
                loadTable();
            }
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("ddMMyyyy");
            string username = txtId.Text + date;
            string stafId = txtId.Text;
            string password = date;

            var _accController = new AccountController();
            string _mess = _accController.Create(username, password, stafId);

            MessageBox.Show(_mess, "Notification");
            loadTable();
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
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileImg = ofd.FileName;
                    picImg.BackgroundImage = Image.FromFile(fileImg);
                    picImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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

        private string GetPosition()
        {
            if (cbxPositionSearch.SelectedIndex == 0)
                return null;
            return cbxPositionSearch.SelectedItem.ToString();
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

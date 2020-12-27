using MainForms.Controllers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fAccount : UserControl
    {
        private AccountController accountController;
        private StaffController staffController = new StaffController();

        private BindingSource tblAcc = new BindingSource();

        public fAccount()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            dataGridView1.DataSource = tblAcc;
            loadAccounts(null, null);
            addBinding();
        }

        private void loadAccounts(string searchstring, bool? status)
        {
            if(accountController == null)
                accountController = new AccountController();

            tblAcc.DataSource = accountController.Gets(searchstring, status).ToList();
            dataGridView1.Columns["PasswordHash"].Visible = false;
            dataGridView1.Columns["PasswordSalt"].Visible = false;
        }

        private void addBinding()
        {
            lblId.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Id", true, DataSourceUpdateMode.Never));
            lblUser.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Username", true, DataSourceUpdateMode.Never));
            lblStaffId.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "StaffId", true, DataSourceUpdateMode.Never));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = lblId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var staffid = Int32.Parse(lblStaffId.Text);
                var staff = staffController.Get(staffid);
                staff.Position = cbxPosition.SelectedItem.ToString();
                staffController.Update(staff);

                MessageBox.Show("You updated account successfully", "Notification");
                var stt = GetStatusBycbx();
                loadAccounts(txtSearch.Text, stt);
            }

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            string id = lblId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var acc = accountController.Get(Int32.Parse(id));
                acc.Status = false;
                accountController.Update(acc, null);

                MessageBox.Show("You locked account successfully", "Notification");
                var stt = GetStatusBycbx();
                loadAccounts(txtSearch.Text, stt);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string id = lblId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                var acc = accountController.Get(Int32.Parse(id));
                acc.Status = true;
                accountController.Update(acc, null);

                MessageBox.Show("You unlocked account successfully", "Notification");
                var stt = GetStatusBycbx();
                loadAccounts(txtSearch.Text, stt);
            }
        }

        private void lblStaffId_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && !string.IsNullOrEmpty(lblId.Text))
            {
                int id = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["StaffId"].Value;

                staffController = new StaffController();
                var staff = staffController.Get(id);
                lblStaffName.Text = staff.Name;
                cbxPosition.SelectedItem = staff.Position;

                bool status = (bool)dataGridView1.SelectedCells[0].OwningRow.Cells["Status"].Value;

                if (status)
                {
                    btnLock.Visible = true;
                    btnUnlock.Visible = false;
                    button1.Visible = true;
                }
                else
                {
                    btnLock.Visible = false;
                    btnUnlock.Visible = true;
                    button1.Visible = false;
                }

                if (!staff.Status)
                    btnUnlock.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = lblId.Text;

            if (!string.IsNullOrEmpty(id))
            {
                accountController.Delete(Int32.Parse(id));

                MessageBox.Show("You deleted account successfully", "Notification");
                var stt = GetStatusBycbx();
                loadAccounts(txtSearch.Text, stt);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadAccounts(null, null);
            lblId.Text = "";
            lblUser.Text = "";
            lblStaffId.Text = "";
            lblStaffName.Text = "";
            txtSearch.Text = "";
            cbxStatus.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            var stt = GetStatusBycbx();
            loadAccounts(search, stt);
        }

        private bool? GetStatusBycbx()
        {
            var status = cbxStatus.SelectedItem.ToString();
            bool? stt = null;
            if (status == "Active")
                stt = true;
            else if (status == "Inactive")
                stt = false;
            return stt;
        }
    }
}

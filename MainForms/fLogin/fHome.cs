using System;
using System.Windows.Forms;

namespace MainForms.fLogin
{
    public partial class fHome : Form
    {
        private readonly int staffId;
        public fHome(string position, int staffId)
        {
            InitializeComponent();
            loadTablet(position);
            this.staffId = staffId;
        }

        private void loadTablet(string position)
        {
            if (position == "Manage")
            {
                btnBanCoffee.Visible = false;
                btnManage.Visible = true;
            }
            else
            {
                btnBanCoffee.Visible = true;
                btnManage.Visible = false;
            }
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

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            fLogin login = new fLogin();
            login.Show();
            Dispose();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            fChangePassword changePassword = new fChangePassword(staffId);
            changePassword.ShowDialog();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            fManage.fManage manage = new fManage.fManage(staffId);
            Hide();
            manage.ShowDialog();
            Show();
        }

        private void btnBanCoffee_Click(object sender, EventArgs e)
        {
            fSell.fSellCoffee sell = new fSell.fSellCoffee(staffId);
            Hide();
            sell.ShowDialog();
            Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            fProfile profile = new fProfile(staffId);
            profile.ShowDialog();
        }
    }
}

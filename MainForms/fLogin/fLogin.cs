using MainForms.Controllers;
using System;
using System.Windows.Forms;

namespace MainForms.fLogin
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                txtuser.Text = Properties.Settings.Default.username;
                txtpass.Text = Properties.Settings.Default.password;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(" Do you want to exit ? ", "Exit",MessageBoxButtons.YesNo);

            if (response ==DialogResult.No)
            {
                //nothing in here
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;

            var accountController = new AccountController();
            var _mess = accountController.Login(username, password);

            if (!string.IsNullOrEmpty(_mess))
            {
                lblWrongAcc.Text = _mess;
                return;
            }
            else
            {
                var staffId = accountController.GetStaffId(username);
                var position = new StaffController().Get(staffId).Position;
                RememberMeWrite();
                var home = new fHome(position, staffId);
                Hide();
                home.Show();
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnlogin_Click(sender, e);
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void RememberMeWrite()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.username = txtuser.Text;
                Properties.Settings.Default.password = txtpass.Text;
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
            }

            Properties.Settings.Default.Save();
        }
    }
}

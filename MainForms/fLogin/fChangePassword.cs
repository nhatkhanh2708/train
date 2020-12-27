using MainForms.Controllers;
using System;
using System.Windows.Forms;

namespace MainForms.fLogin
{
    public partial class fChangePassword : Form
    {
        private readonly int staffId;

        public fChangePassword(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var _old = txtOldPwd.Text;
            var _new = txtNewPwd.Text;
            var _confirm = txtConfirm.Text;

            string err = "";
            
            var accountController = new AccountController();
            var acc = accountController.GetByStaffId(staffId);
            var username = acc.Username;
            var _check = accountController.Login(username, _old);

            if (!string.IsNullOrEmpty(_check))
            {
                err = "Wrong old password !";
            }
            else
            {
                if (_new == _confirm)
                {
                    accountController.Update(acc, _new);
                    MessageBox.Show("You changed your password successfully.", "Notification");
                    Dispose();
                }
                else
                {
                    err = "New password and confirmation password do not match !!!";
                }
            }

            if (!string.IsNullOrEmpty(err))
            {
                lblErr.Text = err;
                lblErr.Visible = true;
            }
        }
    }
}

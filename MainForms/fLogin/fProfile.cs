using MainForms.Controllers;
using System;
using System.Windows.Forms;

namespace MainForms.fLogin
{
    public partial class fProfile : Form
    {        
        public fProfile(int staffId)
        {
            InitializeComponent();
            Profile(staffId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Profile(int staffId)
        {
            var staffController = new StaffController();
            var staff = staffController.Get(staffId);

            lblId.Text = staff.Id.ToString();
            lblName.Text = staff.Name.ToString();
            lblGender.Text = staff.Gender ? "Nam" : "Nữ";
            lblEmail.Text = staff.Email.ToString();
            lblPhone.Text = staff.Phone.ToString();
            string address = staff.Street + ", " + staff.Ward + ", " + staff.City;
            lblAddress.Text = address;

            var accountController = new AccountController();
            var acc = accountController.GetByStaffId(staffId);

            lblUser.Text = acc.Username.ToString();
        }
    }
}

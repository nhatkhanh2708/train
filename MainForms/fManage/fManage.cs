using MainForms.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForms.fManage
{
    public partial class fManage : Form
    {
        public fManage(int staffId)
        {
            InitializeComponent();
            loadNameManage(staffId);
        }

        private void loadNameManage(int staffId)
        {
            lblNameManage.Text = new StaffController().Get(staffId).Name;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FocusButton(Button btnMain, Button btn1, Button btn2, Button btn3, Button btn4, Button btn5)
        {
            btnMain.BackColor = System.Drawing.Color.Blue;
            btnMain.ForeColor = System.Drawing.Color.White;
            btn1.BackColor = System.Drawing.Color.Ivory;
            btn1.ForeColor = System.Drawing.Color.Blue;
            btn2.BackColor = System.Drawing.Color.Ivory;
            btn2.ForeColor = System.Drawing.Color.Blue;
            btn3.BackColor = System.Drawing.Color.Ivory;
            btn3.ForeColor = System.Drawing.Color.Blue;
            btn4.BackColor = System.Drawing.Color.Ivory;
            btn4.ForeColor = System.Drawing.Color.Blue;
            btn5.BackColor = System.Drawing.Color.Ivory;
            btn5.ForeColor = System.Drawing.Color.Blue;
        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            var coffee = new fCoffee();

            if (!pnlShowManage.Controls.Contains(coffee))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(coffee);

                coffee.Dock = DockStyle.Fill;
                coffee.BringToFront();
            }

            FocusButton(btnCoffee, btnCategory, btnStaff, btnAccount, btnPromotion, btnStatistical);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var category = new fCategory();

            if (!pnlShowManage.Controls.Contains(category))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(category);

                category.Dock = DockStyle.Fill;
                category.BringToFront();
            }

            FocusButton(btnCategory, btnCoffee, btnStaff, btnAccount, btnPromotion, btnStatistical);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            var staff = new fStaff();

            if (!pnlShowManage.Controls.Contains(staff))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(staff);

                staff.Dock = DockStyle.Fill;
                staff.BringToFront();
            }

            FocusButton(btnStaff, btnCategory, btnCoffee, btnAccount, btnPromotion, btnStatistical);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            var stt = new fStatistical();

            if (!pnlShowManage.Controls.Contains(stt))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(stt);

                stt.Dock = DockStyle.Fill;
                stt.BringToFront();
            }

            FocusButton(btnStatistical, btnCategory, btnStaff, btnAccount, btnPromotion, btnCoffee);
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            var prm = new fPromotion();

            if (!pnlShowManage.Controls.Contains(prm))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(prm);

                prm.Dock = DockStyle.Fill;
                prm.BringToFront();
            }

            FocusButton(btnPromotion, btnCategory, btnStaff, btnAccount, btnCoffee, btnStatistical);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            var acc = new fAccount();

            if (!pnlShowManage.Controls.Contains(acc))
            {
                pnlShowManage.Controls.Remove(this);
                pnlShowManage.Controls.Add(acc);

                acc.Dock = DockStyle.Fill;
                acc.BringToFront();
            }

            FocusButton(btnAccount, btnCategory, btnStaff, btnCoffee, btnPromotion, btnStatistical);
        }
    }
}

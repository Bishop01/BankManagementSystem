using BankManagementSystem.Database;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            DisableComponent();
        }

        private void RecoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CPassword().ShowDialog();
        }
        private void RecoverLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            RecoverLinkLabel.LinkColor = Color.Cyan;
        }
        private void RecoverLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            RecoverLinkLabel.LinkColor = Color.RoyalBlue;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            DisableComponent();

            string id = EmployeeIdTextbox.Text;
            string Password = PasswordTextbox.Text;
            int Id;
            if (id == "")
            {
                IdErrorLabel.Show();
                return;
            }
            else if (Password == "")
            {
                PasswordErrorLabel.Show();
                return;
            }
            try
            {
                Id = Convert.ToInt32(id);
            }
            catch (FormatException)
            {
                LoginErrorLabel.Text = "ID must be integer!";
                return;
            }

            if (DataVerification.ValidateLogin(Id, Password))
            {
                this.Hide();
                new Main(Id).Show();
            }
            else
            {
                LoginErrorLabel.Text = "Incorrect ID or Password!";
                return;
            };
        }

        private void DisableComponent()
        {
            IdErrorLabel.Hide();
            PasswordErrorLabel.Hide();
            LoginErrorLabel.Text = null;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            new DBAdmin().ShowDialog();
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

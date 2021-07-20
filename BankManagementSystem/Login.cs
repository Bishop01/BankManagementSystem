using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

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
            if(id == "")
            {
                IdErrorLabel.Show();
                return;
            }
            else if(Password == "")
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

            if (DatabaseHandler.ValidateLogin(Id, Password))
            {
                this.Hide();
                string name = DatabaseHandler.GetEmployee(Id);
                new Main(name).Show();
            }
            else
            {
                LoginErrorLabel.Text = "Incorrect ID or Password!";
                return;
            };
        }
        private bool ValidateLogin(string name, string pass)
        {
            return false;
        }
        private void DisableComponent()
        {
            IdErrorLabel.Hide();
            PasswordErrorLabel.Hide();
            LoginErrorLabel.Text = null;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //this.Enabled = true;
            // = false;
            new DBAdmin().ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

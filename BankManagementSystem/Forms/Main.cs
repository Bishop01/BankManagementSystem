using BankManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class Main : Form
    {
        public Main(string name)
        {
            InitializeComponent();
            HideAllPanel();
            DisableComponents();
            DashboardPanel.BringToFront();
            AccountPictureBox.Location = new Point(9, AccountButton.Location.Y+10);
            LoanPictureBox.Location = new Point(9, LoanButton.Location.Y+10); 
            ClockTimer.Start();
            NameLabel.Text = name;
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            HideAllPanel();
            ResetAllButton();
            ResetChildButton();
            ResetPanel(RegisterPanel);
            DashboardPanel.BringToFront();
            DashboardButton.BackColor = Color.FromArgb(43, 63, 97);
            CurrentLabel.Text = "Dashboard";
        }

        #region Register
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            HideAllPanel();
            ResetAllButton();
            ResetChildButton();
            RegisterPanel.Show();
            RegisterButton.BackColor = Color.FromArgb(43, 63, 97);
            CurrentLabel.Text = "Register";
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (CheckEmptyCreateAccountFields())
                ValidateErrorLabel.Text = "No fields can remain empty!";
            else
            {
                ValidateErrorLabel.Text = "";
                string accType = AccountTypeComboBox.Text;
                Client c = new Client();

                c.Firstname = FirstnameTextbox.Text;
                c.Lastname = LastnameTextbox.Text;
                c.Nationality = NationalityTextbox.Text;
                c.NID = NIDTextbox.Text;
                c.Address = AddressTextbox.Text;
                c.Email = EmailTextbox.Text;
                c.DOB = DOBDateTimePicker.Text;
                c.Occupation = OccupationTextbox.Text;
                if (MaleRadioButton.Checked)
                {
                    c.Gender = MaleRadioButton.Text;
                }
                else
                {
                    c.Gender = FemaleRadioButton.Text;
                }
                if (accType.Equals("Salary"))
                {
                    Account a = new SalaryAccount();
                    c.AccountType = ((SalaryAccount)a).AccountType;
                }
                else if (accType.Equals("Savings"))
                {
                    Account a = new SavingsAccount();
                    c.AccountType = ((SavingsAccount)a).AccountType;
                }

                if (Registration.RegisterAccount(c))
                {

                }
            }
        }
        #endregion Register

        #region Account
        private void AccountButton_Click(object sender, EventArgs e)
        {
            ResetAllButton();
            HideAllPanel();
            ResetChildButton();
            AccountPanel.Show();
            AccountButton.BackColor = Color.FromArgb(43, 63, 97);
            CurrentLabel.Text = "Account";
        }
        #endregion Account

        #region Reset

        private void ResetAllButton()
        {
            foreach(Control button in MenuPanel.Controls)
            {
                if(button is Button)
                    button.BackColor = Color.FromArgb(31, 30, 68);
            }
        }
        private void ResetChildButton(Panel panel)
        {
            foreach(Control button in panel.Controls)
            {
                if(button is Button)
                    button.BackColor = Color.FromArgb(31, 30, 68);
            }
        }
        private void ResetChildButton()
        {
            foreach (Control button in RegisterPanel.Controls)
            {
                if(button is Button)
                    button.BackColor = Color.FromArgb(31, 30, 68);
            }
            foreach (Control button in AccountPanel.Controls)
            {
                if(button is Button)
                    button.BackColor = Color.FromArgb(31, 30, 68);
            }
        }

        private void ResetPanel(Panel panel)
        {
            if (panel.Equals(RegisterPanel))
            {
                foreach (Control control in CreateAccountPanel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Text = "";
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedItem = null;
                    }
                    else if (control is RadioButton)
                    {
                        if (((RadioButton)control).Checked)
                        {
                            ((RadioButton)control).Checked = false;
                        }
                    }
                }
                foreach (Control control in CloseAccountPanel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Text = "";
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedItem = null;
                    }
                    else if (control is RadioButton)
                    {
                        if (((RadioButton)control).Checked)
                        {
                            ((RadioButton)control).Checked = false;
                        }
                    }
                }
            }
            else if (panel.Equals(AccountPanel))
            {
                
            }
        }
            
        #endregion Reset

        private void SubmenuButtonsHandler(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if (sender.Equals(CreateAccButton))
                {
                    ResetChildButton(RegisterPanel);
                    CreateAccountPanel.BringToFront();
                    CreateAccButton.BackColor = Color.FromArgb(22, 34, 54);
                }
                else if (sender.Equals(CloseAccButton))
                {
                    ResetChildButton(RegisterPanel);
                    CloseAccountPanel.BringToFront();
                    CloseAccButton.BackColor = Color.FromArgb(22, 34, 54);
                }
                else if (sender.Equals(RecoverAccButton))
                {
                    ResetChildButton(RegisterPanel);
                    RecoverAccountPanel.BringToFront();
                    RecoverAccButton.BackColor = Color.FromArgb(22, 34, 54);
                }
                else if (sender.Equals(DepositButton))
                {
                    ResetChildButton(AccountPanel);
                    DepositPanel.BringToFront();
                    DepositButton.BackColor = Color.FromArgb(22, 34, 54);
                }
                else if (sender.Equals(WithdrawButton))
                {
                    ResetChildButton(AccountPanel);
                    WithdrawPanel.BringToFront();
                    WithdrawButton.BackColor = Color.FromArgb(22, 34, 54);
                }
                else if (sender.Equals(TransferButton))
                {
                    ResetChildButton(AccountPanel);
                    TransferPanel.BringToFront();
                    TransferButton.BackColor = Color.FromArgb(22, 34, 54);
                }
            }
        }

        private void HideAllPanel()
        {
            RegisterPanel.Hide();
            AccountPanel.Hide();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void DisableComponents()
        {
            ValidateErrorLabel.Text = "";
        }
        private bool CheckEmptyCreateAccountFields()
        {
            foreach(Control control in CreateAccountPanel.Controls)
            {
                if(control is TextBox)
                {
                    if(((TextBox)control).Text == "")
                    {
                        return true;
                    }
                }
            }
            if (!(MaleRadioButton.Checked || FemaleRadioButton.Checked))
            {
                return true;
            }
            if(AccountTypeComboBox.Text == "")
            {
                return true;
            }
            return false;
        }
        private void AccountButton_LocationChanged(object sender, EventArgs e)
        {
            AccountPictureBox.Location = new Point(9, AccountButton.Location.Y + 10);
        }
        private void LoanButton_LocationChanged(object sender, EventArgs e)
        {
            LoanPictureBox.Location = new Point(9, LoanButton.Location.Y + 10);
        }
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("hh:mm");
            SecondLabel.Text = DateTime.Now.ToString("ss");
        }
        private void TextBoxEnterColorChange(object sender, EventArgs e)
        {
            if(sender.Equals(FirstnameTextbox))
            {
                FirstnameTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(LastnameTextbox))
            {
                LastnameTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(EmailTextbox))
            {
                EmailTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(PNTextbox))
            {
                PNTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(NIDTextbox))
            {
                NIDTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(AddressTextbox))
            {
                AddressTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(NationalityTextbox))
            {
                NationalityTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(OccupationTextbox))
            {
                OccupationTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else
            {
                return;
            }
        }
        private void TextBoxLeaveColorChange(object sender, EventArgs e)
        {
            if (sender.Equals(FirstnameTextbox))
            {
                FirstnameTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(LastnameTextbox))
            {
                LastnameTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(EmailTextbox))
            {
                EmailTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(PNTextbox))
            {
                PNTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(NIDTextbox))
            {
                NIDTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(AddressTextbox))
            {
                AddressTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(NationalityTextbox))
            {
                NationalityTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(OccupationTextbox))
            {
                OccupationTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else
            {
                return;
            }
        }

        private void Main_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void SignOutButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure to log out?", "Warning!", MessageBoxButtons.YesNo);
            if(confirmation == DialogResult.Yes)
            {
                this.Dispose();
                new Login().Show();
            }
            else
            {
                return;
            }
        }
    }
}

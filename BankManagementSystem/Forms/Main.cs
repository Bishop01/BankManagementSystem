﻿using BankManagementSystem.Database;
using BankManagementSystem.Forms;
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
        private static string registrationImagePathFemale = @"G:\Coding\C#\BankManagementSystem\Images\female.png";
        private static string registrationImagePathMale = @"G:\Coding\C#\BankManagementSystem\Images\male.png";
        private static string registrationImagePath = null;
        private string currentUser;
        private Employee currentEmployee;

        public Main(int id)
        {
            InitializeComponent();
            HideAllPanel();
            DisableComponents();
            DashboardPanel.BringToFront();
            AccountPictureBox.Location = new Point(9, AccountButton.Location.Y+10);
            LoanPictureBox.Location = new Point(9, LoanButton.Location.Y+10); 
            ClockTimer.Start();
            currentUser = FetchData.GetEmployeeName(id);
            currentEmployee = FetchData.GetEmployee(id);
            NameLabel.Text = currentUser;
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            HideAllPanel();
            ResetAllButton();
            ResetChildButton();
            ResetPanel(RegisterPanel);
            ResetCreateAccountDetails();
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
            HideAccountDetails();
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
                c.PhoneNumber = PhoneNumberTextbox.Text;
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
                c.AccountType = AccountTypeComboBox.Text;
                c.AccountStatus = "Open";
                if(registrationImagePath == null)
                {
                    if (c.Gender.Equals("Male"))
                    {
                        c.ImageDir = registrationImagePathMale;
                    }
                    else
                    {
                        c.ImageDir = registrationImagePathFemale;
                    }
                }
                else
                {
                    c.ImageDir = registrationImagePath;
                }
                

                if (Registration.RegisterAccount(c, currentEmployee.ID))
                {
                    MessageBox.Show("Registration Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new PrintAccountDetails(c).ShowDialog();
                    ResetCreateAccountDetails();
                }
                else
                {
                    MessageBox.Show("Error in registering", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ResetCreateAccountDetails();
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
            else if (sender.Equals(PhoneNumberTextbox))
            {
                PhoneNumberTextbox.BackColor = Color.FromArgb(22, 67, 99);
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
            else if (sender.Equals(PhoneNumberTextbox))
            {
                PhoneNumberTextbox.BackColor = Color.FromArgb(34, 33, 74);
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
        private void SignOutButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure to log out?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string s = SearchTextbox.Text;
            if(s == "")
            {
                MessageBox.Show("Input Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Client c = FetchData.GetClient(id);
                    if (c == null)
                    {
                        MessageBox.Show("No client found!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ShowAccountDetails(c);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Input Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BrowseImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Jpg Image(*.jpg)|*.jpg|Png Image(*.png)|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    registrationImagePath = openFileDialog.FileName;
                    ImageRegister.ImageLocation = registrationImagePath;
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error in opening image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ResetCreateAccountDetails()
        {
            foreach(Control control in CreateAccountPanel.Controls)
            {
                if(control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }
            AccountTypeComboBox.Text = "";
            DOBDateTimePicker.ResetText();
            MaleRadioButton.Checked = false;
            FemaleRadioButton.Checked = false;
            ImageRegister.Image = null;
        }
        private void HideAccountDetails()
        {
            AccountDetailsGroupBox.Hide();
        }
        private void ShowAccountDetails(Client client)
        {
            AccountDeatilsAccountIDLabel.Text = "AccountID: " + client.AccountID.ToString();
            AccountDeatilsFirstNameLabel.Text = "Firstname: " + client.Firstname;
            AccountDeatilsLastNameLabel.Text = "Lastname: " + client.Lastname;
            AccountDeatilsGenderLabel.Text = "Gender: " + client.Gender;
            AccountDeatilsNationalityLabel.Text = "Nationality: " + client.Nationality;
            AccountDeatilsNIDLabel.Text = "NID: " + client.NID;
            AccountDeatilsOccupationLabel.Text = "Occupation: " + client.Occupation;
            AccountDeatilsEmailLabel.Text = "Email: " + client.Email;
            AccountDeatilsDOBLabel.Text = "Date of Birth: " + client.DOB;
            AccountDetailsPhoneNumberLabel.Text = "Phone Numebr: " + client.PhoneNumber;
            AccountDeatilsAddressLabel.Text = "Address: " + client.Address;
            AccountDeatilsAccountTypeLabel.Text = "Account Type: " + client.AccountType;
            AccountDeatilsAccountStatusLabel.Text = "Account Status: " + client.AccountStatus;
            ClientPictureBox.ImageLocation = client.ImageDir;

            AccountDetailsGroupBox.Show();
        }
    }
}

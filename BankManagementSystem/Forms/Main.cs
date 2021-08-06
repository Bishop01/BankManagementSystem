using BankManagementSystem.Database;
using BankManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class Main : Form
    {
        private static string registrationImagePathFemale = @"G:\Coding\C#\BankManagementSystem\Images\female.png";
        private static string registrationImagePathMale = @"G:\Coding\C#\BankManagementSystem\Images\male.png";
        private static string registrationImagePath = null;
        private string currentUser;
        private Bitmap bitmap;
        private Employee currentEmployee;
        private Client searchedClient;
        private Account searchedAccount;

        public Main(int id)
        {
            InitializeComponent();
            HideAllPanel();
            DisableComponents();
            HideDepositGroupBox();
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
            ResetResultGroupBox();
            HideDepositGroupBox();
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
                Account account = new Account();

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
                account.AccountType = AccountTypeComboBox.Text;
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

                if (Registration.RegisterAccount(c, account, currentEmployee.ID))
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
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string s = SearchTextbox.Text;
            if (s == "")
            {
                MessageBox.Show("Input Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Client c = FetchData.GetClientByAccountID(id);
                    Account account = FetchData.GetAccount(id);
                    searchedClient = c;
                    searchedAccount = account;
                    if (c == null)
                    {
                        MessageBox.Show("No client found!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HideAccountDetails();
                    }
                    else
                    {
                        ShowAccountDetails(c, account);
                        if (account.AccountStatus.Equals("Closed"))
                        {
                            CloseAccountButton.Enabled = false;
                        }
                        else
                        {
                            CloseAccountButton.Enabled = true;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Input Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CloseAccountButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to close this account?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                searchedAccount.AccountStatus = "Closed";
                if (ModifyData.UpdateAccountStatus(searchedAccount, currentEmployee, "Closed"))
                {
                    MessageBox.Show("Account Closed!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error updating!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                HideAccountDetails();
            }
            else
            {
                return;
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
        private bool CheckEmptyCreateAccountFields()
        {
            foreach (Control control in CreateAccountPanel.Controls)
            {
                if (control is TextBox)
                {
                    if (((TextBox)control).Text == "")
                    {
                        return true;
                    }
                }
            }
            if (!(MaleRadioButton.Checked || FemaleRadioButton.Checked))
            {
                return true;
            }
            if (AccountTypeComboBox.Text == "")
            {
                return true;
            }
            return false;
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
        private void FindButton_Deposit_Click(object sender, EventArgs e)
        {
            if (FindButton_Deposit.Text == "Find Again")
            {
                HideDepositGroupBox();
                return;
            }
            string s = SearchAccountTextbox.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Client c = FetchData.GetClientByAccountID(id);
                    Account account = FetchData.GetAccount(id);
                    if (c == null || account == null)
                    {
                        MessageBox.Show("Invalid Account ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DepositGroupBox.Show();
                    AccountOwnerPictureBox_Deposit.ImageLocation = c.ImageDir;
                    FindButton_Deposit.Text = "Find Again";
                    SearchAccountTextbox.Enabled = false;
                    AccountOwnerLabel.Text = "Account Owner: " + c.Firstname + " " + c.Lastname;
                    BalanceLabel.Text = "Balance: " + account.Balance;
                    AccountTypeLabel_Deposit.Text = "Account Type: " + account.AccountType;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void DepositButton_Deposit_Click(object sender, EventArgs e)
        {
            string s = DepositTextbox.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    double amount = Convert.ToDouble(s);
                    int id = Convert.ToInt32(SearchAccountTextbox.Text);
                    if (ModifyData.UpdateBalance(id, amount))
                    {
                        MessageBox.Show("Amount successfully added!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HideDepositGroupBox();
                        AccountOwnerPictureBox_Deposit.Image = null;
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Amount must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HideDepositGroupBox()
        {
            DepositGroupBox.Hide();
            FindButton_Deposit.Text = "Find";
            SearchAccountTextbox.Enabled = true;
            DepositTextbox.Text = "";
            SearchAccountTextbox.Text = "";
            AccountOwnerPictureBox_Deposit.Image = null;
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
        private void ResetCreateAccountDetails()
        {
            foreach (Control control in CreateAccountPanel.Controls)
            {
                if (control is TextBox)
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

                    InitialDepositTextbox.Text = "500";
                    InitialDepositTextbox.Enabled = false;
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
                else if (sender.Equals(DetailsButton))
                {
                    ResetChildButton(AccountPanel);
                    ResetAccountDetails();
                    DetailsPanel.BringToFront();
                    DetailsButton.BackColor = Color.FromArgb(22, 34, 54);
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
        private void HideAccountDetails()
        {
            AccountDetailsGroupBox.Hide();
        }
        private void ShowAccountDetails(Client client, Account account)
        {
            AccountDeatilsAccountIDLabel.Text = "AccountID: " + account.AccountID.ToString();
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
            AccountDeatilsAccountTypeLabel.Text = "Account Type: " + account.AccountType;
            AccountDeatilsAccountStatusLabel.Text = "Account Status: " + account.AccountStatus;
            ClientPictureBox.ImageLocation = client.ImageDir;

            AccountDetailsGroupBox.Show();
        }
        private void FindButton_Click(object sender, EventArgs e)
        {
            ResetResultGroupBox();
            string s = RecoverAccountTextBox.Text;
            if(s == "")
            {
                return;
            }
            else
            {
                try
                {
                    int nid = Convert.ToInt32(s);
                    List<Account> accounts = FetchData.GetAccountsByNID(nid);
                    Client client = FetchData.GetClientByNID(nid);
                    if(accounts == null)
                    {
                        MessageBox.Show("No client found!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if(accounts.Count > 0)
                    {
                        AccountOwnerPictureBox.ImageLocation = client.ImageDir;
                        int x = 0;
                        foreach(Account account in accounts)
                        {
                            Label l1 = new Label();
                            l1.AutoSize = true;
                            l1.Text = "Account ID: " + account.AccountID;
                            l1.Location = new Point(104, 69 + x * 25);
                            Label l2 = new Label();
                            l2.AutoSize = true;
                            l2.Text = "Account Type: " + account.AccountType;
                            l2.Location = new Point(380, 69 + x * 25);
                            AccountsResultGroupBox.Controls.Add(l1);
                            AccountsResultGroupBox.Controls.Add(l2);
                            x++;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Insert Valid ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ResetResultGroupBox()
        {
            foreach(Control control in AccountsResultGroupBox.Controls)
            {
                control.Text = null;
            }
            AccountOwnerPictureBox.Image = null;
        }
        private void ResetAccountDetails()
        {
            foreach(Control label in AccountDetailsGroupBox_Details.Controls)
            {
                if(label is Label)
                {
                    label.Text = "";
                }
            }
            AccountOwnerPictureBox_Details.Image = null;
        }
        private void SearchAccountTextbox_Details_TextChanged(object sender, EventArgs e)
        {
            string s = SearchAccountTextbox_Details.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Client client = FetchData.GetClientByAccountID(id);
                    Account account = FetchData.GetAccount(id);
                    if(client == null || account == null)
                    {
                        ResetAccountDetails();
                        return;
                    }
                    else
                    {
                        AccountIDLabel_Details.Text = "AccountID: " + account.AccountID.ToString();
                        FirstNameLabel_Details.Text = "Firstname: " + client.Firstname;
                        LastNameLabel_Details.Text = "Lastname: " + client.Lastname;
                        GenderLabel_Details.Text = "Gender: " + client.Gender;
                        NationalityLabel_Details.Text = "Nationality: " + client.Nationality;
                        NIDLabel_Details.Text = "NID: " + client.NID;
                        OccupationLabel_Details.Text = "Occupation: " + client.Occupation;
                        EmailLabel_Details.Text = "Email: " + client.Email;
                        DOBLabel_Details.Text = "Date of Birth: " + client.DOB;
                        PhoneNumberLabel_Details.Text = "Phone Numebr: " + client.PhoneNumber;
                        AddressLabel_Details.Text = "Address: " + client.Address;
                        AccountTypeLabel_Details.Text = "Account Type: " + account.AccountType;
                        AccountStatusLabel_Details.Text = "Account Status: " + account.AccountStatus;
                        AccountOwnerPictureBox_Details.ImageLocation = client.ImageDir;
                        BalanceLabel_Details.Text = "Balance: " + account.Balance;
                        DueLabelDetails.Text = "Due: " + account.Due;
                        CreateDateLabel_Details.Text = "Create Date: " + account.CreateDate;
                    }
                }
                catch(Exception)
                {
                    ResetAccountDetails();
                    return;
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

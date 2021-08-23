using BankManagementSystem.Database;
using BankManagementSystem.Entity;
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
        private Employee currentEmployee;
        private Client searchedClient;
        private Account searchedAccount;
        private Manager manager;

        //TODO: Dummy Data for Employees
        //TODO: Organize the Methods

        public Main(int id, string m=null)
        {
            InitializeComponent();
            HideAllPanel();
            DisableComponents();
            HideDepositGroupBox();
            DashboardPanel.BringToFront();
            AccountLogo.Location = new Point(9, AccountButton.Location.Y+10);
            ManagerLogo.Location = new Point(9, ManagerButton.Location.Y+10); 
            ClockTimer.Start();
            UpdateDashboard();
            if(m == null)
            {
                currentUser = FetchData.GetEmployeeName(id);
                currentEmployee = FetchData.GetEmployee(id);
                NameLabel.Text = currentUser;
                ManagerButton.Enabled = false;
                ManagerButton.BackColor = Color.Gray;
            }
            else
            {
                RegisterButton.Enabled = false;
                RegisterButton.BackColor = Color.Gray;
                AccountButton.Enabled = false;
                AccountButton.BackColor = Color.Gray;
                manager = FetchData.GetManager(id);
                NameLabel.Text = manager.Name;
            }
        }

        #region Register
        private void UpdateDashboard()
        {
            TotalTransacCounterLabel.Text = FetchData.GetTotalTransations().ToString();
            TotalAccountCounterLabel.Text = FetchData.GetTotalAccounts().ToString();
            AccountTodayLabel.Text = FetchData.GetTotalAccountsToday().ToString();
            TransacTodayLabel.Text = FetchData.GetTotalTransactionsToday().ToString();
        }
        private void MenuButtonsHandler(object sender, EventArgs e)
        {
            HideAllPanel();
            ResetAllButton();
            ResetChildButton();
            ((Button)sender).BackColor = Color.FromArgb(43, 63, 97);
            CurrentLabel.Text = ((Button)sender).Text;
            if (sender.Equals(DashboardButton))
            {
                UpdateDashboard();
                EnableManagerPanelButtons(null);
                DashboardPanel.BringToFront();
                if (manager != null)
                {
                    ResetAllMangerPanelControls();
                }
                if (currentEmployee != null)
                {
                    ResetPanel(RegisterPanel);
                    ResetCreateAccountDetails();
                    ResetResultGroupBox();
                    HideDepositGroupBox();
                }
            }
            else if (sender.Equals(RegisterButton))
            {
                HideAccountDetails();
                RegisterPanel.Show();
            }
            else if (sender.Equals(AccountButton))
            {
                ResetCreateAccountDetails();
                AccountPanel.Show();
            }
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (CheckEmptyCreateAccountFields())
            {
                ValidateErrorLabel.Text = "No fields can remain empty!";
                return;
            }
            else if (!VerifyName(FirstnameTextbox.Text+LastnameTextbox.Text))
            {
                ValidateErrorLabel.Text = "Name cannot contain number!";
                return;
            }
            else if (!VerifyEmail(EmailTextbox.Text))
            {
                ValidateErrorLabel.Text = "Invalid email format!";
                return;
            }
            else
            {
                ValidateErrorLabel.Text = "";
                string accType = AccountTypeComboBox.Text;
                Client c = new Client();
                Account account = new Account();

                c.Firstname = FirstnameTextbox.Text;
                c.Lastname = LastnameTextbox.Text;
                c.Nationality = NationalityTextbox.Text;
                try
                {
                    c.NID = Convert.ToInt64(NIDTextbox.Text);
                    c.PhoneNumber = Convert.ToInt64(PhoneNumberTextbox.Text);
                }
                catch (Exception)
                {
                    ValidateErrorLabel.Text = "Invalid NID/Phone Number";
                    return;
                }
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

        #region Deposit

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
                    if (account.AccountStatus.Equals("Closed"))
                    {
                        DepositButton_Deposit.Enabled = false;
                    }
                    DepositGroupBox.Show();
                    AccountOwnerPictureBox_Deposit.ImageLocation = c.ImageDir;
                    FindButton_Deposit.Text = "Find Again";
                    SearchAccountTextbox.Enabled = false;
                    AccountOwnerLabel.Text = "Account Owner: " + c.Firstname + " " + c.Lastname;
                    BalanceLabel.Text = "Balance: " + account.Balance;
                    AccountTypeLabel_Deposit.Text = "Account Type: " + account.AccountType;
                    AccountStatusLabel_Deposit.Text = "Account Status: " + account.AccountStatus;
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
                    if(amount <= 0)
                    {
                        DepositErrorLabel.Text = "Amount must be greater than 0.";
                        return;
                    }
                    int id = Convert.ToInt32(SearchAccountTextbox.Text);
                    if (ModifyData.UpdateBalance(id, amount))
                    {
                        if (!ModifyData.UpdateTransactionHistory(currentEmployee.ID, id, "Deposit", Convert.ToInt32(amount)))
                        {
                            MessageBox.Show("Error updating transaction!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            DepositButton_Deposit.Enabled = true;
            DepositGroupBox.Hide();
            FindButton_Deposit.Text = "Find";
            SearchAccountTextbox.Enabled = true;
            DepositTextbox.Text = "";
            SearchAccountTextbox.Text = "";
            AccountOwnerPictureBox_Deposit.Image = null;
            DepositErrorLabel.Text = "";
        }

        #endregion

        #region Withdraw

        private void Findbutton_Withdraw_Click(object sender, EventArgs e)
        {   
            if (Findbutton_Withdraw.Text == "Find Again")
            {
                HideWithdrawGroupBox();
                return;
            }
            string s = SearchAccounttextBox_Withdraw.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    WithdrawErrorLabel.Text = "";
                    int id = Convert.ToInt32(s);
                    Client c = FetchData.GetClientByAccountID(id);
                    Account account = FetchData.GetAccount(id);
                    if (c == null || account == null)
                    {
                        MessageBox.Show("Invalid Account ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (account.AccountStatus.Equals("Closed"))
                    {
                        Withdrawbutton_Withdraw.Enabled = false;
                    }
                    else
                    {
                        Withdrawbutton_Withdraw.Enabled = true;
                    }
                    groupBox_Withdraw.Show();
                    AccountOwnerpictureBox_Withdraw.ImageLocation = c.ImageDir;
                    Findbutton_Withdraw.Text = "Find Again";
                    SearchAccounttextBox_Withdraw.Enabled = false;
                    AccountOwnerlabel_Withdraw.Text = "Account Owner: " + c.Firstname + " " + c.Lastname;
                    Balancelabel_Withdraw.Text = "Balance: " + account.Balance;
                    AccountTypelabel_Withdraw.Text = "Account Type: " + account.AccountType;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void Withdrawbutton_Withdraw_Click(object sender, EventArgs e)
        {
            string s = WithdrawtextBox.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    double amount = Convert.ToDouble(s);
                    if (amount <= 0)
                    {
                        WithdrawErrorLabel.Text = "Amount must be greater than 0.";
                        return;
                    }
                    int id = Convert.ToInt32(SearchAccounttextBox_Withdraw.Text);
                    if (ModifyData.UpdateBalance(id, (-amount)))
                    {
                        if (!ModifyData.UpdateTransactionHistory(currentEmployee.ID, id, "Withdraw", Convert.ToInt32(amount)))
                        {
                            MessageBox.Show("Error updating transaction!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show("Amount successfully withdrawn!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HideWithdrawGroupBox();
                        AccountOwnerpictureBox_Withdraw.Image = null;
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Amount must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HideWithdrawGroupBox()
        {
            groupBox_Withdraw.Hide();
            Findbutton_Withdraw.Text = "Find";
            SearchAccounttextBox_Withdraw.Enabled = true;
            WithdrawtextBox.Text = "";
            SearchAccounttextBox_Withdraw.Text = "";
            AccountOwnerpictureBox_Withdraw.Image = null;
            WithdrawErrorLabel.Text = "";
        }

        #endregion

        #region Reset

        private void ResetAllButton()
        {
            foreach(Control button in MenuPanel.Controls)
            {
                if(button is Button)
                {
                    if (!button.Enabled)
                        continue;
                    button.Enabled = true;
                    button.BackColor = Color.FromArgb(31, 30, 68);  
                }
            }
            foreach(Control button in RegisterPanel.Controls)
            {
                if(button is Button)
                {
                    button.Enabled = true;
                    button.BackColor = Color.FromArgb(31, 30, 68);
                }
            }
            foreach (Control button in AccountPanel.Controls)
            {
                if (button is Button)
                {
                    button.Enabled = true;
                    button.BackColor = Color.FromArgb(31, 30, 68);
                }
            }
        }
        private void ResetChildButton(Panel panel)
        {
            foreach(Control button in panel.Controls)
            {
                if(button is Button)
                {
                    button.BackColor = Color.FromArgb(31, 30, 68);
                    button.Enabled = true;
                }
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

        #endregion Account

        private void SubmenuButtonsHandler(object sender, EventArgs e)
        {
            // Hide/Reset all active modules
            AccountDetailsGroupBox.Hide();

            if (sender is Button)
            {
                ResetChildButton(RegisterPanel);
                ResetChildButton(AccountPanel);
                ((Button)sender).BackColor = Color.LightGray;
                ((Button)sender).Enabled = false;
                CurrentLabel.Text = CurrentLabel.Text.Split(' ')[0] + " : " + ((Button)sender).Text;

                if (sender.Equals(CreateAccButton))
                {
                    CreateAccountPanel.BringToFront();

                    InitialDepositTextbox.Text = "500";
                    InitialDepositTextbox.Enabled = false;
                }
                else if (sender.Equals(CloseAccButton))
                {
                    CloseAccountPanel.BringToFront();
                }
                else if (sender.Equals(RecoverAccButton))
                {
                    RecoverAccountPanel.BringToFront();
                }
                else if (sender.Equals(DepositButton))
                {
                    DepositPanel.BringToFront();
                }
                else if (sender.Equals(WithdrawButton))
                {
                    WithdrawPanel.BringToFront();
                }
                else if (sender.Equals(TransferButton))
                {
                    TransferPanel.BringToFront();
                }
                else if (sender.Equals(DetailsButton))
                {
                    //AccountDetailsGroupBox_Details.Controls.Clear();
                    ResetGroupBoxControls(AccountDetailsGroupBox_Details);
                    DetailsPanel.BringToFront();
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
            AccountLogo.Location = new Point(9, AccountButton.Location.Y + 10);
        }
        private void LoanButton_LocationChanged(object sender, EventArgs e)
        {
            ManagerLogo.Location = new Point(9, ManagerButton.Location.Y + 10);
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
        
        private void SearchAccountTextbox_Details_TextChanged(object sender, EventArgs e)
        {
            string s = SearchAccountTextbox_Details.Text;
            if (s == "")
            {
                ResetGroupBoxControls(AccountDetailsGroupBox_Details);
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
                        //AccountDetailsGroupBox_Details.Controls.Clear();
                        ResetGroupBoxControls(AccountDetailsGroupBox_Details);
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
                    //AccountDetailsGroupBox_Details.Controls.Clear();
                    ResetGroupBoxControls(AccountDetailsGroupBox_Details);
                    return;
                }
            }
        }
        private bool VerifyEmail(string email)
        {
            //int indx = email.IndexOf('@');
            string[] slice = email.Split('@');
            if(slice.Length != 2)
            {
                return false;
            }
            else
            {
                if (slice[1].Equals("gmail.com"))
                {
                    if (IsNumber(((slice[0])[0]).ToString()))
                    {
                        //Console.WriteLine("asdas");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private bool VerifyName(string name)
        {
            foreach(char c in name)
            {
                try
                {
                    Convert.ToInt32(c.ToString());
                    return false;
                }
                catch
                {
                    
                }
            }
            return true;
        }
        private bool IsNumber(string ch)
        {
            try
            {
                int x = Convert.ToInt32(ch);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ManagerButton_Click(object sender, EventArgs e)
        {
            ManagerPanelDefaultPanel.BringToFront();
            DashboardButton.BackColor = Color.FromArgb(31, 30, 68);
            ManagerPanel.BringToFront();
            ManagerButton.BackColor = Color.FromArgb(43, 63, 97);
            CurrentLabel.Text = "Manager";
            EnableManagerPanelButtons(null);
            ResetAllMangerPanelControls();
        }
        private void ResetAllMangerPanelControls()
        {
            ResetGroupBoxControls(RegisterEmployeeGroupBox);
            ResetGroupBoxControls(RemoveEmployeeGroupBox);
            TransactionHistoryPanel.Controls.Clear();
            DetailsPanel_EmployeeDetails.Controls.Clear();
            ResetPanelControls(EmployeeDetailsPanel);
            ResetPanelControls(TransactionsPanel);
        }
        private void ManagerPanelButtonsHandler(object sender, EventArgs e)
        {
            if(sender.Equals(EmployeeDetailsButton))
            {
                EmployeeDetailsPanel.BringToFront();
                EmployeeDetailsButton.Enabled = false;
                EmployeeDetailsButton.BackColor = Color.Gray;
                EnableManagerPanelButtons(sender);
            }
            else if (sender.Equals(EditDetailsButton))
            {
                EditDetailsPanel.BringToFront();
                EditDetailsButton.Enabled = false;
                EditDetailsButton.BackColor = Color.Gray;
                EnableManagerPanelButtons(sender);
            }
            else if (sender.Equals(ManageButton))
            {
                ManagePanel.BringToFront();
                ManageButton.Enabled = false;
                ManageButton.BackColor = Color.Gray;
                ErrorLabel_Employee.Text = "";
                EnableManagerPanelButtons(sender);
            }
            else if (sender.Equals(TransactionsButton))
            {
                TransactionsPanel.BringToFront();
                TransactionsButton.Enabled = false;
                TransactionsButton.BackColor = Color.Gray;
                EnableManagerPanelButtons(sender);
            }
        }
        private void EnableManagerPanelButtons(object sender)
        {
            foreach(Button button in ManagerButtonsPanel.Controls)
            {
                if(sender != null)
                {
                    if (sender.Equals(button))
                    {
                        continue;
                    }
                }
                
                button.Enabled = true;
                button.BackColor = Color.FromArgb(26, 25, 62);
            }
        }
        private void FindAllButton_Click(object sender, EventArgs e)
        {
            DetailsPanel_EmployeeDetails.Controls.Clear();
            List<Employee> employees = FetchData.GetAllEmployees();
            foreach (Employee employee in employees)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "Employee";
                groupBox.ForeColor = Color.White;
                groupBox.Location = new Point(9, 9);
                groupBox.Dock = DockStyle.Top;
                groupBox.Size = new Size(715, 143);
                //groupBox.Padding = new Padding(0,0,0,10);

                Label l1 = new Label();
                l1.Text = "Name: " + employee.Name;
                l1.Location = new Point(39, 41);
                l1.AutoSize = true;
                Label l2 = new Label();
                l2.Text = "ID: " + employee.ID;
                l2.Location = new Point(60, 90);
                l2.AutoSize = true;
                Label l3 = new Label();
                l3.Text = "NID: " + employee.NID;
                l3.Location = new Point(220, 90);
                l3.AutoSize = true;
                Label l4 = new Label();
                l4.Text = "Gender: " + employee.Gender;
                l4.Location = new Point(434, 40);
                l4.AutoSize = true;
                Label l5 = new Label();
                l5.Text = "Date of Birth: " + employee.DOB;
                l5.Location = new Point(399, 90);
                l5.AutoSize = true;
                Label l6 = new Label();
                l6.Text = "Address: " + employee.Address;
                l6.Location = new Point(430, 64);
                l6.AutoSize = true;
                Label l7 = new Label();
                l7.Text = "Email: " + employee.Email;
                l7.Location = new Point(39, 67);
                l7.AutoSize = true;

                groupBox.Controls.Add(l1);
                groupBox.Controls.Add(l2);
                groupBox.Controls.Add(l3);
                groupBox.Controls.Add(l4);
                groupBox.Controls.Add(l5);
                groupBox.Controls.Add(l6);
                groupBox.Controls.Add(l7);

                DetailsPanel_EmployeeDetails.Controls.Add(groupBox);
            }
        }
        private void FindButton_EmployeeDetails_Click(object sender, EventArgs e)
        {
            string s = EmployeeIDTextbox.Text;
            if(s == "")
            {
                DetailsPanel_EmployeeDetails.Controls.Clear();
                return;
            }
            else
            {
                try
                {
                    DetailsPanel_EmployeeDetails.Controls.Clear();
                    int id = Convert.ToInt32(s);
                    Employee employee = FetchData.GetEmployee(id);
                    if(employee == null)
                    {
                        MessageBox.Show("Invalid employee id!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DetailsPanel_EmployeeDetails.Controls.Clear();
                        return;
                    }
                    else
                    {
                        GroupBox groupBox = new GroupBox();
                        groupBox.Text = "Employee";
                        groupBox.ForeColor = Color.White;
                        groupBox.Location = new Point(9, 9);
                        groupBox.Dock = DockStyle.Top;
                        groupBox.Size = new Size(715, 143);

                        Label l1 = new Label();
                        l1.Text = "Name: " + employee.Name;
                        l1.Location = new Point(39, 41);
                        l1.AutoSize = true;
                        Label l2 = new Label();
                        l2.Text = "ID: " + employee.ID;
                        l2.Location = new Point(60, 90);
                        l2.AutoSize = true;
                        Label l3 = new Label();
                        l3.Text = "NID: " + employee.NID;
                        l3.Location = new Point(220, 90);
                        l3.AutoSize = true;
                        Label l4 = new Label();
                        l4.Text = "Gender: " + employee.Gender;
                        l4.Location = new Point(434, 40);
                        l4.AutoSize = true;
                        Label l5 = new Label();
                        l5.Text = "Date of Birth: " + employee.DOB;
                        l5.Location = new Point(399, 90);
                        l5.AutoSize = true;
                        Label l6 = new Label();
                        l6.Text = "Address: " + employee.Address;
                        l6.Location = new Point(430, 64);
                        l6.AutoSize = true;
                        Label l7 = new Label();
                        l7.Text = "Email: " + employee.Email;
                        l7.Location = new Point(39, 67);
                        l7.AutoSize = true;

                        groupBox.Controls.Add(l1);
                        groupBox.Controls.Add(l2);
                        groupBox.Controls.Add(l3);
                        groupBox.Controls.Add(l4);
                        groupBox.Controls.Add(l5);
                        groupBox.Controls.Add(l6);
                        groupBox.Controls.Add(l7);

                        DetailsPanel_EmployeeDetails.Controls.Add(groupBox);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Input!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DetailsPanel_EmployeeDetails.Controls.Clear();
                    return;
                }
            }
        }
        private void FindButtion_Transactions_Click(object sender, EventArgs e)
        {
            string s = EmployeeIDTextBox_Transactions.Text;
            if (s == "")
            {
                TransactionHistoryPanel.Controls.Clear();
                return;
            }
            else
            {
                try
                {
                    TransactionHistoryPanel.Controls.Clear();
                    int id = Convert.ToInt32(s);
                    Employee employee = FetchData.GetEmployee(id);
                    List<Transactions> transactions = FetchData.GetTransactionHistory(id);
                    Client client;
                    if(employee == null)
                    {
                        MessageBox.Show("Invalid employee id!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TransactionHistoryPanel.Controls.Clear();
                        return;
                    }
                    else if(transactions == null)
                    {
                        TransactionHistoryPanel.Controls.Clear();
                        return;
                    }
                    foreach (Transactions transaction in transactions)
                    {
                        client = FetchData.GetClientByAccountID(transaction.AccountID);

                        GroupBox groupBox = new GroupBox();
                        groupBox.Text = transaction.TransactionType;
                        groupBox.ForeColor = Color.White;
                        groupBox.Dock = DockStyle.Top;
                        groupBox.Size = new Size(720, 112);

                        Label l1 = new Label();
                        l1.Text = "Transaction Amount: " + transaction.TransactionAmount;
                        l1.Location = new Point(70, 38);
                        l1.AutoSize = true;
                        Label l2 = new Label();
                        l2.Text = "Account ID: " + transaction.AccountID;
                        l2.Location = new Point(127, 66);
                        l2.AutoSize = true;
                        Label l3 = new Label();
                        l3.Text = "Transaction ID: " + transaction.ID;
                        l3.Location = new Point(405, 66);
                        l3.AutoSize = true;
                        Label l4 = new Label();
                        l4.Text = "Owner Name: " + (client.Firstname+" "+client.Lastname);
                        l4.Location = new Point(417, 44);
                        l4.AutoSize = true;

                        groupBox.Controls.Add(l1);
                        groupBox.Controls.Add(l2);
                        groupBox.Controls.Add(l3);
                        groupBox.Controls.Add(l4);

                        TransactionHistoryPanel.Controls.Add(groupBox);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Input!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TransactionHistoryPanel.Controls.Clear();
                    return;
                }
            }
        }

        #region Transfer

        private void HidetransferGroupBox()
        {
            transferGroupBox_Transfer.Hide();
            findButton_Transfer.Text = "Find";
            accNumberSearchTextBox_Transfer.Enabled = true;
            enterAmountTextBox_Transfer.Text = "";
            accNumberSearchTextBox_Transfer.Text = "";
            AccountOwnerpictureBox_Transfer.Image = null;
            transferErrorLabel.Text = "";
        }
        private void ResetTransfer()
        {
            recAccNumberTextBox_Transfer.Text = "";
            accOwnerLabel_Transfer.Text = "Account Owner: ";
            accTypeLabel_Transfer.Text = "Account Type";
            recAccFindButton_Transfer.Text = "Find";
            recAccNumberTextBox_Transfer.Enabled = true;
            enterAmountTextBox_Transfer.Text = "";
            transferErrorLabel.Text = "";
        }
        private void findButton_Transfer_Click(object sender, EventArgs e)
        {
            if (findButton_Transfer.Text == "Find Again")
            {
                HidetransferGroupBox();
                ResetTransfer();
                return;
            }
            string s = accNumberSearchTextBox_Transfer.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    transferErrorLabel.Text = "";
                    int id = Convert.ToInt32(s);
                    Client c = FetchData.GetClientByAccountID(id);
                    Account account = FetchData.GetAccount(id);
                    if (c == null || account == null)
                    {
                        MessageBox.Show("Invalid Account ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    transferGroupBox_Transfer.Show();
                    AccountOwnerpictureBox_Transfer.ImageLocation = c.ImageDir;
                    findButton_Transfer.Text = "Find Again";
                    accNumberSearchTextBox_Transfer.Enabled = false;
                    senderAccOwnerLabel_Transfer.Text = "Account Owner: " + c.Firstname + " " + c.Lastname;
                    senderBalanceLabel_Transfer.Text = "Balance: " + account.Balance;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void recAccFindButton_Transfer_Click(object sender, EventArgs e)
        {
            if (recAccFindButton_Transfer.Text == "Find Again")
            {
                ResetTransfer();
            }
            string s = recAccNumberTextBox_Transfer.Text;
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
                    int senderId = Convert.ToInt32(accNumberSearchTextBox_Transfer.Text);
                    if (c == null || account == null || account.AccountID == senderId)
                    {
                        MessageBox.Show("Invalid Account ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        recAccNumberTextBox_Transfer.Text = "";
                        return;
                    }
                    if (account.AccountStatus.Equals("Closed"))
                    {
                        transferButton_Transfer.Enabled = false;
                    }
                    else
                    {
                        transferButton_Transfer.Enabled = true;
                    }
                    transferGroupBox_Transfer.Show();
                    recAccFindButton_Transfer.Text = "Find Again";
                    recAccNumberTextBox_Transfer.Enabled = false;
                    accOwnerLabel_Transfer.Text = "Account Owner: " + c.Firstname + " " + c.Lastname;
                    accTypeLabel_Transfer.Text = "Account Type: " + account.AccountType;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Account Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void transferButton_Transfer_Click(object sender, EventArgs e)
        {
            string s = enterAmountTextBox_Transfer.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    double amount = Convert.ToDouble(s);
                    if (amount <= 0)
                    {
                        transferErrorLabel.Text = "Amount must be greater than 0.";
                        return;
                    }
                    int recId = Convert.ToInt32(recAccNumberTextBox_Transfer.Text);
                    int senderId = Convert.ToInt32(accNumberSearchTextBox_Transfer.Text);
                    if ((ModifyData.UpdateBalance(recId, amount)) && (ModifyData.UpdateBalance(senderId, (-amount))))
                    {
                        if (!ModifyData.UpdateTransactionHistory(currentEmployee.ID, recId, "Transfer", Convert.ToInt32(amount)))
                        {
                            MessageBox.Show("Error updating transaction!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show("Amount successfully added!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HidetransferGroupBox();
                        accOwnerLabel_Transfer.Text = "Account Owner: ";
                        accTypeLabel_Transfer.Text = "Account Type";
                        AccountOwnerpictureBox_Transfer.Image = null;
                        ResetTransfer();
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Amount must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void RegisterButton_Manage_Click(object sender, EventArgs e)
        {
            if (CheckRegisterEmployeeEmptyFields())
            {
                if (!VerifyName(NameTextBox_Employee.Text))
                {
                    ErrorLabel_Employee.Text = "Name can't contain numeric value!";
                    return;
                }
                else if (!VerifyEmail(EmailTextBox_Employee.Text))
                {
                    ErrorLabel_Employee.Text = "Invalid email format!";
                    return;
                }
                else
                {
                    ErrorLabel_Employee.Text = "";
                    Employee employee = new Employee();
                    employee.Name = NameTextBox_Employee.Text;
                    employee.Address = AddressTextBox_Employee.Text;
                    employee.Password = PasswordTextBox_Employee.Text;
                    employee.NID = Convert.ToInt32(NIDTextBox_Employee.Text);
                    employee.PhoneNumber = Convert.ToInt64(PhoneNumberTextBox_Employee.Text);
                    employee.Email = EmailTextBox_Employee.Text;
                    if (MaleRadioButton_Employee.Checked)
                        employee.Gender = MaleRadioButton_Employee.Text;
                    else
                        employee.Gender = FemaleRadioButton_Employee.Text;
                    employee.DOB = DateTimePicker_Employee.Text;
                    if (Registration.RegisterEmployee(employee))
                    {
                        MessageBox.Show("Employee created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGroupBoxControls(RegisterEmployeeGroupBox);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error creating new employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Modified Testing
                        ResetGroupBoxControls(RegisterEmployeeGroupBox);
                        return;
                    }
                }
                
            }
            else
            {
                ErrorLabel_Employee.Text = "Fields can't be empty!";
                return;
            }
        }
        private bool CheckRegisterEmployeeEmptyFields()
        {
            foreach(Control control in RegisterEmployeeGroupBox.Controls)
            {
                if(control is TextBox)
                {
                    if(control.Text == "")
                    {
                        return false;
                    }
                }
            }
            if(!MaleRadioButton_Employee.Checked && !FemaleRadioButton_Employee.Checked)
            {
                return false;
            }

            return true;
        }
        //TODO
        /*private void ClearManagerPanelManageControls()
        {
            foreach(Control control in RegisterEmployeeGroupBox.Controls)
            {
                if(control is TextBox)
                {
                    control.Text = "";
                }
                else if(control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else
                {
                    DateTimePicker_Employee.ResetText();
                }
            }
        }*/
        private void FindButton_RemoveEmployee_Click(object sender, EventArgs e)
        {
            string s = FindEmployeeTextbox_RemoveEmployee.Text;
            if(FindButton_RemoveEmployee.Text.Equals("Find Again"))
            {
                ResetGroupBoxControls(RemoveEmployeeGroupBox);
                RemoveButton.Enabled = false;
                FindButton_RemoveEmployee.Text = "Find";
                FindEmployeeTextbox_RemoveEmployee.Enabled = true;
                return;
            }
            if(s == "")
            {
                ResetGroupBoxControls(RemoveEmployeeGroupBox);
                return;
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Employee employee = FetchData.GetEmployee(id);
                    if(employee == null)
                    {
                        ResetGroupBoxControls(RemoveEmployeeGroupBox);
                        MessageBox.Show("No employee found!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        NameLabel_RemoveEmployee.Text = "Name: " + employee.Name;
                        PhoneNumberLabel_RemoveEmployee.Text = "Phone Number: " + employee.PhoneNumber;
                        NIDLabel_RemoveEmployee.Text = "National ID: " + employee.NID;
                        FindButton_RemoveEmployee.Text = "Find Again";  //reset to default
                        FindEmployeeTextbox_RemoveEmployee.Enabled = false;
                        RemoveButton.Enabled = true ;
                    }
                }
                catch(Exception)
                {
                    ResetGroupBoxControls(RemoveEmployeeGroupBox);
                    MessageBox.Show("Invalid id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you wish to remove this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                int id = Convert.ToInt32(FindEmployeeTextbox_RemoveEmployee.Text);
                if (ModifyData.RemoveEmployee(id))
                {
                    ResetGroupBoxControls(RemoveEmployeeGroupBox);
                    MessageBox.Show("Employee removed!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    ResetGroupBoxControls(RemoveEmployeeGroupBox);
                    MessageBox.Show("Error in removing employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
            
        }
        private void ResetPanelControls(Panel panel)
        {
            foreach(Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
                else if (control is Label)
                {
                    if (control.Name.StartsWith("label"))
                        continue;
                    else
                        control.Text = "";
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).ResetText();
                }
                else if(control is PictureBox)
                {
                    ((PictureBox)control).ImageLocation = null;
                }
            }
        }
        private void ResetGroupBoxControls(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
                else if (control is Label)
                {
                    if(groupBox.Name.Equals("RegisterEmployeeGroupBox"))
                        continue;
                    else if (control.Name.StartsWith("label"))
                        continue;
                    else
                        control.Text = "";
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if(control is DateTimePicker)
                {
                    ((DateTimePicker)control).ResetText();
                }
                else if (control is PictureBox)
                {
                    ((PictureBox)control).ImageLocation = null;
                }
            }
        }

        private void FindButton_ED_Click(object sender, EventArgs e)
        {
            if (FindButton_ED.Text == "Find Again")
            {
               HideEditDetailsGroupBox();
                return;
            }
            string s = SearchboxEmployee_ED.Text;
            if (s == "")
            {
                return;
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(s);
                    Employee employee = FetchData.GetEmployee(id);
                    if (employee == null)
                    {
                        MessageBox.Show("No Employee Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    else
                    {
                        FindButton_ED.Text = "Find Again";
                        groupBox_ED.Show();
                        SearchboxEmployee_ED.Enabled = false;
                        EmployeeID_ED.Text = "ID: " + employee.ID;
                        Name_ED.Text = "Name: " + employee.Name;
                        EmailtextBox_ED.Text = employee.Email;
                        PhonetextBox_ED.Text = Convert.ToString(employee.PhoneNumber);
                        AddresstextBox_ED.Text = employee.Address;
                        


                    }
                }
                catch
                {
                    MessageBox.Show("Enter Valid Employee ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void HideEditDetailsGroupBox()
        {
            groupBox_ED.Hide();
            FindButton_ED.Text = "Find";
            SearchboxEmployee_ED.Enabled = true;
            SearchboxEmployee_ED.Text = "";
            EmailError_ED.Hide();
            EmailError_ED.Text = "";
            NumberError_ED.Hide();
            NumberError_ED.Text = ""; 

        }
        private void Update_Button_ED_Click(object sender, EventArgs e)
        {
            string email = EmailtextBox_ED.Text;   //st VerifyEmail
            string s2 = PhonetextBox_ED.Text;  //long
            string address = AddresstextBox_ED.Text; //st 

            if (email == "" || s2 == "" || address == "")
            {
                MessageBox.Show("Fields can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
            {
                try
                {

                    long phoneNumber = Convert.ToInt64(s2);
                    int id = Convert.ToInt32(SearchboxEmployee_ED.Text);
                    if (!VerifyEmail(email))
                    {

                        EmailError_ED.Text = "Invalid email format!";
                        EmailError_ED.Show();
                        return;
                       
                    }
                    else
                    {
                        EmailError_ED.Hide();
                    }
                    DialogResult dr = MessageBox.Show("Do you want to confirm these changes?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.No)
                    {
                        return;
                    }
                    if (ModifyData.UpdateEmployeeInfo(id, email, phoneNumber, address))
                    {

                        MessageBox.Show("Details successfully added!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HideEditDetailsGroupBox();
                        return;
                    }

                    else
                    {

                        MessageBox.Show("Error updating details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    NumberError_ED.Show();
                    NumberError_ED.Text = "Number can not contain any character!";
                }
            }
        }
    }
}

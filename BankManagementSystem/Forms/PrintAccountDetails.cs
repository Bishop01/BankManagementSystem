using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem.Forms
{
    public partial class PrintAccountDetails : Form
    {
        private Client client;
        public PrintAccountDetails(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void LoadDetails()
        {
            AccountDeatilsAccountIDLabel.Text = "AccountID: "+client.AccountID.ToString();
            AccountDeatilsFirstNameLabel.Text = "Firstname: "+client.Firstname;
            AccountDeatilsLastNameLabel.Text = "Lastname: "+client.Lastname;
            AccountDeatilsGenderLabel.Text = "Gender: "+client.Gender;
            AccountDeatilsNationalityLabel.Text = "Nationality: "+client.Nationality;
            AccountDeatilsNIDLabel.Text = "NID: "+client.NID;
            AccountDeatilsOccupationLabel.Text = "Occupation: "+client.Occupation;
            AccountDeatilsEmailLabel.Text = "Email: "+client.Email;
            AccountDeatilsDOBLabel.Text = "Date of Birth: "+client.DOB;
            AccountDetailsPhoneNumberLabel.Text = "Phone Numebr: "+client.PhoneNumber;
            AccountDeatilsAddressLabel.Text = "Address: "+client.Address;
            AccountDeatilsAccountTypeLabel.Text = "Account Type: "+client.AccountType;
            AccountDeatilsAccountStatusLabel.Text = "Account Status: "+client.AccountStatus;
            ClientPictureBox.ImageLocation = client.ImageDir;
        }

        private void PrintAccountDetails_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void PrintAccountDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}

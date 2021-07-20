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
    public partial class RegisterEmployee : Form
    {
        public RegisterEmployee()
        {
            InitializeComponent();
            ErrorLabel.Text = null;
            RegisterButton.Enabled = false;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = null;
            Employee emp = new Employee();
            emp.Name = NameTextbox.Text;
            emp.Password = PasswordTextbox.Text;
            emp.Email = EmailTextbox.Text;
            emp.Address = AddressTextbox.Text;
            emp.NID = NIDTextbox.Text;
            emp.PhoneNumber = PNTextbox.Text;
            if (MaleRadioButton.Checked)
                emp.Gender = MaleRadioButton.Text;
            else
                emp.Gender = FemaleRadioButton.Text;
            emp.DOB = DOBDateTimePicker.Text;

            if (ValidateFields(emp))
            {
                if (DatabaseHandler.RegisterEmployee(emp))
                {
                    MessageBox.Show("Employee successfully registered!", "Success");
                    this.Dispose();
                    return;
                }
                else
                {
                    MessageBox.Show("Employee registration failed! Try Again.");
                    //this.Dispose();
                    return;
                }
            }
        }
        
        private bool ValidateFields(Employee emp)
        {
            if(emp.Name == "" || emp.Password == "" || emp.Email == "" || emp.Address == "" || emp.NID == "" || emp.PhoneNumber == "" || emp.Gender == "")
            {
                ErrorLabel.Text = "Fields can't be empty!";
                return false;
            }
            else if (!emp.Password.Equals(CPasswordTextbox.Text))
            {
                ErrorLabel.Text = "Password and Confirm Password must match!";
                return false;
            }
            else if(!MaleRadioButton.Checked && !FemaleRadioButton.Checked)
            {
                ErrorLabel.Text = "Gender must be checked either male or female!";
                return false;
            }
            else if(emp.PhoneNumber != "")
            {
                try
                {
                    int x = Convert.ToInt32(emp.PhoneNumber);
                    emp.PhoneNumber = "+880" + emp.PhoneNumber;
                    return true;
                }
                catch (FormatException)
                {
                    ErrorLabel.Text = "Phone number must be valid!";
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void TextBoxEnterColorChange(object sender, EventArgs e)
        {
            if (sender.Equals(NameTextbox))
            {
                NameTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(PasswordTextbox))
            {
                PasswordTextbox.BackColor = Color.FromArgb(22, 67, 99);
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
            else if (sender.Equals(NIDTextbox))
            {
                NIDTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else if (sender.Equals(CPasswordTextbox))
            {
                CPasswordTextbox.BackColor = Color.FromArgb(22, 67, 99);
                return;
            }
            else
            {
                return;
            }
        }
        private void TextBoxLeaveColorChange(object sender, EventArgs e)
        {
            if (sender.Equals(NameTextbox))
            {
                NameTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(PasswordTextbox))
            {
                PasswordTextbox.BackColor = Color.FromArgb(34, 33, 74);
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
            else if (sender.Equals(NIDTextbox))
            {
                NIDTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else if (sender.Equals(CPasswordTextbox))
            {
                CPasswordTextbox.BackColor = Color.FromArgb(34, 33, 74);
                return;
            }
            else
            {
                return;
            }
        }

        private void RegisterEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void TermsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TermsCheckBox.Checked)
            {
                RegisterButton.Enabled = true;
            }
            else
            {
                RegisterButton.Enabled = false;
            }
        }
    }
}

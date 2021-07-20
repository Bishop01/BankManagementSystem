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
        //private List<Control> controls = new List<Control>();
        private int AccountButtonPosition;
        private int LoanButtonPosition;
        public Main(string name)
        {
            InitializeComponent();
            HideAllPanel();
            DisableComponents();
            DashboardPanel.BringToFront();
            AccountButtonPosition = AccountButton.Location.Y;
            LoanButtonPosition = LoanButton.Location.Y;
            ClockTimer.Start();
            NameLabel.Text = name;
            AccountPictureBox.Location = new Point(9, 243);
            LoanPictureBox.Location = new Point(9, 525);
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
        private void CreateAccButton_Click(object sender, EventArgs e)
        {
            ResetChildButton(RegisterPanel);
            CreateAccButton.BackColor = Color.FromArgb(22, 34, 54);
            CreateAccountPanel.BringToFront();
        }
        private void CloseAccButton_Click(object sender, EventArgs e)
        {
            ResetChildButton(RegisterPanel);
            CloseAccButton.BackColor = Color.FromArgb(22, 34, 54);
            CloseAccountPanel.BringToFront();
        }
        private void RecoverAccButton_Click(object sender, EventArgs e)
        {
            ResetChildButton(RegisterPanel);
            RecoverAccButton.BackColor = Color.FromArgb(22, 34, 54);
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ValidateErrorLabel.Text = "IMPLEMENT ALL THE SHITS FIRST!";
        }

        private void AccountButton_LocationChanged(object sender, EventArgs e)
        {
            int changed = AccountButtonPosition - AccountButton.Location.Y;
            AccountButtonPosition = AccountButton.Location.Y;
            AccountPictureBox.Location = new Point(AccountPictureBox.Location.X, AccountPictureBox.Location.Y-changed);
        }

        private void LoanButton_LocationChanged(object sender, EventArgs e)
        {
            {
                int changed = LoanButtonPosition - LoanButton.Location.Y;
                LoanButtonPosition = LoanButton.Location.Y;
                LoanPictureBox.Location = new Point(LoanPictureBox.Location.X, LoanPictureBox.Location.Y - changed);
            }
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
    }
}

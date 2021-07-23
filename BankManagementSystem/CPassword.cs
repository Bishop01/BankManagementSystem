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
    public partial class CPassword : Form
    {
        public CPassword()
        {
            InitializeComponent();
            ErrorLabel.Text = "";
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            int eid;
            try
            {
                eid = Convert.ToInt32(EmployeeIDTextbox.Text);
            }
            catch (FormatException)
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            string nid = NIDTextbox.Text;
            string currPass = CurrPasswordTextbox.Text;
            string newPass = NewPasswordTextbox.Text;
            
            if (IsFieldEmpty())
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            else if (!DatabaseHandler.ValidateReset(eid, nid, currPass))
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            else
            {
                ErrorLabel.Text = "";
                if(DatabaseHandler.UpdatePassword(eid, newPass))
                {
                    MessageBox.Show("Password Updated!","Success");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Could Not Update Password!", "Error");
                }
            }
        }

        private bool IsFieldEmpty()
        {
            if(NIDTextbox.Text == "" || EmployeeIDTextbox.Text == "" || CurrPasswordTextbox.Text == "" || NewPasswordTextbox.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}

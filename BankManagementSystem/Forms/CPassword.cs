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
            long nid;
            try
            {
                eid = Convert.ToInt32(EmployeeIDTextbox.Text);
                nid = Convert.ToInt64(NIDTextbox.Text);
            }
            catch (Exception)
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            
            string currPass = CurrPasswordTextbox.Text;
            string newPass = NewPasswordTextbox.Text;
            
            if (IsFieldEmpty())
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            else if (!DataVerification.ValidateReset(eid, nid, currPass))
            {
                ErrorLabel.Text = "Error! No such employee exists!";
                return;
            }
            else
            {
                ErrorLabel.Text = "";
                if(Registration.UpdatePassword(eid, newPass))
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

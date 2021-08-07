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
    public partial class DBAdmin : Form
    {
        public DBAdmin()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            int Id=0;
            string id = IDTextbox.Text;
            string Pass = PasswordTextbox.Text;
            if(id == "" || Pass == "")
            {
                ErrorMessage();
                return;
            }
            else
            {
                try
                {
                    Id = Convert.ToInt32(id);
                }
                catch(FormatException)
                {
                    ErrorMessage();
                    return;
                }
            }

            if (!DataVerification.ValidateManager(Id, Pass))
            {
                ErrorMessage();
                return;
            }
            else
            {
                this.Dispose();
                new RegisterEmployee().ShowDialog();
                return;
            }
        }

        private void ErrorMessage()
        {
            MessageBox.Show("Permission not aquired!", "Error!");
            this.Dispose();
        }

        private void DBAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}

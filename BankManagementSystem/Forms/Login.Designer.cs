
namespace BankManagementSystem
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginImagePanel = new System.Windows.Forms.Panel();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ManagerCheckBox = new System.Windows.Forms.CheckBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.LoginErrorLabel = new System.Windows.Forms.Label();
            this.PasswordErrorLabel = new System.Windows.Forms.Label();
            this.IdErrorLabel = new System.Windows.Forms.Label();
            this.RecoverLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.EmployeeIdTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmployeeIdLabel = new System.Windows.Forms.Label();
            this.LoginImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginImagePanel
            // 
            this.LoginImagePanel.Controls.Add(this.ImagePictureBox);
            this.LoginImagePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LoginImagePanel.Location = new System.Drawing.Point(0, 0);
            this.LoginImagePanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.LoginImagePanel.Name = "LoginImagePanel";
            this.LoginImagePanel.Size = new System.Drawing.Size(199, 387);
            this.LoginImagePanel.TabIndex = 0;
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ImagePictureBox.Image")));
            this.ImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(199, 387);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ManagerCheckBox);
            this.panel2.Controls.Add(this.LogoPictureBox);
            this.panel2.Controls.Add(this.LoginErrorLabel);
            this.panel2.Controls.Add(this.PasswordErrorLabel);
            this.panel2.Controls.Add(this.IdErrorLabel);
            this.panel2.Controls.Add(this.RecoverLinkLabel);
            this.panel2.Controls.Add(this.LoginButton);
            this.panel2.Controls.Add(this.PasswordTextbox);
            this.panel2.Controls.Add(this.EmployeeIdTextbox);
            this.panel2.Controls.Add(this.PasswordLabel);
            this.panel2.Controls.Add(this.EmployeeIdLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(199, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 387);
            this.panel2.TabIndex = 1;
            // 
            // ManagerCheckBox
            // 
            this.ManagerCheckBox.AutoSize = true;
            this.ManagerCheckBox.FlatAppearance.BorderSize = 0;
            this.ManagerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManagerCheckBox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerCheckBox.Location = new System.Drawing.Point(416, 30);
            this.ManagerCheckBox.Name = "ManagerCheckBox";
            this.ManagerCheckBox.Size = new System.Drawing.Size(92, 24);
            this.ManagerCheckBox.TabIndex = 11;
            this.ManagerCheckBox.Text = "Manager";
            this.ManagerCheckBox.UseVisualStyleBackColor = true;
            this.ManagerCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.InitialImage")));
            this.LogoPictureBox.Location = new System.Drawing.Point(156, 30);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(200, 123);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 10;
            this.LogoPictureBox.TabStop = false;
            // 
            // LoginErrorLabel
            // 
            this.LoginErrorLabel.AutoSize = true;
            this.LoginErrorLabel.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.LoginErrorLabel.Location = new System.Drawing.Point(93, 267);
            this.LoginErrorLabel.Name = "LoginErrorLabel";
            this.LoginErrorLabel.Size = new System.Drawing.Size(35, 16);
            this.LoginErrorLabel.TabIndex = 8;
            this.LoginErrorLabel.Text = "error";
            // 
            // PasswordErrorLabel
            // 
            this.PasswordErrorLabel.AutoSize = true;
            this.PasswordErrorLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordErrorLabel.Location = new System.Drawing.Point(395, 236);
            this.PasswordErrorLabel.Name = "PasswordErrorLabel";
            this.PasswordErrorLabel.Size = new System.Drawing.Size(133, 16);
            this.PasswordErrorLabel.TabIndex = 7;
            this.PasswordErrorLabel.Text = "Field can\'t be empty!";
            // 
            // IdErrorLabel
            // 
            this.IdErrorLabel.AutoSize = true;
            this.IdErrorLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.IdErrorLabel.Location = new System.Drawing.Point(395, 194);
            this.IdErrorLabel.Name = "IdErrorLabel";
            this.IdErrorLabel.Size = new System.Drawing.Size(133, 16);
            this.IdErrorLabel.TabIndex = 6;
            this.IdErrorLabel.Text = "Field can\'t be empty!";
            // 
            // RecoverLinkLabel
            // 
            this.RecoverLinkLabel.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.RecoverLinkLabel.AutoSize = true;
            this.RecoverLinkLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecoverLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.RecoverLinkLabel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.RecoverLinkLabel.Location = new System.Drawing.Point(91, 288);
            this.RecoverLinkLabel.Name = "RecoverLinkLabel";
            this.RecoverLinkLabel.Size = new System.Drawing.Size(149, 16);
            this.RecoverLinkLabel.TabIndex = 5;
            this.RecoverLinkLabel.TabStop = true;
            this.RecoverLinkLabel.Text = "Forgot ID or Password?";
            this.RecoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecoverLinkLabel_LinkClicked);
            this.RecoverLinkLabel.MouseEnter += new System.EventHandler(this.RecoverLinkLabel_MouseEnter);
            this.RecoverLinkLabel.MouseLeave += new System.EventHandler(this.RecoverLinkLabel_MouseLeave);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Location = new System.Drawing.Point(314, 279);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 32);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.PasswordTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextbox.Location = new System.Drawing.Point(215, 230);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(174, 27);
            this.PasswordTextbox.TabIndex = 3;
            // 
            // EmployeeIdTextbox
            // 
            this.EmployeeIdTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.EmployeeIdTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeIdTextbox.ForeColor = System.Drawing.Color.White;
            this.EmployeeIdTextbox.Location = new System.Drawing.Point(215, 188);
            this.EmployeeIdTextbox.Name = "EmployeeIdTextbox";
            this.EmployeeIdTextbox.Size = new System.Drawing.Size(174, 27);
            this.EmployeeIdTextbox.TabIndex = 2;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(115, 233);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 20);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // EmployeeIdLabel
            // 
            this.EmployeeIdLabel.AutoSize = true;
            this.EmployeeIdLabel.Location = new System.Drawing.Point(171, 194);
            this.EmployeeIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.EmployeeIdLabel.Name = "EmployeeIdLabel";
            this.EmployeeIdLabel.Size = new System.Drawing.Size(35, 20);
            this.EmployeeIdLabel.TabIndex = 0;
            this.EmployeeIdLabel.Text = "ID:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(740, 387);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LoginImagePanel);
            this.Font = new System.Drawing.Font("Century", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.LoginImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginImagePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox EmployeeIdTextbox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label EmployeeIdLabel;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.LinkLabel RecoverLinkLabel;
        private System.Windows.Forms.Label IdErrorLabel;
        private System.Windows.Forms.Label PasswordErrorLabel;
        private System.Windows.Forms.Label LoginErrorLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.CheckBox ManagerCheckBox;
    }
}
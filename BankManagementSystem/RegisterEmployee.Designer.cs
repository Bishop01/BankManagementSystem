
namespace BankManagementSystem
{
    partial class RegisterEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterEmployee));
            this.DOBGroupBox = new System.Windows.Forms.GroupBox();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NIDTextbox = new System.Windows.Forms.TextBox();
            this.NIDLabel = new System.Windows.Forms.Label();
            this.PNTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PNLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CPasswordTextbox = new System.Windows.Forms.TextBox();
            this.CPasswordLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.DOBDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DOBLabel = new System.Windows.Forms.Label();
            this.TermsCheckBox = new System.Windows.Forms.CheckBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.DOBGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DOBGroupBox
            // 
            this.DOBGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DOBGroupBox.Controls.Add(this.RegisterButton);
            this.DOBGroupBox.Controls.Add(this.ErrorLabel);
            this.DOBGroupBox.Controls.Add(this.TermsCheckBox);
            this.DOBGroupBox.Controls.Add(this.DOBLabel);
            this.DOBGroupBox.Controls.Add(this.DOBDateTimePicker);
            this.DOBGroupBox.Controls.Add(this.FemaleRadioButton);
            this.DOBGroupBox.Controls.Add(this.MaleRadioButton);
            this.DOBGroupBox.Controls.Add(this.GenderLabel);
            this.DOBGroupBox.Controls.Add(this.CPasswordTextbox);
            this.DOBGroupBox.Controls.Add(this.CPasswordLabel);
            this.DOBGroupBox.Controls.Add(this.AddressTextbox);
            this.DOBGroupBox.Controls.Add(this.AddressLabel);
            this.DOBGroupBox.Controls.Add(this.NIDTextbox);
            this.DOBGroupBox.Controls.Add(this.NIDLabel);
            this.DOBGroupBox.Controls.Add(this.PNTextbox);
            this.DOBGroupBox.Controls.Add(this.label5);
            this.DOBGroupBox.Controls.Add(this.PNLabel);
            this.DOBGroupBox.Controls.Add(this.EmailTextbox);
            this.DOBGroupBox.Controls.Add(this.EmailLabel);
            this.DOBGroupBox.Controls.Add(this.PasswordTextbox);
            this.DOBGroupBox.Controls.Add(this.PasswordLabel);
            this.DOBGroupBox.Controls.Add(this.NameTextbox);
            this.DOBGroupBox.Controls.Add(this.NameLabel);
            this.DOBGroupBox.ForeColor = System.Drawing.Color.White;
            this.DOBGroupBox.Location = new System.Drawing.Point(15, 14);
            this.DOBGroupBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DOBGroupBox.Name = "DOBGroupBox";
            this.DOBGroupBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DOBGroupBox.Size = new System.Drawing.Size(382, 470);
            this.DOBGroupBox.TabIndex = 0;
            this.DOBGroupBox.TabStop = false;
            this.DOBGroupBox.Text = "Registration";
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.AddressTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextbox.ForeColor = System.Drawing.Color.White;
            this.AddressTextbox.Location = new System.Drawing.Point(181, 149);
            this.AddressTextbox.Multiline = true;
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(164, 27);
            this.AddressTextbox.TabIndex = 62;
            this.AddressTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.AddressTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(87, 151);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(74, 21);
            this.AddressLabel.TabIndex = 61;
            this.AddressLabel.Text = "Address:";
            // 
            // NIDTextbox
            // 
            this.NIDTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.NIDTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIDTextbox.ForeColor = System.Drawing.Color.White;
            this.NIDTextbox.Location = new System.Drawing.Point(181, 251);
            this.NIDTextbox.Name = "NIDTextbox";
            this.NIDTextbox.Size = new System.Drawing.Size(164, 27);
            this.NIDTextbox.TabIndex = 60;
            this.NIDTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.NIDTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // NIDLabel
            // 
            this.NIDLabel.AutoSize = true;
            this.NIDLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIDLabel.Location = new System.Drawing.Point(67, 253);
            this.NIDLabel.Name = "NIDLabel";
            this.NIDLabel.Size = new System.Drawing.Size(95, 21);
            this.NIDLabel.TabIndex = 59;
            this.NIDLabel.Text = "National ID:";
            // 
            // PNTextbox
            // 
            this.PNTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.PNTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNTextbox.ForeColor = System.Drawing.Color.White;
            this.PNTextbox.Location = new System.Drawing.Point(224, 215);
            this.PNTextbox.Name = "PNTextbox";
            this.PNTextbox.Size = new System.Drawing.Size(121, 27);
            this.PNTextbox.TabIndex = 57;
            this.PNTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.PNTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 58;
            this.label5.Text = "+880";
            // 
            // PNLabel
            // 
            this.PNLabel.AutoSize = true;
            this.PNLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNLabel.Location = new System.Drawing.Point(36, 217);
            this.PNLabel.Name = "PNLabel";
            this.PNLabel.Size = new System.Drawing.Size(125, 21);
            this.PNLabel.TabIndex = 56;
            this.PNLabel.Text = "Phone Number:";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.EmailTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.ForeColor = System.Drawing.Color.White;
            this.EmailTextbox.Location = new System.Drawing.Point(181, 182);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(164, 27);
            this.EmailTextbox.TabIndex = 55;
            this.EmailTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.EmailTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(110, 184);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(52, 21);
            this.EmailLabel.TabIndex = 54;
            this.EmailLabel.Text = "Email:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.PasswordTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextbox.Location = new System.Drawing.Point(181, 83);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(164, 27);
            this.PasswordTextbox.TabIndex = 53;
            this.PasswordTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.PasswordTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(79, 87);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(83, 21);
            this.PasswordLabel.TabIndex = 52;
            this.PasswordLabel.Text = "Password:";
            // 
            // NameTextbox
            // 
            this.NameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.NameTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextbox.ForeColor = System.Drawing.Color.White;
            this.NameTextbox.Location = new System.Drawing.Point(181, 50);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(164, 27);
            this.NameTextbox.TabIndex = 51;
            this.NameTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.NameTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(104, 52);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(57, 21);
            this.NameLabel.TabIndex = 50;
            this.NameLabel.Text = "Name:";
            // 
            // CPasswordTextbox
            // 
            this.CPasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.CPasswordTextbox.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPasswordTextbox.ForeColor = System.Drawing.Color.White;
            this.CPasswordTextbox.Location = new System.Drawing.Point(181, 116);
            this.CPasswordTextbox.Name = "CPasswordTextbox";
            this.CPasswordTextbox.PasswordChar = '*';
            this.CPasswordTextbox.Size = new System.Drawing.Size(164, 27);
            this.CPasswordTextbox.TabIndex = 64;
            this.CPasswordTextbox.Enter += new System.EventHandler(this.TextBoxEnterColorChange);
            this.CPasswordTextbox.Leave += new System.EventHandler(this.TextBoxLeaveColorChange);
            // 
            // CPasswordLabel
            // 
            this.CPasswordLabel.AutoSize = true;
            this.CPasswordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPasswordLabel.Location = new System.Drawing.Point(16, 118);
            this.CPasswordLabel.Name = "CPasswordLabel";
            this.CPasswordLabel.Size = new System.Drawing.Size(146, 21);
            this.CPasswordLabel.TabIndex = 63;
            this.CPasswordLabel.Text = "Confirm Password:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.Location = new System.Drawing.Point(92, 292);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(69, 21);
            this.GenderLabel.TabIndex = 65;
            this.GenderLabel.Text = "Gender:";
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FemaleRadioButton.Location = new System.Drawing.Point(257, 291);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(88, 24);
            this.FemaleRadioButton.TabIndex = 67;
            this.FemaleRadioButton.TabStop = true;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaleRadioButton.Location = new System.Drawing.Point(181, 291);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(68, 24);
            this.MaleRadioButton.TabIndex = 66;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // DOBDateTimePicker
            // 
            this.DOBDateTimePicker.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOBDateTimePicker.Location = new System.Drawing.Point(181, 325);
            this.DOBDateTimePicker.Name = "DOBDateTimePicker";
            this.DOBDateTimePicker.Size = new System.Drawing.Size(164, 27);
            this.DOBDateTimePicker.TabIndex = 68;
            // 
            // DOBLabel
            // 
            this.DOBLabel.AutoSize = true;
            this.DOBLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOBLabel.Location = new System.Drawing.Point(55, 329);
            this.DOBLabel.Name = "DOBLabel";
            this.DOBLabel.Size = new System.Drawing.Size(107, 21);
            this.DOBLabel.TabIndex = 69;
            this.DOBLabel.Text = "Date of Birth:";
            // 
            // TermsCheckBox
            // 
            this.TermsCheckBox.AutoSize = true;
            this.TermsCheckBox.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TermsCheckBox.Location = new System.Drawing.Point(59, 369);
            this.TermsCheckBox.Name = "TermsCheckBox";
            this.TermsCheckBox.Size = new System.Drawing.Size(205, 20);
            this.TermsCheckBox.TabIndex = 70;
            this.TermsCheckBox.Text = "Agree to terms and conditions";
            this.TermsCheckBox.UseVisualStyleBackColor = true;
            this.TermsCheckBox.CheckedChanged += new System.EventHandler(this.TermsCheckBox_CheckedChanged);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(40, 402);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(41, 16);
            this.ErrorLabel.TabIndex = 71;
            this.ErrorLabel.Text = "Error";
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(136, 429);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(113, 33);
            this.RegisterButton.TabIndex = 72;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(412, 498);
            this.Controls.Add(this.DOBGroupBox);
            this.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "RegisterEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterEmployee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterEmployee_FormClosing);
            this.DOBGroupBox.ResumeLayout(false);
            this.DOBGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DOBGroupBox;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox NIDTextbox;
        private System.Windows.Forms.Label NIDLabel;
        private System.Windows.Forms.TextBox PNTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PNLabel;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox CPasswordTextbox;
        private System.Windows.Forms.Label CPasswordLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Label DOBLabel;
        private System.Windows.Forms.DateTimePicker DOBDateTimePicker;
        private System.Windows.Forms.CheckBox TermsCheckBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Button RegisterButton;
    }
}
namespace SE
{
    partial class Form2
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
            label7 = new Label();
            label6 = new Label();
            button2 = new Button();
            button1 = new Button();
            checkBoxpassword = new CheckBox();
            txtPassword = new TextBox();
            label4 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Cursor = Cursors.Hand;
            label7.Font = new Font("Nirmala UI", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(125, 440);
            label7.Name = "label7";
            label7.Size = new Size(94, 20);
            label7.TabIndex = 24;
            label7.Text = "Create Account";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Nirmala UI", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(103, 422);
            label6.Name = "label6";
            label6.Size = new Size(146, 18);
            label6.TabIndex = 23;
            label6.Text = "Donot Have an Account";
            label6.Click += label6_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(116, 86, 174);
            button2.Location = new Point(65, 372);
            button2.Name = "button2";
            button2.Size = new Size(216, 35);
            button2.TabIndex = 22;
            button2.Text = "CLEAR";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(116, 86, 174);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(65, 319);
            button1.Name = "button1";
            button1.Size = new Size(216, 35);
            button1.TabIndex = 21;
            button1.Text = "LOGIN";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkBoxpassword
            // 
            checkBoxpassword.AutoSize = true;
            checkBoxpassword.Cursor = Cursors.Hand;
            checkBoxpassword.FlatStyle = FlatStyle.Flat;
            checkBoxpassword.Font = new Font("Nirmala UI", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxpassword.Location = new Point(167, 276);
            checkBoxpassword.Name = "checkBoxpassword";
            checkBoxpassword.Size = new Size(114, 19);
            checkBoxpassword.TabIndex = 20;
            checkBoxpassword.Text = "Show Password";
            checkBoxpassword.UseVisualStyleBackColor = true;
            checkBoxpassword.CheckedChanged += checkBoxpassword_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(230, 231, 233);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(65, 241);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(216, 28);
            txtPassword.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 210);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 16;
            label4.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(230, 231, 233);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(65, 169);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(216, 28);
            txtUsername.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 138);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 14;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(166, 86, 176);
            label1.Location = new Point(65, 82);
            label1.Name = "label1";
            label1.Size = new Size(184, 33);
            label1.TabIndex = 13;
            label1.Text = "Get Started";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(347, 548);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBoxpassword);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label6;
        private Button button2;
        private Button button1;
        private CheckBox checkBoxpassword;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
    }
}
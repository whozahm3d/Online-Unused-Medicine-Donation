using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Register";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true; // ✅ Helps reduce flicker/lines
            this.BackColor = Color.WhiteSmoke;
            this.Paint += RegisterForm_Paint;

            Label lblTitle = new Label()
            {
                Text = "Create an Account",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Top = 30,
                Left = 90
            };
            this.Controls.Add(lblTitle);

            Label lblUsername = new Label()
            {
                Text = "Username:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold), // ✅ Bold
                Top = 90,
                Left = 50,
                Width = 280,
                ForeColor = Color.Black
            };
            TextBox txtUsername = new TextBox()
            {
                Name = "txtUsername",
                Font = new Font("Segoe UI", 10),
                Top = 110,
                Left = 50,
                Width = 280,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblPassword = new Label()
            {
                Text = "Password:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold), // ✅ Bold
                Top = 150,
                Left = 50,
                Width = 280,
                ForeColor = Color.Black
            };
            TextBox txtPassword = new TextBox()
            {
                Name = "txtPassword",
                Font = new Font("Segoe UI", 10),
                Top = 170,
                Left = 50,
                Width = 280,
                PasswordChar = '●',
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnRegister = CreateStyledButton("Register", 220);
            btnRegister.Click += BtnRegister_Click;

            Button btnBack = CreateStyledButton("Back to Login", 280);
            btnBack.Click += BtnBack_Click;

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnRegister);
            this.Controls.Add(btnBack);
        }

        private Button CreateStyledButton(string text, int top)
        {
            return new Button()
            {
                Text = text,
                Width = 280,
                Height = 45,
                Top = top,
                Left = 50,
                BackColor = Color.FromArgb(58, 125, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void RegisterForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.LightSkyBlue, Color.White, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = this.Controls["txtUsername"].Text;
            var password = this.Controls["txtPassword"].Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill both fields.");
                return;
            }

            File.AppendAllText("users.txt", username + "," + password + Environment.NewLine);

            MessageBox.Show("Registration Successful!");
            this.Hide();
            new LoginForm("status").Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm("status").Show();
        }
    }
}

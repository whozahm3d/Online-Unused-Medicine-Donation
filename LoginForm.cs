using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class LoginForm : Form
    {
        private string action;

        public LoginForm() => SetupUI();

        public LoginForm(string action)
        {
            this.action = action;
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Medicine Donation App - Login";
            this.Size = new Size(700, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            this.Paint += LoginForm_Paint;

            Label lblTitle = new Label()
            {
                Text = "Login to Continue",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Top = 50,
                Left = 180
            };
            this.Controls.Add(lblTitle);

            Label lblUsername = new Label()
            {
                Text = "Username:",
                Font = new Font("Segoe UI", 10),
                Top = 130,
                Left = 100,
                Width = 400
            };
            this.Controls.Add(lblUsername);

            TextBox txtUsername = new TextBox()
            {
                Name = "txtUsername",
                Font = new Font("Segoe UI", 10),
                Top = 160,
                Left = 100,
                Width = 400
            };
            this.Controls.Add(txtUsername);

            Label lblPassword = new Label()
            {
                Text = "Password:",
                Font = new Font("Segoe UI", 10),
                Top = 210,
                Left = 100,
                Width = 400
            };
            this.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox()
            {
                Name = "txtPassword",
                Font = new Font("Segoe UI", 10),
                Top = 240,
                Left = 100,
                Width = 400,
                PasswordChar = '●'
            };
            this.Controls.Add(txtPassword);

            Button btnLogin = CreateStyledButton("Login", 300);
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            Button btnRegister = CreateStyledButton("Register", 360);
            btnRegister.Click += (s, e) => { this.Hide(); new RegisterForm().Show(); };
            this.Controls.Add(btnRegister);

            Button btnBack = CreateStyledButton("Back to Main Menu", 420);
            btnBack.BackColor = Color.Gray;
            btnBack.Click += (s, e) => { this.Hide(); new MainForm().Show(); };
            this.Controls.Add(btnBack);
        }

        private Button CreateStyledButton(string text, int top)
        {
            return new Button()
            {
                Text = text,
                Width = 400,
                Height = 50,
                Top = top,
                Left = 100,
                BackColor = Color.FromArgb(58, 125, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.LightSkyBlue, Color.White, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = this.Controls.Find("txtUsername", true).FirstOrDefault()?.Text.Trim();
            string password = this.Controls.Find("txtPassword", true).FirstOrDefault()?.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (!File.Exists("users.txt"))
            {
                MessageBox.Show("No users registered.");
                return;
            }

            bool isValid = File.ReadAllLines("users.txt")
                               .Any(line =>
                               {
                                   string[] parts = line.Split(',');
                                   return parts.Length == 2 &&
                                          parts[0] == username &&
                                          parts[1] == password;
                               });

            if (isValid)
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                switch (action)
                {
                    case "donate": new DonateForm().Show(); break;
                    case "order": new OrderForm().Show(); break;
                    case "multiple": new NewOrderForm().Show(); break;
                    case "track":
                    case "status": new TrackProcessForm().Show(); break;
                    default: new MainForm().Show(); break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}

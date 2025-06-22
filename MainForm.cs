using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Medicine Donation App - Main Menu";
            this.Size = new Size(660, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            this.Paint += MainForm_Paint;

            Label lblTitle = new Label()
            {
                Text = "Welcome to Medicine Donation App",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Top = 30,
                Left = 80
            };
            this.Controls.Add(lblTitle);

            int top = 100;
            int spacing = 60;

            Button btnDonate = CreateStyledButton("Donate Medicine", top);
            btnDonate.Click += (s, e) => { this.Hide(); new LoginForm("donate").Show(); };
            this.Controls.Add(btnDonate);

            Button btnOrder = CreateStyledButton("Order Medicine", top += spacing);
            btnOrder.Click += (s, e) => { this.Hide(); new LoginForm("order").Show(); };
            this.Controls.Add(btnOrder);

            Button btnNewOrder = CreateStyledButton("Place New Order (Multiple)", top += spacing);
            btnNewOrder.Click += (s, e) => { this.Hide(); new LoginForm("multiple").Show(); };
            this.Controls.Add(btnNewOrder);

            Button btnAdminApproval = CreateStyledButton("Admin Approval Panel", top += spacing);
            btnAdminApproval.Click += (s, e) => { this.Hide(); new AdminApprovalForm().Show(); };
            this.Controls.Add(btnAdminApproval);

            Button btnTrack = CreateStyledButton("Track Your Order", top += spacing);
            btnTrack.Click += (s, e) => { this.Hide(); new LoginForm("track").Show(); };
            this.Controls.Add(btnTrack);

            Button btnInventory = CreateStyledButton("View Inventory", top += spacing);
            btnInventory.Click += (s, e) => { this.Hide(); new InventoryForm().Show(); };
            this.Controls.Add(btnInventory);

            Button btnFeedback = CreateStyledButton("Feedback", top += spacing);
            btnFeedback.Click += (s, e) => { this.Hide(); new FeedbackForm().Show(); };
            this.Controls.Add(btnFeedback);

            Button btnPopularity = CreateStyledButton("Popularity", top += spacing);
            btnPopularity.Click += (s, e) => { new PopularityForm().Show(); };
            this.Controls.Add(btnPopularity);

            Button btnExit = CreateStyledButton("Exit", top += spacing);
            btnExit.Click += (s, e) => { Application.Exit(); };
            this.Controls.Add(btnExit);
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.LightSkyBlue, Color.White, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}

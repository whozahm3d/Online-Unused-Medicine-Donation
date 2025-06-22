using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class AdminApprovalForm : Form
    {
        private ListBox listBoxPendingOrders;
        private Button btnApprove;
        private Button btnReject;
        private Button btnBack;

        private string pendingOrdersFile = "medicine_data.txt";
        private string approvedOrdersFile = "medicine_data.txt";

        public AdminApprovalForm()
        {
            InitializeComponent();
            SetupUI();
            LoadPendingOrders();
        }

        private void SetupUI()
        {
            this.Text = "Admin Approval Panel";
            this.Size = new System.Drawing.Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Add gradient background
            this.Paint += MainForm_Paint;

            Label lblTitle = new Label()
            {
                Text = "Pending Orders for Approval",
                Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkSlateBlue,
                Top = 20,
                Left = 20,
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            listBoxPendingOrders = new ListBox()
            {
                Top = 70,
                Left = 20,
                Width = 540,
                Height = 280,
                Font = new System.Drawing.Font("Segoe UI", 10),
                BackColor = System.Drawing.Color.GhostWhite, // Slight grayish background for the list box
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(listBoxPendingOrders);

            btnApprove = new Button()
            {
                Text = "Approve Selected",
                Top = 370,
                Left = 20,
                Width = 150,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80), // Green
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 }
            };
            btnApprove.Click += BtnApprove_Click;
            this.Controls.Add(btnApprove);

            btnReject = new Button()
            {
                Text = "Reject Selected",
                Top = 370,
                Left = 200,
                Width = 150,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(244, 67, 54), // Red
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 }
            };
            btnReject.Click += BtnReject_Click;
            this.Controls.Add(btnReject);

            btnBack = new Button()
            {
                Text = "Back",
                Top = 370,
                Left = 400,
                Width = 150,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(33, 150, 243), // Soft Blue
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 }
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                       System.Drawing.Color.LightSkyBlue, System.Drawing.Color.White, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void LoadPendingOrders()
        {
            listBoxPendingOrders.Items.Clear();

            if (File.Exists(pendingOrdersFile))
            {
                var orders = File.ReadAllLines(pendingOrdersFile);

                if (orders.Length == 0)
                {
                    listBoxPendingOrders.Items.Add("No pending orders.");
                }
                else
                {
                    foreach (var order in orders)
                    {
                        listBoxPendingOrders.Items.Add(order);
                    }
                }
            }
            else
            {
                listBoxPendingOrders.Items.Add("Pending orders file not found.");
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (listBoxPendingOrders.SelectedItem != null)
            {
                string approvedOrder = listBoxPendingOrders.SelectedItem.ToString();

                // Save to approved orders
                File.AppendAllText(approvedOrdersFile, approvedOrder + Environment.NewLine);

                // Remove from pending orders
                RemoveOrderFromPending(approvedOrder);

                MessageBox.Show("Order approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingOrders();
            }
            else
            {
                MessageBox.Show("Please select an order to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (listBoxPendingOrders.SelectedItem != null)
            {
                string rejectedOrder = listBoxPendingOrders.SelectedItem.ToString();

                // Just remove from pending orders (not saved anywhere else)
                RemoveOrderFromPending(rejectedOrder);

                MessageBox.Show("Order rejected successfully!", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingOrders();
            }
            else
            {
                MessageBox.Show("Please select an order to reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveOrderFromPending(string order)
        {
            if (File.Exists(pendingOrdersFile))
            {
                var orders = File.ReadAllLines(pendingOrdersFile);
                File.WriteAllLines(pendingOrdersFile, orders.Where(o => o != order));
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}

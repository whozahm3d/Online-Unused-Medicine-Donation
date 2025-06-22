using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class NewOrderForm : Form
    {
        private CheckedListBox clbMedicines;
        private TextBox txtQuantity;
        private TextBox txtAddress;
        private Button btnSubmitOrder;
        private Dictionary<string, int> selectedMedicines = new Dictionary<string, int>();

        public NewOrderForm()
        {
            InitializeComponent();
            SetupUI();
            LoadMedicines();
        }

        private void SetupUI()
        {
            this.Text = "Place New Medicine Order";
            this.Size = new System.Drawing.Size(660, 660);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            Label lblTitle = new Label()
            {
                Text = "Select Medicines",
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                Top = 20,
                Left = 20,
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            clbMedicines = new CheckedListBox()
            {
                Top = 70,
                Left = 20,
                Width = 440,
                Height = 200,
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            this.Controls.Add(clbMedicines);

            Label lblQuantity = new Label()
            {
                Text = "Quantity for Selected Medicines:",
                Top = 280,
                Left = 20,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            this.Controls.Add(lblQuantity);

            txtQuantity = new TextBox()
            {
                Top = 300,
                Left = 20,
                Width = 100
            };
            this.Controls.Add(txtQuantity);

            Label lblAddress = new Label()
            {
                Text = "Delivery Address:",
                Top = 350,
                Left = 20,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            this.Controls.Add(lblAddress);

            txtAddress = new TextBox()
            {
                Top = 370,
                Left = 20,
                Width = 440,
                Height = 60,
                Multiline = true,
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            this.Controls.Add(txtAddress);

            btnSubmitOrder = new Button()
            {
                Text = "Submit Order",
                Top = 450,
                Left = 20,
                Width = 200,
                Height = 40,
                BackColor = System.Drawing.Color.MediumSeaGreen,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 }
            };
            btnSubmitOrder.Click += BtnSubmitOrder_Click;
            this.Controls.Add(btnSubmitOrder);
        }

        private void LoadMedicines()
        {
            string filePath = "inventory.txt";

            if (File.Exists(filePath))
            {
                var medicines = File.ReadAllLines(filePath);
                foreach (var line in medicines)
                {
                    clbMedicines.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Medicines file not found!");
            }
        }

        private void BtnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (clbMedicines.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one medicine.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter a delivery address.");
                return;
            }

            foreach (var item in clbMedicines.CheckedItems)
            {
                selectedMedicines[item.ToString()] = quantity;
            }

            SaveOrder();
            MessageBox.Show("Order placed successfully and pending admin approval!");
            this.Hide();
            new MainForm().Show();
        }

        private void SaveOrder()
        {
            string orderFilePath = "pending_orders.txt";

            using (StreamWriter sw = new StreamWriter(orderFilePath, true))
            {
                sw.WriteLine("New Pending Order:");
                foreach (var kvp in selectedMedicines)
                {
                    sw.WriteLine($"{kvp.Key} - Quantity: {kvp.Value}");
                }
                sw.WriteLine($"Delivery Address: {txtAddress.Text}");
                sw.WriteLine("----------");
            }
        }
    }
}

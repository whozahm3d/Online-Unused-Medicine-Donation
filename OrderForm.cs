using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class OrderForm : Form
    {
        private FlowLayoutPanel medicinePanel;
        private TextBox txtFullName, txtEmail, txtPhone, txtAddress;

        public OrderForm()
        {
            InitializeComponent();
            LoadOrderForm();
        }

        private void LoadOrderForm()
        {
            this.Text = "Order Medicines";
            this.Size = new Size(660, 660);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label()
            {
                Text = "Order Medicines",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true,
                Location = new Point(160, 20)
            };

            this.Controls.Add(lblTitle);

            Label lblFullName = CreateLabel("Full Name:", 60);
            txtFullName = CreateTextBox(80, "");

            Label lblEmail = CreateLabel("Email:", 120);
            txtEmail = CreateTextBox(140, "");

            Label lblPhone = CreateLabel("Phone Number:", 180);
            txtPhone = CreateTextBox(200, "");

            Label lblMedicineHeader = new Label()
            {
                Text = "Medicines",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true,
                Location = new Point(200, 240)
            };

            medicinePanel = new FlowLayoutPanel()
            {
                Location = new Point(50, 270),
                Size = new Size(400, 100),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnAddMedicine = new Button()
            {
                Text = "Add Another Medicine",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Location = new Point(50, 380),
                Size = new Size(200, 30)
            };
            btnAddMedicine.Click += (s, e) => AddMedicineRow();

            Label lblAddress = CreateLabel("Delivery Address:", 420);
            txtAddress = CreateTextBox(440, "");

            Button btnPlaceOrder = new Button()
            {
                Text = "Place Order",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Location = new Point(50, 480),
                Size = new Size(400, 40)
            };
            btnPlaceOrder.Click += (s, e) =>
            {
                foreach (Panel panel in medicinePanel.Controls)
                {
                    string medicine = ((TextBox)panel.Controls[0]).Text;
                    string quantity = ((TextBox)panel.Controls[1]).Text;

                    string line = $"Order,{txtFullName.Text},{txtEmail.Text},{txtPhone.Text},{medicine},{quantity},{txtAddress.Text}";
                    File.AppendAllText("medicine_data.txt", line + Environment.NewLine);
                }

                MessageBox.Show("Order Placed Successfully!");
            };

            this.Controls.Add(lblFullName);
            this.Controls.Add(txtFullName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblMedicineHeader);
            this.Controls.Add(medicinePanel);
            this.Controls.Add(btnAddMedicine);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(btnPlaceOrder);

            AddMedicineRow();
        }

        private Label CreateLabel(string text, int y)
        {
            return new Label()
            {
                Text = text,
                AutoSize = true,
                Location = new Point(50, y),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
        }

        private TextBox CreateTextBox(int y, string placeholder)
        {
            TextBox textBox = new TextBox()
            {
                Size = new Size(400, 25),
                Location = new Point(50, y),
                Text = placeholder
            };

            return textBox;
        }

        private void AddMedicineRow()
        {
            Panel rowPanel = new Panel() { Size = new Size(380, 30) };

            TextBox txtMedicine = new TextBox() { Width = 180, Text = "Medicine Name" };
            TextBox txtQuantity = new TextBox() { Width = 80, Text = "Quantity" };
            Button btnRemove = new Button() { Text = "Remove", BackColor = Color.Red, ForeColor = Color.White, Size = new Size(80, 25) };

            btnRemove.Click += (s, e) =>
            {
                medicinePanel.Controls.Remove(rowPanel);
            };

            rowPanel.Controls.Add(txtMedicine);
            rowPanel.Controls.Add(txtQuantity);
            rowPanel.Controls.Add(btnRemove);

            txtQuantity.Location = new Point(190, 0);
            btnRemove.Location = new Point(280, 0);

            medicinePanel.Controls.Add(rowPanel);
        }
    }
}
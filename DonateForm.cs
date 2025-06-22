using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class DonateForm : Form
    {
        TextBox txtFullName, txtEmail, txtPhone, txtMedicine, txtQuantity;
        DateTimePicker dtpExpiration;

        public DonateForm()
        {
            InitializeComponent();
            this.Load += DonateForm_Load;
        }

        private void DonateForm_Load(object sender, EventArgs e)
        {
            this.Text = "Donate Medicines";
            this.Size = new Size(660, 660);
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label()
            {
                Text = "Donate Unused Medicines",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 70
            };
            this.Controls.Add(lblTitle);

            int yOffset = 60;

            Label lblFullName = CreateLabel("Full Name:", yOffset);
            txtFullName = CreateTextBox(yOffset + 20);

            Label lblEmail = CreateLabel("Email:", yOffset += 60);
            txtEmail = CreateTextBox(yOffset + 20);

            Label lblPhone = CreateLabel("Phone:", yOffset += 60);
            txtPhone = CreateTextBox(yOffset + 20);

            Label lblMedicine = CreateLabel("Medicine Name:", yOffset += 60);
            txtMedicine = CreateTextBox(yOffset + 20);

            Label lblQuantity = CreateLabel("Quantity:", yOffset += 60);
            txtQuantity = CreateTextBox(yOffset + 20);

            Label lblDate = CreateLabel("Expiration Date:", yOffset += 60);
            dtpExpiration = new DateTimePicker()
            {
                Top = yOffset + 20,
                Left = 50,
                Width = 250
            };

            Button btnSubmit = new Button()
            {
                Text = "Submit Donation",
                Top = yOffset + 80,
                Left = 50,
                Width = 250,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White
            };
            btnSubmit.Click += BtnSubmit_Click;

            this.Controls.AddRange(new Control[] {
                lblFullName, txtFullName,
                lblEmail, txtEmail,
                lblPhone, txtPhone,
                lblMedicine, txtMedicine,
                lblQuantity, txtQuantity,
                lblDate, dtpExpiration,
                btnSubmit
            });

            AttachLiveValidation(txtFullName);
            AttachLiveValidation(txtEmail);
            AttachLiveValidation(txtPhone);
            AttachLiveValidation(txtMedicine);
            AttachLiveValidation(txtQuantity);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            string line = $"{txtFullName.Text},{txtEmail.Text},{txtPhone.Text},{txtMedicine.Text},{txtQuantity.Text},{dtpExpiration.Value.ToShortDateString()}";
            File.AppendAllText("medicine_data.txt", line + Environment.NewLine);

            MessageBox.Show("Donation Submitted!");
            this.Close();
            new MainForm().Show();
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            if (!Regex.IsMatch(txtFullName.Text, @"^[a-zA-Z\s]+$"))
            {
                txtFullName.BackColor = Color.LightCoral;
                isValid = false;
            }

            if (!txtEmail.Text.EndsWith("@gmail.com"))
            {
                txtEmail.BackColor = Color.LightCoral;
                isValid = false;
            }

            if (!Regex.IsMatch(txtPhone.Text, @"^\d+$"))
            {
                txtPhone.BackColor = Color.LightCoral;
                isValid = false;
            }

            if (!Regex.IsMatch(txtQuantity.Text, @"^\d+$"))
            {
                txtQuantity.BackColor = Color.LightCoral;
                isValid = false;
            }

            return isValid;
        }

        private void AttachLiveValidation(TextBox textBox)
        {
            textBox.TextChanged += (s, e) => textBox.BackColor = Color.White;
        }

        private Label CreateLabel(string text, int top)
        {
            return new Label()
            {
                Text = text,
                Top = top,
                Left = 50,
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int top)
        {
            return new TextBox()
            {
                Top = top,
                Left = 50,
                Width = 250
            };
        }
    }
}

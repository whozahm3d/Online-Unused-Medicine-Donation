using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class InventoryForm : Form
    {
        private ListBox listBoxCategories;
        private ListBox listBoxMedicines;
        private Dictionary<string, List<string>> medicineData;

        public InventoryForm()
        {
            SetupUI();
            LoadInventory();
        }

        private void SetupUI()
        {
            this.Text = "Medicine Inventory";
            this.Size = new Size(660, 660);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            this.DoubleBuffered = true;
            this.Paint += InventoryForm_Paint;

            Label lblTitle = new Label()
            {
                Text = "Medicine Inventory",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Top = 20,
                Left = 230
            };
            this.Controls.Add(lblTitle);

            Label lblCategories = new Label()
            {
                Text = "Categories",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Top = 70,
                Left = 40,
                AutoSize = true
            };
            this.Controls.Add(lblCategories);

            listBoxCategories = new ListBox()
            {
                Top = 100,
                Left = 40,
                Width = 260,
                Height = 280,
                Font = new Font("Segoe UI", 11)
            };
            listBoxCategories.SelectedIndexChanged += ListBoxCategories_SelectedIndexChanged;
            this.Controls.Add(listBoxCategories);

            Label lblMedicines = new Label()
            {
                Text = "Medicines",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Top = 70,
                Left = 350,
                AutoSize = true
            };
            this.Controls.Add(lblMedicines);

            listBoxMedicines = new ListBox()
            {
                Top = 100,
                Left = 350,
                Width = 280,
                Height = 280,
                Font = new Font("Segoe UI", 11)
            };
            this.Controls.Add(listBoxMedicines);

            Button btnBack = new Button()
            {
                Text = "Back",
                Width = 100,
                Height = 45,
                Top = 400,
                Left = 40,
                BackColor = Color.FromArgb(58, 125, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);
        }

        private void InventoryForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.LightSkyBlue, Color.White, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void LoadInventory()
        {
            string filePath = "inventory.txt";
            medicineData = new Dictionary<string, List<string>>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string category = parts[0].Trim();
                        string medicine = parts[1].Trim();

                        if (!medicineData.ContainsKey(category))
                        {
                            medicineData[category] = new List<string>();
                        }
                        medicineData[category].Add(medicine);
                    }
                }

                listBoxCategories.Items.Clear();
                foreach (var category in medicineData.Keys)
                {
                    listBoxCategories.Items.Add(category);
                }
            }
            else
            {
                MessageBox.Show("No inventory file found (inventory.txt missing)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedItem != null)
            {
                string selectedCategory = listBoxCategories.SelectedItem.ToString();
                listBoxMedicines.Items.Clear();

                if (medicineData.ContainsKey(selectedCategory))
                {
                    foreach (var med in medicineData[selectedCategory])
                    {
                        listBoxMedicines.Items.Add(med);
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}

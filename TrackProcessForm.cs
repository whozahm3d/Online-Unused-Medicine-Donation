using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class TrackProcessForm : Form
    {
        private string filePath = "medicine_data.txt";

        public TrackProcessForm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadTrackingData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false; // Allow editing/deleting
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("User", "User");
            dataGridView1.Columns.Add("FullName", "Full Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns.Add("Medicine", "Medicine");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Details", "Extra Details");
        }

        private void LoadTrackingData()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.Rows.Clear();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                // Ensure the row has exactly 8 elements
                Array.Resize(ref parts, 8);

                dataGridView1.Rows.Add(parts);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                bool found = row.Cells.Cast<DataGridViewCell>()
                                      .Any(cell => cell.Value != null &&
                                                   cell.Value.ToString().ToLower().Contains(searchText));

                row.Visible = found;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dataGridView1.Rows.Remove(row);
                }

                SaveDataToFile();
                MessageBox.Show("Selected row(s) deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string[] rowData = row.Cells.Cast<DataGridViewCell>()
                        .Select(cell => cell.Value?.ToString() ?? "")
                        .ToArray();

                    writer.WriteLine(string.Join(",", rowData));
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click logic here
        }
    }
}

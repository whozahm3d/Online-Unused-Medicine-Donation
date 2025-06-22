using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MedicineDonationApp
{
    public partial class PopularityForm : Form
    {
        public PopularityForm()
        {
            InitializeComponent();
            LoadPopularityStats();
        }

        private void LoadPopularityStats()
        {
            // Set form properties
            this.Text = "App Popularity - Feedback Summary";
            this.Size = new Size(660, 660);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray background
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title label with modern styling
            Label lblTitle = new Label()
            {
                Text = "App Rating Statistics",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(180, 20),
                ForeColor = Color.FromArgb(0, 122, 204)  // Professional blue color
            };
            this.Controls.Add(lblTitle);

            // Check if feedback file exists
            if (!File.Exists("feedback_data.txt"))
            {
                Label lblNoData = new Label()
                {
                    Text = "No feedback data found.",
                    Location = new Point(180, 120),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                    ForeColor = Color.Gray // Light gray for no data
                };
                this.Controls.Add(lblNoData);
                return;
            }

            // Read feedback data from the file
            string[] lines = File.ReadAllLines("feedback_data.txt");
            var ratings = lines
                .Where(line => line.StartsWith("Feedback"))
                .Select(line => line.Split(',')[3])  // Extract rating like "5 Stars"
                .Select(starText => int.Parse(starText.Split(' ')[0]))  // Convert "5 Stars" to 5
                .ToList();

            // If no ratings found, show appropriate message
            if (ratings.Count == 0)
            {
                Label lblNoRatings = new Label()
                {
                    Text = "No ratings available.",
                    Location = new Point(180, 120),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                    ForeColor = Color.Gray // Light gray for no ratings
                };
                this.Controls.Add(lblNoRatings);
                return;
            }

            // Calculate the average rating and total feedback count
            double avgRating = ratings.Average();
            int totalRatings = ratings.Count;

            // Label for displaying average rating
            Label lblAvg = new Label()
            {
                Text = $"Average Rating: {avgRating:F2} / 5",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),  // Modern blue color
                AutoSize = true,
                Location = new Point(180, 160)
            };

            // Label for displaying total number of ratings
            Label lblCount = new Label()
            {
                Text = $"Total Feedbacks: {totalRatings}",
                Font = new Font("Segoe UI", 14),
                AutoSize = true,
                Location = new Point(180, 200),
                ForeColor = Color.FromArgb(64, 64, 64)  // Darker gray for clarity
            };

            // Adding labels to the form
            this.Controls.Add(lblAvg);
            this.Controls.Add(lblCount);

            // Adding a border for better separation of sections
            Panel borderPanel = new Panel()
            {
                Size = new Size(this.Width - 40, 2),
                Location = new Point(20, 250),
                BackColor = Color.LightGray // Light gray border
            };
            this.Controls.Add(borderPanel);

            // Adding a button with a modern look
            Button btnRefresh = new Button()
            {
                Text = "Refresh Data",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Size = new Size(150, 40),
                Location = new Point(200, 280),
                BackColor = Color.FromArgb(0, 122, 204), // Blue background for button
                ForeColor = Color.White, // White text
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (sender, e) => LoadPopularityStats(); // Reload stats on button click
            this.Controls.Add(btnRefresh);
        }
    }
}

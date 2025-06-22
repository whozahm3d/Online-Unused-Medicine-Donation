using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class FeedbackForm : Form
    {
        private Panel feedbackPanel;
        private TextBox txtName, txtEmail, txtSuggestions;
        private Label[] stars = new Label[5];
        private int selectedStars = 0;

        public FeedbackForm()
        {
            InitializeComponent();
            this.Text = "Feedback";
            this.Size = new Size(660, 660);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            CreateFeedbackPanel();
        }

        private void CreateFeedbackPanel()
        {
            feedbackPanel = new Panel()
            {
                Size = new Size(540, 420),
                Location = new Point(30, 20),
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(feedbackPanel);

            Label lblTitle = new Label()
            {
                Text = "We Value Your Feedback",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                AutoSize = true,
                Location = new Point(150, 20)
            };
            feedbackPanel.Controls.Add(lblTitle);

            feedbackPanel.Controls.Add(CreateLabel("Name:", 70));
            txtName = CreateTextBox(90);
            feedbackPanel.Controls.Add(txtName);

            feedbackPanel.Controls.Add(CreateLabel("Email:", 130));
            txtEmail = CreateTextBox(150);
            feedbackPanel.Controls.Add(txtEmail);

            feedbackPanel.Controls.Add(CreateLabel("Your Rating:", 190));
            CreateStarRating(210);

            feedbackPanel.Controls.Add(CreateLabel("Suggestions / Improvements:", 260));
            txtSuggestions = new TextBox()
            {
                Multiline = true,
                Size = new Size(460, 70),
                Location = new Point(40, 280),
                Font = new Font("Segoe UI", 10)
            };
            feedbackPanel.Controls.Add(txtSuggestions);

            Button btnSubmit = new Button()
            {
                Text = "Submit Feedback",
                Size = new Size(460, 40),
                Location = new Point(40, 370),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += BtnSubmit_Click;
            feedbackPanel.Controls.Add(btnSubmit);
        }

        private Label CreateLabel(string text, int top)
        {
            return new Label()
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(40, top),
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int top)
        {
            return new TextBox()
            {
                Size = new Size(460, 25),
                Location = new Point(40, top),
                Font = new Font("Segoe UI", 10)
            };
        }

        private void CreateStarRating(int top)
        {
            for (int i = 0; i < 5; i++)
            {
                stars[i] = new Label()
                {
                    Text = "☆",
                    Font = new Font("Segoe UI", 24),
                    ForeColor = Color.Gray,
                    Location = new Point(40 + i * 45, top),
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    Tag = i + 1
                };
                stars[i].Click += Star_Click;
                feedbackPanel.Controls.Add(stars[i]);
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            int rating = (int)((Label)sender).Tag;
            selectedStars = rating;
            for (int i = 0; i < 5; i++)
            {
                stars[i].Text = i < rating ? "★" : "☆";
                stars[i].ForeColor = i < rating ? Color.Gold : Color.Gray;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || selectedStars == 0)
            {
                MessageBox.Show("Please fill in all required fields and select a rating.");
                return;
            }

            string line = $"Feedback,{txtName.Text},{txtEmail.Text},{selectedStars} Stars,{txtSuggestions.Text}";
            File.AppendAllText("feedback_data.txt", line + Environment.NewLine);

            MessageBox.Show("Thank you for your feedback!");
            txtName.Text = "";
            txtEmail.Text = "";
            txtSuggestions.Text = "";
            selectedStars = 0;
            foreach (var star in stars)
            {
                star.Text = "☆";
                star.ForeColor = Color.Gray;
            }
        }
    }
}

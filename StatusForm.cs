using System;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
            LoadStatusData();
        }

        private void LoadStatusData()
        {
            // Example data (replace with real data loading later)
            dataGridView1.Rows.Add("Paracetamol", "Donated", "Delivered");
            dataGridView1.Rows.Add("Ibuprofen", "Ordered", "Pending");
        }
    }
}

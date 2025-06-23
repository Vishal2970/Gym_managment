using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Gym_Application {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();

            // Your reference date
            DateTime startDate = new DateTime(2025, 6, 23); 

            // Calculate 90 days from that date
            DateTime expiryDate = startDate.AddDays(90);

            if (DateTime.Today > expiryDate)
            {
                MessageBox.Show("Access expired. Please contact the vishal mobile number 7570882970.");
                Environment.Exit(0); // Exit the app
            }
        }


        private void add_Member_Click(object sender, EventArgs e) {
            AddMembers add = new AddMembers("");
            add.ShowDialog();
        }
        private void pay_Fees_Click(object sender, EventArgs e) {
            PayFees payFees = new PayFees();
            payFees.ShowDialog();
        }

        private void expired_Memberships_Click(object sender, EventArgs e) {
            ExpiredMembers expired = new ExpiredMembers();
            expired.ShowDialog();
        }

        private void list_Of_Members_Click(object sender, EventArgs e) {
            AllMembers list = new AllMembers();
            list.ShowDialog();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Application {
    public partial class PayFees : Form {
        public PayFees() {
            InitializeComponent();
            LoadMembers();
        }
        private void LoadMembers() {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();
                string query = "SELECT * from gymManagement ";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.ClearSelection();
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void Cash_Payement_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0) {
                if (dataGridView1.SelectedRows.Count == 0) {
                    MessageBox.Show("Please select a member first.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];

                if (selectedRow.Cells["Id"]?.Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells["Id"].Value.ToString())) {
                    MessageBox.Show("Invalid selection. Member ID is missing.");
                    return;
                }

                int memberId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to pay fees Member ID: {memberId}?", "Confirm Pay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) {
                    PayMemberFees(memberId);

                    LoadMembers();
                }
            }
            else {
                MessageBox.Show("Please select a member to Pay fees.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PayMemberFees(int id) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                // Step 1: Get current FeesPayed date
                string selectQuery = "SELECT FeesPayed FROM gymManagement WHERE Id = @Id";
                DateTime currentFeesDate;

                using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn)) {
                    selectCmd.Parameters.AddWithValue("@Id", id);
                    object result = selectCmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value) {
                        MessageBox.Show("Member not found.");
                        return;
                    }

                    currentFeesDate = Convert.ToDateTime(result);
                }

                // Step 2: Add 30 days
                DateTime newFeesDate = currentFeesDate.AddDays(30);

                // Step 3: Update the new FeesPayed date
                string updateQuery = "UPDATE gymManagement SET FeesPayed = @NewDate WHERE Id = @Id";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn)) {
                    updateCmd.Parameters.AddWithValue("@NewDate", newFeesDate);
                    updateCmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        MessageBox.Show($"Fees extended to {newFeesDate.ToShortDateString()}.");
                    }
                    else {
                        MessageBox.Show("Payment update failed.");
                    }
                }
            }
        }

    }
}

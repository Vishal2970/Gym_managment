using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Gym_Application {
    public partial class AddMembers : Form {
        static int memberlength=0;
        public AddMembers(string btn) {
           
            InitializeComponent();
            if (!string.IsNullOrEmpty(btn)) {
                button1.Text = btn;
            }
            LoadMembers();
        }
        private void button1_Click(object sender, EventArgs e) {
            string name = member_name.Text;
            string mobile = mobileNumber.Text;
            string aadhar = aadharNumber.Text;
            // --- Validation ---
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$")) {
                MessageBox.Show("Member name should contain only letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(mobile, @"^\d{10}$")) {
                MessageBox.Show("Mobile number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(aadhar, @"^\d{12}$")) {
                MessageBox.Show("Aadhar number must be exactly 12 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? memberId = null;
            if (this.button1.Text != "Add Member") {
                if (string.IsNullOrWhiteSpace(id.Text)) {
                    MessageBox.Show("Member ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

                if (!string.IsNullOrWhiteSpace(id.Text)) {
                if (int.TryParse(id.Text.Trim(), out int parsedId)) {
                    memberId = parsedId;
                }
                else {
                    MessageBox.Show("Member ID must be a valid number or left empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Assign default ID if not provided
            if (memberId == null) {
                memberId = memberlength + 1;
            }
            if (this.button1.Text == "Add Member") {
                InsertMember(memberId.Value, name, mobile, aadhar);
            }else {
                UpdateMember(memberId.Value, name, mobile, aadhar);
            }
            this.Close();
        }
        private void LoadMembers() {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();
                string query = "SELECT top 10 * from tadnreportchild ";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.ClearSelection();
                        dataGridView1.DataSource = dt;
                        memberlength=dt.Rows.Count;
                    }
                }
            }
        }
        private void InsertMember(int id, string name,string mobileNumber, string aadharNumber) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                // Check for duplicate by Id, MobileNumber, or AadharNumber
                string checkQuery = @"SELECT COUNT(*) FROM tadnreportchild 
                              WHERE Id = @Id OR MobileNumber = @MobileNumber OR AadharNumber = @AadharNumber";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn)) {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    checkCmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    checkCmd.Parameters.AddWithValue("@AadharNumber", aadharNumber);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0) {
                        MessageBox.Show("Member with this ID, Mobile Number, or Aadhar Number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // If not duplicate, insert new member
                string insertQuery = @"INSERT INTO tadnreportchild (Id, Name, Age, MobileNumber, AadharNumber, MembershipStatus)
                               VALUES (@Id, @Name,@MobileNumber, @AadharNumber)";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn)) {
                    insertCmd.Parameters.AddWithValue("@Id", id);
                    insertCmd.Parameters.AddWithValue("@Name", name);
                    insertCmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    insertCmd.Parameters.AddWithValue("@AadharNumber", aadharNumber);
                    insertCmd.Parameters.AddWithValue("@AadharNumber", DateTime.UtcNow.ToString());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        MessageBox.Show("Member inserted successfully with Membership ID "+id+" .");
                    }
                    else {
                        MessageBox.Show("Insert failed. Please try again.");
                    }
                }
            }
        }

        private void UpdateMember(int id, string name, string mobileNumber, string aadharNumber) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                string query = @"UPDATE tadnreportchild SET Name = @Name, mobileNumber = @mobileNumber, aadharNumber = @aadharNumber WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    // Use parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                    cmd.Parameters.AddWithValue("@aadharNumber", aadharNumber);
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        MessageBox.Show("Member updated successfully.");
                    }
                    else {
                        MessageBox.Show("Update failed. Member not found.");
                    }
                }
            }
        }
    }
}

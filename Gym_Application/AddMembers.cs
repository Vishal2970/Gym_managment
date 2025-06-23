using Microsoft.VisualBasic;
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
using static System.Net.Mime.MediaTypeNames;
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
            if (this.button1.Text == "Add Member") {
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
                while (isHaving(memberId.Value)) {
                    memberId = memberId.Value + 1;
                }
            }
            if (this.button1.Text == "Add Member") {
                using (var inputForm = new CustomInputBox("Fees Payment", "How many months' fees do you want to pay?", "1")) {
                    if (inputForm.ShowDialog() == DialogResult.OK) {
                        if (int.TryParse(inputForm.InputText, out int months)) {
                            MessageBox.Show($"You chose to pay fees for {months} month(s).");
                            DateTime selectedDate = dateTimePicker1.Value;
                            InsertMember(memberId.Value, name, mobile, aadhar, months,selectedDate.ToString());
                        }
                        else {
                            MessageBox.Show("Please enter a valid number.");
                        }
                    }
                }
                dateTimePicker1.Value = DateTime.Today;
                this.member_name.Text = "";
                this.aadharNumber.Text = "";
                this.mobileNumber.Text = "";
                this.id.Text = "";
                LoadMembers();
            }
            else {
                DateTime selectedDate = dateTimePicker1.Value;
                UpdateMember(memberId.Value, name, mobile, aadhar, selectedDate.ToString());
                this.Close();
            }
        }
        private Boolean isHaving(int id) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                string checkQuery = @"SELECT COUNT(*) FROM gymManagement WHERE Id = @Id ";


                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn)) {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0) {
                        return true;
                    }
                }
            }
            return false;
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
                        memberlength=dt.Rows.Count;
                    }
                }
            }
        }
        private void InsertMember(int id, string name,string mobileNumber, string aadharNumber,int months,string dateSelected) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                string checkQuery = @"SELECT COUNT(*) FROM gymManagement WHERE Id = @Id OR MobileNumber = @MobileNumber OR AadharNumber = @AadharNumber";


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
                string insertQuery = @"INSERT INTO gymManagement (Id, Name, MobileNumber, AadharNumber, MemberShipDate, FeesPayed) 
                 VALUES (@Id, @Name, @MobileNumber, @AadharNumber, @MemberShipDate, @FeesPayed)";
                DateTime date = DateTime.UtcNow;

                if (months != 0) {
                    date = date.AddDays(months * 30);
                }

                string dateString = date.ToString("yyyy-MM-dd");

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn)) {
                    insertCmd.Parameters.AddWithValue("@Id", id);
                    insertCmd.Parameters.AddWithValue("@Name", name);
                    insertCmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    insertCmd.Parameters.AddWithValue("@AadharNumber", aadharNumber);
                    insertCmd.Parameters.AddWithValue("@MemberShipDate", dateSelected);
                    insertCmd.Parameters.AddWithValue("@feesPayed", date.ToString());

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

        private void UpdateMember(int id, string name, string mobileNumber, string aadharNumber,string date) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                // Build the SET clause dynamically
                List<string> updates = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(name)) {
                    updates.Add("Name = @Name");
                    cmd.Parameters.AddWithValue("@Name", name);
                }

                if (!string.IsNullOrEmpty(mobileNumber)) {
                    updates.Add("MobileNumber = @MobileNumber");
                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                }

                if (!string.IsNullOrEmpty(aadharNumber)) {
                    updates.Add("AadharNumber = @AadharNumber");
                    cmd.Parameters.AddWithValue("@AadharNumber", aadharNumber);
                }

                if (!string.IsNullOrEmpty(date)) {
                    updates.Add("MemberShipDate = @MemberShipDate");
                    cmd.Parameters.AddWithValue("@MemberShipDate", date);
                }

                // Agar koi update field hi nahi hai to return karo
                if (updates.Count == 0) {
                    MessageBox.Show("No data provided to update.");
                    return;
                }

                string setClause = string.Join(", ", updates);
                string query = $"UPDATE gymManagement SET {setClause} WHERE Id = @Id";
                cmd.CommandText = query;
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

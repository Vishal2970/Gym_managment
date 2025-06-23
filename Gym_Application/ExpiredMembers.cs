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
    public partial class ExpiredMembers : Form {
        public ExpiredMembers() {
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
                        var filteredRows = dt.AsEnumerable().Where(row =>row.Field<DateTime?>("FeesPayed") != null && row.Field<DateTime>("FeesPayed") < DateTime.Today.AddDays(-30));
                        //if (filteredRows.Any())
                        //    dataGridView1.DataSource = filteredRows.CopyToDataTable();
                        //else
                        //    dataGridView1.DataSource = null;
                        if (filteredRows.Any()) {
                            dataGridView1.DataSource = filteredRows.CopyToDataTable();
                        }
                        else {
                            // Create a temporary table with same structure
                            DataTable emptyTable = dt.Clone();
                            DataRow row = emptyTable.NewRow();
                            emptyTable.Rows.Add(row);

                            dataGridView1.DataSource = emptyTable;
                        }

                    }
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e) {
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

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Member ID: {memberId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) {
                    DeleteMember(memberId);
                    // Optionally remove row from DataGridView on successful deletion:
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            else {
                MessageBox.Show("Please select a member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteMember(int id) {
            using (SqlConnection conn = Database.GetConnection()) {
                conn.Open();

                string query = "DELETE FROM gymManagement WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        MessageBox.Show("Member deleted successfully.");
                    }
                    else {
                        MessageBox.Show("Delete failed. Member not found.");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class ManageDatabaseBackups : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource backupBindingSource = new BindingSource();

        public ManageDatabaseBackups(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter backup log ID");
        }

        private void ManageDatabaseBackups_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadBackupLogs();
            btnSearch.Click += btnSearch_Click;
            btnInitiateBackup.Click -= btnInitiateBackup_Click;
            btnInitiateBackup.Click += btnInitiateBackup_Click;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
            this.Hide();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.ShowDialog();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.ShowDialog();
            this.Hide();
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.ShowDialog();
            this.Hide();
        }

        private void composeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.ShowDialog();
            this.Hide();
        }

        private void SetupPlaceholders(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void SetupGridView()
        {
            dataGridBackupLogs.Columns.Clear();

            DataGridViewTextBoxColumn backupIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "backup_id",
                HeaderText = "Backup ID",
                DataPropertyName = "database_backup_log_id",
                ReadOnly = true
            };
            dataGridBackupLogs.Columns.Add(backupIDColumn);

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "date",
                HeaderText = "Date and Time of Backup",
                DataPropertyName = "date",
                ReadOnly = true
            };
            dataGridBackupLogs.Columns.Add(dateColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "status",
                HeaderText = "Status",
                DataPropertyName = "status",
                ReadOnly = true
            };
            dataGridBackupLogs.Columns.Add(statusColumn);

            dataGridBackupLogs.AllowUserToAddRows = false;
            dataGridBackupLogs.RowHeadersVisible = false;
        }

        private void LoadBackupLogs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT database_backup_log_id, date, status FROM DatabaseBackupLog";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        backupBindingSource.DataSource = dt;
                        dataGridBackupLogs.DataSource = backupBindingSource;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading backup logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Enter backup ID")
            {
                int backupID;

                if (int.TryParse(searchQuery, out backupID))
                {
                    backupBindingSource.Filter = $"database_backup_log_id = {backupID}";
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric Backup ID.", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                backupBindingSource.RemoveFilter();
            }
        }

        private void btnInitiateBackup_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Backup_{DateTime.Now:yyyyMMddHHmmss}.bak");

            bool isBackupSuccessful = false; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string backupQuery = $@"
                BACKUP DATABASE [{conn.Database}]
                TO DISK = '{backupPath}'
                WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of Current Database';";

                    using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        isBackupSuccessful = true; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    string logQuery = @"
                INSERT INTO DatabaseBackupLog (admin_id, date, status)
                VALUES (@AdminID, @Date, @Status)";

                    using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                    {
                        logCmd.Parameters.AddWithValue("@AdminID", loggedInUserId);
                        logCmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        logCmd.Parameters.AddWithValue("@Status", isBackupSuccessful ? "Completed" : "Failed");

                        logCmd.ExecuteNonQuery();
                    }

                    if (isBackupSuccessful)
                    {
                        MessageBox.Show($"Database backup completed successfully! File: {backupPath}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadBackupLogs(); 
                }
            }
        }
    }
}

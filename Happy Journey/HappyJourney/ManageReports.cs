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
using System.Configuration;

namespace HappyJourney
{
    public partial class ManageReports : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource reportBindingSource = new BindingSource();

        public ManageReports(int userId, int userRole)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = userRole;

            SetupPlaceholder(txtFlightId, "Flight ID");
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.Show();
            this.Hide();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.Show();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.Show();
            this.Hide();
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.Show();
            this.Hide();
        }

        private void composeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.Show();
            this.Hide();
        }

        private void SetupPlaceholder(TextBox textBox, string placeholderText)
        {
            // Set placeholder text and color
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.LightGray;

            // clear placeholder text on focus
            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = ""; // Clear the placeholder text
                    textBox.ForeColor = Color.Black; // Reset text color
                }
            };

            // Restore placeholder text if empty
            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText; // Restore placeholder text
                    textBox.ForeColor = Color.LightGray; // Set placeholder color
                }
            };
        }

        private void ManageReports_Load(object sender, EventArgs e)
        {
            btnGenerateSummary.Click += btnGenerateSummary_Click;
            btnGenerateManifest.Click += btnGenerateManifest_Click;
            SetupGridView();
        }

        private void SetupGridView()
        {
            dataGridReport.Columns.Clear();
            dataGridReport.AllowUserToAddRows = false;
            dataGridReport.RowHeadersVisible = false;
            dataGridReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT flight_number AS 'Flight Number', origin_airport_id AS 'Origin', destination_airport_id AS 'Destination', 
                                   departure_time AS 'Departure Time', arrival_time AS 'Arrival Time'
                                   FROM Flight WHERE CAST(departure_time AS DATE) = CAST(GETDATE() AS DATE)";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        reportBindingSource.DataSource = dt;
                        dataGridReport.DataSource = reportBindingSource;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating flight summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerateManifest_Click(object sender, EventArgs e)
        {
            string flightId = txtFlightId.Text.Trim();

            if (string.IsNullOrEmpty(flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT passenger_id AS 'Passenger ID', cpr AS 'CPR', seat_code AS 'Seat Code'
                        FROM Passenger WHERE booking_id IN (SELECT booking_id FROM Booking WHERE flight_id = @FlightID)";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@FlightID", flightId);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            reportBindingSource.DataSource = dt;
                            dataGridReport.DataSource = reportBindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No passengers found for the specified Flight ID.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridReport.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating passenger manifest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class EditFlight : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedFlightId;

        public EditFlight(int userId, int roleId, int flightId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedFlightId = flightId;

            LoadStatuses();
            LoadFlightDetails();
        }

        private void EditFlight_Load(object sender, EventArgs e)
        {
            lblEditFlight.Left = (this.ClientSize.Width - lblEditFlight.Width) / 2;
            btnSaveChanges.Left = (this.ClientSize.Width - btnSaveChanges.Width) / 2;
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArrival.Text) ||
                string.IsNullOrWhiteSpace(txtDeparture.Text) ||
                string.IsNullOrWhiteSpace(txtAvailableSeats.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(txtArrival.Text.Trim(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime arrivalTime) ||
                !DateTime.TryParseExact(txtDeparture.Text.Trim(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime departureTime))
            {
                MessageBox.Show("Arrival time and Departure time must be in the format YYYY-MM-DD HH:MM:SS.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAvailableSeats.Text.Trim(), out int availableSeats))
            {
                MessageBox.Show("Available seats must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Price must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cmbStatus.SelectedItem.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = @"
                        UPDATE Flight 
                        SET arrival_time = @ArrivalTime, 
                            departure_time = @DepartureTime, 
                            available_seats = @AvailableSeats, 
                            price = @Price, 
                            status = @Status 
                        WHERE flight_id = @FlightID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                        cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
                        cmd.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@FlightID", passedFlightId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Flight details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made. Please check your input.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating flight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Scheduled");
            cmbStatus.Items.Add("Delayed");
            cmbStatus.Items.Add("Cancelled");
        }

        private void LoadFlightDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT arrival_time, departure_time, available_seats, price, status FROM Flight WHERE flight_id = @FlightID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FlightID", passedFlightId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtArrival.Text = Convert.ToDateTime(reader["arrival_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                txtDeparture.Text = Convert.ToDateTime(reader["departure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                txtAvailableSeats.Text = reader["available_seats"].ToString();
                                txtPrice.Text = reader["price"].ToString();

                                string status = reader["status"].ToString();
                                cmbStatus.SelectedItem = status;
                                if (cmbStatus.SelectedItem == null)
                                {
                                    cmbStatus.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Flight not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading flight details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            ManageFlights manageFlights = new ManageFlights(loggedInUserId, loggedInUserRoleId);
            manageFlights.ShowDialog();
            this.Hide();
        }
    }
}
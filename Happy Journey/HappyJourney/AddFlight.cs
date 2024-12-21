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
    public partial class AddFlight : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public AddFlight(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholder(txtOrigin, "Origin");
            SetupPlaceholder(txtDestination, "Destination");
            SetupPlaceholder(txtDeparture, "Departure time");
            SetupPlaceholder(txtArrival, "Arrival time");
            SetupPlaceholder(txtPrice, "Price");
            SetupPlaceholder(txtAvailableSeats, "Available seats");

            btnAdd.Click += btnAdd_Click;
        }

        private void AddFlight_Load(object sender, EventArgs e)
        {
            lblAddFlight.Left = (this.ClientSize.Width - lblAddFlight.Width) / 2;
            btnAdd.Left = (this.ClientSize.Width - btnAdd.Width) / 2;
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

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            ManageFlights manageFlights = new ManageFlights(loggedInUserId, loggedInUserRoleId);
            manageFlights.ShowDialog();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtOrigin.Text) || txtOrigin.Text == "Origin airport ID" ||
                string.IsNullOrWhiteSpace(txtDestination.Text) || txtDestination.Text == "Destination airport ID" ||
                string.IsNullOrWhiteSpace(txtDeparture.Text) || txtDeparture.Text == "Departure date & time" ||
                string.IsNullOrWhiteSpace(txtArrival.Text) || txtArrival.Text == "Arrival date & time" ||
                string.IsNullOrWhiteSpace(txtAvailableSeats.Text) || txtAvailableSeats.Text == "Available seats" ||
                string.IsNullOrWhiteSpace(txtPrice.Text) || txtPrice.Text == "Price")
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtOrigin.Text.Trim(), out int originAirportId) ||
                !int.TryParse(txtDestination.Text.Trim(), out int destinationAirportId))
            {
                MessageBox.Show("Origin and Destination must be valid Airport IDs.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(txtDeparture.Text.Trim(), out DateTime departureTime) ||
                !DateTime.TryParse(txtArrival.Text.Trim(), out DateTime arrivalTime))
            {
                MessageBox.Show("Please enter valid dates in the format YYYY-MM-DD HH:MM:SS.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Flight (origin_airport_id, destination_airport_id, arrival_time, departure_time, available_seats, status, price)
                        OUTPUT INSERTED.flight_id
                        VALUES (@Origin, @Destination, @ArrivalTime, @DepartureTime, @AvailableSeats, @Status, @Price)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Origin", originAirportId);
                        cmd.Parameters.AddWithValue("@Destination", destinationAirportId);
                        cmd.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                        cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
                        cmd.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                        cmd.Parameters.AddWithValue("@Status", "Scheduled");
                        cmd.Parameters.AddWithValue("@Price", price);

                        int flightId = (int)cmd.ExecuteScalar();
                        string flightNumber = "HJ" + flightId;

                        string updateQuery = "UPDATE Flight SET flight_number = @FlightNumber WHERE flight_id = @FlightID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@FlightNumber", flightNumber);
                            updateCmd.Parameters.AddWithValue("@FlightID", flightId);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Flight added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the flight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtOrigin.Text = "Origin Airport ID";
            txtDestination.Text = "Destination Airport ID";
            txtDeparture.Text = "Departure time (YYYY-MM-DD)";
            txtArrival.Text = "Arrival time (YYYY-MM-DD)";
            txtAvailableSeats.Text = "Available seats";
            txtPrice.Text = "Price";

            txtOrigin.ForeColor = Color.LightGray;
            txtDestination.ForeColor = Color.LightGray;
            txtDeparture.ForeColor = Color.LightGray;
            txtArrival.ForeColor = Color.LightGray;
            txtAvailableSeats.ForeColor = Color.LightGray;
            txtPrice.ForeColor = Color.LightGray;
        }
    }
}

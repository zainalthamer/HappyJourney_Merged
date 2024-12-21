using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyJourney.entities;
using HappyJourney.services;
using HappyJourney.singletons;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HappyJourney
{
    public partial class Bookings : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        readonly string bookingIdPlaceholder = "Enter Booking ID";
        public Bookings(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            User user = UserSession.Instance.CurrentUser;

            if (user != null) {
                FetchAndLogBookings(user.UserId);
            }

            PlaceholderService.SetupPlaceholder(textBoxSearch, bookingIdPlaceholder);

            Font inputFont = new Font("Segoe UI", 10);

            textBoxSearch.Font = inputFont;
            textBoxSearch.Size = new Size(textBoxSearch.Size.Width, 30);
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;


            btnSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnSearch.Size = new Size(100, 30);
            btnSearch.BackColor = Color.Black;
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Cursor = Cursors.Hand;

            dataGridView1.CellMouseEnter += (s, e) =>
            {
                DataGridViewColumn bookingIdColumn = dataGridView1.Columns["Booking ID"];

                if (bookingIdColumn != null && e.ColumnIndex == bookingIdColumn.Index && e.RowIndex >= 0)
                {
                    dataGridView1.Cursor = Cursors.Hand;
                }
            };

            dataGridView1.CellMouseLeave += (s, e) =>
            {
                dataGridView1.Cursor = Cursors.Default;
            };
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if it's a valid row (not header, not out of bounds)
            if (e.RowIndex >= 0)
            {
                // Check if the clicked column is "Booking ID"
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Booking ID")
                {
                    // Get the flight ID from the clicked cell
                    int bookingId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Booking ID"].Value);

                    // Create and show the FlightDetail form
                    ExactBooking exactBookingForm = new ExactBooking(bookingId);
                    exactBookingForm.ShowDialog();
                }
            }
        }

        private void FetchAndLogBookings(int travelerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string baseQuery = @"
        SELECT 
            b.booking_id as 'Booking ID',
            f.flight_number as 'Flight Number',
            b.totalPrice as 'Paid Amount',
            b.status as 'Status',
            f.departure_time as 'Departure Time',
            a1.name as 'From',
            a2.name as 'To'
        FROM Booking b
        INNER JOIN Flight f ON b.flight_id = f.flight_id
        INNER JOIN Airport a1 ON f.origin_airport_id = a1.airport_id
        INNER JOIN Airport a2 ON f.destination_airport_id = a2.airport_id
        WHERE b.traveler_id = @TravelerId";

            // Add booking ID filter if search box has a value
            if (!string.IsNullOrEmpty(textBoxSearch.Text) && textBoxSearch.Text != bookingIdPlaceholder)
            {
                baseQuery += " AND b.booking_id = @BookingId";
            }

            baseQuery += " ORDER BY b.date DESC";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(baseQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@TravelerId", travelerId);

                        if (!string.IsNullOrEmpty(textBoxSearch.Text) && textBoxSearch.Text != bookingIdPlaceholder)
                        {
                            if (int.TryParse(textBoxSearch.Text.Trim(), out int bookingId))
                            {
                                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid booking ID number", "Invalid Input",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Create a DataTable to hold the results
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dt;

                        // Style the grid
                        dataGridView1.EnableHeadersVisualStyles = false;
                        dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
                        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
                        dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 35, 35); // Keep header black when selected
                        dataGridView1.ColumnHeadersHeight = 45;  // Increase header height
                        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
                        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        // Format grid
                        dataGridView1.BackgroundColor = Color.White;
                        dataGridView1.GridColor = Color.Black;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.ReadOnly = true;  // Make grid non-editable
                        dataGridView1.RowHeadersVisible = false;  // Remove the left-most column
                        dataGridView1.BorderStyle = BorderStyle.None;
                        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        dataGridView1.ScrollBars = ScrollBars.None;
                        dataGridView1.AllowUserToAddRows = false;

                        // Add padding to cells
                        dataGridView1.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
                        dataGridView1.RowTemplate.Height = 40;  // Increase row height

                        // Format the grid
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        dataGridView1.Columns["Paid Amount"].DefaultCellStyle.Format = "C2"; // Currency format
                        dataGridView1.Columns["Departure Time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                        dataGridView1.Columns["Flight Number"].FillWeight = 20;
                        dataGridView1.Columns["Booking ID"].FillWeight = 20;
                        dataGridView1.Columns["Paid Amount"].FillWeight = 20;
                        dataGridView1.Columns["Status"].FillWeight = 15;
                        dataGridView1.Columns["Departure Time"].FillWeight = 20;
                        dataGridView1.Columns["From"].FillWeight = 20;
                        dataGridView1.Columns["To"].FillWeight = 20;

                        // Color coding for status
                        dataGridView1.CellFormatting += (s, e) =>
                        {
                            if (e.ColumnIndex == dataGridView1.Columns["Status"].Index)
                            {
                                string status = e.Value?.ToString().ToLower();
                                switch (status)
                                {
                                    case "confirmed":
                                        e.CellStyle.BackColor = Color.LightGreen;
                                        break;
                                    case "cancelled":
                                        e.CellStyle.BackColor = Color.LightPink;
                                        break;
                                    case "pending":
                                        e.CellStyle.BackColor = Color.LightYellow;
                                        break;
                                }
                            }
                        };

                        // Center align all columns
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            if (col.HeaderText == "Booking ID")
                            {
                                col.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Underline);
                                col.DefaultCellStyle.ForeColor = Color.Blue;
                                col.DefaultCellStyle.SelectionForeColor = Color.Blue;
                            }
                        }

                        // Log to file

                        Console.WriteLine($"\nBookings fetched for Traveler ID: {travelerId} at {DateTime.Now}");
                        foreach (DataRow row in dt.Rows)
                        {
                            Console.WriteLine($"Booking {row["Booking ID"]}: Flight {row["Flight Number"]} from {row["From"]} to {row["To"]} on {row["Departure Time"]}");
                        }
                        Console.WriteLine("----------------------------------------");

                        // Show message if no bookings found
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No bookings found for this traveler.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching bookings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log error
                string logPath = Path.Combine(Application.StartupPath, "error_logs.txt");
                File.AppendAllText(logPath,
                    $"\n[{DateTime.Now}] Error fetching bookings for Traveler ID {travelerId}: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text) && textBoxSearch.Text.Length != 0)
            {
                FetchAndLogBookings(2);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bookings_Load(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
            this.Hide();
        }

        private void bookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookings bookings = new Bookings(loggedInUserId, loggedInUserRoleId);
            bookings.ShowDialog();
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
    }
}
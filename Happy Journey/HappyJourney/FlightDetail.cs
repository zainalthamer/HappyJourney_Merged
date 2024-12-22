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
    public partial class FlightDetail : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private readonly int flightId;

        public FlightDetail(int userId, int roleId, int flightId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            this.flightId = flightId;
            this.StartPosition = FormStartPosition.CenterScreen;

            imgBackArrow.Cursor = Cursors.Hand;

            btnBookFlight.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnBookFlight.Size = new Size(100, 30);
            btnBookFlight.BackColor = Color.Black;
            btnBookFlight.ForeColor = Color.White;
            btnBookFlight.FlatStyle = FlatStyle.Flat;
            btnBookFlight.FlatAppearance.BorderSize = 0;
            btnBookFlight.Cursor = Cursors.Hand;

            LoadFlightDetails();
        }

        private void LoadFlightDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Query for flight details
            string flightQuery = @"
    SELECT 
        f.flight_id as 'Flight ID',
        a1.iata_code as 'Origin',
        a2.iata_code as 'Destination',
        f.departure_time as 'Departure',
        f.arrival_time as 'Arrival'
    FROM Flight f
    INNER JOIN Airport a1 ON f.origin_airport_id = a1.airport_id
    INNER JOIN Airport a2 ON f.destination_airport_id = a2.airport_id
    WHERE f.flight_id = @FlightId";

            // Query for seat categories
            string seatQuery = @"
    SELECT 
        name as 'Class',
        CONCAT(price, ' BHD') as 'Price'
    FROM SeatCategory
    ORDER BY price ASC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Load flight details
                    using (SqlCommand cmd = new SqlCommand(flightQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@FlightId", flightId);
                        DataTable flightDt = new DataTable();
                        SqlDataAdapter flightAdapter = new SqlDataAdapter(cmd);
                        flightAdapter.Fill(flightDt);
                        StyleFlightGridView(flightDt);
                    }

                    // Load seat categories
                    using (SqlCommand cmd = new SqlCommand(seatQuery, connection))
                    {
                        DataTable seatDt = new DataTable();
                        SqlDataAdapter seatAdapter = new SqlDataAdapter(cmd);
                        seatAdapter.Fill(seatDt);
                        StyleSeatCategoryGridView(seatDt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading flight details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleFlightGridView(DataTable dt)
        {
            flightsGridView.DataSource = dt;

            // Basic grid settings
            flightsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flightsGridView.ReadOnly = true;
            flightsGridView.RowHeadersVisible = false;
            flightsGridView.BorderStyle = BorderStyle.None;
            flightsGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            flightsGridView.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            flightsGridView.RowTemplate.Height = 40;

            // Remove extra row
            flightsGridView.AllowUserToAddRows = false;
            flightsGridView.ScrollBars = ScrollBars.None;

            // Header styling
            flightsGridView.EnableHeadersVisualStyles = false;
            flightsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            flightsGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            flightsGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            flightsGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            flightsGridView.ColumnHeadersHeight = 45;
            flightsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Cell styling
            flightsGridView.BackgroundColor = Color.White;
            flightsGridView.GridColor = Color.Black;
            flightsGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            flightsGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Center align all columns
            foreach (DataGridViewColumn col in flightsGridView.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (flightsGridView.Columns.Contains("Departure"))
            {
                flightsGridView.Columns["Departure"].DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";
            }
            if (flightsGridView.Columns.Contains("Arrival"))
            {
                flightsGridView.Columns["Arrival"].DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";
            }
        }

        private void StyleSeatCategoryGridView(DataTable dt)
        {
            seatCategoryGridView.DataSource = dt;

            // Basic grid settings
            seatCategoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            seatCategoryGridView.ReadOnly = true;
            seatCategoryGridView.RowHeadersVisible = false;
            seatCategoryGridView.BorderStyle = BorderStyle.None;
            seatCategoryGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            seatCategoryGridView.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            seatCategoryGridView.RowTemplate.Height = 40;

            // Header styling
            seatCategoryGridView.EnableHeadersVisualStyles = false;
            seatCategoryGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            seatCategoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            seatCategoryGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            seatCategoryGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            seatCategoryGridView.ColumnHeadersHeight = 45;
            seatCategoryGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Remove extra row
            seatCategoryGridView.AllowUserToAddRows = false;
            seatCategoryGridView.ScrollBars = ScrollBars.None;

            // Cell styling
            seatCategoryGridView.BackgroundColor = Color.White;
            seatCategoryGridView.GridColor = Color.Black;
            seatCategoryGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            seatCategoryGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Center align all columns
            foreach (DataGridViewColumn col in seatCategoryGridView.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void flightsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void seatCategoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            Book_flight book_Flight = new Book_flight(loggedInUserId, loggedInUserRoleId, flightId);
            book_Flight.Show();
            Hide();
        }

        private void FlightDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
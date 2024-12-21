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
    public partial class Payment : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedFlightId;
        private List<Passenger> passengers;
        private decimal additionalServicesCost;
        private decimal baseFare;
        private decimal vat;
        private decimal grandTotal;

        public Payment(int userId, int roleId, int flightId, List<Passenger> passengers, decimal additionalServicesCost, decimal baseFare, decimal vat, decimal grandTotal)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedFlightId = flightId;
            this.passengers = passengers;
            this.additionalServicesCost = additionalServicesCost;
            this.baseFare = baseFare;
            this.vat = vat;
            this.grandTotal = grandTotal;

            SetupPlaceholder(txtCardNumber, "456825*****52064");
            SetupPlaceholder(txtExpiration, "MM/YY");
            SetupPlaceholder(txtCvv, "367");

            SetupMenuStrip();
            PopulatePaymentDetails();
            PopulatePaymentMethods();
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void PopulatePaymentMethods()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT payment_method_id, type FROM PaymentMethod";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            cmbPaymentMethod.DataSource = dt;
                            cmbPaymentMethod.DisplayMember = "type"; // Display the type of payment
                            cmbPaymentMethod.ValueMember = "payment_method_id"; // Store the payment_method_id as the value
                            cmbPaymentMethod.SelectedIndex = -1; // Set no initial selection
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading payment methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void imgBakArrow_Click(object sender, EventArgs e)
        {
            Book_flight book_flight = new Book_flight(loggedInUserId, loggedInUserRoleId, passedFlightId);
            book_flight.Show();
            this.Hide();
        }

        private void SetupMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem homeItem = new ToolStripMenuItem("Home");
            homeItem.Click += (s, e) =>
            {
                MessageBox.Show("You are already on the Home page.");
            };

            ToolStripMenuItem profileItem = new ToolStripMenuItem("Profile");
            profileItem.Click += (s, e) => NavigateToProfile();

            ToolStripMenuItem inboxItem = new ToolStripMenuItem("Inbox");
            inboxItem.Click += (s, e) => NavigateToInbox();

            ToolStripMenuItem composeItem = new ToolStripMenuItem("Compose");
            composeItem.Click += (s, e) => NavigateToCompose();

            menuStrip.Items.Add(homeItem);

            if (loggedInUserRoleId == 1)
            {
                ToolStripMenuItem dashboardItem = new ToolStripMenuItem("Dashboard");
                dashboardItem.Click += (s, e) => NavigateToDashboard();
                menuStrip.Items.Add(dashboardItem);
            }

            else if (loggedInUserRoleId == 3)
            {
                ToolStripMenuItem bookingsItem = new ToolStripMenuItem("Bookings");
                bookingsItem.Click += (s, e) => NavigateToBookings();
                menuStrip.Items.Add(bookingsItem);
            }

            menuStrip.Items.Add(profileItem);
            menuStrip.Items.Add(inboxItem);
            menuStrip.Items.Add(composeItem);

            this.mnuPayment = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void NavigateToInbox()
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.ShowDialog();
            this.Hide();

        }

        private void NavigateToCompose()
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.ShowDialog();
            this.Hide();
        }

        private void NavigateToProfile()
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.ShowDialog();
            this.Hide();
        }

        private void NavigateToDashboard()
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.ShowDialog();
            this.Hide();
        }

        private void NavigateToBookings()
        {
            Bookings bookings = new Bookings(loggedInUserId, loggedInUserRoleId);
            bookings.ShowDialog();
            this.Hide();
        }

        private void NavigateToHome()
        {
            MessageBox.Show("You are already on the Home page.");
        }

        private void PopulatePaymentDetails()
        {
            lblBaseFares.Text = $"{baseFare:C2}";
            lblAdditionalServices.Text = $"{additionalServicesCost:C2}";
            lblVat.Text = $"{vat:C2}";
            lblGrandTotal.Text = $"{grandTotal:C2}";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!ValidatePaymentDetails())
            {
                MessageBox.Show("Please fill out all payment details correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveBookingDetails();
                MessageBox.Show("Payment successful! Your booking has been completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePaymentDetails()
        {
            if (cmbPaymentMethod.SelectedItem == null || string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                string.IsNullOrWhiteSpace(txtExpiration.Text) || string.IsNullOrWhiteSpace(txtCvv.Text))
            {
                return false;
            }

            if (!DateTime.TryParseExact(txtExpiration.Text, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime expirationDate) || expirationDate < DateTime.Now)
            {
                MessageBox.Show("Please enter a valid expiration date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCvv.Text.Length != 3 || !int.TryParse(txtCvv.Text, out _))
            {
                MessageBox.Show("Please enter a valid CVV (3 digits).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveBookingDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string insertBookingQuery = @"
                    INSERT INTO Booking (traveler_id, flight_id, date, totalPrice, status, seat_category)
                    VALUES (@TravelerId, @FlightId, @Date, @TotalPrice, @Status, @SeatCategory);
                    SELECT SCOPE_IDENTITY();";

                int bookingId;

                using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TravelerId", passengers[0].CPR);
                    cmd.Parameters.AddWithValue("@FlightId", passengers[0].BookingId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TotalPrice", grandTotal);
                    cmd.Parameters.AddWithValue("@Status", "Confirmed");
                    cmd.Parameters.AddWithValue("@SeatCategory", "Economy");

                    bookingId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var passenger in passengers)
                {
                    string insertPassengerQuery = @"
                        INSERT INTO Passenger (booking_id, seat_code, cpr, first_name, last_name, date_of_birth, gender, price)
                        VALUES (@BookingId, @SeatCode, @CPR, @FirstName, @LastName, @DateOfBirth, @Gender, @Price);";

                    using (SqlCommand cmd = new SqlCommand(insertPassengerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        cmd.Parameters.AddWithValue("@SeatCode", passenger.SeatCode);
                        cmd.Parameters.AddWithValue("@CPR", passenger.CPR);
                        cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", passenger.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", passenger.Gender);
                        cmd.Parameters.AddWithValue("@Price", passenger.Price);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Insert transaction details
                string insertTransactionQuery = @"
                    INSERT INTO Transaction (payment_method_id, amount, date, status)
                    VALUES (@PaymentMethod, @Amount, @Date, @Status);";

                using (SqlCommand cmd = new SqlCommand(insertTransactionQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Amount", grandTotal);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", "Success");

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

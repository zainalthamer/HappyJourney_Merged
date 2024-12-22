using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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

        public Payment(int userId, int roleId, int flightId, List<Passenger> passengers, decimal additionalServices, decimal baseFare, decimal vat, decimal grandTotal)
        {
            InitializeComponent();

            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedFlightId = flightId;
            this.passengers = passengers;
            this.additionalServicesCost = additionalServices;
            this.baseFare = baseFare;
            this.vat = vat;
            this.grandTotal = grandTotal;

            LoadPaymentMethods();
            DisplayPrices();

            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
        }

        private void DisplayPrices()
        {
            lblBaseFaresPrice.Text = $"{baseFare:F2} BHD";
            lblAdditionalServicesPrice.Text = $"{additionalServicesCost:F2} BHD";
            lblVatPrice.Text = $"{vat:F2} BHD";
            lblGrandTotalPrice.Text = $"{grandTotal:F2} BHD";
        }

        private void LoadPaymentMethods()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT payment_method_id, type FROM PaymentMethod";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int paymentMethodId = reader.GetInt32(0);
                                string paymentType = reader.GetString(1);
                                cmbPaymentMethod.Items.Add(new ComboBoxItem { Value = paymentMethodId, Text = paymentType });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment methods: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidatePaymentDetails())
            {
                return;
            }

            ComboBoxItem selectedPaymentMethod = cmbPaymentMethod.SelectedItem as ComboBoxItem;
            if (selectedPaymentMethod == null)
            {
                MessageBox.Show("Invalid payment method selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int paymentMethodId = selectedPaymentMethod.Value;

            try
            {
                SaveBooking(paymentMethodId);
                MessageBox.Show("Payment successful! Your booking has been confirmed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing your payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePaymentDetails()
        {
            string cardNumber = txtCardNumber.Text.Trim();
            string expiration = txtExpiration.Text.Trim();
            string cvv = txtCvv.Text.Trim();

            if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length != 16 || !long.TryParse(cardNumber, out _))
            {
                MessageBox.Show("Please enter a valid 16-digit card number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expiration) || !DateTime.TryParseExact(expiration, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime expiryDate) || expiryDate < DateTime.Now)
            {
                MessageBox.Show("Please enter a valid expiration date (MM/yy) that is not expired.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cvv) || cvv.Length != 3 || !int.TryParse(cvv, out _))
            {
                MessageBox.Show("Please enter a valid 3-digit CVV.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveBooking(int paymentMethodId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Save transaction
                string transactionQuery = "INSERT INTO [Transaction] (payment_method_id, amount, date) OUTPUT INSERTED.transaction_id VALUES (@PaymentMethodId, @Amount, @Date)";
                int transactionId;
                using (SqlCommand cmd = new SqlCommand(transactionQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentMethodId", paymentMethodId);
                    cmd.Parameters.AddWithValue("@Amount", grandTotal);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    transactionId = (int)cmd.ExecuteScalar();
                }

                // Save booking
                string bookingQuery = "INSERT INTO Booking (employer_id, traveler_id, transaction_id, date, flight_id, totalPrice, status, seat_category_id) OUTPUT INSERTED.booking_id " +
                      "VALUES (@EmployerId, @TravelerId, @TransactionId, @Date, @FlightId, @TotalPrice, @Status, @SeatCategoryId)";
                int bookingId;
                using (SqlCommand cmd = new SqlCommand(bookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployerId", loggedInUserRoleId == 2 ? (object)loggedInUserId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TravelerId", loggedInUserRoleId == 3 ? (object)loggedInUserId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TransactionId", transactionId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FlightId", passedFlightId);
                    cmd.Parameters.AddWithValue("@TotalPrice", grandTotal);
                    cmd.Parameters.AddWithValue("@Status", "Confirmed");

                    int seatCategoryId = 1; 
                    cmd.Parameters.AddWithValue("@SeatCategoryId", seatCategoryId);

                    bookingId = (int)cmd.ExecuteScalar();
                }

                // Save passengers
                foreach (var passenger in passengers)
                {
                    string passengerQuery = "INSERT INTO Passenger (booking_id, seat_code, cpr, first_name, last_name, date_of_birth, price, gender) " +
                                            "VALUES (@BookingId, @SeatCode, @CPR, @FirstName, @LastName, @DateOfBirth, @Price, @Gender)";
                    using (SqlCommand cmd = new SqlCommand(passengerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        cmd.Parameters.AddWithValue("@SeatCode", passenger.SeatCode);
                        cmd.Parameters.AddWithValue("@CPR", passenger.CPR);
                        cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", passenger.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Price", passenger.Price);
                        cmd.Parameters.AddWithValue("@Gender", passenger.Gender);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private int? GetSeatCategoryIdFromSeatCode(string seatCode, SqlConnection conn)
        {
            if (string.IsNullOrWhiteSpace(seatCode))
            {
                return null; // Return null if the seat code is invalid
            }

            string query = "SELECT seat_category_id FROM SeatCategory WHERE seat_code = @SeatCode";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SeatCode", seatCode);

                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int seatCategoryId))
                {
                    return seatCategoryId;
                }
            }

            return null; // Return null if no matching seat category ID is found
        }
    }
}

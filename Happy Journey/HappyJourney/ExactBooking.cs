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
    public partial class ExactBooking : Form
    {
        private readonly int bookingId;
        public ExactBooking(int bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;

            SetupFormStyle();
            LoadBookingDetails();
        }

        private void ExactBooking_Load(object sender, EventArgs e)
        {
        }

        private void SetupFormStyle()
        {
            // Style for the FlowLayoutPanel
            servicesFlowLayoutPanel.AutoScroll = true;
            servicesFlowLayoutPanel.WrapContents = true;
            servicesFlowLayoutPanel.Padding = new Padding(10);

            imgBackArrow.Cursor = Cursors.Hand;
        }

        private void LoadBookingDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = @"
        SELECT 
            b.status,
            b.totalPrice,
            sc.name as category,
            p.first_name,
            p.last_name,
            p.cpr,
            p.date_of_birth,
            p.gender,
            p.seat_code,
            bs.service_id
        FROM Booking b
        LEFT JOIN SeatCategory sc ON b.seat_category_id = sc.seat_category_id
        LEFT JOIN Passenger p ON b.booking_id = p.booking_id
        LEFT JOIN BookingService bs ON b.booking_id = bs.booking_id
        WHERE b.booking_id = @BookingId";

            string servicesQuery = @"
        SELECT 
            service_id,
            name,
            price
        FROM Service";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    HashSet<int> selectedServices = new HashSet<int>();

                    // Load booking details and passengers
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int passengerCount = 0;

                            while (reader.Read())
                            {
                                // Load basic booking info (only once)
                                if (passengerCount == 0)
                                {
                                    statusLabel.Text = reader["status"].ToString();
                                    priceLabel.Text = $"{reader["totalPrice"]} BHD";
                                    categoryLabel.Text = reader["category"].ToString();
                                }

                                // Load passenger info
                                if (!reader.IsDBNull(reader.GetOrdinal("first_name")))
                                {
                                    passengerCount++;
                                    string index = passengerCount.ToString();

                                    ((TextBox)this.Controls.Find($"txtFirstName{index}", true)[0]).Text = reader["first_name"].ToString();
                                    ((TextBox)this.Controls.Find($"txtLastName{index}", true)[0]).Text = reader["last_name"].ToString();
                                    ((TextBox)this.Controls.Find($"txtCpr{index}", true)[0]).Text = reader["cpr"].ToString();
                                    ((TextBox)this.Controls.Find($"txtDateOfBirth{index}", true)[0]).Text = reader["date_of_birth"].ToString();
                                    ((TextBox)this.Controls.Find($"txtGender{index}", true)[0]).Text = reader["gender"].ToString();
                                    ((TextBox)this.Controls.Find($"txtSeat{index}", true)[0]).Text = reader["seat_code"].ToString();
                                }

                                // Collect selected service IDs
                                if (!reader.IsDBNull(reader.GetOrdinal("service_id")))
                                {
                                    selectedServices.Add(reader.GetInt32(reader.GetOrdinal("service_id")));
                                }
                            }
                        }
                    }

                    for (int i = 1; i <= 4; i++)
                    {
                        string index = i.ToString();
                        // Get all textboxes for this passenger
                        var textBoxes = new[] {
                            (TextBox)this.Controls.Find($"txtFirstName{index}", true)[0],
                            (TextBox)this.Controls.Find($"txtLastName{index}", true)[0],
                            (TextBox)this.Controls.Find($"txtCpr{index}", true)[0],
                            (TextBox)this.Controls.Find($"txtDateOfBirth{index}", true)[0],
                            (TextBox)this.Controls.Find($"txtGender{index}", true)[0],
                            (TextBox)this.Controls.Find($"txtSeat{index}", true)[0]
                        };

                        // Apply styling to each textbox
                        foreach (var textBox in textBoxes)
                        {
                            textBox.Enabled = false;
                            textBox.BackColor = Color.White;  // Keep white background even when disabled
                            textBox.BorderStyle = BorderStyle.FixedSingle;  // Keep the border visible
                            textBox.ForeColor = Color.Black;
                        }
                    }

                    // Load services into FlowLayoutPanel
                    using (SqlCommand cmd = new SqlCommand(servicesQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int serviceId = reader.GetInt32(reader.GetOrdinal("service_id"));
                                string serviceName = reader.GetString(reader.GetOrdinal("name"));
                                decimal servicePrice = reader.GetDecimal(reader.GetOrdinal("price"));

                                CheckBox checkbox = new CheckBox
                                {
                                    Text = $"{serviceName} ({servicePrice} BHD)",
                                    AutoSize = true,
                                    AutoCheck = false,
                                    Checked = selectedServices.Contains(serviceId)
                                };

                                // Keep checkbox colors even when disabled
                                checkbox.ForeColor = SystemColors.ControlText;  // Keep original text color
                                checkbox.BackColor = Color.Transparent;

                                servicesFlowLayoutPanel.Controls.Add(checkbox);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkLoungeAccess_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void chkLoungeAccess_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
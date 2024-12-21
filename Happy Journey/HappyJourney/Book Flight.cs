using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class Book_flight : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedFlightId;
        private List<string> seatCodes = new List<string>
        {
            "A1", "A2", "A3", "A4", "A5",
            "B1", "B2", "B3", "B4", "B5",
            "C1", "C2", "C3", "C4", "C5",
            "D1", "D2", "D3", "D4", "D5",
            "E1", "E2", "E3", "E4", "E5",
            "F1", "F2", "F3", "F4", "F5",
            "G1", "G2", "G3", "G4", "G5",
            "H1", "H2", "H3", "H4", "H5"
        };
        private Dictionary<string, decimal> servicePrices = new Dictionary<string, decimal>();
        private List<Passenger> passengers = new List<Passenger>();

        public Book_flight(int userId, int roleId, int flightId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedFlightId = flightId;

            SetupMenuStrip();
            PopulateSeatDropdowns();
            LoadServicePrices();

            // Set placeholders for all textboxes
            SetPassengerPlaceholders();
        }

        private void Book_flight_Load(object sender, EventArgs e) { }

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

            this.mnuBookFlight = menuStrip;
            this.Controls.Add(menuStrip);
        }


        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            passengers.Clear();

            if (!ValidatePassenger(txtFirstName1.Text, txtLastName1.Text, txtCpr1.Text, txtDateOfBirth1.Text, txtGender1.Text, cmbSeat1.SelectedItem, out Passenger passenger1))
            {
                MessageBox.Show("Passenger 1 details are required and must be valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            passengers.Add(passenger1);

            if (IsPassengerInputValid(txtFirstName2, txtLastName2, txtCpr2))
            {
                if (!ValidatePassenger(txtFirstName2.Text, txtLastName2.Text, txtCpr2.Text, txtDateOfBirth2.Text, txtGender2.Text, cmbSeat2.SelectedItem, out Passenger passenger2))
                {
                    MessageBox.Show("Please ensure Passenger 2 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger2);
            }

            if (IsPassengerInputValid(txtFirstName3, txtLastName3, txtCpr3))
            {
                if (!ValidatePassenger(txtFirstName3.Text, txtLastName3.Text, txtCpr3.Text, txtDateOfBirth3.Text, txtGender3.Text, cmbSeat3.SelectedItem, out Passenger passenger3))
                {
                    MessageBox.Show("Please ensure Passenger 3 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger3);
            }

            if (IsPassengerInputValid(txtFirstName4, txtLastName4, txtCpr4))
            {
                if (!ValidatePassenger(txtFirstName4.Text, txtLastName4.Text, txtCpr4.Text, txtDateOfBirth4.Text, txtGender4.Text, cmbSeat4.SelectedItem, out Passenger passenger4))
                {
                    MessageBox.Show("Please ensure Passenger 4 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger4);
            }

            ProceedToPayment();
        }

        private void SetPassengerPlaceholders()
        {
            SetupPlaceholder(txtFirstName1, "First name");
            SetupPlaceholder(txtLastName1, "Last name");
            SetupPlaceholder(txtCpr1, "CPR");
            SetupPlaceholder(txtDateOfBirth1, "Date of birth");
            SetupPlaceholder(txtGender1, "Gender");

            SetupPlaceholder(txtFirstName2, "First name");
            SetupPlaceholder(txtLastName2, "Last name");
            SetupPlaceholder(txtCpr2, "CPR");
            SetupPlaceholder(txtDateOfBirth2, "Date of birth");
            SetupPlaceholder(txtGender2, "Gender");

            SetupPlaceholder(txtFirstName3, "First name");
            SetupPlaceholder(txtLastName3, "Last name");
            SetupPlaceholder(txtCpr3, "CPR");
            SetupPlaceholder(txtDateOfBirth3, "Date of birth");
            SetupPlaceholder(txtGender3, "Gender");

            SetupPlaceholder(txtFirstName4, "First name");
            SetupPlaceholder(txtLastName4, "Last name");
            SetupPlaceholder(txtCpr4, "CPR");
            SetupPlaceholder(txtDateOfBirth4, "Date of birth");
            SetupPlaceholder(txtGender4, "Gender");
        }

        private void SetupPlaceholder(TextBox textBox, string placeholderText)
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

        private void PopulateSeatDropdowns()
        {
            cmbSeat1.Items.AddRange(seatCodes.ToArray());
            cmbSeat2.Items.AddRange(seatCodes.ToArray());
            cmbSeat3.Items.AddRange(seatCodes.ToArray());
            cmbSeat4.Items.AddRange(seatCodes.ToArray());
        }

        private void LoadServicePrices()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT name, price FROM Service";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string serviceName = reader.GetString(0);
                                decimal servicePrice = reader.GetDecimal(1);
                                servicePrices[serviceName] = servicePrice;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading service prices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidatePassenger(string firstName, string lastName, string cpr, string dob, string gender, object seat, out Passenger passenger)
        {
            passenger = null;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(cpr) || string.IsNullOrWhiteSpace(dob) || string.IsNullOrWhiteSpace(gender) || seat == null)
            {
                return false;
            }

            if (!DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                return false;
            }

            passenger = new Passenger
            {
                FirstName = firstName,
                LastName = lastName,
                CPR = cpr,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                SeatCode = seat.ToString(),
                Price = servicePrices.ContainsKey("Base Fare") ? servicePrices["Base Fare"] : 0
            };

            return true;
        }

        private bool IsPassengerInputValid(TextBox firstName, TextBox lastName, TextBox cpr)
        {
            return !string.IsNullOrWhiteSpace(firstName.Text) || !string.IsNullOrWhiteSpace(lastName.Text) || !string.IsNullOrWhiteSpace(cpr.Text);
        }

        private void ProceedToPayment()
        {
            decimal additionalServicesCost = CalculateAdditionalServicesCost(passengers.Count);
            decimal baseFare = passengers.Sum(p => p.Price);
            decimal vat = (baseFare + additionalServicesCost) * 0.10m;
            decimal grandTotal = baseFare + additionalServicesCost + vat;

            Payment paymentPage = new Payment(loggedInUserId, loggedInUserRoleId, passedFlightId, passengers, additionalServicesCost, baseFare, vat, grandTotal);
            paymentPage.ShowDialog();
            this.Hide();
        }

        private decimal CalculateAdditionalServicesCost(int passengerCount)
        {
            decimal additionalCost = 0;

            if (chkLoungeAccess.Checked && servicePrices.ContainsKey("Lounge Access"))
                additionalCost += servicePrices["Lounge Access"] * passengerCount;
            if (chkInternetAccess.Checked && servicePrices.ContainsKey("Internet Access"))
                additionalCost += servicePrices["Internet Access"] * passengerCount;
            if (chkComplimentaryMeals.Checked && servicePrices.ContainsKey("Complimentary Meals"))
                additionalCost += servicePrices["Complimentary Meals"] * passengerCount;
            if (chkPriorityBaggageHandling.Checked && servicePrices.ContainsKey("Priority Baggage Handling"))
                additionalCost += servicePrices["Priority Baggage Handling"] * passengerCount;
            if (chkTravelAccessories.Checked && servicePrices.ContainsKey("Travel Accessories"))
                additionalCost += servicePrices["Travel Accessories"] * passengerCount;
            if (chkSpecialAssistance.Checked && servicePrices.ContainsKey("Special Assistance"))
                additionalCost += servicePrices["Special Assistance"] * passengerCount;

            return additionalCost;
        }

        private void NavigateToInbox()
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.ShowDialog();
        }

        private void NavigateToCompose()
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.ShowDialog();
        }

        private void NavigateToProfile()
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.Show();
        }

        private void NavigateToDashboard()
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.ShowDialog();
        }

        private void NavigateToBookings()
        {
            Bookings bookings = new Bookings(loggedInUserId, loggedInUserRoleId);
            bookings.ShowDialog();
        }

        private void NavigateToHome()
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
        }
    }
}

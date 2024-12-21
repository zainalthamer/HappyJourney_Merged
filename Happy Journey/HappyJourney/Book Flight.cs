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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        }

        private void Book_flight_Load(object sender, EventArgs e)
        {

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

            if (!string.IsNullOrWhiteSpace(txtFirstName2.Text) || !string.IsNullOrWhiteSpace(txtLastName2.Text) || !string.IsNullOrWhiteSpace(txtCpr2.Text))
            {
                if (!ValidatePassenger(txtFirstName2.Text, txtLastName2.Text, txtCpr2.Text, txtDateOfBirth2.Text, txtGender2.Text, cmbSeat2.SelectedItem, out Passenger passenger2))
                {
                    MessageBox.Show("Please ensure Passenger 2 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger2);
            }

            if (!string.IsNullOrWhiteSpace(txtFirstName3.Text) || !string.IsNullOrWhiteSpace(txtLastName3.Text) || !string.IsNullOrWhiteSpace(txtCpr3.Text))
            {
                if (!ValidatePassenger(txtFirstName3.Text, txtLastName3.Text, txtCpr4.Text, txtDateOfBirth3.Text, txtGender3.Text, cmbSeat3.SelectedItem, out Passenger passenger3))
                {
                    MessageBox.Show("Please ensure Passenger 3 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger3);
            }

            if (!string.IsNullOrWhiteSpace(txtFirstName4.Text) || !string.IsNullOrWhiteSpace(txtLastName4.Text) || !string.IsNullOrWhiteSpace(txtCpr4.Text))
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

        private void ProceedToPayment()
        {
            List<Passenger> passengers = new List<Passenger>();

            if (!ValidatePassenger(txtFirstName1.Text, txtLastName1.Text, txtCpr1.Text, txtDateOfBirth1.Text, txtGender1.Text, cmbSeat1.SelectedItem, out Passenger passenger1))
            {
                MessageBox.Show("Passenger 1 details are required and must be valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            passengers.Add(passenger1);

            if (!string.IsNullOrWhiteSpace(txtFirstName2.Text) || !string.IsNullOrWhiteSpace(txtLastName2.Text) || !string.IsNullOrWhiteSpace(txtCpr2.Text))
            {
                if (!ValidatePassenger(txtFirstName2.Text, txtLastName2.Text, txtCpr2.Text, txtDateOfBirth2.Text, txtGender2.Text, cmbSeat2.SelectedItem, out Passenger passenger2))
                {
                    MessageBox.Show("Please ensure Passenger 2 details are valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passengers.Add(passenger2);
            }

            decimal additionalServicesCost = CalculateAdditionalServicesCost(passengers.Count);
            decimal baseFare = passengers.Sum(p => p.Price);
            decimal vat = (baseFare + additionalServicesCost) * 0.10m;
            decimal grandTotal = baseFare + additionalServicesCost + vat;

            Payment paymentPage = new Payment(loggedInUserId, loggedInUserRoleId, passedFlightId, passengers, additionalServicesCost, baseFare, vat, grandTotal);
            paymentPage.ShowDialog();
            this.Hide();
        }
    }
}

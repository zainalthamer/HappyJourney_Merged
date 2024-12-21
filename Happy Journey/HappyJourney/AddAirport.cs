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
    public partial class AddAirport : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public AddAirport(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholder(txtName, "Name");
            SetupPlaceholder(txtIataCode, "IATA code");
            SetupPlaceholder(txtIcaoCode, "ICAO code");

            btnAdd.Click += btnAdd_Click;
        }

        private void AddAirport_Load(object sender, EventArgs e)
        {
            lblAddAirport.Left = (this.ClientSize.Width - lblAddAirport.Width) / 2;
            btnAdd.Left = (this.ClientSize.Width - btnAdd.Width) / 2;

            LoadCities();
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

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            ManageAirports manageAirports = new ManageAirports(loggedInUserId, loggedInUserRoleId);
            manageAirports.ShowDialog();
            this.Hide();
        }

        private void LoadCities()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT city_id, name FROM City";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbCities.DataSource = dt;
                        cmbCities.DisplayMember = "name";
                        cmbCities.ValueMember = "city_id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading cities: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int cityId;
            string airportName = txtName.Text.Trim();
            string iataCode = txtIataCode.Text.Trim();
            string icaoCode = txtIcaoCode.Text.Trim();

            if (cmbCities.SelectedValue == null ||
                airportName == "" || airportName == "" ||
                iataCode == "" || iataCode == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cityId = Convert.ToInt32(cmbCities.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Airport (city_id, name, iata_code, icao_code) " +
                                   "VALUES (@CityID, @Name, @IATACode, @ICAOCode)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CityID", cityId);
                        cmd.Parameters.AddWithValue("@Name", airportName);
                        cmd.Parameters.AddWithValue("@IATACode", iataCode);
                        cmd.Parameters.AddWithValue("@ICAOCode", icaoCode);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Airport added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the airport. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the airport: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            LoadCities();

            if (cmbCities.Items.Count > 0)
            {
                cmbCities.SelectedIndex = 0;
            }

            txtName.Clear();
            txtIataCode.Clear();
            txtIcaoCode.Clear();
        }
    }
}


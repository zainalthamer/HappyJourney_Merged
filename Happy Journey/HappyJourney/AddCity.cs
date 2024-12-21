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
    public partial class AddCity : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public AddCity(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholder(txtName, "Name");
            btnAdd.Click += btnAdd_Click;
        }

        private void AddCity_Load(object sender, EventArgs e)
        {
            lblAddCity.Left = (this.ClientSize.Width - lblAddCity.Width) / 2;
            btnAdd.Left = (this.ClientSize.Width - btnAdd.Width) / 2;

            LoadCountries();
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

        private void LoadCountries()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT country_id, name FROM Country";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbCountries.DataSource = dt;
                        cmbCountries.DisplayMember = "name"; 
                        cmbCountries.ValueMember = "country_id"; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading countries: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbCountries.SelectedValue == null || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please select a country and enter the city name.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cityName = txtName.Text.Trim();
            int countryId = Convert.ToInt32(cmbCountries.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO City (country_id, name) VALUES (@CountryID, @CityName)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CountryID", countryId);
                        cmd.Parameters.AddWithValue("@CityName", cityName);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("City added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the city. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the city: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            cmbCountries.SelectedIndex = -1;
            txtName.Clear();
        }
    }
}

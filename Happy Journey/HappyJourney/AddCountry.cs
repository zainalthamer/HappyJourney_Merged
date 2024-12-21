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
    public partial class AddCountry : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public AddCountry(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholder(txtName, "Name");
        }

        private void AddCountry_Load(object sender, EventArgs e)
        {
            lblAddCountry.Left = (this.ClientSize.Width - lblAddCountry.Width) / 2;
            txtName.Left = (this.ClientSize.Width - txtName.Width) / 2;
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
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter a valid country name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Country (name) VALUES (@CountryName)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CountryName", txtName.Text.Trim());

                        connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Country added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtName.Clear(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the country. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

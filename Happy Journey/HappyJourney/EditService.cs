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
    public partial class EditService : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedServiceId;

        public EditService(int userId, int roleId, int serviceId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedServiceId = serviceId;

            btnSaveChanges.Click += btnSaveChanges_Click;
            LoadServiceDetails();
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            lblEditService.Left = (this.ClientSize.Width - lblEditService.Width) / 2;
            btnSaveChanges.Left = (this.ClientSize.Width - btnSaveChanges.Width) / 2;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
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

        private void LoadServiceDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name, price FROM Service WHERE service_id = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", passedServiceId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                txtPrice.Text = reader["price"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading service details: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a valid service name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serviceName = txtName.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Service SET name = @Name, price = @Price WHERE service_id = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", serviceName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@ServiceID", passedServiceId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the service. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

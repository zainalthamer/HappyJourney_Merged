using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class AddUser : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public AddUser(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholder(txtFirstName, "First Name");
            SetupPlaceholder(txtLastName, "Last Name");
            SetupPlaceholder(txtDateOfBirth, "Date of Birth");
            SetupPlaceholder(txtNationality, "Nationality");
            SetupPlaceholder(txtPhone, "Phone");
            SetupPlaceholder(txtEmail, "Email Address");
            SetupPlaceholder(txtPassword, "Password");

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'happy_journeyDataSet3.UserRole' table. You can move, or remove it, as needed.
            this.userRoleTableAdapter.Fill(this.happy_journeyDataSet3.UserRole);
            lblAddUser.Left = (this.ClientSize.Width - lblAddUser.Width) / 2;

            this.userRoleTableAdapter.Fill(this.happy_journeyDataSet3.UserRole);
            lblAddUser.Left = (this.ClientSize.Width - lblAddUser.Width) / 2;
            btnAdd.Left = (this.ClientSize.Width - btnAdd.Width) / 2;
            cmbRole.SelectedIndex = -1;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtDateOfBirth.Text) || string.IsNullOrWhiteSpace(txtNationality.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO dbo.[User] (first_name, last_name, date_of_birth, nationality, phone, email, hashed_password, role_id, is_subscribed) VALUES (@FirstName, @LastName, @DOB, @Nationality, @Phone, @Email, @Password, @RoleId, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDateOfBirth.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim())); // Hash the password
                        cmd.Parameters.AddWithValue("@RoleId", cmbRole.SelectedValue);
                        cmd.Parameters.AddWithValue("@IsSubscribed", 0);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Convert byte to hex
                }

                return builder.ToString();
            }
        }

        private void ClearFields()
        {
            // Clear all text boxes
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDateOfBirth.Clear();
            txtNationality.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPassword.Clear();

            cmbRole.SelectedIndex = -1;

            SetupPlaceholder(txtFirstName, "First Name");
            SetupPlaceholder(txtLastName, "Last Name");
            SetupPlaceholder(txtDateOfBirth, "Date of Birth");
            SetupPlaceholder(txtNationality, "Nationality");
            SetupPlaceholder(txtPhone, "Phone");
            SetupPlaceholder(txtEmail, "Email Address");
            SetupPlaceholder(txtPassword, "Password");
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
            ManageUsers manageUser = new ManageUsers(loggedInUserId, loggedInUserRoleId);
            manageUser.ShowDialog();
            this.Hide();
        }
    }
}

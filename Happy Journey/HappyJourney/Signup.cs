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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();

            SetupPlaceholder(txtFirstName, "First Name");
            SetupPlaceholder(txtLastName, "Last Name");
            SetupPlaceholder(txtDateOfBirth, "Date of Birth");
            SetupPlaceholder(txtNationality, "Nationality");
            SetupPlaceholder(txtPhone, "Phone");
            SetupPlaceholder(txtEmail, "Email Address");
            SetupPlaceholder(txtPassword, "Password");
        }

        private void Signup_Load(object sender, EventArgs e)
        {

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

        private void lblLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnSignup_Click_1(object sender, EventArgs e)
        {
            // retrieve input 
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string dateOfBirth = txtDateOfBirth.Text.Trim();
            string nationality = txtNationality.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool isSubscribed = chkSubscribe.Checked;

            // Check for empty fields
            if (firstName == "First name" || lastName == "Last name" || dateOfBirth == "Date of birth" ||
                nationality == "Nationality" || phone == "Phone" || email == "Email address" ||
                password == "Password" ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(dateOfBirth) || string.IsNullOrWhiteSpace(nationality) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate inputs using Regex
            if (!Regex.IsMatch(firstName, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(lastName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First and Last names must contain only letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(dateOfBirth, out DateTime parsedDateOfBirth))
            {
                MessageBox.Show("Date of birth must be a valid date in the format YYYY-MM-DD.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(nationality, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nationality must contain only letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d{8,}$")) // At least 8 digits
            {
                MessageBox.Show("Phone number must contain only digits and be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email must be a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // hash the password
            string hashedPassword = HashPassword(password);

            // save the traveler to the database
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO [User] (first_name, last_name, date_of_birth, nationality, phone, email, hashed_password, role_id, is_subscribed) " +
                                   "VALUES (@FirstName, @LastName, @DateOfBirth, @Nationality, @Phone, @Email, @Password, @RoleId, @IsSubscribed)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(dateOfBirth));
                        command.Parameters.AddWithValue("@Nationality", nationality);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", hashedPassword); // Save the hashed password
                        command.Parameters.AddWithValue("@RoleId", 3); // Assign the traveler user role to the new user
                        command.Parameters.AddWithValue("@IsSubscribed", isSubscribed ? 1 : 0); // Save the subscription state (1 for true, 0 for false)

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Signup Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clearing text fields 
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDateOfBirth.Clear();
            txtNationality.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            chkSubscribe.Checked = false;
        }

        // hashing the traveler's password for security
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}

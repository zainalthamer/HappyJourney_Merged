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
using HappyJourney.services;

namespace HappyJourney
{
    public partial class Login : Form
    {
        public static int LoggedInUserId = -1; // the default value indicates that no user is logged in
        public static int LoggedInUserRoleId = -1;

        public Login()
        {
            InitializeComponent();

            PlaceholderService.SetupPlaceholder(txtBoxEmail, "Email");
            PlaceholderService.SetupPlaceholder(txtBoxPassword, "Password");
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void lblSignupLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string email = txtBoxEmail.Text.Trim();
            string password = txtBoxPassword.Text.Trim();
            string hashedPassword = HashPassword(password);

            string query = "SELECT user_id, role_id FROM [User] WHERE email = @Email AND hashed_password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue ("@Password", hashedPassword);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        LoggedInUserId = Convert.ToInt32(reader["user_id"]);
                        LoggedInUserRoleId = Convert.ToInt32(reader["role_id"]);

                        Home home = new Home(LoggedInUserId, LoggedInUserRoleId);
                        this.Hide();
                        home.ShowDialog();
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.");
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            LoggedInUserId = 1; 
            LoggedInUserRoleId = 1; 

            Home home = new Home(LoggedInUserId, LoggedInUserRoleId);
            this.Hide();
            home.ShowDialog();
            this.Close();
        }
    }
}

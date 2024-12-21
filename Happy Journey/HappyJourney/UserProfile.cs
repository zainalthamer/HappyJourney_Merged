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
    public partial class UserProfile : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedUserId;

        public UserProfile(int currentUserId, int roleId, int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            passedUserId = userId;
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadUserDetails();

            lblFullName.Left = (this.ClientSize.Width - lblFullName.Width) / 2;
            imgProfile.Left = (this.ClientSize.Width - imgProfile.Width) / 2;
            lblFullName.Anchor = AnchorStyles.Top;
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
            ManageUsers manageUsers = new ManageUsers(loggedInUserId, loggedInUserRoleId);
            manageUsers.ShowDialog();
            this.Hide();
        }

        private void LoadUserDetails()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT u.first_name, u.last_name, u.date_of_birth, u.nationality, u.phone, u.email, r.role_name FROM [User] u INNER JOIN UserRole r ON u.role_id = r.role_id WHERE u.user_id = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", passedUserId);

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string fullName = $"{reader["first_name"]} {reader["last_name"]}";
                            lblFullName.Text = fullName;

                            txtDateOfBirth.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("dd/MM/yyyy");
                            txtNationality.Text = reader["nationality"].ToString();
                            txtPhone.Text = reader["phone"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtRole.Text = reader["role_name"].ToString();
                        }

                        else
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

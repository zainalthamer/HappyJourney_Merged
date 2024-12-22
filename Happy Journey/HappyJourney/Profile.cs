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
using HappyJourney.entities;
using HappyJourney.observers;
using HappyJourney.singletons;

namespace HappyJourney
{
    public partial class Profile : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public Profile(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            SetupMenuStrip();

            User user = UserSession.Instance.CurrentUser;

            if (user != null)
            {
                labelName.Text = user.FullName;
                txtDob.Text = user.DateOfBirth;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtNationality.Text = user.Nationality;

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                // Query for flight details
                string query = @"
            SELECT role_name
            FROM UserRole
            WHERE role_id = @RoleId";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Load flight details
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                            txtRole.Text = cmd.ExecuteScalar().ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading role name: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UserObserver.Subscribe(() =>
            {
                User newUser = UserSession.Instance.CurrentUser;

                if (newUser != null)
                {
                    labelName.Text = newUser.FullName;
                    txtPhone.Text = newUser.Phone;
                }
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            UserSession.Instance.ClearSession();

            Signup signup = new Signup();
            signup.Show();
            Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

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

            this.mnuProfile = menuStrip;
            this.Controls.Add(menuStrip);
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
            MessageBox.Show("You are already on the Home page.");
        }
    }
}

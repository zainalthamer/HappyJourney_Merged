using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class Dashboard : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public Dashboard(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.Show();
            this.Close();
        }

        private void composeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.Show();
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.Show();
            this.Close();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.Show();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnManageUserAccounts_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers(loggedInUserId, loggedInUserRoleId);
            manageUsers.ShowDialog();
            this.Hide();
        }

        private void btnManageUserRoles_Click(object sender, EventArgs e)
        {
            ManageRoles manageRoles = new ManageRoles(loggedInUserId, loggedInUserRoleId);
            manageRoles.ShowDialog();
            this.Hide();
        }

        private void btnManageFlights_Click(object sender, EventArgs e)
        {
            ManageFlights manageFlights = new ManageFlights(loggedInUserId, loggedInUserRoleId);
            manageFlights.ShowDialog();
            this.Hide();
        }

        private void btnManageCountries_Click(object sender, EventArgs e)
        {
            ManageCountries manageCountries = new ManageCountries(loggedInUserId, loggedInUserRoleId);
            manageCountries.ShowDialog();
            this.Hide();
        }

        private void btnManageCities_Click(object sender, EventArgs e)
        {
            ManageCities manageCities = new ManageCities(loggedInUserId, loggedInUserRoleId);
            manageCities.ShowDialog();
            this.Hide();
        }

        private void btnManageAirports_Click(object sender, EventArgs e)
        {
            ManageAirports manageAirports = new ManageAirports(loggedInUserId, loggedInUserRoleId);
            manageAirports.ShowDialog();
            this.Hide();
        }

        private void btnManageServices_Click(object sender, EventArgs e)
        {
            ManageServices manageServices = new ManageServices(loggedInUserId, loggedInUserRoleId);
            manageServices.ShowDialog();
            this.Hide();
        }

        private void btnManageBookings_Click(object sender, EventArgs e)
        {
            ManageBookings manageBookings = new ManageBookings(loggedInUserId, loggedInUserRoleId);
            manageBookings.ShowDialog();
            this.Hide();
        }

        private void btnManageBackupLogs_Click(object sender, EventArgs e)
        {
            ManageDatabaseBackups manageDatabaseBackups = new ManageDatabaseBackups(loggedInUserId, loggedInUserRoleId);
            manageDatabaseBackups.ShowDialog();
            this.Hide();
        }

        private void btnManageReports_Click(object sender, EventArgs e)
        {
            ManageReports manageReports = new ManageReports(loggedInUserId, loggedInUserRoleId);
            manageReports.ShowDialog();
            this.Hide();
        }
    }
}

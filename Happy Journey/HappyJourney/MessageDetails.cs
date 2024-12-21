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
    public partial class MessageDetails : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        private string senderEmail;
        private string messageContent;
        private string messageTimestamp;

        public MessageDetails(int userId, int roleId, string senderEmail, string content, string timestamp)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            this.senderEmail = senderEmail;
            messageContent = content;
            messageTimestamp = timestamp;
            SetupMenuStrip();
            LoadMessageDetails();
        }

        private void imgBackArrow_Click(object sender, EventArgs e)
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.Show();
            this.Hide();
        }

        private void MessageDetails_Load(object sender, EventArgs e)
        {

        }

        private void LoadMessageDetails()
        {
            lblSender.Text = $"From: {senderEmail}";
            lblMessageContent.Text = messageContent;
            lblDate.Text = $"Date: {messageTimestamp}";
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

            this.mnuMessageDetails = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void NavigateToInbox()
        {
            Inbox inbox = new Inbox(loggedInUserId, loggedInUserRoleId);
            inbox.ShowDialog();
            this.Hide();

        }

        private void NavigateToCompose()
        {
            Compose compose = new Compose(loggedInUserId, loggedInUserRoleId);
            compose.ShowDialog();
            this.Hide();
        }

        private void NavigateToProfile()
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.ShowDialog();
            this.Hide();
        }

        private void NavigateToDashboard()
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.ShowDialog();
            this.Hide();
        }

        private void NavigateToBookings()
        {
            Bookings bookings = new Bookings(loggedInUserId, loggedInUserRoleId);
            bookings.ShowDialog();
            this.Hide();
        }

        private void NavigateToHome()
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
            this.Hide();
        }
    }
}

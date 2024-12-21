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
    public partial class Inbox : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public Inbox(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            SetupMenuStrip();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            LoadMessagesForUser();
            dataGridInbox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInbox.ReadOnly = true;
            dataGridInbox.CellDoubleClick += DataGridInbox_CellDoubleClick;
        }

        private void LoadMessagesForUser()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = @"SELECT U.email AS Sender, M.content AS Message, M.date AS Timestamp FROM Message M INNER JOIN [User] U ON M.sender_id = U.user_id WHERE M.receiver_id = @ReceiverId;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ReceiverId", loggedInUserId);

                DataTable messagesTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(messagesTable);

                    dataGridInbox.DataSource = messagesTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading messages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            this.mnuInbox = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void NavigateToInbox()
        {
            MessageBox.Show("You are already on the Inbox page.");

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

        private void DataGridInbox_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridInbox.Rows[e.RowIndex];

                string senderEmail = selectedRow.Cells["Sender"].Value.ToString();
                string messageContent = selectedRow.Cells["Message"].Value.ToString();
                string timestamp = selectedRow.Cells["Timestamp"].Value.ToString();

                MessageDetails messageDetailsForm = new MessageDetails(
                    loggedInUserId,
                    loggedInUserRoleId,
                    senderEmail,
                    messageContent,
                    timestamp
                );
                messageDetailsForm.ShowDialog();
            }
        }
    }
}

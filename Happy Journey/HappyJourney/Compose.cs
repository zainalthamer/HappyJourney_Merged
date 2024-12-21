using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HappyJourney
{
    public partial class Compose : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public Compose(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            // Setup placeholders
            SetupPlaceholder(txtRecepient, "To:");
            SetupPlaceholder(txtMessageContent, "Message");
        }

        private void Compose_Load(object sender, EventArgs e)
        {
            if (loggedInUserRoleId != 1)
            {
                chkBroadcast.Visible = false;
            }
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecepient.Text) && !chkBroadcast.Checked)
            {
                MessageBox.Show("Please specify a recipient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessageContent.Text))
            {
                MessageBox.Show("Message content cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string messageContent = txtMessageContent.Text;
            DateTime currentDate = DateTime.Now;

            try
            {
                if (chkBroadcast.Checked && loggedInUserRoleId == 1)
                {
                    BroadcastMessage(messageContent, currentDate);
                }
                else
                {
                    SendMessage(messageContent, currentDate, txtRecepient.Text);
                }

                MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BroadcastMessage(string messageContent, DateTime messageDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string fetchUsersQuery = "SELECT user_id FROM [User] WHERE user_id != @SenderId";
                SqlCommand fetchCommand = new SqlCommand(fetchUsersQuery, connection);
                fetchCommand.Parameters.AddWithValue("@SenderId", loggedInUserId);

                SqlDataAdapter adapter = new SqlDataAdapter(fetchCommand);
                DataTable userTable = new DataTable();
                adapter.Fill(userTable);

                foreach (DataRow row in userTable.Rows)
                {
                    int recipientId = Convert.ToInt32(row["user_id"]);
                    InsertMessage(connection, messageContent, messageDate, recipientId);
                }
            }
        }

        private void SendMessage(string messageContent, DateTime messageDate, string recipientEmail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string fetchRecepientQuery = "SELECT user_id FROM [User] WHERE email = @Email";
                SqlCommand fetchCommand = new SqlCommand(fetchRecepientQuery, connection);
                fetchCommand.Parameters.AddWithValue("@Email", recipientEmail);

                object recipientIdObj = fetchCommand.ExecuteScalar();

                if (recipientIdObj != null)
                {
                    int recipientId = Convert.ToInt32(recipientIdObj);
                    InsertMessage(connection, messageContent, messageDate, recipientId);
                }
                else
                {
                    throw new Exception("Recipient email not found.");
                }
            }
        }

        private void InsertMessage(SqlConnection connection, string content, DateTime date, int receiverId)
        {
            string insertMessageQuery = "INSERT INTO Message (content, sender_id, receiver_id, date) " +
                                        "VALUES (@Content, @SenderId, @ReceiverId, @Date)";

            SqlCommand insertCommand = new SqlCommand(insertMessageQuery, connection);
            insertCommand.Parameters.AddWithValue("@Content", content);
            insertCommand.Parameters.AddWithValue("@SenderId", loggedInUserId);
            insertCommand.Parameters.AddWithValue("@ReceiverId", receiverId);
            insertCommand.Parameters.AddWithValue("@Date", date);

            insertCommand.ExecuteNonQuery();
        }
    }
}

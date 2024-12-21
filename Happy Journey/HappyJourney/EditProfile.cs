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
    public partial class EditProfile : Form
    {
        public EditProfile()
        {
            InitializeComponent();

            User user = UserSession.Instance.CurrentUser;

            if (user != null)
            {
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtPhone.Text = user.Phone;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = @"UPDATE [User] 
                   SET first_name = @FirstName,
                       last_name = @LastName, 
                       phone = @Phone
                   WHERE user_id = @UserId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserId", UserSession.Instance.CurrentUser.UserId);

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        // Update the UserSession data
                        UserSession.Instance.CurrentUser.FirstName = txtFirstName.Text.Trim();
                        UserSession.Instance.CurrentUser.LastName = txtLastName.Text.Trim();
                        UserSession.Instance.CurrentUser.Phone = txtPhone.Text.Trim();

                        UserObserver.Publish();

                        MessageBox.Show("Profile updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
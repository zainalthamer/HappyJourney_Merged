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
using HappyJourney.services;

namespace HappyJourney
{
    public partial class ManageUsers : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;

        public ManageUsers(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            PlaceholderService.SetupPlaceholder(txtSearchBar, "Enter User ID");
            SetupDataGridView();

            dataGridUsers.CellClick += dataGridUsers_CellClick;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.Show();
            this.Close();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.Show();
            this.Close();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(loggedInUserId, loggedInUserRoleId);
            profile.Show();
            this.Close();
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(loggedInUserId, loggedInUserRoleId);
            addUser.ShowDialog();
            this.Hide();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'happy_journeyDataSet2.User' table. You can move, or remove it, as needed.
            this.userTableAdapter1.Fill(this.happy_journeyDataSet2.User);
            // TODO: This line of code loads data into the 'happy_journeyDataSet1.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.happy_journeyDataSet1.User);

            userBindingSource.DataSource = happy_journeyDataSet1.User;
            dataGridUsers.DataSource = userBindingSource;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                userBindingSource.Filter = $"CONVERT(user_id, 'System.String') LIKE '%{searchQuery}%'";
            }
            else
            {
                userBindingSource.RemoveFilter();
            }
        }

        private void SetupDataGridView()
        {
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "EditColumn";       
            editButton.HeaderText = "Edit User"; 
            editButton.Text = "Edit";            
            editButton.UseColumnTextForButtonValue = true;
            dataGridUsers.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "DeleteColumn";      
            deleteButton.HeaderText = "Delete User";  
            deleteButton.Text = "Delete";            
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridUsers.Columns.Add(deleteButton);

            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.RowHeadersVisible = false;

            dataGridUsers.CellPainting += dataGridUsers_CellPainting;
        }

        private void dataGridUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridUsers.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, "Edit", dataGridUsers.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }

                else if (dataGridUsers.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridUsers.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ensuring it is not the header row
            {
                int userId = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells["user_id"].Value);

                if (dataGridUsers.Columns[e.ColumnIndex].Name == "user_id")
                {
                    UserProfile userProfile = new UserProfile(loggedInUserId, loggedInUserRoleId, userId);
                    userProfile.ShowDialog();
                    this.Hide();
                }

                if (dataGridUsers.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    EditUser editUser = new EditUser(loggedInUserId, loggedInUserRoleId, userId);
                    editUser.ShowDialog();
                    this.Hide();
                }

                if (dataGridUsers.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete user {userId}?", "Confirm Deletion", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if(DeleteUserFromDatabase(userId))
                        {
                            dataGridUsers.Rows.RemoveAt(e.RowIndex);

                            MessageBox.Show($"User ID {userId} has been deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private bool DeleteUserFromDatabase(int userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM dbo.[User] WHERE user_id = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


    }
}


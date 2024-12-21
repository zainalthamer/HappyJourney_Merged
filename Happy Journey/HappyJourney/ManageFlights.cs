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
    public partial class ManageFlights : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private DataTable flightTable = new DataTable();

        public ManageFlights(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter Flight ID");
            SetupDataGridView();

            dataGridFlights.CellClick += dataGridFlights_CellClick;
        }

        private void ManageFlights_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'happy_journeyDataSet6.Flight' table. You can move, or remove it, as needed.
            this.flightTableAdapter.Fill(this.happy_journeyDataSet6.Flight);

            LoadFlightData();
        }

        private void LoadFlightData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT flight_id FROM dbo.Flight";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        flightTable.Clear(); 
                        adapter.Fill(flightTable);
                        dataGridFlights.DataSource = flightTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading flights: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupPlaceholders(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void SetupDataGridView()
        {

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "EditColumn";
            editButton.HeaderText = "Edit Flight";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            dataGridFlights.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "DeleteColumn";
            deleteButton.HeaderText = "Delete Flight";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridFlights.Columns.Add(deleteButton);

            dataGridFlights.AllowUserToAddRows = false;
            dataGridFlights.RowHeadersVisible = false;

            dataGridFlights.CellPainting += dataGridUsers_CellPainting;
        }

        private void dataGridUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridFlights.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, "Edit", dataGridFlights.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }

                else if (dataGridFlights.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridFlights.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string flightIdInput = txtSearchBar.Text.Trim();

            if (string.IsNullOrWhiteSpace(flightIdInput) || flightIdInput == "Enter Flight ID")
            {
                MessageBox.Show("Please enter a valid Flight ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flightId;
            if (!int.TryParse(flightIdInput, out flightId))
            {
                MessageBox.Show("Flight ID must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT flight_id FROM dbo.Flight WHERE flight_id = @flightId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@flightId", flightId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable filteredTable = new DataTable();
                            adapter.Fill(filteredTable);

                            if (filteredTable.Rows.Count > 0)
                            {
                                dataGridFlights.DataSource = filteredTable;
                            }
                            else
                            {
                                MessageBox.Show($"No flight found with ID: {flightId}.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for flight: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            AddFlight addFlight = new AddFlight(loggedInUserId, loggedInUserRoleId);
            addFlight.ShowDialog();
            this.Hide();
        }

        private void dataGridFlights_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int flightId = Convert.ToInt32(dataGridFlights.Rows[e.RowIndex].Cells["flight_id"].Value);

            if (dataGridFlights.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                EditFlight editFlight = new EditFlight(loggedInUserId, loggedInUserRoleId, flightId);
                editFlight.ShowDialog();
                this.Hide();
            }
            else if (dataGridFlights.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show("Are you sure you want to delete this flight?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteFlight(flightId);
                    LoadFlightData();
                }
            }
            else if (dataGridFlights.Columns[e.ColumnIndex].HeaderText == "Flight ID")
            {
                FlightDetail flightDetail = new FlightDetail(loggedInUserId, loggedInUserRoleId, flightId);
                flightDetail.ShowDialog();
                this.Hide();
            }
        }

        private void DeleteFlight(int flightId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"IF NOT EXISTS (SELECT 1 FROM dbo.Booking WHERE flight_id = @flightId) DELETE FROM dbo.Flight WHERE flight_id = @flightId; ELSE THROW 50000, 'Cannot delete flight. Related bookings exist.', 1;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@flightId", flightId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Flight deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadFlightData(); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(loggedInUserId, loggedInUserRoleId);
            dashboard.ShowDialog();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home(loggedInUserId, loggedInUserRoleId);
            home.ShowDialog();
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
    }
}
    

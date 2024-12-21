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
    public partial class ManageAirports : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource airportBindingSource = new BindingSource();

        public ManageAirports(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter airport name");
        }

        private void ManageAirports_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
            dataGridAirports.CellContentClick += dataGridAirports_CellContentClick;
            btnSearch.Click += btnSearch_Click;
            btnAddAirport.Click += btnAddAirport_Click;
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

        private void SetupGridView()
        {
            dataGridAirports.Columns.Clear();

            DataGridViewTextBoxColumn cityIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "city_id",
                HeaderText = "City ID",
                DataPropertyName = "city_id",
                ReadOnly = true
            };
            dataGridAirports.Columns.Add(cityIDColumn);

            DataGridViewTextBoxColumn airportIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "airport_id",
                HeaderText = "Airport ID",
                DataPropertyName = "airport_id",
                ReadOnly = true
            };
            dataGridAirports.Columns.Add(airportIDColumn);

            DataGridViewTextBoxColumn airportNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Airport Name",
                DataPropertyName = "name",
                ReadOnly = true
            };
            dataGridAirports.Columns.Add(airportNameColumn);

            DataGridViewTextBoxColumn icaoCodeColumn = new DataGridViewTextBoxColumn
            {
                Name = "icao_code",
                HeaderText = "ICAO Code",
                DataPropertyName = "icao_code",
                ReadOnly = true
            };
            dataGridAirports.Columns.Add(icaoCodeColumn);

            DataGridViewTextBoxColumn iataCodeColumn = new DataGridViewTextBoxColumn
            {
                Name = "iata_code",
                HeaderText = "IATA Code",
                DataPropertyName = "iata_code",
                ReadOnly = true
            };
            dataGridAirports.Columns.Add(iataCodeColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete Airport",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridAirports.Columns.Add(deleteButtonColumn);

            dataGridAirports.AllowUserToAddRows = false;
            dataGridAirports.RowHeadersVisible = false;

            dataGridAirports.CellPainting += dataGridAirports_CellPainting;
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT city_id, airport_id, name, icao_code, iata_code FROM Airport";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    airportBindingSource.DataSource = dt;
                    dataGridAirports.DataSource = airportBindingSource;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Enter airport name")
            {
                airportBindingSource.Filter = $"name LIKE '%{searchQuery}%'";
            }
            else
            {
                airportBindingSource.RemoveFilter();
            }
        }

        private void dataGridAirports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridAirports.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                string airportID = dataGridAirports.Rows[e.RowIndex].Cells["airport_id"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this airport?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteAirport(airportID);
                    LoadData(); // Refresh the grid after deletion
                }
            }
        }

        private void DeleteAirport(string airportID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Airport WHERE airport_id = @AirportID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AirportID", airportID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Airport deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridAirports_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridAirports.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridAirports.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void btnAddAirport_Click(object sender, EventArgs e)
        {
            AddAirport addAirport = new AddAirport(loggedInUserId, loggedInUserRoleId);
            addAirport.ShowDialog();
            this.Hide();
        }
    }
}


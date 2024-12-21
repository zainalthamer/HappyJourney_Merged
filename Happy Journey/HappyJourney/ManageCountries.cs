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
    public partial class ManageCountries : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private DataTable countriesTable;
        private BindingSource userBindingSource = new BindingSource();

        public ManageCountries(int userId, int roleId)
        {
            InitializeComponent();

            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter country name");
        }

        private void ManageCountries_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
            dataGridCountries.CellContentClick += dataGridCountries_CellContentClick;
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

        private void SetupGridView()
        {
            dataGridCountries.Columns.Clear();

            DataGridViewTextBoxColumn countryIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "country_id",
                HeaderText = "Country ID",
                DataPropertyName = "country_id",
                ReadOnly = true
            };
            dataGridCountries.Columns.Add(countryIDColumn);

            DataGridViewTextBoxColumn countryNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Country Name",
                DataPropertyName = "name",
                ReadOnly = true
            };
            dataGridCountries.Columns.Add(countryNameColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete City",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridCountries.Columns.Add(deleteButtonColumn);

            dataGridCountries.AllowUserToAddRows = false;
            dataGridCountries.RowHeadersVisible = false;

            dataGridCountries.CellPainting += dataGridCountries_CellPainting;
        }

        private void dataGridCountries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridCountries.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridCountries.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT country_id, name FROM Country";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    userBindingSource.DataSource = dt;

                    dataGridCountries.DataSource = userBindingSource;
                }
            }
        }

        private void dataGridCountries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCountries.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                string countryID = dataGridCountries.Rows[e.RowIndex].Cells["country_id"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this country?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteCountry(countryID);

                    LoadData();
                }
            }
        }

        private void DeleteCountry(string countryID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Country WHERE country_id = @CountryID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CountryID", countryID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Country deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                userBindingSource.Filter = $"name LIKE '%{searchQuery}%'";
            }
            else
            {
                userBindingSource.RemoveFilter();
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            AddCountry addCountry = new AddCountry(loggedInUserId, loggedInUserRoleId);
            addCountry.ShowDialog();
            this.Hide();
        }
    }
}

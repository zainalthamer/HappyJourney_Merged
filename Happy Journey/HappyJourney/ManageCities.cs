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
    public partial class ManageCities : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource cityBindingSource = new BindingSource();

        public ManageCities(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter city name");
        }

        private void ManageCities_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
            dataGridCities.CellContentClick += dataGridCities_CellContentClick;
            btnSearch.Click += btnSearch_Click;
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
            dataGridCities.Columns.Clear();

            DataGridViewTextBoxColumn cityIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "city_id",
                HeaderText = "City ID",
                DataPropertyName = "city_id",
                ReadOnly = true
            };
            dataGridCities.Columns.Add(cityIDColumn);

            DataGridViewTextBoxColumn countryIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "country_id",
                HeaderText = "Country ID",
                DataPropertyName = "country_id",
                ReadOnly = true
            };
            dataGridCities.Columns.Add(countryIDColumn);

            DataGridViewTextBoxColumn cityNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "City Name",
                DataPropertyName = "name",
                ReadOnly = true
            };
            dataGridCities.Columns.Add(cityNameColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete City",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridCities.Columns.Add(deleteButtonColumn);

            dataGridCities.AllowUserToAddRows = false;
            dataGridCities.RowHeadersVisible = false;

            dataGridCities.CellPainting += dataGridCities_CellPainting;
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT city_id, country_id, name FROM City";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cityBindingSource.DataSource = dt;
                    dataGridCities.DataSource = cityBindingSource;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Enter city name")
            {
                cityBindingSource.Filter = $"name LIKE '%{searchQuery}%'";
            }
            else
            {
                cityBindingSource.RemoveFilter();
            }
        }

        private void dataGridCities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCities.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                string cityID = dataGridCities.Rows[e.RowIndex].Cells["city_id"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this city?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteCity(cityID);
                    LoadData(); // Refresh the grid after deletion
                }
            }
        }

        private void DeleteCity(string cityID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM City WHERE city_id = @CityID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("City deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridCities_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridCities.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridCities.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void btnAddCities_Click(object sender, EventArgs e)
        {
            AddCity addCity = new AddCity(loggedInUserId, loggedInUserRoleId);
            addCity.ShowDialog();
            this.Hide();
        }
    }
}

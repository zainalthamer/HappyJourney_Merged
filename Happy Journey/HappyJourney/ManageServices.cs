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
    public partial class ManageServices : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource serviceBindingSource = new BindingSource();

        public ManageServices(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter service name");
        }

        private void ManageServices_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
            dataGridServices.CellContentClick += dataGridServices_CellContentClick;
            btnSearch.Click += btnSearch_Click;
            btnAddServices.Click += btnAddServices_Click;
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
            dataGridServices.Columns.Clear();

            DataGridViewTextBoxColumn serviceIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "service_id",
                HeaderText = "Service ID",
                DataPropertyName = "service_id",
                ReadOnly = true
            };
            dataGridServices.Columns.Add(serviceIDColumn);

            DataGridViewTextBoxColumn serviceNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Service Name",
                DataPropertyName = "name",
                ReadOnly = true
            };
            dataGridServices.Columns.Add(serviceNameColumn);

            DataGridViewTextBoxColumn servicePriceColumn = new DataGridViewTextBoxColumn
            {
                Name = "price",
                HeaderText = "Service Price",
                DataPropertyName = "price",
                ReadOnly = true
            };
            dataGridServices.Columns.Add(servicePriceColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit Service",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridServices.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete Service",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridServices.Columns.Add(deleteButtonColumn);

            dataGridServices.AllowUserToAddRows = false;
            dataGridServices.RowHeadersVisible = false;

            dataGridServices.CellPainting += dataGridServices_CellPainting;
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT service_id, name, price FROM Service";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    serviceBindingSource.DataSource = dt;
                    dataGridServices.DataSource = serviceBindingSource;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Enter service name")
            {
                serviceBindingSource.Filter = $"name LIKE '%{searchQuery}%'";
            }
            else
            {
                serviceBindingSource.RemoveFilter();
            }
        }

        private void dataGridServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string serviceID = dataGridServices.Rows[e.RowIndex].Cells["service_id"].Value.ToString();

                if (dataGridServices.Columns[e.ColumnIndex].Name == "Edit")
                {
                    EditService editService = new EditService(loggedInUserId, loggedInUserRoleId, Convert.ToInt32(serviceID));
                    editService.ShowDialog();
                    LoadData();
                }
                else if (dataGridServices.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this service?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteService(serviceID);
                        LoadData();
                    }
                }
            }
        }

        private void DeleteService(string serviceID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Service WHERE service_id = @ServiceID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridServices_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridServices.Columns[e.ColumnIndex].Name == "Edit")
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, "Edit", dataGridServices.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }

                else if (dataGridServices.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridServices.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }

        private void btnAddServices_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService(loggedInUserId, loggedInUserRoleId);
            addService.ShowDialog();
            LoadData();
        }
    }
}

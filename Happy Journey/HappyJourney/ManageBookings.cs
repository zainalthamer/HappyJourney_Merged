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
    public partial class ManageBookings : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private BindingSource bookingBindingSource = new BindingSource();

        public ManageBookings(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;

            SetupPlaceholders(txtSearchBar, "Enter booking ID");
        }

        private void ManageBookings_Load(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
            dataGridBookings.CellContentClick += dataGridBookings_CellContentClick;
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
            dataGridBookings.Columns.Clear();

            DataGridViewTextBoxColumn bookingIDColumn = new DataGridViewTextBoxColumn
            {
                Name = "booking_id",
                HeaderText = "Booking ID",
                DataPropertyName = "booking_id",
                ReadOnly = true
            };
            dataGridBookings.Columns.Add(bookingIDColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit Booking",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridBookings.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete Booking",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridBookings.Columns.Add(deleteButtonColumn);

            dataGridBookings.AllowUserToAddRows = false;
            dataGridBookings.RowHeadersVisible = false;

            dataGridBookings.CellPainting += dataGridBookings_CellPainting;
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT booking_id FROM Booking";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bookingBindingSource.DataSource = dt;
                    dataGridBookings.DataSource = bookingBindingSource;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Enter booking ID")
            {
                if (int.TryParse(searchQuery, out int bookingID))
                {
                    bookingBindingSource.Filter = $"booking_id = {bookingID}";
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric Booking ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                bookingBindingSource.RemoveFilter();
            }
        }

        private void dataGridBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string bookingID = dataGridBookings.Rows[e.RowIndex].Cells["booking_id"].Value.ToString();

                if (dataGridBookings.Columns[e.ColumnIndex].Name == "Edit")
                {
                    EditBooking editBooking = new EditBooking(loggedInUserId, loggedInUserRoleId, Convert.ToInt32(bookingID));
                    editBooking.ShowDialog();
                    LoadData();
                }
                else if (dataGridBookings.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this booking?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteBooking(bookingID);
                        LoadData();
                    }
                }
            }
        }

        private void DeleteBooking(string bookingID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Booking WHERE booking_id = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridBookings_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridBookings.Columns[e.ColumnIndex].Name == "Edit")
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, "Edit", dataGridBookings.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }

                else if (dataGridBookings.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);
                    using (Brush brush = new SolidBrush(Color.IndianRed))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridBookings.Font, e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    e.Handled = true;
                }
            }
        }
    }
}

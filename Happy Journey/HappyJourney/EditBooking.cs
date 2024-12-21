using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class EditBooking : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int bookingId;

        public EditBooking(int userId, int roleId, int selectedBookingId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
            bookingId = selectedBookingId;
        }

        private void EditBooking_Load(object sender, EventArgs e)
        {
        }
    }
}

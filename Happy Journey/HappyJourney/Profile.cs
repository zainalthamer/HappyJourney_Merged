using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyJourney
{
    public partial class Profile : Form
    {
        private int loggedInUserId;
        private int loggedInUserRoleId;
        private int passedUserId;

        public Profile(int userId, int roleId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            loggedInUserRoleId = roleId;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
    }
}

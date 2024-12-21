using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyJourney.entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public bool IsSubscribed { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}

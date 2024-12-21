using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyJourney
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int BookingId { get; set; }
        public string SeatCode { get; set; }
        public string CPR { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
    }
}


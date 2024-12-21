using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyJourney.entities;
using HappyJourney.observers;

namespace HappyJourney.singletons
{
    public class UserSession
    {
        private static UserSession instance;
        public User CurrentUser { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSession();
                }
                return instance;
            }
        }

        public void Initialize(string userId, string email, string firstName, string lastName,
            string nationality, string dateOfBirth, string phone, string roleId, string isSubscribed)
        {
            CurrentUser = new User
            {
                UserId = Convert.ToInt32(userId),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality,
                DateOfBirth = dateOfBirth,
                Phone = phone,
                RoleId = int.Parse(roleId),
                IsSubscribed = isSubscribed != "0"
            };
        }

        public void ClearSession()
        {
            CurrentUser = null;
            UserObserver.Publish();
        }
    }
}

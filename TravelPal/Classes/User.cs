using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }

        public List<Travel>? Travels { get; set; }

        public User(string username, string password, string location)
        {
            this.Username = username;
            this.Password = password;
            this.Location = location;
        }
    }
}

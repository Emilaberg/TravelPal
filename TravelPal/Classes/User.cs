using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Classes
{
    internal class User : IUser
    {
        public int Id { get; } = UserManager.CreateId();
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public List<Travel>? Travels { get; set; }

        public User(string username, string password, Country location)
        {
            this.Username = username;
            this.Password = password;
            this.Location = location;
        }

        public string GetInfo()
        {
            return $"Username {Username} Password: {Password} Location: {Location}";
        }
    }
}

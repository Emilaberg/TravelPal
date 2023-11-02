using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Classes
{
    internal class Admin : IUser
    {
        public int Id { get; } = UserManager.CreateId();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }

        public Admin(string username, string password, string location)
        {
            this.Username = username;
            this.Password = password;
            this.Location = location;
        }

        public string GetInfo()
        {
            return $"Username {Username} Password: {Password}";
        }
    }
}

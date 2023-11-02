using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Enums;
namespace TravelPal.Classes
{
    internal class Admin : IUser
    {
        public int Id { get; } = UserManager.CreateId();
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public Admin(string username, string password, Country location)
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

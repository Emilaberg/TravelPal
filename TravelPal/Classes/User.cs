using System.Collections.Generic;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Classes
{
    internal class User : IUser
    {
        public int Id { get; } = UserManager.CreateId();
        public string Username { get; set; }
        public string Password { get; set; }
        public object Location { get; set; }
        public bool FromEu { get; set; }

        public List<Travel>? Travels { get; set; }



        public string GetInfo()
        {
            return $"Username {Username} Password: {Password} Location: {Location}";
        }
    }
}

using TravelPal.Interfaces;
using TravelPal.Managers;
namespace TravelPal.Classes
{
    internal class Admin : IUser
    {
        public int Id { get; } = UserManager.CreateId();
        public string Username { get; set; }
        public string Password { get; set; }
        public object Location { get; set; }


        public string GetInfo()
        {
            return $"Username {Username} Password: {Password}";
        }
    }
}

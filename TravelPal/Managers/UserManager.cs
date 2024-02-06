using System.Collections.Generic;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        private static int id;
        public static List<IUser>? Users { get; set; } = new()
        {
            new User()
            {
                Username = "user",
                FromEu = true,
                Location = Enums.EuropeanCountry.Finland,
                Password = "password",

            },
            new Admin()
            {
                Username = "admin",
                Password = "password",
                Location = Enums.Country.Australia,
            }
        };
        public static IUser? SignedInUser { get; set; }

        public static bool AddUser(string username, string password, object location)
        {
            //skapar en ny användare
            User newUser = new()
            {
                Username = username,
                Password = password,
                Location = location,
                FromEu = location.GetType().Equals(typeof(EuropeanCountry))//jag kollar om typen av location (GetType) är lika med (Equals) europeanCountry (typeOf()), om det är det sätter jag FromEu till true, annars false
            };

            Users!.Add(newUser);
            //sätter den nya användaren till signedInUser
            SignedInUser = newUser;
            return true;

        }

        public static int CreateId()
        {
            return ++id;
        }

    }
}

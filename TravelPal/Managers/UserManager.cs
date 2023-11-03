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
                Username = "Emil",
                FromEu = true,
                Location = Enums.EuropeanCountry.Finland,
                Password = "123",

            },
            new User()
            {
                Username = "Ella",
                FromEu = false,
                Location = Enums.Country.Chile,
                Password = "123",
            },
            new User()
            {
                Username = "ahmed",
                FromEu = false,
                Location = Enums.Country.Canada,
                Password = "00"
            },
            new Admin()
            {
                Username = "admin",
                Password = "0",
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

        public static void RemoveUser(IUser user)
        {

        }

        public static bool UpdateUsername(IUser user, string newUsername)
        {
            //return true if successfull
            return false;
        }

        //Behövs ej, GÖRS I VALIDATECONTROLLER
        private static bool ValidateUsername(string username)
        {
            //return true if successfull
            return false;
        }

        //Behövs ej, GÖRS I CODE BEHINDEN PÅ ANTINGEN LOGIN ELLER REGISTER WINDOW. VIEWCONTROLLERN SERVAR DE KORREKTA SIDORNA OM ALLT ALL VALIDERING ÄR GODKÄND.
        public static bool SignInUser(string username, string password)
        {
            //return true if successfull
            return false;
        }

        public static int CreateId()
        {
            return id++;
        }

    }
}

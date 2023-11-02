using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        private static int id;
        public static List<IUser>? Users { get; set; } = new()
        {
            new User("Emil", "123", "sweden"),
            new User("Ella", "123", "Sweden"),
            new User("ahmed", "00", "afganistan"),
            new Admin("admin", "0", "usbeck")
        };
        public static IUser? SignedInUser { get; set; } 

        public static bool AddUser(string username, string password, string location)
        {
            //skapar en ny användare
            User newUser = new(username, password, location);
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

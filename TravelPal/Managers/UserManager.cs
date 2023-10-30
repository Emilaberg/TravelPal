using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        public static List<IUser>? Users { get; set; }
        public static IUser? SignedInUser { get; set; }

        public static bool AddUser(IUser user)
        {
            //return true if successfull
            return false;
        }

        public static void RemoveUser(IUser user)
        {

        }

        public static bool UpdateUsername(IUser user, string newUsername)
        {
            //return true if successfull
            return false;
        }

        private static bool ValidateUsername(string username)
        {
            //return true if successfull
            return false;
        }

        public static bool SignInUser(string username, string password)
        {
            //return true if successfull
            return false;
        }

    }
}

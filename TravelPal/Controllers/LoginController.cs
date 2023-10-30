using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Controllers
{
    internal class LoginController
    {


        public bool ValidateLogin(string username, string password)
        {
            //om username och password är korrekt skrivna, kör loginUser()
            return false;
        }

        public void LoginUser(IUser user) 
        {
            //hämta

        }
    }
}

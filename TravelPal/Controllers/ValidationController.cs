using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Classes;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Controllers
{
    public static class ValidationController
    {

        //Validates the login information
        public static bool ValidateLogin(string username, string password)
        {
            //om username och password är korrekt skrivna, kör loginUser()
            if (username == "" && password == "") //Om man inte skrivit in nånting alls
            {
                MessageBox.Show("you need to type a username and a password", "Alert");
                return false;
            }
            else if (username == "" && password != "") //om man inte skrivit in ett username
            {
                MessageBox.Show("you need to type a username", "Alert");
                return false;
            }
            else if (username != "" && password == "") // om man inte skrivit in ett password 
            {
                MessageBox.Show("you need to type a password", "Alert");
                return false;
            }
            else
            {
                foreach (IUser user in UserManager.Users!)
                {
                    if(user.Username == username && user.Password == password)
                    {
                        UserManager.SignedInUser = user; //SETS THE LOGGED IN USER TO CURRENTSIGNEDINUSER
                        return true;
                    }
                    else if (user.Username == username && user.Password != password) //Password was wrong
                    {
                        MessageBox.Show("user Found, but password is incorrect", "Alert");
                        return false;
                    }
                    
                }
                MessageBox.Show("There are no user registrerd with these credentials.", "Alert");

                return false;
            }
            
        }



        //Validates the register information
        public static bool ValidateRegister(string username, string password, string confirmPassword)
        {
            
            if (username == "" && password == "" && confirmPassword == "") //Om man inte skrivit in nånting alls
            {
                MessageBox.Show("you need to type a username, password and confirm password", "Alert");
                return false;
            }
            else if (username == "" && password != "") //om man inte skrivit in ett username
            {
                MessageBox.Show("you need to type a username", "Alert");
                return false;
            }
            else if (username != "" && password == "") // om man inte skrivit in ett password 
            {
                MessageBox.Show("you need to type a password", "Alert");
                return false;
            }
            else if (username != "" && password != "" && confirmPassword == "") // confirm password är tom
            {
                MessageBox.Show("you need to confirm password", "Alert");
                return false;
            }
            else
            {
                if (password != confirmPassword)
                {
                    MessageBox.Show("password was not the same, try again", "Alert");
                    return false;
                }
                else
                {
                    //kolla om användaren redan finns
                    foreach(IUser user in UserManager.Users!)
                    {
                        if(user.Username == username)
                        {
                            MessageBox.Show("Username is taken, choose a different username");
                            return false;
                        }
                    }
                    //kolla så att password inte är kortare än 3 karaktärer
                    if(password.Length < 3)
                    {
                        MessageBox.Show("Password needs to be longer than 3 characters");
                        return false;
                    }
                    //Här är allt korrekt och kommer returnas true!
                    return true;
                }
            }
            
        }

        public static bool ValidateSelectedCountry(string Location)
        {
            if(Location == "Select a country")
            {
                MessageBox.Show("you need to select a country", "warning");
                return false;
            }
            return true;
        }
        //använder ej då jag tycker att det ej behövs
        public static void LoginUser(IUser user) 
        {
            //hämta
            UserManager.SignedInUser = user; //SETS THE LOGGED IN USER TO CURRENTSIGNEDINUSER
        }
    }
}

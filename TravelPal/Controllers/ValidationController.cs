using System;
using System.Windows;
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
                    if (user.Username == username && user.Password == password)
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
                    foreach (IUser user in UserManager.Users!)
                    {
                        if (user.Username == username)
                        {
                            MessageBox.Show("Username is taken, choose a different username");
                            return false;
                        }
                    }
                    //kolla så att password inte är kortare än 3 karaktärer
                    if (password.Length < 3)
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
            if (Location == "Select a country") //check if the user have selected a country. the default location will be "select a country"
            {
                MessageBox.Show("you need to select a country", "warning");
                return false;
            }
            return true;
        }

        public static bool ValidateAllFields(string destination, string country, int travellers, DateTime startDate, DateTime endDate, string typeOfTravel, string meetingDetails)
        {
            if (destination == "")
            {
                MessageBox.Show("You need to type a Destination", "warning");
                return false;
            }
            else if (country == "Select a country")
            {
                MessageBox.Show("You need to type a country", "warning");
                return false;
            }
            else if (travellers == 0)
            {
                MessageBox.Show("atleast 1 traveller is needed", "warning");
                return false;
            }
            else if (startDate.Date < DateTime.Today.AddDays(-1))
            {
                MessageBox.Show("start needs to be today or a date in the future", "warning");
                return false;
            }
            else if (endDate.Date < DateTime.Today.AddDays(4))
            {
                MessageBox.Show("End Date needs to be 4 days from start date", "warning");
                return false;
            }
            else
            {
                MessageBox.Show("Travel Added!", "Success!");
                return true;
            }
        }
    }
}

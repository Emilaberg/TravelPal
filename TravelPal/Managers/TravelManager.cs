using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        private static int id;
        public static List<Travel>? Travels { get; set; }
        private static int CalculateDays()
        {
            throw new NotImplementedException();
        }

        public static int CreateId()
        {
            return id++;
        }

        //Gets all of the requested users travel
        public static List<Travel> GetUserTravel(int userId)
        {
            List<Travel> usersTravels = new();

            foreach(Travel travel in Travels)
            {
                if(travel.UserId == userId)
                {
                    usersTravels.Add(travel);
                }
            }
            return usersTravels;
        }
    }
}

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
        public static List<Travel>? Travels { get; set; } = new()
        {
            new Travel ( 
                "Tokyo",
                Country.Japan,
                2,
                new List<IPackingListItem>() { new OtherItem("ToothBrush", 1), new TravelDocument("Passport", true) },
                new DateTime(2023,11,10),
                new DateTime(2023,11,20),
                1
            ),
            new Travel (
                "Madrid",
                EuropeanCountry.Spain,
                2,
                new List<IPackingListItem>() { new OtherItem("ToothBrush", 1), new TravelDocument("Passport", false) },
                new DateTime(2023,11,20),
                new DateTime(2023,11,30),
                1
            ),
        };
        

        public static int CreateId()
        {
            return id++;
        }

        //Gets all of the requested users travel
        public static List<Travel> GetUserTravel(int userId)
        {
            List<Travel> usersTravels = new();

            foreach(Travel travel in Travels!)
            {
                if(travel.UserId == userId)
                {
                    usersTravels.Add(travel);
                }
            }
            return usersTravels;
        }

        public static Travel GetSpecificTravel(int userId, int travelId)
        {
            List<Travel> usersTravels = GetUserTravel(userId);
            foreach (Travel userTravel in usersTravels)
            {
                if(userTravel.TravelId == travelId)
                {
                    return userTravel;
                }
            }
            return null;
        }
    }
}

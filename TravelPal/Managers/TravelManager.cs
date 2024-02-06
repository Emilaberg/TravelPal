using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
            new Vacation ( 
                true,
                "Tokyo",
                Country.Japan,
                2,
                new List<IPackingListItem>() { new OtherItem("ToothBrush", 1), new TravelDocument("Passport", true) },
                new DateTime(2023,11,10),
                new DateTime(2023,11,20),
                1
            ),

            new WorkTrip (
                "meet with boss",
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
            return ++id;
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
            //Jag hittade ett problem här Albin, när jag hittar den specifica traveln så vill jag returnera den och sedan bryta loopen. så att jag inte fortsätter att loopa genom userns resor i onödan.
            //Men jag har försökt sätta usertravel till en object variabel "specificTravel" och sedan returnera den den variabeln castad till en travel. men varje gång jag returnera variabeln så returneras den som null.
            //Jag kommer ta upp detta i min rapport, men jag vill gärna prata med dig om det sen och se hur man kan lösa det :)
            foreach (Travel userTravel in usersTravels)
            {
                if (userTravel.TravelId == travelId)
                {
                    return userTravel;
                }
            }
            return null!;
        }

        public static bool RemoveSpecificTravel(int userId, int travelId)
        {
            Travels!.RemoveAll(t => t.UserId == userId && t.TravelId == travelId);
            return true;
        }

        public static bool AddVacation(bool allInclusive, string destination, object countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate, int userId)
        {
            try
            {
                Vacation newVacation = new(allInclusive, destination, countries, travellers, packingList, startDate, endDate, userId);
                Travels!.Add(newVacation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                return false;
            }
        }

        public static bool AddWorkTrip(string meetingDetails, string destination, object countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate, int userId)
        {
            try
            {
                WorkTrip newWorkTrip = new(meetingDetails, destination, countries, travellers, packingList, startDate, endDate, userId);
                Travels!.Add(newWorkTrip);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;
using TravelPal.Managers;
namespace TravelPal.Classes
{
    public class Travel
    {
        public int TravelId { get; } = TravelManager.CreateId();
        public int UserId { get; set; }
        public string Destination { get; set; }
        public object Countries { get; set; }
        public int Travellers { get; set; }
        public List<IPackingListItem> PackingList { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TravelDays { get; set; }

        public Travel(string destination, object countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate,int userId)
        {
            
            this.Destination = destination;
            this.Countries = countries;
            this.Travellers = travellers;
            this.PackingList = packingList;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TravelDays = CalculateTravelDays(startDate,endDate);
            UserId = userId;
        }

        public virtual string GetInfo()
        {
            return $"Place: {Destination}, Country: {Countries}, travellers: {Travellers}, from: {StartDate.ToString("yyyy-MM-dd")}, to: {EndDate.ToString("yyyy-MM-dd")}, Traveldays: {TravelDays} ";
        }

        private static double CalculateTravelDays(DateTime startDate, DateTime endDate)
        {
            var traveldays = endDate - startDate;
            return double.Floor(traveldays.Days);
        }
    }
}

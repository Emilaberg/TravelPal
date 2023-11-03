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
        public int TravelDays { get; set; }

        public Travel(string destination, object countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate, int travelDays)
        {
            this.Destination = destination;
            this.Countries = countries;
            this.Travellers = travellers;
            this.PackingList = packingList;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TravelDays = travelDays;
        }

        public virtual string GetInfo()
        {
            return $"${Destination},${Countries}, ${Travellers}, ${StartDate}, ${EndDate}, ${TravelDays} ";
        }

        private int CalculateTravelDays()
        {
            //räkna ut antalet traveldays
            //temporär int.
            return 10;
        }
    }
}

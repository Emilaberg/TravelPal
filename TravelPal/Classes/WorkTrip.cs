using System;
using System.Collections.Generic;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string meetingDetails, string destination, object countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate, int userId) : base(destination, countries, travellers, packingList, startDate, endDate, userId)
        {
            this.MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            //returns information about the travel.
            return $"Place: {Destination}, Country: {Countries}, travellers: {Travellers}, from: {StartDate.ToString("yyyy-MM-dd")}, to: {EndDate.ToString("yyyy-MM-dd")}, Traveldays: {TravelDays} "; ;
        }

    }
}

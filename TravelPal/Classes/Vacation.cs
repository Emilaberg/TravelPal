﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string destination, string countries, int travellers, List<IPackingListItem> packingList, DateTime startDate, DateTime endDate, int travelDays) : base(destination, countries, travellers, packingList, startDate, endDate, travelDays)
        {
            this.AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            //returna information om själva resan.
            return $"";
        }
    }
}

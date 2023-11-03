using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class TravelDocument: IPackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }

        public TravelDocument(string name, bool required)
        {
            this.Name = name;
            this.Required = required;
        }

        public string GetInfo()
        {
            string info = Required ? "Is required" : "Is not required";
            return $"Item: {Name} {info}";
        }
    }
}

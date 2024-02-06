using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class TravelDocument : IPackingListItem
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
            string info = Required ? "Is required" : "Is not required"; //sets info to either Is required or is not required based on the traveldocument is required.
            return $"Item: {Name} {info}";
        }
    }
}

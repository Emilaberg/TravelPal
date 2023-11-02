using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal.Interfaces
{
    public interface IUser
    {
        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public string GetInfo();
    }
}

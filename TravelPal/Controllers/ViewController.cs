using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Views;

namespace TravelPal.Controllers
{
    public static class ViewController
    {
        public static MainWindow MainWindow()
        {
            return new MainWindow();
        }
        public static AccountWindow AccountWindow()
        {
            return new AccountWindow();
        }

        public static AddTravelWindow AddTravelWindow()
        {
            return new AddTravelWindow();
        }
        public static AddTravelWindow EditTravelWindow(int userId, int travelId)
        {
            return new AddTravelWindow(userId, travelId);
        }

        public static AdminPanelWindow AdminPanelWindow()
        {
            return new AdminPanelWindow();
        }

        public static RegisterWindow RegisterWindow()
        {
            return new RegisterWindow();
        }

        public static TravelsWindow TravelsWindow()
        {
            return new TravelsWindow();
        }

    }
}

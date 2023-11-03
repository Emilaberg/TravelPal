using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Classes;
using TravelPal.Managers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        Travel travel;
        public AddTravelWindow(int userId, int travelId)
        {
            
            InitializeComponent();
            travel = TravelManager.GetSpecificTravel(userId, travelId);
            InitUi();
        }
        public AddTravelWindow()
        {

            InitializeComponent();
            
        }

        private void InitUi()
        {
            
        }
    }
}

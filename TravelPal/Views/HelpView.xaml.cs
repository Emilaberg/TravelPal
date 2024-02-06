using System.Windows;
using TravelPal.Controllers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : Window
    {
        string fromPage;
        public HelpView(string fromPage)
        {
            InitializeComponent();
            this.fromPage = fromPage;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (fromPage == "travel")
            {
                ViewController.TravelsWindow().Show();

            }
            else if (fromPage == "account")
            {
                ViewController.AccountWindow().Show();
            }
            else if (fromPage == "addTravel")
            {
                ViewController.AddTravelWindow().Show();
            }
            else if (fromPage == "admin")
            {
                ViewController.AccountWindow().Show();
            }
            Close();
        }
    }
}

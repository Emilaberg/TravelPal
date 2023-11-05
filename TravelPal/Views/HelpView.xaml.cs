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
            if(fromPage == "travel")
            {
                ViewController.TravelsWindow().Show();
                
            }else if(fromPage == "account")
            {
                ViewController.AccountWindow().Show();
            }else if(fromPage == "addTravel") 
            { 
                ViewController.TravelsWindow().Show();
            }else if(fromPage == "admin") 
            { 
                ViewController.AccountWindow().Show();
            }
            Close();
        }
    }
}

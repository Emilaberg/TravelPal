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
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Classes;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        IUser user = UserManager.SignedInUser!;
        public TravelsWindow()
        {

            InitializeComponent();

            InitUi();
            
        }

        private void InitUi()
        {
            txtUsername.Content = user.Username;
            txtWelcome.Content = $"Welcome Back {user.Username} {user.Id}";

            //hämtar alla users travels och lägger in dom i travelslist
            List<Travel> usersTravels = TravelManager.GetUserTravel(user.Id);
            foreach (Travel travel in usersTravels)
            {
                ListViewItem userTravel = new();
                userTravel.Content = travel.GetInfo();
                userTravel.Tag = travel;
                lstUserTravels.Items.Add(userTravel);
            }
        }

        private void UpdateUi(string type)
        {
            lstUserTravels.Items.Clear();
            //hämtar alla users travels och lägger in dom i travelslist
            List<Travel> usersTravels = TravelManager.GetUserTravel(user.Id);
            foreach (Travel travel in usersTravels)
            {
                ListViewItem userTravel = new();
                userTravel.Content = travel.GetInfo();
                userTravel.Tag = travel;
                lstUserTravels.Items.Add(userTravel);
            }
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            ViewController.AccountWindow().Show();
            Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser = null;

            ViewController.MainWindow().Show();
            Close();
        }

        private void BtnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            
            ViewController.AddTravelWindow().Show();
            Close();
        }

        private void BtnTravelDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lstUserTravels.SelectedItem == null)
            {
                MessageBox.Show("you need to select a travel to edit");
                return;
            }

            ListViewItem selectedItem = (ListViewItem)lstUserTravels.SelectedItem;
            Travel selectedTravel = (Travel)selectedItem.Tag;

            ViewController.EditTravelWindow(selectedTravel.UserId, selectedTravel.TravelId).Show();
            Close();
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstUserTravels.SelectedItem;
            Travel selectedTravel = (Travel)selectedItem.Tag;
            //lägg i travelmanager
            if (TravelManager.RemoveSpecificTravel(UserManager.SignedInUser!.Id, selectedTravel.TravelId))
            {
                UpdateUi("update");
            }
            
        }
    }
}

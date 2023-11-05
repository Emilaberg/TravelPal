using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Classes;
using TravelPal.Controllers;
using TravelPal.Interfaces;
using TravelPal.Managers;

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
            lblUsername.Content = user.Username;
            txtWelcome.Content = $"Welcome Back {user.Username}";

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
            if (lstUserTravels.SelectedItem == null)
            {
                MessageBox.Show("you need to select a travel to Remove");
                return;
            }

            if (MessageBox.Show("YOU ARE ABOUT TO REMOVE YOUR ACCOUNT DO YOU WANT TO PROCEED?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewController.HelpView("travel").Show();
            Close();
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using TravelPal.Controllers;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();

            UpdateUi();
        }

        private void UpdateUi()
        {
            lstUsers.Items.Clear();
            foreach (IUser user in UserManager.Users!)
            {

                ListViewItem newUser = new();
                newUser.Content = user.GetInfo();
                newUser.Tag = user;

                if (user.GetType().Name == "Admin")
                {
                    newUser.IsEnabled = false;
                }
                lstUsers.Items.Add(newUser);
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("YOU ARE ABOUT TO REMOVE A USERACCOUNT, DO YOU WANT TO PROCEED?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListViewItem selectedItem = (ListViewItem)lstUsers.SelectedItem;
                IUser selectedUser = (IUser)selectedItem.Tag;
                //loops through all the users and check for each user if userid is correct. and the removes that user.
                UserManager.Users!.RemoveAll(user => user.Id == selectedUser.Id);
                UpdateUi();
            }
        }

        private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnRemove.Opacity = 1;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser = null;
            ViewController.MainWindow().Show();
            Close();
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            ViewController.AccountWindow().Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewController.HelpView("admin").Show();
            Close();
        }
    }
}

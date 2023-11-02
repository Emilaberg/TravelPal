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

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        IUser user = UserManager.SignedInUser;
        public TravelsWindow()
        {

            InitializeComponent();

            InitUi();
            UpdateUi();
        }

        private void InitUi()
        {
            txtUsername.Content = user.Username;
            txtWelcome.Content = $"Welcome Back {user.Username}";
        }

        private void UpdateUi()
        {
            
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
    }
}

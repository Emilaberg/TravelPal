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
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Controllers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        
        IUser user = UserManager.SignedInUser!;
        public AccountWindow()
        {
            InitializeComponent();
            UpdateUi("init");
        }

        private void UpdateUi(string info)
        {
            if (info == "update" || info == "cancel")
            {
                txtConfirmNewPassword.Clear();
            }

            txtUsername.Clear();
            txtPassword.Clear();
            cbCountry.Items.Clear();
            foreach(Country country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }

            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;

            cbCountry.SelectedIndex = (int)user.Location;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            //kollar om man ändrar användarnamn, därefter kollar jag om användarnamnet är upptaget.
            if(user.Username != txtUsername.Text)
            {
                string oldUsername = user.Username;
                user.Username = txtUsername.Text;
                int count = UserManager.Users!.Count(u => u.Username == txtUsername.Text);
                if (count > 1)
                {
                    MessageBox.Show("Username is taken, Choose a different one", "Warning");
                    user.Username = oldUsername;
                    oldUsername = "";
                    return;
                }
                
            }
            
            if(txtConfirmNewPassword.Text != "")
            {
                if (txtPassword.Text != txtConfirmNewPassword.Text)
                {
                    MessageBox.Show("Password must match");
                    return;
                }
                user.Password = txtPassword.Text;
            }

            if ((Country)cbCountry.SelectedIndex != user.Location)
            {
                user.Location = (Country)cbCountry.SelectedIndex;
            }
            UpdateUi("update");
            MessageBox.Show("Updated successfull","Info");
            
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ViewController.TravelsWindow().Show();
            Close();
        }

        private void BtnRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("YOU ARE ABOUT TO REMOVE YOUR ACCOUNT DO YOU WANT TO PROCEED?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //removes the user
                UserManager.Users!.Remove(user);
                UserManager.SignedInUser = null;
                ViewController.MainWindow().Show();
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi("cancel");
        }
    }
}

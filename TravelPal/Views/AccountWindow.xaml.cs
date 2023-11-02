using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using TravelPal.Controllers;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;

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
            //Fyller upp comboboxen för countries.
            cbCountry.Items.Add("Select a country");
            foreach (EuropeanCountry europeanCountry in Enum.GetValues(typeof(EuropeanCountry)))
            {
                cbCountry.Items.Add(europeanCountry);
            }

            foreach (Country Country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(Country);
            }
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

            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;

            cbCountry.SelectedIndex = (int)user.Location;


            if (user.FromEu.Equals(true))
            {
                isFromEu.IsChecked = true;
                isFromEu.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
                isFromEu.Foreground = new SolidColorBrush(Colors.LimeGreen);
            }
            else
            {
                isFromEu.IsChecked = false;
                isFromEu.BorderBrush = new SolidColorBrush(Colors.Red);
                isFromEu.Foreground = new SolidColorBrush(Colors.Red);
            }

        }



        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            //kollar om man ändrar användarnamn, därefter kollar jag om användarnamnet är upptaget.
            if (user.Username != txtUsername.Text)
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
            //kollar om användare vill byta lösenord
            if (txtConfirmNewPassword.Text != "")
            {
                //Kolla så att lösenorden stämmer överens
                if (txtPassword.Text != txtConfirmNewPassword.Text)
                {
                    MessageBox.Show("Password must match");
                    return;
                }
                //sätter det nya lösenordet
                user.Password = txtPassword.Text;
            }

            //kollar om användare har valt ett annat land.
            if ((object)cbCountry.SelectedItem != user.Location)
            {
                //sätter användarens location till det man valt, castat som ett objekt.
                user.Location = (object)cbCountry.SelectedItem;
                user.FromEu = cbCountry.SelectedItem.GetType().Equals(typeof(EuropeanCountry)) ? true : false;
            }
            //UpdateUi("update");
            MessageBox.Show("Updated successfull", "Info");

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

        private void cbCountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (cbCountry.SelectedItem.GetType().Equals(typeof(EuropeanCountry)))
            {
                isFromEu.IsChecked = true;
                isFromEu.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
                isFromEu.Foreground = new SolidColorBrush(Colors.LimeGreen);
            }
            else
            {
                isFromEu.IsChecked = false;
                isFromEu.BorderBrush = new SolidColorBrush(Colors.Red);
                isFromEu.Foreground = new SolidColorBrush(Colors.Red);
            }
        }


    }
}

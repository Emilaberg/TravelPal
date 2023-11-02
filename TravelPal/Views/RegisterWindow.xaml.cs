using System;
using System.Windows;
using TravelPal.Controllers;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
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
            cbCountry.SelectedIndex = 0;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {

            //om validateRegister returnerar true, då vill jag köra sign in user i Usermanagerklassen, där efter vill jag returnera true och logga in användaren.
            if (ValidationController.ValidateRegister(txtUsername.Text, txtPassword.Text, txtConfirmPassword.Text))
            {
                //username är korrekt skrivit, nu vill vi kolla om man har selectat ett country
                //om användaren har valt ett land, då kör jag Adduser med username och text
                if (ValidationController.ValidateSelectedCountry(cbCountry.SelectedItem.ToString()!))
                {
                    //om addUser lyckats då vill jag visa accountwindow
                    if (UserManager.AddUser(txtUsername.Text, txtPassword.Text, cbCountry.SelectedItem)) //NOTE den kommer alltid returna true för allt är checkat, så jag behöver inte en if sats igentligen.
                    {
                        ViewController.TravelsWindow().Show();
                        Close();
                    }
                }
            }
        }
    }
}

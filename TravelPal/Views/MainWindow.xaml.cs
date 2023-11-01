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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal;
using TravelPal.Controllers;
using TravelPal.Managers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Kör loginController som validerar
            
            if (ValidationController.ValidateLogin(txtUsername.Text, txtPassword.Text))
            {
                //Jag sätter den inloggade usern i logincontrollern om username och password stämmer överens.
                //loginuser
                if (UserManager.SignedInUser!.GetType().Name == "Admin")
                {
                    //Visar Admin panelen om det är en Admin
                    ViewController.AdminPanelWindow().Show();
                }
                else
                {
                    //Visar Accountwindow om det är en client
                    ViewController.AccountWindow().Show();
                }
                Close();

            }
            else
            {
                //om det blir false kommer den messagebox visas.
                return;
            }

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            ViewController.RegisterWindow().Show();
            Close();

        }

    }
}

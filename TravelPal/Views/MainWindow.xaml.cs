using System.Windows;
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
            txtUsername.Text = "user";
            txtPassword.Password = "password";
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Kör loginController som validerar

            if (ValidationController.ValidateLogin(txtUsername.Text, txtPassword.Password))
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
                    ViewController.TravelsWindow().Show();
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

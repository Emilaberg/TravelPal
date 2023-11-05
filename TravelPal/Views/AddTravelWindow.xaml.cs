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
using TravelPal.Classes;
using TravelPal.Controllers;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        int userId;
        int travelId;
        bool editing = false;
        public AddTravelWindow(int userId, int travelId)
        {
            InitializeComponent();
            this.userId = userId;
            this.travelId = travelId;
            UpdateUi("IsEditing");
            editing = true;
        }

        public AddTravelWindow()
        {

            InitializeComponent();
            UpdateUi("");
        }
        //To go back
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ViewController.TravelsWindow().Show();
            Close();
        }
        //UI METHODS//
        private void UpdateUi(string type)
        {
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

            cbTypeOfTravel.Items.Add("Vacation");
            cbTypeOfTravel.Items.Add("Work Trip");

                        
            //Clearer all comboboxen
            txtDestination.Text = "";
            cbCountry.SelectedIndex = 0;
            txtAmountOfTravelers.Text = "";
            DateStartDate.Text = "";
            DateEndDate.Text = "";
            cbTypeOfTravel.SelectedIndex = 0;
            cbxAllInclusiv.IsChecked = false;
            cbxMeetingDetails.IsChecked = false;
            txtMeetingDetails.Text = "";
            lstPackingList.Items.Clear();

                        

            if (type == "IsEditing" || editing == true)
            {
                //SET ALL BOXES TO READONLY
                //Change all textboxes to isreadonly to false,
                txtDestination.IsReadOnly = true;
                cbCountry.IsEnabled = false;
                txtAmountOfTravelers.IsReadOnly = true;
                DateStartDate.IsEnabled = false;
                DateEndDate.IsEnabled = false;
                cbTypeOfTravel.IsEnabled = false;
                txtNameOfItem.IsReadOnly = true;
                txtQuantity.IsReadOnly = true;
                cbxTravelDocument.IsEnabled = false;
                BtnSaveEdit.IsEnabled = false;
                BtnCancel.IsEnabled = false;

                //Sets packinglistitem to not selected
                lstPackingList.IsEnabled = false;
                BtnAddPackListItem.IsEnabled = false;

                //Sets opacity to 0.5 //change opacity
                txtDestination.Opacity = 0.5;
                cbCountry.Opacity = 0.5;
                txtAmountOfTravelers.Opacity = 0.5;
                DateStartDate.Opacity = 0.5;
                DateEndDate.Opacity = 0.5;
                cbTypeOfTravel.Opacity = 0.5;
                txtNameOfItem.Opacity = 0.5;
                txtQuantity.Opacity = 0.5;
                cbxTravelDocument.Opacity = 0.5;
                BtnSaveEdit.Opacity = 0.5;
                BtnCancel.Opacity = 0.5;

                //Gets the chosen travel
                Travel travel = TravelManager.GetSpecificTravel(userId, travelId);
                //adds all the info to the boxes for the specific travel
                txtDestination.Text = travel.Destination;
                cbCountry.SelectedItem = travel.Countries;
                txtAmountOfTravelers.Text = travel.Travellers.ToString();
                DateStartDate.SelectedDate = travel.StartDate;
                DateEndDate.SelectedDate = travel.EndDate;
                cbTypeOfTravel.SelectedItem = travel.GetType();

                //lägger till varje packinglist item från resan man valt och lägger till det i listview:n
                foreach (IPackingListItem item in travel.PackingList)
                {
                    if (item.GetType() == typeof(TravelDocument)) // Om typen av item är ett traveldocument så skapar jag ett traveldocument
                    {
                        TravelDocument travelDocument = (TravelDocument)item;
                        if(travelDocument.Name.ToLower() != "passport")
                        {
                            ListViewItem newPackingListItem = new();
                            newPackingListItem.Content = travelDocument.GetInfo();
                            newPackingListItem.Tag = travelDocument;
                            lstPackingList.Items.Add(newPackingListItem);
                        }
                        
                    }
                    else // annars vill jag skapa ett otherItem
                    {
                        OtherItem otherItem = (OtherItem)item;
                        ListViewItem newPackingListItem = new();
                        newPackingListItem.Content = otherItem.GetInfo();
                        newPackingListItem.Tag = otherItem;
                        lstPackingList.Items.Add(newPackingListItem);
                    }
                }

                //Shows the isEditing
                BtnEditTravel.Visibility = Visibility.Visible;

                //show the save edit button instead of the save button.
                BtnSave.Visibility = Visibility.Hidden;
                BtnSaveEdit.Visibility = Visibility.Visible;

                if (type == "SaveEdit" || type == "Cancel" || type == "Save")
                {
                    BtnEditTravel.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
                    BtnSaveEdit.IsEnabled = false;
                    BtnEditTravel.IsEnabled = true;
                }
            }
            
        }
        private void BtnEditTravel_Click(object sender, RoutedEventArgs e)
        {
            //Change all textboxes to isreadonly to false,
            txtDestination.IsReadOnly = false;
            cbCountry.IsEnabled = true;
            txtAmountOfTravelers.IsReadOnly = false;
            DateStartDate.IsEnabled = true;
            DateEndDate.IsEnabled = true;
            cbTypeOfTravel.IsEnabled = true;
            txtNameOfItem.IsReadOnly = false;
            txtQuantity.IsReadOnly = false;
            cbxTravelDocument.IsEnabled = true;
            BtnSaveEdit.IsEnabled = true;
            BtnEditTravel.Focusable = false;
            BtnCancel.IsEnabled = true;

            //Sets packinglistitem to not selected
            lstPackingList.IsEnabled = true;
            BtnAddPackListItem.IsEnabled = true;
            //change opacity
            txtDestination.Opacity = 1;
            cbCountry.Opacity = 1;
            txtAmountOfTravelers.Opacity = 1;
            DateStartDate.Opacity = 1;
            DateEndDate.Opacity = 1;
            cbTypeOfTravel.Opacity = 1;
            txtNameOfItem.Opacity = 1;
            txtQuantity.Opacity = 1;
            cbxTravelDocument.Opacity = 1;
            BtnSaveEdit.Opacity = 1;
            BtnCancel.Opacity = 1;
            BtnSaveEdit.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
            BtnEditTravel.BorderBrush = new SolidColorBrush(Colors.Orange);
            
        }
        //Updating the UI
        

        //for UI
        private void cbTypeOfTravel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((string)cbTypeOfTravel.SelectedItem == "Vacation") 
            {
                //gömmer meetingdetails
                lblMeetingDetails.Visibility = Visibility.Hidden;
                cbxMeetingDetails.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Hidden;
                cbxAllInclusiv.IsChecked = false;

                //visar allinclusive
                lblAllInclusive.Visibility = Visibility.Visible;
                cbxAllInclusiv.Visibility = Visibility.Visible;
            }else if((string)cbTypeOfTravel.SelectedItem == "Work Trip")
            {
                //gömmer meeting details
                lblMeetingDetails.Visibility = Visibility.Visible;
                cbxMeetingDetails.Visibility = Visibility.Visible;
                cbxMeetingDetails.IsChecked = false;
                //visar meetingdetails
                lblAllInclusive.Visibility = Visibility.Hidden;
                cbxAllInclusiv.Visibility = Visibility.Hidden;

                
            }
        }
        //for UI
        private void cbxMeetingDetails_Checked(object sender, RoutedEventArgs e)
        {
            txtMeetingDetails.Visibility = Visibility.Visible;
        }
        //for UI
        private void cbxTravelDocument_Checked(object sender, RoutedEventArgs e)
        {
            //Om den är checked då vill jag gömma quantity label och textbox och visa required label och checkbox
            lblQuantity.Visibility = Visibility.Hidden;
            txtQuantity.Visibility = Visibility.Hidden;
            txtQuantity.Text = "";

            lblRequired.Visibility = Visibility.Visible;
            cbxRequired.Visibility = Visibility.Visible;
        }
        //for UI
        private void cbxTravelDocument_UnChecked(object sender, RoutedEventArgs e)
        {
            //om man uncheckar den vill jag gömma den och unchecka required
            lblRequired.Visibility = Visibility.Hidden;
            cbxRequired.Visibility = Visibility.Hidden;
            cbxRequired.IsChecked = false;

            lblQuantity.Visibility = Visibility.Visible;
            txtQuantity.Visibility = Visibility.Visible;

            
        }
        //UI METHODS//

        // FRONT END //
        
        // when adding a packing list item 
        private void BtnAddPackListItem_Click(object sender, RoutedEventArgs e)
        {
            //om namnet på item är passport 
                //skriv att man passport är redan inlagt
            if(txtNameOfItem.Text.ToLower() == "passport")
            {
                MessageBox.Show("Passport will be added when selecting country, If you wish to add more passport, add passport as Extra passports and choose quantity.", "Warning");
                return;
            }

            // om det är ett traveldocument då vill jag skapa ett travel document
            //då vill jag skapa ett TravelDocument
            if (cbxTravelDocument.IsChecked == true)
            {
                bool isRequired = cbxRequired.IsChecked == true ? true : false;
                ListViewItem newPackingListItem = new();
                TravelDocument newTravelDocument = new(txtNameOfItem.Text, isRequired);
                newPackingListItem.Content = newTravelDocument.GetInfo();
                newPackingListItem.Tag = newTravelDocument;
                lstPackingList.Items.Add(newPackingListItem);
                
            }
            else // annars vill jag skapa ett otherItem
            {
                int.TryParse(txtQuantity.Text, out int res); //CHECKA DETTA

                ListViewItem newPackingListItem = new();
                OtherItem newItem = new(txtNameOfItem.Text, res);
                newPackingListItem.Content = newItem.GetInfo();
                newPackingListItem.Tag = newItem;
                lstPackingList.Items.Add(newPackingListItem);
            }
            cbxTravelDocument.IsChecked = false;
            txtNameOfItem.Text = "";
            txtQuantity.Text = "";
            cbxTravelDocument.IsChecked = false;
            cbxRequired.IsChecked = false;


        }

        //To remove an packinglist item 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lstPackingList.Items.Remove(lstPackingList.SelectedItem);
        }

        // FRONT END //

        //for saving a trip
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string meetingDetails = cbxAllInclusiv.IsChecked == true ? txtMeetingDetails.Text : "";

            bool success = int.TryParse(txtAmountOfTravelers.Text, out int res);
            if (success)
            {
                if (!ValidationController.ValidateAllFields(txtDestination.Text, cbCountry.SelectedItem.ToString(), res, (DateTime)DateStartDate.SelectedDate, (DateTime)DateEndDate.SelectedDate, cbTypeOfTravel.SelectedItem.ToString(), meetingDetails))
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("amount of travelers need to be a number", "warning");
                return;
            }

            //skapa en ny Travel och lägg in all data från det man skrivit in
            //skapa en Ipackinglista med alla listitems från packinglist och lägg till den i travel klassen
            List<IPackingListItem> packingListItems = new();
            foreach (ListViewItem packingListItem in lstPackingList.Items)
            {
                IPackingListItem item = (IPackingListItem)packingListItem.Tag;
                packingListItems.Add(item);
            }

            if ((string)cbTypeOfTravel.SelectedItem == "Vacation")
            {
                bool allInclusive = cbxAllInclusiv.IsChecked == true ? true : false;
                TravelManager.AddVacation(allInclusive, txtDestination.Text, (object)cbCountry.SelectedItem, int.Parse(txtAmountOfTravelers.Text), packingListItems, (DateTime)DateStartDate.SelectedDate, (DateTime)DateEndDate.SelectedDate, UserManager.SignedInUser!.Id);
                
            }
            else
            {
                TravelManager.AddWorkTrip(txtMeetingDetails.Text, txtDestination.Text, (object)cbCountry.SelectedItem, int.Parse(txtAmountOfTravelers.Text), packingListItems, (DateTime)DateStartDate.SelectedDate, (DateTime)DateEndDate.SelectedDate, UserManager.SignedInUser!.Id);
                
            }
            
            UpdateUi("Save");
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            //Get the specific travel
            Travel travel = TravelManager.GetSpecificTravel(userId, travelId);
            //
            List<IPackingListItem> packingListItems = new();
            foreach (ListViewItem packingListItem in lstPackingList.Items)
            {
                IPackingListItem item = (IPackingListItem)packingListItem.Tag;
                packingListItems.Add(item);
            }
            //if the type of travel is a vacation, then I want to update that vacation.
            if (travel.GetType() == typeof(Vacation))
            {
                Vacation vacation = (Vacation)travel;
                //TravelManager.AddVacation(allInclusive, txtDestination.Text, (object)cbCountry.SelectedItem, int.Parse(txtAmountOfTravelers.Text), packingListItems, (DateTime)DateStartDate.SelectedDate, (DateTime)DateEndDate.SelectedDate, UserManager.SignedInUser!.Id);
                bool allInclusive = cbxAllInclusiv.IsChecked == true ? true : false;
                vacation.AllInclusive = allInclusive;
                vacation.Destination = txtDestination.Text;
                vacation.Countries = (object)cbCountry.SelectedItem;
                vacation.Travellers = int.Parse(txtAmountOfTravelers.Text);
                vacation.PackingList = packingListItems;
                vacation.StartDate = (DateTime)DateStartDate.SelectedDate;
                vacation.EndDate = (DateTime)DateEndDate.SelectedDate;

            }
            else//if the type of travel is a Worktrip, then I want to update that vacation.
            {
                //TravelManager.AddWorkTrip(txtMeetingDetails.Text, txtDestination.Text, (object)cbCountry.SelectedItem, int.Parse(txtAmountOfTravelers.Text), packingListItems, (DateTime)DateStartDate.SelectedDate, (DateTime)DateEndDate.SelectedDate, UserManager.SignedInUser!.Id);
                WorkTrip workTrip = (WorkTrip)travel;
                workTrip.MeetingDetails = txtMeetingDetails.Text;
                workTrip.Destination = txtDestination.Text;
                workTrip.Countries = (object)cbCountry.SelectedItem;
                workTrip.Travellers = int.Parse(txtAmountOfTravelers.Text);
                workTrip.PackingList = packingListItems;
                workTrip.StartDate = (DateTime)DateStartDate.SelectedDate;
                workTrip.EndDate = (DateTime)DateEndDate.SelectedDate;
                
            }
            
            UpdateUi("SaveEdit");
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi("Cancel");
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

        private void CbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //när användaren väljer ett land, så ska jag köra AddPassport
            AddPassport();
        }

        private void AddPassport()
        {
            if(lstPackingList.Items.Count > 0)
            {
                for(int i = 0; i < lstPackingList.Items.Count; i++)
                {
                    ListViewItem listViewItem = (ListViewItem)lstPackingList.Items[i];
                    IPackingListItem packingItem = (IPackingListItem)listViewItem.Tag;
                    if (packingItem.GetType() == typeof(TravelDocument))
                    {
                        lstPackingList.Items.RemoveAt(i);
                    }
                }
                
            }
            
            ListViewItem listViewPassport = new();
            if (cbCountry.SelectedItem.GetType() == typeof(EuropeanCountry) && UserManager.SignedInUser!.Location.GetType() == typeof(EuropeanCountry))
            {
                TravelDocument passport = new("Passport", false);

                listViewPassport.Content = passport.GetInfo();
                listViewPassport.Tag = passport;
                listViewPassport.IsEnabled = false;

            }
            else if (cbCountry.SelectedItem.GetType() == typeof(Country) && UserManager.SignedInUser!.Location.GetType() == typeof(EuropeanCountry))
            {

                TravelDocument passport = new("Passport", true);
                listViewPassport.Content = passport.GetInfo();
                listViewPassport.Tag = passport;
                listViewPassport.IsEnabled = false;
            }
            else
            {

                TravelDocument passport = new("Passport", true);
                listViewPassport.Content = passport.GetInfo();
                listViewPassport.Tag = passport;
                listViewPassport.IsEnabled = false;
            }
            lstPackingList.Items.Add(listViewPassport);
           
            //if cbcountry är från euCountry och User Country är från euCountry
            //lägg till ett nytt traveldocument med namn passport och required till false

            //else if cbCountry är från Country och User Country är från euCountry
            //lägg till ett nytt traveldocument med namn passport och required till true
            //else User Country är utanför
            //Lägg till ett nytt traveldocument med namn passport och required till true

            //sätt isenabled to false
            

        }

        
    }
}

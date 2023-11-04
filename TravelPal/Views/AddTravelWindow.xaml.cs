﻿using System;
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
        public AddTravelWindow(int userId, int travelId)
        {
            InitializeComponent();
            this.userId = userId;
            this.travelId = travelId;
            InitUi("Edit");
        }

        public AddTravelWindow()
        {

            InitializeComponent();
            InitUi("");

        }
        //To go back
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ViewController.TravelsWindow().Show();
            Close();
        }
        //UI METHODS//
        private void InitUi(string type)
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

            if (type == "Edit")
            {

                Travel travel = TravelManager.GetSpecificTravel(userId, travelId);
                txtDestination.Text = travel.Destination;
                cbCountry.SelectedIndex = (int)travel.Countries;
                txtAmountOfTravelers.Text = travel.Travellers.ToString();
                DateStartDate.SelectedDate = travel.StartDate;
                DateEndDate.SelectedDate = travel.EndDate;
                cbTypeOfTravel.SelectedItem = travel.GetType();

                foreach(IPackingListItem item in travel.PackingList)
                {
                    if (item.GetType() == typeof(TravelDocument)) // Om typen av item är ett traveldocument så skapar jag ett traveldocument
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
                }


            }
            

        }
        //Updating the UI
        private void UpdateUi(string type)
        {
            
            if(type == "clearUI")
            {
                txtDestination.Text = "";
                cbCountry.SelectedIndex = 0;
                txtAmountOfTravelers.Text = "";
                DateStartDate.Text = "";
                DateEndDate.Text = "";
                cbTypeOfTravel.SelectedIndex = 0;
                cbxAllInclusiv.IsChecked = false;
                cbxMeetingDetails.IsChecked = false;
                txtMeetingDetails.Text = "";
            }
        }
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

            UpdateUi("clearUI");
        }
    }
}

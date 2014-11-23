using System;
using System.Collections.Generic;
using System.Text;
using WorkTogether.Models;

using GalaSoft.MvvmLight;
using Parse;
using Windows.UI.Popups;
using System.Threading.Tasks;

namespace WorkTogether.ViewModels
{
    public class UploadAdPageViewModel :ViewModelBase
    {
        private string title;
        private string description;
        private string town;
        private DateTime dateOfEvent;
        private const string EmptyTitleMessage = "Title cannot be empty";
        private const string EmptyDescriptionMessage = "Description cannot be empty";
        private const string EmptyTownMessage = "Town cannot be empty";
        private const int MinimumTitleLength = 6;
        private const int MaximumTitleLength = 16;
        private const int MinimumDescriptionLength = 6;
        private const int MaximumDescriptionLength = 16;
        private const int MinimumTownLength = 2;
        private const int MaximumTownLength = 16;

        public UploadAdPageViewModel()
        {
        }

        public string Title 
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.RaisePropertyChanged(() => this.Title);
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.RaisePropertyChanged(() => this.Description);
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
                this.RaisePropertyChanged(() => this.Town);
            }
        }

        public DateTime DateOfEvent
        {
            get
            {
                return this.dateOfEvent.Date.AddYears(DateTime.Now.Year-1).AddMonths(DateTime.Now.Month-1).AddDays(DateTime.Now.Day-1).AddHours(DateTime.Now.Hour);
            }
            set
            {

                this.dateOfEvent = value;                
                this.RaisePropertyChanged(() => this.DateOfEvent);
            }
        }

        public async Task<bool> SendDataToDb()
        {
            string title = this.Title;
            string description = this.Description;
            DateTime dateOfEvent = this.DateOfEvent;
            string town = this.Town;

            //Validation
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                var msgDialog = new MessageDialog(EmptyTitleMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                var msgDialog = new MessageDialog(EmptyDescriptionMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (string.IsNullOrEmpty(town) || string.IsNullOrWhiteSpace(town))
            {
                var msgDialog = new MessageDialog(EmptyTownMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else
            {
                ParseObject newAd = ParseObject.Create<AdModel>();
                newAd["Title"] = title;
                newAd["Content"] = description;
                newAd["DateOfEvent"] = this.DateOfEvent;
                newAd["Town"] = town;
                newAd["CreatorId"] = ParseUser.CurrentUser.ObjectId;
                newAd["PhoneNumber"] = ParseUser.CurrentUser["PhoneNumber"].ToString();
                newAd["Name"] = ParseUser.CurrentUser.Username;
                await newAd.SaveAsync();
                return true;
            }
        }
    }
}

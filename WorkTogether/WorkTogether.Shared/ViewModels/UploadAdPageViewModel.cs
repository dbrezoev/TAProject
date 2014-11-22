using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class UploadAdPageViewModel :ViewModelBase
    {
        private string title;
        private string description;
        private string town;
        private DateTime dateOfEvent;

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
                var a = 5;
                this.RaisePropertyChanged(() => this.DateOfEvent);
            }
        }

        public async void SendDataToDb()
        {
            ParseObject newAd = ParseObject.Create<AdModel>();
            newAd["Title"] = this.Title;
            newAd["Content"] = this.Description;
            newAd["DateOfEvent"] = this.DateOfEvent;
            newAd["Town"] = this.Town;
            newAd["CreatorId"] = ParseUser.CurrentUser.ObjectId;
            newAd["PhoneNumber"] = ParseUser.CurrentUser["PhoneNumber"].ToString();
            newAd["Name"] = ParseUser.CurrentUser.Username;
            var a = 9;
            await newAd.SaveAsync();
        }
    }
}

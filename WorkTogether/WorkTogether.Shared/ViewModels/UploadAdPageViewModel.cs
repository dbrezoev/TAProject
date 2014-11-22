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
                return this.dateOfEvent;
            }
            set
            {
                this.dateOfEvent = value;
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
            newAd["Creator"] = ParseUser.CurrentUser;

            await newAd.SaveAsync();
        }
    }
}

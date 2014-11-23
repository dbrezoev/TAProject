using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using GalaSoft.MvvmLight;

using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class FavouriteAdViewModel : ViewModelBase
    {
        private string title;
        private string contactName;
        private string contactPhone;

        public static Expression<Func<FavouriteAd, FavouriteAdViewModel>> FromModel
        {
            get
            {
                return model => new FavouriteAdViewModel()
                {
                    Title = model.Title,
                    ContactName = model.ContactName,
                    ContactPhone = model.ContactPhone
                };
            }
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

        public string ContactName
        {
            get
            {
                return this.contactName;
            }
            set
            {
                this.contactName = value;
                this.RaisePropertyChanged(() => this.ContactName);
            }
        }

        public string ContactPhone
        {
            get
            {
                return this.contactPhone;
            }
            set
            {
                this.contactPhone = value;
                this.RaisePropertyChanged(() => this.ContactPhone);
            }
        }
    }
}

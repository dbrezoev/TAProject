using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using Parse;

using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class AdViewModel:ViewModelBase
    {
        private string title;
        private string content;
        private string town;
        private string creatorId;
        private DateTime dateOfEvent;                
        private string name;
        private string phone;

        public static Expression<Func<AdModel, AdViewModel>> FromModel
        {
            get
            {
                return model => new AdViewModel()
                {
                    Title = model.Title,
                    Content = model.Content,
                    CreatorId = model.Creator,
                    Name = model.Name,
                    Phone = model.PhoneNumber,                    
                    Town = model.Town,
                    DateOfEvent = model.DateOfEvent,                    
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

        public string Content 
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
                this.RaisePropertyChanged(() => this.Content);
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

        public string CreatorId {
            get
            {
                return this.creatorId;
            }
            set
            {
                this.creatorId = value;
                this.RaisePropertyChanged(() => this.CreatorId);
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

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
                this.RaisePropertyChanged(() => this.Phone);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged(() => this.Name);
            }
        }
    }
}

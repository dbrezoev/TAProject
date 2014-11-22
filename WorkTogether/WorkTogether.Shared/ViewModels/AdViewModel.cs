using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class AdViewModel:ViewModelBase
    {
        private string title;
        public static Expression<Func<AdModel, AdViewModel>> FromModel
        {
            get
            {
                return model => new AdViewModel()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Creator = model.Creator,
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

        public string Content { get; set; }

        public string Town { get; set; }

        public ParseUser Creator { get; set; }

        public DateTime DateOfEvent { get; set; }        
    }
}

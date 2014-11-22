using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Parse;
using WorkTogether.Models;
using System.Linq;
namespace WorkTogether.ViewModels
{
    public class SearchPageViewModel:ViewModelBase
    {
        private ObservableCollection<AdViewModel> ads;
        private bool initializing;


        public SearchPageViewModel()
        {
            this.LoadAds();
        }

        private async Task LoadAds()
        {
            this.Initializing = true;
            // Loader
            var ads = await new ParseQuery<AdModel>()
                .FindAsync();

            this.Ads = ads.AsQueryable().Select(AdViewModel.FromModel);
            this.Initializing = false;
        }

        public bool Initializing
        {
            get
            {
                return this.initializing;
            }
            set
            {
                this.initializing = value;
                this.RaisePropertyChanged(() => this.Initializing);
            }
        }
        public IEnumerable<AdViewModel> Ads
        {
            get
            {
                if (this.ads == null)
                {
                    this.ads = new ObservableCollection<AdViewModel>();
                }
                return this.ads;
            }
            set
            {
                if (this.ads == null)
                {
                    this.ads = new ObservableCollection<AdViewModel>();
                }
                this.ads.Clear();
                foreach (var item in value)
                {
                    this.ads.Add(item);
                }
            }
        }
    }
}

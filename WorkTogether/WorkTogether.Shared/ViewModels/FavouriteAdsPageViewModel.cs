using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

using GalaSoft.MvvmLight;
using SQLite;

using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class FavouriteAdsPageViewModel : ViewModelBase
    {
        private const string dbName = "Database.db";
        private ObservableCollection<FavouriteAdViewModel> favAds;

        public FavouriteAdsPageViewModel()
        {
            this.LoadDataFromSqlite();
        }

        private async void LoadDataFromSqlite()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);            
            var allArticles = await conn.QueryAsync<FavouriteAd>("SELECT * FROM FavouriteAds");
            this.FavAds = allArticles.AsQueryable().Select(FavouriteAdViewModel.FromModel);            
        }

        public IEnumerable<FavouriteAdViewModel> FavAds
        {
            get
            {
                if (this.favAds == null)
                {
                    this.favAds = new ObservableCollection<FavouriteAdViewModel>();
                }
                return this.favAds;
            }
            set
            {
                if (this.favAds == null)
                {
                    this.favAds = new ObservableCollection<FavouriteAdViewModel>();
                }
                this.favAds.Clear();
                foreach (var item in value)
                {
                    this.favAds.Add(item);
                }
            }
        }
    }
}

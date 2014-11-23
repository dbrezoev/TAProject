using GalaSoft.MvvmLight;
using Parse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WorkTogether.Models;

namespace WorkTogether.ViewModels
{
    public class AdDetailsPageViewModel : ViewModelBase
    {
        private const string dbName = "Favourites.db";
        private AdViewModel adVm;        

        public AdViewModel Ad 
        {
            get
            {
                return this.adVm;
            }
            set
            {
                this.adVm = value;
                this.RaisePropertyChanged(() => this.Ad);
            }
        }

        public async void SaveContact()
        {
            //TODO:add in sqlite
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
            }

            await AddFavouriteAdsAsync();

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var allArticles = await conn.QueryAsync<FavouriteAd>("SELECT * FROM FavouriteAds");
            var count = allArticles.Count;           
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<FavouriteAd>();
        }

        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task AddFavouriteAdsAsync()
        {

            var currentFavouriteAd = new FavouriteAd()
            {
                Title = this.Ad.Title,
                ContactName = this.Ad.Name,
                ContactPhone = this.Ad.Phone
            };

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAsync(currentFavouriteAd);            
        }
    }
}

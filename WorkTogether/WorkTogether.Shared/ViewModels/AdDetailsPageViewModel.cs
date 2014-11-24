using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

using GalaSoft.MvvmLight;
using Parse;

using WorkTogether.Models;
using Windows.UI.Popups;

namespace WorkTogether.ViewModels
{
    public class AdDetailsPageViewModel : ViewModelBase
    {
        private const string dbName = "Db.db";        
        private const string SavedSuccessMessage = "Saved successfully";

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
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
            }

            await AddFavouriteAdsAsync();

            //SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            //var allArticles = await conn.QueryAsync<FavouriteAd>("SELECT * FROM Database");                       
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

        public async void NotifyUser()
        {
            var msgDialog = new MessageDialog(SavedSuccessMessage);
            await msgDialog.ShowAsync();            
        }
    }
}

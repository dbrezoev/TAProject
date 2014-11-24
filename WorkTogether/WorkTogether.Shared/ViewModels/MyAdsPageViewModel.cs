using GalaSoft.MvvmLight;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkTogether.Models;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;

namespace WorkTogether.ViewModels
{
    public class MyAdsPageViewModel : ViewModelBase
    {
        private const string dbName = "Db.db";
        private ObservableCollection<FavouriteAdViewModel> favAds;

        public MyAdsPageViewModel()
        {
            this.LoadDataFromSqlite();
        }

        private async void LoadDataFromSqlite()
        {
            bool dbExists = await CheckDbAsync(dbName);
            if (dbExists)
            {
                SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
                var allArticles = await conn.QueryAsync<FavouriteAd>("SELECT * FROM FavouriteAds");
                this.FavAds = allArticles.AsQueryable().Select(FavouriteAdViewModel.FromModel);
            }
           
            var a = 9;
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
    
        public async Task DeleteFromDb(string parameter)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            var parts = parameter.Split(new char[] { ' ' });
            var name = parts[0];
            var phone = parts[1];
            
            var toBedeleted = await conn.Table<FavouriteAd>().
                Where(x => x.ContactName == name && x.ContactPhone == phone).
                FirstOrDefaultAsync();
            if (toBedeleted != null)
            {
                // Delete record
                await conn.DeleteAsync(toBedeleted);
            }

            var msgDialog = new MessageDialog("Item deleted");
            await msgDialog.ShowAsync();           
        }
    }
}

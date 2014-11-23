using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using Parse;

namespace WorkTogether.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private bool initializing;
        public UserViewModel User { get; set; }

        public LoginPageViewModel()
        {
            this.User = new UserViewModel();            
        }
        public async Task<bool> Login()
        {
            try
            {
                this.Initializing = true;
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);

                return true;
                this.Initializing = false;
                //navigate to other page
            }
            catch (Exception ex)
            {
                return false;
            }
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
    }
}

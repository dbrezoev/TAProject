using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTogether.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        public RegisterPageViewModel()
        {
            this.User = new UserViewModel();
        }

        public UserViewModel User { get; set; }

        public async void RegisterUser()
        {
            var user = new ParseUser();
            user.Username = this.User.Username;
            user.Password = this.User.Password;
            user["PhoneNumber"] = this.User.PhoneNumber;

            await user.SignUpAsync();
        }
    }
}

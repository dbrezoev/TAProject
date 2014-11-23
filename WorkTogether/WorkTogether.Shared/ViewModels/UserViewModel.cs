using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight;
using Parse;

namespace WorkTogether.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private string phoneNumber;
        private string username;
        private string password;

        public UserViewModel()
        {            

        }
        public string Username 
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                this.RaisePropertyChanged(() => this.Username);
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                this.RaisePropertyChanged(() => this.Password);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
                this.RaisePropertyChanged(() => this.PhoneNumber);
            }
        }        
    }
}

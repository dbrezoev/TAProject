using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

using GalaSoft.MvvmLight;
using Parse;
using System.Threading.Tasks;

namespace WorkTogether.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private const string EmptyUsernameMessage = "Username cannot be empty";
        private const string EmptyPasswordMessage = "Password cannot be empty";
        private const string NotFullPasswordMessage = "Your password should be at least 6 letters";
        private const string NotFullUsernameMessage = "Your username should be at least 6 letters";
        private const string TooLongUsernameMessage = "Your username should be no more than 10 letters";
        private const string TooLongPasswordMessage = "Too long password";
        private const string WrongPhoneNumberMessage = "Wrong phone number";
        private const int MinimumPasswordLength = 6;
        private const int MinimumUsernameLength = 6;
        private const int MaximumUsernameLength = 10;
        private const int MaximumPasswordLength = 10;
        private const int NumberOfPhoneDigits = 10; // for Bulgaria

        public RegisterPageViewModel()
        {
            this.User = new UserViewModel();
        }

        public UserViewModel User { get; set; }

        public async Task<bool> RegisterUser()
        {
            string username = this.User.Username;
            string password = this.User.Password;
            string phoneNumber = this.User.PhoneNumber;

            //Validate user input
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                var msgDialog = new MessageDialog(EmptyUsernameMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                var msgDialog = new MessageDialog(EmptyPasswordMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (password.Length < MinimumPasswordLength)
            {
                var msgDialog = new MessageDialog(NotFullPasswordMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (username.Length < MinimumUsernameLength)
            {
                var msgDialog = new MessageDialog(NotFullUsernameMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (username.Length > MaximumUsernameLength)
            {
                var msgDialog = new MessageDialog(TooLongUsernameMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (username.Length > MaximumPasswordLength)
            {
                var msgDialog = new MessageDialog(TooLongPasswordMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else if (phoneNumber[0].ToString() != "0" || phoneNumber[1].ToString() != "8" || phoneNumber.Length != NumberOfPhoneDigits)
            {
                var msgDialog = new MessageDialog(WrongPhoneNumberMessage);
                await msgDialog.ShowAsync();
                return false;
            }
            else
            {
                var user = new ParseUser();
                user.Username = username;
                user.Password = password;
                user["PhoneNumber"] = phoneNumber;

                await user.SignUpAsync();

                return true;
            }
            
        }
    }
}

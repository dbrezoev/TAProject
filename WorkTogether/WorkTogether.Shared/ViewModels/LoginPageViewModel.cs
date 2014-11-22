using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkTogether.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public UserViewModel User { get; set; }

        public LoginPageViewModel()
        {
            this.User = new UserViewModel();            
        }
        public async Task<bool> Login()
        {
            try
            {
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);

                return true;
                //navigate to other page
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkTogether.ViewModels
{
    public class AdDetailsPageViewModel : ViewModelBase
    {
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
    }
}

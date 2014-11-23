using System;
using System.Collections.Generic;
using System.Text;
using WorkTogether.Models;
using Windows.UI.Xaml.Data;

namespace WorkTogether.Converters
{
    public class ContactsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is FavouriteAd))
            {
                throw new ArgumentException();
            }

                var favourite = value as FavouriteAd;
                var result = favourite.ContactName + " - " + favourite.ContactPhone;
                return result;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

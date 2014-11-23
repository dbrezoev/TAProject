using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTogether.Models
{
    [Table("FavouriteAds")]
    public class FavouriteAd
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string ContactName { get; set; }

        [MaxLength(12)]
        public string ContactPhone { get; set; }
    }
}

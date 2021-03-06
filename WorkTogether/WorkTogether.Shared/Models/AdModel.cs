﻿using System;
using System.Collections.Generic;
using System.Text;

using Parse;

namespace WorkTogether.Models
{
    [ParseClassName("Ad")]
    public class AdModel : ParseObject
    {
        [ParseFieldName("Title")]
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Content")]
        public string Content
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("DateOfEvent")]
        public DateTime DateOfEvent
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty<DateTime>(value); }
        }

        [ParseFieldName("Town")]
        public string Town
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("CreatorId")]
        public string Creator
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
         
        [ParseFieldName("PhoneNumber")]
        public string PhoneNumber
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }        
    }
}

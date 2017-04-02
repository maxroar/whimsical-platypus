using System.Collections.Generic;
using System;

namespace BeerBuddy.Models
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string bio { get; set; }
        public int zip { get; set; }
        public string profilePic { get; set; }
    }
}
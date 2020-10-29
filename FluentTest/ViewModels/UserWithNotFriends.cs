using FluentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentTest.ViewModels
{
    public class UserWithNotFriends
    {
        public virtual Developer Developer { get; set; }

        public virtual List<Developer> Not_Friends { get; set; }

        public int selected_ID { get; set; }

    }
}
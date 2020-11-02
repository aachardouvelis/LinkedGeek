using FluentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentTest.ViewModels
{
    public class UserPosted
    {
        public User User { get; set; }
        public Post Post { get; set; }


        public UserPosted()
        {
            switch (User)
            {
                case Developer Dev:

                    break;
            }
        }
    }
}
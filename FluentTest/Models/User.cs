using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    public abstract class User
    {
        [Key]
        public int ID { get; set; }

        //[Display(Name = "Upload File")]
        //[DataType(DataType.Upload)]
        //[NotMapped]
        //public HttpPostedFileBase Image { get; set; }

        

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("[^A - Za - z0 - 9] +")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        private IList<Company> _CompanyFollows;
        
        //private IList<User> _Friends;
        //private IList<User> _Requests;
        private IList<Post> _Posts;
            
        public IList<Company> CompanyFollows
        {
            get
            {
                if (_CompanyFollows == null)
                    _CompanyFollows = new List<Company>();
                return _CompanyFollows;
            }
            set
            {
                _CompanyFollows = value;
            }
        }

        //public virtual IList<User> Friends
        //{
        //    //get;set;
        //    get
        //    {
        //        if (_Friends == null)
        //            _Friends = new List<User>();
        //        return _Friends;
        //    }
        //    set
        //    {
        //        _Friends = value;
        //    }
        //}
        //public virtual IList<User> Requests
        //{
        //    //get; set;
        //    get
        //    {
        //        if (_Requests == null)
        //            _Requests = new List<User>();
        //        return _Requests;
        //    }
        //    set
        //    {
        //        _Requests = value;
        //    }
        //}
        public virtual IList<Post> Posts
        {
            //get; set;
            get
            {
                if (_Posts == null)
                    _Posts = new List<Post>();
                return _Posts;
            }
            set
            {
                _Posts = value;
            }
        }

        public String CurrentPosition { get; set; }
        public bool Follow(Company company)
        {
            if (!CompanyFollows.Any(x => x.ID == company.ID))
            {
                CompanyFollows.Add(company);
                return true;
            }
            return false;
        }

        
       // public void Delete() =>


        public void Unfollow(Company Company) => CompanyFollows=CompanyFollows.Where(F => F.ID != Company.ID).ToList();
    }
}

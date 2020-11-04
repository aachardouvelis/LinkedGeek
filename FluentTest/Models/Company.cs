using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    public class Company 
    {
        public string Name { get; set; }

        public CompanyContactInfo ContactInfo { get; set; }
        [ForeignKey("Address")]
        public Address Address { get; set; }
        public virtual IList<Job> Jobs { get; set; }
        [Key]
        public int ID { get; set; }


        public String CurrentPosition { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("[^A - Za - z0 - 9] +")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        private IList<Company> _CompanyFollows;


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

      
        public virtual IList<Post> Posts
        {
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

        
        public bool Follow(Company company)
        {
            if (!CompanyFollows.Any(x => x.ID == company.ID))
            {
                CompanyFollows.Add(company);
                return true;
            }
            return false;
        }
        public void Unfollow(Company Company) => CompanyFollows = CompanyFollows.Where(F => F.ID != Company.ID).ToList();

    }
}
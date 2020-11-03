using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentTest.Models
{
    public class Developer
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("[^A - Za - z0 - 9] +")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public String CurrentPosition { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DeveloperContactInfo ContactInfo { get; set; }
        public DeveloperAddress Address { get; set; }

        private IList<Company> _CompanyFollows;
        private List<Developer> _DeveloperFollows;
        private IList<DeveloperPost> _Posts;
        public List<Developer> DeveloperFollows {
            get
            {
                if (_DeveloperFollows == null)
                    _DeveloperFollows = new List<Developer>();
                return _DeveloperFollows; 
            }
            set
            {
                _DeveloperFollows = value;
            }
        }
        
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

        
        public virtual IList<DeveloperPost> Posts
        {
            //get; set;
            get
            {
                if (_Posts == null)
                    _Posts = new List<DeveloperPost>();
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
        public bool Follow(Developer Developer)
        {
            if (!DeveloperFollows.Any(x => x.ID == Developer.ID))
            {
                DeveloperFollows.Add(Developer);
                return true;
            }
            return false;
        }
        public void Unfollow(Company Company) => CompanyFollows = CompanyFollows.Where(F => F.ID != Company.ID).ToList();
        public void Unfollow(Developer Developer) => DeveloperFollows = DeveloperFollows.Where(F => F.ID != Developer.ID).ToList();
    }
}

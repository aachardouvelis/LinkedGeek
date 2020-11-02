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
    [Table("Developer")]
    public class Developer:User
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DeveloperContactInfo ContactInfo { get; set; }
        public DeveloperAddress Address { get; set; }

        private List<Developer> _DeveloperFollows;
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

        public bool Follow(Developer Developer)
        {
            if (!DeveloperFollows.Any(x => x.ID == Developer.ID))
            {
                DeveloperFollows.Add(Developer);
                return true;
            }
            return false;
        }


        // public void Delete() =>


        public void Unfollow(Developer Developer) => DeveloperFollows = DeveloperFollows.Where(F => F.ID != Developer.ID).ToList();
    }
}

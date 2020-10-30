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
    public abstract class User
    {
        [Key]
        public int ID { get; set; }

        //[Display(Name = "Upload File")]
        //[DataType(DataType.Upload)]
        //[NotMapped]
        //public HttpPostedFileBase Image { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("[^A - Za - z0 - 9] +")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        private IList<User> _Friends;
        private IList<User> _Requests;
        private IList<Post> _Posts;
        public virtual IList<User> Friends
        {
            //get;set;
            get
            {
                if (_Friends == null)
                    _Friends = new List<User>();
                return _Friends;
            }
            set
            {
                _Friends = value;
            }
        }
        public virtual IList<User> Requests
        {
            //get; set;
            get
            {
                if (_Requests == null)
                    _Requests = new List<User>();
                return _Requests;
            }
            set
            {
                _Requests = value;
            }
        }
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


        public bool AddFriend(User friend)
        {
            if (!Friends.Any(x => x.ID == friend.ID))
            {
                Friends.Add(friend);
                friend.Friends.Add(this);
                return true;
            }
            return false;
        }

        public bool RequestFriend(User friend)
        {
            if (friend.Requests.Any(f => f.ID == friend.ID))
                return false;

            friend.Requests.Add(this);
            return true;
        }

        public void Delete() => Friends.ForEach(F => F.RemoveFriend(this));


        public void RemoveFriend(User friend) => Friends = Friends.Where(F => F.ID != friend.ID).ToList();
    }
}

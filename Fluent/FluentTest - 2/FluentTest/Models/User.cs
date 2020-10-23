using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.Models
{
    public abstract class User
    {
        [Key]
        public int ID { get; set; }

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
        public ICollection<User> Friends { get; set; }
        public ICollection<User> Requests { get; set; }
        public ICollection<Post> Posts { get; set; }


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

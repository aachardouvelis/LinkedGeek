using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.Models
{
    public interface IUser
    {
        [Key]
        int ID { get; set; }

        [StringLength(50)]
        string FirstName { get; set; }
        [StringLength(50)]
        string LastName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        string Email { get; set; }

        [RegularExpression("[^A - Za - z0 - 9] +")]
        [DataType(DataType.Password)]
        string Password { get; set; }
        ICollection<IUser> Friends { get; set; }
        ICollection<IUser> Requests { get; set; }


        bool AddFriend(IUser friend);

        bool RequestFriend(IUser friend);
        void Delete();


        void RemoveFriend(IUser friend);
    }
}

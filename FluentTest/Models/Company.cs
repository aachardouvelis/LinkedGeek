using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    [Table("Companies")]
    public class Company : User
    {
        public virtual IList<Job> Jobs { get; set; }
        public Company()
        {
            Friends = new List<User>();
            Posts = new List<Post>();
            Jobs = new List<Job>();
        }


    }
}
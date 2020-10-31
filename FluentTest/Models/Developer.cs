using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    [Table("Developers")]
    public class Developer : User
    {
        public Developer()
        {
            //Friends = new List<User>();
            //Requests = new List<User>();
            //Posts = new List<Post>();
            
        }

        //[DataType(DataType.Date)]
        //public DateTime BirthDate { get; set; }
        public String CurrentPosition { get; set; }
    }
}
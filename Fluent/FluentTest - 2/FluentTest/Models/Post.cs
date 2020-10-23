using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    public class Post
    {

        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }


    }
}
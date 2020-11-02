using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    public class DeveloperContactInfo
    {
        public int ID { get;set; }
        public int DeveloperID { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
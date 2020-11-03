using System;
using System.ComponentModel.DataAnnotations;

namespace FluentTest.Models
{
    public class CompanyPost
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public string Content { get; set; }

        public Company Company { get; set; }

    }
}
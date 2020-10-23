using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FluentTest.Models
{
    public class Job
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Company")]
        public virtual int CompanyID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }


        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public virtual Company Company { get; set; }

        //public virtual ICollection<Developer> Applicants { get; set; }
    }
}
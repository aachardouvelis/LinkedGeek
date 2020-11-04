using System.ComponentModel.DataAnnotations.Schema;

namespace FluentTest.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string StreetName { get; set; }
        public short StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [ForeignKey("Developer")]
        public Developer Developer { get; set; }

        [ForeignKey("Company")]
        public Company Company { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace FluentTest.Models
{
    public class Post
    {
        public Post(int iD, DateTime datePosted, string content, Company company=null, Developer developer=null)
        {
            if ((company != null && developer != null) || (company == null & developer == null))
                throw new ArgumentException("Can only initiate a Post object with either a company or a developer. Can't initialize with none or both");
            ID = iD;
            DatePosted = datePosted;
            Content = content;
            Company = company;
            Developer = developer;
            
        }
       public Post() { }
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public string Content { get; set; }

        public string Author
        {
            get
            {
                if (Company != null)
                    return Company.Name;
                else if (Developer != null)
                    return Developer.FirstName + " " + Developer.LastName;
                else
                    throw new InvalidOperationException("A Company Nor a Developer has been initialised. Can't access Authoer of Post");
            }
            
        }

        public Company Company { get; set; }
        public Developer Developer { get; set; }
    }
}
using FluentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentTest.ViewModels
{
    public interface IUserPosted
    {

        string GetAuthor();
        string GetContent();
        DateTime getDatePosted();
        object getPosterObject();



    }
    public class DeveloperPosted : IUserPosted
    {
        private Developer Developer { get; set; }
        public DeveloperPost Post { get; set; }

        public string GetAuthor()
        {
            return Developer.FirstName + " " + Developer.LastName;
        }

        public string GetContent()
        {
            return Post.Content;
        }

        public DateTime getDatePosted()
        {
            return Post.DatePosted;
        }

        public object getPosterObject()
        {
            return Developer;
        }
    }

    public class CompanyPosted : IUserPosted
    {
        public Company Company { get; set; }
        public CompanyPost Post { get; set; }

        public string GetAuthor()
        {
            return Company.
        }

        public string GetContent()
        {
            throw new NotImplementedException();
        }

        public DateTime getDatePosted()
        {
            throw new NotImplementedException();
        }

        public object getPosterObject()
        {
            throw new NotImplementedException();
        }
    }
}
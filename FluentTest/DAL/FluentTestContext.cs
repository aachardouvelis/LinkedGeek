using FluentTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FluentTest.DAL
{
    public class FluentTestContext: DbContext
    {
        public FluentTestContext() : base("FluentTestContext") { } 
        //public DbSet<Developer> Developers { get; set; }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
            .HasMany(D => D.CompanyFollows)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("User_ID");
                m.MapRightKey("Company_ID");
                m.ToTable("CompanyFollows");
            });

            modelBuilder.Entity<Developer>()
            .HasMany(D => D.DeveloperFollows)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("Developer_ID");
                m.MapRightKey("Developer2_ID");
                m.ToTable("DeveloperFollows");
            });

            modelBuilder.Entity<User>()
           .HasMany(D => D.Posts)
           .WithRequired(P => P.User);

            //modelBuilder.Entity<User>()
            //.HasMany(D => D.Posts)
            //.WithMany()
            //.Map(m =>
            //{
            //    m.MapLeftKey("Dev_ID");
            //    m.MapRightKey("Post_ID");
            //    m.ToTable("User_Posts");
            //});

            //modelBuilder.Entity<User>()
            //   .HasMany(D => D.Requests)
            //   .WithMany()
            //   .Map(m =>
            //   {
            //       m.MapLeftKey("Dev_ID");
            //       m.MapRightKey("Requester_ID");
            //       m.ToTable("User_Requests");
            //   });

        }


    }
}
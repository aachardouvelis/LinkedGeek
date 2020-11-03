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

        public DbSet<DeveloperPost> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>()
            .HasMany(D => D.CompanyFollows)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("Company_ID");
                m.MapRightKey("Company_ID");
                m.ToTable("CompanyFollowCompany");
            });
            modelBuilder.Entity<Developer>()
            .HasMany(D => D.CompanyFollows)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("Developer_ID");
                m.MapRightKey("Company_ID");
                m.ToTable("DeveloperFollowCompany");
            });

            modelBuilder.Entity<Developer>()
            .HasMany(D => D.DeveloperFollows)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("Developer_ID");
                m.MapRightKey("Developer2_ID");
                m.ToTable("DeveloperFollowDeveloper");
            });

            modelBuilder.Entity<Developer>()
           .HasMany(D => D.Posts)
           .WithRequired(P => P.Developer);

            modelBuilder.Entity<Company>()
           .HasMany(D => D.Posts)
           .WithRequired(P => P.Company);

            
        }


    }
}
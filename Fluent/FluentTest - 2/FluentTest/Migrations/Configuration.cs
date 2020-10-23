namespace FluentTest.Migrations
{
    using FluentTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FluentTest.DAL.FluentTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FluentTest.DAL.FluentTestContext context)
        {

            var Developers = new List<Developer>()
            {
                new Developer
                {
                    FirstName="Alex",
                    LastName="Chardouvelis"
                },
            new Developer
                {

                    FirstName="Alex",
                    LastName="Mavridis"
                },
            new Developer
                {

                    FirstName="George",
                    LastName="Dermetzis"
                },
            new Developer
                {
                    FirstName="George",
                    LastName="Nikolakeas",
                    Friends=new List<User>{new Developer { LastName="NIKOLAKEAS"} },
                    Posts=new List<Post>{new Post(){DatePosted=new DateTime(2000,10,3)}
                    }
                    
                }
            };

            
            Developer friend = new Developer { FirstName = "FRETTI",LastName="FRETTIUS", Friends = new List<User> { Developers[0], Developers[1] } };
            Developer friend2 = new Developer { FirstName = "SPAGETTI" };
            Developer friend3 = new Developer { FirstName = "VINCETTI" };


            Developers.ForEach(Dev => Dev.Friends = new List<User> { friend, friend2, friend3 });
            Developers.ForEach(Dev => context.Developers.AddOrUpdate(p => p.ID, Dev));
            context.SaveChanges();
        }
    }
}

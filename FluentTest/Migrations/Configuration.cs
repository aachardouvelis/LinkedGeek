namespace FluentTest.Migrations
{
    using FluentTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
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
                    LastName="Chardouvelis",
                    CurrentPosition="Front End Software Engineer at PALIATSOS A.E.",
                    //BirthDate=new DateTime(1993,10,03,0,0,0),
                    Posts=new List<Post>{
                        new Post
                        {
                            DatePosted=new DateTime(2020,10,23,10,0,0),
                            Content="it hurts my feelings when people bask in a torrential downpour of trees? "
                        },
                    new Post
                        {
                            DatePosted=new DateTime(2020,10,23,10,10,0),
                            Content="i love to pass the Deadly Five Trials Of Horror And disease"
                        },
                    new Post
                        {
                            DatePosted=new DateTime(2020,10,23,12,30,0),
                            Content="its hard to relax when all u wanna do is contour the face of blood worms?"
                        }
                    }
                },
            new Developer
                {

                    FirstName="Alex",
                    LastName="Mavridis",
                    CurrentPosition="Software Engineer at Pfizer",
                    //BirthDate=new DateTime(1996,11,05,0,0,0),
                    Posts=new List<Post>{
                        new Post
                        {
                            DatePosted=new DateTime(2020,10,23,10,5,0),
                            Content="my beak is my most beautiful feature. i use it to popularize sonic the hedgehog"
                        }
                    }
                },
            new Developer
                {
                    CurrentPosition="Full Stack Dev",
                    //BirthDate=new DateTime(1999,2,12,0,0,0),
                    FirstName="George",
                    LastName="Dermetzis"
                },
            new Developer
                {
                    FirstName="George",
                    LastName="Nikolakeas",
                    CurrentPosition="AI scientist at Imperial, University of London",
                    //BirthDate=new DateTime(2002,11,11,0,0,0),
                    Posts=new List<Post>{
                        new Post
                        {
                            DatePosted=new DateTime(2020,10,23,10,10,0),
                            Content="this post generator is alright i guess but if i could be doing anything right now i would rather emulate homestuck"
                        }

                    }

                }
            };


            Developer friend = new Developer
            {
                FirstName = "FRETTI",
                LastName = "FRETTIUS",
                Posts = new List<Post>() {
                new Post {
                    Content="FRETI'S POST.. IM POSTING AND IM FRETTI LOL",
                    DatePosted=new DateTime(2020,10,23,10,5,0)
                    }
                }
            };
            Developer friend2 = new Developer { FirstName = "SPAGETTI" };
            Developer friend3 = new Developer { FirstName = "VINCETTI" };

            foreach (var dev in Developers)
            {
                //dev.AddFriend(friend);
                //        //dev.AddFriend(friend2);
                //        //dev.AddFriend(friend3);

                dev.DeveloperFollows.Add(friend);
                friend.DeveloperFollows.Add(dev);

                dev.DeveloperFollows.Add(friend2);
                friend2.DeveloperFollows.Add(dev);

                dev.DeveloperFollows.Add(friend3);
                friend3.DeveloperFollows.Add(dev);

            }


            //var chard= Developers.Find(d => d.ID == 1);
            //var nikol = Developers.Find(d => d.ID == 5);
            //chard.AddFriend(nikol);
            //Developers[0].AddFriend(Developers[3]); // WHAT. THE. FUCK.



            //Developers.ForEach(Dev => Dev.Friends = new List<User> { friend, friend2, friend3 });
            Developers.ForEach(Dev => context.Developers.AddOrUpdate(p => p.ID, Dev));
            context.SaveChanges();
        }
        //protected override void Seed(FluentTest.DAL.FluentTestContext context)
        //{

        //    var Developers = new List<Developer>()
        //    {
        //        new Developer
        //        {
        //            //ID=1,
        //            FirstName="Alex",
        //            LastName="Chardouvelis",
        //            Posts={
        //                new Post
        //                {
        //                    DatePosted=new DateTime(2020,10,23,10,0,0),
        //                    Content="it hurts my feelings when people bask in a torrential downpour of trees? "
        //                },
        //            new Post
        //                {
        //                    DatePosted=new DateTime(2020,10,23,10,10,0),
        //                    Content="i love to pass the Deadly Five Trials Of Horror And disease"
        //                },
        //            new Post
        //                {
        //                    DatePosted=new DateTime(2020,10,23,12,30,0),
        //                    Content="its hard to relax when all u wanna do is contour the face of blood worms?"
        //                }
        //            }
        //        },
        //        new Developer
        //            {
        //                //ID=2,
        //                FirstName="Alex",
        //                LastName="Mavridis",
        //                Posts={
        //                    new Post
        //                    {
        //                        DatePosted=new DateTime(2020,10,23,10,5,0),
        //                        Content="my beak is my most beautiful feature. i use it to popularize sonic the hedgehog"
        //                    }
        //                }
        //            },
        //        new Developer
        //            {
        //                //ID=3,
        //                FirstName="George",
        //                LastName="Dermetzis"
        //            },
        //        new Developer
        //            {
        //                //ID=4,
        //                FirstName="George",
        //                LastName="Nikolakeas",
        //                Posts={
        //                    new Post
        //                    {
        //                        DatePosted=new DateTime(2020,10,23,10,10,0),
        //                        Content="this post generator is alright i guess but if i could be doing anything right now i would rather emulate homestuck"
        //                    }

        //                }

        //            }
        //    };


        //    Developer friend = new Developer {
        //        //ID = 5,
        //        FirstName = "FRETTI", LastName = "FRETTIUS", 
        //        Posts = {
        //        new Post {
        //            Content="FRETI'S POST.. IM POSTING AND IM FRETTI LOL",
        //            DatePosted=new DateTime(2020,10,23,10,5,0)
        //            }
        //        }
        //    };
        //    Developer friend2 = new Developer { //ID = 6,
        //        LastName = "SPAGETTI" };
        //    Developer friend3 = new Developer {// ID = 7,
        //        LastName = "VINCETTI" };

        //    foreach (var dev in Developers)
        //    {
        //        //dev.AddFriend(friend);
        //        //dev.AddFriend(friend2);
        //        //dev.AddFriend(friend3);

        //        dev.Friends.Add(friend);
        //        friend.Friends.Add(dev);

        //        dev.Friends.Add(friend);
        //        friend.Friends.Add(dev);

        //        dev.Friends.Add(friend);
        //        friend.Friends.Add(dev);

        //    }


        //    //var chard= Developers.Find(d => d.ID == 1);
        //    //var nikol = Developers.Find(d => d.ID == 5);
        //    //chard.AddFriend(nikol);
        //    //Developers[0].AddFriend(Developers[3]); // WHAT. THE. FUCK.



        //    //Developers.ForEach(Dev => Dev.Friends = new List<User> { friend, friend2, friend3 });
        //    Developers.ForEach(Dev => context.Developers.AddOrUpdate(p => p.ID, Dev));
        //    context.SaveChanges();
        //}
    }
}

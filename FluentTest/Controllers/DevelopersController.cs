using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FluentTest.DAL;
using FluentTest.Models;
using FluentTest.ViewModels;

namespace FluentTest.Controllers
{
    public class DevelopersController : Controller
    {
        private FluentTestContext db = new FluentTestContext();

        // GET: Developers
        public ActionResult Index()
        {
            var Developers = db.Developers.ToList();//.Include(i => i.Friends).Include(i=>i.Posts).ToList();
           
            
            return View(Developers);
            //return View(db.Developers.ToList());
        }

        public ActionResult Network(int? id)
        {

            var Developers = db.Developers.ToList();//.Include(i => i.DeveloperFollows).Include(i => i.Posts).ToList();
            return View(Developers); 
        }

       

        public ActionResult ViewFeed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Dev = db.Developers.Include(i => i.Posts).Include(i => i.DeveloperFollows.Select(f => f.Posts)).Where(i => i.ID == id).Single() ;

            List<UserPosted> Dev_Feed = new List<UserPosted>();
            //add to Dev_Feed each individual Post with its User that makes a User's feed.

            //first add his own Posts
            foreach (var post in Dev.Posts)
                Dev_Feed.Add(new UserPosted { User = Dev, Post = post });
            //Then add all of his Friend's Posts
            foreach (var friend in Dev.DeveloperFollows)
                foreach (var post in friend.Posts)
                    Dev_Feed.Add(new UserPosted { User = friend, Post = post });

            //Order the feed by date posted..
            Dev_Feed=Dev_Feed.OrderByDescending(P => P.Post.DatePosted).ToList();
            return View(Dev_Feed);
        }

        // GET: Developers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // GET: Developers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Password")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                db.Developers.Add(developer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

        // GET: Developers/Edit/5
        //public ActionResult Edit(int? id)
        //{   
           
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Developer developer1 = db.Developers.Find(id);
        //    Developer developer = db.Developers.Include(i => i.Friends).Include(i => i.Posts).Include(i => i.Requests).Where(D => D.ID == id).Single();
        //    if (developer == null)
        //        return HttpNotFound();
        //    var friends = developer.Friends;
        //    ViewBag.FriendsSelList = new SelectList(developer.Friends.ToList(), "ID", "LastName", developer.ID);
        //    return View(developer);
        //}

        

        // POST: Developers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name")] Developer developer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(developer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(developer);
        //}

        // GET: Developers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Developer developer = db.Developers.Find(id);
            db.Developers.Remove(developer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

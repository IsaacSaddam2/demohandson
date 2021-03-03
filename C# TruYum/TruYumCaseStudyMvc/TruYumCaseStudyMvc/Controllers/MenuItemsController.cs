using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruYumCaseStudyMvc.Models;

namespace TruYumCaseStudyMvc.Controllers
{
    public class MenuItemsController : Controller
    {
        private truYumContext db = new truYumContext();


    
        // GET: MenuItems
        public ActionResult Index()
        {

            bool isAdmin = false;
            isAdmin = Convert.ToBoolean(Request.QueryString["isAdmin"]);
            ViewBag.isAdmin = isAdmin;

            if (isAdmin == true)
            {
                var menuItems = db.MenuItems.Include(m => m.GetCategory);
                return View(menuItems.ToList());
            }
            else
            {
                //var menuItems = db.MenuItems.Include(m => m.GetCategory).Where(c => c.Active == true);
                var menuItems = db.MenuItems.Include(m => m.GetCategory).Where(c => (c.Active == true && c.Dof<DateTime.Now));

                return View(menuItems.ToList());
            }
        }

       /* [HttpPost]
        public ActionResult Index(bool isAdmin)
        {
            bool isadmin = false;
            ViewBag.IsAdmin = isAdmin;
             
            if(Id==1)
            {

                var menuItems = db.MenuItems.Include(m => m.GetCategory);
                return View(menuItems.ToList());
            }
            else
            {
                var menuItems = db.MenuItems.Include(m => m.GetCategory).Where(c => c.Active == true);
            
                return View(menuItems.ToList());

            }
        }*/

        // GET: MenuItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Active,Dof,free,CategoryId")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", menuItem.CategoryId);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", menuItem.CategoryId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Active,Dof,free,CategoryId")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", menuItem.CategoryId);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuItem);
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

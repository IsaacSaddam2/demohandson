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
    public class CartsController : Controller
    {
        private truYumContext db = new truYumContext();

        // GET: Carts
        public ActionResult AddCart(int id)
        {
            Cart c = new Cart() { MenuItemId = id };
            db.Carts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Carts");
        }
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.GetMenuItem);
            return View(carts.ToList());
        }


          // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
           
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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

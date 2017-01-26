using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hummelManager.Models;
using hummelManager.blobHandler;

namespace hummelManager.Controllers
{
    public class HummelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hummels
        [Authorize(Roles = "canEdit")]
        public ActionResult Index()
        {
            return View(db.Hummels.ToList());
        }

        // GET: Hummels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hummel hummel = db.Hummels.Find(id);
            if (hummel == null)
            {
                return HttpNotFound();
            }
            return View(hummel);
        }

        // GET: Hummels/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hummels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "hummelId,name,trademark,description,fileLoc,active")] Hummel hummel)
        {
            if (ModelState.IsValid)
            {
                db.Hummels.Add(hummel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hummel);
        }

        // GET: Hummels/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hummel hummel = db.Hummels.Find(id);
            if (hummel == null)
            {
                return HttpNotFound();
            }
            return View(hummel);
        }

        // POST: Hummels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "hummelId,name,trademark,description,fileLoc,active")] Hummel hummel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hummel).State = EntityState.Modified;
                db.SaveChanges();

                BlobHandler bh = new BlobHandler(file.FileName);
                
              
                return RedirectToAction("Index");
            }
            return View(hummel);
        }

        // GET: Hummels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hummel hummel = db.Hummels.Find(id);
            if (hummel == null)
            {
                return HttpNotFound();
            }
            return View(hummel);
        }

        // POST: Hummels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hummel hummel = db.Hummels.Find(id);
            db.Hummels.Remove(hummel);
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

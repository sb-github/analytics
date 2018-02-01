using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportingDataBase.Models;
using ReportingDataBase.DAL.MySQL;

namespace DataBaseAnalytics.Controllers
{
    public class PlatformSkillsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: PlatformSkills
        public ActionResult Index()
        {
            return View(db.PlatformSkills.ToList());
        }

        // GET: PlatformSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformSkill platformSkill = db.PlatformSkills.Find(id);
            if (platformSkill == null)
            {
                return HttpNotFound();
            }
            return View(platformSkill);
        }

        // GET: PlatformSkills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatformSkills/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,image,difficulty,description,created_at,updated_at")] PlatformSkill platformSkill)
        {
            if (ModelState.IsValid)
            {
                db.PlatformSkills.Add(platformSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platformSkill);
        }

        // GET: PlatformSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformSkill platformSkill = db.PlatformSkills.Find(id);
            if (platformSkill == null)
            {
                return HttpNotFound();
            }
            return View(platformSkill);
        }

        // POST: PlatformSkills/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,image,difficulty,description,created_at,updated_at")] PlatformSkill platformSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platformSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platformSkill);
        }

        // GET: PlatformSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatformSkill platformSkill = db.PlatformSkills.Find(id);
            if (platformSkill == null)
            {
                return HttpNotFound();
            }
            return View(platformSkill);
        }

        // POST: PlatformSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatformSkill platformSkill = db.PlatformSkills.Find(id);
            db.PlatformSkills.Remove(platformSkill);
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

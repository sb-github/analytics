using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportingDataBase.DAL;
using ReportingDataBase.Models;

namespace DataBaseAnalytics.Controllers
{
    public class ReportingSkillsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ReportingSkills
        public ActionResult Index()
        {
            var reportingSkills = db.ReportingSkills.Include(r => r.CurrentSkill);
            return View(reportingSkills.ToList());
        }

        // GET: ReportingSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingSkills reportingSkills = db.ReportingSkills.Find(id);
            if (reportingSkills == null)
            {
                return HttpNotFound();
            }
            return View(reportingSkills);
        }

        // GET: ReportingSkills/Create
        public ActionResult Create()
        {
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "SkillName");
            return View();
        }

        // POST: ReportingSkills/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReportingDate,SkillID,Count,CreatedDate,UpdatedDate")] ReportingSkills reportingSkills)
        {
            if (ModelState.IsValid)
            {
                db.ReportingSkills.Add(reportingSkills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillID = new SelectList(db.Skills, "ID", "SkillName", reportingSkills.SkillID);
            return View(reportingSkills);
        }

        // GET: ReportingSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingSkills reportingSkills = db.ReportingSkills.Find(id);
            if (reportingSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "SkillName", reportingSkills.SkillID);
            return View(reportingSkills);
        }

        // POST: ReportingSkills/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReportingDate,SkillID,Count,CreatedDate,UpdatedDate")] ReportingSkills reportingSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportingSkills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "SkillName", reportingSkills.SkillID);
            return View(reportingSkills);
        }

        // GET: ReportingSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingSkills reportingSkills = db.ReportingSkills.Find(id);
            if (reportingSkills == null)
            {
                return HttpNotFound();
            }
            return View(reportingSkills);
        }

        // POST: ReportingSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportingSkills reportingSkills = db.ReportingSkills.Find(id);
            db.ReportingSkills.Remove(reportingSkills);
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

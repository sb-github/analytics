using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportingDataBase.DAL;
using ReportingDataBase.DAL.SQL;
using ReportingDataBase.Models;

namespace DataBaseAnalytics.Controllers
{
    public class SkillsController : Controller
    {
        UnitOfWork unity = new UnitOfWork();
        //private DatabaseContext db = new DatabaseContext();
        //private SkillRepository repo=new SkillRepository();

        // GET: Skills
        public ActionResult Index()
        {

            return View(unity.SkillRepository.GetAll().ToList());
            //return View(repo.GetAll());
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Skill skill = repo.Get(id.Value);
            Skill skill = unity.SkillRepository.GetById(id.Value);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SkillName,CreatedDate,UpdatedDate")] Skill skill)
        {
            if (ModelState.IsValid)
            {

                unity.SkillRepository.Create(skill);

                return RedirectToAction("Index");
            }

            return View(skill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Skill skill = repo.Get(id.Value);
            Skill skill = unity.SkillRepository.GetById(id.Value);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SkillName,CreatedDate,UpdatedDate")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                //repo.Edit(skill);
                unity.SkillRepository.Update(skill);

                return RedirectToAction("Index");
            }
            return View(skill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Skill skill = repo.Get(id.Value);
            Skill skill = unity.SkillRepository.GetById(id.Value);
            unity.SkillRepository.Remove(skill);
            return RedirectToAction("Index");
        }




    }
}
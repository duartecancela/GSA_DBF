using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_DBF.Models;

namespace GSA_DBF.Areas.Alunos.Controllers
{
    public class UCsController : Controller
    {
        private gsa_dbaEntities1 db = new gsa_dbaEntities1();

        // GET: Alunos/UCs
        public ActionResult Index()
        {
            return View(db.UC.ToList());
        }

        // GET: Alunos/UCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UC uC = db.UC.Find(id);
            if (uC == null)
            {
                return HttpNotFound();
            }
            return View(uC);
        }

        // GET: Alunos/UCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/UCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] UC uC)
        {
            if (ModelState.IsValid)
            {
                db.UC.Add(uC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uC);
        }

        // GET: Alunos/UCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UC uC = db.UC.Find(id);
            if (uC == null)
            {
                return HttpNotFound();
            }
            return View(uC);
        }

        // POST: Alunos/UCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] UC uC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uC);
        }

        // GET: Alunos/UCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UC uC = db.UC.Find(id);
            if (uC == null)
            {
                return HttpNotFound();
            }
            return View(uC);
        }

        // POST: Alunos/UCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UC uC = db.UC.Find(id);
            db.UC.Remove(uC);
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

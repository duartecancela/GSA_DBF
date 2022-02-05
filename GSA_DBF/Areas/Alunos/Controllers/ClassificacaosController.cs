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
    public class ClassificacaosController : Controller
    {
        private gsa_dbaEntities1 db = new gsa_dbaEntities1();

        // GET: Alunos/Classificacaos
        public ActionResult Index()
        {
            var classificacao = db.Classificacao.Include(c => c.Aluno).Include(c => c.Epoca).Include(c => c.UC);
            return View(classificacao.ToList());
        }

        // GET: Alunos/Classificacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacao.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Create
        public ActionResult Create()
        {
            ViewBag.id_aluno = new SelectList(db.Aluno, "Id", "nome");
            ViewBag.id_epoca = new SelectList(db.Epoca, "Id", "nome");
            ViewBag.id_uc = new SelectList(db.UC, "Id", "nome");
            return View();
        }

        // POST: Alunos/Classificacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,id_aluno,id_uc,id_epoca,nota,obs")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Classificacao.Add(classificacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_aluno = new SelectList(db.Aluno, "Id", "nome", classificacao.id_aluno);
            ViewBag.id_epoca = new SelectList(db.Epoca, "Id", "nome", classificacao.id_epoca);
            ViewBag.id_uc = new SelectList(db.UC, "Id", "nome", classificacao.id_uc);
            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacao.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "Id", "nome", classificacao.id_aluno);
            ViewBag.id_epoca = new SelectList(db.Epoca, "Id", "nome", classificacao.id_epoca);
            ViewBag.id_uc = new SelectList(db.UC, "Id", "nome", classificacao.id_uc);
            return View(classificacao);
        }

        // POST: Alunos/Classificacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,id_aluno,id_uc,id_epoca,nota,obs")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classificacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "Id", "nome", classificacao.id_aluno);
            ViewBag.id_epoca = new SelectList(db.Epoca, "Id", "nome", classificacao.id_epoca);
            ViewBag.id_uc = new SelectList(db.UC, "Id", "nome", classificacao.id_uc);
            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacao.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            return View(classificacao);
        }

        // POST: Alunos/Classificacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classificacao classificacao = db.Classificacao.Find(id);
            db.Classificacao.Remove(classificacao);
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

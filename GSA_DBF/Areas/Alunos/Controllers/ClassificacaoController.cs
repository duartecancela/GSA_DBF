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
    public class ClassificacaoController : Controller
    {
        private gsa_dbaEntities1 db = new gsa_dbaEntities1();

        // GET: Alunos/Classificacao
        public ActionResult Index()
        {
            var classificacao = db.Classificacao.Include(c => c.Aluno).Include(c => c.Epoca).Include(c => c.UC);
            return View(classificacao.ToList());
        }

        //[HttpPost]
        public ActionResult AverageResult(FormCollection form)
        {
            //var disciplina = "DAW";
            var disciplina = form["disciplina"].ToString();
            var epoca = form["epoca"].ToString();
            var idUc = db.UC.Where(u => u.nome.Contains(disciplina)).SingleOrDefault()?.Id;
            var idEpoca = db.Epoca.Where(u => u.nome.Contains(epoca)).SingleOrDefault()?.Id;

            var classificacao = db.Classificacao.Where(c => c.id_uc == idUc).Where(c => c.id_epoca == idEpoca);

            var cl = classificacao.ToList();
            var count = classificacao.Count();
            var sum = classificacao.Sum(x => x.nota);
            ViewBag.Total = sum / count;

            return View(cl);
            
        }

        /*[HttpPost]
        public ActionResult AverageInput(FormCollection form)
        {
            string strDisciplina = form["disciplina"].ToString();
            ViewBag.disciplina = strDisciplina;
            //var classificacao = db.Classificacao.Where(c => c.id_uc == 1);
            //return View(classificacao.ToList());
            return View();
        }*/

        [HttpGet]
        public ActionResult AverageInput()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Average(FormCollection form)
        {
            string strDisciplina = form["disciplina"].ToString();
            ViewBag.disciplina = strDisciplina;
            //var classificacao = db.Classificacao.Where(c => c.id_uc == 1);
            //return View(classificacao.ToList());
            return View();
        }
    }
}
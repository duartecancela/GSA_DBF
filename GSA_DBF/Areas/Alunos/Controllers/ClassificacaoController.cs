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

        public ActionResult Average()
        {
            var classificacao = db.Classificacao.Where(c => c.id_uc == 1);
            return View(classificacao.ToList());
        }
    }
}
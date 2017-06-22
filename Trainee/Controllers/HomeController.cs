using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee.Models;
using Trainee.Business;

namespace Trainee.Controllers
{
    public class HomeController : Controller
    {
        private CadastroBusiness cadastroBusiness = new CadastroBusiness();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(cadastro dados)
        {
            try
            {
                cadastroBusiness.NovoCadastro(dados);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(404, ex.Message);
            }

            return Json(dados, JsonRequestBehavior.AllowGet);
        }
    }
}
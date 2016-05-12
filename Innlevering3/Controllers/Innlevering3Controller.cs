using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innlevering3.Models;

namespace Innlevering3.Controllers
{
    public class Innlevering3Controller : Controller
    {
        // GET: Innlevering3
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisAlleHenvendelser()
        {
            try
            {
                using (Innlevering3DatabaseEntities innlevering3DBTilkobling = new Innlevering3DatabaseEntities())
                {
                    var henvendelserListe = (from henvendelser in innlevering3DBTilkobling.Henvendelser
                                     select henvendelser).ToList();

                    return View(henvendelserListe);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult VisAlleAnsatte()
        {
            try
            {
                using (Innlevering3DatabaseEntities innlevering3DBTilkobling = new Innlevering3DatabaseEntities())
                {
                    var ansatteListe = (from ansatte in innlevering3DBTilkobling.Ansatte
                                        select ansatte).ToList();

                    return View(ansatteListe);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult RegistrerNyAnsatt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrerNyAnsatt(Ansatte nyAnsatt)
        {
            if (ModelState.IsValid)
            {
                using (Innlevering3DatabaseEntities innlevering3DBTilkobling = new Innlevering3DatabaseEntities())
                {
                    innlevering3DBTilkobling.Ansatte.Add(nyAnsatt);
                    innlevering3DBTilkobling.SaveChanges();
                }

                Session["SisteAnsatt"] = nyAnsatt.Fornavn;

                return RedirectToAction("VisAlleAnsatte");
            }
            else
            {
                return View();
            }


        }
    }
}
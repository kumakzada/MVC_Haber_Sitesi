using HaberProjesi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberProjesi2.Controllers
{
    [Authorize]
    public class GaleriController : Controller
    {
        Model1 db = new Model1();
        // GET: Galeri
        public ActionResult Index()
        {

            return View(db.Haber.Where(x => x.HaberTipi == 4).OrderByDescending(x => x.YayinTarih));
        }
        public ActionResult GaleriGuruntele(int id)
        {
            var haber = db.Haber.FirstOrDefault(x => x.ID == id);
            return View(haber);
        }
    }
}
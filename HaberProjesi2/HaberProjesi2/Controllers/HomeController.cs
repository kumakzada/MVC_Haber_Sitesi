using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using HaberProjesi2.Models;

namespace HaberProjesi2.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slidergetir()
        {
          using (db)
            {
             
                var obj = db.Haber.Where(X => X.HaberTipi == 1).OrderByDescending(X => X.ID).Take(10).ToList(); //Eger Video Yol Bos Ise  Ozamn Son 10 Tane Haber Yazdir.
  
                return View(obj);
            }

        }
        public ActionResult SonhaberBaslik()
        {
            using (db)
            {
                var x = ViewBag.SonHaberlist = db.Haber.OrderByDescending(X => X.YayinTarih).Take(6).ToList();
                return View(x);
            }


        }
        public ActionResult UstTab()
        {
            return View();
        }
        public ActionResult Yayin()
        {
            var yayinler = db.Haber.Where(X => X.HaberTipi == 4).OrderByDescending(x => x.ID).Take(5);
            return View(yayinler);
        }
        public ActionResult Tab_VideoGetir()
        {
        
            return View();
        }
        public ActionResult Tab_GorusGetir()
        {
            //var Gorusler = db.Gorus.OrderByDescending(X => X.GorusTarih).Take(2);
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Autorize(Models.Yazar1 yazarBilgileri)
        {
            using (Model1 db = new Model1())
            {
                var yazardetay = db.Yazar1.Where(x => x.Mail == yazarBilgileri.Mail && x.Sifre == yazarBilgileri.Sifre).FirstOrDefault();
                if (yazardetay != null)
                {
                    Session["ID"] = yazardetay.ID;
                    Session["kullaniciadi"] = yazardetay.YazarAd;
                    return RedirectToAction("Index", "Admin",new { area="Admin"});
                }
                else
                {
                    ModelState.AddModelError("", "Hatali Sifre veya isim");
                    return View("Login", yazarBilgileri);
                }
            }
        }
         
        public ActionResult cikis()
        {
            Session["ID"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}
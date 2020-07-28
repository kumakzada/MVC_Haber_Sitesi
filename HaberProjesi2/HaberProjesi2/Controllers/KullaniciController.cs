using HaberProjesi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaberProjesi2.Areas.Kullanici.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici/Kullanici
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autorize( Models.Kullanici KullaniciBilgileri)
        {
            using (Model1 db = new Model1())
            {
                var yazardetay = db.Kullanici.Where(x=>x.Ad== KullaniciBilgileri.Ad && x.Sifre == KullaniciBilgileri.Sifre).FirstOrDefault();
                if (yazardetay != null)
                {
                    FormsAuthentication.SetAuthCookie(yazardetay.Ad, false);
                    //Session["ID"] = yazardetay.Id;
                    //Session["kullaniciadi"] = yazardetay.Ad;
                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.mesaj = "Hatali Sifre veya isim";
                    //ModelState.AddModelError("", "Hatali Sifre veya isim");
                    return View("Login", KullaniciBilgileri);
                }
            }
        }
        public ActionResult cikis()
        {
            Session["ID"] = null;
            return RedirectToAction("Login", "Kullanici");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Models.Kullanici obj)
        {
            if (ModelState.IsValid)
            {
                Model1 db = new Model1();
                db.Kullanici.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //public ActionResult Git()
        //{
        //    return View();
        //}
        //public ActionResult Index()

        //{
        //    if (ModelState.IsValid)
        //    {
        //        RegMVCEntities db = new RegMVCEntities();
        //        db.tblRegistrations.Add(obj);
        //        db.SaveChanges();
        //    }
        //    return View(obj);
        //}

    }
}
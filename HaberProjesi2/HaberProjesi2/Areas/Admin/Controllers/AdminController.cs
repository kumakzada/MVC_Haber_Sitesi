using HaberProjesi2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberProjesi2.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
      
        
        // GET: Admin/Admin
     


        Model1 db = new Model1();
         
              
        public ActionResult Index()
        {
            List<Haber> listhaber = db.Haber.ToList();
            return View(listhaber);
        }
        [HttpGet]
        public ActionResult HaberEkle()
        {
            ViewBag.KategoriIDs = db.Kategori.Select(x => new { ID = x.ID, Ad = x.Ad });
            ViewBag.HabertipIDs = db.HaberTipi.Select(x => new { ID = x.ID, Ad = x.Adi });
            return View();
        }
        string ResimKayedet(HttpPostedFileBase file) //Dosyaya resim Ekleme Ve Kayidetme 
        {
            Image orj = Image.FromStream(file.InputStream);
            Bitmap kck = new Bitmap(orj, 120, 120);
            string DosyaAdi = Path.GetFileNameWithoutExtension(file.FileName + Guid.NewGuid() + Path.GetExtension(file.FileName));
            orj.Save(Server.MapPath("~/Content/Admin/big/" + DosyaAdi));
            orj.Save(Server.MapPath("~/Content/Images/photos/Small/" + DosyaAdi));
            return DosyaAdi;
        }
        string VideoKayedet(HttpPostedFileBase file)//Dosyaya video Ekleme Ve Kayidetme 
        {
            string yol = Path.GetFileNameWithoutExtension(file.FileName + Guid.NewGuid() + Path.GetExtension(file.FileName));
            FileStream fs = new FileStream(Server.MapPath("~/Content/admin/video/" + yol), FileMode.Create);
            byte[] buffer = new byte[file.ContentLength];
            file.InputStream.Read(buffer, 0, file.ContentLength);
            fs.Write(buffer, 0, file.ContentLength);
            fs.Close();
            return yol;
        }
        [HttpPost]
        public ActionResult HaberEkle2(Haber haber, HttpPostedFileBase Resim)
        {
          

            if (Resim != null)
            {
                string resimName = Resim.FileName;
                string filename = Guid.NewGuid() + Path.GetExtension(resimName);

                Resim.SaveAs(Path.Combine(Server.MapPath("~/Content/Admin/big/"), filename));
                haber.ResimYol = filename;
                db.Haber.Add(haber);
                db.SaveChanges();

            }
            return RedirectToAction("HaberEkle");
        }

        public ActionResult haberKaldir(int haberid)
        {
            Haber KaldiralacakHaber = db.Haber.Find(haberid);

            db.Haber.Remove(KaldiralacakHaber);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
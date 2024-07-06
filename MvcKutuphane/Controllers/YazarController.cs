using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values=db.TBLYAZAR.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var yazar=db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id) 
        {
            var yazar = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yazar=db.TBLYAZAR.Find(p.Id);
            yazar.AD=p.AD;
            yazar.SOYAD=p.SOYAD;
            yazar.DETAY=p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarKitaplar(int id)
        { 
            var yazar=db.TBLKITAP.Where(x=>x.YAZAR==id).ToList();
            var yazarad=db.TBLYAZAR.Where(y=>y.Id==id).Select(z=>z.AD+ " " +z.SOYAD).FirstOrDefault();
            ViewBag.y1= yazarad;
            return View(yazar); 
        }
    }
}
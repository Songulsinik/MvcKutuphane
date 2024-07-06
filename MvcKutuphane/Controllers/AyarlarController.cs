using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();   
        public ActionResult Index()
        {
            var kullaniciler=db.TBLADMIN.ToList();
            return View(kullaniciler);
        }

        public ActionResult Index2()
        {
            var kullaniciler = db.TBLADMIN.ToList();
            return View(kullaniciler);
        }
        [HttpGet]
        public ActionResult YeniAdmin() 
        { 
        return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN t)
        {
            db.TBLADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id) 
        {
            var admin = db.TBLADMIN.Find(id);
            return View("AdminGüncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN p)
        {
            var admin = db.TBLADMIN.Find(p.Id);
            admin.KULLANICI = p.KULLANICI;
            admin.SIFRE=p.SIFRE;
            admin.YETKI= p.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
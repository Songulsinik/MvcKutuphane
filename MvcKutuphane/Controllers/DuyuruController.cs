﻿using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLDUYURULAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniDuyuru()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR d)
        {
            db.TBLDUYURULAR.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int  id) 
        { 
           var duyuru=db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TBLDUYURULAR d)
        {
            var duyuru = db.TBLDUYURULAR.Find(d.Id);
            return View("DuyuruDetay", duyuru);
        }

        public ActionResult DuyuruGuncelle(TBLDUYURULAR t)
        {
            var duyuru = db.TBLDUYURULAR.Find(t.Id);
            duyuru.KATEGORI=t.KATEGORI;
            duyuru.ICERIK=t.ICERIK;
            duyuru.TARIH=t.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
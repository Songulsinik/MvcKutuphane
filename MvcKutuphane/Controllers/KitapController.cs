using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar=from k in db.TBLKITAP select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar=kitaplar.Where(m=>m.AD.Contains(p));
            }
            //var kitaplar=db.TBLKITAP.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value=i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2=(from i in db.TBLYAZAR.ToList()
                                         select new SelectListItem
                                         {
                                             Text=i.AD + ' ' + i.SOYAD,
                                              Value = i.Id.ToString()
                                         }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var kategori=db.TBLKATEGORI.Where(k=>k.Id==p.TBLKATEGORI.Id).FirstOrDefault();
            var yazar=db.TBLYAZAR.Where(y=>y.Id==p.TBLYAZAR.Id).FirstOrDefault();
            p.TBLKATEGORI = kategori;
            p.TBLYAZAR = yazar;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id) 
        { 
        var kitap=db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id) 
        {
            var kitap = db.TBLKITAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKITAP p) 
        {
            var kitap = db.TBLKITAP.Find(p.Id);
            kitap.AD = p.AD;
            kitap.BASIMYIL=p.BASIMYIL;
            kitap.SAYFA=p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.DURUM = true;
            var kategori = db.TBLKATEGORI.Where(k => k.Id == p.TBLKATEGORI.Id).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.Id == p.TBLYAZAR.Id).FirstOrDefault();
            kitap.KATEGORI = kategori.Id;
            kitap.YAZAR = yazar.Id;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
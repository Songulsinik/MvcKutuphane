using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcKutuphane.Controllers
{
    [Authorize(Roles ="A")]
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.Id.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in db.TBLKITAP.Where(x => x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.Id.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from z in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.Id.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYELER.Where(x => x.Id == p.TBLUYELER.Id).FirstOrDefault();
            var d2 = db.TBLKITAP.Where(y => y.Id == p.TBLKITAP.Id).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(z => z.Id == p.TBLPERSONEL.Id).FirstOrDefault();
            p.TBLUYELER = d1;
            p.TBLKITAP = d2;
            p.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(TBLHAREKET p)
        {
            var odunc = db.TBLHAREKET.Find(p.Id);
            DateTime d1 = DateTime.Parse(odunc.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odunc);
        }

        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hareket = db.TBLHAREKET.Find(p.Id);
            hareket.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
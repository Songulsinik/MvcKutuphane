using MvcKutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs= new List<Class1>();
            cs.Add(new Class1()
            {
               yayinevi="Güneş",
               sayi=7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Doğan",
                sayi = 5
            });
            cs.Add(new Class1()
            {
                 yayinevi="Yıldız",
                 sayi=1
            });
            return cs;
        }
    }
}
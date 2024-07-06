using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var bilgiler=db.TBLADMIN.FirstOrDefault(x=>x.KULLANICI==p.KULLANICI && x.SIFRE==p.SIFRE);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["KULLANICI"]=bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else 
            {
                return View();
            }
           
        }
    }
}
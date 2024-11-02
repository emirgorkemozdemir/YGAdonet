using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGAdonet.Models;

namespace YGAdonet.Controllers
{
    public class CountryController : Controller
    {
        YGAdonetDBEntities db = new YGAdonetDBEntities();

        [HttpGet]
        public ActionResult AddCountry()
        {
            // Görüntü döndürecegim. Ancak bunu yapmadan önce buraya baglı bir görüntü
            // var mı kontrol edin.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCountry(Country input)
        {
            if (ModelState.IsValid)
            {
                db.Country.Add(input);
                db.SaveChanges();
            }
            else
            {
               
            }
            return View();
        }

        [HttpGet]
        public ActionResult ListCountries()
        {
            // Örnegin ListCountries açıldıgında ben admin olarak giriş yapmışım varsayalım.
            Session["IsUserAdmin"] = true;
            var ulkeler = db.Country.ToList();
            return View(ulkeler);
        }

        [HttpGet]
        public ActionResult DeleteCountry(int id) 
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                Country deleting_country = db.Country.Find(id);
                db.Country.Remove(deleting_country);
                db.SaveChanges();

                return RedirectToAction("ListCountries");
            }
            return RedirectToAction("AddCountry");
        }

        [HttpGet]
        public ActionResult EditCountry(int id)
        {
            Country editing_country = db.Country.Find(id);
            return View(editing_country);
        }

        [HttpPost]
        public ActionResult EditCountry(Country posted_country)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                if (ModelState.IsValid)
                {
                    var db_country = db.Country.Find(posted_country.CountryID);
                    db_country.CountryName = posted_country.CountryName;
                    db_country.CountryCount = posted_country.CountryCount;
                    db.SaveChanges();
                    return RedirectToAction("ListCountries");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("AddCountry");  
        }
    }
}
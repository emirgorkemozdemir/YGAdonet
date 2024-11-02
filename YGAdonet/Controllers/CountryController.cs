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
    }
}
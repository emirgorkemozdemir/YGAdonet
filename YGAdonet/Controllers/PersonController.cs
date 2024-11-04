using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGAdonet.Models;

namespace YGAdonet.Controllers
{
    public class PersonController : Controller
    {
        YGAdonetDBEntities db = new YGAdonetDBEntities();

        public List<SelectListItem> GetCountries()
        {
            List<SelectListItem> result_list = new List<SelectListItem>();
            var ulkeler = db.Country.ToList();
            foreach (var ulke in ulkeler)
            {
                SelectListItem myitem = new SelectListItem();
                myitem.Text = ulke.CountryName;
                myitem.Value = ulke.CountryID.ToString();
                result_list.Add(myitem);
            }
            return result_list;
        }

        [HttpGet]
        public ActionResult AddPerson()
        {
            // Görüntü döndürecegim. Ancak bunu yapmadan önce buraya baglı bir görüntü
            // var mı kontrol edin.
            ViewBag.sonuc = GetCountries();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerson(Person input)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(input);
                db.SaveChanges();
            }
            else
            {

            }
            ViewBag.sonuc = GetCountries();
            return View();
        }

        [HttpGet]
        public ActionResult ListPersons()
        {
            // Örnegin ListPerson açıldıgında ben admin olarak giriş yapmışım varsayalım.
            Session["IsUserAdmin"] = true;
            var kisiler = db.Person.ToList();
            return View(kisiler);
        }

        [HttpGet]
        public ActionResult DeletePerson(int id)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
               Person deleting_person = db.Person.Find(id);
                db.Person.Remove(deleting_person);
                db.SaveChanges();

                return RedirectToAction("ListPersons");
            }
            return RedirectToAction("ListPersons");
        }

        [HttpGet]
        public ActionResult EditPerson(int id)
        {
            Person editing_Person = db.Person.Find(id);
            return View(editing_Person);
        }

        [HttpPost]
        public ActionResult EditPerson(Person posted_person)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                if (ModelState.IsValid)
                {
                    var db_person = db.Person.Find(posted_person.PersonID);
                    db_person.PersonName = posted_person.PersonName;
                    db_person.PersonSurname = posted_person.PersonSurname;
                    db_person.PersonCountry = posted_person.PersonCountry;
                    db.SaveChanges();
                    return RedirectToAction("ListPersons");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("ListPersons");
        }
    }
}
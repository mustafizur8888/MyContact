using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using MyContact.Models;
using MyContact.ViewModel;

namespace MyContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public HomeController()
        {
            ViewBag.CountofContact = _db.Contacts.Count();
            ViewBag.SideBar = "All Contact";

        }

        public ActionResult Index()
        {
            var contacts = _db.Contacts.GroupBy(x => x.Name.Substring(0, 1).ToUpper(), (alphabet, x) => new
            {
                Alphabet = alphabet,
                contactList = x.OrderBy(y => y.Name).ToList()

            }).OrderBy(x => x.Alphabet).ToList();


            List<ContactViewModel> contactViewModels = contacts.Select(x => new ContactViewModel
            {
                FirstAlphabet = x.Alphabet,
                Contacts = x.contactList
            }).ToList();







            return View(contactViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Contact contact = new Contact();
            ViewBag.SideBar = "Add New";
            return View(contact);
        }


        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            Contact contact = _db.Contacts.Single(x => x.ContactId == id);
            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(contact);
        }


        public ActionResult MakeFavourite(int id)
        {
            Contact dbContact = _db.Contacts.FirstOrDefault(x => x.ContactId == id);
            if (dbContact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (dbContact.Favourite != null && dbContact.Favourite.Value)
            {
                dbContact.Favourite = false;
            }
            else
            {
                dbContact.Favourite = true;
            }
            _db.SaveChanges();
            return View("Details", dbContact);
        }
        public ActionResult Favourite()
        {



            var contacts = _db.Contacts.Where(x => x.Favourite.Value)
                .GroupBy(x => x.Name.Substring(0, 1).ToUpper(), (alphabet, x) => new
                {
                    Alphabet = alphabet,
                    contactList = x.OrderBy(y => y.Name).ToList()

                }).OrderBy(x => x.Alphabet);


            List<ContactViewModel> contactViewModels = contacts.Select(x => new ContactViewModel
            {
                FirstAlphabet = x.Alphabet,
                Contacts = x.contactList
            }).ToList();
            return View("Index", contactViewModels);
        }
    }
}
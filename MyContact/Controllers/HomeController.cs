using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyContact.Models;

namespace MyContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public HomeController()
        {
            ViewBag.CountofContact = _db.Contacts.Count();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Contact contact = new Contact();
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
    }
}
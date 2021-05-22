using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonsProfileMVC.Models;
using PersonsProfileMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsProfileMVC.Controllers
{
    public class PersonsProfileController : Controller
    {
        private ILogger<PersonsProfileController> _logger;
        private IPersonRepo<PersonsProfile> _repo;
        public PersonsProfileController(IPersonRepo<PersonsProfile> repo, ILogger<PersonsProfileController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public ActionResult Index()
        {
            List<PersonsProfile> profiles = _repo.GetAll().ToList();
            return View(profiles);
        }

        public ActionResult Details(int id)
        {
            PersonsProfile profile = _repo.Get(id);
            return View(profile);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonsProfile profile)
        {
            try
            {
                _repo.Add(profile);
                return RedirectToAction("Success");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}

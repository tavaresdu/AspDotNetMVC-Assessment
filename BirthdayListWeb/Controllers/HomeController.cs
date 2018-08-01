using BirthdayListWeb.DAO;
using BirthdayListWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayListWeb.Controllers
{
    public class HomeController : Controller
    {
        private PersonDAO personDAO;

        public HomeController()
        {
            personDAO = new PersonDAO();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.birthdayToday = personDAO.FindBirthdayToday();
            ViewBag.people = personDAO.List().OrderBy(o => o.DaysToBirthday()).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(String search)
        {
            ViewBag.birthdayToday = personDAO.FindBirthdayToday();
            ViewBag.people = personDAO.FindByNameAndSurname(search).OrderBy(o => o.DaysToBirthday()).ToList();
            ViewBag.search = search;
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Person person)
        {
            personDAO.Add(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Visualizar(int id)
        {
            return View(personDAO.FindById(id));
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            return View(personDAO.FindById(id));
        }

        [HttpPost]
        public ActionResult Editar(Person person)
        {
            personDAO.Update(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            personDAO.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
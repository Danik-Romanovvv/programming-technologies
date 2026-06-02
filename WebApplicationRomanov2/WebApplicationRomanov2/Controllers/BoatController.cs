using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebApplicationRomanov2.Models;


namespace WebApplicationRomanov2.Controllers
{
    public class BoatController : Controller
    {
        // Хранение лодок в списке (List) 
        private static List<Boat> boatList = new List<Boat>
        {
            new Boat { Id = 1, BoatName = "Ветерок-1", RentalPrice = 500.0, LastMaintenanceDate = DateTime.Now.AddDays(-10), IsAvailable = true, Description = "Отличное состояние, 2 весла в комплекте." },
            new Boat { Id = 2, BoatName = "Катамаран Морской", RentalPrice = 800.0, LastMaintenanceDate = DateTime.Now.AddMonths(-1), IsAvailable = false, Description = "На ремонте (замена педалей)." }
        };

        [HttpGet]
        public ActionResult Index(bool useInline = true)
        {
            // Передача логического значения
            ViewData["UseInlineHelper"] = useInline;
            return View(boatList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = boatList.Find(b => b.Id == id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Boat());
        }

        [HttpPost]
        public ActionResult Create(Boat model)
        {
            model.Id = boatList.Count + 1;
            boatList.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Сохранение номера текущей лодки в Cookie 
            HttpCookie cookie = new HttpCookie("CurrentBoatId", id.ToString());
            Response.Cookies.Add(cookie);

            var model = boatList.Find(b => b.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Boat model)
        {
            var index = boatList.FindIndex(b => b.Id == model.Id);
            if (index != -1)
            {
                boatList[index] = model;
            }
            return RedirectToAction("Index");
        }
    }
}
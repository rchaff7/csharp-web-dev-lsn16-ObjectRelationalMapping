using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<EventCategory> categories = context.EventCategories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel catViewModel = new AddEventCategoryViewModel();
            return View(catViewModel);
        }

        [HttpPost("/EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel catViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCat = new EventCategory(catViewModel.Name);

                context.EventCategories.Add(newCat);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View("Create", catViewModel);
        }
    }
}

using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
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
    }
}

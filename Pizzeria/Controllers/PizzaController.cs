using Microsoft.AspNetCore.Mvc;
using Pizzeria.Database;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> PizzaList = db.Pizzas.ToList<Pizza>();
                return View("Index", PizzaList);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza FoundPizza = db.Pizzas
                    .Where(DbPizza => DbPizza.Id == id)
                    .FirstOrDefault();

                if (FoundPizza != null)
                {
                    return View(FoundPizza);
                }

                return NotFound("La pizza che stai cercando non esiste!");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using(PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

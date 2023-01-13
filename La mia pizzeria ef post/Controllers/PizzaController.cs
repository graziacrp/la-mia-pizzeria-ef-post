using La_mia_pizzeria_ef_post.Models;
using Microsoft.AspNetCore.Mvc;
using static La_mia_pizzeria_ef_post.Models.Pizza.pizzaList;
using static La_mia_pizzeria_ef_post.Models.Pizza;

namespace La_mia_pizzeria_ef_post.Controllers
{
	public class PizzaController : Controller
	{

		public static PizzaContext db = new PizzaContext();


		public static pizzaList pizze = null;
		public IActionResult Pizzeria()
		{

			if (pizze == null)
			{
				Pizza Margherita = new Pizza("Margherita", "Ingredienti: Mozzarella, Pomodoro e Basilico", 6.50);
				Pizza Nutella = new Pizza("Nutella", "Ingredienti: Nutella, Mascarpone", 7);
				Pizza Patate = new Pizza("Patate", "Ingredienti: Patate, Rosmarino", 7);


				pizze = new();
				//pizze.ListaPizze.Add(Margherita);
				//pizze.ListaPizze.Add(Nutella);
				//pizze.ListaPizze.Add(Patate);


				db.Add(Margherita);
				db.Add(Nutella);
				db.Add(Patate);
				db.SaveChanges();

				//List<Pizza> Pizze = db.Pizzas.OrderBy(pizza => pizza.Nome).ToList<Pizza>();
				//Console.WriteLine(Pizze);
			}


			return View(db);
		}

		public IActionResult CreaPizza()
		{
			Pizza MiaPizza = new Pizza()
			{
				Nome = "",
				Desc = "",
				Prezzo = 0
			};
			return View(MiaPizza);

		}

		public IActionResult MostraPizza(int id)
		{
			return View("MostraPizza", db.Pizzas.Find(id));

		}
	}

	[HttpPost]
	[ValidateAntiForgeryToken]

	public IActionResult Update(Pizza formData)
	{
		if (!ModelState.IsValid)
		{
			return View("Update", formData);
		}

		using (PizzaContext db = new PizzaContext())
		{
			Pizza pizzaToUpdate = db.Pizzas.Where(Pizza => Pizza.Id == formData.Id).FirstOrDefault();

			if (pizzaToUpdate != null)
			{
				pizzaToUpdate.Nome = formData.Nome;
				pizzaToUpdate.Descrizione = formData.Descrizione;
				pizzaToUpdate.Prezzo = formData.Prezzo;

				db.SaveChanges();

				return RedirectToAction("Index");
			}
			else
			{
				return NotFound("La pizza che vuoi modificare non è stata trovata");
			}
		}
	}

	[HttpPost]
	[ValidateAntiForgeryToken]

	public IActionResult Delete(int id)
	{
		using (PizzaContext db = new PizzaContext())
		{
			Pizza pizzaToDelete = db.Pizze.Where(Pizze => Pizze.Id == id) FirstOrDefault();

			if (pizzaToDelete != null)
			{
				db.Pizze.Remove(pizzaToDelete);
				db.SaveChanges();

				return RedirectToActionResult("Index");
			}
			else
			{
				return NotFoundObjectResult("La pizza da eliminare non è stata trovata");
			}
		}
	}
}




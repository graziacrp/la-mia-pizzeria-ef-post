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
}

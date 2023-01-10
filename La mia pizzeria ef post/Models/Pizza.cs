using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace La_mia_pizzeria_ef_post.Models
{
	[Table("Pizza")]
	public class Pizza
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Il Nome è obbligatorio")]
		public string? Nome { get; set; }

		[Required(ErrorMessage = "La Descrizione è obbligatoria")]
		
		public string? Desc { get; set; }

		[Required(ErrorMessage = "Il Prezzo è obbligatorio")]

		[Range(1, int.MaxValue, ErrorMessage = "Messaggio di errore")]
		public int? Prezzo { get; set; }
		public Pizza( int Id, string Nome, string Descrizione, int Prezzo)
		{
			
			this.Nome = Nome;
			this.Descrizione = Descrizione;
			this.Prezzo = Prezzo;


		}

		public class pizzaList
		{
			public List<Pizza> ListaPizze { get; set; }

			public pizzaList()
			{
				ListaPizze = new();

			}

			public class PizzaContext : DbContext
			{
				public DbSet<Pizza> Pizzas { get; set; }


				protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
				{
					optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizzeria;Integrated Security=True;Pooling=False");
				}
			}
		}

using BakeBot.Wasm.Models;

namespace BakeBot.Wasm.Services
{
	public class RecipeService
	{
		public List<Recipe> Recipes { get; set; }
		public RecipeService()
		{
			Recipes = new List<Recipe>()
			{
				new Recipe() { 
					Name = "Chocolate Chip Cookies", 
					Ingredients = new List<Ingredient>() { 
						new() {Name = "Flour", Quantity = 350, Unit = "grams"},
						new() {Name = "Sugar", Quantity = 200, Unit = "grams"},
						new() {Name = "Chocolate Chips", Quantity = 200, Unit = "grams"},
						new() {Name = "Butter", Quantity = 200, Unit = "grams"},
						new() {Name = "Eggs", Quantity = 2}
					},
					Instructions = new List<string>() {
						"Cream butter and sugar",
						"Add flour and chocolate chips",
						"bake at 350 degrees for 10 minutes"
					},
					PreparationTime = TimeSpan.FromMinutes(20),
					CookingTime = TimeSpan.FromMinutes(30),
					Tags = new List<string>() { "baking", "cookies", "chocolate" },
					Notes = "These cookies are delicious! You can also add nuts or dried fruit."
				},
				new Recipe() { 
					Name = "Spaghetti Carbonara", 
					Ingredients = new List<Ingredient>() { 
						new() {Name = "Spaghetti", Quantity = 350, Unit = "grams"},
						new() {Name = "Pancetta", Quantity = 200, Unit = "grams"},
						new() {Name = "Eggs", Quantity = 2},
						new() {Name = "Parmesan Cheese", Quantity = 200, Unit = "grams"},
						new() {Name = "Black Pepper", Quantity = 1, Unit = "teaspoon"}
					},
					Instructions = new List<string>() {
						"Boil spaghetti",
						"Fry pancetta",
						"Mix eggs and cheese",
						"Combine all ingredients"
					},
					PreparationTime = TimeSpan.FromMinutes(10),
					CookingTime = TimeSpan.FromMinutes(20),
					Tags = new List<string>() { "cooking", "pasta", "italian" },
					Notes = "This is a classic Italian dish that is quick and easy to make."
				},
				new Recipe() { 
					Name = "Manhattan", 
					Ingredients = new List<Ingredient>() { 
						new() {Name = "Rye Whiskey", Quantity = 2, Unit = "ounces"},
						new() {Name = "Sweet Vermouth", Quantity = 1, Unit = "ounce"},
						new() {Name = "Angostura Bitters", Quantity = 2, Unit = "dashes"},
						new() {Name = "Maraschino Cherry", Quantity = 1}
					},
					Instructions = new List<string>() {
						"Stir whiskey, vermouth, and bitters with ice",
						"Strain into a chilled glass",
						"Garnish with cherry"
					},
					PreparationTime = TimeSpan.FromMinutes(2),
					Tags = new List<string>() { "coctail", "whiskey", "classic" },
					Notes = "This is a classic cocktail that is perfect for sipping on a cold evening."
				},
			};
		}
	}
}
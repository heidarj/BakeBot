using BakeBot.Models;

namespace BakeBot.API.Services;

public class RecipeService
{
	public List<DetailedRecipe> Recipes { get; set; } = new List<DetailedRecipe>()
		{
			new DetailedRecipe() {
				Id = "182a7cb7-6f16-418c-88f1-44e712f793da",
				Name = "Chocolate Chip Cookies",
				Ingredients = new List<Ingredient>() {
					new() { Name = "Flour", Quantity = 350m, Unit = "grams" },
					new() { Name = "Granulated Sugar", Quantity = 200m, Unit = "grams" },
					new() { Name = "Brown Sugar", Quantity = 150m, Unit = "grams" },
					new() { Name = "Chocolate Chips", Quantity = 200m, Unit = "grams" },
					new() { Name = "Butter", Quantity = 200m, Unit = "grams" },
					new() { Name = "Eggs", Quantity = 2m, Unit = "large", MustBeWholeNumber = true },
					new() { Name = "Vanilla Extract", Quantity = 1m, Unit = "teaspoon" },
					new() { Name = "Baking Soda", Quantity = 1m, Unit = "teaspoon" },
					new() { Name = "Salt", Quantity = 0.5m, Unit = "teaspoon" }
				},
				Instructions = new SortedList<int, string>() {
					{ 1, "Preheat your oven to 350°F (175°C) and line a baking sheet with parchment paper." },
					{ 2, "In a large bowl, cream together the softened butter, granulated sugar, and brown sugar until smooth and creamy." },
					{ 3, "Beat in the eggs one at a time, then stir in the vanilla extract." },
					{ 4, "Dissolve the baking soda in hot water, then add it to the batter along with the salt." },
					{ 5, "Gradually add the flour to the mixture, mixing well until fully incorporated." },
					{ 6, "Fold in the chocolate chips until evenly distributed throughout the dough." },
					{ 7, "Drop large spoonfuls of dough onto the prepared baking sheet, leaving space between each cookie." },
					{ 8, "Bake in the preheated oven for about 10-12 minutes, or until the edges are nicely browned." },
					{ 9, "Remove from the oven and allow the cookies to cool on the baking sheet for a few minutes before transferring to a wire rack to cool completely." }
				},
				PreparationTime = TimeSpan.FromMinutes(20),
				CookingTime = TimeSpan.FromMinutes(12),
				Tags = new List<string>() { "baking", "cookies", "chocolate", "dessert", "snacks", "homemade" },
				Notes = "These chocolate chip cookies are incredibly delicious, with a perfect balance of crisp edges and chewy centers. Enjoy them warm with a glass of milk or a scoop of vanilla ice cream for a delightful treat. Feel free to customize them by adding nuts, dried fruit, or even a sprinkle of sea salt on top. They're perfect for sharing with family and friends, or as a comforting homemade snack."
			},
			new DetailedRecipe() {
				Id = "e068a6e7-8d40-4eea-bfbd-27373f8486ba",
				Name = "Spaghetti Carbonara",
				Ingredients = new List<Ingredient>() {
					new() {Name = "Spaghetti", Quantity = 500, Unit = "grams"},
					new() {Name = "Pancetta", Quantity = 300, Unit = "grams"},
					new() {Name = "Eggs", Quantity = 3, MustBeWholeNumber = true},
					new() {Name = "Parmesan Cheese", Quantity = 300, Unit = "grams"},
					new() {Name = "Black Pepper", Quantity = 1, Unit = "teaspoon"}
				},
				Instructions = new SortedList<int, string>() {
					{1, "Bring a large pot of salted water to a boil" },
					{2, "Fry pancetta in a large skillet until crispy" },
					{3, "Cook spaghetti in boiling water until al dente" },
					{4, "Whisk eggs and cheese together in a bowl" },
					{5, "Drain spaghetti and add to skillet with pancetta" },
					{6, "Remove skillet from heat and add egg mixture" },
					{7, "Stir until eggs are cooked and sauce is creamy" }
				},
				PreparationTime = TimeSpan.FromMinutes(10),
				CookingTime = TimeSpan.FromMinutes(20),
				Tags = new List<string>() { "cooking", "pasta", "italian" },
				Notes = "This is a classic Italian dish that is quick and easy to make."
			},
			new DetailedRecipe() {
				Id = "040dcccd-ffec-4065-b8a5-1089b79ab89d",
				Name = "Manhattan",
				Ingredients = new List<Ingredient>() {
					new() {Name = "Rye Whiskey", Quantity = 2, Unit = "ounces"},
					new() {Name = "Sweet Vermouth", Quantity = 1, Unit = "ounce"},
					new() {Name = "Angostura Bitters", Quantity = 2, Unit = "dashes"},
					new() {Name = "Maraschino Cherry", Quantity = 1}
				},
				Instructions = new SortedList<int, string>() {
					{1, "Chill a cocktail glass" },
					{2, "Stir whiskey, vermouth, and bitters with ice" },
					{3, "Strain into a chilled glass" },
					{4, "Garnish with cherry" }
				},
				PreparationTime = TimeSpan.FromMinutes(2),
				Tags = new List<string>() { "coctail", "whiskey", "classic" },
				Notes = "This is a classic cocktail that is perfect for sipping on a cold evening."
			},
		};
}

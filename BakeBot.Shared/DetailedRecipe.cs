using BakeBot.Extensions;
namespace BakeBot.Models;

public class DetailedRecipe : Recipe
{
	public required ICollection<Ingredient> Ingredients { get; set; }
	public required SortedList<int, string> Instructions { get; set; }
	public string? Notes { get; set; }
    public string? ImageUrl { get; set; }
}

public class Recipe
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public TimeSpan? PreparationTime { get; set; }
    public TimeSpan? CookingTime { get; set; }
    public required ICollection<string> Tags { get; set; }
}
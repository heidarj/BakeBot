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
    public string? Id { get; set; }
    public required string Name { get; set; }
    public TimeSpan? PreparationTime { get; set; }
    public TimeSpan? CookingTime { get; set; }
    public required ICollection<string> Tags { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public required string CreatedBy { get; set; }
    public string? EditedBy { get; set; }
}
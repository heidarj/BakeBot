namespace BakeBot.Wasm.Models;

public class Recipe
{
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public required string Name { get; set; }
	public required ICollection<Ingredient> Ingredients { get; set; }
	public required ICollection<string> Instructions { get; set; }
	public TimeSpan? PreparationTime { get; set; }
	public TimeSpan? CookingTime { get; set; }
	public TimeSpan? TotalTime => PreparationTime.AddNullable(CookingTime);
	public required ICollection<string> Tags { get; set; }
	public string? ImageUrl { get; set; }
	public string? Notes { get; set; }
}
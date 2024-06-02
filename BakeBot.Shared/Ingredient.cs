namespace BakeBot.Models;

public class Ingredient
{
	public required string Name { get; set; }
	public required decimal Quantity { get; set; }
	public string? Unit { get; set; }
	public bool MustBeWholeNumber { get; set; }
}
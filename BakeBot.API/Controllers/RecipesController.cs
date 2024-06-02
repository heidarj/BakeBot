using Microsoft.AspNetCore.Mvc;
using BakeBot.API.Services;
using BakeBot.Models;
using BakeBot.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BakeBot.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
	private readonly RecipeService _recipeService;
	private readonly ILogger<RecipesController> _logger;

	public RecipesController(RecipeService recipeService, ILogger<RecipesController> logger)
	{
		_recipeService = recipeService;
		_logger = logger;
	}

	// GET: api/<RecipesController>
	[HttpGet]
	public IEnumerable<Recipe> List()
	{
		using (_logger.BeginScope(new Dictionary<string, object> { ["Action"] = nameof(List) }))
		{
			_logger.LogTrace("Getting all recipes");
			return _recipeService.Recipes.Select(x => x as Recipe);
		}
	}

	// GET api/<RecipesController>/5
	[HttpGet("{id:guid}")]
	public IActionResult Get(Guid id)
	{
		using (_logger.BeginScope(new Dictionary<string, object> { ["Action"] = nameof(Get), ["RecipeId"] = id }))
		{
			_logger.LogTrace("Getting recipe by ID");
			var recipe = _recipeService.Recipes.FirstOrDefault(r => r.Id == id.ToString());
			if (recipe is null)
			{
				_logger.LogWarning("Recipe with ID {id} not found", id);

				return new NotFoundResult();
			}
			return new OkObjectResult(recipe);
		}
	}

	// POST api/<RecipesController>
	[HttpPost]
	public IActionResult Post([FromBody] DetailedRecipe value)
	{
		if (value is not DetailedRecipe
			{
				Ingredients: { Count: > 0 },
				Instructions: { Count: > 0 },
				Tags: { Count: > 0 }
			})
		{ 
			return new BadRequestResult();
		}
		using (_logger.BeginScope(new Dictionary<string, object> { ["Action"] = nameof(Post), ["RecipeId"] = value.Id ?? string.Empty }))
		{
			_logger.LogTrace("Adding new recipe: {name}", value.Name);
			try
			{
				var id = Guid.NewGuid();
				value.Id = id.ToString();
				_recipeService.Recipes.Add(value);
				return CreatedAtAction(nameof(Get), new { id }, value);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding new recipe: {name}", value.Name);
				return new StatusCodeResult(500);
			}
		}
	}

	// PUT api/<RecipesController>/5
	[HttpPut("{id:guid}")]
	public IActionResult Put(Guid id, [FromBody] DetailedRecipe value)
	{
		if (value is not DetailedRecipe
		{
			Id: var recipeId,
			Ingredients: { Count: > 0 },
			Instructions: { Count: > 0 },
			Tags: { Count: > 0 }
		} || recipeId != id.ToString())
		{
			return new BadRequestResult();
		}
		using (_logger.BeginScope(new Dictionary<string, object> { ["Action"] = nameof(Put), ["RecipeId"] = id }))
		{
			_logger.LogTrace("Updating recipe with ID: {id}", id);
			var recipe = _recipeService.Recipes.FirstOrDefault(r => r.Id == id.ToString());
			if (recipe is null)
			{
				_logger.LogWarning("{Action}: Recipe with ID {id} not found", nameof(Put), id);
				return new NotFoundResult();
			}
			try
			{
				_logger.LogTrace("Removing to replace recipe with ID: {id}", id);
				_recipeService.Recipes.Remove(recipe);
				_logger.LogTrace("Adding updated recipe with ID: {id}", id);
				_recipeService.Recipes.Add(value);
				return new OkObjectResult(value);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating recipe with ID: {id}", id);
				return new StatusCodeResult(500);
			}
		}
	}

	// DELETE api/<RecipesController>/5
	[HttpDelete("{id:guid}")]
	public IActionResult Delete(Guid id)
	{
		_logger.LogTrace("Deleting recipe with ID: {id}", id);
		_recipeService.Recipes.RemoveAll(r => r.Id == id.ToString());
		return new NoContentResult();
	}
}

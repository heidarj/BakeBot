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

    public RecipesController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    // GET: api/<RecipesController>
    [HttpGet]
    public IEnumerable<Recipe> Get()
    {
        return _recipeService.Recipes.Select(x => x as Recipe);
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var recipe = _recipeService.Recipes.FirstOrDefault(r => r.Id == id.ToString());
        if(recipe is null)
        {
            return new NotFoundResult();
        }
        return new OkObjectResult(recipe);
    }

    // POST api/<RecipesController>
    [HttpPost]
    public IActionResult Post([FromBody] DetailedRecipe value)
    {
        _recipeService.Recipes.Add(value);
        return new CreatedAtActionResult("Get", "Recipes", new { id = value.Id }, value);
    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id:guid}")]
    public IActionResult Put(Guid id, [FromBody] DetailedRecipe value)
    {
        var recipe = _recipeService.Recipes.FirstOrDefault(r => r.Id == id.ToString());
        if (recipe is null)
        {
            return new NotFoundResult();
        }
        _recipeService.Recipes.Remove(recipe);
        _recipeService.Recipes.Add(value);
        return new OkObjectResult(value);
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _recipeService.Recipes.RemoveAll(r => r.Id == id.ToString());
        return new NoContentResult();
    }
}

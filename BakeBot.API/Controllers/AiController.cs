using BakeBot.API.Services;
using BakeBot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using System.Text.Json;

namespace BakeBot.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AiController : ControllerBase
{
	private readonly RecipeService _recipeService;
	private readonly AiService _aiService;
	private readonly ILogger<AiController> _logger;

	public AiController(RecipeService recipeService, AiService aiService, ILogger<AiController> logger)
	{
		_recipeService = recipeService;
		_aiService = aiService;
		_logger = logger;
	}

	// Post api/<AiController>/5
	[HttpPost]
	public async Task<IActionResult> Enhance([FromBody] DetailedRecipe value)
	{
		var stringValue = JsonSerializer.Serialize(value);
		var enhanced = await _aiService.Enhance(stringValue);
		return new OkObjectResult(enhanced);
	}
}

using BakeBot.Models;
using System.Net.Http.Json;

namespace BakeBot.Wasm.Services;

public class RecipeService
{
    public HttpClient httpClient { get; }
    public RecipeService(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<IEnumerable<Recipe>> ListRecipesAsync()
    {
        var recipes = await httpClient.GetFromJsonAsync<IEnumerable<Recipe>>("Recipes");
        if (recipes is null)
        {
            throw new NullReferenceException("No recipes found.");
        }
        return recipes;
    }

    public async Task<DetailedRecipe> GetRecipeAsync(string id)
    {
        var recipe = await httpClient.GetFromJsonAsync<DetailedRecipe>($"Recipes/{id}");
        if (recipe is null)
        {
            throw new NullReferenceException("Recipe not found.");
        }
        return recipe;
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        await httpClient.PostAsJsonAsync("Recipes", recipe);
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        await httpClient.PutAsJsonAsync($"Recipes/{recipe.Id}", recipe);
    }

    public async Task DeleteRecipeAsync(string id)
    {
        await httpClient.DeleteAsync($"Recipes/{id}");
    }
}
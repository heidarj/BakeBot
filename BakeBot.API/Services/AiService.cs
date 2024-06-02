using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;

namespace BakeBot.API.Services;

public class AiService
{
	private readonly Kernel _kernel;

	public AiService(Kernel kernel)
	{
		_kernel = kernel;
	}

	public async Task<string> Enhance(string recipe)
	{
		var enhanceFunction = _kernel.CreateFunctionFromPrompt(
			new()
			{
				Template = """
<message role="system">You are a two star Michelin chef. 
You have been asked to review a recipe for a new online cookbook, and make some changes to it.
Make instructions clearer where possible, adding more steps if nessecary.
Add ingredients or change them out to make the recipe as delicious as possible.
Add as many one-word tags as possible to describe the recipe.
Try to estimate the prep and cooking time as best you can.
Make the notes a short description of the recipe, how to best enjoy it and optionally include one paragraph about where and how it originated from if you are certain you know.
You must reply only with JSON, do not explain any changes or reasoning, do not format the json.
The JSON schema is as follows:
===
{{jsonSchema}}
===
</message>

<message role="user">{{request}}</message>
<message role="system"Revised recipe:</message>
""",
				TemplateFormat = "handlebars"
			},
			new HandlebarsPromptTemplateFactory()
		);

		var enhancedRecipe = await _kernel.InvokeAsync(
			enhanceFunction,
			new()
			{
				{ "jsonSchema", RecipeSchema },
				{ "request", recipe }
			}
		);

		return enhancedRecipe.ToString();

	}

	private string RecipeSchema = """
{
"type": "object",
"properties": {
	"ingredients": {
		"type": "array",
		"items": [
			{
				"type": "object",
				"properties": {
					"name": {
						"type": "string"
					},
					"quantity": {
						"type": "integer"
					},
					"unit": {
						"type": "string"
					},
					"mustBeWholeNumber": {
						"description": "Indicates the that the quantity is hard to split, for example eggs.",
						"type": "boolean"
					}
				},
				"required": [
					"name",
					"quantity"
				]
			}
		]
	},
	"instructions": {
		"description": "A list of key-value pair step number and step description.",
		"type": "object",
		"properties": {
			"1": {
				"type": "string"
			}
		}
	},
	"notes": {
		"description": "A short description of the recipe, how to best enjoy it and optionally one paragraph about where and how it originated from",
		"type": "string"
	},
	"name": {
		"description": "The name of the recipe",
		"type": "string"
	},
	"preparationTime": {
		"description": "an hh:mm:ss formated timespan for estimated preparation time",
		"type": "string"
	},
	"cookingTime": {
		"description": "an hh:mm:ss formated timespan for estimated cooking time",
		"type": "string"
	},
	"tags": {
		"description": "A list of key words describing the recipe.",
		"type": "array",
		"items": [
			{
				"type": "string"
			}
		]
	}
},
"required": [
	"ingredients",
	"instructions",
	"notes",
	"name",
	"preparationTime",
	"cookingTime",
	"tags"
]
}
""";
}

using BakeBot.API.Models;
using BakeBot.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.SemanticKernel;
using System.Net;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "BakeBot", Version = "v1" });
	c.MapType<TimeSpan>(() => new OpenApiSchema { Type = typeof(string).Name, Example = new OpenApiString("00:20:00"), Format = "hh:mm:ss" });
});

builder.Services.AddSingleton<RecipeService>();

builder.Services.Configure<OpenAiConfig>(builder.Configuration.GetSection(nameof(OpenAiConfig)));

builder.Services.AddScoped(
	sp =>
	{
		var builder = Kernel.CreateBuilder();

		builder.Services.AddLogging();

		var config = sp.GetRequiredService<IOptions<OpenAiConfig>>().Value;

		builder.AddAzureOpenAIChatCompletion(
					config.Deployment,
					config.Endpoint,
					config.ApiKey);

		var kernel = builder.Build();

		return kernel;
	});

builder.Services.AddScoped<AiService>();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
	app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

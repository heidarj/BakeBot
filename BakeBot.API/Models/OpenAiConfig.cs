namespace BakeBot.API.Models
{
	public class OpenAiConfig
	{
		public required string ApiKey { get; set; }
		public required string Deployment { get; set; }
		public required string Endpoint { get; set; }
	}
}

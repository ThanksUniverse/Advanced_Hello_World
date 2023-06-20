using HelloWorldLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HelloWorldLibrary.BusinessLogic;

public class Messages : IMessages
{
	private readonly ILogger<Messages> _log;

	public Messages(ILogger<Messages> log)
	{
		_log = log;
	}

	public string Greeting(string language)
	{
		string output = LookUpCustomText("Greeting", language);
		return output;
	}

	private string LookUpCustomText(string key, string language)
	{
		JsonSerializerOptions options = new()
		{
			PropertyNameCaseInsensitive = true
		};

		try
		{
			List<CustomText>? messageSets = JsonSerializer
			.Deserialize<List<CustomText>>
			(
				File.ReadAllText("CustomText.json"), options
			);

			CustomText? messages = messageSets?.Where(x => x.Language == language).First();

			if (messages is null)
			{
				throw new NullReferenceException("The specified language was not found in the json file.");
			}

			return messages.Translations[key];
		}
		catch (Exception ex)
		{
			_log.LogError("Error looking up the custom text", ex);
			throw;
		}


	}
}

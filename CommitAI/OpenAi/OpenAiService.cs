using System.Text;

using CommitAI.OpenAi.Models;

using Newtonsoft.Json;

namespace CommitAI.OpenAi;

public class OpenAiService : IOpenAIService
{
    private const string OpenAiApiUrl = "https://api.openai.com/v1/completions";
    private readonly HttpClient _httpClient;
    private readonly OpenApiConfiguration _openApiConfiguration;

    public OpenAiService(OpenApiConfiguration openApiConfiguration, HttpClient httpClient)
    {
        _openApiConfiguration = openApiConfiguration;
        _httpClient = httpClient;
    }

    public async Task<string> GetAnswerAsync(string prompt)
    {
        var request = new OpenAIRequest(
            prompt,
            _openApiConfiguration.Model,
            _openApiConfiguration.Temperature,
            _openApiConfiguration.MaxTokens,
            _openApiConfiguration.TopP,
            _openApiConfiguration.FrequencyPenalty,
            _openApiConfiguration.PresencePenalty);

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_openApiConfiguration.ApiKey}");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new("OpenAI API call failed");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<OpenAIResponse>(jsonResponse);

        var resultText = responseObject?.Choices[0].Text ?? string.Empty;

        resultText = resultText.Replace("\r", string.Empty).Replace("\n", string.Empty);

        return resultText;
    }
}
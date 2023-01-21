using Newtonsoft.Json;

namespace CommitAI.OpenAi.Models;

public record OpenAIRequest(
    [property: JsonProperty("prompt")] string Prompt,
    [property: JsonProperty("model")] string Model,
    [property: JsonProperty("temperature")] float Temperature,
    [property: JsonProperty("max_tokens")] int MaxTokens,
    [property: JsonProperty("top_p")] float TopP,
    [property: JsonProperty("frequency_penalty")] int FrequencyPenalty,
    [property: JsonProperty("presence_penalty")] int PresencePenalty);
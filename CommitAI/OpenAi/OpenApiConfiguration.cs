namespace CommitAI.OpenAi;

public record OpenApiConfiguration(
    string ApiKey,
    string Model = "text-davinci-003",
    float Temperature = 0.8f,
    int MaxTokens = 256,
    float TopP = 1,
    int FrequencyPenalty = 0,
    int PresencePenalty = 0);
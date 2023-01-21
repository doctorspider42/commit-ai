namespace CommitAI.OpenAi;

public interface IOpenAIService
{
    public Task<string> GetAnswerAsync(string prompt);
}
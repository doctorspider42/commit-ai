namespace CommitAI.OpenAi;

public interface IOpenAIService
{
    public string GetAnswer(string question, string context);
}
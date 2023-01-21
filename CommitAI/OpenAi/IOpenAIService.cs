namespace CommitAI.OpenAi;

public interface IOpenAIService
{
    public string GetAnswer(string question, string context);
}

public class OpenAiService : IOpenAIService
{
    public string GetAnswer(string question, string context)
    {
        throw new NotImplementedException();
    }
}
using CommitAI.OpenAi;

namespace CommitAI.Services;

public class GitDiffRequestProcessor
{
    private readonly IGitDiffRequestContextConfiguration _contextConfiguration;
    private readonly IOpenAIService _openAiService;

    public GitDiffRequestProcessor(IGitDiffRequestContextConfiguration contextConfiguration, IOpenAIService openAiService)
    {
        _contextConfiguration = contextConfiguration;
        _openAiService = openAiService;
    }

    public string GetCommitMessage(string diff)
    {
        var context = _contextConfiguration.GetContext();
        var answer = _openAiService.GetAnswer(diff, context);
        return answer;
    }
}
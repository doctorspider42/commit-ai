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

    public async Task<string> GetCommitMessageAsync(string diff)
    {
        var cutDiff = diff.Length > 7500 ? diff.Substring(0, 7500) : diff;
        var context = _contextConfiguration.GetContext();
        var prompt = $"{context} {cutDiff} Answer:";

        var answer = await _openAiService.GetAnswerAsync(prompt);
        return answer;
    }
}
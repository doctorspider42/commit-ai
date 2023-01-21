using CommitAI.OpenAi;
using CommitAI.Services;

using NSubstitute;

using Shouldly;

namespace UnitTests;

public class GitDiffRequestProcessorTests
{
    private const string CorrectContext = "Correct context";
    private const string CorrectCommitMessage = "Correct commit message";
    private readonly GitDiffRequestProcessor _sut;
    private readonly IOpenAIService _openAiService;

    public GitDiffRequestProcessorTests()
    {
        _openAiService = Substitute.For<IOpenAIService>();
        _openAiService.GetAnswer(Arg.Any<string>(), Arg.Any<string>()).Returns(CorrectCommitMessage);
        var contextConfiguration = Substitute.For<IGitDiffRequestContextConfiguration>();
        contextConfiguration.GetContext().Returns(CorrectContext);

        _sut = new GitDiffRequestProcessor(contextConfiguration, _openAiService);
    }

    [Fact]
    public void Process_GivenValidGitDiffRequest_ReturnsCorrectCommitMessage()
    {
        var result = _sut.GetCommitMessage("some correct diff");

        _openAiService.Received(1).GetAnswer(Arg.Any<string>(), Arg.Any<string>());
        result.ShouldBe(CorrectCommitMessage);
    }
}
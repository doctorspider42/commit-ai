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
        _openAiService.GetAnswerAsync(Arg.Any<string>()).Returns(CorrectCommitMessage);
        var contextConfiguration = Substitute.For<IGitDiffRequestContextConfiguration>();
        contextConfiguration.GetContext().Returns(CorrectContext);

        _sut = new GitDiffRequestProcessor(contextConfiguration, _openAiService);
    }

    [Fact]
    public async Task Process_GivenValidGitDiffRequest_ReturnsCorrectCommitMessage()
    {
        // Act
        var result = await _sut.GetCommitMessageAsync("some correct diff");

        // Assert
        _ = await _openAiService.Received(1).GetAnswerAsync(Arg.Any<string>());
        result.ShouldBe(CorrectCommitMessage);
    }

    [Fact]
    public async Task Process_ShouldCallOpenAiServiceWithCorrectPrompt()
    {
        // Arrange
        const string diff = "some correct diff";
        var expectedPrompt = $"{CorrectContext} {diff} Answer: ";

        // Act
        _ = await _sut.GetCommitMessageAsync(diff);

        // Assert
        _ = await _openAiService.Received(1).GetAnswerAsync(expectedPrompt);
    }
}
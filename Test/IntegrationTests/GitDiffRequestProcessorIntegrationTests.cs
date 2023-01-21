using CommitAI.OpenAi;
using CommitAI.Services;

using Microsoft.Extensions.Configuration;

using Shouldly;

namespace IntegrationTests;

public class GitDiffRequestProcessorIntegrationTests
{
    private readonly GitDiffRequestProcessor _sut;

    public GitDiffRequestProcessorIntegrationTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<GitDiffRequestProcessorIntegrationTests>()
            .Build();
        var openApiConfiguration = new OpenApiConfiguration(configuration["OpenAi:ApiKey"]);
        _sut = new GitDiffRequestProcessor(new GitDiffRequestContextConfiguration(), new OpenAiService(openApiConfiguration, new HttpClient()));
    }

    [Fact]
    public async Task GetCommitMessage_ShouldReturnMessageInCorrectFormat()
    {
        var actualCommitMessage = await _sut.GetCommitMessageAsync(SampleDiff);
        actualCommitMessage.ShouldStartWith("UPDATE:");
    }

    private const string SampleDiff =
        @"diff --git a/src/Api/WebApi/Resolvers/Users/Queries/UsersQuery.cs b/src/Api/WebApi/Resolvers/Users/Queries/UsersQuery.cs
index f3a01a9..d99faf6 100644
--- a/src/Api/WebApi/Resolvers/Users/Queries/UsersQuery.cs
+++ b/src/Api/WebApi/Resolvers/Users/Queries/UsersQuery.cs
@@ -32,7 +32,7 @@ public class UsersQuery

     [UsePFS]
     [Authorize(Role.Leader)]
-    public IQueryable<User> GetMyTeamMembers([Service] IReadOnlyDatabaseContext<InventeoDatabaseContext> context,
+    public IQueryable<User> GetAllTeamMembers([Service] IReadOnlyDatabaseContext<InventeoDatabaseContext> context,
         [Service] IUserDataProvider userDataProvider)
     {
         var externalUserId = userDataProvider.GetUserExternalId();";
}
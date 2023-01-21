using CommitAI.OpenAi;
using CommitAI.Services;

using Shouldly;

namespace IntegrationTests;

public class GitDiffRequestProcessorIntegrationTests
{
    private GitDiffRequestProcessor _sut;

    public GitDiffRequestProcessorIntegrationTests()
    {
        _sut = new GitDiffRequestProcessor(new GitDiffRequestContextConfiguration(), new OpenAiService());
    }

    [Fact]
    public void GetCommitMessage_ShouldReturnMessageInCorrectFormat()
    {
        var actualCommitMessage = _sut.GetCommitMessage(SampleDiff);
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
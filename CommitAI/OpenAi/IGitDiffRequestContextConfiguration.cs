namespace CommitAI.OpenAi;

public interface IGitDiffRequestContextConfiguration
{
    public string GetContext();
}

public class GitDiffRequestContextConfiguration : IGitDiffRequestContextConfiguration
{
    public string GetContext()
    {
        throw new NotImplementedException();
    }
}
namespace CommitAI.OpenAi;

public class GitDiffRequestContextConfiguration : IGitDiffRequestContextConfiguration
{
    private const string Context = "Give short, compressed git description for changes. "
                                   + "Always use imperative form (example: ADD newfile.cs, UPDATE: examplemethod, UPDATE: rename oldmethod to newmethod). "
                                   + "FORMAT: \"ADD: (what will be added in which file). "
                                   + "UPDATE: (what will be UPDATED in which file). DELETE: (what will be deleted)\"";

    public string GetContext()
    {
        return Context;
    }
}
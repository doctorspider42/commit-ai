namespace CommitAI.OpenAi;

public class GitDiffRequestContextConfiguration : IGitDiffRequestContextConfiguration
{
    public string GetContext()
    {
        return "Give short, compressed git description for changes. Always use imperative form. Example: \"ADD: add TestUser.cs, Add GetAll() in MonitorService.cs. UPDATE: rename User to UserModel.cs\" FORMAT: FORMAT: ADD: (what will be added in which files). UPDATE: (what will be UPDATED in which files). DELETE: (what will be deleted). Omit not important\r\n";
    }
}
namespace OsintSharp.Core;

public class UserForSearch
{
    public string? UserName { get; set; }

    public UserForSearch(string? userName)
    {
        UserName = userName;
    }

    public UserForSearch()
    {
        UserName = "";
    }
}

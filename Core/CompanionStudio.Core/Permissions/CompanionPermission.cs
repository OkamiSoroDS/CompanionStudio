namespace CompanionStudio.Core.Permissions;

public class CompanionPermission
{
    public string Id { get; }

    public string Description { get; }


    public CompanionPermission(
        string id,
        string description)
    {
        Id = id;
        Description = description;
    }
}
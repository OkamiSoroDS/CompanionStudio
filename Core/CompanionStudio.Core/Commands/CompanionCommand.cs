namespace CompanionStudio.Core.Commands;

public class CompanionCommand
{
    public string Name { get; }

    public string Parameter { get; }


    public CompanionCommand(
        string name,
        string parameter = "")
    {
        Name = name;
        Parameter = parameter;
    }
}
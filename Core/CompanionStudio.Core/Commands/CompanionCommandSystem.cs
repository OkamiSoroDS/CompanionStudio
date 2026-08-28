using CompanionStudio.Core.Api;

namespace CompanionStudio.Core.Commands;

public class CompanionCommandSystem
{
    private readonly CompanionApi api;


    public CompanionCommandSystem()
    {
        api =
            new CompanionApi();
    }


    public bool Execute(
        CompanionCommand command)
    {
        switch (command.Name)
        {
            case "Start":
                return api.Start(
                    command.Parameter);


            case "Stop":
                api.Stop();
                return true;


            default:
                return false;
        }
    }
}
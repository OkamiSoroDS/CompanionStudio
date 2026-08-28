namespace CompanionStudio.Core.Configuration;

public class CompanionConfigurationManager
{
    private CompanionConfiguration configuration;


    public CompanionConfigurationManager()
    {
        configuration =
            new CompanionConfiguration();
    }


    public CompanionConfiguration Get()
    {
        return configuration;
    }


    public void Update(
        CompanionConfiguration newConfiguration)
    {
        configuration =
            newConfiguration;
    }
}
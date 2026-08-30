using CompanionStudio.Core.Identity;


namespace CompanionStudio.Core.Services;


public class CurrentIdentityService
{

    private readonly IdentitySelectorService selectorService;


    private IdentityModel? currentIdentity;



    public CurrentIdentityService(
        IdentitySelectorService selectorService)
    {

        this.selectorService = selectorService;


        Load();

    }





    public IdentityModel? CurrentIdentity
    {
        get
        {
            return currentIdentity;
        }
    }





    public void Load()
    {

        currentIdentity =
            selectorService.GetActiveIdentity();

    }





    public void Refresh()
    {

        Load();

    }





    public bool HasIdentity()
    {

        return currentIdentity != null;

    }

}
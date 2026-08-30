using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Services;


namespace CompanionStudio.App.UI.Components;


public partial class IdentityCard : ContentView
{

    public static event EventHandler? IdentityChanged;



    private readonly IdentityModel identity;
    private readonly IdentitySelectorService selectorService;




    public IdentityCard(
        IdentityModel identity,
        IdentitySelectorService selectorService)
    {

        InitializeComponent();


        this.identity = identity;

        this.selectorService = selectorService;


        LoadIdentity();

    }





    private void LoadIdentity()
    {

        NameLabel.Text =
            $"Name: {identity.Name}";



        VersionLabel.Text =
            $"Version: {identity.Version}";



        IdLabel.Text =
            $"ID: {identity.Id}";



        StatusLabel.Text =
            identity.IsActive
            ? "Status: Active"
            : "Status: Offline";



        IntegrityLabel.Text =
            $"Integrity: {identity.IntegrityStatus}";



        LockLabel.Text =
            $"Core Lock: {identity.CoreLocked}";



        FingerprintLabel.Text =
            $"Fingerprint: {identity.Fingerprint}";

    }





    private void SetActive_Clicked(
        object sender,
        EventArgs e)
    {

        selectorService
            .SetActiveIdentity(identity.Id);



        identity.IsActive = true;



        StatusLabel.Text =
            "Status: Active";



        IdentityChanged?
            .Invoke(
                this,
                EventArgs.Empty);

    }

}
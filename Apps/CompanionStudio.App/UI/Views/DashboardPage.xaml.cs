using CompanionStudio.Core.Services;
using CompanionStudio.App.UI.Components;


namespace CompanionStudio.App.UI.Views;


public partial class DashboardPage : ContentPage
{

    private readonly IdentityService identityService;

    private readonly IdentitySelectorService selectorService;

    private readonly CurrentIdentityService currentIdentityService;

    private readonly LanguageService languageService;




    public DashboardPage(
        IdentityService identityService,
        IdentitySelectorService selectorService,
        CurrentIdentityService currentIdentityService,
        LanguageService languageService)
    {

        InitializeComponent();


        this.identityService =
            identityService;


        this.selectorService =
            selectorService;


        this.currentIdentityService =
            currentIdentityService;


        this.languageService =
            languageService;



        LoadCurrentIdentity();

        LoadIdentityCards();

    }





    private async void Settings_Clicked(
    object? sender,
    EventArgs e)
    {

        await Shell.Current.GoToAsync(
            nameof(SettingsPage));

    }





    private void LoadCurrentIdentity()
    {

        var identity =
            currentIdentityService.CurrentIdentity;



        if (identity == null)
        {

            CurrentIdentityLabel.Text =
                "Identidad actual: Ninguna";


            return;

        }



        CurrentIdentityLabel.Text =
            $"Identidad actual: {identity.Name}\n" +
            $"ID: {identity.Id}\n" +
            $"Huella: {identity.IdentityFingerprint}";

    }





    private void LoadIdentityCards()
    {

        IdentityCardsContainer.Children.Clear();



        var identities =
            identityService.GetAll();



        foreach (var identity in identities)
        {

            var card =
                new IdentityCard(
                    identity,
                    selectorService);



            IdentityCardsContainer.Children.Add(
                card);

        }

    }





    private void OnIdentityChanged(
        object? sender,
        EventArgs e)
    {

        currentIdentityService.Refresh();


        LoadCurrentIdentity();


        LoadIdentityCards();

    }





    private async void CreateIdentity_Clicked(
        object? sender,
        EventArgs e)
    {

        var name =
            NameEntry.Text;



        var description =
            DescriptionEntry.Text;




        if (string.IsNullOrWhiteSpace(name))
        {

            await DisplayAlertAsync(
                "Error",
                "Ingrese un nombre",
                "OK");


            return;

        }




        var identity =
            identityService.Create(
                name,
                description ?? "");




        currentIdentityService.Refresh();


        LoadCurrentIdentity();


        LoadIdentityCards();




        NameEntry.Text =
            string.Empty;


        DescriptionEntry.Text =
            string.Empty;





        await DisplayAlertAsync(
            "Creado",
            $"Identidad {identity.Name} creada",
            "OK");

    }





    protected override void OnAppearing()
    {

        base.OnAppearing();



        currentIdentityService.Refresh();


        LoadCurrentIdentity();


        LoadIdentityCards();

    }





    protected override void OnDisappearing()
    {

        IdentityCard.IdentityChanged -=
            OnIdentityChanged;



        base.OnDisappearing();

    }

}
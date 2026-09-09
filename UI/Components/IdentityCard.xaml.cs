using CompanionStudio.App.UI.Views;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Services;

namespace CompanionStudio.App.UI.Components;

public partial class IdentityCard : ContentView
{
    public event EventHandler? IdentityChanged;


    private readonly IdentityModel identity;

    private readonly IdentitySelectorService selectorService;

    private readonly TranslationService translationService;

    private readonly IdentityService identityService;

    private readonly CurrentIdentityService currentIdentityService;



    public IdentityCard(
        IdentityModel identity,
        IdentitySelectorService selectorService,
        TranslationService translationService,
        IdentityService identityService,
        CurrentIdentityService currentIdentityService)
    {
        InitializeComponent();


        this.identity = identity;

        this.selectorService = selectorService;

        this.translationService = translationService;

        this.identityService = identityService;

        this.currentIdentityService = currentIdentityService;


        LoadIdentity();


        translationService
            .LanguageService
            .LanguageChanged += LanguageChanged;
    }



    private void LanguageChanged(
        object? sender,
        EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LoadIdentity();
        });
    }



    private void LoadIdentity()
    {
        TitleLabel.Text =
            translationService.Get("companion_identity");


        NameLabel.Text =
            $"{translationService.Get("name")}: {identity.Name}";


        VersionLabel.Text =
            $"{translationService.Get("version")}: {identity.Version}";


        IdLabel.Text =
            $"{translationService.Get("identity_id")}: {identity.Id}";


        StatusLabel.Text =
            identity.IsActive
            ?
            $"{translationService.Get("status")}: {translationService.Get("active")}"
            :
            $"{translationService.Get("status")}: {translationService.Get("offline")}";


        IntegrityLabel.Text =
            $"{translationService.Get("integrity")}: {identity.IntegrityStatus}";


        LockLabel.Text =
            $"{translationService.Get("core_lock")}: {identity.CoreLocked}";


        FingerprintLabel.Text =
            $"{translationService.Get("fingerprint")}: {identity.Fingerprint}";


        ActiveButton.Text =
            translationService.Get("set_active");


        EditButton.Text =
            translationService.Get("edit_identity");


        DeleteButton.Text =
            translationService.Get("delete_identity");
    }



    private void SetActive_Clicked(
        object? sender,
        EventArgs e)
    {
        if (!identityService.SetActiveIdentity(identity.Id))
        {
            return;
        }


        currentIdentityService.Refresh();


        IdentityChanged?.Invoke(
            this,
            EventArgs.Empty);
    }



    private async void Edit_Clicked(
        object? sender,
        EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(
            new IdentityEditorPage(
                identity,
                identityService,
                currentIdentityService,
                translationService));
    }



    private async void Delete_Clicked(
        object? sender,
        EventArgs e)
    {
        var confirmed = await Shell.Current.DisplayAlertAsync(
            translationService.Get("delete_identity"),
            string.Format(
                translationService.Get("delete_identity_confirmation"),
                identity.Name),
            translationService.Get("yes"),
            translationService.Get("no"));


        if (!confirmed)
            return;


        var identitiesRemaining =
            identityService.GetAll().Count() - 1;


        var warningMessage =
            identitiesRemaining == 0
                ? translationService.Get("delete_last_identity_irreversible")
                : translationService.Get("delete_identity_irreversible");


        var finalConfirmation = await Shell.Current.DisplayAlertAsync(
            translationService.Get("delete_identity"),
            warningMessage,
            translationService.Get("yes"),
            translationService.Get("no"));


        if (!finalConfirmation)
            return;


        if (!identityService.Delete(identity.Id))
        {
            await Shell.Current.DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("identity_delete_error"),
                translationService.Get("ok"));

            return;
        }


        currentIdentityService.Refresh();


        IdentityChanged?.Invoke(
            this,
            EventArgs.Empty);


        await Shell.Current.DisplayAlertAsync(
            translationService.Get("delete_identity"),
            translationService.Get("identity_deleted"),
            translationService.Get("ok"));
    }
}
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Services;

namespace CompanionStudio.App.UI.Views;

public partial class IdentityEditorPage : ContentPage
{
    private readonly TranslationService translationService;
    private readonly IdentityService identityService;
    private readonly CurrentIdentityService currentIdentityService;
    private readonly IdentityModel identity;

    public IdentityEditorPage(
        IdentityModel identity,
        IdentityService identityService,
        CurrentIdentityService currentIdentityService,
        TranslationService translationService)
    {
        InitializeComponent();

        this.identity = identity;
        this.identityService = identityService;
        this.currentIdentityService = currentIdentityService;
        this.translationService = translationService;
        
        LoadIdentity();
        ApplyTranslations();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        translationService.LanguageService.LanguageChanged -=
            LanguageChanged;

        translationService.LanguageService.LanguageChanged +=
            LanguageChanged;

        ApplyTranslations();
    }

    protected override void OnDisappearing()
    {
        translationService.LanguageService.LanguageChanged -=
            LanguageChanged;

        base.OnDisappearing();
    }

    private void LanguageChanged(
        object? sender,
        EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(
            ApplyTranslations);
    }

    private void ApplyTranslations()
    {
        Title = translationService.Get("edit_identity");

        EditorTitleLabel.Text =
            translationService.Get("edit_identity");

        NameTitleLabel.Text =
            translationService.Get("name");

        NameEntry.Placeholder =
            translationService.Get("companion_name");

        DescriptionTitleLabel.Text =
            translationService.Get("description");

        DescriptionEditor.Placeholder =
            translationService.Get("description");

        IdTitleLabel.Text =
            translationService.Get("identity_id_locked");

        FingerprintTitleLabel.Text =
            translationService.Get("identity_fingerprint_locked");

        SaveButton.Text =
            translationService.Get("save_changes");
    }

    private void LoadIdentity()
    {
        NameEntry.Text = identity.Name;
        DescriptionEditor.Text = identity.Description;
        IdLabel.Text = identity.Id;
        FingerprintLabel.Text = identity.IdentityFingerprint;
    }

    private async void Save_Clicked(
        object? sender,
        EventArgs e)
    {
        var name = NameEntry.Text;
        var description = DescriptionEditor.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("identity_name_required"),
                translationService.Get("ok"));

            return;
        }

        var newName = name.Trim();
        var newDescription = description?.Trim() ?? string.Empty;

        var hasNoChanges =
            string.Equals(
                identity.Name,
                newName,
                StringComparison.Ordinal) &&
            string.Equals(
                identity.Description,
                newDescription,
                StringComparison.Ordinal);

        if (hasNoChanges)
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("no_changes"),
                translationService.Get("ok"));

            return;
        }

        if (identityService.IsNameInUse(
                newName,
                identity.Id))
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("name_already_exists"),
                translationService.Get("ok"));

            return;
        }

        var confirmed = await DisplayAlertAsync(
            translationService.Get("confirm_changes"),
            translationService.Get("save_identity_confirmation"),
            translationService.Get("yes"),
            translationService.Get("no"));

        if (!confirmed)
        {
            return;
        }

        var updatedIdentity =
            new IdentityModel
            {
                Id = identity.Id,
                Name = newName,
                Description = newDescription,
                Version = identity.Version,
                IdentityFingerprint = identity.IdentityFingerprint,
                IsActive = identity.IsActive
            };

        var result =
            identityService.UpdateIdentity(updatedIdentity);

        if (!result)
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("identity_update_error"),
                translationService.Get("ok"));

            return;
        }

        currentIdentityService.Refresh();

        await DisplayAlertAsync(
            translationService.Get("saved"),
            translationService.Get("identity_updated"),
            translationService.Get("ok"));

        await Navigation.PopAsync();
    }
}
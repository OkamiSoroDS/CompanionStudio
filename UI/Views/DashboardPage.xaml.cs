using CompanionStudio.App.UI.Components;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Memory.Tests;
using CompanionStudio.Core.Services;


namespace CompanionStudio.App.UI.Views;

public partial class DashboardPage : ContentPage
{
    private readonly IdentityService identityService;
    private readonly IdentitySelectorService selectorService;
    private readonly CurrentIdentityService currentIdentityService;
    private readonly LanguageService languageService;
    private readonly TranslationService translationService;
    private readonly CognitiveMemoryTestService cognitiveMemoryTestService;


    public DashboardPage(
        CognitiveMemoryTestService cognitiveMemoryTestService,
        IdentityService identityService,
        IdentitySelectorService selectorService,
        CurrentIdentityService currentIdentityService,
        LanguageService languageService,
        TranslationService translationService)
    {
        InitializeComponent();

        this.identityService = identityService;
        this.selectorService = selectorService;
        this.currentIdentityService = currentIdentityService;
        this.languageService = languageService;
        this.translationService = translationService;
        this.cognitiveMemoryTestService = cognitiveMemoryTestService;

        Title = "Dashboard cargado correctamente";
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        languageService.LanguageChanged -= LanguageChanged;
        languageService.LanguageChanged += LanguageChanged;

        ApplyTranslations();

        currentIdentityService.Refresh();

        LoadCurrentIdentity();

        LoadIdentityCards();
    }



    private void LanguageChanged(
        object? sender,
        EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ApplyTranslations();

            LoadCurrentIdentity();

            LoadIdentityCards();
        });
    }


    private void IdentitySearch_TextChanged(
    object? sender,
    TextChangedEventArgs e)
    {
        LoadIdentityCards();
    }


    private void LoadIdentityCards()
    {
        IdentityCardsContainer.Children.Clear();

        var allIdentities =
            identityService
            .GetAll()
            .ToList();

        var identities =
            allIdentities
            .Where(identity => !identity.IsActive)
            .ToList();

        var searchText =
            IdentitySearchBar.Text?
            .Trim();

        var isSearching =
            !string.IsNullOrWhiteSpace(searchText);

        if (isSearching)
        {
            identities = identities
                .Where(identity =>
                    identity.Name.Contains(
                        searchText!,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        identities = identities
            .OrderBy(identity => identity.Name,
                StringComparer.CurrentCultureIgnoreCase)
            .ToList();

        var hasIdentities =
            identities.Count > 0;

        EmptyStateLabel.IsVisible =
            !hasIdentities;

        IdentityCardsContainer.IsVisible =
            hasIdentities;

        EmptyStateLabel.Text =
            isSearching
                ? translationService.Get("no_search_results")
                : allIdentities.Count == 0
                    ? translationService.Get("no_identities_message")
                    : translationService.Get("no_other_identities");

        foreach (var identity in identities)
        {
            var card =
                new IdentityCard(
                    identity,
                    selectorService,
                    translationService,
                    identityService,
                    currentIdentityService);

            card.IdentityChanged += OnIdentityChanged;

            IdentityCardsContainer.Children.Add(card);
        }
    }

    private void ApplyTranslations()
    {
        Title =
            translationService.Get("app_name");


        AppTitleLabel.Text =
            translationService.Get("app_name");


        AppDescriptionLabel.Text =
            translationService.Get("app_description");


        CreateTitleLabel.Text =
            translationService.Get("create_companion");


        NameEntry.Placeholder =
            translationService.Get("companion_name");


        DescriptionEntry.Placeholder =
            translationService.Get("description");


        CreateButton.Text =
            translationService.Get("create");


        CurrentIdentitiesLabel.Text =
            translationService.Get("current_identities");

        EmptyStateLabel.Text =
    translationService.Get("no_identities_message");

        ActiveIdentitySectionLabel.Text =
    translationService.Get("active_identity");

        DeactivateIdentityButton.Text =
            translationService.Get("deactivate_identity");

        NoActiveIdentityLabel.Text =
            translationService.Get("no_identity");

        ToolbarSettings.Text =
            translationService.Get("settings");

        IdentitySearchBar.Placeholder =
    translationService.Get("search_identities");

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
            ActiveIdentityBorder.IsVisible = false;
            NoActiveIdentityLabel.IsVisible = true;

            return;
        }

        ActiveIdentityBorder.IsVisible = true;
        NoActiveIdentityLabel.IsVisible = false;

        CurrentIdentityLabel.Text =
    $"{translationService.Get("current_identity")}: {identity.Name}\n" +
    $"{translationService.Get("identity_id")}: {identity.Id}\n" +
    $"{translationService.Get("fingerprint")}: {identity.IdentityFingerprint}";
    }





    private void OnIdentityChanged(
        object? sender,
        EventArgs e)
    {
        currentIdentityService.Refresh();

        LoadCurrentIdentity();

        LoadIdentityCards();
    }



    private async void DeactivateIdentity_Clicked(
    object? sender,
    EventArgs e)
    {
        var confirmed = await DisplayAlertAsync(
            translationService.Get("deactivate_identity"),
            translationService.Get("deactivate_identity_confirmation"),
            translationService.Get("yes"),
            translationService.Get("no"));

        if (!confirmed)
        {
            return;
        }

        identityService.ClearActiveIdentity();

        currentIdentityService.Refresh();

        LoadCurrentIdentity();

        LoadIdentityCards();

        await DisplayAlertAsync(
            translationService.Get("deactivate_identity"),
            translationService.Get("identity_deactivated"),
            translationService.Get("ok"));
    }


    private async void TestMemory_Clicked(
    object sender,
    EventArgs e)
    {
        var result =
            cognitiveMemoryTestService.RunTest();


        await DisplayAlertAsync(
            "Cognitive Memory Engine Test",
            result,
            "OK");
    }

    private async void CreateIdentity_Clicked(
    object? sender,
    EventArgs e)
    {
        var name = NameEntry.Text;
        var description = DescriptionEntry.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("identity_name_required"),
                translationService.Get("ok"));

            return;
        }

        var newName = name.Trim();

        if (identityService.IsNameInUse(
                newName,
                string.Empty))
        {
            await DisplayAlertAsync(
                translationService.Get("error"),
                translationService.Get("name_already_exists"),
                translationService.Get("ok"));

            return;
        }

        var identity =
            identityService.Create(
                newName,
                description?.Trim() ?? string.Empty);

        currentIdentityService.Refresh();

        LoadCurrentIdentity();

        LoadIdentityCards();

        NameEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;

        await DisplayAlertAsync(
            translationService.Get("identity_created"),
            identity.Name,
            translationService.Get("ok"));
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    

}
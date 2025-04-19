using Avhrm.Identity.UI.Services;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor.Services;

namespace Avhrm.UI.Shared;
public partial class MainLayout
{
    public bool IsAdmin = false;
    public string Name;
    private string Point;

    public ComponentsContext Context { get; set; } = new();
    Guid IBrowserViewportObserver.Id { get; } = Guid.NewGuid();

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public AvhrmClientAuthenticationStateProvider AuthStateProvider { get; set; }
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Inject] public IBrowserViewportService BrowserViewportService { get; set; }
    [Inject] public NotificationService NotificationService { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await BrowserViewportService.SubscribeAsync(this, fireImmediately: true);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += NavigationManager_LocationChanged;

        var user = (await AuthStateProvider.GetAuthenticationStateAsync()).User;

        if (user.Identities.Any(p => p.IsAuthenticated))
        {
            Name = user.GetUserPersianName();

            Point = user.GetUserPoint();

            IsAdmin = user.GetUserRoleName().ToLower() == "admin";
        }

        Context.OnChange += StateHasChanged;

        NotificationService.Context = Context;
    }

    private async void NavigationManager_LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Context.IsDrawerOpen = false;

        StateHasChanged();
    }

    public async Task OnSwipEnd(SwipeEventArgs e)
    {
        if (e.SwipeDirection == SwipeDirection.RightToLeft)
        {
            Context.IsDrawerOpen = true;
        }
        else if (e.SwipeDirection == SwipeDirection.LeftToRight)
        {
            Context.IsDrawerOpen = false;
        }
    }

    public async Task OnClickExit()
    {
        await AuthStateProvider.SetUserLoggedOut();
    }

    public async Task OnToggleDrawerClick()
    {
        Context.IsDrawerOpen = !Context.IsDrawerOpen;
    }

    public async Task OnOverlayClick(bool newValue)
    {
        if (!newValue)
        {
            Context.IsDrawerOpen = false;
        }
    }

    public async Task OnBackClick()
    {
        await JSRuntime.InvokeVoidAsync("history.back");
    }

    public async ValueTask DisposeAsync() => await BrowserViewportService.UnsubscribeAsync(this);


    ResizeOptions IBrowserViewportObserver.ResizeOptions { get; } = new()
    {
        ReportRate = 50,
        NotifyOnBreakpointOnly = false
    };

    Task IBrowserViewportObserver.NotifyBrowserViewportChangeAsync(BrowserViewportEventArgs browserViewportEventArgs)
    {
        Context.ViewportWidth = browserViewportEventArgs.BrowserWindowSize.Width;

        return InvokeAsync(StateHasChanged);
    }
}

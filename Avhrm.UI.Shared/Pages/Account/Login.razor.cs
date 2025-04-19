using Avhrm.Identity.UI.Services;
using Avhrm.Infrastructure.Client;

namespace Avhrm.UI.Shared.Pages.Account;
public partial class Login
{
    public bool IsLoading = false;

    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public AvhrmClientAuthenticationStateProvider ClientAuthProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ApiHandler Api { get; set; }
    [Inject] public NotificationService Notification { get; set; }

    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsDrawerShown = false;

        Context.IsBackButtonShown = false;

#if DEBUG
        Request = new()
        {
            Username = "11",
            Password = "rfidadmin"
        };
#endif
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        var result = (await Api.SendJsonAsync<GetUserLoginVm>(HttpMethod.Post
            , "account/AuthenticateByPassword"
            , Request)).Value;

        if (result.Token.HasNoValue())
        {
            Notification.AddNotification(TextResources.APP_StringKeys_Error_Login, NotificationType.Error);

            IsLoading = false;

            return;
        }

        await ClientAuthProvider.SetUserAuthenticated(result.Token);

        IsLoading = false;

        NavigationManager.NavigateTo("/", true);
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        foreach (var valid in context.GetValidationMessages())
        {
            Notification.AddNotification(valid, NotificationType.Error);
        }
    }
}

using AutoMapper;
using Avhrm.Infrastructure.Client;
using MediatR;

namespace Avhrm.UI.Shared.Pages.Account;
public partial class AddUser
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
    public Severity AlertSeverity = Severity.Error;
    public List<GetAllDepartmentDto> Departments = new();
    public List<GetAllUsersDto> Users = new();
    public List<GetAllRolesDto> Roles = new();
    public InsertUserCommand Command = new();

    [Parameter] public string? Username { get; set; }

    [Inject] public ApiHandler Api { get; set; }
    [Inject] public IMapper Mapper { get; set; }
    [Inject] public NotificationService Notification { get; set; }

    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsBackButtonShown = true;

        IsLoading = true;

        Departments = (await Api.SendJsonAsync<GetAllDepartmentVm>(HttpMethod.Get
            , "Department/GetAll")).Value.Data;

        Users = (await Api.SendJsonAsync<GetAllUsersVm>(HttpMethod.Get
            , "account/GetAll")).Value.Data;

        Roles = (await Api.SendJsonAsync<GetAllRolesVm>(HttpMethod.Get
            , "account/GetAllRoles")).Value.Data;

        if (Username.HasValue())
        {
            Command = Mapper.Map<InsertUserCommand>((await Api.SendJsonAsync<GetUserByUsernameVm>(HttpMethod.Get
            , "account/get"
            , new GetUserByUsernameQuery()
            {
                Username = Username
            })).Value);
        }

        IsLoading = false;
    }

    public async Task OnValidSubmit()
    {
        IsLoading = true;

        bool result;

        if (Username is null)
        {
            result = (await Api.SendJsonAsync<InsertUserVm>(HttpMethod.Post
            , "Account/Insert"
            , Command)).Value.Result;
        }
        else
        {
            result = (await Api.SendJsonAsync<UpdateUserVm>(HttpMethod.Put
            , "Account/Update"
            , Command)).Value.Result;
        }

        if (result)
        {
            Notification.AddNotification(TextResources.APP_StringKeys_Message_Success, NotificationType.Success);
        }
        else
        {
            Notification.AddNotification(TextResources.APP_StringKeys_Message_Failed, NotificationType.Error);
        }

        IsLoading = false;
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid);
        }

        AlertSeverity = Severity.Error;

        IsMessageShown = true;
    }
}

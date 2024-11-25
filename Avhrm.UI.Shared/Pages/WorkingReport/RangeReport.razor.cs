using Avhrm.Infrastructure.Client;
using MediatR;
using MudBlazor;
using System.Globalization;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class RangeReport
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
    public Severity AlertSeverity = Severity.Error;
    public DateRange Range = new();
    public PersianCalendar PersianCalendar = new();
    public List<GetChildUsersDto> ChildUsers = new();
    public GetWorkReportByDateRangeAndUserQuery Request = new();

    [CascadingParameter] public ComponentsContext Context { get; set; }

    [Inject] public ApiHandler Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsBackButtonShown = true;

        IsLoading = true;

        ChildUsers = (await Api.SendJsonAsync<GetChildUsersVm>(HttpMethod.Get
            , "Account/GetChildUsers"
            )).Value.Data;

        int persianYear = PersianCalendar.GetYear(DateTime.Now);
        
        int persianMonth = PersianCalendar.GetMonth(DateTime.Now);
        
        Range.Start = PersianCalendar.ToDateTime(persianYear, persianMonth, 1, 0, 0, 0, 0);
        
        int daysInMonth = PersianCalendar.GetDaysInMonth(persianYear, persianMonth);
        
        Range.End = PersianCalendar.ToDateTime(persianYear, persianMonth, daysInMonth, 23, 59, 59, 999);
        
        IsLoading = false;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        //Reports = (await Api.SendJsonAsync<GetUserWorkingReportByDateVm>(HttpMethod.Get
        //    , "WorkReport/GetByDate"
        //    , Request)).Value.Data;

        IsLoading = false;
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid);
        }

        IsMessageShown = true;
    }

    public async Task OnDateRangeChanged(DateRange range)
    {
        Request.FromDate = range.Start;
        Request.ToDate = range.End;
    }
}

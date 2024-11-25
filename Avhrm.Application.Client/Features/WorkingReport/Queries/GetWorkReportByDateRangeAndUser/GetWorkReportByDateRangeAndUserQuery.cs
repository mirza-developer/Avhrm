namespace Avhrm.Application.Client.Features;

public class GetWorkReportByDateRangeAndUserQuery
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string UserId { get; set; }
}

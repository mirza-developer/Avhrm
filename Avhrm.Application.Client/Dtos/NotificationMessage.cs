using Avhrm.Application.Client.Enums;

namespace Avhrm.Application.Client.Dtos;
public class NotificationMessage
{
    public string Message { get; set; }
    public NotificationType Type { get; set; }
    public TimeSpan Duration { get; set; }
    public string Icon { get; set; }
}

namespace Avhrm.UI.Shared.Components;
public class NotificationService(ISnackbar snackbar)
{
    public ComponentsContext? Context { get; set; }

    public void AddNotification(string message
        , NotificationType type
        , TimeSpan? duration = null)
    {
        if (message.HasNoValue())
        {
            return;
        }

        string? position = Defaults.Classes.Position.TopCenter;

        if (Context.ClientType == ClientType.Web)
        {
            position = Defaults.Classes.Position.BottomRight;
        }

        snackbar.Configuration.PositionClass = position;
        snackbar.Configuration.ShowTransitionDuration = 500;
        snackbar.Configuration.PreventDuplicates = false;
        snackbar.Configuration.NewestOnTop = true;

        var icon = GetIcon(type);
        var notificationDuration = duration ?? TimeSpan.FromSeconds(5);

        switch (type)
        {
            case NotificationType.Success:
                snackbar.Add(message, Severity.Success, options =>
                {
                    options.VisibleStateDuration = (int)notificationDuration.TotalMilliseconds;
                });
                break;
            case NotificationType.Error:
                snackbar.Add(message, Severity.Error, options =>
                {
                    options.VisibleStateDuration = (int)notificationDuration.TotalMilliseconds;
                });
                break;
            case NotificationType.Warning:
                snackbar.Add(message, Severity.Warning, options =>
                {
                    options.VisibleStateDuration = (int)notificationDuration.TotalMilliseconds;
                });
                break;
            case NotificationType.Info:
                snackbar.Add(message, Severity.Info, options =>
                {
                    options.VisibleStateDuration = (int)notificationDuration.TotalMilliseconds;
                });
                break;
            default:
                snackbar.Add(message, Severity.Normal, options =>
                {
                    options.VisibleStateDuration = (int)notificationDuration.TotalMilliseconds;
                });
                break;
        }
    }

    private string GetIcon(NotificationType type)
    {
        return type switch
        {
            NotificationType.Success => Icons.Material.Filled.CheckCircle,
            NotificationType.Error => Icons.Material.Filled.Error,
            NotificationType.Warning => Icons.Material.Filled.Warning,
            NotificationType.Info => Icons.Material.Filled.Info,
            _ => Icons.Material.Filled.Notifications,
        };
    }
}

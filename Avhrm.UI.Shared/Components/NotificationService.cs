namespace Avhrm.UI.Shared.Components;
public class NotificationService(ISnackbar Snackbar)
{
    public void AddNotification(string message, NotificationType type, TimeSpan? duration = null)
    {
        NotificationMessage notificationMessage = new ()
        {
            Message = message,
            Type = type,
            Duration = duration ?? TimeSpan.FromSeconds(5),
            Icon = GetIcon(type)
        };

        HandleNotificationAdded(notificationMessage);
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

    private void HandleNotificationAdded(NotificationMessage notification)
    {
        if (notification == null) return;

        Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

        Snackbar.Configuration.ShowTransitionDuration = 500;

        Snackbar.Configuration.PreventDuplicates = false;

        Snackbar.Configuration.NewestOnTop = true;

        switch (notification.Type)
        {
            case NotificationType.Success:
                Snackbar.Add(notification.Message, Severity.Success, options =>
                {
                    options.VisibleStateDuration = (int)notification.Duration.TotalMilliseconds;
                });
                break;
            case NotificationType.Error:
                Snackbar.Add(notification.Message, Severity.Error, options =>
                {
                    options.VisibleStateDuration = (int)notification.Duration.TotalMilliseconds;
                });
                break;
            case NotificationType.Warning:
                Snackbar.Add(notification.Message, Severity.Warning, options =>
                {
                    options.VisibleStateDuration = (int)notification.Duration.TotalMilliseconds;
                });
                break;
            case NotificationType.Info:
                Snackbar.Add(notification.Message, Severity.Info, options =>
                {
                    options.VisibleStateDuration = (int)notification.Duration.TotalMilliseconds;
                });
                break;
            default:
                Snackbar.Add(notification.Message, Severity.Normal, options =>
                {
                    options.VisibleStateDuration = (int)notification.Duration.TotalMilliseconds;
                });
                break;
        }
    }
}
using Microsoft.Extensions.Logging;
using Avhrm.UI.Shared;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Avhrm.UI.Mobile;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services
        , IConfiguration configuration
        , MauiAppBuilder builder)
    {
        services.AddMauiBlazorWebView();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();

        builder.Logging.AddDebug();

        builder.Logging.AddConsole();
#endif

        builder.Logging.AddEventSourceLogger();

        services.AddSharedServices(configuration);

#if ANDROID
        services.AddAndroidServices();
#elif iOS
        services.AddiOSServices();
#endif
    }
}

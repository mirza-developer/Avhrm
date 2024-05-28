using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class iOSServices
{
    public static void AddiOSServices(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
                                              .Enrich.FromLogContext().MinimumLevel.Information()
                                              .WriteTo
                                              .NSLog()
                                              .CreateLogger();
    }
}

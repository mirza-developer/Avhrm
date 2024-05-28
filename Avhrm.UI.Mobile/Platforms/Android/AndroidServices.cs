using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class AndroidServices
{
    public static void AddAndroidServices(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
                                             .Enrich.FromLogContext().MinimumLevel.Information()
                                             .WriteTo.AndroidLog()
                                             .Enrich.WithProperty(Serilog.Core.Constants.SourceContextPropertyName, "MyCustomTag") //Sets the Tag field.
                                             .CreateLogger();
    }
}

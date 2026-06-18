#region

using System.Windows;
using Serilog;

#endregion

namespace Statify;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
            .WriteTo.File(
                "log.txt",
                rollingInterval: RollingInterval.Month,
                fileSizeLimitBytes: 1000000,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
            .CreateLogger();
    }
}
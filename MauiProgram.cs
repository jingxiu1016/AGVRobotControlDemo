using MauiApp3.app.robot;
using MauiApp3.app.robot.map_manage;
using Microsoft.Extensions.Logging;
using MauiApp3.Data;

namespace MauiApp3;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddBootstrapBlazor();
        builder.Services.AddSingleton<AgvRobot>();
        builder.Services.AddSingleton<Manage>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}
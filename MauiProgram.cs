using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using C3P1.App.Services;
using Microsoft.Extensions.Logging;

namespace C3P1.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            var configuration = builder.Configuration;

            builder.Services.AddMauiBlazorWebView();

            // Register Blazorise related services
            builder.Services
                .AddBlazorise(options =>
                {
                    options.ProductToken = "token"; //configuration["Blazorise:ProductToken"];
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddScoped<NavState>();

            return builder.Build();
        }
    }
}

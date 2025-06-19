using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UAS.ViewModels;

namespace UAS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //Viewa
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddSingleton<TermsAndConditionsPage>();

            //ViewModels
            builder.Services.AddSingleton<LoginViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

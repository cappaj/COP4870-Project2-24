using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AMAZON.MAUI.ViewModels;

namespace AMAZON.MAUI
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

            builder.Services.AddSingleton<InventoryService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<InventoryViewModel>();
            builder.Services.AddSingleton<ShopViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

    internal class InventoryService
    {
    }
}

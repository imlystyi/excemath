
#region Usings-частина
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace excemath;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		// Налаштування первинного конфігуратора.
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
			//.ConfigureServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Comfortaa-Light.ttf", "ComfortaLight");
                fonts.AddFont("JosefinSans-Medium.ttf", "JosefinSansMedium");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace excemath;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Comfortaa-Light.ttf", "ComfortaLight");
                fonts.AddFont("JosefinSans-Medium.ttf", "JosefinSansMedium");
				fonts.AddFont("Montserrat-Regular.ttf", "Regular");
                fonts.AddFont("Montserrat-ExtraLight.ttf", "ExtraLight");
                fonts.AddFont("Montserrat-Light.ttf", "Light");
				fonts.AddFont("Montserrat-Bold.ttf", "Bold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

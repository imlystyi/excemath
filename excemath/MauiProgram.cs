using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;

namespace excemath;

/// <summary>
/// Представляє можливості для ініціалізації додатку.
/// </summary>
public static class MauiProgram
{
    #region Методи

	/// <summary>
	/// Ініціалізує додаток, використовуючи заданий в коді <see cref="MauiAppBuilder"/>.
	/// </summary>
	/// <returns>
	/// Додаток як <see cref="MauiApp"/>.
	/// </returns>
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

    #endregion
}

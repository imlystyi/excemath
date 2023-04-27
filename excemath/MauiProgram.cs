﻿#region Usings-частина

using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;


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
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

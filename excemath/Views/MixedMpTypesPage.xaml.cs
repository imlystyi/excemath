using CSharpMath.SkiaSharp;
using SkiaSharp;
using CSharpMath;
using SkiaSharp.Views.Maui;
using Microsoft.Maui.Graphics;

namespace excemath.Views;

public partial class MixedMpTypesPage : ContentPage
{
	public MixedMpTypesPage()
	{
		InitializeComponent();
        
    }
    void OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKImageInfo info = args.Info;
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        var painter = new CSharpMath.SkiaSharp.MathPainter();
        painter.FontSize = 40;
        painter.LaTeX = @"\int_a^b f(x) dx";
        painter.Draw(canvas);

    }
    private void OkButton_Clicked(object sender, EventArgs e)
    {

    }
    private void ResetButton_Clicked(object sender, EventArgs e)
    {
        
    }
}
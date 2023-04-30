using SkiaSharp;
using SkiaSharp.Views.Maui;
using CSharpMath.SkiaSharp;
using excemathApi.Models;

namespace excemath.Views;

[QueryProperty(nameof(ItemType), nameof(ItemType))]
public partial class AnswerEnteringPage : ContentPage
{
    public AnswerEnteringPage()
	{
		InitializeComponent();
        
    }

    public string ItemType
    {
        set => LoadExpression(value);
    }

    private MathProblem _mathProblem;
    private SolvedMathProblem _solvedMathProblem;

    void OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    { 
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = @"\int_a^b f(x) dx"
        };

        painter.Draw(canvas);
    }

    private void OkButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ResetButton_Clicked(object sender, EventArgs e)
    {
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void LoadExpression(string parameters)
    {
        if (parameters == "mixed")
        {
            _mathProblem = await MathProblem.GetMixed();
        }
    }
}
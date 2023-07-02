using CommunityToolkit.Maui.Views;
using CSharpMath.SkiaSharp;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace excemath.Views;

/// <summary>
/// Представляє спливаюче вікно для підказки.
/// </summary>
public partial class TipPopup : Popup
{
    #region Поля

    private readonly string _latex;

    #endregion

    #region Конструктори

    /// <summary>
    /// Ініціалізує спливаюче вікно <see cref="TipPopup"/>.
    /// </summary>
    public TipPopup() => InitializeComponent();

    /// <summary>
    /// Ініціалізує спливаюче вікно <see cref="TipPopup"/> із вказаними текстом підказки, LaTeX-частиною та висотою LaTeX-частини.
    /// </summary>
    /// <param name="text">Текст підказки.</param>
    /// <param name="latex">LaTeX-частина підказки.</param>
    /// <param name="heightRequest">Висота LaTeX-частини підказки.</param>
    public TipPopup(string text, string latex, int heightRequest, int leftMargin)
    {
        InitializeComponent();

        TipText.Text = text;
        TipLatexCanvas.HeightRequest = heightRequest;
        TipLatexCanvas.Margin = new Thickness(leftMargin, 0, 0, 0);
        _latex = latex;
    }

    public void TipLatexCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _latex
        };

        painter.Draw(canvas);
    }

    #endregion
}
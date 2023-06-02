using CommunityToolkit.Maui.Views;
using CSharpMath.SkiaSharp;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace excemath.Views;

/// <summary>
/// ����������� ��������� ���� ��� �������.
/// </summary>
public partial class TipPopup : Popup
{
    #region ����

    private readonly string _latex;

    #endregion

    #region ������������

    /// <summary>
    /// �������� ��������� ���� <see cref="TipPopup"/>.
    /// </summary>
    public TipPopup() => InitializeComponent();

    /// <summary>
    /// �������� ��������� ���� <see cref="TipPopup"/> �� ��������� ������� �������, LaTeX-�������� �� ������� LaTeX-�������.
    /// </summary>
    /// <param name="text">����� �������.</param>
    /// <param name="latex">LaTeX-������� �������.</param>
    /// <param name="heightRequest">������ LaTeX-������� �������.</param>
    public TipPopup(string text, string latex, int heightRequest)
    {
        InitializeComponent();

        TipText.Text = text;
        TipLatexCanvas.HeightRequest = heightRequest;
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
#define DEMO_ANSWER

using SkiaSharp;
using SkiaSharp.Views.Maui;
using CSharpMath.SkiaSharp;
using excemath.Models;

namespace excemath.Views;

/// <summary>
/// ����������� ������� ��� ����'������ ����������� ������
/// </summary>
[QueryProperty(nameof(ItemValue), nameof(ItemValue))]
public partial class MpAnswerEnteringPage : ContentPage
{
    #region ����

    private MathProblem _mathProblem;
    private int _answer;

    #endregion

    #region ������������ 

    /// <summary>
    /// �������� ������� <see cref="MpAnswerEnteringPage"/>.
    /// </summary>
    public MpAnswerEnteringPage() => InitializeComponent();

    #endregion

    #region ����������

    /// <summary>
    /// ���������� �������� ��� ���������� �������� �������.
    /// </summary>
    /// <remarks>
    /// ��� ����������� ������� ����� <see cref="LoadExpression(string)"/> � ��������� ���� ���������� � ����� ���������.
    /// </remarks>
    public string ItemValue
    {
        set => LoadExpression(value);
    }

    #endregion

    #region ��������� ����    

    private void Option1_CheckedChanged(object sender, CheckedChangedEventArgs args) => _answer = 1;

    private void Option2_CheckedChanged(object sender, CheckedChangedEventArgs args) => _answer = 2;

    private void Option3_CheckedChanged(object sender, CheckedChangedEventArgs args) => _answer = 3;

    private void Option4_CheckedChanged(object sender, CheckedChangedEventArgs args) => _answer = 4;

    private void QuestionCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetQuestionLatex()
        };

        painter.Draw(canvas);
    }

    private void AnswerCanvas1_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetAnswerOption(1)
        };

        painter.Draw(canvas);
    }

    private void AnswerCanvas2_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetAnswerOption(2)
        };

        painter.Draw(canvas);
    }

    private void AnswerCanvas3_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetAnswerOption(3)
        };

        painter.Draw(canvas);
    }

    private void AnswerCanvas4_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetAnswerOption(4)
        };

        painter.Draw(canvas);
    }

    private void OkButton_Clicked(object sender, EventArgs e)
    {
        if (_answer == _mathProblem.GetAnswer())
        {
            Console.WriteLine("��������� �������!");

            // TODO: ���������� 䳿 ��� ������� ��������� ������
        }

        else
        {
            Console.WriteLine("����������� �������!");

            // TODO: ���������� 䳿 ��� ������� ����������� ������
        }
    }    

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MpKind.Text = _mathProblem.GetKindAsText();
        MpQuestion.Text = _mathProblem.GetQuestionText();
    }

    #endregion

    #region ������

    private void LoadExpression(string parameters)
    {
        if (parameters == "m")
        {

#if DEMO_ANSWER
            MathProblem _NO_SSL_mathProblem_ = new()
            {
                Id = 1,
                Question = @"����'���� ��������. /expr \int_{0}^{1} x^2 dx",
                Answer = @"2 /opt \frac{1}{6}/n\frac{1}{3}/n\frac{1}{9}/n\frac{1}{27}",
                Kind = MathProblemKinds.TableIntegral
            };

            _mathProblem = _NO_SSL_mathProblem_;
        
#else
            Task<MathProblem> task = Task.Run(MathProblem.GetMixed);
            task.Wait();

            _mathProblem = task.Result;
#endif
        }
    }

    #endregion
}

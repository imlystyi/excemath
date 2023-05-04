using SkiaSharp;
using SkiaSharp.Views.Maui;
using CSharpMath.SkiaSharp;
using excemathApi.Models;

namespace excemath.Views;

[QueryProperty(nameof(ItemValue), nameof(ItemValue))]
public partial class MpAnswerEnteringPage : ContentPage
{
    #region Поля

    private MathProblem _mathProblem;
    private int _answer;

    #endregion

    #region Конструктори 

    /// <summary>
    /// Ініціалізує сторінку <see cref="MpAnswerEnteringPage"/>.
    /// </summary>
    public MpAnswerEnteringPage() => InitializeComponent();

    #endregion

    #region Властивості

    /// <summary>
    /// Встановлює значення для визначення поведінки сторінки.
    /// </summary>
    /// <remarks>
    /// При встановленні викликає метод <see cref="LoadExpression(string)"/> зі значенням цієї властивості у якості аргумента.
    /// </remarks>
    public string ItemValue
    {
        set => LoadExpression(value);
    }

    #endregion

    #region Обробники подій    

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

    private void AnswerCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _mathProblem.GetAnswerOptions()
        };

        painter.Draw(canvas);
    }

    private void OkButton_Clicked(object sender, EventArgs e)
    {
        if (_answer == _mathProblem.GetAnswer())
        {
            Console.WriteLine("Правильна відповідь!");

            // TODO: реалізувати дії при введенні правильної відповіді
        }

        else
        {
            Console.WriteLine("Неправильна відповідь!");

            // TODO: реалізувати дії при введенні неправильної відповіді
        }
    }

    private void Option1_CheckedChanged(object sender, CheckedChangedEventArgs e) => _answer = 1;

    private void Option2_CheckedChanged(object sender, CheckedChangedEventArgs e) => _answer = 2;

    private void Option3_CheckedChanged(object sender, CheckedChangedEventArgs e) => _answer = 3;

    private void Option4_CheckedChanged(object sender, CheckedChangedEventArgs e) => _answer = 4;

    #endregion

    #region Методи

    private void LoadExpression(string parameters)
    {
        if (parameters == "m")
        {
            Task<MathProblem> task = Task.Run(MathProblem.GetMixed);
            task.Wait();

            _mathProblem = task.Result;   
        }
    }

    private static string ConvertKindToTopic(MathProblemKinds kind)
    {
        return kind switch
        {
            MathProblemKinds.TableIntegral => "Криволінійні інтеграли",
            _ => "...",
        };
    }

    #endregion

    #region Перезаписані обробники подій

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MpTopic.Text = ConvertKindToTopic(_mathProblem.Kind);
    }

    #endregion
}
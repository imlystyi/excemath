/* excemath - an app for preparing for math exams.
 * Copyright (C) 2023 miu-miu enjoyers

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>. */

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CSharpMath.SkiaSharp;
using excemath.Models;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace excemath.Views;

/// <summary>
/// Представляє сторінку для розв'язання математичної задачі
/// </summary>
public partial class MpAnswerEnteringPage : ContentPage
{
    #region Поля

    private readonly bool _isSolved;
    private readonly bool _isByKind;
    private readonly MathProblemKinds _kind;

#nullable enable

    private readonly MathProblem? _mathProblem;
    private readonly SolvedMathProblem? _solvedMathProblem;

#nullable restore

    private int _answer;

    #endregion

    #region Конструктори 

    /// <summary>
    /// Ініціалізує сторінку <see cref="MpAnswerEnteringPage"/> з випадковим математичним прикладом.
    /// </summary>
    public MpAnswerEnteringPage()
    {
        _mathProblem = Task.Run(MathProblem.GetMixed).Result;
        _isSolved = false;
        _isByKind = false;

        InitializeComponent();
    }

    /// <summary>
    /// Ініціалізує сторінку <see cref="MpAnswerEnteringPage"/> з математичним прикладом заданого виду.
    /// </summary>
    /// <param name="kind">Вид математичного прикладу.</param>
    /// <param name="isSolved">Визначає, чи є математична проблема розв'язаною.</param>s
    public MpAnswerEnteringPage(MathProblemKinds kind, bool isSolved = false)
    {
        _isSolved = isSolved;

        if (!_isSolved)
            _mathProblem = Task.Run(() => MathProblem.GetByKind(kind)).Result;

        else
            _solvedMathProblem = Task.Run(() => SolvedMathProblem.GetByKind(kind)).Result;

        _isByKind = true;
        _kind = kind;

        InitializeComponent();
    }

    #endregion

    #region Обробники подій    

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
            LaTeX = (_mathProblem is not null) ? _mathProblem.GetQuestionLatex() : _solvedMathProblem.GetQuestionLatex()
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
            LaTeX = (_mathProblem is not null) ? _mathProblem.GetAnswerOption(1) : _solvedMathProblem.GetAnswerOption(1)
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
            LaTeX = (_mathProblem is not null) ? _mathProblem.GetAnswerOption(2) : _solvedMathProblem.GetAnswerOption(2)
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
            LaTeX = (_mathProblem is not null) ? _mathProblem.GetAnswerOption(3) : _solvedMathProblem.GetAnswerOption(3)
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
            LaTeX = (_mathProblem is not null) ? _mathProblem.GetAnswerOption(4) : _solvedMathProblem.GetAnswerOption(4)
        };

        painter.Draw(canvas);
    }

    private async void SendAnswerButton_Tapped(object sender, TappedEventArgs args)
    {
        if (_answer == ((_mathProblem is not null) ? _mathProblem.GetAnswerNumber() : _solvedMathProblem.GetAnswerNumber()))
        {
            UserGetRequest currentUser = await User.GetCurrentProfile();

            string nickname = currentUser.Nickname;
            UserUpdateRequest userUpdateRequest = new()
            {
                Password = User.GetCurrentPassword(),
                RightAnswers = currentUser.RightAnswers + 1,
                WrongAnswers = currentUser.WrongAnswers,
            };

            _ = User.TryUpdate(nickname, userUpdateRequest);

            string text = "Правильна відповідь!";
            double fontSize = 14;
            ToastDuration duration = ToastDuration.Short;
            CancellationTokenSource cancellationTokenSource = new();

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);

            var currentPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];

            if (_isByKind)
                await Navigation.PushAsync(new MpAnswerEnteringPage(_kind, _isSolved));

            else
                await Navigation.PushAsync(new MpAnswerEnteringPage());

            Navigation.RemovePage(currentPage);
        }

        else
        {
            UserGetRequest currentUser = await User.GetCurrentProfile();

            string nickname = currentUser.Nickname;
            UserUpdateRequest userUpdateRequest = new()
            {
                Password = User.GetCurrentPassword(),
                RightAnswers = currentUser.RightAnswers,
                WrongAnswers = currentUser.WrongAnswers + 1,
            };

            _ = User.TryUpdate(nickname, userUpdateRequest);

            string text = "Неправильна відповідь!";
            double fontSize = 14;
            ToastDuration duration = ToastDuration.Short;
            CancellationTokenSource cancellationTokenSource = new();

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private void HelpButton_Clicked(object sender, EventArgs args)
    {
        var popup = (_mathProblem is not null)
            ? new TipPopup(_mathProblem.GetTipText(), _mathProblem.GetTipLatex(), _mathProblem.GetTipHeight(), _mathProblem.GetTipLeftMargin())
            : new TipPopup(_solvedMathProblem.GetSolutionText(), _solvedMathProblem.GetSolutionLatex(), _solvedMathProblem.GetSolutionHeight(), _solvedMathProblem.GetSolutionLeftMargin());

        this.ShowPopup(popup);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MpKind.Text = (_mathProblem is not null) ? _mathProblem.GetKindAsText() : _solvedMathProblem.GetKindAsText();
        MpQuestion.Text = (_mathProblem is not null) ? _mathProblem.GetQuestionText() : _solvedMathProblem.GetQuestionText();       
    }

    #endregion
}

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

using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє сторінку вибору конкретного виду розв'язаної математичної задачі для підготовки до сесії.
/// </summary>
public partial class SolvedMpStudentExamsPreparingPage : ContentPage
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує сторінку <see cref="SolvedMpStudentExamsPreparingPage"/>.
    /// </summary>
    public SolvedMpStudentExamsPreparingPage() => InitializeComponent();

    #endregion

    #region Обробники подій

    private void MultipleIntegralsButton_Tapped(object sender, TappedEventArgs args) =>
    Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.MultipleIntegral, true));

    private void LineIntegralsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LineIntegral, true));

    private void LimitsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.Limit, true));

    private void LinearEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LinearEquation, true));

    private void QuadraticEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.QuadraticEquation, true));

    private void IrrationalEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.IrrationalEquation, true));

    private void ExponentialEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.ExponentialEquation, true));

    private void LogarithmicEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LogarithmicEquation, true));

    private void TrigonometricEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.TrigonometricEquation, true));

    private void LinearInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LinearInequality, true));

    private void QuadraticInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.QuadraticInequality, true));

    private void IrrationalInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.IrrationalInequality, true));

    private void ExponentialInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.ExponentialInequality, true));

    private void LogarithmicInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LogarithmicInequality, true));

    private void TrigonometricInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.TrigonometricInequality, true));

    private void NumericalSequencesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.NumericalSequence, true));

    private void FunctionsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.Function, true));

    #endregion
}
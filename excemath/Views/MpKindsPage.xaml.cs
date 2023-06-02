using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє сторінку вибору конкретного виду математичної задачі.
/// </summary>
public partial class MpKindsPage : ContentPage
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує сторінку <see cref="MpKindsPage"/>.
    /// </summary>
    public MpKindsPage() => InitializeComponent();

    #endregion

    #region Обробники подій

    private void TableIntegralsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.TableIntegral));

    private void MultipleIntegralsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.MultipleIntegral));

    private void LineIntegralsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LineIntegral));

    private void MatrixButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.Matrix));

    private void LimitsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.Limit));

    private void LinearEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LinearEquation));

    private void QuadraticEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.QuadraticEquation));

    private void IrrationalEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.IrrationalEquation));

    private void ExponentialEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.ExponentialEquation));

    private void LogarithmicEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LogarithmicEquation));

    private void TrigonometricEquationsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.TrigonometricEquation));

    private void LinearInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LinearInequality));

    private void QuadraticInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.QuadraticInequality));

    private void IrrationalInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.IrrationalInequality));

    private void ExponentialInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.ExponentialInequality));

    private void LogarithmicInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.LogarithmicInequality));

    private void TrigonometricInequalitiesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.TrigonometricInequality));

    private void NumericalSequencesButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.NumericalSequence));

    private void FunctionsButton_Tapped(object sender, TappedEventArgs args) =>
        Navigation.PushAsync(new MpAnswerEnteringPage(MathProblemKinds.Function));

    #endregion
}
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
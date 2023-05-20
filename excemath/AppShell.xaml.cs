using CommunityToolkit.Maui.Views;
using excemath.Models;
using excemath.Views;

namespace excemath;

/// <summary>
/// Представляє оболонку та головну сторінку додатку.
/// </summary>
public partial class AppShell : Shell
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує екземпляр класу <see cref="AppShell"/>.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();

        MathProblem.GenerateMixedKey();
        MathProblem.GenerateByKindKey();

        if (string.IsNullOrEmpty(User.GetCurrentNickname()))
        {
            this.ShowPopup(new AuthorizationPopup());
        }
    }

    #endregion

    #region Обробники подій

    private void HowToUseButton_Clicked(object sender, EventArgs args) => this.ShowPopup(new HowToUsePopup());

    private void ProfileButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new ProfilePage());

    private void AchievementsButton_Clicked(object sender, TappedEventArgs args) => this.ShowPopup(new AuthorizationPopup());

    private void MixedKindsButton_Clicked(object sender, EventArgs args) => Current.GoToAsync($"{nameof(MpAnswerEnteringPage)}?{nameof(MpAnswerEnteringPage.ItemValue)}=m");

    private void ChooseKindButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new MpKindsPage());

    private void ZNOPreparingButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new SolvedMpZNOPreparingPage());

    private void StudentExamsPreparingButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new SolvedMpStudentExamsPreparingPage());

    private void AboutProgramButton_Clicked(object sender, EventArgs args) => Navigation.PushAsync(new AboutProgramPage());

#endregion
}

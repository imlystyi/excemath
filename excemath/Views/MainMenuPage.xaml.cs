using CommunityToolkit.Maui.Views;

namespace excemath.Views;

public partial class MainMenuPage : ContentPage
{
    #region Конструктори

    public MainMenuPage() => InitializeComponent();

    #endregion

    #region Обробники подій

    private void MpMixedButton_Clicked(object sender, EventArgs e) => Shell.Current.GoToAsync($"{nameof(MpAnswerEnteringPage)}?{nameof(MpAnswerEnteringPage.ItemValue)}=m");

    private void SingleMpTypeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MpKindsPage());
    }

    private void LevelsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MpLevelsPage());
    }

    private void StudentExamsPreparingButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MpStudentExamsPreparingPage());
    }

    private void ZNOPreparingButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MpZNOPreparingPage());
    }

    private void HowToUseButton_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new HowToUsePage());
    }

    #endregion

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}
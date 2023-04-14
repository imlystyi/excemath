namespace excemath.Views;

public partial class MainMenuPage : ContentPage
{
    #region Конструктори сторінки

    public MainMenuPage() => InitializeComponent();

    #endregion

    #region Обробники подій

    private void MixedMpButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MixedMpTypesPage());
    }

    private void SingleMpTypeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SingleMpTypePage());
    }

    private void LevelsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LevelsPage());
    }

    private void StudentExamsPreparingButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StudentExamsPreparingPage());
    }

    private void ZNOPreparingButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ZNOPreparingPage());
    }

    #endregion
}
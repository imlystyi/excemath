namespace excemath.Views;

public partial class MainMenuPage : ContentPage
{
    #region ������������ �������

    public MainMenuPage() => InitializeComponent();

    #endregion

    #region ��������� ����

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
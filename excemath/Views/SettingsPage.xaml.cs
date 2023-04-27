namespace excemath.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void AboutProgramButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AboutProgramPage());
    }
}
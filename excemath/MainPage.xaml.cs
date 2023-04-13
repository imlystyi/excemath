namespace excemath;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

    private void AllTypesOfMathProblemsPage_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AllTypesOfMathProblemsPage());
    }

    private void DifferentTypesPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DifferentTypesPage());
    }

    private void LevelsPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LevelsPage());
    }

    private void PrepareForExamPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PrepareForExamPage());
    }

    private void PrepareForZNOPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PrepareForZNOPage());
    }
}


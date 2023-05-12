using CommunityToolkit.Maui.Views;
using excemath.Views;

namespace excemath;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MpAnswerEnteringPage), typeof(MpAnswerEnteringPage));
    }

    
    private void SettingsButton_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new SettingsPage());
    private void HowToUseButton_Clicked(object sender, EventArgs args) => this.ShowPopup(new HowToUsePage());
    private void ProfileButton_Clicked(object sender, TappedEventArgs e) => Navigation.PushAsync(new ProfilePage());
    private void AchievementsButton_Clicked(object sender, TappedEventArgs e) => Navigation.PushAsync(new AchievementsPage());

    private void MixedKindsButton_Clicked(object sender, EventArgs args) => Current.GoToAsync($"{nameof(MpAnswerEnteringPage)}?{nameof(MpAnswerEnteringPage.ItemValue)}=m");

    private void ChooseKindButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new MpKindsPage());

    private void ZNOPreparingButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new SolvedMpZNOPreparingPage());

    private void StudentExamsPreparingButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new SolvedMpStudentExamsPreparingPage());

    


}

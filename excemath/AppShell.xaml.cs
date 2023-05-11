using excemath.Views;

namespace excemath;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.MpAnswerEnteringPage), typeof(Views.MpAnswerEnteringPage));
    }

    private void MixedKindsButton_Clicked(object sender, EventArgs args) => Current.GoToAsync($"{nameof(MpAnswerEnteringPage)}?{nameof(MpAnswerEnteringPage.ItemValue)}=m");

    private void ChooseKindButton_Clicked(object sender, TappedEventArgs args) => Navigation.PushAsync(new MpKindsPage());
}

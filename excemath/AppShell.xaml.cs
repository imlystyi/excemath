namespace excemath;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.MpAnswerEnteringPage), typeof(Views.MpAnswerEnteringPage));
    }
}

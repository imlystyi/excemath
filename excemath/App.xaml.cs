using excemath.Models;
using excemath.Views;

namespace excemath;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		MathProblem.GenerateMixedKey();
		MathProblem.GenerateByKindKey();
	}
}

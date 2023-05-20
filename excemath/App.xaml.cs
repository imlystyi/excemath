using excemath.Models;

namespace excemath;

/// <summary>
/// Представляє ядро додатку.
/// </summary>
public partial class App : Application
{
    #region Конструктори

    /// <summary>
    /// Створює екземпляр класу <see cref="App"/>.
    /// </summary>
    public App()
    {
        InitializeComponent();        

        MainPage = new AppShell();
    }

    #endregion
}

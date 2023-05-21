using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє сторінку профілю.
/// </summary>
public partial class ProfilePage : ContentPage
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує сторінку <see cref="ProfilePage"/>.
    /// </summary>
    public ProfilePage()
    {
        InitializeComponent();

        
    }

    #endregion

    #region Обробники подій

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        UserLevel.Text = await User.GetCurrentLevelText();
    }

    #endregion

    #region Методи

    #endregion
}
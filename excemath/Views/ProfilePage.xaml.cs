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

        UserLevel.Text = User.GetCurrentLevelText();
    }

    #endregion

    #region Обробники подій

    protected override void OnAppearing()
    {
        base.OnAppearing();


    }

    #endregion

    #region Методи

    #endregion
}
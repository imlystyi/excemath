using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє сторінку профілю.
/// </summary>
public partial class ProfilePage : ContentPage
{
    #region Поля

    UserGetRequest currentUser;

    #endregion

    #region Конструктори

    /// <summary>
    /// Ініціалізує сторінку <see cref="ProfilePage"/>.
    /// </summary>
    public ProfilePage() => InitializeComponent();    

    #endregion

    #region Обробники подій

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        currentUser = await User.GetCurrentProfile();

        UserLevel.Text = User.GetCurrentLevelText(currentUser, out double rating);
        Rating.Text = rating.ToString() + " %";        
        RightAnswers.Text = currentUser.RightAnswers.ToString();
        WrongAnswers.Text = currentUser.WrongAnswers.ToString();
    }

    #endregion

    #region Методи

    #endregion
}
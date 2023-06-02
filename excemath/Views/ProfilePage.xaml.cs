using CommunityToolkit.Maui.Views;
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

    private void ChangePasswordButton_Tapped(object sender, TappedEventArgs args) => this.ShowPopup(new ChangePasswordPopup());

    // TODO: перезавантаження сторінки після скинення досягнень
    private async void ResetDataButton_Tapped(object sender, TappedEventArgs args)
    {
        string nickname = currentUser.Nickname;
        UserUpdateRequest userUpdateRequest = new()
        {
            Password = User.GetCurrentPassword(),
            RightAnswers = 0,
            WrongAnswers = 0,
        };

        _ = User.TryUpdate(nickname, userUpdateRequest);

        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        currentUser = await User.GetCurrentProfile();

        UserLevel.Text = User.GetCurrentLevelText(currentUser, out double rating);
        Rating.Text = rating.ToString("0.##") + " %";
        RightAnswers.Text = currentUser.RightAnswers.ToString();
        WrongAnswers.Text = currentUser.WrongAnswers.ToString();
    }

    #endregion 
}

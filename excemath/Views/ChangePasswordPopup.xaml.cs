using CommunityToolkit.Maui.Views;
using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє спливаюче вікно для зміни паролю.
/// </summary>
public partial class ChangePasswordPopup : Popup
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує спливаюче вікно <see cref="ChangePasswordPopup"/>.
    /// </summary>
    public ChangePasswordPopup() => InitializeComponent();

    #endregion

    #region Обробники подій

    private async void ConfirmButton_Tapped(object sender, TappedEventArgs args)
    {
        UserGetRequest currentUser = await User.GetCurrentProfile();
        string nickname = currentUser.Nickname;

        UserUpdateRequest userUpdateRequest = new()
        {
            Password = NewPasswordEntry.Text,
            RightAnswers = currentUser.RightAnswers,
            WrongAnswers = currentUser.WrongAnswers,
        };

        string result = await User.TryUpdate(nickname, userUpdateRequest);

        if (string.IsNullOrEmpty(result))
            Close();

        NewPasswordEntry.Placeholder = result;
    }

    #endregion
}

using CommunityToolkit.Maui.Views;
using excemath.Models;

namespace excemath.Views;

/// <summary>
/// Представляє спливаюче вікно для авторизації користувача.
/// </summary>
public partial class AuthorizationPopup : Popup
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує спливаюче вікно <see cref="AuthorizationPopup"/>.
    /// </summary>
    public AuthorizationPopup() => InitializeComponent();

    #endregion

    #region Обробники подій

    private async void AuthorizeButton_Clicked(object sender, TappedEventArgs args)
    {
        if (string.IsNullOrEmpty(NicknameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            return;        

        string nickname = NicknameEntry.Text;
        string password = PasswordEntry.Text;

        UserIdentity userIdentity = new()
        {
            Nickname = nickname,
            Password = password
        };

        bool success = await User.TryAuthorize(userIdentity);

        if (!success)
            IdentitySuccess.Text = "Неправильний нікнейм або пароль!";

        else
            Close();
    }

    private async void RegisterButton_Clicked(object sender, TappedEventArgs args)
    {
        if (string.IsNullOrEmpty(NicknameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            return;

        string nickname = NicknameEntry.Text;
        string password = PasswordEntry.Text;

        UserIdentity userIdentity = new()
        {
            Nickname = nickname,
            Password = password
        };

        string errors = await User.TryRegister(userIdentity);

        if (!string.IsNullOrEmpty(errors))
            IdentitySuccess.Text = errors;        

        else 
            Close();
    }

    #endregion
}
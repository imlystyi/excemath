namespace excemath.Models;

/// <summary>
/// Представляє користувача, який має унікальний псевдонім, пароль, кількість правильних та неправильних відповідей.
/// </summary>
public class User
{
    #region Поля

    private const string _SAVED_LOGIN_USERNAME_PREFERENCES_KEY = "u_nickname";
    private const string _SAVED_LOGIN_PASSWORD_PREFERENCES_KEY = "u_password";
    private const string _IS_LOGINED = "u_logined";

    #endregion

    #region Властивості 

    /// <summary>
    /// Повертає або встановлює унікальний псевдонім поточного користувача.
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// Повертає або встановлює пароль поточного користувача.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Повертає або встановлює кількість правильних відповідей поточного користувача.
    /// </summary>
    /// <remarks>
    /// Має значення 0 за замовчуванням.
    /// </remarks>
    public int RightAnswers { get; set; } = 0;

    /// <summary>
    /// Повертає або встановлює кількість неправильних відповідей поточного користувача.
    /// </summary>
    /// <remarks>
    /// Має значення 0 за замовчуванням.
    /// </remarks>
    public int WrongAnswers { get; set; } = 0;

    #endregion

    #region Методи

    /// <inheritdoc cref="ApiClient.TryAuthorizeUser(UserIdentity)"/>
    public static async Task<bool> TryAuthorize(UserIdentity userIdentity)
    {
        bool success = await ApiClient.TryAuthorizeUser(userIdentity);

        if (success)
        {
            Preferences.Set(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userIdentity.Password);
            Preferences.Set(_IS_LOGINED, true);
        }

        return success;
    }

    /// <inheritdoc cref="ApiClient.TryRegisterUser(UserIdentity)"/>
    public static async Task<string> TryRegister(UserIdentity userIdentity)
    {
        string errors = await ApiClient.TryRegisterUser(userIdentity);

        if (!string.IsNullOrEmpty(errors))
        {
            Preferences.Set(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_IS_LOGINED, true);
        }

        return errors;
    }

    /// <inheritdoc cref="ApiClient.TryUpdateUser(string, UserUpdateRequest)"/>
    public static async Task<string> TryUpdate(string nickname, UserUpdateRequest userUpdateRequest)
    {
        string errors = await ApiClient.TryUpdateUser(nickname, userUpdateRequest);

        if (string.IsNullOrEmpty(errors))
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userUpdateRequest.Password);

        return errors;
    }

#nullable enable

    /// <summary>
    /// Повертає профіль авторизованого в додатку користувача як <see cref="UserGetRequest"/>.
    /// </summary>
    public static async Task<UserGetRequest?> GetCurrentProfile()
    {
        string nickname = GetCurrentNickname();

        return await ApiClient.GetUser(nickname);
    }

#nullable restore

    public static string GetCurrentNickname() => Preferences.Get(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, string.Empty);

    #endregion
}

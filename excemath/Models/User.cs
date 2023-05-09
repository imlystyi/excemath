using excemath.Models;
using Java.Util;

namespace excemath.Models;

/// <summary>
/// Представляє звичайну модель користувача, яка має унікальний псевдонім, пароль, кількість правильних та неправильних відповідей.
/// </summary>
/// <remarks>
/// Має первинний ключ <see cref="Nickname"/>.
/// </remarks>
public class User
{
    #region Поля

    private const string _SAVED_LOGIN_USERNAME_PREFERENCES_KEY = "u_nickname";
    private const string _SAVED_LOGIN_PASSWORD_PREFERENCES_KEY = "u_password";
    private const string _IS_LOGINED
    #endregion

    #region Властивості 

    /// <summary>
    /// Повертає або встановлює псевдонім користувача.
    /// </summary>
    /// <returns>
    /// Псевдонім користувача як <see cref="string"/>. Є первинним ключом.
    /// </returns>
    public string Nickname { get; set; }

    /// <summary>
    /// Повертає або встановлює пароль користувача.
    /// </summary>
    /// <returns>
    /// Пароль користувача як <see cref="string"/>.
    /// </returns>
    public string Password { get; set; }

    /// <summary>
    /// Повертає або встановлює кількість правильних відповідей користувача.
    /// </summary>
    /// <remarks>
    /// Має значення 0 за замовчуванням.
    /// </remarks>
    /// <returns>
    /// Кількість правильних відповідей користувача як <see cref="int"/>.
    /// </returns>
    public int RightAnswers { get; set; } = 0;

    /// <summary>
    /// Повертає або встановлює кількість неправильних відповідей користувача.
    /// </summary>
    /// <remarks>
    /// Має значення 0 за замовчуванням.
    /// </remarks>
    /// <returns>
    /// Кількість неправильних відповідей користувача як <see cref="int"/>.
    /// </returns>
    public int WrongAnswers { get; set; } = 0;

    #endregion

    #region Методи

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <returns></returns>
    public static async Task<bool> TryAuthorize(UserIdentity userIdentity)
    {
        bool success = await Client.TryAuthorizeUser(userIdentity);

        if (success)
        {
            Preferences.Set(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userIdentity.Password);
            Preferences.Set(_IS_LOGINED, true);
        }

        return success;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <returns></returns>
    public static async Task<string> TryRegister(UserIdentity userIdentity)
    {
        string errors = await Client.TryRegisterUser(userIdentity);

        if (!string.IsNullOrEmpty(errors))
        {
            Preferences.Set(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userIdentity.Nickname);
            Preferences.Set(_IS_LOGINED, true);
        }

        return errors;
    }

    public static async Task<bool>
    #endregion
}

/* excemath - an app for preparing for math exams.
 * Copyright (C) 2023 miu-miu enjoyers

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>. */

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

    /// <summary>
    /// Змінює пароль користувача.
    /// </summary>
    /// <param name="nickname">Псевдонім користувача.</param>
    /// <param name="password">Новий пароль користувача.</param>
    public static async Task<string> TryChangePassword(string nickname, string password, UserUpdateRequest userUpdateRequest)
    {
        userUpdateRequest.Password = password;

        string errors = await ApiClient.TryUpdateUser(nickname, userUpdateRequest);

        if (string.IsNullOrEmpty(errors))
            Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, userUpdateRequest.Password);

        return errors;
    }

    /// <summary>
    /// Повертає псевдонім авторизованого в додатку користувача як <see cref="string"/>.
    /// </summary>
    /// <returns></returns>
    public static string GetCurrentNickname() => Preferences.Get(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, string.Empty);

    public static void SetCurrentNickname(string nickname) => Preferences.Set(_SAVED_LOGIN_USERNAME_PREFERENCES_KEY, nickname);

    public static void SetCurrentPassword(string password) => Preferences.Set(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, password);

    public static string GetCurrentPassword() => Preferences.Get(_SAVED_LOGIN_PASSWORD_PREFERENCES_KEY, string.Empty);

    public static string GetCurrentLevelText(UserGetRequest currentUser, out double rating)
    {
        rating = GetRating(currentUser);
        return $"{currentUser.Nickname}, " + rating switch
        {
            < 10 => "тобі варто розвиватись далі, але це вже непогано!",
            < 30 => "ти на правильному шляху!",
            < 50 => "ти маєш класні результати! Продовжуй далі!",
            < 70 => "йоу, звідки ти такий крутий?! Чудові результати!",
            < 90 => "ти маєш практично ідеальні результати... ми горді за тебе!",
            100 => "ти - майстер! Цікаво, чи ти в топі рейтингу?..",
            _ => string.Empty
        };
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

    private static double GetRating(UserGetRequest userGetRequest) => ((userGetRequest.RightAnswers + userGetRequest.WrongAnswers) > 0)
        ? ((double)userGetRequest.RightAnswers * 100 / (userGetRequest.RightAnswers + userGetRequest.WrongAnswers))
        : 0;

    #endregion
}

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
        {
            User.SetCurrentNickname(nickname);
            User.SetCurrentPassword(password);
            Close();

        }

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
        {
            User.SetCurrentNickname(nickname);
            User.SetCurrentPassword(password);
            Close();
        }
    }

    #endregion
}
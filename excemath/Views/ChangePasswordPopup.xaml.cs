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

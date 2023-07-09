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

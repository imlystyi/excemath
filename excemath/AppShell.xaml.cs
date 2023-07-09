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
using excemath.Views;

namespace excemath;

/// <summary>
/// Представляє оболонку та головну сторінку додатку.
/// </summary>
public partial class AppShell : Shell
{
    #region Конструктори

    /// <summary>
    /// Ініціалізує екземпляр класу <see cref="AppShell"/>.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();

        MathProblem.GenerateMixedKey();
        MathProblem.GenerateByKindKey();
        SolvedMathProblem.GenerateKey();
    }

    #endregion

    #region Обробники подій

    private void HowToUseButton_Tapped(object sender, EventArgs args) => this.ShowPopup(new HowToUsePopup());

    private void ProfileButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new ProfilePage());
    }

    private void AchievementsButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new AchievementsPage());
    }

    private void MixedKindsButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new MpAnswerEnteringPage());
    }

    private void ChooseKindButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new MpKindsPage());
    }

    private void ZNOPreparingButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new SolvedMpZNOPreparingPage());
    }

    private void StudentExamsPreparingButton_Tapped(object sender, TappedEventArgs args)
    {
        if (ShowAuthorizationPopup())
            Navigation.PushAsync(new SolvedMpStudentExamsPreparingPage());
    }

    private void AboutProgramButton_Tapped(object sender, EventArgs args)
    {
        Navigation.PushAsync(new AboutProgramPage());
    }

    #endregion

    #region Методи

    private bool ShowAuthorizationPopup()
    {
        if (!string.IsNullOrEmpty(User.GetCurrentNickname()))
            return true;

        else
        {
            this.ShowPopup(new AuthorizationPopup());

            return false;
        }
    }

    #endregion
}

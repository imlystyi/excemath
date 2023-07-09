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

using System.Collections.ObjectModel;

namespace excemath.Models;

/// <summary>
/// Представляє рейтинг користувачів як колекцію.
/// </summary>
public class RatingCollection
{
    #region Конструктори

    /// <summary>
    /// Створює екземпляр класу <see cref="RatingCollection"/>.
    /// </summary>
    public RatingCollection()
    {
        LoadRatings();
    }

    #endregion

    #region Властивості

    /// <summary>
    /// Повертає рейтинг користувачів.
    /// </summary>
    public ObservableCollection<UserRating> Ratings { get; } = new();

    #endregion

    #region Методи

    private void LoadRatings()
    {
        var list = Task.Run(ApiClient.GetRatingList).Result;
        list.ForEach(Ratings.Add);
    }

    #endregion
}

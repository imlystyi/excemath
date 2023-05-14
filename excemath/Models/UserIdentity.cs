﻿namespace excemath.Models;

/// <summary>
/// Представляє ідентичність користувача, яка має унікальний псевдонім та пароль.
/// </summary>
public class UserIdentity
{
    #region Властивості

    /// <inheritdoc cref="User.Nickname"/>
    public string Nickname { get; set; }

    /// <inheritdoc cref="User.Password"/>
    public string Password { get; set; }

    #endregion
}

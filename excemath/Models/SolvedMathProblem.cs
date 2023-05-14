﻿namespace excemath.Models;

/// <summary>
/// Представляє розв'язану математичну задачу, яка має унікальний ідентифікатор, вид, питання, правильну відповідь та покроковий розв'язок.
/// </summary>
public class SolvedMathProblem
{
    #region Властивості

    /// <inheritdoc cref="MathProblem.Id"/>
    public int Id { get; set; }

    /// <inheritdoc cref="MathProblem.Kind"/>
    public MathProblemKinds Kind { get; set; }

    /// <inheritdoc cref="MathProblem.Question"/>
    public string Question { get; set; }

    /// <inheritdoc cref="MathProblem.Answer"/>
    public string Answer { get; set; }

    /// <summary>
    /// Повертає або встановлює покроковий розв'язок у поточній задачі.
    /// </summary>
    public string Solution { get; set; }

    #endregion
}

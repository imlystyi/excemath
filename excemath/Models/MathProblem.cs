using excemath.Models;
using System;

namespace excemath.Models;

/// <summary>
/// Представляє математичну задачу, яка має унікальний ідентифікатор, вид, питання та правильну відповідь.
/// </summary>
public class MathProblem
{
    #region Поля

    private const int _ID_MIN = 1;
    private const int _MIXED_KEY_MIN = 1;
    private const int _MIXED_KEY_MAX = 5;
    private const int _BY_KIND_KEY_MIN = 1;
    private const int _BY_KIND_KEY_MAX = 3;

    private const string _MIXED_KEY_PREFERENCES_KEY = "mp_m";
    private const string _MIXED_LAST_ID_PREFERENCES_KEY = "mp_m_lid";
    private const string _BY_KIND_KEY_PREFERENCES_KEY = "mp_bk";
    private const string _BY_KIND_LAST_INDEX_PREFERENCES_KEY = "mp_bk_lindex";

    #endregion

    #region Властивості

    /// <summary>
    /// Повертає або встановлює унікальний ідентифікатор поточної задачі.
    /// </summary>
    /// <remarks>
    /// Є первинним ключом.
    /// </remarks>
    public int Id { get; set; }

    /// <summary>
    /// Повертає або встановлює вид поточної задачі, який представлений елементом перерахування <see cref="MathProblemKinds"/>.
    /// </summary>
    public MathProblemKinds Kind { get; set; }

    /// <summary>
    /// Повертає або встановлює питання поточної задачі.
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// Повертає або встановлює правильну відповідь поточної задачі.
    /// </summary>
    public string Answer { get; set; }

    /// <summary>
    /// Повертає загальну підказку до математичної задачі.
    /// </summary>
    public string Tip =>
            // TODO: розписати підказки (використовуючи LaTeX).
            Kind switch
            {
                MathProblemKinds.TableIntegral => "",
                MathProblemKinds.LineIntegral => "підказка для лінійного інтеграла",

                MathProblemKinds.Matrix => "підказка для матриць",
                MathProblemKinds.Limit => "підказка для границь",

                MathProblemKinds.LinearEquation => "підказка для лінійних рівнянь",
                MathProblemKinds.QuadraticEquation => "підказка для квадратних рівнянь",
                MathProblemKinds.IrrationalEquation => "підказка для ірраціональних рівнянь",
                MathProblemKinds.ExponentialEquation => "підказка для показникових рівнянь",
                MathProblemKinds.LogarithmicEquation => "підказка для логарифмічних рівнянь",
                MathProblemKinds.TrigonometricEquation => "підказка для тригонометричних рівнянь",

                MathProblemKinds.LinearInequality => "підказка для лінійних нерівностей ",
                MathProblemKinds.QuadraticInequality => "підказка для квадратичних нерівностей ",
                MathProblemKinds.IrrationalInequality => "підказка для ірраціональних нерівностей ",
                MathProblemKinds.ExponentialInequality => "підказка для показникових нерівностей ",
                MathProblemKinds.LogarithmicInequality => "підказка для логарифмічних нерівностей ",
                MathProblemKinds.TrigonometricInequality => "підказка для тригонометричних нерівностей ",

                MathProblemKinds.NumericalSequence => "підказка для числових послідовностях",
                MathProblemKinds.Function => "підказка для функцій",
                MathProblemKinds.Combinatorics => "підказка для комбінаторики",

                _ => throw new ArgumentException("Некоректний вид математичної проблеми", nameof(Kind))
            };

    #endregion

    #region Методи

    /// <summary>
    /// Повертає текстову частину питання математичної задачі як <see cref="string"/>.
    /// </summary>
    public string GetQuestionText() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).First();

    /// <summary>
    /// Повертає LaTeX-частину запитання математичної задачі як <see cref="string"/>.
    /// </summary>
    public string GetQuestionLatex() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).Last();

    /// <summary>
    /// Повертає номер правильної відповіді математичної задачі серед варіантів відповідей як <see cref="int"/>.
    /// </summary>
    public int GetAnswer() => int.Parse(Answer.Split(new[] { @"/opt" }, StringSplitOptions.None).First());

    /// <summary>
    /// Повертає певний варіант відповіді у форматі LaTeX як <see cref="string"/>.
    /// </summary>
    /// <param name="num">Номер варіанту відповіді.</param>
    public string GetAnswerOption(int num) => Answer.Split(new[] { @"/opt" }, StringSplitOptions.None).Last().Split(@"/n")[num - 1];

    /// <summary>
    /// Повертає вид математичної задачі у текстовому форматі як <see cref="string"/>.
    /// </summary>
    public string GetKindAsText()
    {
        return Kind switch
        {
            MathProblemKinds.TableIntegral => "Табличний інтеграл",
            MathProblemKinds.MultipleIntegral => "Кратні інтеграли",
            MathProblemKinds.LineIntegral => "Криволінійні інтеграли",
            MathProblemKinds.Matrix => "Матриці",
            MathProblemKinds.LinearEquation => "Лінійні рівняння",
            MathProblemKinds.QuadraticEquation => "Квадратні рівняння",
            MathProblemKinds.IrrationalEquation => "Ірраціональні рівняння",
            MathProblemKinds.ExponentialEquation => "Показникові рівняння",
            MathProblemKinds.LogarithmicEquation => "Логарифмічні рівняння",
            MathProblemKinds.TrigonometricEquation => "Тригонометричні рівняння",
            MathProblemKinds.LinearInequality => "Лінійні нерівності",
            MathProblemKinds.QuadraticInequality => "Квадратні нерівності",
            MathProblemKinds.IrrationalInequality => "Ірраціональні нерівності",
            MathProblemKinds.ExponentialInequality => "Показникові рівняння",
            MathProblemKinds.LogarithmicInequality => "Логарифмічні рівняння",
            MathProblemKinds.TrigonometricInequality => "Тригонометричні рівняння",
            MathProblemKinds.NumericalSequence => "Числові послідовності",
            MathProblemKinds.Function => "Функції",
            MathProblemKinds.Combinatorics => "Комбінаторика",

            _ => throw new ApplicationException("Вид математичної задачі визначено неправильно")
        };
    }

    /// <summary>
    /// Повертає випадкову математичну задачу як <see cref="MathProblem"/>.
    /// </summary>
    public static async Task<MathProblem> GetMixed()
    {
        int mixedKey = GetMixedKey();
        int lastMathProblemId = GetLastMixedId();
        int id = mixedKey + lastMathProblemId;

        MathProblem mathProblem = await ApiClient.GetMathProblem(id);

        while (mathProblem == null)
        {
            GenerateMixedKey(true);
            mixedKey = GetMixedKey();

            id = mixedKey + _ID_MIN;
            SetLastMixedId(id);

            mathProblem = await ApiClient.GetMathProblem(id);
        }

        return mathProblem;
    }

    /// <summary>
    /// Повертає випадкову математичну проблему вказаного виду як <see cref="MathProblem"/>.
    /// </summary>
    /// <param name="kind">Вид математичної проблеми.</param>
    public static async Task<MathProblem> GetByKind(MathProblemKinds kind)
    {
        int byKindKey = GetByKindKey();
        int lastMathProblemIndex = GetLastByKindIndex();
        int index = byKindKey + lastMathProblemIndex;

        List<int> ids = await ApiClient.GetMathProblemsIdsList(kind);

        int id;

        try
        {
            id = ids[index];
        }

        catch (IndexOutOfRangeException)
        {
            GenerateByKindKey(true);
            byKindKey = GetByKindKey();

            index = byKindKey + _ID_MIN;
            id = ids[index];

            SetLastByKindIndex(index);
        }

        return await ApiClient.GetMathProblem(id);
    }

    /// <summary>
    /// Генерує ключ <c>"mp_m"</c> та записує його у дані додатку, якщо його там не знайдено.
    /// </summary>
    /// <param name="forced">Визначає, чи треба записувати ключ у дані додатку примусово.</param>
    public static void GenerateMixedKey(bool forced = false)
    {
        if (!Preferences.ContainsKey(_MIXED_KEY_PREFERENCES_KEY) || forced)
        {
            Random random = new();
            int mixedKey = random.Next(_MIXED_KEY_MIN, _MIXED_KEY_MAX);

            Preferences.Set(_MIXED_KEY_PREFERENCES_KEY, mixedKey);
        }
    }

    /// <summary>
    /// Генерує ключ <c>"mp_bk"</c> та записує його у дані додатку, якщо його там не знайдено.
    /// </summary>
    /// <param name="forced">Визначає, чи треба записувати ключ у дані додатку примусово.</param>
    public static void GenerateByKindKey(bool forced = false)
    {
        if (!Preferences.ContainsKey(_BY_KIND_KEY_PREFERENCES_KEY) || forced)
        {
            Random random = new();
            int byKindKey = random.Next(_BY_KIND_KEY_MIN, _BY_KIND_KEY_MAX);

            Preferences.Set(_BY_KIND_KEY_PREFERENCES_KEY, byKindKey);
        }
    }

    private static int GetMixedKey() => Preferences.Get(_MIXED_KEY_PREFERENCES_KEY, 1);

    private static int GetByKindKey() => Preferences.Get(_BY_KIND_KEY_PREFERENCES_KEY, 1);

    private static int GetLastMixedId() => Preferences.Get(_MIXED_LAST_ID_PREFERENCES_KEY, 1);

    private static int GetLastByKindIndex() => Preferences.Get(_BY_KIND_LAST_INDEX_PREFERENCES_KEY, 1);

    private static void SetLastMixedId(int id) => Preferences.Set(_MIXED_LAST_ID_PREFERENCES_KEY, id);

    private static void SetLastByKindIndex(int index) => Preferences.Set(_BY_KIND_LAST_INDEX_PREFERENCES_KEY, index);

    #endregion
}

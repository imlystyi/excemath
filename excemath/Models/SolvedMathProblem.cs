namespace excemath.Models;

/// <summary>
/// Представляє розв'язану математичну задачу, яка має унікальний ідентифікатор, вид, питання, правильну відповідь та покроковий розв'язок.
/// </summary>
public class SolvedMathProblem
{
    #region Поля

    private const int _ID_MIN = 0;
    private const int _MIXED_KEY_MIN = 1;
    private const int _MIXED_KEY_MAX = 2;
    private const int _BY_KIND_KEY_MIN = 1;
    private const int _BY_KIND_KEY_MAX = 2;

    private const string _MIXED_KEY_PREFERENCES_KEY = "smp_m";
    private const string _MIXED_LAST_ID_PREFERENCES_KEY = "smp_m_lid";
    private const string _BY_KIND_KEY_PREFERENCES_KEY = "smp_bk";
    private const string _BY_KIND_LAST_INDEX_PREFERENCES_KEY = "smp_bk_lindex";

    #endregion

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

    #region Методи

    /// <summary>
    /// Повертає вид поточної задачі у текстовому форматі як <see cref="string"/>.
    /// </summary>
    public string GetKindAsText() => Kind switch
    {
        MathProblemKinds.TableIntegral => "Табличні інтеграли",
        MathProblemKinds.MultipleIntegral => "Кратні інтеграли",
        MathProblemKinds.LineIntegral => "Криволінійні інтеграли",
        MathProblemKinds.Limit => "Границі",
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
        _ => throw new ApplicationException("Вид поточної задачі визначено неправильно")
    };

    /// <summary>
    /// Повертає текстову частину питання поточної задачі як <see cref="string"/>.
    /// </summary>
    public string GetQuestionText() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).First();

    /// <summary>
    /// Повертає LaTeX-частину запитання поточної задачі як <see cref="string"/>.
    /// </summary>
    public string GetQuestionLatex() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).Last();

    /// <summary>
    /// Повертає номер правильної відповіді поточної задачі серед варіантів відповідей як <see cref="int"/>.
    /// </summary>
    public int GetAnswerNumber() => int.Parse(Answer.Split(new[] { @"/opt" }, StringSplitOptions.None).First());

    /// <summary>
    /// Повертає певний варіант відповіді у форматі LaTeX як <see cref="string"/>.
    /// </summary>
    /// <param name="num">Номер варіанту відповіді.</param>
    public string GetAnswerOption(int num) => Answer.Split(new[] { @"/opt" }, StringSplitOptions.None).Last().Split(@"/n")[num - 1];

    /// <summary>
    /// Повертає текстову частину загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string GetSolutionText()
    {
        string[] array = Solution.Split(new[] { @"/d" }, StringSplitOptions.None)[0].Split(new[] { @"/nl" }, StringSplitOptions.None);

        for (int ii = 0; ii < array.Length; ii++)
            array[ii] += "\n";

        return string.Join(string.Empty, array);
    }

    /// <summary>
    /// Повертає LaTeX-частину загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string GetSolutionLatex() => Solution.Split(new[] { @"/d" }, StringSplitOptions.None)[1];

    /// <summary>
    /// Повертає висоту LaTeX-частини загальної підказки до поточної задачі.
    /// <exception cref="ArgumentException"></exception>
    /// </summary>
    public int GetSolutionHeight() => int.Parse(Solution.Split(new[] { @"/d" }, StringSplitOptions.None)[2]);

    /// <summary>
    /// Повертає випадкову математичну проблему вказаного виду як <see cref="MathProblem"/>.
    /// </summary>
    /// <param name="kind">Вид математичної проблеми.</param>
    public static async Task<SolvedMathProblem> GetByKind(MathProblemKinds kind)
    {
        int byKindKey = GetByKindKey();
        int lastMathProblemIndex = GetLastByKindIndex();
        int index = byKindKey + lastMathProblemIndex - 1;

        List<int> ids = await ApiClient.GetSolvedMathProblemsList(kind);

        int id;

        try
        {
            id = ids[index];
            SetLastByKindIndex(id);
        }

        catch
        {
            SetLastByKindIndex(_ID_MIN);
            id = ids[_ID_MIN];
        }

        var sv = await ApiClient.GetSolvedMathProblem(id);
        return sv;
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

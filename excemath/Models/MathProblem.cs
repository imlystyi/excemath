namespace excemath.Models;

/// <summary>
/// Представляє математичну задачу, яка має унікальний ідентифікатор, вид, питання та правильну відповідь.
/// </summary>
public class MathProblem
{
    #region Поля

    private const int _ID_MIN = 0;
    private const int _MIXED_KEY_MIN = 1;
    private const int _MIXED_KEY_MAX = 2;
    private const int _BY_KIND_KEY_MIN = 1;
    private const int _BY_KIND_KEY_MAX = 2;

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
    public string GetTipText() => Kind switch
    {
        MathProblemKinds.TableIntegral =>
            "1. Скористайтеся таблицею інтегралів (1).\n" +
            "2. Використайте один з наступних пунктів:\n" +
            "• поділіть окремо кожен член чисельника на знаменник;\n" +
            "• скоротіть вирази;\n" +
            "• виконайте інші тотожні перетворення - допоки інтеграл не набуде табличного вигляду.",
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
        _ => throw new ArgumentException("Некоректний вид поточної проблеми", nameof(Kind))
    };

    /// <summary>
    /// Повертає LaTeX-частину загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string GetTipLatex() => Kind switch
    {
        MathProblemKinds.TableIntegral =>
@"(1)\\
\int x^a dx = \frac{x^a+1}{a+1} + C \quad \int \frac{dx}{x^2} = -\frac{1}{x} + C\\
\int x^a dx = \frac{x^a+1}{a+1} + C \quad \int \frac{dx}{x^2} = -\frac{1}{x} + C\\
\int \frac{dx}{\sqrt{x}} = 2\sqrt{x} + C \quad \int \frac{dx}{x} = \ln|x| + C\\
\int a^x dx = \frac{a^x}{\ln a} + C \quad \int e^x dx = e^x + C\\
\int \sin(x) dx = -\cos(x) + C\\
\int \cos(x) dx = \sin(x) + C\\
\int \tan(x) dx = -\ln|\cos(x)| + C\\
\int \frac{dx}{\cos^2x}  = \tan(x) + C\\
\int \frac{dx}{\sin^2x}  = -\cot(x) + C\\
\int \frac{1}{a^2+x^2} dx = \arctan(\frac{x}{a}) + C\\
\int \frac{1}{x^2-a^2} dx = \frac{1}{2a}\ln|(\frac{x}{a})| + C\\
\int \frac{1}{\sqrt{a^2-x^2}} dx = \arcsin(\frac{x}{a}) + C\\
\int \frac{dx}{\sqrt{x^2 \pm a^2}} = \ln|x + \sqrt{x^2 \pm a^2}| + C",
        MathProblemKinds.LineIntegral =>
@"підказка для лінійного інтеграла",
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
        _ => throw new ArgumentException("Некоректний вид поточної проблеми", nameof(Kind))
    };

    /// <summary>
    /// Повертає висоту LaTeX-частини загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int GetTipHeight() => Kind switch
    {
        MathProblemKinds.TableIntegral => 700,
        MathProblemKinds.LineIntegral => 780,
        MathProblemKinds.Matrix => 780,
        MathProblemKinds.Limit => 780,
        MathProblemKinds.LinearEquation => 780,
        MathProblemKinds.QuadraticEquation => 780,
        MathProblemKinds.IrrationalEquation => 780,
        MathProblemKinds.ExponentialEquation => 780,
        MathProblemKinds.LogarithmicEquation => 780,
        MathProblemKinds.TrigonometricEquation => 780,
        MathProblemKinds.LinearInequality => 780,
        MathProblemKinds.QuadraticInequality => 780,
        MathProblemKinds.IrrationalInequality => 780,
        MathProblemKinds.ExponentialInequality => 780,
        MathProblemKinds.LogarithmicInequality => 780,
        MathProblemKinds.TrigonometricInequality => 780,
        MathProblemKinds.NumericalSequence => 780,
        MathProblemKinds.Function => 780,
        _ => throw new ArgumentException("Некоректний вид поточної проблеми", nameof(Kind))
    };

    /// <summary>
    /// Повертає випадкову математичну задачу як <see cref="MathProblem"/>.
    /// </summary>
    public static async Task<MathProblem> GetMixed()
    {
        int mixedKey = GetMixedKey();
        int lastMathProblemId = GetLastMixedId();
        int id = mixedKey + lastMathProblemId;

        MathProblem mathProblem = await ApiClient.GetMathProblem(id);

        while (mathProblem is null)
        {
            GenerateMixedKey(true);
            mixedKey = GetMixedKey();

            id = mixedKey + _ID_MIN;
            SetLastMixedId(id);

            mathProblem = await ApiClient.GetMathProblem(id);
        }

        SetLastMixedId(id);

        return mathProblem;
    }

    /// <summary>
    /// Повертає випадкову математичну задачу вказаного виду як <see cref="MathProblem"/>.
    /// </summary>
    /// <param name="kind">Вид математичної проблеми.</param>
    public static async Task<MathProblem> GetByKind(MathProblemKinds kind)
    {
        int byKindKey = GetByKindKey();
        int lastMathProblemIndex = GetLastByKindIndex();
        int index = byKindKey + lastMathProblemIndex - 1;

        List<int> ids = await ApiClient.GetMathProblemsIdsList(kind);

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

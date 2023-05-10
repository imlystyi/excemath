using excemath.Models;

namespace excemath.Models;

/// <summary>
/// Представляє модель математичної проблеми, яка має унікальний ідентифікатор, тип, умову, правильну відповідь та загальну підказку.
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
    /// Повертає або встановлює унікальний ідентифікатор математичної проблеми.
    /// </summary>
    /// <returns>
    /// Унікальний ідентифікатор математичної проблеми як <see cref="int"/>. Є первинним ключом.
    /// </returns>
    public int Id { get; set; }

    /// <summary>
    /// Повертає або встановлює вид математичної проблеми, представлений елементом перерахування <see cref="MathProblemKinds"/>.
    /// </summary>
    /// <returns>
    /// Вид математичної проблеми як елемент перерахування <see cref="MathProblemKinds"/>.
    /// </returns>
    public MathProblemKinds Kind { get; set; }

    /// <summary>
    /// Повертає або встановлює питання математичної проблеми.
    /// </summary>
    /// <returns>
    /// Питання математичної проблеми як <see cref="string"/>.
    /// </returns>
    public string Question { get; set; }

    /// <summary>
    /// Повертає або встановлює правильну відповідь математичної проблеми.
    /// </summary>
    /// <returns>
    /// Правильну відповідь математичної проблеми як <see cref="string"/>.
    /// </returns>
    public string Answer { get; set; }

    /// <summary>
    /// Повертає загальну підказку математичної проблеми.
    /// </summary>
    /// <returns>
    /// Загальну підказку математичної проблеми як <see cref="string"/>.
    /// </returns>
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

                MathProblemKinds.NumericalSequences => "підказка для числових послідовностях",
                MathProblemKinds.Function => "підказка для функцій",
                MathProblemKinds.Combinatorics => "підказка для комбінаторики",

                _ => throw new ArgumentException("Некоректний вид математичної проблеми", nameof(Kind))
            };

    #endregion

    #region Методи

    /// <summary>
    /// Повертає текстову частину запитання математичної проблеми.
    /// </summary>
    /// <returns>
    /// Текстову частину запитання математичної проблеми як <see cref="string"/>.
    /// </returns>
    public string GetQuestionText() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).First();

    /// <summary>
    /// Повертає LaTeX-частину запитання математичної проблеми.
    /// </summary>
    /// <returns>
    /// LaTeX-частину запитання математичної проблеми як <see cref="string"/>.
    /// </returns>
    public string GetQuestionLatex() => Question.Split(new[] { @"/expr" }, StringSplitOptions.None).Last();

    /// <summary>
    /// Повертає номер правильної відповіді серед варіантів відповідей.
    /// </summary>
    /// <returns>
    /// Номер правильної відповіді.
    /// </returns>
    public int GetAnswer() => int.Parse(Answer.Split(new[] { @"/opt" }, StringSplitOptions.None).First());

    /// <summary>
    /// Повертає варіанти відповіді у форматі LaTeX.
    /// </summary>
    /// <returns>
    /// Варіанти відповіді у форматі LaTeX як <see cref="string"/>.
    /// </returns>
    public string GetAnswerOptions() => Answer.Split(new[] {@"/opt"}, StringSplitOptions.None).Last();

    /// <summary>
    /// Повертає випадкову математичну проблему.
    /// </summary>
    /// <returns>
    /// Математичну проблему як <see cref="MathProblem"/> (результат виконання відповідного <see cref="Task{TResult}"/>).
    /// </returns>
    public static async Task<MathProblem> GetMixed()
    {
        int mixedKey = GetMixedKey();
        int lastMathProblemId = GetLastMixedId();        
        int id = mixedKey + lastMathProblemId;

        MathProblem mathProblem = await Client.GetMathProblem(id);

        while (mathProblem == null)
        {
            GenerateMixedKey(true);
            mixedKey = GetMixedKey();

            id = mixedKey + _ID_MIN;
            SetLastMixedId(id);

            mathProblem = await Client.GetMathProblem(id);
        }

        return mathProblem;
    }

    /// <summary>
    /// Повертає випадкову математичну проблему вказаного виду.
    /// </summary>
    /// <param name="kind">Вид математичної проблеми.</param>
    /// <returns>
    /// Математичну проблему як <see cref="MathProblem"/> (результат виконання відповідного <see cref="Task{TResult}"/>).
    /// </returns>
    public static async Task<MathProblem> GetByKind(MathProblemKinds kind)
    {
        int byKindKey = GetByKindKey();
        int lastMathProblemIndex = GetLastByKindIndex();
        int index = byKindKey + lastMathProblemIndex;

        List<int> ids = await Client.GetMathProblemsIdsList(kind);

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
        
        return await Client.GetMathProblem(id);        
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

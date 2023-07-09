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
        MathProblemKinds.ExponentialInequality => "Показникові нерівності",
        MathProblemKinds.LogarithmicInequality => "Логарифмічні нерівності",
        MathProblemKinds.TrigonometricInequality => "Тригонометричні нерівності",
        MathProblemKinds.NumericalSequence => "Числові послідовності",
        MathProblemKinds.Function => "Функції",
        _ => string.Empty
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

        MathProblemKinds.MultipleIntegral =>
        "1. Намалювати область інтегрування та визначити її межі.\n" +
        "2. Переписати інтеграл з визначеними межами інтегрування.\n" +
        "3. Обчислити внутрішній інтеграл; якщо необхідно, перейти до полярної, сферичної або циліндричної системи координат.\n" +
        "4. Обчислити зовнішній інтеграл; якщо необхідно, перейти до полярної, сферичної або циліндричної системи координат. Спростити інтеграл.\n" +
        "5. Обчислити інтеграл, що вийшов, як табличний інтеграл (за необхідності, скористатися таблицею інтегралів (1)).",

        MathProblemKinds.LineIntegral =>
        "1. Намалювати область інтегрування та визначити її межі.\n" +
        "2. Переписати інтеграл з визначеними межами інтегрування.\n" +
        "3. За необхідності, розбити криволінійний інтеграл на інтеграли з іншими межами. Спростити інтеграли.\n" +
        "4. Обчислити інтеграл, що вийшов, як табличний інтеграл (за необхідності, скористатися таблицею інтегралів (1)).",

        MathProblemKinds.Limit =>
        "1. Підставте відповідне значення (до якого прямує границя) замість невідомого.\n" +
        "2. При виникненні невизаченості зробіть наступні кроки:\n" +
        "   • дріб з нескінченностей (1):  чисельник і знаменник розділити на найвищий степінь цих многочленів;\n" +
        "   • дріб з нулів при багаточленах (2): в чисельнику і знаменнику виділити критичний множник і скоротити на нього дріб;\n" +
        "   • дріб з нулів при ірраціональних виразах (2): для виділення критичного множника треба чисельник і знаменник;\n" +
        "   • нескінченість відняти нескінченість (3): шляхом елементарних перетворень звести до невизначеності виду (1) і (2);\n" +
        "   • одиниця у степіні нескінченість (4): використовують другу визначну границю (5).",

        MathProblemKinds.IrrationalEquation =>
        "1. Переходимо від ірраціонального до раціонального рівняння шляхом піднесення до певного степеня обох частин рівняння.\n" +
        "2. При піднесенні обох частин рівняння до парного степеня можуть виникати сторонні корені, тому необхідно робити перевірку або знаходити область допустимих значень.",

        MathProblemKinds.ExponentialEquation =>
        "Використати один з методів:\n" +
        "• привести рівняння до спільної основи;\n" +
        "• винести спільний множник за дужки;\n" +
        "• привести рівняння до квадратного;\n" +
        "• намалювати графік та знайти невідомі.",

        MathProblemKinds.TrigonometricEquation => 
        "1. Визначити ОДЗ.\n" +
        "2. Спробувати звести всі тригонометричні функції до одного агрумента;\n" +
        "   якщо це не вийшло, спробувати звести рівняння до однорідного;\n" +
        "   в іншому випадку, одержати добуток.",

        MathProblemKinds.IrrationalInequality =>
        "1. Виразити ірраціональний вираз з лівої частини нерівності і перенести його в праву частину, отримуючи нерівність відносно звичайного виразу.\n" +
        "2. Розв'язати отриману нерівність, зважаючи на ОДЗ.\n" +
        "3. Перевірити корені, щоб переконатись, що вони не виключаються з ОДЗ.",

        _ => string.Empty
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

        MathProblemKinds.MultipleIntegral =>
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

        MathProblemKinds.Limit =>
@"(1) \frac{\infty}{\infty}\\
(2) \frac{0}{0}\\
(3) \infty - \infty\\
(4) 1^{\infty}\\
(5) \lim_{x \to \infty} {1 + \frac{1}{x}}^x = e",

        _ => string.Empty
    };

    /// <summary>
    /// Повертає висоту LaTeX-частини загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int GetTipHeight() => Kind switch
    {
        MathProblemKinds.TableIntegral           => 700,
        MathProblemKinds.MultipleIntegral        => 700,
        MathProblemKinds.LineIntegral            => 700,
        MathProblemKinds.Limit                   => 200,
        _                                        => 0
    };

    /// <summary>
    /// Повертає лівий відступ LaTeX-частини загальної підказки до поточної задачі.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int GetTipLeftMargin() => Kind switch
    {
        MathProblemKinds.TableIntegral           => -20,
        MathProblemKinds.MultipleIntegral        => -20,
        MathProblemKinds.LineIntegral            => -20,
        MathProblemKinds.Limit                   => -190,
        _                                        => 0
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
        int index = byKindKey + lastMathProblemIndex;

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

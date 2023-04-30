using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using FluentValidation.Results;
using excemathApi.Models;

namespace excemath.Models
{
    /// <summary>
    /// Представляє HTTP-клієнт для роботи з <i>excemath API</i>.
    /// </summary>
    /// <remarks>
    /// Детальніше про <i>excemath API</i>: <see href="https://github.com/miu-miu-enjoyers/excemath-api"/>.
    /// </remarks>
    public static class ExcemathApiHttpClient
    {
        #region Поля

        private static readonly HttpClient _client = new(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

        private const string urlBase = "https://10.0.2.2:7270/api";

        #endregion

#nullable enable

        #region Методи для отримання математичних проблем

        /// <summary>
        /// Отримує список математичних проблем за вказаним списком ідентифікаторів.
        /// </summary>
        /// <param name="ids">Список ідентифікаторів математичних проблем.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та за ідентифікатором знайдено принаймні одну математичну проблему, то список математичних проблем як <see cref="List{MathProblem}"/> з елементів <see cref="MathProblem"/>;<br>
        /// інакше, <see langword="null"/>.</br>
        /// </returns>
        public async static Task<List<MathProblem>?> GetMathProblemsList(List<int> ids)
        {
            string query = ids.Select(i => $"ids={i}").Aggregate((j, k) => $"{j}&{k}");
            string url = $"{urlBase}/MathProblemsGet/ids_list?{query}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<MathProblem>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        /// <summary>
        /// Отримує список математичних проблем за вказаним видом.
        /// </summary>
        /// <param name="kind">Вид математичної проблеми.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та за видом знайдено принаймні одну математичну проблему, то список математичних проблем як <see cref="List{MathProblem}"/> з елементів <see cref="MathProblem"/>;<br>
        /// інакше, <see langword="null"/>.</br>
        /// </returns>
        public async static Task<List<MathProblem>?> GetMathProblemsList(MathProblemKinds kind)
        {
            string url = $"{urlBase}/MathProblemsGet/kinds_list/{kind}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<MathProblem>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        /// <summary>
        /// Отримує конкретну математичну проблему за вказаним ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор математичної проблеми.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та математичну проблему знайдено, то математичну проблему як <see cref="MathProblem"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<MathProblem?> GetMathProblem(int id)
        {
            string url = $"{urlBase}/MathProblemsGet/id/{id}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<MathProblem>(await response.Content.ReadAsStringAsync())
                : null;
        }

        #endregion

        #region Методи для отримання розв'язаних математичних проблем

        /// <summary>
        /// Отримує список розв'язаних математичних проблем за вказаним списком ідентифікаторів.
        /// </summary>
        /// <param name="ids">Список ідентифікаторів розв'язаних математичних проблем.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та за ідентифікатором знайдено принаймні одну розв'язану математичну проблему, то список розв'язаних математичних проблем як <see cref="List{SolvedMathProblem}"/> з елементів <see cref="SolvedMathProblem"/>;<br>
        /// інакше, <see langword="null"/>.</br>
        /// </returns>
        public async static Task<List<SolvedMathProblem>?> GetSolvedMathProblemsList(List<int> ids)
        {
            string query = ids.Select(i => $"ids={i}").Aggregate((j, k) => $"{j}&{k}");
            string url = $"{urlBase}/SolvedMathProblemsGet/ids_list?{query}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<SolvedMathProblem>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        /// <summary>
        /// Отримує список розв'язаних математичних проблем за вказаним видом.
        /// </summary>
        /// <param name="kind">Вид розв'язаної математичної проблеми.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та за видом знайдено принаймні одну розв'язану математичну проблему, то список розв'язаних математичних проблем як <see cref="List{SolvedMathProblem}"/> з елементів <see cref="SolvedMathProblem"/>;<br>
        /// інакше, <see langword="null"/>.</br>
        /// </returns>
        public async static Task<List<SolvedMathProblem>?> GetSolvedMathProblemsList(MathProblemKinds kind)
        {
            string url = $"{urlBase}/SolvedMathProblemsGet/kinds_list/{kind}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<SolvedMathProblem>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        /// <summary>
        /// Отримує конкретну розв'язану математичну проблему за вказаним ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор розв'язаної математичної проблеми.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та розв'язану проблему знайдено, то розв'язану математичну проблему як <see cref="MathProblem"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<SolvedMathProblem?> GetSolvedMathProblem(int id)
        {
            string url = $"{urlBase}/SolvedMathProblemsGet/id/{id}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<SolvedMathProblem>(await response.Content.ReadAsStringAsync())
                : null;
        }

        #endregion

        #region Методи для отримання користувачів

        /// <summary>
        /// Отримує рейтинговий список користувачів.
        /// </summary>
        /// <returns>
        /// Список користувачів як <see cref="List{T}"/> з елементів <see cref="UserRating"/>.
        /// </returns>
        public async static Task<List<UserRating>> GetRatingList()
        {
            string url = $"{urlBase}/UsersGet/rating_list";

            HttpResponseMessage response = await _client.GetAsync(url);

            return JsonConvert.DeserializeObject<List<UserRating>>(await response.Content.ReadAsStringAsync())!;
        }

        /// <summary>
        /// Отримує конкретного користувача за вказаним псевдонімом.
        /// </summary>
        /// <param name="nickname">Псевдонім користувача.</param>
        /// <returns>
        /// Якщо відповідь HTTP-сервера є успішною та користувача знайдено, то користувача як <see cref="UserGetRequest"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<UserGetRequest?> GetUser(string nickname)
        {
            string url = $"{urlBase}/UsersGet/nickname/{nickname}";

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<UserGetRequest>(await response.Content.ReadAsStringAsync())
                : null;
        }

        #endregion

#nullable restore

        #region Методи автентифікації

        /// <summary>
        /// Отримує успішність авторизації користувача, визначивши її за вказаною моделлю ідентичності.
        /// </summary>
        /// <param name="userIdentity">Модель ідентичності користувача.</param>
        /// <returns>
        /// Якщо авторизація пройшла успішно, <see langword="true"/>; інакше, <see langword="false"/>.
        /// </returns>
        public static async Task<bool> TryAuthorize(UserIdentity userIdentity)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(UserIdentity.Nickname), userIdentity.Nickname },
                { nameof(UserIdentity.Password), userIdentity.Password },
            };

            string url = QueryHelpers.AddQueryString($"{urlBase}/UsersAuthentication/authorize", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Реєструє користувача за вказаною моделлю ідентичності (додає його в фізичну базу даних).
        /// </summary>
        /// <param name="userIdentity">Модель ідентичності користувача.</param>
        /// <returns>
        /// Якщо реєстрація пройшла успішно, то <see cref="string.Empty"/>; інакше, рядок як <see cref="string"/>, що складається з помилок валідації на стороні API.
        /// </returns>
        public static async Task<string> TryRegister(UserIdentity userIdentity)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(UserIdentity.Nickname), userIdentity.Nickname },
                { nameof(UserIdentity.Password), userIdentity.Password },
            };

            string url = QueryHelpers.AddQueryString($"{urlBase}/UsersAuthentication/register", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return string.Empty;

            else
            {
                List<ValidationFailure> validationFailures = JsonConvert.DeserializeObject<List<ValidationFailure>>(await response.Content.ReadAsStringAsync());
                return string.Join(Environment.NewLine, validationFailures.Select(vf => vf.ErrorMessage));
            }
        }

        #endregion
    }
}

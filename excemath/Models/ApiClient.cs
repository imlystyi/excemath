using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using FluentValidation.Results;

namespace excemath.Models
{
    /// <summary>
    /// Представляє HTTP-клієнт для роботи з <i>excemath API</i>.
    /// </summary>
    /// <remarks>
    /// Детальніше про <i>excemath API</i>: <see href="https://github.com/miu-miu-enjoyers/excemath-api"/>.
    /// </remarks>
    public static class ApiClient
    {
        #region Поля

        private static readonly HttpClient _client = new(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

        private const string urlBase = "https://10.0.2.2:7270/api";

        #endregion

#nullable enable

        #region Методи для отримання математичних задач

        /// <summary>
        /// Повертає список ідентифікаторів об'єктів класу <see cref="MathProblem"/> за вказаним видом.
        /// </summary>
        /// <param name="kind">Вид математичної задачі.</param>
        /// <returns>
        /// Якщо сервер повернув принаймні один ідентифікатор, то список знайдених ідентифікаторів як <see cref="List{T}"/> з <see cref="int"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<List<int>?> GetMathProblemsIdsList(MathProblemKinds kind)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(MathProblem.Kind), ((int)kind).ToString() }
            };

            string url = QueryHelpers.AddQueryString(@$"{urlBase}/MathProblemsGet/kind_list", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        /// <summary>
        /// Повертає конкретний об'єкт класу <see cref="MathProblem"/> за вказаним ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор математичної задачі.</param>
        /// <returns>
        /// Якщо сервер повернув об'єкт, його як <see cref="MathProblem"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<MathProblem?> GetMathProblem(int id)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(MathProblem.Id), id.ToString() }
            };

            string url = QueryHelpers.AddQueryString(@$"{urlBase}/MathProblemsGet/id", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<MathProblem>(await response.Content.ReadAsStringAsync())
                : null;
        }

        #endregion

        #region Методи для отримання розв'язаних математичних задач

        /// <summary>
        /// Повертає список ідентифікаторів об'єктів класу <see cref="SolvedMathProblem"/> за вказаним видом.
        /// </summary>
        /// <param name="kind">Вид розв'язаної математичної задачі.</param>
        /// <returns>
        /// Якщо сервер повернув принаймні один ідентифікатор, то список знайдених ідентифікаторів як <see cref="List{T}"/> з <see cref="int"/>; інакше, <see langword="null"/>.
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
        /// Повертає конкретний об'єкт класу <see cref="SolvedMathProblem"/> за вказаним ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор розв'язаної математичної задачі.</param>
        /// <returns>
        /// Якщо сервер повернув об'єкт, його як <see cref="SolvedMathProblem"/>; інакше, <see langword="null"/>.
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
        /// Повертає рейтинговий список користувачів.
        /// </summary>
        /// <returns>
        /// Рейтинговий список користувачів як <see cref="List{T}"/> з <see cref="UserRating"/>.
        /// </returns>
        public async static Task<List<UserRating>> GetRatingList()
        {
            string url = $"{urlBase}/UsersGet/rating_list";

            HttpResponseMessage response = await _client.GetAsync(url);

            return JsonConvert.DeserializeObject<List<UserRating>>(await response.Content.ReadAsStringAsync())!;
        }

        /// <summary>
        /// Повертає конкретний об'єкт класу <see cref="UserGetRequest"/> за вказаним псевдонімом.
        /// </summary>
        /// <param name="nickname">Псевдонім користувача.</param>
        /// <returns>
        /// Якщо сервер повернув об'єкт, його як <see cref="UserGetRequest"/>; інакше, <see langword="null"/>.
        /// </returns>
        public async static Task<UserGetRequest?> GetUser(string nickname)
        {
            Dictionary<string, string> parameters = new() { { nameof(User.Nickname), nickname } };

            string url = QueryHelpers.AddQueryString(@$"{urlBase}/UsersGet/nickname", parameters);

            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<UserGetRequest>(await response.Content.ReadAsStringAsync())
                : null;
        }

        #endregion

#nullable restore

        #region Методи автентифікації

        /// <summary>
        /// Повертає інформацію про успішність авторизації користувача, визначивши її за вказаною ідентичністю користувача (об'єктом класу <see cref="UserIdentity"/>).
        /// </summary>
        /// <param name="userIdentity">Ідентичність користувача.</param>
        /// <returns>
        /// Якщо авторизація пройшла успішно, <see langword="true"/>; інакше, <see langword="false"/>.
        /// </returns>
        public static async Task<bool> TryAuthorizeUser(UserIdentity userIdentity)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(UserIdentity.Nickname), userIdentity.Nickname },
                { nameof(UserIdentity.Password), userIdentity.Password },
            };

            string url = QueryHelpers.AddQueryString(@$"{urlBase}/UsersAuthentication/authorize", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Реєструє користувача, використовуючи вказану ідентичність користувача (об'єкт класу <see cref="UserIdentity"/>).
        /// </summary>
        /// <param name="userIdentity">Ідентичність користувача.</param>
        /// <returns>
        /// Якщо реєстрація пройшла успішно, то <see cref="string.Empty"/>; інакше, рядок як <see cref="string"/>, що складається з помилок валідації на стороні API.
        /// </returns>
        public static async Task<string> TryRegisterUser(UserIdentity userIdentity)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(UserIdentity.Nickname), userIdentity.Nickname },
                { nameof(UserIdentity.Password), userIdentity.Password },
            };

            string url = QueryHelpers.AddQueryString($"{urlBase}/UsersAuthentication/register", parameters);

            //string requestContent = $"{nameof(UserIdentity.Nickname)}={userIdentity.Nickname}&{nameof(UserIdentity.Password)}={userIdentity.Password}";
            StringContent stringContent = new(string.Empty);
            HttpResponseMessage response = await _client.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
                return string.Empty;

            else
            {
                List<ValidationFailure> validationFailures = JsonConvert.DeserializeObject<List<ValidationFailure>>(await response.Content.ReadAsStringAsync());

                if (validationFailures.Any(vf => vf.ErrorCode == "01") && validationFailures.Any(vf => vf.ErrorCode == "03"))
                    return "Неправильний нікнейм і пароль!";

                else 
                    return string.Join(" ", validationFailures.Select(vf => vf.ErrorMessage));
            }
        }

        /// <summary>
        /// Оновлює дані користувача за його псевдонімом, використовуючи вказаного користувача для запиту оновлення (об'єкт класу <see cref="UserUpdateRequest"/>).
        /// </summary>
        /// <param name="nickname">Псевдонім користувача.</param>
        /// <param name="userUpdateRequest">Користувач для запиту оновлення.</param>
        /// <returns>
        /// Якщо оновлення пройшло успішно, то <see cref="string.Empty"/>; інакше, якщо користувача з таким псевдонімом не знайдено, повідомлення про таку помилку як <see cref="string"/>; інакше, якщо користувача знайдено, але оновлення не пройшло успішно, рядок як <see cref="string"/>, що складається з помилок валідації на стороні API.
        /// </returns>
        public static async Task<string> TryUpdateUser(string nickname, UserUpdateRequest userUpdateRequest)
        {
            Dictionary<string, string> parameters = new()
            {
                { nameof(nickname), nickname },
                { nameof(UserUpdateRequest.Password), userUpdateRequest.Password },
                { nameof(UserUpdateRequest.RightAnswers), userUpdateRequest.RightAnswers.ToString() },
                { nameof(UserUpdateRequest.WrongAnswers), userUpdateRequest.WrongAnswers.ToString() }
            };

            string url = QueryHelpers.AddQueryString($"{urlBase}/UsersAuthentication/update/{nickname}", parameters);
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return string.Empty;

            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return "Користувача з таким псевдонімом не знайдено";

            else
            {
                List<ValidationFailure> validationFailures = JsonConvert.DeserializeObject<List<ValidationFailure>>(await response.Content.ReadAsStringAsync());
                return string.Join(Environment.NewLine, validationFailures.Select(vf => vf.ErrorMessage));
            }
        }

        #endregion
    }
}

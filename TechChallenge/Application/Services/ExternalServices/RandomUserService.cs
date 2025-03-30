using System.Text.Json;
using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.IExternalServices;

namespace TechChallenge.Application.Services.ExternalServices
{
    public class RandomUserService : IRandomUserService
    {
        #region[PROPERTIES]
        private readonly HttpClient _httpClient;
        #endregion

        #region[CONSTRUCTOR]
        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        #region[METHODS]
        public async Task<List<User>> GetUserRandom(CreateUserDto createUser)
        {
            var response = await _httpClient.GetFromJsonAsync<JsonElement>($"https://randomuser.me/api/?results={createUser.Amount}");
            var users = new List<User>();

            foreach (var result in response.GetProperty("results").EnumerateArray())
            {
                var user = new User(result.GetProperty("name").GetProperty("first").GetString(), result.GetProperty("name").GetProperty("last").GetString(), result.GetProperty("dob").GetProperty("date").GetDateTime(),
                    result.GetProperty("gender").GetString(), result.GetProperty("phone").GetString(), result.GetProperty("email").GetString());

                users.Add(user);
            }

            return users;
        }
        #endregion
    }
}

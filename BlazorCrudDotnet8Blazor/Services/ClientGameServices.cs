using CRUD_Game.Models;
using System.Net.Http.Json;

namespace CRUD_Game.Services
{
    public class ClientGameServices : IGameServices
    {
        private readonly HttpClient httpClient;

        public ClientGameServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Game> AddGame(Game game)
        {
            var result = await httpClient
                .PostAsJsonAsync("/Api/game", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        //public async Task<bool> DeleteGame(int id)
        //{
        //    var result = await httpClient.DeleteAsync($"/Api/games/{id}");
        //    return result.Content.ReadFromJsonAsync<bool>();
        //}
        public async Task<bool> DeleteGame(int id)
        {
            // Send DELETE request to the API endpoint
            HttpResponseMessage response = await httpClient.DeleteAsync($"/Api/games/{id}");

            // Ensure the request was successful (status code 200-299)
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a boolean
                bool deletionResult = await response.Content.ReadFromJsonAsync<bool>();

                return deletionResult;
            }
            else
            {
                // Handle the case where the API request was not successful
                // For example, you might throw an exception or return false
                return false;
            }
        }



        public async Task<Game> EditGame(int id, Game game)
        {
            var result = await httpClient.PutAsJsonAsync($"/Api/games/{id}", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            var result = await httpClient.GetAsync("/Api/games"); // Adjust the endpoint as needed
            result.EnsureSuccessStatusCode(); // Ensure the request was successful
            return await result.Content.ReadFromJsonAsync<List<Game>>();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
           var result = await httpClient
                .GetFromJsonAsync<Game>($"/Api/games/{id}");
             return result;   
        }



    }
}

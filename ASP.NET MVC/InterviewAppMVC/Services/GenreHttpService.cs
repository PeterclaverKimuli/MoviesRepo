using InterviewAppMVC.Interfaces;
using InterviewAppMVC.Models;
using InterviewAppMVC.ViewModels;
using Newtonsoft.Json;

namespace InterviewAppMVC.Services
{
    public class GenreHttpService : IGenreHttpService
    {
        private readonly HttpClient _httpClient;
        Uri baseAddress = new Uri("http://localhost:5085/api/Genres");

        public GenreHttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = new List<Genre>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                genres = JsonConvert.DeserializeObject<List<Genre>>(data);
            }
            else
            {
                genres = null;
            }

            return genres;
        }
    }
}

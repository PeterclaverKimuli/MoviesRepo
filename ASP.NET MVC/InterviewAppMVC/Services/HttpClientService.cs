using InterviewAppMVC.Interfaces;
using InterviewAppMVC.ViewModels;
using Newtonsoft.Json;
using System.Net;

namespace InterviewAppMVC.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        Uri baseAddress = new Uri("http://localhost:5062/api/movies");

        public HttpClientService()
        {
            _httpClient = new HttpClient();   
            _httpClient.BaseAddress = baseAddress;
        }

        public async Task<IEnumerable<MovieListViewModel>> GetAllMovies()
        {
            var movieList = new List<MovieListViewModel>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                movieList = JsonConvert.DeserializeObject<List<MovieListViewModel>>(data);
            }
            else
            {
                movieList = null;
            }

            return movieList;
        }

        public async Task<MovieListViewModel> GetMovie(int id)
        {
            var movie = new MovieListViewModel();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<MovieListViewModel>(data);
            }
            else
            {
                movie = null;
            }

            return movie;
        }
    }
}

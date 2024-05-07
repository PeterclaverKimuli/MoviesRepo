using InterviewAppMVC.Interfaces;
using InterviewAppMVC.Models;
using InterviewAppMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InterviewAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientService httpClient;
        private readonly IGenreHttpService genreHttpService;

        public HomeController(ILogger<HomeController> logger, IHttpClientService httpClient, 
            IGenreHttpService genreHttpService)
        {
            _logger = logger;
            this.httpClient = httpClient;
            this.genreHttpService = genreHttpService;
        }

        public async Task<IActionResult> Index()
        {
            var movieList = await httpClient.GetAllMovies();

            return View(movieList);
        }

        public async Task<IActionResult> New()
        {
            var genres = await genreHttpService.GetAllGenres();

            var movieForm = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("NewMovie", movieForm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await httpClient.GetMovie(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

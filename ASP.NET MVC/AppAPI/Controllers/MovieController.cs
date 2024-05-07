using AppAPI.Core.Interfaces;
using AppAPI.Core.Models;
using AppAPI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AppAPI.Controllers
{
    [Route("/api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MovieController(IMovieRepository movieRepository, IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] SaveMovieDto movieDto) {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Log.Error(error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            var movie = mapper.Map<SaveMovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;

            Log.Information("Adding a movie to the Database...");

            await movieRepository.AddAsync(movie);
            await unitOfWork.Complete();

            var result = mapper.Map<Movie, SaveMovieDto>(movie);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] SaveMovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Log.Error(error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            var movie = await movieRepository.GetMovieAsync(id);
            if(movie == null)
            {
                Log.Error("The movie is not available in the Database.");
                return NotFound();
            }

            Log.Information("Updating a movie in the Database...");

            mapper.Map<SaveMovieDto, Movie>(movieDto, movie);
            await unitOfWork.Complete();

            var result = mapper.Map<Movie, SaveMovieDto>(movie);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await movieRepository.GetMovieAsync(id);

            if (movie == null){
                Log.Error("The movie is not available in the Database.");
                return NotFound();
            }

            Log.Information("Removing a movie from the Database...");

            movieRepository.Remove(movie);
            await unitOfWork.Complete();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await movieRepository.GetMovieAsync(id);

            if (movie == null){
                Log.Error("The movie is not available in the Database");
                return NotFound();
            }

            Log.Information("Retrieving the movie from the Database...");
            
            var movieDto = mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            Log.Information("Retrieving the movies from the Database...");
            var movies = await movieRepository.GetAllMoviesAsync();
            
            if(movies == null)
            {
                Log.Error("There are no movies available in the Database");
                return NotFound();
            }

            var moviesDto = movies.Select(m => mapper.Map<Movie, MovieDto>(m));

            return Ok(moviesDto);
        }
    }
}

using ADOApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres() {
            var genres = await genreRepository.GetGenresAsync();

            if (genres == null) 
                return NotFound();

            return Ok(genres);
        }
    }
}

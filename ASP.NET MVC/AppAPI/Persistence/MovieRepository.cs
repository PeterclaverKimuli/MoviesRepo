using AppAPI.Core.Interfaces;
using AppAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext context;

        public MovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a movie object to the Movies table in the Database
        /// </summary>
        /// <param name="movie">Movie object to be added to the Database</param>
        public async Task AddAsync(Movie movie)
        {
            await context.Movies.AddAsync(movie);
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await context.Movies
                .Include(g => g.Genre)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await context.Movies.Include(g => g.Genre).ToListAsync();
        }

        public void Remove(Movie movie)
        {
            context.Remove(movie);
        }
    }
}

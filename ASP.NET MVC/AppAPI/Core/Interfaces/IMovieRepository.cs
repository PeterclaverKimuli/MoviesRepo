using AppAPI.Core.Models;

namespace AppAPI.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieAsync(int id);

        /// <summary>
        /// Returns all movies in the Database
        /// </summary>
        /// <returns>An IEnumerable of movies in the Database</returns>
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        /// <summary>
        /// Adds a movie object to the Movies table in the Database
        /// </summary>
        /// <param name="movie">Movie object to be added to the Database</param>
        Task AddAsync(Movie movie);
        void Remove(Movie movie);
    }
}

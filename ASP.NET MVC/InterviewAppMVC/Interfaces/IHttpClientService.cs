using InterviewAppMVC.ViewModels;

namespace InterviewAppMVC.Interfaces
{
    public interface IHttpClientService
    {
        /// <summary>
        /// Retrieves all the movies from the Database.
        /// </summary>
        /// <returns>Returns an IEnumerable of movies.</returns>
        Task<IEnumerable<MovieListViewModel>> GetAllMovies();

        /// <summary>
        ///  Retrieves a movie from the Database
        /// </summary>
        /// <param name="id">Id of the movie to retrieve</param>
        /// <returns>Returns a movie object.</returns>
        Task<MovieListViewModel> GetMovie(int id);
    }
}

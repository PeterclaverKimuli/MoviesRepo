using ADOApi.Core.Models;

namespace ADOApi.Core.Interfaces
{
    public interface IGenreRepository
    {
        /// <summary>
        /// Retrieves all genres from the Genres table in the Database
        /// </summary>
        /// <returns>An IEnumerable of genre objects in the Database</returns>
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}

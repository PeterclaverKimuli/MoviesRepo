using InterviewAppMVC.Models;
using InterviewAppMVC.ViewModels;

namespace InterviewAppMVC.Interfaces
{
    public interface IGenreHttpService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
    }
}

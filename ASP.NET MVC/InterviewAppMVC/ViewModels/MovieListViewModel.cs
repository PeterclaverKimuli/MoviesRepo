using System.ComponentModel.DataAnnotations;
using InterviewAppMVC.Models;

namespace InterviewAppMVC.ViewModels
{
    public class MovieListViewModel : Identity
    {
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
    }
}

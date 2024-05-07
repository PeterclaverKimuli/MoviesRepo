using InterviewAppMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace InterviewAppMVC.ViewModels
{
    public class MovieFormViewModel : Identity
    {
        [Required(ErrorMessage = "Please input a release date")]
        [Display(Name = "Release Date")]
        //[DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please input number in stock")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Number in stock should be more than 0")]
        public int? NumberInStock {  get; set; }

        [Required(ErrorMessage = "Please input a genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        //public MovieFormViewModel() : base() { }
    }
}

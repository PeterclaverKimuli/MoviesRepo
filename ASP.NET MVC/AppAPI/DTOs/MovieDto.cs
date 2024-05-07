using AppAPI.Core.Models;

namespace AppAPI.DTOs
{
    public class MovieDto : Identity
    {
        public DateTime ReleaseDate { get; set; }
        public GenreDto Genre { get; set; }
    }
}

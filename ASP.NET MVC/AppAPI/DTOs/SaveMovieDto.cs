using AppAPI.Core.Models;

namespace AppAPI.DTOs
{
    public class SaveMovieDto : Identity
    {
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
        public int GenreId { get; set; }
    }
}

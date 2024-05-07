using System.ComponentModel.DataAnnotations;

namespace AppAPI.Core.Models
{
    public class Movie : Identity
    {
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

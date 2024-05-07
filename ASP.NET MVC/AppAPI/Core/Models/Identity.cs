using System.ComponentModel.DataAnnotations;

namespace AppAPI.Core.Models
{
    public class Identity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}

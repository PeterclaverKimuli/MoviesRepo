using System.ComponentModel.DataAnnotations;

namespace InterviewAppMVC.ViewModels
{
    public class Identity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input a name")]
        [StringLength(255)]
        public string Name { get; set; }

        //public Identity()
        //{
        //    Id = 0;
        //}
    }
}

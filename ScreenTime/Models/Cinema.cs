using ScreenTime.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ScreenTime.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}

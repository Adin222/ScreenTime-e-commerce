using ScreenTime.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ScreenTime.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}

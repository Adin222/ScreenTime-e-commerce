using ScreenTime.Data.Base;
using ScreenTime.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenTime.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Description = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Description = "Movie Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Description = "Price in $")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Movie poster URL is required")]
        [Display(Description = "Movie poster URL")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        [Display(Description = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        [Display(Description = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie Category is required")]
        [Display(Description = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Select actor(s) is required")]
        [Display(Description = "Select actor(s)")]
        public List<int>? ActorIds { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Description = "Select a city")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [Display(Description = "Select a movie producer")]
        public int ProducerId { get; set; }
    }
}

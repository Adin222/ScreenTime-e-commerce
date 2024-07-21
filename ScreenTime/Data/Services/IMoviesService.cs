using ScreenTime.Data.Base;
using ScreenTime.Data.ViewModels;
using ScreenTime.Models;

namespace ScreenTime.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValue();

        Task AddNewMovie(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);
    }
}

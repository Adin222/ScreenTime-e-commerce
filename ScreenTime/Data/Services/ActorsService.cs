using ScreenTime.Data.Base;
using ScreenTime.Models;

namespace ScreenTime.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) {}
    }
}

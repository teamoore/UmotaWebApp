using Prizma.Core.Model;
using UmotaWebApp.Shared;

namespace Prizma.Core.Repositories
{
    public interface IMahalRepository : IRepository<Mahal>
    {
        Task<IEnumerable<Mahal>> GetMahalsListAsync();

        Task<IEnumerable<V005Mahal>> GetMahals(int turref, int projeref);
    }
}

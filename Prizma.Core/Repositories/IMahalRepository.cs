using Prizma.Core.Model;

namespace Prizma.Core.Repositories
{
    public interface IMahalRepository : IRepository<Mahal>
    {
        Task<IEnumerable<Mahal>> GetMahalsListAsync();
    }
}

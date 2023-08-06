using Prizma.Core.Model;
using UmotaWebApp.Shared;

namespace Prizma.Core.Services
{
    public interface IMahalService
    {
        Task<IEnumerable<Mahal>> GetMahalsList();

        Task<IEnumerable<V005Mahal>> GetMahals(int turref, int projeref);
    }
}

using Prizma.Core.Model;

namespace Prizma.Core.Services
{
    public interface IMahalService
    {
        Task<IEnumerable<Mahal>> GetMahalsList(); 
    }
}

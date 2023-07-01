using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //IMusicRepository Musics { get; }
        //IArtistRepository Artists { get; }

        ITalepDetayRepository TalepDetays { get; }
        Task<int> CommitAsync();
    }
}

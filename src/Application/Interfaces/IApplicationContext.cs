using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpStorage.Domain;

namespace SimpStorage.Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Metadata> Metadatas { get; }
        DbSet<BinaryObject> BinaryObjects { get; }
        void RaiseApplicationEvent(IApplicationEvent evt);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace SimpStorage.Application.Interfaces
{
    public interface IApplicationEvent
    {
        Task InvokeAsync(IApplicationContext context, CancellationToken cancellationToken);
    }
}

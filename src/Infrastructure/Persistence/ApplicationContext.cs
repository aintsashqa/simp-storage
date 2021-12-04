using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpStorage.Application.Interfaces;
using SimpStorage.Domain;

namespace SimpStorage.Infrastructure.Persistence
{
    internal class ApplicationContext : DbContext, IApplicationContext
    {
        private readonly ICollection<IApplicationEvent> _events;

        public DbSet<Metadata> Metadatas => Set<Metadata>();
        public DbSet<BinaryObject> BinaryObjects => Set<BinaryObject>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            _events = new List<IApplicationEvent>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public void RaiseApplicationEvent(IApplicationEvent evt)
        {
            _events.Add(evt);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var evt in _events)
            {
                await evt.InvokeAsync(this, cancellationToken);
            }

            _events.Clear();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

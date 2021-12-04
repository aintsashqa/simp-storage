using System;

namespace SimpStorage.Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    }
}

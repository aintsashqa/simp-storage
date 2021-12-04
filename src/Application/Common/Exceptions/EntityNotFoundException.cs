using System;

namespace SimpStorage.Application.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityType, Guid entityId)
            : base($"Cannot found {entityType} by primary key ({entityId}) in database") { }
    }
}

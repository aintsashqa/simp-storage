using System;
using SimpStorage.Application.Common.Exceptions;
using SimpStorage.Domain;

namespace SimpStorage.Application.Queries.GetBinaryObjectDetails
{
    public class BinaryObjectNotFoundException : EntityNotFoundException
    {
        public BinaryObjectNotFoundException(Guid binaryObjectId)
            : base(nameof(BinaryObject), binaryObjectId) { }
    }
}

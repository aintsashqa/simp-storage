using System.Collections.Generic;
using MediatR;

namespace SimpStorage.Application.Queries.GetBinaryObjectsCollection
{
    public record GetBinaryObjectsCollectionQuery(
        int Limit,
        int Offset,
        BinaryObjectsCollectionOrder Order = BinaryObjectsCollectionOrder.None
    ) : IRequest<IEnumerable<BinaryObjectCollectionItemDto>>;
}

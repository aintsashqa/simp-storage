using System;

namespace SimpStorage.Application.Queries.GetBinaryObjectsCollection
{
    public record BinaryObjectCollectionItemDto(
        Guid Id,
        BinaryObjectItemMetadataDto Metadata
    );
}

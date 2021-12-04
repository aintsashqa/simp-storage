using System;

namespace SimpStorage.Application.Queries.GetBinaryObjectDetails
{
    public record BinaryObjectDetailsDto(
        Guid Id,
        byte[] Data,
        BinaryObjectMetadataDto Metadata
    );
}

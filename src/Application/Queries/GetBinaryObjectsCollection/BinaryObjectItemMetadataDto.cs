using System;

namespace SimpStorage.Application.Queries.GetBinaryObjectsCollection
{
    public record BinaryObjectItemMetadataDto(
        long Size,
        string Filename,
        string Extension,
        DateTime CreationDate
    );
}

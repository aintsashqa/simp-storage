using System;

namespace SimpStorage.Application.Queries.GetBinaryObjectDetails
{
    public record BinaryObjectMetadataDto(
        long Size,
        string Filename,
        string Extension,
        string ContentType,
        DateTime CreationDate
    );
}

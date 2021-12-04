using MediatR;

namespace SimpStorage.Application.Commands.AddBinaryObject
{
    public record AddBinaryObjectCommand(
        long Length,
        string Filename,
        string Extension,
        string ContentType,
        byte[] Content
    ) : IRequest;
}

using System;
using MediatR;

namespace SimpStorage.Application.Queries.GetBinaryObjectDetails
{
    public record GetBinaryObjectDetailsQuery(
        Guid Id
    ) : IRequest<BinaryObjectDetailsDto>;
}

using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpStorage.Application.Interfaces;

namespace SimpStorage.Application.Queries.GetBinaryObjectDetails
{
    public class GetBinaryObjectDetailsQueryHandler
        : IRequestHandler<GetBinaryObjectDetailsQuery, BinaryObjectDetailsDto>
    {
        private readonly IApplicationContext _context;

        public GetBinaryObjectDetailsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BinaryObjectDetailsDto> Handle(GetBinaryObjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var binaryObject = await _context.BinaryObjects
                .Include(x => x.Metadata)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (binaryObject is null)
            {
                throw new BinaryObjectNotFoundException(request.Id);
            }

            return binaryObject.Adapt<BinaryObjectDetailsDto>();
        }
    }
}

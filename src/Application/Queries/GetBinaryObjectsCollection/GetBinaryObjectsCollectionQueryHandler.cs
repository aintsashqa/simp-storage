using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpStorage.Application.Interfaces;

namespace SimpStorage.Application.Queries.GetBinaryObjectsCollection
{
    public class GetBinaryObjectsCollectionQueryHandler
        : IRequestHandler<GetBinaryObjectsCollectionQuery, IEnumerable<BinaryObjectCollectionItemDto>>
    {
        private readonly IApplicationContext _context;

        public GetBinaryObjectsCollectionQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BinaryObjectCollectionItemDto>> Handle(GetBinaryObjectsCollectionQuery request,
            CancellationToken cancellationToken)
        {
            var binaryObjectsQuery = _context.BinaryObjects.AsQueryable();
            switch (request.Order)
            {
                case BinaryObjectsCollectionOrder.BySize:
                    binaryObjectsQuery = binaryObjectsQuery.OrderBy(x => x.Metadata.Size);
                    break;

                case BinaryObjectsCollectionOrder.ByFilename:
                    binaryObjectsQuery = binaryObjectsQuery.OrderBy(x => x.Metadata.Filename);
                    break;

                case BinaryObjectsCollectionOrder.ByCreationDate:
                    binaryObjectsQuery = binaryObjectsQuery.OrderBy(x => x.Metadata.CreationDate);
                    break;

                case BinaryObjectsCollectionOrder.None:
                default:
                    break;
            }

            return await binaryObjectsQuery
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectToType<BinaryObjectCollectionItemDto>()
                .ToArrayAsync(cancellationToken);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpStorage.Application.Events;
using SimpStorage.Application.Interfaces;
using SimpStorage.Domain;

namespace SimpStorage.Application.Commands.AddBinaryObject
{
    public class AddBinaryObjectCommandHandler : IRequestHandler<AddBinaryObjectCommand>
    {
        private readonly IApplicationContext _context;

        public AddBinaryObjectCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddBinaryObjectCommand request, CancellationToken cancellationToken)
        {
            var binaryObject = new BinaryObject { Data = request.Content };
            var createMetadataEvent = new CreateMetadataEvent(request.Length,
                request.Filename, request.Extension, request.ContentType, binaryObject);

            _context.RaiseApplicationEvent(createMetadataEvent);
            await _context.BinaryObjects.AddAsync(binaryObject, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

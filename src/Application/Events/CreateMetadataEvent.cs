using System.Threading;
using System.Threading.Tasks;
using SimpStorage.Application.Interfaces;
using SimpStorage.Domain;

namespace SimpStorage.Application.Events
{
    internal class CreateMetadataEvent : IApplicationEvent
    {
        public long Size { get; }
        public string Filename { get; }
        public string Extension { get; }
        public string ContentType { get; set; }
        public BinaryObject BinaryObject { get; }

        public CreateMetadataEvent(long size, string filename, string extension, string contentType, BinaryObject binaryObject)
        {
            Size = size;
            Filename = filename;
            Extension = extension;
            ContentType = contentType;
            BinaryObject = binaryObject;
        }

        public async Task InvokeAsync(IApplicationContext context, CancellationToken cancellationToken)
        {
            var metadata = new Metadata
            {
                Size = Size,
                Filename = Filename,
                Extension = Extension,
                ContentType = ContentType,
                BinaryObject = BinaryObject
            };

            BinaryObject.Metadata = metadata;
            await context.Metadatas.AddAsync(metadata, cancellationToken);
        }
    }
}
